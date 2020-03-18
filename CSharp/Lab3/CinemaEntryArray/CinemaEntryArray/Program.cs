using System;

namespace CinemaEntryArray
{
    class Program
    {
        static void Main(string[] args)
        {
            bool anotherCustomer;
           

           
            string[] films = EnterFilms(HowManyFilms());

            do
            {
                PickAFilm(Welcome(films));
                anotherCustomer = AnotherCustomerPrompt();
            } while (anotherCustomer);


           
            
        }

        static int HowManyFilms()
        {
            int numberOfFilmsShown;


            Console.WriteLine("How many films are currently being shown?");

            string numberOfFilmsInput = Console.ReadLine();
            bool isValidNumber = int.TryParse(numberOfFilmsInput, out numberOfFilmsShown);
            if (isValidNumber && (numberOfFilmsShown > 0))
            {
                return numberOfFilmsShown;
            }
            else
            {
                Console.WriteLine("Input invalid! Try again.");
                return HowManyFilms();
            }
        }


        static bool AnotherCustomerPrompt()
        {
            bool thereIsAnotherCustomer;

            Console.WriteLine("Is there another customer?");
            string anotherCustomerInput = Console.ReadLine();
            if (anotherCustomerInput.StartsWith("Y") || anotherCustomerInput.StartsWith("y"))
            {
                thereIsAnotherCustomer = true;
            } else if (anotherCustomerInput.StartsWith("N") || anotherCustomerInput.StartsWith("n"))
            {
                thereIsAnotherCustomer = false;
            } else
            {
                Console.WriteLine("Input invalid. Please answer with either Y or N.");
                return AnotherCustomerPrompt();
            }



            return thereIsAnotherCustomer;

        }
        static string[] EnterFilms(int numberOfFilms)
        {
           
            string[] filmNames = new string[numberOfFilms];



            for (int i = 0; i < numberOfFilms; i++)
            {
                int displayNumber = i + 1;
                bool filmNameIsValid;
                Console.Write("Enter the name of film number " + displayNumber + ", including the age restriction in parentheses: ");
                string enteredFilmName = Console.ReadLine();
                filmNameIsValid = ValidateFilmName(enteredFilmName);

                if (filmNameIsValid)
                {
                    filmNames[i] = enteredFilmName;
                } else
                {
                    Console.WriteLine("Invalid film name format");
                    Console.WriteLine("<moviename> (<age restriction>)");
                    Console.WriteLine("Include age restriction in parentheses like so: ");
                    Console.WriteLine("Rush (15)");
                    i--;

                }
                

            }

            return filmNames;
        }

        static bool ValidateFilmName(string filmName)
        {
            bool filmNameIsValid = false;
            string trimmedFilmName = filmName.Trim();

            if (
                trimmedFilmName.EndsWith("(15)") ||
                trimmedFilmName.EndsWith("(12A)") ||
                trimmedFilmName.EndsWith("(12a)") ||
                trimmedFilmName.EndsWith("(18)") ||
                trimmedFilmName.EndsWith("(U)") ||
                trimmedFilmName.EndsWith("(u)")
                )
            {
                filmNameIsValid = true;
            }


            return filmNameIsValid;

        }

        static string[] Welcome(string[] filmNames)
        {
            Console.WriteLine("Welcome to our Multiplex");
            Console.WriteLine("We are currently showing:");

            for (int i = 0; i < filmNames.Length; i++)
            {
                int filmNumber = i + 1;
                Console.WriteLine("\t " + filmNumber + " " + filmNames[i]);
            }

            return filmNames;

        }

        static void PickAFilm(string[] filmNames)
        {
            int chosenFilm;
            string filmInput;
            Console.WriteLine("Enter the number of the film you wish to see: ");
            filmInput = Console.ReadLine();
            bool inputIsValid = int.TryParse(filmInput, out chosenFilm);

            if (inputIsValid && ((chosenFilm <= filmNames.Length) && (chosenFilm > 0)))
            {
                string filmString = filmNames[chosenFilm - 1].Trim();
                if (filmString.EndsWith("(15)"))
                {
                    CheckAge(15);
                } else if (filmString.EndsWith("(12A)"))
                {
                    CheckAge(12);
                } else if (filmString.EndsWith("(18)"))
                {
                    CheckAge(18);
                } else if (filmString.EndsWith("(U)"))
                {
                    CheckAge(5);
                } else
                {
                    Console.WriteLine("Invalid movie entry. Please contact Multiplex if this continues happening.");
                }
                    
            } else
            {
                Console.WriteLine("Input invalid!");
                PickAFilm(filmNames);
            }


        }
        static void CheckAge(int age)
        {
            string ageInput;
            int actualAge;
            Console.WriteLine("Please enter your age: ");
            ageInput = Console.ReadLine();

            bool ageIsValid = int.TryParse(ageInput, out actualAge);
            if (ageIsValid)
            {
                if (actualAge >= age)
                {
                    Console.WriteLine("Enjoy the show!");
                } else if (actualAge < age)
                {
                    Console.WriteLine("Sorry! You must be at least " + age + " to see this film.");
                }
            } else
            {
                Console.WriteLine("Age input invalid!");
                CheckAge(age);

            }
        }
    }
}
