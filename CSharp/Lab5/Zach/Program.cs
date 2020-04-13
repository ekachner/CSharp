using System;

namespace ZachArrayLab
{
    class Program
    {
        static void Main(string[] args)
        {
            string anotherCustomer = "Y";

            string[] filmNames = new string[5];


            for (int i = 0; i < filmNames.Length; i++)

            {
                var displayNumber = i + 1;
                Console.Write("Enter the name of film number " + displayNumber + ": ");


                filmNames[i] = Console.ReadLine();
            }
            WelcomeMessage(filmNames);

            while (anotherCustomer == "Y")
            {
                int filmNo = FilmSelect();
                if (filmNo >= 0 && filmNo <= 4)
                {
                    var filmName = filmNames[filmNo];
                    var filmAge = AgeCheck(filmName);
                    ValidAge(filmAge);
                }
                else //(filmNo < 0 || filmNo > 4)
                {
                    Console.WriteLine("Invalid Film number. Please select from films listed.");
                }
                Console.WriteLine("Another Customer? (Y or N):");
                anotherCustomer = Console.ReadLine();
            }


        }

        // method for film age requirements
        static int AgeCheck(string filmName)
        {
            var movieAge = 0;
            filmName = filmName.Trim();
            if (filmName.EndsWith("(15)"))
            {
                movieAge = 15;
            }
            if (filmName.EndsWith("(12A)") || filmName.EndsWith("(12a)"))
            {
                movieAge = 12;
            }

            if (filmName.EndsWith("(18)"))
            {
                movieAge = 18;
            }
            if (filmName.EndsWith("(U)") || filmName.EndsWith("(u)"))
            {
                movieAge = 5;
            }
            return movieAge;

        }

        // method for displaying film names and numbers
        static void WelcomeMessage(string[] filmNames)
        {
            Console.WriteLine("Welcome to our Multiplex!");
            int filmNo = 1;
            Console.WriteLine("We are currently showing:");
            foreach (string film in filmNames)
            {
                Console.WriteLine(filmNo + " " + film);
                filmNo++;
            }
        }

        // method for customer to put in film number
        static int FilmSelect()
        {

            string filmInput;
            Console.WriteLine("Enter the number of the film you want to see: ");
            filmInput = Console.ReadLine();
            if (int.TryParse(filmInput, out int input))
            {
                
                return input - 1;
            }
            else
            {
                Console.WriteLine("Please enter correct number of film you want to see.");
                FilmSelect();
                return 0;
            }
        }


        // method for validateRating

        static bool ValidateRating(string filmNames)
        {
            bool filmEntryisValid = false;
            string trimmedFilmName = filmNames.Trim();
            if (

                trimmedFilmName.EndsWith("(15)") ||
                trimmedFilmName.EndsWith("(12A)") ||
                trimmedFilmName.EndsWith("(12a)") ||
                trimmedFilmName.EndsWith("(18)") ||
                trimmedFilmName.EndsWith("(U)") ||
                trimmedFilmName.EndsWith("(u)")
               )
            {
                filmEntryisValid = true;
            }
            return filmEntryisValid;
        }

        static void ValidAge(int age)
        {
            string ageInput;
            int custAge;
            int low = 5;
            int high = 120;
            Console.WriteLine("Enter your age: ");
            ageInput = Console.ReadLine();

            bool canReadInput = int.TryParse(ageInput, out custAge);



            if (canReadInput) // did read input from user
            {
                if (custAge >= low && custAge <= high)  // is user input "valid" in the range
                {
                    if (custAge >= age)
                    {
                        Console.WriteLine("Enjoy the Show!");
                    }
                    else if (custAge < age)
                    {
                        Console.WriteLine("You must be at least " + age + " to see this film.");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a value in the range " + low + " to " + high);
                }
            }
            else
            {
                Console.WriteLine("Age input is invalid! Try again.");

            }




        }

        static int readFilmNumber()
        {
            int num;
            do
            {
                Console.WriteLine("Choose Film Number.");
                num = int.Parse(Console.ReadLine());
                num -= 1;
            } while (num < 0 && num > 4);
            return num;
        }

        int filmNumber = readFilmNumber();

    }
}
