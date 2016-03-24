using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Draft_Winners
{
    public partial class NHLPlayerSelectionForm : Form
    {
        // All players total
        private List<Player> mCenterList;
        private List<Player> mWingerList;
        private List<Player> mDefenseList;
        private List<Player> mGoalieList;
        private List<Player> mUtilList;

        // subsets of total players spliced into boxes, need a better design to house all of this information.
        private List<Player> mFixedCenter1;
        private List<Player> mFixedCenter2;

        private List<Player> mFixedWinger1;
        private List<Player> mFixedWinger2;
        private List<Player> mFixedWinger3;

        private List<Player> mFixedGoalie;

        private List<Player> mFixedDefense1;
        private List<Player> mFixedDefense2;

        private List<Player> mFixedUtility;

        private List<Team> mTeamList;

        protected int mSalaryCap;
        protected int mSalaryThreshold;

        public NHLPlayerSelectionForm(List<Player> centerList, List<Player> wingerList,
         List<Player> defenseList, List<Player> goalieList, int salaryCap, int salaryThreshold)
        {
            InitializeComponent();

            mCenterList = centerList;
            mWingerList = wingerList;
            mDefenseList = defenseList;
            mGoalieList = goalieList;
            mUtilList = centerList.Concat(wingerList).Concat(defenseList).ToList();

            fillComboBox(goalieBox, mGoalieList);
            fillComboBox(centerBox1, mCenterList);
            fillComboBox(centerBox2, mCenterList);
            fillComboBox(defenseBox1, mDefenseList);
            fillComboBox(defenseBox2, mDefenseList);
            fillComboBox(wingerBox1, mWingerList);
            fillComboBox(wingerBox2, mWingerList);
            fillComboBox(wingerBox3, mWingerList);
            fillComboBox(utilBox, mUtilList);

            mTeamList = new List<Team>();
            mSalaryCap = salaryCap;
            mSalaryThreshold = salaryThreshold;
        }

        private void fillComboBox(ComboBox box, List<Player> list)
        {
            foreach (Player player in list)
            {
                box.Items.Add(player.getName());
            }
        }

        private List<Player> parseComboBox(ComboBox box, List<Player> list)
        {
            if (box.SelectedItem == null)
            {
                return list;
            }

            foreach (Player player in list)
            {
                if (box.SelectedItem.ToString() == player.getName())
                {
                    List<Player> playerList = new List<Player>();
                    playerList.Add(player);
                    return playerList;
                }
            }
            return list;
        }

        private void fillPlayerArrays()
        {
            mFixedGoalie = parseComboBox(goalieBox, mGoalieList);

            mFixedCenter1 = parseComboBox(centerBox1, mCenterList);
            mFixedCenter2 = parseComboBox(centerBox2, mCenterList);

            mFixedDefense1 = parseComboBox(defenseBox1, mDefenseList);
            mFixedDefense2 = parseComboBox(defenseBox2, mDefenseList);

            mFixedWinger1 = parseComboBox(wingerBox1, mWingerList);
            mFixedWinger2 = parseComboBox(wingerBox2, mWingerList);
            mFixedWinger3 = parseComboBox(wingerBox3, mWingerList);

            mFixedUtility = parseComboBox(utilBox, mUtilList);
        }

        private void createTeamButton_Click(object sender, EventArgs e)
        {
            fillPlayerArrays();
            Thread generatorThread = new Thread(() =>
            {
                generateTeams();
                this.Invoke((MethodInvoker)delegate
                {
                    createTeamButton.Visible = true;
                    MainForm.saveFile(convertTeamsToCSVStrings());
                });
            });

            createTeamButton.Visible = false;
            generatorThread.Start();
        }

        public void generateTeams()
        {
            foreach (Player g in mFixedGoalie)
            {
                Team team = new Team();
                team.addPlayer(g);
                foreach (Player c1 in mFixedCenter1)
                {
                    team.addPlayer(c1);
                    foreach (Player c2 in mFixedCenter2)
                    {
                        if (c2.Equals(c1))
                        {
                            continue;
                        }
                        team.addPlayer(c2);
                        foreach (Player w1 in mFixedWinger1)
                        {
                            team.addPlayer(w1);
                            foreach (Player w2 in mFixedWinger2)
                            {
                                if (w2.Equals(w1))
                                {
                                    continue;
                                }
                                team.addPlayer(w2);
                                foreach (Player w3 in mFixedWinger3)
                                {
                                    if (w3.Equals(w1) || w3.Equals(w2))
                                    {
                                        continue;
                                    }
                                    team.addPlayer(w3);
                                    foreach (Player d1 in mFixedDefense1)
                                    {
                                        team.addPlayer(d1);
                                        foreach (Player d2 in mFixedDefense2)
                                        {
                                            if (d2.Equals(d1))
                                            {
                                                continue;
                                            }
                                            team.addPlayer(d2);
                                            foreach (Player util in mFixedUtility)
                                            {
                                                if (util.Equals(c1) || util.Equals(c2) || util.Equals(w1) || util.Equals(w2) || util.Equals(w3) || util.Equals(d1) || util.Equals(d2))
                                                {
                                                    continue;
                                                }

                                                team.addPlayer(util);
                                                addTeam(new Team(team));
                                                team.removePlayer(util);
                                            }
                                            team.removePlayer(d2);
                                        }
                                        team.removePlayer(d1);
                                    }
                                    team.removePlayer(w3);
                                }
                                team.removePlayer(w2);
                            }
                            team.removePlayer(w1);
                        }
                        team.removePlayer(c2);
                    }
                    team.removePlayer(c1);
                }
            }
        }

        //DUPLICATING A LOT OF LOGIC FROM GENERATE TEAMS THIS NEEDS A BETTER DESIGN.
        private void addTeam(Team team)
        {
            if (team.getTeamsTotalSalary() < mSalaryCap - mSalaryThreshold || team.getTeamsTotalSalary() > mSalaryCap || isDuplicate(team))
            {
                return;
            }

            if (mTeamList.Count < 30)
            {
                mTeamList.Add(team);
                return;
            }

            Team lowestTeam = mTeamList[0];
            foreach (Team x in mTeamList)
            {
                if (lowestTeam.getTeamsTotalPoints() > x.getTeamsTotalPoints())
                {
                    lowestTeam = x;
                    continue;
                }
            }

            mTeamList.Remove(lowestTeam);
            mTeamList.Add(team);
        }

        private bool isDuplicate(Team addedTeam)
        {
            foreach (Team team in mTeamList)
            {
                if (team.Equals(addedTeam))
                {
                    return true;
                }
            }

            return false;
        }

        public String convertTeamsToCSVStrings()
        {
            mTeamList.Sort((a, b) => { return b.getTeamsTotalPoints().CompareTo(a.getTeamsTotalPoints()); });
            String fullCSV = "";
            int i = 1;
            foreach (Team team in mTeamList)
            {
                fullCSV += team.toCSV(i++);
            }

            return fullCSV;
        }
    }
}
