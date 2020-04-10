using System;

namespace CinemaEntryArray
{
    class Program
    {
        //readonly int numberOfMovies = 1;


        

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
 

        //static void FilterAge(int age, int filmNumber)
        //{
        //    if (filmNumber == 1 || filmNumber == 4)
        //    {
        //        Console.WriteLine("Enjoy the film!");
        //    }

        //    if (filmNumber == 2 || filmNumber == 5)
        //    {
        //        Console.WriteLine(age >= 13 ? "Enjoy the film!" : "Access denied - You are too young to view this film.");
        //    }

        //    if (filmNumber == 3 || filmNumber == 6)
        //    {
        //        Console.WriteLine(age >= 18 ? "Enjoy the film!" : "Access denied - You are too young to view this film.");
        //    }
        //}





        //try
        //        {
        //            age = ReadNumber("Enter your age : ", 5, 120);
        //Console.WriteLine("\tYou say you are " + age + " years old...\n");
        //            Console.WriteLine();
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine("\tError; " + e.Message);
        //            Console.WriteLine();
        //        }


        static string[] ReadFilmNames()
        {
            int numberOfMovies;
            //string filmName;

            Console.Write("How many movies do you wish to insert?:");
            string answerString = Console.ReadLine();
            int answer = int.Parse(answerString);
            numberOfMovies = answer;

            string[] filmNames = new string[numberOfMovies];

           
            //this reads in the film names
            for (int i = 0; i < filmNames.Length; i++)
            {
                int displayNumber = i + 1;
                
                Console.Write($"Enter the name of film number {displayNumber}: ");                
                string filmName = Console.ReadLine();
                if (ValidateFilmName(filmName))
                {
                    filmNames[i] = filmName;
                }
                else
                {
                    Console.WriteLine($"\tError; Make sure the film name ends with a rating");
                }
            }                                               
            return filmNames;
        }



        static bool ValidateFilmName(string filmName)
        {
            var trimmedFilm = filmName.Trim();
            return (trimmedFilm.EndsWith("(PG)") || trimmedFilm.EndsWith("(PG-13)") || trimmedFilm.EndsWith("(R)"));            
        }





        static void WriteFilmNames()
        {
            string[] filmName = ReadFilmNames(); 

            Console.WriteLine($"We are currently showing: ");
            for (int i = 0; i < filmName.Length; i++)
            {
                int number = i + 1;
                Console.WriteLine(number + ". " + filmName[i]);
            }
        }



        
        //static int FilmNumberPrompt()
        //{
        //    int filmNumber = 0;
        //    string[] filmName;

        //    do
        //    {
        //        try
        //        {
        //            filmNumber = ReadNumber("Enter the corresponding film number wished to be viewed: ", 1, filmName.Length);
        //            Console.WriteLine("\tFilm Number " + filmNumber + " chosen\n");

        //        }
        //        catch (Exception e)
        //        {
        //            if (ValidateFilmName(filmName))
        //            {
        //                filmNames[i] = filmName;
        //            }
        //            else
        //            {
        //                Console.WriteLine($"\tError; {e.Message} Make sure the film name ends with a rating");
        //            }
        //        }
        //    } while (filmNumber < 1 || filmNumber > NUMBER_OF_MOVIES);
        //    return filmNumber;

        //}



        //if (filmNames[chosenFilm].EndsWith("(12A)") ) {
        //    // The user has selected a film that is 12A rated
        //}





        static void Main(string[] args)
        {

            string roundAbout;
            //string[] filmNames = ReadFilmNames();




            //int chosenFilm = number - 1;
            //int chosenFilm;

            Console.WriteLine("\nWelcome to Cineplex!\n");
            string[] filmNames = ReadFilmNames();

            do
            {
                WriteFilmNames();

                Console.WriteLine("Please select a Movie: ");
                string chosenNumberString = Console.ReadLine();
                int chosenNumber = int.Parse(chosenNumberString);

                for(var i = 0; i < filmNames.Length; i++)
                {
                    chosenNumber = i + 1;
                    Console.Write(chosenNumber.ToString() + ": " + filmNames[i]);
                }

                //int filmNumber = FilmNumberPrompt();
                //int age = AgePrompt();

                //FilterAge(age, filmNumber);

                //look for end of string to filter rating


                Console.Write("\nIf you would like to add another person to your party, enter \"Y\" OR press \"return\" to end this session:");
                roundAbout = Console.ReadLine();
                Console.WriteLine();

            } while (roundAbout.ToUpper() == "Y");


            Console.WriteLine("\nThank you for choosing Cineplex to enjoy all your box office hits.");
        }
    }
}
