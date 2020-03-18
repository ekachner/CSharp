using System;

namespace Cinema2
{
    class Program
    {
        static void Main(string[] args)
        {

            bool anotherCustomer;
            do
            {
                Welcome();
                EnterAge(EnterFilmNo());
                anotherCustomer = AnotherCustomer();



            } while (anotherCustomer);

        }

        static bool AnotherCustomer()
        {
            string anotherCustomerInput;
            Console.WriteLine("Another customer? Y or N");

            anotherCustomerInput = Console.ReadLine();
            if (anotherCustomerInput.StartsWith('Y') || anotherCustomerInput.StartsWith('y'))
            {
                return true;
            }
            else if (anotherCustomerInput.StartsWith('N') || anotherCustomerInput.StartsWith('n'))
            {
                return false;
            }
            else
            {
                Console.WriteLine("Invalid input. Answer must begin with Y or N");
                return AnotherCustomer();
            }
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
            Console.Write("Enter the number of the film you wish to see: ");
            int filmNumber;
            string filmInput = Console.ReadLine();
            bool result = int.TryParse(filmInput, out filmNumber);
            if (result == true && filmNumber <= 5 && filmNumber > 0)
            {
                return filmNumber;


            }
            else
            {
                Console.WriteLine("That film number is invalid.");
                filmNumber = EnterFilmNo();
                return filmNumber;
            }

        }

        static void EnterAge(int filmNo)
        {
            Console.Write("Enter your age: ");
            int age;
            string ageMessage = "Invalid age! Please input an integer between 5 - 120";
            string ageInput = Console.ReadLine();
            bool result = int.TryParse(ageInput, out age);

            if (result == false || age < 5 || age > 120)
            {
                Console.WriteLine(ageMessage);
                EnterAge(filmNo);
                return;
            }

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
            }
            else
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
