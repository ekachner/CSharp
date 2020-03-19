using System;
using System.Collections.Generic;
using static System.Console;

namespace cinema
{
    public struct Movie
    {
        public string Title;
        public int Age;

        public Movie(string title, int age)
        {
            Title = title;
            Age = age;
        }
    }

    public class UserFilm
    {
        public int Age { get; set; }
        public string Film { get; set; }
    }


    class Program
    {
        static int ReadNumber(string prompt, int min, int max)
        {
            int result = 0;
            bool validInput = false;

            Write(prompt);

            while (!validInput)
            {
                validInput = int.TryParse(ReadLine(), out result);
                if (!validInput || result > max || result < min)
                {
                    validInput = false;
                    Write($"Please enter a number between {min} and {max}: ");
                }
                else
                {
                    break;
                }
            }

            return result;
        }

        static string StringInput(string prompt, string value1, string value2)
        {
            string input;

            do
            {
                Write(prompt);
                input = ReadLine().ToUpper();
                if (input == value1 || input == value2)
                {
                    break;
                }
                else
                {
                    WriteLine($"Please choose either {value1} or {value2}");
                }
            } while (true);

            return input;
        }

        static void Main()
        {
            Movie[] Movies = new Movie[5];
            Movies[0] = new Movie("Rush", 15);
            Movies[1] = new Movie("How I Live Now", 15);
            Movies[2] = new Movie("Thor: The Dark World", 12);
            Movies[3] = new Movie("Filth", 18);
            Movies[4] = new Movie("Planes", 0);

            string newCustomer;

            var userFilms = new List<UserFilm>();

            do
            {
                WriteLine("Welcome to our Multiplex\nWe are presently showing:");

                for (int number = 0; number < Movies.Length; number++)
                {
                    var item = Movies[number];

                    if (item.Age == 15 || item.Age == 18)
                    {
                        WriteLine($"\t{number + 1}. {item.Title} ({item.Age})");
                    }
                    else if (item.Age == 12)
                    {
                        WriteLine($"\t{number + 1}. {item.Title} ({item.Age}A)");
                    }
                    else
                    {
                        WriteLine($"\t{number + 1}. {item.Title} (U)");
                    }
                }

                int userMovie = ReadNumber("Enter the number of the film you wish to see: ", 1, 5);

                WriteLine($"The film you want to see is {Movies[userMovie - 1].Title}");

                int userAge = ReadNumber("Enter Your Age: ", 1, 120);

                if (userAge >= Movies[userMovie - 1].Age)
                {
                    WriteLine("Enjoy the film");
                    userFilms.Add(new UserFilm { Age = userAge, Film = Movies[userMovie - 1].Title });
                }
                else
                {
                    WriteLine("Access denied - you are too young");
                }

                newCustomer = StringInput("Another customer? ( Y / N ): ", "Y", "N");

            } while (newCustomer == "Y");

            string seeMovies = StringInput("Would you like to see a list of movies selected? ( Y / N ): ", "Y", "N");

            if (seeMovies == "Y")
            {
                WriteLine("Age\tFilm Selected");
                foreach (var film in userFilms)
                {
                    WriteLine($"{film.Age}\t{film.Film}");
                }
            }

            WriteLine("Have a nice day!");

        }
    }
}
