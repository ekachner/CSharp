using System;

namespace Lab2
{
    class Program
    {
        static void Main()
        {
           String doWeGoAroundAgain;
            do
            {
                int Min_FilmNbr = 1;
                int Max_FilmNbr = 5;

                int intFilmNbr, age;


                Console.WriteLine("Welcome to our Multiplex, where the seats stink and the floors are always sticky!" +
                     "\nWe are currently showing one decent film, three crappy films, and one good film! Your selections are:  " +
                     "\n1. Rush (15)" +
                     "\n2. How I Live Now (15)" +
                     "\n3. Thor:  The Dark World (12A)" +
                     "\n4. Filth (18)" +
                     "\n5. Planes (U)" +
                     "\n");
                do
                {
                    Console.WriteLine("Please enter the film number you whish to see: ");
                    intFilmNbr = int.Parse(Console.ReadLine());
                    if (intFilmNbr < 1 || intFilmNbr > 5)
                    {
                        Console.WriteLine("Please make a choice between 1 and 5");
                    }
                }
                while (intFilmNbr < 1 || intFilmNbr > 5);

                do
                {
                    Console.Write("Please enter your age:  ");
                    age = int.Parse(Console.ReadLine());
                    if (age < 1 || age > 132)
                    {
                        Console.WriteLine("please select and age between 1 and 132");
                    }
                }
                while (age < 1 || age > 132);


                if ((intFilmNbr == 1 || intFilmNbr == 2) && age >= 15)
                {
                    Console.WriteLine("You are old enough, unfortunately, due to COVID 19 we are closed! ");
                }
                else if (intFilmNbr == 3 && age >= 12)
                {
                    Console.WriteLine("Not sure what the A means, but your old enough, unfortunately, due to COVID 19 we are closed! ");
                }
                else if (intFilmNbr == 4 && age >= 18)
                {
                    Console.WriteLine("You are old enough, unfortunately, due to COVID 19 we are closed! ");
                }
                else if (intFilmNbr == 5 && age >= 0)
                {
                    Console.WriteLine("You are old enough, unfortunately, due to COVID 19 we are closed ");
                }
                else
                {
                    Console.WriteLine("Sorry little buddy, your not old enough ");
                }

                Console.Write("Another Customer? Press Y for YES, or N for NO: ");
                doWeGoAroundAgain = Console.ReadLine();
                Console.WriteLine();
            }
            while (doWeGoAroundAgain.ToUpper( ) == "Y");
        } 
    }
}