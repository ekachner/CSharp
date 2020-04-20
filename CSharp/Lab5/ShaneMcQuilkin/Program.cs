using System;

namespace CinemaEntry //lab 4 / lab 5
{
    class Program
    {
        
        
        static int ReadAge(int low,
            int high,
            string prompt)
        {
            int result = 0;
            do
            {
                Console.WriteLine(prompt);
                string resultString = Console.ReadLine();
                result = int.Parse(resultString);

            } while ((result < low) || (result > high));
            return result;

        }
        static int ReadFilmNo(int low,
        int high,
        string prompt)
        {
            int result = 0;
               do
            {
                Console.WriteLine(prompt);
                string resultString = Console.ReadLine();
                result = int.Parse(resultString);

            } while ((result < low) || (result > high));
           return result;
        }
        static int ReadNumber(int low,
        int high,
        string prompt)
        {
            int result = 0;
            do
            {
                Console.WriteLine(prompt);
                string numberString = Console.ReadLine();
                result = int.Parse(numberString);
                if ((result < low) || (result > high))
                    Console.WriteLine("Please enter a value in the range " + low + " to " + high);


            } while (result < low || result > high);
            return result;
        }
        static bool filmNameIsValid(string filmName)
        {
            var trimmed = filmName.Trim();
            return trimmed.EndsWith("(15)") ||
                trimmed.EndsWith("(U)") ||
                trimmed.EndsWith("(12)") ||
                trimmed.EndsWith("(18)") ||
                trimmed.EndsWith("(12a)");
           
        }
        
        static void Main(string[] args)
        {
            string[] filmNames = new string[5];
            //var filmNo = filmNo1;
            for (int i = 0; i < filmNames.Length; i++) 
            {
                string filmName;
                do
                {
                    int displayNumber = i + 1;
                    Console.Write("Enter the name of the film number" + displayNumber + ": ");
                    filmName = Console.ReadLine();
                    if (filmNameIsValid(filmName))
                    {
                        filmNames[i] = filmName;
                    }
                    else
                    {
                        Console.WriteLine("Please, Enter a valid film name.");
                    }
                } while (filmNameIsValid(filmName) == false);
                
            }
            
            string doWeGoRoundAgain;
            do
            {
                
                

                Console.WriteLine("Welcome to our multiplex.");
                Console.WriteLine("We are presently showing.");
                for (int i = 0; i < filmNames.Length; i++) 
                {
                    Console.WriteLine($"{i + 1}. {filmNames[i]}");
                }
                //Console.WriteLine("1, Rush");
                //Console.WriteLine("2. How I Live Now");
                //Console.WriteLine("3. Thor: Dark World");
                //Console.WriteLine("4. Filth");
                //Console.WriteLine("5. Planes");
                //Console.WriteLine("Please select the movie that you would like to see?");
                //int filmNumber: must be between 1 and 5
                //int age = Convert.ToInt32(Console.ReadLine());

                const int MAX_FILMNO = 5;
                const int MIN_FILMNO = 1;
                int filmNo = ReadFilmNo(MIN_FILMNO, MAX_FILMNO, "Please select the movie that you would like to see?: ");
                
                const int MAX_AGE = 120;
                const int MIN_AGE = 5;
                int age = ReadNumber(MIN_AGE, MAX_AGE, "Please, Enter your age: ");
                Console.WriteLine(age);
                

                switch (filmNo)

                {
                    case 1:
                        //Console.WriteLine("Please, Enter your age: ");
                        if (age >= 15)
                        {
                            Console.WriteLine("Please enjoy the movie");
                        }
                        else
                        {
                            Console.WriteLine("You are not old enough to watch this movie.");
                        }
                        break;

                    case 2:

                        if (age >= 15)
                        {
                            Console.WriteLine("Please, Enjoy the movie");
                        }
                        else
                        {
                            Console.WriteLine("You are not old enough to watch this film.");
                        }
                        break;

                    case 3:

                        if (age >= 12)
                        {
                            Console.WriteLine("Please, enjoy the movie.");
                        }
                        else
                        {
                            Console.WriteLine("you are not old enough to watch this film");
                        }
                        break;

                    case 4:

                        if (age >= 18)
                        {

                            Console.WriteLine("Please, enjoy the movie.");
                        }
                        else
                        {
                            Console.WriteLine("You are not old enough to watch this film.");
                        }
                        break;

                    case 5:

                        if (age >= 5)
                        {
                            Console.WriteLine("Please, enjoy the movie");
                        }
                        else
                        {
                            Console.WriteLine("You are not old enough to watch this film.");
                        }
                        break;

                }
                
                Console.Write("Another customer? (Y or N): ");
                doWeGoRoundAgain = Console.ReadLine();
                Console.WriteLine("Please press enter to exit; ");
                Console.ReadLine();
                

            } while (doWeGoRoundAgain == "Y");
        }
        
    }
}
        
