using System;
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


    class Program
    {
        static int ReadNumber(string prompt, int min, int max)
        {
            int result = 0;

            do
            {
                Write(prompt);
                string numberString = ReadLine();
                result = int.Parse(numberString);
                if (result > max || result < min)
                {
                    WriteLine($"Please enter a number between {min} and {max}");
                }
                else
                {
                    break;
                }
            } while (true);

            return result;
        }

        static void Main()
        {
            Movie[] Movies = new Movie[5];
            Movies[0] = new Movie("Rush", 15);
            Movies[1] = new Movie("How I Live Now", 15);
            Movies[2] = new Movie("Thor: The Dark World", 12);
            Movies[3] = new Movie("Filth", 18);
            Movies[4] = new Movie("Planes", 0);

            WriteLine("Welcome to our Multiplex");
            WriteLine("We are presently showing:");

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
            } else
            {
                WriteLine("Access denied - you are too young");
            }
        }
    }
}
