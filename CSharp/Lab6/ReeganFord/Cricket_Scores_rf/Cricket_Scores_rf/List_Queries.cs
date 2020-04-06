using System;

namespace CricketScores
{
    public class ListQueries
    {
        public static void ListOrder(Player[] arr)
        {
            int playerNum = 0;
            foreach (var Player in arr)
            {
                playerNum++;
                Console.WriteLine("{0}. {1} {2}: {3} points", playerNum, Player.FirstName, Player.LastName, Player.Score);
            }
            AverageScore.FindAverage(arr);
        }

        public static void SortList(Player[] arr)
        {
            bool listQuery;
            do
            {
                listQuery = false;

                Console.Write("Sort by name or by score? [N or S]: ");
                char sortBy = char.ToUpper(Console.ReadLine()[0]);

                while (sortBy != 'N' && sortBy != 'S')
                {
                    Console.WriteLine("Invalid sort option. Please try again.");
                    Console.Write("Sort by name or by score? [N or S]: ");
                    sortBy = char.ToUpper(Console.ReadLine()[0]);
                }

                if (sortBy == 'N')
                {
                    Console.Clear();
                    Console.Write("By first or last name? [F or L]: ");
                    char fl = char.ToUpper(Console.ReadLine()[0]);

                    while (fl != 'F' && fl != 'L')
                    {
                        Console.WriteLine("Invalid sort option. Please try again.");
                        Console.Write("By first or last name? [F or L]: ");
                        fl = char.ToUpper(Console.ReadLine()[0]);
                    }

                    if (fl == 'F')
                    {
                        SortOptions.ByFirstName(arr);
                        Console.WriteLine("By first name:");

                        ListOrder(arr);
                    }
                    else
                    {
                        SortOptions.ByLastName(arr);
                        Console.WriteLine("By last name:");

                        ListOrder(arr);
                    }
                    listQuery = true;
                }

                if (sortBy == 'S')
                {
                    Console.Clear();
                    Console.Write("Should the list begin with the highest or the lowest score? [H or L]: ");
                    char hl = char.ToUpper(Console.ReadLine()[0]);

                    while (hl != 'H' && hl != 'L')
                    {
                        Console.WriteLine("Invalid sort option. Please try again.");
                        Console.Write("Should the list begin with the highest or the lowest score? [H or L]: ");
                        hl = char.ToUpper(Console.ReadLine()[0]);
                    }

                    if (hl == 'H')
                    {
                        SortOptions.HighToLow(arr);
                        Console.WriteLine("High to Low:");

                        ListOrder(arr);
                    }
                    else
                    {
                        SortOptions.LowToHigh(arr);
                        Console.WriteLine("Low to High:");

                        ListOrder(arr);
                    }
                    listQuery = true;
                }
            } while (listQuery);
        }
    }
}