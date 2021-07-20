using System;
namespace T20Cricket
{
    public class Team
    {
        private string teamName;
        private int score = 0;
        private int wicketslost = 0;
        private string[] teamMembers;

        public Team(string name)
        {
            teamName = name;
        }

        public void setScore(int score)
        {
            this.score += score;
        }
        public int getScore()
        {
            return score;
        }
        public void setWicket(int wicket = 1)
        {
            if (wicket == 0)
                wicketslost = 0;
            wicketslost += wicket;
        }
        public int getWickets()
        {
            return wicketslost;
        }

        public string getTeamName()
        {
            return this.teamName;
        }
        public void setTeamMembers(string[] teamMembers)
        {
            this.teamMembers = teamMembers;
        }
        public string[] getTeamMembers()
        {
            return teamMembers;
        }

    }
}
