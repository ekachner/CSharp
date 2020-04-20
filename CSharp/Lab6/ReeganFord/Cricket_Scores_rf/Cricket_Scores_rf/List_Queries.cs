using System;

namespace CricketScores
{
    public class ListQueries
    {
        public static void Roster(Player[] arr)
        {
            int playerNum = 0;
            foreach (var Player in arr)
            {
                playerNum++;
                Console.WriteLine("{0}. {1} {2}: {3} points", playerNum, Player.FirstName, Player.LastName, Player.Score);
            }
            Player.FindAverage(arr);
        }

        public static void SortList(Player[] arr)
        {
            bool listQuery;
            do
            {
                listQuery = false;

                char sortBy = Inputs.ReadString("Sort by name or by score? [N or S]: ")[0];

                while (sortBy != 'N' && sortBy != 'S')
                {
                    Console.WriteLine("Invalid sort option. Please try again.");
                    sortBy = Inputs.ReadString("Sort by name or by score? [N or S]: ")[0];
                }

                if (sortBy == 'N')
                {
                    Console.Clear();
                    char fl = Inputs.ReadString("By first name or last name? [F or L]: ")[0];
                    
                    while (fl != 'F' && fl != 'L')
                    {
                        Console.WriteLine("Invalid sort option. Please try again.");
                        fl = Inputs.ReadString("By first name or last name? [F or L]: ")[0];
                    }

                    if (fl == 'F')
                    {
                        SortOptions.ByFirstName(arr);
                        Console.WriteLine("By first name:");

                        Roster(arr);
                    }
                    else
                    {
                        SortOptions.ByLastName(arr);
                        Console.WriteLine("By last name:");

                        Roster(arr);
                    }
                    listQuery = true;
                }

                if (sortBy == 'S')
                {
                    Console.Clear();
                    char hl = Inputs.ReadString("Should the list begin with the Highest or the Lowest score? [H or L]: ")[0];

                    while (hl != 'H' && hl != 'L')
                    {
                        Console.WriteLine("Invalid sort option. Please try again.");
                        hl = Inputs.ReadString("Should the list begin with the Highest or the Lowest score? [H or L]: ")[0];
                    }

                    if (hl == 'H')
                    {
                        SortOptions.HighToLow(arr);
                        Console.WriteLine("High to Low:");

                        Roster(arr);
                    }
                    else
                    {
                        SortOptions.LowToHigh(arr);
                        Console.WriteLine("Low to High:");

                        Roster(arr);
                    }
                    listQuery = true;
                }
            } while (listQuery);
        }
    }
}