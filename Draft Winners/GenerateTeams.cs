using System;
using System.Collections.Generic;

namespace Draft_Winners
{
    abstract class GenerateTeams
    {
        public event TeamCompleteHandler completeEvent;
        public EventArgs e = null;
        public delegate void TeamCompleteHandler(GenerateTeams teamGen, EventArgs e);

        protected List<Team> mTeamList;
        protected int mSalaryCap;
        protected int mSalaryThreshold;

        public enum League {Professional, College};

        public GenerateTeams(int salaryCap, int salaryThreshold)
        {
            mTeamList = new List<Team>();
            mSalaryCap = salaryCap;
            mSalaryThreshold = salaryThreshold;
        }

        protected void updateProgressEvent()
        {
            completeEvent(this, e);
        }

        protected void addTeam(Team team)
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

        public abstract String convertPlayersToValues();

        public abstract void addPlayer(Player player);

        public abstract void createTeams(MainForm.ProgressBarIncrement inc, League league);

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

    }
}
