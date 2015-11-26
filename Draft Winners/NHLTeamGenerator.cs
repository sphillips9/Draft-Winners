using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Draft_Winners
{
    class NHLTeamGenerator : GenerateTeams
    {
        private List<Player> mCenterList;
        private List<Player> mWingerList;
        private List<Player> mDefenseList;
        private List<Player> mGoalieList;
        private List<Player> mUtilList;

        public NHLTeamGenerator(int salaryCap, int salaryThreshold) : base(salaryCap, salaryThreshold)
        {
            mCenterList = new List<Player>();
            mWingerList = new List<Player>();
            mDefenseList = new List<Player>();
            mGoalieList = new List<Player>();
            mUtilList = new List<Player>();
        }
        override public void addPlayer(Player player)
        {
            Player.Positions pos = player.getPosition();

            if (pos == Player.Positions.C)
            {
                mCenterList.Add(player);
            }
            else if (pos == Player.Positions.LW || pos == Player.Positions.RW)
            {
                mWingerList.Add(player);
            }
            else if (pos == Player.Positions.D)
            {
                mDefenseList.Add(player);
            }
            else if (pos == Player.Positions.G)
            {
                mGoalieList.Add(player);
            }

            if (pos == Player.Positions.C || pos == Player.Positions.LW || pos == Player.Positions.RW || pos == Player.Positions.D)
            {
                mUtilList.Add(player);
            }
        }

        public void generateNFLTeams(MainForm.ProgressBarIncrement inc)
        {
            int i = 0;
            int x = 0;
            foreach (Player g in mGoalieList)
            {
                Team team = new Team();
                team.addPlayer(g);
                foreach (Player c1 in mCenterList)
                {
                    team.addPlayer(c1);
                    foreach (Player c2 in mCenterList)
                    {
                        if (c2.Equals(c1))
                        {
                            continue;
                        }
                        team.addPlayer(c2);
                        foreach (Player w1 in mWingerList)
                        {
                            team.addPlayer(w1);
                            foreach (Player w2 in mWingerList)
                            {
                                if (w2.Equals(w1))
                                {
                                    continue;
                                }
                                team.addPlayer(w2);
                                foreach (Player w3 in mWingerList)
                                {
                                    if (w3.Equals(w1) || w3.Equals(w2))
                                    {
                                        continue;
                                    }
                                    team.addPlayer(w3);
                                    foreach (Player d1 in mDefenseList)
                                    {
                                        team.addPlayer(d1);
                                        foreach (Player d2 in mDefenseList)
                                        {
                                            if (d2.Equals(d1))
                                            {
                                                continue;
                                            }
                                            team.addPlayer(d2);
                                            foreach (Player util in mUtilList)
                                            {
                                                if (util.Equals(c1) || util.Equals(c2) || util.Equals(w1) || util.Equals(w2) || util.Equals(w3) || util.Equals(d1) || util.Equals(d2))
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

            updateProgressEvent();
        }

        override public String convertPlayersToValues()
        {
            List<Player> allPlayers = new List<Player>();
            allPlayers.AddRange(mCenterList);
            allPlayers.AddRange(mWingerList);
            allPlayers.AddRange(mDefenseList);
            allPlayers.AddRange(mGoalieList);
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
