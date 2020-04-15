using System;

namespace CricketPlayerScores
{
    class Program
    {
        string[] players = new string[11]; /*{ Ricky, Allan, Bobby, Dillon, Trevor, Bryce, Donovan, Asher, Marvin, Tommy, Billy };*/
        int[] scores = new int[11];

        static string ReadString(string prompt)
        {
            string result;
            do
            {
                Console.Write(prompt);
                result = Console.ReadLine();
            } while (result == "");
            return result;
        }

        static int ReadInteger(string prompt, int min, int max)
        {
            int result;
            do
            {
                string intString = ReadString(prompt);
                result = int.Parse(intString);
            } while ((result < min) || (result > max));
            return result;
        }

        


        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}








//* Create 11 players -  Array[name, score]

//* Input Score(prompt = enter score for batsmen name, min = 0 or “duck”, max = 500).  Anything outside this must be rejected

//* Average Score  = total innings score / 11 


//* Create a structure to store the score information about each player (refer to SharePoint lecture to store scores in each element of the array.) 

//* Print cricket scores in order from largest to smallest (Bubble Sort)

//* Then create method to sort by names of players. 
//(Use CompareTo method). 
//string a = “Fred”;
//string b = “Jim”;
//if(a.CompareTo(b) < 0)
//{
//    Console.WriteLine($“{ a} is before { b }”);
//}
//else
//{
//    Console.WriteLine($”{ b} is before { a }”);
//}


//* Create prompt that asks if you want to sort by name or by scores.
//(Do you want to sort by name or by score? (Enter N or S): )
