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
    public partial class GolfPlayerSelectorForm : Form
    {

        List<Player> mGolfer1;
        List<Player> mGolfer2;
        List<Player> mGolfer3;
        List<Player> mGolfer4;
        List<Player> mGolfer5;
        List<Player> mGolfer6;

        private List<Player> mGolfers;
        private List<Team> mTeamList;

        protected int mSalaryCap;
        protected int mSalaryThreshold;

        public GolfPlayerSelectorForm(List<Player> golfers, int salaryCap, int salaryThreshold)
        {
            InitializeComponent();
            fillComboBox(golfer1Box, golfers);
            fillComboBox(golfer2Box, golfers);
            fillComboBox(golfer3Box, golfers);
            fillComboBox(golfer4Box, golfers);
            fillComboBox(golfer5Box, golfers);
            fillComboBox(golfer6Box, golfers);

            mTeamList = new List<Team>();

            mGolfers = golfers;
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
            mGolfer1 = parseComboBox(golfer1Box, mGolfers);
            mGolfer2 = parseComboBox(golfer2Box, mGolfers);
            mGolfer3 = parseComboBox(golfer3Box, mGolfers);
            mGolfer4 = parseComboBox(golfer4Box, mGolfers);
            mGolfer5 = parseComboBox(golfer5Box, mGolfers);
            mGolfer6 = parseComboBox(golfer6Box, mGolfers);
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
            foreach (Player g1 in mGolfer1)
            {
                Team team = new Team();
                team.addPlayer(g1);
                foreach (Player g2 in mGolfer2)
                {
                    if (g2.Equals(g1))
                    {
                        continue;
                    }
                    team.addPlayer(g2);
                    foreach (Player g3 in mGolfer3)
                    {
                        if (g3.Equals(g1) || g3.Equals(g2))
                        {
                            continue;
                        }
                        team.addPlayer(g3);
                        foreach (Player g4 in mGolfer4)
                        {
                            if (g4.Equals(g1) || g4.Equals(g2) || g4.Equals(g3))
                            {
                                continue;
                            }
                            team.addPlayer(g4);
                            foreach (Player g5 in mGolfer5)
                            {
                                if (g5.Equals(g1) || g5.Equals(g2) || g5.Equals(g3) || g5.Equals(g4))
                                {
                                    continue;
                                }
                                team.addPlayer(g5);
                                foreach (Player g6 in mGolfer6)
                                {
                                    if (g6.Equals(g1) || g6.Equals(g2) || g6.Equals(g3) || g6.Equals(g4) || g6.Equals(g5))
                                    {
                                        continue;
                                    }
                                    team.addPlayer(g6);
                                    addTeam(new Team(team));
                                    team.removePlayer(g6);
                                }
                                team.removePlayer(g5);
                            }
                            team.removePlayer(g4);
                        }
                        team.removePlayer(g3);
                    }
                    team.removePlayer(g2);
                }
                team.removePlayer(g1);
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
