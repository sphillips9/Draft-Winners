using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Draft_Winners
{
    class BasketballTeamGenerator : GenerateTeams
    {
        private List<Player> mForwardList;
        private List<Player> mGuardList;
        private List<Player> mUtilList;

        public BasketballTeamGenerator (int salaryCap, int salaryThreshold) : base(salaryCap, salaryThreshold)
        {
            mForwardList = new List<Player>();
            mGuardList = new List<Player>();
            mUtilList = new List<Player>();
        }

        public override void addPlayer(Player player)
        {
            if (player.getPosition() == Player.Positions.F)
            {
                mForwardList.Add(player);
            }
            else if (player.getPosition() == Player.Positions.G)
            {
                mGuardList.Add(player);
            }

            if (player.getPosition() != Player.Positions.INVALID)
            {
                mUtilList.Add(player);
            }
        }

        public override string convertPlayersToValues()
        {
            List<Player> allPlayers = new List<Player>();
            allPlayers.AddRange(mUtilList);
            allPlayers.RemoveAll(item => item.getDollarsPerPoint() == 0);

            allPlayers.Sort((a, b) => { return a.getDollarsPerPoint().CompareTo(b.getDollarsPerPoint()); });
            String fullCSV = "Position, Name, Salary, Dollars Per Fantasy Point\n";
            foreach (Player player in allPlayers)
            {
                fullCSV += player.toStringWithDollars() + "\n";
            }

            return fullCSV;
        }

        public override void createTeams(MainForm.ProgressBarIncrement inc, League league)
        {
            if (league == League.College)
            {
                generateTopCollegeBasketballTeams(inc);
            }
        }

        public List<Player> getForwards()
        {
            return mForwardList;
        }

        public List<Player> getGuards()
        {
            return mGuardList;
        }

        public void generateTopCollegeBasketballTeams(MainForm.ProgressBarIncrement inc)
        {
            int i = 0;
            int x = 0;
            foreach (Player f1 in mForwardList)
            {
                Team team = new Team();
                team.addPlayer(f1);
                foreach (Player f2 in mForwardList)
                {
                    team.addPlayer(f2);
                    foreach (Player f3 in mForwardList)
                    {
                        if (f3.Equals(f2))
                        {
                            continue;
                        }
                        team.addPlayer(f3);
                        foreach (Player g1 in mGuardList)
                        {
                            team.addPlayer(g1);
                            foreach (Player g2 in mGuardList)
                            {
                                if (g2.Equals(g1))
                                {
                                    continue;
                                }
                                team.addPlayer(g2);
                                foreach (Player g3 in mGuardList)
                                {
                                    if (g3.Equals(g1) || g3.Equals(g2))
                                    {
                                        continue;
                                    }
                                    team.addPlayer(g3);
                                    foreach (Player u1 in mUtilList)
                                    {
                                        if (u1.Equals(g1) || u1.Equals(g2) || u1.Equals(g3) || u1.Equals(f2) || u1.Equals(f3))
                                        {
                                            continue;
                                        }
                                        team.addPlayer(u1);
                                            foreach (Player u2 in mUtilList)
                                            {
                                                if (u2.Equals(u1) || u2.Equals(g1) || u2.Equals(g2) || u2.Equals(g3) || u2.Equals(f2) || u2.Equals(f3))
                                                {
                                                    continue;
                                                }
                                                i++;

                                            //should eventually refactor this, pull this out from all of the Generators, have it as a protected method in GenerateTeams abstract class, and have that abstract class upon receiving
                                            // the "progress bar inc" variable set that progress bar for future use, would remove this ugly chunk of code from all calculators, lots less duplicated code.
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
            }

            updateProgressEvent();
        }

    }
}
