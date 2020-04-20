using System;
using System.Collections.Generic;

namespace CinemaEntryArray
{
    public class User
    {
        public int Age;
        public string Film;
        public int FilmSelection;

        public User(int age, string film)
        {
            Age = age;
            Film = film;
        }

        public static int GetFilmSelectionNumber(Film[] films)
        {
            int userFilm = Program.IsNumber("Enter the number of the film you wish to see: ", 1, films.Length);
            return userFilm;
        }

        public static string GetFilmTitle(Film[] films, int userFilm)
        {
            string selectedFilm = films[userFilm - 1].FilmInformation;
            return selectedFilm;
        }

        public static int GetUserAge()
        {
            int userAge = Program.IsNumber("Enter your age: ", 1, 120);
            return userAge;
        }

        public static void PrintUserFilms(List<User> userFilms)
        {
            string seeFilms = Program.StringInput("Would you like to see a list of films selected? ( Y / N ): ", "Y", "N");

            if (seeFilms == "Y" && userFilms.Count > 0)
            {
                Console.WriteLine("Viewer Age\tFilm Selected");
                foreach (var film in userFilms)
                {
                    Console.WriteLine($"{film.Age}\t\t{film.Film}");
                }
            }
            else if (seeFilms == "Y" && userFilms.Count < 1)
            {
                Console.WriteLine("No films selected");
            }
        }
    }
}