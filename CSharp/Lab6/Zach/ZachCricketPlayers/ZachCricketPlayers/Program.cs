using System;

namespace ZachCricketPlayers
{
    class Program
    {

        struct Player {
            public string Name;
            public int Score;
        }
        static void Main(string[] args)
        {
            
            Player[] team = new Player[11];

          
            for (int i = 0; i < team.Length; i++)
            {
                
                var playerNumber = i + 1;
                Console.WriteLine("Enter the name of player " + playerNumber + ": ");
                team[i].Name = Console.ReadLine();

                Console.WriteLine("Enter the score of player " + playerNumber + ": ");

                team[i].Score = ScoreLimit();

            }

            SortPlayers(team);  // calls the method that sorts players
            OutputTeam(team);   // calls the method that will output everything the user inputs
        }

        static void OutputTeam(Player[] team)
        {
            int sum = 0;
            
            foreach (Player p in team)
            {
                Console.WriteLine("Name: " + p.Name);
                Console.WriteLine("Score: " + p.Score);
                sum += p.Score;
            }
                      
            int average = sum / team.Length;
            Console.WriteLine("The average score is: " + average);
           
        }

        static int ScoreLimit()
        {
            
            int low = 0;
            int high = 500;

            if (int.TryParse(Console.ReadLine(), out var scoreInput))
            {
                if (scoreInput >= 0 && scoreInput <= 500)
                {
                    return scoreInput;
                } else
                {
                    Console.WriteLine("Please enter score in the range of " + low + " to " + high);
                    ScoreLimit();
                }
            } else
            {
                Console.WriteLine("Please enter score in the range of " + low + " to " + high);
                ScoreLimit();
            }

            return 0;  // should never return 0 because it will run until the right answer comes in
           
        }

        static void SortPlayers(Player[] team)
        {
            bool sortedTeam;

            do
            {
                sortedTeam = false;
                for (int i = 0; i < team.Length - 1; i++)  // array we are working with
                {
                    if (team[i].Score < team[i + 1].Score)  // sorts the team from high score to low
                    {
                        
                        Player temp = team[i];
                        team[i] = team[i + 1];
                        team[i + 1] = temp;
                        sortedTeam = true;
                    }
                }
            } while (sortedTeam);
        }
    }
}
