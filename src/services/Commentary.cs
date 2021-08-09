using System;

namespace T20Cricket
{
    public class Commentary
    {
        Random random = new Random(5);

        public string CommentaryForShot(int resultOfShot)
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
                    return commentary[random.Next(0, 3)] + " - " + resultOfShot + " Run";

                case 2:
                    commentary = new string[2]{ "Good running between the wickets",
                                        "Converts ones into two"
                                    };
                    return commentary[random.Next(0, 2)] + " - " + resultOfShot + " Runs";

                case 3:
                    commentary = new string[3]{ "Good running between the wickets",
                                        "Excellent stop at the boundary",
                                        "Excellent line and length"
                                    };
                    return commentary[random.Next(0, 3)] + " - " + resultOfShot + " Runs";

                case 4:
                    commentary = new string[3]{ "Just over the fielder",
                                        "Excellent Short",
                                        "Wow that is what we call a short"
                                    };
                    return commentary[random.Next(0, 3)] + " - " + resultOfShot + " Runs";

                case 6:
                    commentary = new string[2]{ "That’s massive and out of the ground",
                                        "It’s a huge hit"
                                    };
                    return commentary[random.Next(0, 2)] + " - " + resultOfShot + " Runs";

                case -1:
                    commentary = new string[2] { "It's a wicket", "This is what we call a ball" };
                    return commentary[random.Next(0, 2)] + " - 0 Runs";
                case 0:
                    commentary = new string[3]{ "Excellent bowling", "Good Length",
                                        "Excellent line and length"
                                    };
                    return commentary[random.Next(0, 3)] + " - 0 Runs";
                default :
                return " ";
            }

        }
    }
}