using System;

namespace T20Cricket
{
    public class Commentary
    {
        Random random = new Random(5);

        public string GetCommentaryForShot(int resultOfShot)
        {
            string[] commentary;
            string comment="";
            switch (resultOfShot)
            {
                case 1:
                    commentary = new string[3]{
                                        "Good running between the wickets",
                                        "It's a single",
                                        "Excellent line and length"
                                    };
                    comment=commentary[random.Next(0, commentary.Length)];
                    comment += " - " + resultOfShot + " Run";
                    return   comment;

                case 2:
                    commentary = new string[2]{ "Good running between the wickets",
                                        "Converts ones into two"
                                    };
                    comment = commentary[random.Next(0, commentary.Length)];
                    comment += " - " + resultOfShot + " Runs";
                    return comment;
                case 3:
                    commentary = new string[3]{ "Good running between the wickets",
                                        "Excellent stop at the boundary",
                                        "Excellent line and length"
                                    };
                    comment = commentary[random.Next(0, commentary.Length)];
                    comment += " - " + resultOfShot + " Runs";
                    return comment;
                case 4:
                    commentary = new string[3]{ "Just over the fielder",
                                        "Excellent Short",
                                        "Wow that is what we call a short"
                                    };
                    comment = commentary[random.Next(0, commentary.Length)];
                    comment += " - " + resultOfShot + " Runs";
                    return comment;
                case 6:
                    commentary = new string[2]{ "That’s massive and out of the ground",
                                        "It’s a huge hit"
                                    };
                    comment = commentary[random.Next(0, commentary.Length)];
                    comment += " - " + resultOfShot + " Runs";
                    return comment;
                case -1:
                    commentary = new string[2] { "It's a wicket", "This is what we call a ball" };
                    
                    comment = commentary[random.Next(0, commentary.Length)];
                    comment += " - 0 Runs";
                    return comment;
                case 0:
                    commentary = new string[3]{ "Excellent bowling", "Good Length",
                                        "Excellent line and length"
                                    };
                    comment = commentary[random.Next(0, commentary.Length)];
                    comment += " - 0 Runs";
                    return comment;
                default :
                return comment;
            }

        }
    }
}