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

            if (films.Length < 1)
            {
                Console.WriteLine("Sorry, we are not currently showing any films.");
                Environment.Exit(1);
            }

            List<User> userFilms = new List<User>();

            NewCustomer(films, userFilms);

            User.PrintUserFilms(userFilms);

            Console.WriteLine("Have a nice day!");
        }

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
                    string newFilm = Film.VerifyFilmInformation($"Enter the film title and the age of viewer for film {displayNumber}: ");
                    films[i] = new Film { FilmInformation = newFilm };
                     displayNumber += 1;
                }

                Console.WriteLine($"The Films you entered are:");

                foreach (var film in films)
                {
                    Console.WriteLine($"\t{film.FilmInformation}");
                }

                areFilmsCorrect = StringInput("Are these correct? ( Y / N ): ", "Y", "N");
            }

            Console.Clear();

            return films;
        }

        static void MultiplexWelcome(Film[] films)
        {
            Console.WriteLine("Welcome to our Multiplex\nWe are presently showing:");

            for (int number = 0; number < films.Length; number++)
            {
                string film = films[number].FilmInformation;
                Console.WriteLine($"\t{number + 1}. {Film.FilmOutput(film)}");
            }
        }

        static void NewCustomer(Film[] films, List<User> userFilms)
        {
            string newCustomer;

            do
            {
                MultiplexWelcome(films);

                int userFilm = User.GetFilmSelectionNumber(films);
                string selectedFilm = User.GetFilmTitle(films, userFilm);
                string filmName = Film.GetFilmName(selectedFilm);

                string filmChosen = StringInput($"The film you selected is {filmName}\nIs this correct? ( Y / N ): ", "Y", "N");

                if (filmChosen == "N")
                {
                    newCustomer = "Y";
                    Console.Clear();
                    continue;
                }

                int userAge = User.GetUserAge();

                FilmGoerAgeCheck(selectedFilm, userFilms, userAge, filmName);

                newCustomer = StringInput("Another customer? ( Y / N ): ", "Y", "N");
                Console.Clear();

            } while (newCustomer == "Y");

            Console.Clear();
        }

        static void FilmGoerAgeCheck(string film, List<User> userFilms, int userAge, string selectedFilm)
        {
            if (userAge >= Film.GetFilmAge(film))
            {
                Console.WriteLine($"Enjoy {selectedFilm}");
                userFilms.Add(new User(userAge, selectedFilm));
            }
            else
            {
                Console.WriteLine("Access denied - you are too young");
                AdultGoing(userFilms, userAge, selectedFilm);
            }
        }

        static void AdultGoing(List<User> userFilms, int userAge, string selectedFilm)
        {
            string adultGoing = StringInput("Will there be someone over the age of 18 accompanying the minor? ( Y / N ): ", "Y", "N");

            if (adultGoing == "Y")
            {
                string anotherTicketBought = StringInput("Have you already selected a ticket for the adult? ( Y / N ): ", "Y", "N");

                if (anotherTicketBought == "Y" && userFilms.Exists(x => x.Film == selectedFilm) == true)
                {
                    userFilms.Add(new User(userAge, selectedFilm));
                    Console.WriteLine($"Enjoy {selectedFilm}");
                }
                else
                {
                    userFilms.Add(new User(userAge, selectedFilm));
                    int adultAge = IsNumber("Enter the age of the adult accompanying the minor: ", 18, 120);
                    userFilms.Add(new User(adultAge, selectedFilm));
                    Console.WriteLine($"Enjoy {selectedFilm}");
                }
            }
        }
    }
}