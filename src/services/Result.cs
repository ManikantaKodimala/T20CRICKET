using System;
namespace T20Cricket
{
    public class Result
    {
        public bool GetGameResult(Team team1, Team team2)
        {

            if (team1.GetScore() == team2.GetScore())
            {
                Console.WriteLine("It's a tie \n Moving on to Super Over ");
                return true;
            }
            if (team1.GetScore() > team2.GetScore())
            {
                Console.WriteLine(team1.GetTeamName() + " won by " + (team1.GetScore() - team2.GetScore()) + "Runs 🎉🎉🎉");
                return false;
            }
            else
            {
                Console.WriteLine(team2.GetTeamName() + " won by " + (team1.GetScore() - team2.GetScore()) + " Runs 🎉🎉🎉");
                return false;
            }
        }
    }
}