using System;

namespace cinema
{
    class Program
    {
        static void Main(string[] args)
        {
            Welcome();
            EnterAge(EnterFilmNo());
        }

        static void Welcome()
        {
            Console.WriteLine("Welcome to our Multiplex");
            Console.WriteLine("We are presently showing:");
            Console.WriteLine("\t 1. Rush (15)");
            Console.WriteLine("\t 2. How I Live Now (15)");
            Console.WriteLine("\t 3. Thor: The Dark World (12A)");
            Console.WriteLine("\t 4. Filth (18)");
            Console.WriteLine("\t 5. Planes (U)");
        }

        static int EnterFilmNo()
        {
            Console.Write("Enter the film you wish to see: ");
            int filmNumber;
            string filmInput = Console.ReadLine();
            bool result = int.TryParse(filmInput, out filmNumber);
            return filmNumber;
        }
        static void EnterAge(int filmNo)
        {
            Console.Write("Enter your age: ");
            int age;
            string ageInput = Console.ReadLine();
            bool result = int.TryParse(ageInput, out age);

            switch (filmNo)
            {
                case 1:
                    AgeCheck(age, 15);
                    break;
                case 2:
                    AgeCheck(age, 15);
                    break;
                case 3:
                    AgeCheck(age, 12);      
                    break;
                case 4:
                    AgeCheck(age, 18);
                    break;
                case 5:
                    AgeCheck(age, 4);
                    break;
                default:
                    break;
                  
            }
        }
        static void AgeCheck(int age, int minAge)
        {
            if (age >= minAge)
            {
                EnjoyTheShow();
            } else
            {
                TooYoung();
            }
        }
        static void EnjoyTheShow()
        {
            Console.WriteLine("Access granted - enjoy the show");
        }
        static void TooYoung()
        {
            Console.WriteLine("Access denied - you are too young");
        }
    }
}
