using System;

namespace HyperspaceCheeseBattle
{
    class Program
    {
        



        static void Main(string[] args)
        {
            Player[] test = ResetGame();

            PlayerTurn(test);
            
        }


        // 2D array that holds the board and mirrored across the X axis to flip the Y values.
        static int[,] board = new int[,]
        {
            {1,1,1,1,1,1,1,1}, //row 0
            {2,2,1,0,1,1,3,3}, //row 1
            {2,2,1,2,3,2,3,3}, //row 2
            {2,2,1,2,1,1,3,3}, //row 3
            {2,2,2,2,1,1,3,3}, //row 4
            {2,2,2,2,1,1,3,3}, //row 5
            {2,2,1,0,1,2,3,3}, //row 6
            {0,2,2,2,2,2,0,0}, //row 7
        };

        

        private enum Direction
        {
            Down = 0,
            Up = 1,
            Right = 2,
            Left = 3,
        }



        struct Player
        {
            public string Name;
            public int PositionX;
            public int PositionY;
        }


        // reads in the player information for a new game
        static Player[] ResetGame()
        {
            int numberOfPlayers = ReadInteger("How many players are there?: ", 2, 4);

            // 1D array that holds the player information
            Player[] players = new Player[numberOfPlayers];

            Console.WriteLine($"You have selected {players.Length} players");

            for (int i = 0; i < players.Length; i++)
            {
                players[i] = new Player
                {
                    Name = $"Player{i + 1}",
                    PositionX = 0,
                    PositionY = 0
                };

                Console.WriteLine($"{players[i].Name}");
            }
            return players;            
        }


        // returns the value of the next dice throw
        static int RollDice()
        {
            Random random = new Random();
            int roll = random.Next(1, 7);            
            return roll;

            //return 1;
        }


        // makes a move for the player given in playerNo
        private static void PlayerTurn(Player[] players)
        {
            for (int i = 0; i < players.Length; i++)
            {
                Console.WriteLine($"It's {players[i].Name}'s turn");
                int rollValue = RollDice();
                Console.WriteLine($"{players[i].Name} rolled {rollValue}");

                //if(RocketInSquare(players[i].PositionX, players[i].PositionY) == true)
                //{
                //    //do something
                //}

                if (players[i].PositionX + rollValue < 7 || players[i].PositionX - rollValue > 0 || players[i].PositionY + rollValue < 7 || players[i].PositionY - rollValue > 0)
                {
                    switch (board[players[i].PositionX, players[i].PositionY])
                    {
                        case 0:
                            players[i].PositionY = MoveDown(rollValue, players[i].PositionY);
                            break;

                        case 1:
                            players[i].PositionY = MoveUp(rollValue, players[i].PositionY);
                            break;

                        case 2:
                            players[i].PositionX = MoveRight(rollValue, players[i].PositionX);
                            break;

                        case 3:
                            players[i].PositionX = MoveLeft(rollValue, players[i].PositionX);
                            break;                        
                    }
                }
            Console.WriteLine($"Player{i + 1} has landed on boardsquare ({players[i].PositionX}, {players[i].PositionY}).\n");
            }
        }


        //// returns true if there is a rocket in the specified square
        //static bool RocketInSquare(Player[] players)
        //{
        //    for (int i = 0; i < players.Length; i++)
        //    {
        //        if ((board[players[i].PositionX, players[i].PositionY]) == OCCUPIED)  
        //        {
        //            return true;
        //        }
        //    }
        //    
        //}












        public static int ReadInteger(string prompt, int min, int max)
        {
            int result = min - 1;
            do
            {
                try
                {
                    string intString = ReadString(prompt);
                    result = int.Parse(intString);
                    if (result < min || result > max)
                    {
                        Console.WriteLine($"\nPlease list a value between {min} and {max}. ");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + (e.Message) + $" Please enter a valid number between {min} and {max}");
                }
            } while ((result < min) || (result > max));
            return result;
        }

        public static string ReadString(string prompt)
        {
            string result;
            do
            {
                Console.Write(prompt);
                result = Console.ReadLine();
            } while (result == "");
            return result;
        }

        static int MoveDown(int rollValue, int PositionY)
        {
            PositionY -= rollValue;
            return PositionY;
        }

        static int MoveUp(int rollValue, int PositionY)
        {
            PositionY += rollValue;
            return PositionY;
        }

        static int MoveLeft(int rollValue, int PositionX)
        {
            PositionX -= rollValue;
            return PositionX;
        }

        static int MoveRight(int rollValue, int PositionX)
        {
            PositionX += rollValue;
            return PositionX;
        }

        //// returns true if there is cheese in the specified square
        //static bool CheeseInSquare(int X, int Y)
        //{
        //    return ((X == 0 && Y == 3) || (X == 3 && Y == 5) || (X == 4 && Y == 1) || (X == 6 && Y == 4));
        //}
    }
}

