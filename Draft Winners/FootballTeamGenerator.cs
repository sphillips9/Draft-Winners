using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Draft_Winners
{
    class FootballTeamGenerator : GenerateTeams
    {
        private List<Player> mQBList;
        private List<Player> mRBList; // also in flex
        private List<Player> mWRList; // also in flex
        private List<Player> mTEList; // also in flex
        private List<Player> mDSTList;
        private List<Player> mFlexList;
        private List<Player> mCollegeFlex;

        public FootballTeamGenerator(int salaryCap, int salaryThreshold) : base(salaryCap, salaryThreshold)
        {
            mQBList = new List<Player>();
            mRBList = new List<Player>();
            mWRList = new List<Player>();
            mTEList = new List<Player>();
            mDSTList = new List<Player>();
            mFlexList = new List<Player>();
            mCollegeFlex = new List<Player>();
        }

        /*
         * Returns a List of all football positions parsed
         * Positions are: QB/RB/WR/TE/DST/Flex in that order.
         */
        public List<List<Player>> getAllPlayers()
        {
            List<List<Player>> allPlayers = new List<List<Player>>();
            allPlayers.Add(mQBList);
            allPlayers.Add(mRBList);
            allPlayers.Add(mWRList);
            allPlayers.Add(mTEList);
            allPlayers.Add(mDSTList);
            allPlayers.Add(mFlexList);
            return allPlayers;
        }

        override public void addPlayer(Player player)
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

            if (player.getPosition() == Player.Positions.WR || player.getPosition() == Player.Positions.RB)
            {
                mCollegeFlex.Add(player);
            }
        }

        public override void createTeams(MainForm.ProgressBarIncrement inc, League league)
        {
            if (league == League.Professional)
            {
                generateTopNFLTeams(inc);
            }
            else
            {
                generateTopCollegeTeams(inc);
            }
        }

        public void generateTopNFLTeams(MainForm.ProgressBarIncrement inc)
        {
            int i = 0;
            int x = 0;
            foreach (Player qb in mQBList)
            {
                Team team = new Team();
                team.addPlayer(qb);
                foreach (Player rb1 in mRBList)
                {
                    team.addPlayer(rb1);
                    foreach (Player rb2 in mRBList)
                    {
                        if (rb2.Equals(rb1))
                        {
                            continue;
                        }
                        team.addPlayer(rb2);
                        foreach (Player wr1 in mWRList)
                        {
                            team.addPlayer(wr1);
                            foreach (Player wr2 in mWRList)
                            {
                                if (wr2.Equals(wr1))
                                {
                                    continue;
                                }
                                team.addPlayer(wr2);
                                foreach (Player wr3 in mWRList)
                                {
                                    if (wr3.Equals(wr1) || wr3.Equals(wr2))
                                    {
                                        continue;
                                    }
                                    team.addPlayer(wr3);
                                    foreach (Player te in mTEList)
                                    {
                                        team.addPlayer(te);
                                        foreach (Player dst in mDSTList)
                                        {
                                            team.addPlayer(dst);
                                            foreach (Player flex in mFlexList)
                                            {
                                                if (flex.Equals(te) || flex.Equals(wr1) || flex.Equals(wr2) || flex.Equals(wr3) || flex.Equals(rb1) || flex.Equals(rb2))
                                                {
                                                    continue;
                                                }
                                                i++;

                                                if (i == 10000000)
                                                {
                                                    i = 0;
                                                    x++;
                                                    if (x > 3)
                                                    {
                                                        x = 0;
                                                    }
                                                    inc.Invoke(x);
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

            updateProgressEvent();
        }

        public void generateTopCollegeTeams(MainForm.ProgressBarIncrement inc)
        {
            int i = 0;
            int x = 0;
            foreach (Player qb in mQBList)
            {
                Team team = new Team();
                team.addPlayer(qb);
                foreach (Player qb2 in mQBList)
                {
                    if (qb2.Equals(qb))
                    {
                        continue;
                    }
                    team.addPlayer(qb2);
                    foreach (Player rb1 in mRBList)
                    {
                        team.addPlayer(rb1);
                        foreach (Player rb2 in mRBList)
                        {
                            if (rb2.Equals(rb1))
                            {
                                continue;
                            }
                            team.addPlayer(rb2);
                            foreach (Player wr1 in mWRList)
                            {
                                team.addPlayer(wr1);
                                foreach (Player wr2 in mWRList)
                                {
                                    if (wr2.Equals(wr1))
                                    {
                                        continue;
                                    }
                                    team.addPlayer(wr2);
                                    foreach (Player wr3 in mWRList)
                                    {
                                        if (wr3.Equals(wr1) || wr3.Equals(wr2))
                                        {
                                            continue;
                                        }
                                        team.addPlayer(wr3);

                                        foreach (Player flex in mCollegeFlex)
                                        {
                                            if (flex.Equals(wr1) || flex.Equals(wr2) || flex.Equals(wr3) || flex.Equals(rb1) || flex.Equals(rb2))
                                            {
                                                continue;
                                            }
                                            team.addPlayer(flex);
                                            foreach (Player flex2 in mCollegeFlex)
                                            {
                                                if (flex2.Equals(wr1) || flex2.Equals(wr2) || flex2.Equals(wr3) || flex2.Equals(rb1) || flex2.Equals(rb2) || flex2.Equals(flex))
                                                {
                                                    continue;
                                                }

                                                i++;

                                                if (i == 10000000)
                                                {
                                                    i = 0;
                                                    x++;
                                                    if (x > 3)
                                                    {
                                                        x = 0;
                                                    }
                                                    inc.Invoke(x);
                                                }

                                                team.addPlayer(flex2);
                                                addTeam(new Team(team));
                                                team.removePlayer(flex2);
                                            }
                                            team.removePlayer(flex);
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
                    team.removePlayer(qb2);
                }
            }
            updateProgressEvent();
        }

        override public String convertPlayersToValues()
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
    }
}
