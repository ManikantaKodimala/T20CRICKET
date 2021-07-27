using System;
using System.Collections.Generic;
namespace T20Cricket
{
    public class Team
    {
        private string teamName;
        private int score = 0;
        private int wicketslost = 0;
        private List<string> teamMembers;
        public bool isSecondInnings = false;
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
        public string GetTeamName()
        {
            return this.teamName;
        }
        public void SetTeamMembers()
        {
            teamMembers = new List<string>();
            Console.WriteLine("Names of Team members");
            for (int i = 0; i < 11; i++)
            {
                teamMembers.Add(Console.ReadLine().Trim());
            }
        }
        public List<string> getTeamMembers()
        {
            return teamMembers;
        }
        public string GetATeamMember()
        {
            Random random = new Random();
            return teamMembers[random.Next(0, 11)];
        }
    }
}
