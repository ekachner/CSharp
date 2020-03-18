using System;
using System.Collections.Generic;

namespace cinema_entry
{
    public class Program
    {
        public static void Main()
        {
            char anotherTicket = 'Y';

            do
            {
                List<Movie> movieList = new List<Movie>();
                movieList.Add(new Movie(1, "Rush", 15));
                movieList.Add(new Movie(2, "How I Live Now", 15));
                movieList.Add(new Movie(3, "Thor: The Dark World", 12));
                movieList.Add(new Movie(4, "Filth", 18));
                movieList.Add(new Movie(5, "Planes", 18));

                Console.WriteLine("Welcome to our MultiPlex!");
                Console.WriteLine("We are showing:");

                foreach (var Movie in movieList)
                {
                    Console.WriteLine("{0}.  {1} ({2})", Movie.movieNum, Movie.movieName, Movie.ageRestriction);
                }

                Console.Write("Enter the number of the film you want to see: ");

                string movieInput = Console.ReadLine();
                int movieNum;
                bool isNumber = int.TryParse(movieInput, out movieNum);

                while (movieNum < 1 || movieNum > movieList.Count || !isNumber)
                {
                    Console.WriteLine("Not a valid movie number.");
                    Console.Write("Enter the number of the film you want to see: ");
                    movieInput = Console.ReadLine();

                    isNumber = int.TryParse(movieInput, out movieNum);
                }

                foreach (var Movie in movieList)
                {
                    if (Movie.movieNum == movieNum)
                    {
                        Console.WriteLine("You have selected " + Movie.movieName + ".  ");
                        Console.Write("Please enter your age: ");

                        string ageInput = Console.ReadLine();
                        int age;
                        bool result = int.TryParse(ageInput, out age);

                        while (age < 5 || age > 120 || !result)
                        {
                            Console.WriteLine("Invalid age. Please try again.");
                            Console.Write("Please enter your age: ");
                            ageInput = Console.ReadLine();
                            result = int.TryParse(ageInput, out age);
                        }

                        if (age >= Movie.ageRestriction)
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
                anotherTicket = char.ToUpper(Console.ReadLine()[0]);
                Console.Clear();

                if (anotherTicket == 'N')
                {
                    Console.Clear();
                    Console.WriteLine("Thank you for coming to the Multiplex! Enjoy your movie!");
                }

            } while (anotherTicket == 'Y');

        }

        public class Movie
        {
            public int movieNum;
            public string movieName;
            public int ageRestriction;


            public Movie(int movieNum, string movieName, int ageRestriction)
            {
                this.movieNum = movieNum;
                this.movieName = movieName;
                this.ageRestriction = ageRestriction;
            }
        }
    }
}
