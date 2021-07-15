using System;
namespace T20Cricket
{
    class Team
    {
        private string teamName;
        public int wicketsLost { get; set; }
        public int score { get; set; }
        public Team(string name)
        {
            teamName = name;
        }
        public string getTeamName()
        {
            return this.teamName;
        }
        public string[] teamMembers { get; set; }

    }
}
