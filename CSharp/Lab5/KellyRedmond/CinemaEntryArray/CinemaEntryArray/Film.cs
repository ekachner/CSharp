using System;
using System.Globalization;
using System.Linq;


namespace CinemaEntryArray
{
    public class Film
    {
        public string FilmInformation { get; set; }

        public static string VerifyFilmInformation(string prompt)
        {
            string filmInput;

            do
            {
                Console.Write(prompt);
                filmInput = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine().Trim());
                string filmAge = new string (filmInput.ToCharArray().Where(i => char.IsDigit(i)).ToArray());

                if (filmInput.Length > 3 && filmInput.Contains(" ") && filmInput.ToCharArray().Where(i => char.IsDigit(i)).ToArray().Length > 0)
                {
                  
                    int ageForFilm = GetFilmAge(filmInput);
                    filmInput = GetFilmName(filmInput);
                    filmInput += ageForFilm.ToString();
                    break;
                }
                else
                {
                    Console.WriteLine("Please re-enter your film using this example\nRush 15");
                }
            } while (true);

            return filmInput;
        }

        public static string GetFilmName(string film)
        {
            string filmName = film.Substring(0, film.IndexOf(" ") + 1);
            return filmName;
        }

        public static int GetFilmAge(string film)
        {
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

                    case int n when n >= 18:
                        ageForFilm = 18;
                        break;

                    default:
                        Console.WriteLine("Age not accepted. Please run program again");
                        break;
                }

                return ageForFilm;
            }
        }

        public static string FilmOutput(string film)
        {
            string filmTitle = GetFilmName(film);
            int filmAge = GetFilmAge(film);
            string filmReturn = filmAge switch
            {
                int n when n == 15 || n == 18 => $"{filmTitle} ({filmAge})",
                int n when n == 12 => $"{filmTitle} ({filmAge}A)",
                int n when n == 0 => $"{filmTitle} (U)",
                _ => "Age not accepted. Please run program again",
            };
            return filmReturn;
        }
    }
}
