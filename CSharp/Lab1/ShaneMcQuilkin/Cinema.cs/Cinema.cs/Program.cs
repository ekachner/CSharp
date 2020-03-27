using System;

namespace Cinema.cs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to our multiplex.");
            Console.WriteLine("We are presently showing.");

            Console.WriteLine("1. Rush");
            Console.WriteLine("2. How I Live Now");
            Console.WriteLine("3. Thor: Dark World");
            Console.WriteLine("4. Filth");
            Console.WriteLine("5. Planes");
            Console.WriteLine("Please select the movie that you would like to see?");
            int filmNumber = Convert.ToInt32(Console.ReadLine());
            
            //int age = Convert.ToInt32(Console.ReadLine());
            switch (filmNumber)
            {
                case 1:
                    Console.WriteLine("How old are you? ");
                    //int age = Convert.ToInt32(Console.ReadLine());
                    if (Convert.ToInt32(Console.ReadLine()) >= 15)
                    {
                        Console.WriteLine("Please enjoy the movie");
                    }
                    else
                    {
                        Console.WriteLine("You are not old enough to watch this movie.");
                    }
                    break;

                case 2:
                    Console.WriteLine("How old are you? ");
                       //age = Convert.ToInt32(Console.ReadLine());
                    if (Convert.ToInt32(Console.ReadLine() )>= 15)
                    {
                        Console.WriteLine("Please, Enjoy the movie");
                    }
                    else
                    {
                        Console.WriteLine("You arfe not old enough to watch this film.");
                    }
                    break;

                case 3:
                    Console.WriteLine("How old are you? ");
                    //int age = Convert.ToInt32(Console.ReadLine());
                    if (Convert.ToInt32(Console.ReadLine()) >= 12)
                    {
                        Console.WriteLine("Please, enjoy the movie. ");
                    }
                    else
                    {
                        Console.WriteLine("you are not old enough to watch this film");
                    }
                    break;

                case 4:
                    Console.WriteLine("You old are you? ");
                    //int age = Convert.ToInt32(Console.ReadLine());
                    if (Convert.ToInt32(Console.ReadLine()) >= 18)
                    {
                        Console.WriteLine("Please, enjoy the movie.");
                    }
                    else
                    {
                        Console.WriteLine("You are not old enough to watch this film.");
                    }
                    break;

                case 5:
                    Console.WriteLine("How old are you? " );
                    //int age = Convert.ToInt32(Console.ReadLine());
                    if (Convert.ToInt32(Console.ReadLine()) >= 5)
                    {
                        Console.WriteLine("Please, enjoy the movie");
                    }else
                    {
                        Console.WriteLine("You are not old enough to watch this film.");
                    }
                    break;
            }
        } 
        
    }
}
