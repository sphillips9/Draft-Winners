using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Draft_Winners
{
    class ShowdownTeamGenerator : GenerateTeams
    {
        public ShowdownTeamGenerator(int salaryCap, int salaryThreshold) : base(salaryCap, salaryThreshold)
        {
            mPlayers = new List<Player>();
            mFixedPlayers = new List<Player>();
        }

        private List<Player> mPlayers;
        private List<Player> mFixedPlayers;

        public override void addPlayer(Player player)
        {
            mPlayers.Add(player);
        }

        public void addPlayerToFixedList(Player player)
        {
            mFixedPlayers.Add(player);
        }

        public override string convertPlayersToValues()
        {
            List<Player> allPlayers = new List<Player>();
            allPlayers.AddRange(mPlayers);
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
            mPlayers.RemoveAll(z => mFixedPlayers.Contains(z));
            List<List<Player>> mTeamList = new List<List<Player>>();
            for (int j = 0; j < 6; j++)
            {
                mTeamList.Add(new List<Player>());
                mTeamList[j].AddRange(mPlayers);
            }

            for (int j = 0; j < mFixedPlayers.Count(); j++)
            {
                mTeamList[j].Clear();
                mTeamList[j].Add(mFixedPlayers[j]);
            }

            foreach (Player p1 in mTeamList[0])
            {
                Team team = new Team();
                team.addPlayer(p1);
                foreach (Player p2 in mTeamList[1])
                {
                    if (p2.Equals(p1))
                    {
                        continue;
                    }
                    team.addPlayer(p2);
                    foreach (Player p3 in mTeamList[2])
                    {
                        if (p3.Equals(p1) || p3.Equals(p2))
                        {
                            continue;
                        }
                        team.addPlayer(p3);
                        foreach (Player p4 in mTeamList[3])
                        {
                            if (p4.Equals(p1) || p4.Equals(p2) || p4.Equals(p3))
                            {
                                continue;
                            }
                            team.addPlayer(p4);
                            foreach (Player p5 in mTeamList[4])
                            {
                                if (p5.Equals(p1) || p5.Equals(p2) || p5.Equals(p3) || p5.Equals(p4))
                                {
                                    continue;
                                }
                                team.addPlayer(p5);
                                foreach (Player p6 in mTeamList[5])
                                {
                                    if (p6.Equals(p1) || p6.Equals(p2) || p6.Equals(p3) || p6.Equals(p4) || p6.Equals(p5))
                                    {
                                        continue;
                                    }
                                    team.addPlayer(p6);
                                    addTeam(new Team(team));
                                    team.removePlayer(p6);
                                }
                                team.removePlayer(p5);
                            }
                            team.removePlayer(p4);
                        }
                        team.removePlayer(p3);
                    }
                    team.removePlayer(p2);
                }
                team.removePlayer(p1);
            }
        }
    }
}
