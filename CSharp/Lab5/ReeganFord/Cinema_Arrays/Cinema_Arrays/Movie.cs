using System;
namespace Cinema_Arrays
{
    public class Movie
    {
        public Movie[] Movies;
        public int MovieNumber;
        public string MovieName;
        private string rating;
        public int AgeLimit;

        public Movie(int movieNumber, string movieName, string rating, int ageLimit)
        {
            MovieNumber = movieNumber;
            MovieName = movieName;
            Rating = rating;
            AgeLimit = ageLimit;
        }

        public string Rating
        {
            get { return rating; }
            set
            {
                if (value == "G" || value == "PG" || value == "PG-13" || value == "R")
                {
                    rating = value;
                }
                else
                {
                    rating = "NR";
                }
            }
        }

        public static Movie[] EnterMovieInfo(int numOfMovies)
        {
            Movie[] Movies = new Movie[numOfMovies];

            for (int i = 0; i < numOfMovies; i++)
            {
                int movieNum = i + 1;
                string nameInput = Inputs.ReadString("Please enter movie title: ");
                string ratingInput = Inputs.ReadString("Enter movie rating [G, PG, PG-13, R, NR]: ");

                int ageLimit = 0;
                switch (ratingInput)
                {
                    case "G":
                        ageLimit = 5;
                        break;
                    case "PG":
                        ageLimit = 7;
                        break;
                    case "PG-13":
                        ageLimit = 13;
                        break;
                    case "R":
                        ageLimit = 17;
                        break;
                    default:
                        ageLimit = 18;
                        break;
                }
                Movies[i] = new Movie(movieNum, nameInput, ratingInput, ageLimit);
            }
            return Movies;
        }
    }
}
