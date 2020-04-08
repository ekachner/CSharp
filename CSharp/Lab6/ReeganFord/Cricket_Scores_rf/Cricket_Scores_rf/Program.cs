using System;

namespace CricketScores
{
    class Program
    {
        static void Main()
        {
            Player[] Team = new Player[11];

            for (int i = 0; i < 11; i++)
            {
                int counter = i + 1;
                Console.Write("(Player {0}) Please enter player's first name: ", counter);
                string fname = Console.ReadLine().Trim();
                string Fname = StringHelper.FirstLetterCap(fname);

                Console.Write("Please enter player's last name: ");
                string lname = Console.ReadLine().Trim();
                string Lname = StringHelper.FirstLetterCap(lname);

                Console.Write("Please enter player's score: ");
                string scoreInput = Console.ReadLine().Trim();
                int score = StringHelper.ValidNumber(scoreInput);

                Team[i] = new Player(Fname, Lname, score);
                Console.Clear();
                Console.WriteLine("Accepted! Next player:");
            }

            Console.Clear();
            Console.WriteLine("Team roster:");

            ListQueries.ListOrder(Team);

            ListQueries.SortList(Team);
        }
    }
}
