using System;

namespace CinemaEntry
{
    class Program
    {


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
                    Console.WriteLine("Your age must be between " + min + " to " + max );
                    Console.WriteLine();
                }  
            } while (age > max || age < min);

            return age;
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
                    Console.WriteLine("Please enter a valid film number between " + min + " to " + max);
                    Console.WriteLine();
                }
            } while (filmNumber > max || filmNumber < min);

            return filmNumber;           
        }




        static void Main(string[] args)
        {
            
            string roundAbout;

            Console.WriteLine("\nWelcome to Cineplex!\n");

            do
            {
                int filmNumber = 0;
                int age = 0;

                Console.WriteLine("We are currently showing:\n1. Onward (PG)\n2. Bloodshot (PG13)\n3. The Way Back (R)\n" +
                    "4. The Call of the Wild (PG)\n5. Jumanji the Next Level (PG13)\n6. 1917 (R)\n");


                do
                {
                    try
                    {
                        filmNumber = ReadFilmNumber("Enter the corresponding film number wished to be viewed: ", 1, 6);
                        Console.WriteLine("Film Number " + filmNumber + " chosen\n");
                        
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error; " + e.Message);
                        Console.WriteLine();
                    }
                } while (filmNumber < 1 || filmNumber > 6);


                do
                {
                    try
                    {
                        age = ReadAge("Enter your age : ", 5, 120);
                        Console.WriteLine("You say you are " + age + " years old...\n");
                        Console.WriteLine();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error; " + e.Message);
                        Console.WriteLine();
                    }
                } while (age < 5 || age > 120);


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


                Console.Write("\nIf you would like to add another person to your party, enter \"Y\" OR press \"return\" to end this session:");
                roundAbout = Console.ReadLine();
                Console.WriteLine();

            } while (roundAbout.ToUpper() == "Y");


            Console.WriteLine("\nThank you for choosing Cineplex to enjoy all your box office hits.");
        }
    }
}








