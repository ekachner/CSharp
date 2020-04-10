using System;

namespace Cinema_Arrays
{
    class Program
    {
        static void Main()
        {
            int numOfMovies = Inputs.ReadNumber("Please enter the number of movies currently playing at the Multiplex: ", 1, 10);
            Movie[] Movies = Movie.EnterMovieInfo(numOfMovies);

            char anotherTicket = 'Y';

            do
            {
                foreach (var Movie in Movies)
                {
                    string movieNumber = Movie.MovieNumber.ToString();

                    Console.WriteLine("{0}.  {1}  ({2})", movieNumber, Movie.MovieName, Movie.Rating);
                }

                int input = Inputs.ReadNumber("Please enter the number of the movie you would like to see: ", 1, numOfMovies);

                foreach (var Movie in Movies)
                {
                    if (input == Movie.MovieNumber)
                    {
                        Console.WriteLine("You have selected {0}.", Movie.MovieName);
                        int ageInput = Inputs.ReadNumber("Please enter your age: ", 5, 120);

                        if (ageInput >= Movie.AgeLimit)
                        {
                            Console.WriteLine("Approved. Enjoy your movie!");
                        }

                        else
                        {
                            Console.WriteLine("You are too young to see this movie.");
                        }
                    }
                }

                anotherTicket = Inputs.ReadString("Would you like to buy another movie ticket? [Y or N]: ")[0];
                Console.Clear();

                if (anotherTicket == 'N')
                {
                    Console.WriteLine("Thank you for coming to the Multiplex! Enjoy your movie!");
                }

            } while (anotherTicket == 'Y');
        }
    }
}
