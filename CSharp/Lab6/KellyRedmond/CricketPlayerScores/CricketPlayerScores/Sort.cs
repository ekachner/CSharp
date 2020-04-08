using System;

namespace CricketPlayerScores
{
    public class Sort
    {
        public static void PickSort(Player[] players)
        {
            string sortAgain = "Y";

            while (sortAgain == "Y")
            {
                string nameScore = Methods.StringInput("Do you want to sort by names or scores? (enter N or S): ", "N", "S");

                if (nameScore == "N")
                {
                    string nameSort = Methods.StringInput("Do you want to start at A or Z? (enter A or Z): ", "A", "Z");
                    if (nameSort == "A")
                    {
                        AtoZ(players);
                    }
                    else
                    {
                        ZtoA(players);
                    }
                }
                else
                {
                    string scoreSort = Methods.StringInput("Do you want to start at the high score or low score? (enter H or L): ", "H", "L");
                    if (scoreSort == "H")
                    {
                        ScoreHighLow(players);
                    }
                    else
                    {
                        ScoreLowHigh(players);
                    }
                }

                Team.PrintRoster(players);

                sortAgain = Methods.StringInput("Would you like to sort another way? ( Y / N ): ", "Y", "N");

                if (sortAgain == "Y")
                {
                    Console.Clear();
                }
            }
        }

        public static void ScoreHighLow(Player[] players)
        {
            Player temp;
            bool trade = true;

            for (int i = 0; (i <= (players.Length - 2)) && trade; i++)
            {
                trade = false;
                for (int j = 0; j <= (players.Length - 2); j++)
                {
                    if(players[j + 1].Score > players[j].Score)
                    {
                        temp = players[j];
                        players[j] = players[j + 1];
                        players[j + 1] = temp;
                        trade = true;
                    }
                }
            }
        }

        public static void ScoreLowHigh(Player[] players)
        {
            ScoreHighLow(players);
            Array.Reverse(players);
        }

        public static void AtoZ(Player[] players)
        {
            string[] arrKeys = new string[players.Length];
            string[] arrValues = new string[players.Length];

            for (int i = 0; i < players.Length; i++)
            {
                arrKeys[i] = players[i].Name;
                arrValues[i] = players[i].Score.ToString();
            }

            Array.Clear(players, 0, players.Length);

            Array.Sort(arrKeys, arrValues);

            for (int i = 0; i < players.Length; i++)
            {
                players[i] = new Player(arrKeys[i], int.Parse(arrValues[i]));
            }
        }

        public static void ZtoA(Player[] players)
        {
            Player temp;
            bool trade = true;

            for (int i = 0; (i <= (players.Length - 2)) && trade; i++)
            {
                trade = false;
                for (int j = 0; j <= (players.Length - 2); j++)
                {
                    if (players[j + 1].Name.CompareTo(players[j].Name) > 0 )
                    {
                        temp = players[j];
                        players[j] = players[j + 1];
                        players[j + 1] = temp;
                        trade = true;
                    }
                }
            }
        }

        //public static void PickSort(Player[] players)
        //{
        //    string sortAgain = "Y";

        //    while (sortAgain == "Y")
        //    {
        //        int userSort = Methods.IsNumber("Roster order options" +
        //        "\n\t1. Player Score High to Low\n\t2. Player Score Low to High" +
        //        "\n\t3. Player Name A to Z\n\t4. Player Name Z to A\n", 1, 4, "selection");

        //        switch (userSort)
        //        {
        //            case 1:
        //                ScoreHighLow(players);
        //                break;

        //            case 2:
        //                ScoreLowHigh(players);
        //                break;

        //            case 3:
        //                AtoZ(players);
        //                break;

        //            case 4:
        //                ZtoA(players);
        //                break;

        //            default:
        //                Console.WriteLine("Entry not accepted, please restart program");
        //                break;
        //        }

        //        Team.PrintRoster(players);

        //        sortAgain = Methods.StringInput("Would you like to sort another way? ( Y / N ): ", "Y", "N");

        //        if (sortAgain == "Y")
        //        {
        //            Console.Clear();
        //        }
        //    }
    }
}
