using System;

namespace T20Cricket
{
    public class Result
    {
        public int ResultOfShotForDoosra(string shotSelected, string shortTiming)
        {
            string[] bestShots = { "CoverDrive" };
            int i = 0;
            Random random = new Random(5);
            for (i = 0; i < bestShots.Length; i = i + 1)
            {
                if (shotSelected == bestShots[i])
                {
                    if (shortTiming == "Early")
                    {

                        return -1;
                    }
                    else if (shortTiming == "Good")
                    {

                        int[] results = { 1, 2 };
                        return results[random.Next(0, 2)];
                    }
                    else if (shortTiming == "Perfect")
                    {

                        return 4;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            return 0;
        }
        public int ResultOfShotForSlower(string shotSelected, string shortTiming)
        {
            string[] bestShots = { "CoverDrive" };
            int i = 0;
            Random random = new Random(5);
            for (i = 0; i < bestShots.Length; i = i + 1)
            {
                if (shotSelected == bestShots[i])
                {
                    if (shortTiming == "Early")
                    {

                        return -1;
                    }
                    else if (shortTiming == "Good")
                    {

                        int[] results = { 1, 2 };
                        return results[random.Next(0, 2)];
                    }
                    else if (shortTiming == "Perfect")
                    {

                        return 4;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            return 0;
        }

        public int ResultOfShotForPace(string shotSelected, string shortTiming)
        {
            string[] bestShots = { "CoverDrive" };
            int i = 0;
            Random random = new Random(5);
            for (i = 0; i < bestShots.Length; i = i + 1)
            {
                if (shotSelected == bestShots[i])
                {
                    if (shortTiming == "Early")
                    {

                        return -1;
                    }
                    else if (shortTiming == "Good")
                    {

                        int[] results = { 1, 2 };
                        return results[random.Next(0, 2)];
                    }
                    else if (shortTiming == "Perfect")
                    {

                        return 4;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            return 0;
        }
        public int ResultOfShotForBouncer(string shotSelected, string shortTiming)
        {
            string[] bestShots = { "Pull", "UpperCut", "SquareCut" };
            int i = 0;
            Random random = new Random(5);
            for (i = 0; i < bestShots.Length; i = i + 1)
            {
                if (shotSelected == bestShots[i])
                {
                    if (shortTiming == "Early")
                    {
                        return -1;
                    }
                    else if (shortTiming == "Good")
                    {

                        int[] results = { 4, 6 };
                        return results[random.Next(0, 2)];
                    }
                    else if (shortTiming == "Perfect")
                    {
                        int[] results = { 4, 6 };
                        return results[random.Next(0, 2)];
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            return 0;

        }
        public int ResultOfShotForOutSwinger(string shotSelected, string shortTiming)
        {
            string[] bestShots = { "CoverDrive" };
            int i = 0;
            Random random = new Random(5);
            for (i = 0; i < bestShots.Length; i = i + 1)
            {
                if (shotSelected == bestShots[i])
                {
                    if (shortTiming == "Early")
                    {
                        return -1;
                    }
                    else if (shortTiming == "Good")
                    {

                        int[] results = { 2, 1 };
                        return results[random.Next(0, 2)];
                    }
                    else if (shortTiming == "Perfect")
                    {
                        return 4;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            return 0;

        }
        public int ResultOfShotForLegCutter(string shotSelected, string shortTiming)
        {
            string[] bestShots = { "Sweep", "LegLance" };
            int i = 0;
            Random random = new Random(5);
            for (i = 0; i < bestShots.Length; i = i + 1)
            {
                if (shotSelected == bestShots[i])
                {
                    if (shortTiming == "Early")
                    {

                        int[] results = { 1, 2, 3, 4, -1 };
                        return shotSelected == "LegLance" ? 1 : results[random.Next(0, 5)];
                    }
                    else if (shortTiming == "Good")
                    {

                        int[] results = { 1, 2 };
                        return shotSelected == "LegLance" ? results[random.Next(0, 2)] : 2;
                    }
                    else if (shortTiming == "Perfect")
                    {
                        int[] results = { 2, 3 };
                        return shotSelected == "LegLance" ? results[random.Next(0, 2)] : 4;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            return 0;
        }
        public int ResultOfShotForInSwinger(string shotSelected, string shortTiming)
        {
            string[] bestShots = { "Straight", "CoverDrive" };
            int i = 0;
            Random random = new Random(5);
            for (i = 0; i < bestShots.Length; i = i + 1)
            {
                if (shotSelected == bestShots[i])
                {
                    if (shortTiming == "Early")
                    {

                        int[] results = { 0, -1 };
                        return shotSelected == "Straight" ? -1 : results[random.Next(0, 2)];
                    }
                    else if (shortTiming == "Good")
                    {

                        int[] results = { 1, 2 };
                        return results[random.Next(0, 2)];
                    }
                    else if (shortTiming == "Perfect")
                    {

                        int[] results = { 1, 2 };
                        return shotSelected == "Straight" ? results[random.Next(0, 2)] : 4;
                    }
                    else
                    {

                        int[] results = { -1, 0 };
                        return results[random.Next(0, 2)];
                    }
                }
            }
            return 0;
        }
        public int ResultOfShotForOffBreak(string shotSelected, string shortTiming)
        {
            string[] bestShots = { "Sweep", "LongON", "CoverDrive" };
            int i = 0;
            Random random = new Random(5);
            for (i = 0; i < bestShots.Length; i = i + 1)
            {
                if (shotSelected == bestShots[i])
                {
                    if (shortTiming == "Early")
                    {
                        return -1;
                    }
                    else if (shortTiming == "Good")
                    {
                        int[] results = { 0, 1, 2 };
                        return results[random.Next(0, 3)];
                    }
                    else if (shortTiming == "Perfect")
                    {
                        return shotSelected == "Straight" ? 1 : 6;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            return 0;
        }
        public int ResultOfShotForYorker(string shotSelected, string shortTiming)
        {
            string[] bestShots = { "Straight", "LongON" };
            int i = 0;
            Random random = new Random(5);
            for (i = 0; i < bestShots.Length; i = i + 1)
            {
                if (shotSelected == bestShots[i])
                {
                    if (shortTiming == "Early")
                    {
                        return -1;
                    }
                    else if (shortTiming == "Good")
                    {

                        int[] results = { 0, 1, 2 };
                        return results[random.Next(0, 3)];
                    }
                    else if (shortTiming == "Perfect")
                    {
                        return shotSelected == "Straight" ? 1 : 6;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            return -1;
        }
        public int ResultOfShotForOffCutter(string shotSelected, string shortTiming)
        {
            string[] bestShots = { "Straight", "CoverDrive" };
            int i = 0;
            Random random = new Random(5);
            for (i = 0; i < bestShots.Length; i = i + 1)
            {
                if (shotSelected == bestShots[i])
                {
                    if (shortTiming == "Early")
                    {
                        return 0;
                    }
                    else if (shortTiming == "Good")
                    {

                        int[] results = { 2, 1 };
                        return results[random.Next(0, 2)];
                    }
                    else if (shortTiming == "Perfect")
                    {

                        int[] results = { 2, 1 };
                        return shotSelected == "CoverDrive" ? 4 : results[random.Next(0, 2)];
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            return 0;
        }
    }
}