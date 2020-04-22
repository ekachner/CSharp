using System;

namespace HyperspaceCheeseBattle
{
    class Program
    {
        
        static void Main(string[] args)
        {

            ResetGame();

            for(var i = 0; i < players.Length; i++)
            {
                players[i] = PlayerTurn(players[i]);
            }

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

        static Player[] players = new Player[NumberOfPlayers()];

        static int NumberOfPlayers()
        {
            int numberOfPlayers = ReadInteger("How many players are there?: ", 2, 4);
            return numberOfPlayers;
        }


        // reads in the player information for a new game
        static void ResetGame()
        {
            Console.WriteLine($"You have selected {players.Length} players");

            for (int i = 0; i < players.Length; i++)
            {
                //string name = EnterPlayerName();
                players[i] = new Player
                {
                    Name = $"Player{i + 1}",
                    PositionX = 0,
                    PositionY = 0
                };

                Console.WriteLine($"{players[i].Name}");
            }                       
        }


        static int RollDice()
        {
            //Random random = new Random();
            //int roll = random.Next(1, 7);
            //return roll;

            return 1;
        }


        // makes a move for the player given in playerNo
        private static Player PlayerTurn(Player p)
        {         
            Console.WriteLine($"\nIt's {p.Name}'s turn");
            int rollValue = RollDice();
            Console.WriteLine($"{p.Name} rolled {rollValue}");
            Direction direction = (Direction)board[p.PositionY, p.PositionX];

            int newX = p.PositionX;
            int newY = p.PositionY;

            string loseTurn = "Abandon move, this roll value will cause you to fall off the board.";

            if (direction == Direction.Up)
            {
                if(p.PositionY + rollValue <= 7)
                {
                    newY += rollValue;  //1
                }
                else
                {
                    Console.WriteLine(loseTurn);
                }
            }
            else if (direction == Direction.Down)
            {
                if(p.PositionY - rollValue >= 0)
                {
                    newY -= rollValue;
                }
                else
                {
                    Console.WriteLine(loseTurn);
                }
            }
            else if (direction == Direction.Right)
            {
                if(p.PositionX + rollValue <= 7)
                {
                    newX += rollValue;
                }
                else
                {
                    Console.WriteLine(loseTurn);
                }
            }
            else // left
            {
                if(p.PositionX - rollValue >= 0)
                {
                    newX -= rollValue;
                }
                else
                {
                    Console.WriteLine(loseTurn);
                }
            }

            Console.WriteLine($"New coordinates after rolling {rollValue} is ({newX}, {newY})");

                
            bool rocketInSquare = RocketInSquare(newX, newY);
           
            if (rocketInSquare == true)
            {
                do
                {                    
                    Console.WriteLine("in the while loop");

                    direction = (Direction)board[newY, newX];
                    Console.WriteLine($"direction in do while loop moves {direction} for coordinates: ({newX},{newY})" );

                    if (direction == Direction.Up)
                    {
                        newY += 1;
                    }
                    else if (direction == Direction.Down)
                    {
                        newY -= 1;
                    }
                    else if (direction == Direction.Right)
                    {
                        newX += 1;
                    }
                    else //left
                    {
                        newX -= 1;
                    }

                    Console.WriteLine($"New pending coordinates to test for ({newX},{newY})");   

                    rocketInSquare = RocketInSquare(newX, newY);

                } while (rocketInSquare == true);
            }

            p.PositionX = newX;
            p.PositionY = newY;
            Console.WriteLine($"{p.Name} has landed on boardsquare ({p.PositionX}, {p.PositionY}).\n");
            return p;
        }


        // returns true if there is a rocket in the specified square
        static bool RocketInSquare(int newX, int newY)
        {

            for (int i = 0; i < players.Length; i++)
            {
                Console.WriteLine($"player{i + 1}: {players[i].PositionX}, player{i + 1}: {players[i].PositionY}");

                if(players[i].PositionX == newX && players[i].PositionY == newY)
                {
                    Console.WriteLine("rocket in square = true");
                    return true;
                }
            }
            Console.WriteLine("rocket in square = false");
            return false;
        }










        //These are supplementary Methods to help out with funcationality of the other methods.

        public static string EnterPlayerName()
        {
            string name = ReadString("Please enter a player's name: ");
            return name;
        }

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


        //// returns true if there is cheese in the specified square
        //static bool CheeseInSquare(int X, int Y)
        //{
        //    return ((X == 0 && Y == 3) || (X == 3 && Y == 5) || (X == 4 && Y == 1) || (X == 6 && Y == 4));
        //}
    }
}

