using System;
using System.Collections.Generic;

namespace CinemaEntryArray
{

    class Program
    {
        public const int THEATERSCREENS = 5;

        static void Main()
        { 
            Film[] films = FilmEntry();

            Console.Clear();

            if (films.Length < 1)
            {
                Console.WriteLine("Sorry, we are not currently showing any films.");
                Environment.Exit(1);
            }

            List<User> userFilms = new List<User>();

            do
            {
                MultiplexWelcome(films);

                int userFilm = User.GetFilmSelectionNumber(films);
                string selectedFilm = User.GetFilmTitle(films, userFilm);
                string filmChosen = StringInput($"The film you selected is {selectedFilm}\nIs this correct? ( Y / N ): ", "Y", "N");

                if (filmChosen == "N")
                {
                    newCustomer = "Y";
                    continue;
                }

                int userAge = User.GetUserAge();

                FilmGoerAgeCheck(films, userFilms, userAge, userFilm, selectedFilm);

                newCustomer = StringInput("Another customer? ( Y / N ): ", "Y", "N");

            } while (newCustomer == "Y");

            Console.Clear();

            User.PrintUserFilms(userFilms);

            Console.WriteLine("Have a nice day!");

        }


        public static string newCustomer;

        public static int IsNumber(string prompt, int min, int max)
        {

            Console.Write(prompt);
            string numberString = Console.ReadLine();
            bool verifyNumber = int.TryParse(numberString, out int numberOut);

            while (!verifyNumber || numberOut < min || numberOut > max)
            {
                Console.Write($"Entry not valid. Please enter a number between {min} and {max}: ");
                verifyNumber = int.TryParse(Console.ReadLine(), out numberOut);
            }

            return numberOut;
        }

        public static string StringInput(string prompt, string value1, string value2)
        {
            string input;

            do
            {
                Console.Write(prompt);
                input = Console.ReadLine().ToUpper().Trim();
                if (input == value1 || input == value2)
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Please choose either {value1} or {value2}");
                }
            } while (true);

            return input;
        }

        static Film[] FilmEntry()
        {
            int numberOfFilms = IsNumber("Please enter the number of films you are entering today: ", 0, THEATERSCREENS);

            Film[] films = new Film[numberOfFilms];

            string areFilmsCorrect = "N";

            while (areFilmsCorrect == "N")
            {
                int displayNumber = 1;

                for (var i = 0; i < films.Length; i++)
                {
                    Console.Write($"Enter the name of film number {displayNumber}: ");

                    string titleForFilm = Film.GetFilmTitle();

                    int ageForFilm = Film.GetFilmAge();

                    films[i] = new Film(titleForFilm, ageForFilm);

                    displayNumber += 1;
                }

                Console.WriteLine($"The Films you entered are:\n\nAge of Viewer\tFilm Title");

                foreach (var film in films)
                {
                    Console.WriteLine(value: $"{film.FilmAge}\t\t{film.FilmTitle}");
                }

                areFilmsCorrect = StringInput("Are these correct? ( Y / N ): ", "Y", "N");
            }

            return films;
        }

        static void MultiplexWelcome(Film[] films)
        {
            Console.WriteLine("Welcome to our Multiplex\nWe are presently showing:");

            for (int number = 0; number < films.Length; number++)
            {
                var film = films[number];

                if (film.FilmAge == 15 || film.FilmAge == 18)
                {
                    Console.WriteLine($"\t{number + 1}. {film.FilmTitle} ({film.FilmAge})");
                }
                else if (film.FilmAge == 12)
                {
                    Console.WriteLine($"\t{number + 1}. {film.FilmTitle} ({film.FilmAge}A)");
                }
                else
                {
                    Console.WriteLine($"\t{number + 1}. {film.FilmTitle} (U)");
                }
            }
        }

        static void FilmGoerAgeCheck(Film[] films, List<User> userFilms, int userAge, int userFilm, string selectedMovie)
        {
            if (userAge >= films[userFilm - 1].FilmAge)
            {
                Console.WriteLine($"Enjoy {selectedMovie}");
                userFilms.Add(new User(userAge, selectedMovie));
            }
            else
            {
                Console.WriteLine("Access denied - you are too young");
                AdultGoing(films, userFilms, userAge, selectedMovie);
            }
        }

        static void AdultGoing(Film[] films, List<User> userFilms, int userAge, string selectedMovie)
        {
            string adultGoing = StringInput("Will there be someone over the age of 18 accompanying the minor? ( Y / N ): ", "Y", "N");

            if (adultGoing == "Y")
            {
                string anotherTicketBought = StringInput("Have you already selected a ticket for the adult? ( Y / N ): ", "Y", "N");
                if (anotherTicketBought == "Y" && userFilms.Exists(x => x.Film == selectedMovie) == true)
                {
                    userFilms.Add(new User(userAge, selectedMovie));
                    Console.WriteLine($"Enjoy {selectedMovie}");
                }
                else
                {
                    userFilms.Add(new User(userAge, selectedMovie));
                    int adultAge = IsNumber("Enter the age of the adult accompanying the minor: ", 18, 120);
                    userFilms.Add(new User(adultAge, selectedMovie));
                    Console.WriteLine($"Enjoy {selectedMovie}");
                }
            }
        }
    }
}