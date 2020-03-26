using System;

namespace ZachLab1
{
    class Program
    {
        static void Main(string[] args)
        {
            int filmNo = 1;
            int age = 1;
            string filmMessage = "Access Denied";

            Console.WriteLine("Welcome to our Multiplex!");
            Console.WriteLine("We are currently showing:");
            Console.WriteLine("1. Rush (15)");
            Console.WriteLine("2. How I Live Now (15)");
            Console.WriteLine("3. Thor: The Dark World (12A)");
            Console.WriteLine("4. Filth (18)");
            Console.WriteLine("5. Planes (U)");
            Console.WriteLine("Enter the number of the film you wish to see:");
            filmNo = Convert.ToInt32(Console.ReadLine());
            if (filmNo > 5 || filmNo < 1)
            {
                filmMessage = "Invalid film number";
                Console.WriteLine(filmMessage);
                return;
            }
            Console.WriteLine("Enter your age:");
            age = Convert.ToInt32(Console.ReadLine());

            

            if (age > 120 || age < 5)
            {
                filmMessage = "Invalid Age";
                Console.WriteLine(filmMessage);
                return;
            }

            if (filmNo == 1 && age >= 15)
            {
                filmMessage = "Enjoy your film!";
            }
            else if (filmNo == 2 && age >= 15)
            {
                filmMessage = "Enjoy your film!";
            }
            else if (filmNo == 3 && age >= 12)
            {
                filmMessage = "Enjoy your film!";
            }
            else if (filmNo == 4 && age >= 18)
            {
                filmMessage = "Enjoy your film!";
            }
            else if (filmNo == 5 && age >= 5)
            {
                filmMessage = "Enjoy your film!";
            }
            

            Console.WriteLine(filmMessage);
            
            
        }
    }
}



            

