using System;

namespace CricketPlayerScores
{
    class Program
    {


        public static void Main(string[] args)
        {
            Player[] players = new Player[3];
            

            EnterTeamStats(players);

            string sortOption = ChooseBetween("How do you wish to sort your list? By the names of the players or by their scores (Enter: N or S): ", "N", "S");


            
            PrintPlayers(players, sortOption);



        }




        



        struct Player
        {
            public string Name;
            public int Score;
        }


        static void EnterTeamStats(Player[] players)
        {
            for (int i = 0; i < players.Length; i++)
            {
                string name = EnterPlayerName();
                int score = EnterScore(0, 500);
                players[i] = new Player { Name = name, Score = score };
            }
        }



        static string EnterPlayerName()
        {
            string name = ReadString("Please enter a player's name: ");
            return name;
        }


        static string ReadString(string prompt)
        {
            string result;
            do
            {
                Console.Write(prompt);
                result = Console.ReadLine();
                if(result == "")
                {
                    Console.WriteLine("Please enter the player's name: ");
                }
            } while (result == "");
            return result;
        }



        static int EnterScore(int min, int max)
        {

            int score = ReadInteger($"Please enter his score: ", min, max);
            return score;
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
                    if(result < min || result > max)
                    {
                        Console.WriteLine($"Please list a score between {min} and {max}");
                    }
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



        static void PrintPlayers(Player[] players, string chooseBetweenOption)
        {
            if(chooseBetweenOption == "N")
            {
                SortByName(players);

                for (int i = 0; i < players.Length; i++)
                {
                    Console.WriteLine($"{players[i].Name} scored {players[i].Score} points.");
                }
            }

            if(chooseBetweenOption == "S")
            {
                SortByScores(players);

                for (int i = 0; i < players.Length; i++)
                {
                    Console.WriteLine($"{players[i].Name} scored {players[i].Score} points.");
                }
            }

            //foreach(Player p in players)
            //{
            //    Console.WriteLine($"{p.Name} scored {p.Score} points");
            //}
        }







        //static int[] EnterScore(int min, int max, string[] players, int[] scores)
        //{
        //    int result;

        //    for (int i = 0; i < players.Length; i++)
        //    {
        //        result = ReadInteger($"Please enter a score for player {players[i]}", min, max);
        //        scores[i] = result;
        //        Console.WriteLine($"Player {players[i]} scored: {scores[i]}");
        //    }
        //    return scores;
        //}


        //static void PrintPlayers(string[] players, int[] scores)
        //{
        //    for (int i = 0; i < players.Length; i++)
        //    {                
        //            Console.WriteLine($"Player {i + 1}: " + players[i] + "\nScore: " + scores[i] + "\n");                
        //    }
        //}


        



        //BUBBLE SWAP: sorts scores highest to lowest
        static void SortByScores(Player[] players)
        {
            bool doneSwapping;

            do
            {
                doneSwapping = false;
                for (int i = 0; i < players.Length - 1; i++)
                {
                    if (players[i].Score < players[i + 1].Score)
                    {
                        Player temp = players[i];
                        players[i] = players[i + 1];
                        players[i + 1] = temp;
                        doneSwapping = true;
                    }
                }
            } while (doneSwapping);
        }





        static void SortByName(Player[] players)
        {
            bool doneSwapping;
            do
            {
                doneSwapping = false;
                for (int i = 0; i < players.Length - 1; i++)
                {
                    if (players[i].Name.CompareTo(players[i + 1].Name) > 0)
                    {
                        Player temp = players[i];
                        players[i] = players[i + 1];
                        players[i + 1] = temp;
                        doneSwapping = true;
                    }
                }
            } while (doneSwapping);
        }


        //        //* Then create method to sort by names of players. 
        //        //(Use CompareTo method). 
        //        string a = “Fred”;
        //        string b = “Jim”;
        //        if(a.CompareTo(b) < 0)
        //        {
        //            Console.WriteLine($“{ a} is before { b}”);
        //        }
        //        else
        //        {
        //            Console.WriteLine($”{ b} is before { a }”);
        //        }

    }
}






//* Create 11 players -  Array[name, score]
//two separate arrays. Use index value to link score to player?



//* Input Score(prompt = enter score for batsmen name, min = 0 or “duck”, max = 500).  Anything outside this must be rejected

//* Average Score  = total innings score / 11 


//* Create a structure to store the score information about each player (refer to SharePoint lecture to store scores in each element of the array.) 

//* Print cricket scores in order from largest to smallest (Bubble Sort)




