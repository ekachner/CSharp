using System;
using System.Globalization;


namespace CinemaEntryArray
{
    public class Film
    {
        public string FilmTitle;
        public int FilmAge;

        public Film(string filmtitle, int filmAge)
        {
            FilmTitle = filmtitle;
            FilmAge = filmAge;
        }

        public static string GetFilmTitle()
        {
            string filmTitleInput = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine().Trim());
            while (String.IsNullOrEmpty(filmTitleInput))
            {
                Console.Write("Please enter a film name: ");
                filmTitleInput = Console.ReadLine().Trim();
            }

            return filmTitleInput;
        }


        public static int GetFilmAge()
        {
            int ageForFilm = Program.IsNumber("Please enter the required age of the viewer for this film: ", 0, 18);

            switch(ageForFilm)
            {
                case int n when (n <= 11) :
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
    }
}
