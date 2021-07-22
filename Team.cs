using System;
using System.Collections.Generic;

namespace T20Cricket
{
    public class Team
    {
        private string teamName;
        private int score;
        private int wicketsLost;
        private List<string> teamMembers;
        public Team(string name)
        {
            teamName = name;
        }
        public void SetScore(int score)
        {
            this.score += score;
        }
        public int GetScore()
        {
            return this.score;
        }
        public void SetWicket(int wicket = 1)
        {
            wicketsLost += wicket == 1 ? 1 : -wicketsLost;
        }
        public int GetWickets()
        {
            return this.wicketsLost;
        }
        public string GetTeamName()
        {
            return this.teamName;
        }
        public void SetTeamMembers(List<string> teamMembers)
        {
            this.teamMembers = teamMembers;
        }
        public List<string> GetTeamMembers()
        {
            return this.teamMembers;
        }

    }
}
