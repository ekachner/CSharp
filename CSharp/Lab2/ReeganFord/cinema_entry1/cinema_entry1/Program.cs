using System;
using System.Collections.Generic;

namespace cinema_entry
{
    public class Program
    {
        public static void Main()
        {
            char AnotherTicket = 'Y';

            do
            {
                List<Movie> MovieList = Movie.MovieList();

                Console.WriteLine("Welcome to our MultiPlex!");
                Console.WriteLine("We are showing:");

                foreach (var Movie in MovieList)
                {
                    Console.WriteLine("{0}.  {1} ({2})", Movie.MovieNum, Movie.MovieName, Movie.AgeRestriction);
                }

                Console.Write("Enter the number of the film you want to see: ");

                string MovieInput = Console.ReadLine();
                int MovieNum;
                bool isNumber = int.TryParse(MovieInput, out MovieNum);

                while (MovieNum < 1 || MovieNum > MovieList.Count || !isNumber)
                {
                    Console.WriteLine("Not a valid movie number.");
                    Console.Write("Enter the number of the film you want to see: ");
                    MovieInput = Console.ReadLine();

                    isNumber = int.TryParse(MovieInput, out MovieNum);
                }

                foreach (var Movie in MovieList)
                {
                    if (Movie.MovieNum == MovieNum)
                    {
                        Console.WriteLine("You have selected " + Movie.MovieName + ".  ");
                        Console.Write("Please enter your age: ");

                        string AgeInput = Console.ReadLine();
                        int Age;
                        bool result = int.TryParse(AgeInput, out Age);

                        while (Age < 5 || Age > 120 || !result)
                        {
                            Console.WriteLine("Invalid age. Please try again.");
                            Console.Write("Please enter your age: ");
                            AgeInput = Console.ReadLine();
                            result = int.TryParse(AgeInput, out Age);
                        }

                        if (Age >= Movie.AgeRestriction)
                        {
                            Console.WriteLine("Approved. Enjoy your movie!");
                        }

                        else
                        {
                            Console.WriteLine("Access denied - You are too young to see this movie.");
                        }
                    }
                }

                Console.Write("Would you like to purchase another ticket? [Y or N]: ");
                AnotherTicket = char.ToUpper(Console.ReadLine()[0]);
                Console.Clear();

                if (AnotherTicket == 'N')
                {
                    Console.Clear();
                    Console.WriteLine("Thank you for coming to the Multiplex! Enjoy your movie!");
                }

            } while (AnotherTicket == 'Y');

        }

        public class Movie
        {
            public readonly int MovieNum;
            public readonly string MovieName;
            public readonly int AgeRestriction;


            public Movie(int movieNum, string movieName, int ageRestriction)
            {
                MovieNum = movieNum;
                MovieName = movieName;
                AgeRestriction = ageRestriction;
            }

            public static List<Movie> MovieList()
            {
                List<Movie> MovieList = new List<Movie>();

                MovieList.Add(new Movie(1, "Rush", 15));
                MovieList.Add(new Movie(2, "How I Live Now", 15));
                MovieList.Add(new Movie(3, "Thor: The Dark World", 12));
                MovieList.Add(new Movie(4, "Filth", 18));
                MovieList.Add(new Movie(5, "Planes", 18));

                return MovieList;
            }
        }
    }
}
