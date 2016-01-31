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
    public partial class BasketballChooserForm : Form
    {
        List<Player> mForwardList;
        List<Player> mGuardList;
        List<Player> mUtilList;

        List<Player> fixedGuard1;
        List<Player> fixedGuard2;
        List<Player> fixedGuard3;

        List<Player> fixedForward1;
        List<Player> fixedForward2;
        List<Player> fixedForward3;

        private List<Team> mTeamList;

        protected int mSalaryCap;
        protected int mSalaryThreshold;

        public BasketballChooserForm(List<Player> forwardList, List<Player> guardList, int salaryCap, int salaryThreshold)
        {
            InitializeComponent();
            fillComboBox(guard1Box, guardList);
            fillComboBox(guard2Box, guardList);
            fillComboBox(guard3Box, guardList);
            fillComboBox(forward1Box, forwardList);
            fillComboBox(forward2Box, forwardList);
            fillComboBox(forward3Box, forwardList);

            mForwardList = forwardList;
            mGuardList = guardList;
            mUtilList = forwardList.Concat(guardList).ToList();
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
            fixedForward1 = parseComboBox(forward1Box, mForwardList);
            fixedForward2 = parseComboBox(forward2Box, mForwardList);
            fixedForward3 = parseComboBox(forward3Box, mForwardList);

            fixedGuard1 = parseComboBox(guard1Box, mGuardList);
            fixedGuard2 = parseComboBox(guard2Box, mGuardList);
            fixedGuard3 = parseComboBox(guard3Box, mGuardList);
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

        private void generateTeams()
        {
            foreach(Player f1 in  fixedForward1)
            {
                Team team = new Team();
                team.addPlayer(f1);
                foreach(Player f2 in fixedForward2)
                {
                    if (f2.Equals(f1))
                    {
                        continue;
                    }
                    team.addPlayer(f2);
                    foreach(Player f3 in fixedForward3)
                    {
                        if (f3.Equals(f2) || f3.Equals(f1))
                        {
                            continue;
                        }
                        team.addPlayer(f3);
                        foreach(Player g1 in fixedGuard1)
                        {
                            team.addPlayer(g1);
                            foreach(Player g2 in fixedGuard2)
                            {
                                if (g2.Equals(g1))
                                {
                                    continue;
                                }
                                team.addPlayer(g2);
                                foreach(Player g3 in fixedGuard3)
                                {
                                    if (g3.Equals(g1) || g3.Equals(g2))
                                    {
                                        continue;
                                    }
                                    team.addPlayer(g3);
                                    foreach(Player u1 in mUtilList)
                                    {
                                        if (u1.Equals(g1) || u1.Equals(g2) || u1.Equals(g3) || u1.Equals(f1) || u1.Equals(f2) || u1.Equals(f3))
                                        {
                                            continue;
                                        }
                                        team.addPlayer(u1);
                                        foreach(Player u2 in mUtilList)
                                        {
                                            if (u2.Equals(u1) || u1.Equals(g1) || u1.Equals(g2) || u1.Equals(g3) || u1.Equals(f1) || u1.Equals(f2) || u1.Equals(f3))
                                            {
                                                continue;
                                            }
                                            team.addPlayer(u2);
                                            addTeam(new Team(team));
                                            team.removePlayer(u2);
                                        }
                                        team.removePlayer(u1);
                                    }
                                    team.removePlayer(g3);
                                }
                                team.removePlayer(g2);
                            }
                            team.removePlayer(g1);
                        }
                        team.removePlayer(f3);
                    }
                    team.removePlayer(f2);
                }
                team.removePlayer(f1);
            }
        }

        //DUPLICATING ALOT OF LOGIC FROM GENERATE TEAMS THIS NEEDS A BETTER DESIGN.
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
