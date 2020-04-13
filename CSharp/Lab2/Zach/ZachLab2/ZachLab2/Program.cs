using System;

namespace ZachLab2
{
        class Program
        {
            static void Main(string[] args)
            {
                int filmNo = 1;
                int age = 1;
                string filmMessage = "Access Denied";
                string anotherCustomer;
            do
            { 
                Console.WriteLine("Welcome to our Multiplex!");
                Console.WriteLine("We are currently showing:");
                Console.WriteLine("1. Rush (15)");
                Console.WriteLine("2. How I Live Now (15)");
                Console.WriteLine("3. Thor: The Dark World (12A)");
                Console.WriteLine("4. Filth (18)");
                Console.WriteLine("5. Planes (U)");
                                
                do
                {
                    Console.WriteLine("Enter the number of the film you wish to see:");
                    filmNo = Convert.ToInt32(Console.ReadLine());
                    if (filmNo > 5 || filmNo < 1)
                    {
                        Console.WriteLine("Enter number between 1 and 5");
                    }
                }
                while (filmNo > 5 || filmNo < 1);
                    
                do
                {
                    Console.WriteLine("Enter your age:");
                    age = Convert.ToInt32(Console.ReadLine());
                    if (age > 120 || age < 5);
                    {
                        Console.WriteLine("Invalid age. Must be between 5 and 120.");
                    }
                }
                while (age > 120 || age < 5);
                    

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
                

                Console.WriteLine("Another Customer? (Y or N):");
                anotherCustomer = Console.ReadLine();
            }
            while (anotherCustomer == "Y");


                Console.WriteLine(filmMessage); 

            }
        }
    

}
    

