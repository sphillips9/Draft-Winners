using System;
using System.Collections.Generic;

namespace Draft_Winners
{
    class Team
    {
        List<Player> mTeamRoster;   

        public Team()
        {
            mTeamRoster = new List<Player>();
        }

        public Team(Team team)
        {
            mTeamRoster = new List<Player>();
            foreach (Player player in team.mTeamRoster)
            {
                mTeamRoster.Add(player);
            }
        }

        public void addPlayer(Player player)
        {
            mTeamRoster.Add(player);
        }

        public double getTeamsTotalPoints()
        {
            double total = 0;
            foreach (Player player in mTeamRoster)
            {
                total += player.getFantasyPoints();
            }

            return total;
        }

        public int getTeamsTotalSalary()
        {
            int total = 0;
            foreach (Player player in mTeamRoster)
            {
                total += player.getSalary();
            }

            return total;
        }

        public void removePlayer(Player player)
        {
            mTeamRoster.Remove(player);
        }

        public override Boolean Equals(System.Object obj)
        {
            List<Player> teamRoster1 = mTeamRoster;
            List<Player> teamRoster2 = ((Team)(obj)).mTeamRoster;

            foreach (Player player in teamRoster2)
            {
                if (teamRoster1.Contains(player))
                {
                    continue;
                }
                return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public String toCSV(int teamNumber)
        {
            String csvLine = "Team Total Fantasy Points: " + getTeamsTotalPoints() + "\n" +
             "Team Total Salary: " + getTeamsTotalSalary() + "\n";
            foreach (Player player in mTeamRoster)
            {
                csvLine += player.toString() + "\n";
            }

            return csvLine + "\n";
        }
    }
}
