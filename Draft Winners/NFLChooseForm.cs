using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace Draft_Winners
{
    public partial class NFLChooseForm : Form
    {
        private List<Player> mQBList;
        private List<Player> mRBList; // also in flex
        private List<Player> mWRList; // also in flex
        private List<Player> mTEList; // also in flex
        private List<Player> mDSTList;
        private List<Player> mFlexList;

        private List<Player> mFixedQBList;
        private List<Player> mFixedRB1List;
        private List<Player> mFixedRB2List;
        private List<Player> mFixedWR1List;
        private List<Player> mFixedWR2List;
        private List<Player> mFixedWR3List;
        private List<Player> mFixedTEList;
        private List<Player> mFixedDSTList;
        private List<Player> mFixedFlexList;

        public NFLChooseForm(List<List<Player>> players, int salaryCap, int salaryThreshold)
        {
            InitializeComponent();
            mQBList = players[0];
            mRBList = players[1];
            mWRList = players[2];
            mTEList = players[3];
            mDSTList = players[4];
            mFlexList = players[5];
            mSalaryCap = salaryCap;
            mSalaryThreshold = salaryThreshold;
            mTeamList = new List<Team>();

            fillComboBox(QBBox, mQBList);
            fillComboBox(rb1Box, mRBList);
            fillComboBox(rb2Box, mRBList);
            fillComboBox(wrBox1, mWRList);
            fillComboBox(wrBox2, mWRList);
            fillComboBox(wrBox3, mWRList);
            fillComboBox(teBox, mTEList);
            fillComboBox(dstBox, mDSTList);
            fillComboBox(flexBox, mFlexList);
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
            mFixedQBList = parseComboBox(QBBox, mQBList);
            mFixedRB1List = parseComboBox(rb1Box, mRBList);
            mFixedRB2List = parseComboBox(rb2Box, mRBList);
            mFixedWR1List = parseComboBox(wrBox1, mWRList);
            mFixedWR2List = parseComboBox(wrBox2, mWRList);
            mFixedWR3List = parseComboBox(wrBox3, mWRList);
            mFixedTEList = parseComboBox(teBox, mTEList);
            mFixedDSTList = parseComboBox(dstBox, mDSTList);
            mFixedFlexList = parseComboBox(flexBox, mFlexList);
        }
        #region GenerateTeams Duplicate

        private void createTeamButton_Click(object sender, EventArgs e)
        {
            fillPlayerArrays();
            mTeamList = new List<Team>();
            Thread generatorThread = new Thread(() =>
            {
                generateTopNFLTeams();
                this.Invoke((MethodInvoker)delegate
                {
                    createTeamButton.Visible = true;
                    MainForm.saveFile(convertTeamsToCSVStrings());
                });
            });

            createTeamButton.Visible = false;
            generatorThread.Start();
        }

        // TODO: This should be entirely redone cannot extend 2 classes in C# for Form and Generate Teams so the selection
        // Tables need to be form in addition to Generate Teams, Generate teams needs to use composition in the future.
        private List<Team> mTeamList;
        private int mSalaryCap;
        private int mSalaryThreshold;

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
                }
            }

            if (team.getTeamsTotalPoints() < lowestTeam.getTeamsTotalPoints())
            {
                return;
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

        public void addPlayer(Player player)
        {
            if (player.getPosition() == Player.Positions.QB)
            {
                mQBList.Add(player);
            }
            else if (player.getPosition() == Player.Positions.RB)
            {
                mRBList.Add(player);
            }
            else if (player.getPosition() == Player.Positions.WR)
            {
                mWRList.Add(player);
            }
            else if (player.getPosition() == Player.Positions.TE)
            {
                mTEList.Add(player);
            }
            else if (player.getPosition() == Player.Positions.DST)
            {
                mDSTList.Add(player);
            }

            if (player.getPosition() == Player.Positions.WR || player.getPosition() == Player.Positions.TE || player.getPosition() == Player.Positions.RB)
            {
                mFlexList.Add(player);
            }
        }

        public String convertPlayersToValues()
        {
            List<Player> allPlayers = new List<Player>();
            allPlayers.AddRange(mQBList);
            allPlayers.AddRange(mRBList);
            allPlayers.AddRange(mWRList);
            allPlayers.AddRange(mTEList);
            allPlayers.AddRange(mDSTList);
            allPlayers.RemoveAll(item => item.getDollarsPerPoint() == 0);

            allPlayers.Sort((a, b) => { return a.getDollarsPerPoint().CompareTo(b.getDollarsPerPoint()); });
            String fullCSV = "Position, Name, Salary, Dollars Per Fantasy Point\n";
            foreach (Player player in allPlayers)
            {
                fullCSV += player.toStringWithDollars() + "\n";
            }

            return fullCSV;
        }

        #endregion

        public void generateTopNFLTeams()
        {
            foreach (Player qb in mFixedQBList)
            {
                Team team = new Team();
                team.addPlayer(qb);
                foreach (Player rb1 in mFixedRB1List)
                {
                    team.addPlayer(rb1);
                    foreach (Player rb2 in mFixedRB2List)
                    {
                        if (rb2.Equals(rb1))
                        {
                            continue;
                        }
                        team.addPlayer(rb2);
                        foreach (Player wr1 in mFixedWR1List)
                        {
                            team.addPlayer(wr1);
                            foreach (Player wr2 in mFixedWR2List)
                            {
                                if (wr2.Equals(wr1))
                                {
                                    continue;
                                }
                                team.addPlayer(wr2);
                                foreach (Player wr3 in mFixedWR3List)
                                {
                                    if (wr3.Equals(wr1) || wr3.Equals(wr2))
                                    {
                                        continue;
                                    }
                                    team.addPlayer(wr3);
                                    foreach (Player te in mFixedTEList)
                                    {
                                        team.addPlayer(te);
                                        foreach (Player dst in mFixedDSTList)
                                        {
                                            team.addPlayer(dst);
                                            foreach (Player flex in mFixedFlexList)
                                            {
                                                if (flex.Equals(te) || flex.Equals(wr1) || flex.Equals(wr2) || flex.Equals(wr3) || flex.Equals(rb1) || flex.Equals(rb2))
                                                {
                                                    continue;
                                                }

                                                team.addPlayer(flex);
                                                addTeam(new Team(team));
                                                team.removePlayer(flex);
                                            }
                                            team.removePlayer(dst);
                                        }
                                        team.removePlayer(te);
                                    }
                                    team.removePlayer(wr3);
                                }
                                team.removePlayer(wr2);
                            }
                            team.removePlayer(wr1);
                        }
                        team.removePlayer(rb2);
                    }
                    team.removePlayer(rb1);
                }
            }
        }
    }
}