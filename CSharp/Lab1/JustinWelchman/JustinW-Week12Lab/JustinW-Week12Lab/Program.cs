using System;

namespace JustinW_Week12Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Weclome to our Multiplex!");
            Console.WriteLine("We are presently showing:");
            Console.WriteLine("1. Rush (15)");
            Console.WriteLine("2. How I Live Now (15)");
            Console.WriteLine("3. Thor: The Dark World (12A)");
            Console.WriteLine("4. Filth (18)");
            Console.WriteLine("5. Planes (U)");
            Console.WriteLine("Enter the number of the film you wish to see:");
            string FilmNo = Console.ReadLine();
            int FilmInput = int.Parse(FilmNo);
            Console.WriteLine("Enter your age:");
            string Age = Console.ReadLine();
            int AgeInput = int.Parse(Age);

            if (FilmInput == 1 && AgeInput >= 15)
            {
                Console.WriteLine("Enjoy your film!");
            } else if (FilmInput == 2 && AgeInput >= 15)
            {
                Console.WriteLine("Enjoy your film!");
            } else if (FilmInput == 3 && AgeInput >= 12)
            {
                Console.WriteLine("Enjoy your film!");
            } else if (FilmInput == 4 && AgeInput >= 18)
            {
                Console.WriteLine("Enjoy your film!");
            } else if (FilmInput == 5 && AgeInput >= 0)
            {
                Console.WriteLine("Enjoy your film!");
            } else
            {
                Console.WriteLine("Access Denied");
            }
        }
    }
}
