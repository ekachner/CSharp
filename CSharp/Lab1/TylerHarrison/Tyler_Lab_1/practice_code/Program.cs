using System;

namespace practice_code
{
    class Program
    {
        static void Main()
        {
            int Min_FilmNbr = 1;
            int Max_FilmNbr = 5;

            int intFilmNbr, age;
            String stringFilmNbr, ageString;

            Console.WriteLine("Welcome to our Multiplex, where the seats stink and the floors are always sticky!" +
                 "\nWe are currently showing one decent film, three crappy films, and one good film! Your selections are:  " +
                 "\n1. Rush (15)" +
                 "\n2. How I Live Now (15)" +
                 "\n3. Thor:  The Dark World (12A)" +
                 "\n4. Filth (18)" +
                 "\n5. Planes (U)" +
                 "\n");
            Console.WriteLine("Please enter the film number you whish to see: ");
            stringFilmNbr = Console.ReadLine();
            intFilmNbr = int.Parse(stringFilmNbr);

            Console.Write("Please enter your age:  ");
            ageString = Console.ReadLine();
            age = int.Parse(ageString);

            if (intFilmNbr == 1 && age >=15)
            {
                Console.WriteLine("You are old enough, unfortunately, due to COVID 19 we are closed! ");

            }

            else if (intFilmNbr == 2 && age >= 15)
            {
                Console.WriteLine("You are old enough, unfortunately, due to COVID 19 we are closed! ");

            }
            else if (intFilmNbr == 3 && age >=12)
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



        }
    }
}