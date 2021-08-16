using System;
using System.Collections.Generic;

namespace T20Cricket.Model
{
    public class Team
    {
        private string teamName;
        private int score = 0;
        private int wicketslost = 0;
        private List<string> teamMembers;
        public bool isSecondInnings = false;

        public Team(int teamNumber)
        {
            SetTeamDetails(teamNumber);
        }

        public void SetScore(int score)
        {
            if(score>=0){
                this.score += score;
            }
        }

        public int GetScore()
        {
            return score;
        }

        public void SetWicket(int wicket = 1)
        {
            if (wicket == 0)
                wicketslost = 0;
            wicketslost += wicket;
        }

        public int GetWickets()
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

        public List<string> GetTeamMembers()
        {
            return teamMembers;
        }

        public void SetTeamDetails(int teamNumber)
        {
            Console.WriteLine("Team-{0} Name:", teamNumber);
            string teamName = Console.ReadLine();
            this.teamName = teamName;
            this.SetTeamMembers();
        }
        
        public string GetATeamMember()
        {
            Random random = new Random();
            return teamMembers[random.Next(0, 11)];
        }
    }
}
