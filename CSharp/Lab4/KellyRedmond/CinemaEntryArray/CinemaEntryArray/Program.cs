using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CinemaEntryArray
{

    class Program
    {
        public const int THEATERSCREENS = 5;

        static void Main()
        { 
            string[] films = FilmEntry();

            Console.Clear();

            if (films.Length < 1)
            {
                Console.WriteLine("Sorry, we are not currently showing any films.");
                Environment.Exit(1);
            }

            List<User> userFilms = new List<User>();

            string newCustomer;

            do
            {
                MultiplexWelcome(films);

                int userFilm = User.GetFilmSelectionNumber(films);
                string selectedFilm = User.GetFilmTitle(films, userFilm);
                string filmNameOnly = selectedFilm.Substring(0, selectedFilm.IndexOf(" ") + 1);
                string filmChosen = StringInput($"The film you selected is {filmNameOnly}\nIs this correct? ( Y / N ): ", "Y", "N");

                if (filmChosen == "N")
                {
                    newCustomer = "Y";
                    continue;
                }

                int userAge = User.GetUserAge();

                FilmGoerAgeCheck(selectedFilm, userFilms, userAge, filmNameOnly);

                newCustomer = StringInput("Another customer? ( Y / N ): ", "Y", "N");

            } while (newCustomer == "Y");

            Console.Clear();

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

        static string[] FilmEntry()
        {
            int numberOfFilms = IsNumber("Please enter the number of films you are entering today: ", 0, THEATERSCREENS);

            string[] films = new string[numberOfFilms];

            string areFilmsCorrect = "N";

            while (areFilmsCorrect == "N")
            {
                int displayNumber = 1;

                for (var i = 0; i < films.Length; i++)
                {
                    bool filmEnteredCorrectly = false;
                    do
                    {
                        Console.Write($"Enter the film title and the age of viewer for film {displayNumber}: ");

                        string filmInformation = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine().Trim());

                        if (filmInformation.Length > 6 && filmInformation.Contains(" "))
                        {
                            if (filmInformation.EndsWith("12") || filmInformation.EndsWith("15") || filmInformation.EndsWith("18") || filmInformation.EndsWith("0"))
                            {
                                films[i] = filmInformation;
                                filmEnteredCorrectly = true;
                            }
                            else
                            {
                                Console.WriteLine("Ages for films are: 0, 12, 15, 18");
                                continue;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Please re-enter your film using this example\nRush 15");
                        }

                    } while (filmEnteredCorrectly == false);

                     displayNumber += 1;
                }

                Console.WriteLine($"The Films you entered are:");

                foreach (var film in films)
                {
                    Console.WriteLine($"\t{film}");
                }

                areFilmsCorrect = StringInput("Are these correct? ( Y / N ): ", "Y", "N");
            }

            return films;
        }

        static void MultiplexWelcome(string[] films)
        {
            Console.WriteLine("Welcome to our Multiplex\nWe are presently showing:");

            for (int number = 0; number < films.Length; number++)
            {
                var film = films[number];

                if (film.Contains("15") || film.EndsWith("18"))
                {
                    Console.WriteLine($"\t{number + 1}. {film}");
                }
                else if (film.EndsWith("12"))
                {
                    Console.WriteLine($"\t{number + 1}. {film}A");
                }
                else
                {
                    Console.WriteLine($"\t{number + 1}. {film.Remove(film.Length - 1)}U");
                }
            }
        }

        static int AgeForFilm(string film)
        {
            string ageForFilmString = new string(film.ToCharArray().Where(i => char.IsDigit(i)).ToArray());
            int ageForFilm = int.Parse(ageForFilmString);

            switch (ageForFilm)
            {
                case int n when (n <= 11):
                    ageForFilm = 0;
                    break;

                case int n when (n <= 14):
                    ageForFilm = 12;
                    break;

                case int n when (n <= 17):
                    ageForFilm = 15;
                    break;

                case int n when n == 18:
                    ageForFilm = 18;
                    break;

                default:
                    Console.WriteLine("Age not accepted. Please run program again");
                    break;
            }

            return ageForFilm;
        }

        static void FilmGoerAgeCheck(string film, List<User> userFilms, int userAge, string selectedFilm)
        {
            if (userAge >= AgeForFilm(film))
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

        static void AdultGoing(List<User> userFilms, int userAge, string selectedMovie)
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