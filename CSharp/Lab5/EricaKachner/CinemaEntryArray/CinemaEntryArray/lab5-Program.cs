using System;

namespace CinemaEntryArray
{
    class Program
    {

        //reads film inputs
        static int ReadNumber(string prompt, int min, int max)
        {
            int number;

            do
            {
                Console.Write(prompt);
                string numberString = Console.ReadLine();
                number = int.Parse(numberString);
                if (number > max || number < min)
                {
                    Console.WriteLine("\tPlease enter a valid number between " + min + " to " + max);
                    Console.WriteLine();
                }
            } while (number > max || number < min);
            return number;
        }


        //reads films the user inputs
        static string[] ReadFilmNames()
        {
            int moviesNumber = ReadNumber("How many movies do you wish to insert?: ", 1, 15);
            int numberOfMovies;
            numberOfMovies = moviesNumber;
            string[] filmNames = new string[numberOfMovies];

           
            //this reads in the film names
            for (int i = 0; i < filmNames.Length; i++)
            {
                int displayNumber = i + 1;
                string filmName;

                do
                {
                    Console.Write($"Enter the name of film number {displayNumber}: ");
                    filmName = Console.ReadLine();


                    if (ValidateFilmName(filmName))
                    {
                        filmNames[i] = filmName;
                    }
                    else
                    {
                        Console.WriteLine($"\tError; Make sure the film name ends with a rating");
                    }
                } while (ValidateFilmName(filmName) == false) ;
            }                                               
            return filmNames;
        }


        //checks to make sure films contain a proper rating
        static bool ValidateFilmName(string filmName)
        {
            var trimmedFilm = filmName.Trim();
            return (trimmedFilm.EndsWith("(PG)") || trimmedFilm.EndsWith("(PG-13)") || trimmedFilm.EndsWith("(R)"));            
        }


        //list film inputs
        static void WriteFilmNames(string[] filmName)
        {
            Console.WriteLine($"We are currently showing: ");
            for (int i = 0; i < filmName.Length; i++)
            {
                int number = i + 1;
                Console.WriteLine(number + ". " + filmName[i]);
            }
        }


        //returns age of user
        static int AgePrompt()
        {
            int age = 0;

            do
            {
                try
                {
                    age = ReadNumber("Enter your age : ", 5, 120);
                    Console.WriteLine("\tYou say you are " + age + " years old...\n");
                    Console.WriteLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine("\tError; " + e.Message);
                    Console.WriteLine();
                }
            } while (age < 5 || age > 120);
            return age;
        }
       

        //filters whether the person is old enough to view the film based on the age of user
        static void FilterAges(string[] filmName, int chosenNumber, int age)
        {
            chosenNumber = chosenNumber - 1;
            if (filmName[chosenNumber].EndsWith("(PG)"))
            {
                Console.WriteLine("Enjoy the film!");
            }

            if (filmName[chosenNumber].EndsWith("(PG-13)"))
            {
                Console.WriteLine(age >= 13 ? "Enjoy the film!" : "Access denied - You are too young to view this film.");
            }

            if (filmName[chosenNumber].EndsWith("(R)"))
            {
                Console.WriteLine(age >= 18 ? "Enjoy the film!" : "Access denied - You are too young to view this film.");
            }
        }



        static void Main(string[] args)
        {

            string roundAbout;
            int age; 
            

            Console.WriteLine("\nWelcome to Cineplex!\n");            
            string[] filmName = ReadFilmNames();

            do
            {
                WriteFilmNames(filmName);
                
                
                Console.Write("Please select a movie number: ");
                string chosenNumberString = Console.ReadLine();
                int chosenNumber = int.Parse(chosenNumberString);
                Console.WriteLine("You have chosen " + chosenNumber.ToString() + ": " + filmName[chosenNumber - 1]);

                age = AgePrompt();
                FilterAges(filmName, chosenNumber, age);


                Console.Write("\nIf you would like to add another person to your party, enter \"Y\" OR press \"return\" to end this session:");
                roundAbout = Console.ReadLine();
                Console.WriteLine();

            } while (roundAbout.ToUpper() == "Y");


            Console.WriteLine("\nThank you for choosing Cineplex to enjoy all your box office hits.");
        }
    }
}
