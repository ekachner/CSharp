using System;

namespace CricketPlayerScores
{
    class Program
    {


        public static void Main(string[] args)
        {
            string[] players = new[] { "Ricky", "Allan", "Bobby", "Dillon", "Trevor", "Bryce", "Donovan", "Asher", "Marvin", "Tommy", "Billy" };
            int[] scores = new int[11];


            EnterScore(0, 500, players, scores);

            PrintPlayers(players, scores);


            //ChooseBetween("How do you wish to sort your list? By the name of player or by their score (Enter: N or S): ", "N", "S");
        }




        static int[] EnterScore(int min, int max, string[] players, int[] scores)
        {
            int result;            

            for(int i = 0; i < players.Length; i++)
            {                
                result = ReadInteger($"Please enter a score for player {players[i]}", min, max);
                scores[i] = result;
                Console.WriteLine($"Player {players[i]} scored: {scores[i]}");                
            }
            return scores;
        }



        static void PrintPlayers(string[] players, int[] scores)
        {
            for (int i = 0; i < players.Length; i++)
            {                
                    Console.WriteLine($"Player {i + 1}: " + players[i] + "\nScore: " + scores[i] + "\n");                
            }
        }



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
            int result = min - 1;
            do
            {
                try
                {
                    string intString = ReadString(prompt);
                    result = int.Parse(intString);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + (e.Message) + $" Please enter a valid number between {min} and {max}");
                }
            } while ((result < min) || (result > max));
            return result;
        }

        

        static string ChooseBetween(string prompt, string option1, string option2)
        {
            do
            {
                Console.Write(prompt);
                string input = Console.ReadLine().ToUpper().Trim();
                if (input == option1 || input == option2)
                {
                    return input;
                }
                else
                {
                    Console.WriteLine($"Error: Please select {option1} or {option2}");
                }
            } while (true);
        }



    }
}






//* Create 11 players -  Array[name, score]
//two separate arrays. Use index value to link score to player?



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



