using System;

namespace CinemaEntry
{
    class Program
    {
        static void Main(string[] args)
        {
            char anotherTicket = 'Y';

            do
            {
                Console.WriteLine("Welcome to our Multiplex!");
                Console.WriteLine("We are currently showing:");

                Console.WriteLine("1. Rush (15)");
                Console.WriteLine("2. How I Live Now (15)");
                Console.WriteLine("3. Thor: The Dark World (12A)");
                Console.WriteLine("4. Filth (18)");
                Console.WriteLine("5. Planes (U)");
                
                int FilmNo;

                do 
                {
                    Console.WriteLine("Enter the number of the film you want to see:");
                    string FilmInput = Console.ReadLine();
                    FilmNo = int.Parse(FilmInput);

                    if (FilmNo < 1 || FilmNo > 5)
                    {
                        Console.WriteLine("Invalid movie number!");
                    }
                } while (FilmNo < 1 || FilmNo > 5);

                int Age;

                do 
                {
                    Console.WriteLine("Please enter your age:");
                    string AgeInput = Console.ReadLine();
                    Age = int.Parse(AgeInput);
                    if (Age < 5 || Age > 110)
                    {
                        Console.WriteLine("Invalid Age!");
                    }
                } while (Age < 5 || Age > 110);

                if (FilmNo == 1 && Age >= 15)
                {
                    Console.WriteLine("Age approved!");
                }
                else if (FilmNo == 2 && Age >= 15)
                {
                    Console.WriteLine("Age approved!");
                }
                else if (FilmNo == 3 && Age >= 12)
                {
                    Console.WriteLine("Age approved!");
                }
                else if (FilmNo == 4 && Age >= 18)
                {
                    Console.WriteLine("Age approved!");
                }
                else if (FilmNo == 5 && Age >= 5)
                {
                    Console.WriteLine("Age approved!");
                }
                else
                {
                    Console.WriteLine("Access Denied! You are too young to view this film!");
                }
                Console.WriteLine("Would you like to purchase another ticket? Y/N");
                anotherTicket = char.ToUpper(Console.ReadLine()[0]);

                if (anotherTicket == 'N')
                {
                    Console.WriteLine("Thank you for choosing us! Beverages will be on the next counter. Enjoy your film!");

                } else if (anotherTicket == 'Y')
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("Invalid response!");
                    Console.WriteLine("Would you like to purchase another ticket? Y/N");
                    anotherTicket = char.ToUpper(Console.ReadLine()[0]);
                }

            } while (anotherTicket == 'Y');
        }
    }
}
