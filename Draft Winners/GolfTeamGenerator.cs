using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Draft_Winners
{
    class GolfTeamGenerator : GenerateTeams
    {
        private List<Player> mGolferList;

        public GolfTeamGenerator(int salaryCap, int salaryThreshold) : base(salaryCap, salaryThreshold)
        {
            mGolferList = new List<Player>();
        }

        public List<Player> getGolfers()
        {
            return mGolferList;
        }

        override public void addPlayer(Player player)
        {
            mGolferList.Add(player);
        }

        public override void createTeams(MainForm.ProgressBarIncrement inc, League league)
        {
            throw new NotImplementedException();
        }

        override public String convertPlayersToValues()
        {
            List<Player> allPlayers = new List<Player>();
            allPlayers.AddRange(mGolferList);
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
