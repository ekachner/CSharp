using System;

namespace cinema_entry_arrays
{
    class Program
    {
        static void Main()
        {
            Console.Write("Please enter the number of movies currently playing at the MultiPlex: ");
            string numInput = Console.ReadLine();
            int numOfMovies;
            bool isNumber = int.TryParse(numInput, out numOfMovies);

            while(numOfMovies < 1 || numOfMovies > 10 || !isNumber)
            {
                Console.WriteLine("Invalid user input. Please try again.");
                Console.Write("Please enter the number of movies currently playing at the MultiPlex: ");
                numInput = Console.ReadLine();
                isNumber = int.TryParse(numInput, out numOfMovies);
            }

            Movie[] Movies = new Movie[numOfMovies];

            for(int i = 0; i < numOfMovies; i++)
            {
                int movieNum = i + 1;
                Console.WriteLine("Please enter movie title: ");
                string nameInput = Console.ReadLine();

                Console.Write("Enter movie rating (G, PG, PG-13, R, or NC-17): ");
                string ratingInput = Console.ReadLine().ToUpper();
                int ageLimit = 0;
                bool validEntry = false;

                while(!validEntry)
                {
                    switch (ratingInput)
                    {
                        case "G":
                            ageLimit = 5;
                            validEntry = true;
                            break;
                        case "PG":
                            ageLimit = 6;
                            validEntry = true;
                            break;
                        case "PG-13":
                            ageLimit = 13;
                            validEntry = true;
                            break;
                        case "R":
                            ageLimit = 17;
                            validEntry = true;
                            break;
                        case "NC-17":
                            ageLimit = 18;
                            validEntry = true;
                            break;
                        default:
                            Console.WriteLine("Invalid rating. Please try again.");
                            Console.Write("Enter movie rating (G, PG, PG-13, R, or NC-17): ");
                            ratingInput = Console.ReadLine().ToUpper();
                            validEntry = false;
                            break;
                    }
                }

                Movies[i] = new Movie(movieNum, nameInput, ratingInput.ToUpper(), ageLimit);     
            }

            char anotherTicket = 'Y';

            do
            {
                foreach (var Movie in Movies)
                {
                    string movieNumber = Movie.MovieNumber.ToString();

                    Console.WriteLine("{0}.  {1}  ({2})", movieNumber, Movie.MovieName, Movie.Rating);
                }

                Console.Write("Please enter the number of the movie you would like to see: ");
                string movieInput = Console.ReadLine();
                int number;
                bool isANumber = int.TryParse(movieInput, out number);

                while (number < 1 || number > numOfMovies || !isANumber)
                {
                    Console.WriteLine("Invalid movie number. Please try again.");
                    Console.WriteLine("Please enter the number of the movie you would like to see: ");
                    movieInput = Console.ReadLine();
                    isANumber = int.TryParse(movieInput, out number);
                }

                foreach (var Movie in Movies)
                {
                    if (number == Movie.MovieNumber)
                    {
                        Console.WriteLine("You have selected {0}.", Movie.MovieName);

                        Console.Write("Please enter your age: ");
                        string ageString = Console.ReadLine();
                        int age;
                        bool isNum = int.TryParse(ageString, out age);

                        while (age < 5 || age > 120 || !isNum)
                        {
                            Console.WriteLine("Invalid age. Please try again.");
                            Console.Write("Please enter your age: ");
                            ageString = Console.ReadLine();
                            isNum = int.TryParse(ageString, out age);
                        }

                        if (age >= Movie.AgeLimit)
                        {
                            Console.WriteLine("Approved. Enjoy your movie!");
                        }

                        else
                        {
                            Console.WriteLine("You are too young to see this movie.");
                        }
                    }
                }

                Console.Write("Would you like to buy another movie ticket? [Y or N]: ");
                anotherTicket = char.ToUpper(Console.ReadLine()[0]);
                Console.Clear();

                if(anotherTicket == 'N')
                {
                    Console.WriteLine("Thank you for coming to the Multiplex! Enjoy your movie!");
                }

            } while (anotherTicket == 'Y');
        }

        public class Movie
        {
            public readonly int MovieNumber;
            public readonly string MovieName;
            public readonly string Rating;
            public readonly int AgeLimit;

            public Movie(int movieNumber, string movieName, string rating, int ageLimit)
            {
                MovieNumber = movieNumber;
                MovieName = movieName;
                Rating = rating;
                AgeLimit = ageLimit;
            }
        }
    }
}
