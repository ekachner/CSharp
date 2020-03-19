using System;

namespace erica_cinema.cs
{
    class Program
    {
        //private static int number;

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my Cineplex.\nWe are currently showing: ");
            Console.WriteLine("1. Onward (PG)\n2. Bloodshot (PG13)\n3. The Way Back (R)\n" +
                "4. The Call of the Wild (PG)\n5. Jumanji the Next Level (PG13)\n6. 1917 (R)\n");
            //Console.Write("Enter the corresponding number for the film you wish to see: ");
            //string filmNumber = Console.ReadLine();
            //int number = int.Parse(filmNumber);
            //Console.Write("Enter your age: ");
            //string ageText = Console.ReadLine();
            //int age = int.Parse(ageText);


            //variables = age , number

            int number;
            int age;

            do
            {
                Console.Write("Enter the corresponding number for the film you wish to see: ");
                string filmNumber = Console.ReadLine();
                number = int.Parse(filmNumber);
            } while (number < 1 || number > 6);


            do
            {
                Console.Write("Enter your age: ");
                string ageText = Console.ReadLine();
                age = int.Parse(ageText);
            } while (age < 5 || age > 120);




            //if (age >= 100 && number >= 1 && number < 7)
            //{
            //    Console.Write("Bless your soul...");
            //}


            //if (number == 1 || number == 4)
            //{
            //    Console.WriteLine("Enjoy the film!");
            //}



            //if (number == 2 || number == 5)
            //{
            //    if (age >= 13)
            //    {
            //        Console.WriteLine("Enjoy the film!");
            //    }
            //    else
            //    {
            //        Console.WriteLine("Access denied - You are too young to view this film.");
            //    }

            //}



            //         if (number == 3 || number == 6)
            //         {
            //             if(age >= 18)
            //             {
            //                 Console.WriteLine("Enjoy the film!");
            //             }
            //             else
            //             {
            //                 Console.WriteLine("Access denied - You are too young to view this film.");
            //             }

            //         }

            //         if (number > 6 || number == 0)
            //{
            //             Console.WriteLine("The film number you entered is not a valid input");
            //}

        }
    }
}

