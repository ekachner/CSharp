using System;

namespace CinemaEntryArray
{
    class Program
    {
        static void Main(string[] args)
        {
            char filmVerification = 'N';

            do
            {
                FilmEntry();
            } while (filmVerification == 'N');


        }

        static void FilmEntry(char filmVerification = 'N')
        {

            string[] filmNames = new string[5];
            string[] age = new string[5];

            for (int i = 0; i < 5; i = i + 1)
            {
                int displayNum = i + 1;
                Console.Write("Enter the name of film " + displayNum + ": ");
                filmNames[i] = Console.ReadLine();
            }
            Console.WriteLine("The movies you've submitted are as follows:");

            for (int i = 0; i < 5; i = i + 1)
            {
                int displayNum = i + 1;
                Console.WriteLine(displayNum + ". " + filmNames[i]);
            }

            for (int i = 0; i < 5; i = i + 1)
            {
                int displayNum = i + 1;
                Console.Write("Enter the age rating for film " + displayNum + ". The ratings are U, 12A, 15, and 18. ");
                age[i] = Console.ReadLine();

                if (age[i] == "U" || age[i] == "12A" || age[i] == "15" || age[i] == "18")
                {

                }
                else
                {
                    Console.WriteLine("Invalid age input! The ratings are U, 12A, 15, and 18.");
                    age[i] = Console.ReadLine();
                }
            }

            Console.WriteLine("The movies and specified ages are as follows: ");

            for (int i = 0; i < 5; i = i + 1)
            {
                int displayNum = i + 1;
                Console.WriteLine(displayNum + ". " + filmNames[i] + " (" + age[i] + ")");
            }

            Console.WriteLine("Are the following correct? Proceed to the purchace screen? Y/N");
            filmVerification = char.ToUpper(Console.ReadLine()[0]);

            if (filmVerification == 'Y')
            {
                Console.WriteLine("Thank you for verifying!");
                Multiplex();
            }
        }

        static void Multiplex(string[] filmNames, string[] age)
        {

            Console.WriteLine("Welcome to the Multiplex!");
            Console.WriteLine("We are currently showing:");

            for (int i = 0; i < 5; i = i + 1)
            {
                int displayNum = i + 1;
                Console.WriteLine(displayNum + ". " + filmNames[i] + " (" + age[i] + ")");
            }

            Console.WriteLine("Enter the number of the film you wish to see:");

            string filmInput = Console.ReadLine();
            int filmNo = int.Parse(filmInput);

            if (filmNo < 1 || filmNo > 5)
            {
                Console.WriteLine("Invalid movie number!");
                Console.WriteLine("Enter the number of the film you want to see:");
                filmInput = Console.ReadLine();

                Console.WriteLine("Please enter your age:");
                string ageInput = Console.ReadLine();
                int ageIn = int.Parse(ageInput);

                if (ageIn < 5 || ageIn > 110)
                {
                    Console.WriteLine("Invalid Age!");
                    Console.WriteLine("Please enter your age:");
                    ageInput = Console.ReadLine();
                }

                string filmAge = age[filmNo];

                if (ageIn >= 5 && filmAge == "U")
                {
                    Console.WriteLine("Age approved! Enjoy your film!");
                }
                else if (ageIn >= 12 && filmAge == "12A")
                {
                    Console.WriteLine("Age approved! Enjoy your film!");
                }
                else if (ageIn >= 15 && filmAge == "15")
                {
                    Console.WriteLine("Age approved! Enjoy your film!");
                }
                else if (ageIn >= 18 && filmAge == "18")
                {
                    Console.WriteLine("Age approved! Enjoy your film!");
                }
                else
                {
                    Console.WriteLine("Access denied! You are too young to view this film!");
                    Console.WriteLine("Please enter your age:");
                    ageInput = Console.ReadLine();
                }
            }
        }
    }
}