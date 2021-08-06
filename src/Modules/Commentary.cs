using System;

namespace T20Cricket
{
    public class Commentary
    {
        Random random = new Random(5);

        public void CommentaryForShot(int resultOfShot)
        {
            string[] commentary;
            switch (resultOfShot)
            {
                case 1:
                    commentary = new string[3]{
                                        "Good running between the wickets",
                                        "It's a single",
                                        "Excellent line and length"
                                    };
                    Console.WriteLine(commentary[random.Next(0, 3)] + " - " + resultOfShot + " Runs");
                    break;
                case 2:
                    commentary = new string[2]{ "Good running between the wickets",
                                        "Converts ones into two"
                                    };
                    Console.WriteLine(commentary[random.Next(0, 2)] + " - " + resultOfShot + " Runs");
                    break;
                case 3:
                    commentary = new string[3]{ "Good running between the wickets",
                                        "Excellent stop at the boundary",
                                        "Excellent line and length"
                                    };
                    Console.WriteLine(commentary[random.Next(0, 3)] + " - " + resultOfShot + " Runs");
                    break;
                case 4:
                    commentary = new string[3]{ "Just over the fielder",
                                        "Excellent Short",
                                        "Wow that is what we call a short"
                                    };
                    Console.WriteLine(commentary[random.Next(0, 3)] + " - " + resultOfShot + " Runs");
                    break;
                case 6:
                    commentary = new string[2]{ "That’s massive and out of the ground",
                                        "It’s a huge hit"
                                    };
                    Console.WriteLine(commentary[random.Next(0, 2)] + " - " + resultOfShot + " Runs");
                    break;
                case -1:
                    commentary = new string[2] { "It's a wicket", "This is what we call a ball" };
                    Console.WriteLine(commentary[random.Next(0, 2)] + " - 0 Runs");
                    break;
                case 0:
                    commentary = new string[3]{ "Excellent bowling", "Good Length",
                                        "Excellent line and length"
                                    };
                    Console.WriteLine(commentary[random.Next(0, 3)] + " - 0 Runs");
                    break;
            }

        }
    }
}