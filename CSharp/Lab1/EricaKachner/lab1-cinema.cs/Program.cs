using System;

namespace erica_cinema.cs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my Cineplex.\nWe are currently showing: ");
            Console.WriteLine("1. Onward (PG)\n2. Bloodshot (PG13)\n3. The Way Back (R)\n" +
                "4. The Call of the Wild (PG)\n5. Jumanji the Next Level (PG13)\n6. 1917 (R)\n");
            Console.Write("Enter the corresponding number for the film you wish to see: ");
            string filmNumber = Console.ReadLine();
            int number = int.Parse(filmNumber);
            Console.Write("Enter your age: ");
            string ageText = Console.ReadLine();
            int age = int.Parse(ageText);

            //test if number = 1 and age = 3  (enjoy film)
            //test if number = 4 and age = 21  (enjoy film)
            if (number == 1 || number == 4)
            {
                Console.WriteLine("Enjoy the film!");
            }


            //test if number = 2 and age = 3  (access denied)
            //test if number = 5 and age = 13  (enjoy film)
            if (number == 2 || number == 5)
            {
                if (age >= 13)
                {
                    Console.WriteLine("Enjoy the film!");
                }
                else
                {
                    Console.WriteLine("Access denied - You are too young to view this film.");
                }
                    
            }


            //test if number = 3 and age = 17   (access denied)
            //test if number = 6 and age = 18   (enjoy film)
            if (number == 3 || number == 6)
            {
                if(age >= 18)
                {
                    Console.WriteLine("Enjoy the film!");
                }
                else
                {
                    Console.WriteLine("Access denied - You are too young to view this film.");
                }
                   
            }  
        }
    }
}

