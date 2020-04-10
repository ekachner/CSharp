using System;

namespace CinemaEntry
{
    class Program
    {

        static int FilmNumberPrompt()
        {
            int filmNumber = 0;

            do
            {
                try
                {
                    filmNumber = ReadFilmNumber("Enter the corresponding film number wished to be viewed: ", 1, 6);
                    Console.WriteLine("\tFilm Number " + filmNumber + " chosen\n");

                }
                catch (Exception e)
                {
                    Console.WriteLine("\tError; " + e.Message);
                    Console.WriteLine();
                }
            } while (filmNumber < 1 || filmNumber > 6);
            return filmNumber;
        }



        static int ReadFilmNumber(string prompt, int min, int max)
        {
            int filmNumber;

            do
            {
                Console.Write(prompt);
                string numberString = Console.ReadLine();
                filmNumber = int.Parse(numberString);
                if (filmNumber > max || filmNumber < min)
                {
                    Console.WriteLine("\tPlease enter a valid film number between " + min + " to " + max);
                    Console.WriteLine();
                }
            } while (filmNumber > max || filmNumber < min);
            return filmNumber;           
        }



        static int AgePrompt()
        {
            int age = 0;

            do
            {
                try
                {
                    age = ReadAge("Enter your age : ", 5, 120);
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



        static int ReadAge(string prompt, int min, int max)
        {
            int age;

            do
            {
                Console.Write(prompt);
                string ageString = Console.ReadLine();
                age = int.Parse(ageString);
                if (age > max || age < min)
                {
                    Console.WriteLine("\tYour age must be between " + min + " to " + max);
                    Console.WriteLine();
                }
            } while (age > max || age < min);
            return age;
        }



        static void FilterAge(int age, int filmNumber)
		{
            if (filmNumber == 1 || filmNumber == 4)
            {
                Console.WriteLine("Enjoy the film!");
            }


            if (filmNumber == 2 || filmNumber == 5)
            {
                Console.WriteLine(age >= 13 ? "Enjoy the film!" : "Access denied - You are too young to view this film.");
            }


            if (filmNumber == 3 || filmNumber == 6)
            {
                Console.WriteLine(age >= 18 ? "Enjoy the film!" : "Access denied - You are too young to view this film.");
            }
        }




        static void Main(string[] args)
        {
            
            string roundAbout;

            Console.WriteLine("\nWelcome to Cineplex!\n");

            do
            {

                Console.WriteLine("We are currently showing:\n1. Onward (PG)\n2. Bloodshot (PG13)\n3. The Way Back (R)\n" +
                    "4. The Call of the Wild (PG)\n5. Jumanji the Next Level (PG13)\n6. 1917 (R)\n");


                int filmNumber = FilmNumberPrompt();
                int age = AgePrompt();

               
                FilterAge(age, filmNumber);


				Console.Write("\nIf you would like to add another person to your party, enter \"Y\" OR press \"return\" to end this session:");
                roundAbout = Console.ReadLine();
 
            } while (roundAbout.ToUpper() == "Y");


            Console.WriteLine("\nThank you for choosing Cineplex to enjoy all your box office hits.");
        }
    }
}








