using System;

namespace CinemaEntry
{
    class Program
    {
        //int age = 0;
        //int filmNumber = 0;

        static int ReadAge(string prompt, int min, int max)
        {
            int age = 0;

            do
            {
                Console.Write(prompt);
                string ageString = Console.ReadLine();
                age = int.Parse(ageString);
                if (age > max || age < min)
                {
                    Console.WriteLine("Please enter your age between " + min + " to " + max);
                } else
                {
                    break;
                }  
            } while (age > max || age < min);

            return age;
        }




        static int ReadFilmNumber(string prompt, int min, int max)
        {
            int filmNumber = 0;

            do
            {
                Console.Write(prompt);
                string numberString = Console.ReadLine();
                filmNumber = int.Parse(numberString);
                if (filmNumber > max || filmNumber < min)
                {
                    Console.WriteLine("Please enter your age between " + min + " to " + max);
                }
                else
                {
                    break;
                }
            } while (filmNumber > max || filmNumber < min);

            return filmNumber;
        }




        static void Main(string[] args)
        {
            int filmNumber = 0;
            int age = 0;
           
            filmNumber = ReadFilmNumber("Enter the corresponding film number wished to be viewed: ", 1, 6);
            Console.WriteLine("Film Number: " + filmNumber);

            age = ReadAge("Enter your age : ", 5, 120);
            Console.WriteLine("Age: " + age);
        }
    }
}




//using System;

//namespace erica_cinema.cs
//{
//    class Program
//    {


//        static void Main(string[] args)
//        {
//            Console.WriteLine("Welcome to Cineplex.\nWe are currently showing: ");
//            Console.WriteLine("1. Onward (PG)\n2. Bloodshot (PG13)\n3. The Way Back (R)\n" +
//                "4. The Call of the Wild (PG)\n5. Jumanji the Next Level (PG13)\n6. 1917 (R)\n");


//            int number = 0;
//            int age = 0;
//            string roundAbout;

//            do
//            {   //  loop for another customer



//                do
//                {       //ask for film number and keep asking till acceptable film input is given
//                    try
//                    {
//                        Console.Write("Enter the corresponding film number wished to be viewed: ");
//                        string filmNumber = Console.ReadLine();
//                        number = int.Parse(filmNumber);
//                    }
//                    catch (Exception e)
//                    {
//                        Console.WriteLine("Error: " + e.Message);
//                    }


//                    if (number < 1 || number > 6)
//                    {
//                        Console.WriteLine("Invalid film entry");
//                    }

//                } while (number < 1 || number > 6);



//                do
//                {       //ask for age and keep asking till a numeric value is given

//                    try
//                    {
//                        Console.Write("Enter your age: ");
//                        string ageText = Console.ReadLine();
//                        age = int.Parse(ageText);
//                    }
//                    catch (Exception e)
//                    {
//                        Console.WriteLine("Error: " + e.Message);
//                    }
//                    finally
//                    {
//                        if (age < 5 || age > 120)
//                        {
//                            Console.WriteLine("The age you submitted is either too young or too old, " +
//                                "are you certain of the age value? Please try again.");
//                        }
//                    }
//                } while (age < 5 || age > 120);




//                if (number == 1 || number == 4)
//                {
//                    Console.WriteLine("Enjoy the film!");
//                }



//                if (number == 2 || number == 5)
//                {
//                    if (age >= 13)
//                    {
//                        Console.WriteLine("Enjoy the film!");
//                    }
//                    else
//                    {
//                        Console.WriteLine("Access denied - You are too young to view this film.");
//                    }

//                }



//                if (number == 3 || number == 6)
//                {
//                    if (age >= 18)
//                    {
//                        Console.WriteLine("Enjoy the film!");
//                    }
//                    else
//                    {
//                        Console.WriteLine("Access denied - You are too young to view this film.");
//                    }

//                }


//                Console.Write("Would you like to add another person to your party? If yes enter \"Y\": ");
//                roundAbout = Console.ReadLine();

//            } while (roundAbout.ToUpper() == "Y");  //if input is "Y" then program will run again if not then program executes


//            Console.WriteLine("Thank you for choosing Cineplex to enjoy all your box office hits.");

//        }

//    }
//}









//using System;
//class MethodLibraries
//{
//    static string readString(string prompt)
//    {
//        string result;
//        do
//        {
//            Console.Write(prompt);
//            result = Console.ReadLine();
//        } while (result == "");
//        return result;
//    }

//    static int readInt(string prompt, int low, int high)
//    {
//        int result;
//        do
//        {
//            string intString = readString(prompt);
//            result = int.Parse(intString);
//        } while ((result < low) || (result > high));
//        return result;
//    }

//    public static void Main()
//    {
//        string name;
//        name = readString("Enter your name : ");
//        Console.WriteLine("Name: " + name);
//        int age;
//        age = readInt("Enter your age : ", 0, 100);
//        Console.WriteLine("Age: " + age);
//    }
//}


//static void readPerson(out string name, out int age)
//{
//    name = readString("Enter your name : "); age = readInt("Enter your age : ", 0, 100);
//    OR
//    string name;
//    int age;
//    readPerson(out name, out age);
//}



//static double readValue(
//    string prompt, // prompt for the user
//    double low,    // lowest allowed value
//    double high    // highest allowed value
//    )
//{
//    double result = 0; do
//    {
//        Console.WriteLine(prompt + " between " + low +
//        " and " + high);
//        string resultString = Console.ReadLine(); result = double.Parse(resultString);
//    } while ((result < low) || (result > high));
//    return result;
//}





//static string readString(string prompt)
//{
//}
//string result;
//do
//{
//Console.Write(prompt ) ;
//result = Console.ReadLine(); } while (result == "" ) ;
//return result ;
//static int readInt(string prompt, int low, int high)
//{
//    int result;
//    do
//    {
//        string intString = readString(prompt);
//        result = int.Parse(intString);
//    } while ((result < low) || (result > high));
//    return result;
//}

//string name;
//name = readString( "Enter your name : " );
//int age;
//age = readInt( "Enter your age : ", 0, 100);




