using System;

namespace HyperspaceCheeseBattle
{
    class Program
    {
        static bool winStatus = false;

        static void Main(string[] args)
        {
            string decision;

            do
            {
                ResetGame();

                do
                {
                    for (var i = 0; i < players.Length; i++)
                    {
                        players[i] = PlayerTurn(players[i]);                       
                    }
                    ShowStatus(players);
                }
                while (winStatus == false);

                decision = ChooseBetween("\nWould you like to play again? (Y or N)", "Y", "N");

            } while (decision == "Y");           
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
            {0,2,2,2,2,2,0,4}, //row 7
        };

        
        private enum Direction
        {
            Down = 0,
            Up = 1,
            Right = 2,
            Left = 3,
            GameOver = 4
        }


        struct Player
        {
            public string Name;
            public int PositionX;
            public int PositionY;
        }


        static Player[] players = new Player[4]; //or "numberOfPlayers" and awaken method in Reset()

        static int NumberOfPlayers()
        {
            int numberOfPlayers = ReadInteger("How many players are there?: ", 2, 4);
            return numberOfPlayers;
        }


        // reads in the player information for a new game
        static void ResetGame()
        {
            //NumberOfPlayers();
            Console.WriteLine($"\nYou have selected {players.Length} players");

            for (int i = 0; i < players.Length; i++)
            {
                //string name = EnterPlayerName();
                players[i] = new Player
                {
                    Name = $"Player{i + 1}", //and use "name" if adding names manually
                    PositionX = 0,
                    PositionY = 0
                };

                Console.WriteLine($"{players[i].Name}");
            }
            winStatus = false;
        }

        
        //static Player[] MakeMoves()
        //{
        //    int i;
        //    for (i = 0; i < players.Length; i++)
        //    {
        //        players[i] = PlayerTurn(players[i]);
        //    }

        //    //ShowStatus(players);
        //    return players;
        //}


        static int[] diceValues = new int[] { 2,2,2,3 };
        static int diceValuePosition = 0;
        static int RollDice()
        {
            {
                int dots = diceValues[diceValuePosition];
                diceValuePosition += 1;
                if (diceValuePosition == diceValues.Length)
                {
                    diceValuePosition = 0;
                }
                return dots;
            }
        }


        static Player PlayerTurn(Player p)
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
                if (p.PositionY + rollValue <= 7)
                {
                    newY += rollValue;
                }
                else
                {
                    Console.WriteLine(loseTurn);
                    return p;
                }
            }
            else if (direction == Direction.Down)
            {
                if (p.PositionY - rollValue >= 0)
                {
                    newY -= rollValue;
                }
                else
                {
                    Console.WriteLine(loseTurn);
                    return p;
                }
            }
            else if (direction == Direction.Right)
            {
                if (p.PositionX + rollValue <= 7)
                {
                    newX += rollValue;
                }
                else
                {
                    Console.WriteLine(loseTurn);
                    return p;
                }
            }
            else if (direction == Direction.Right) //left
            {
                if (p.PositionX - rollValue >= 0)
                {
                    newX -= rollValue;
                }
                else
                {
                    Console.WriteLine(loseTurn);
                    return p;
                }
            }
            else
            {
                Console.WriteLine("in Direction detection conditional, for ");
            }
            

            Console.WriteLine($"New coordinates after rolling {rollValue} is ({newX},{newY})");


            bool rocketInSquare = RocketInSquare(newX, newY);

            if (rocketInSquare == true)
            {
                do
                {                  
                    direction = (Direction)board[newY, newX];
                    Console.WriteLine($"direction in do while loop moves {direction} for coordinates: ({newX},{newY})");

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
            } //end if statement for do-while


            bool cheeseInSquare = CheeseInSquare(newX, newY);

            if(cheeseInSquare == true)
            {
                Console.WriteLine("\nYou have landed on a cheese square!!!\nHere is the current status of your rivals:");
                for (int i = 0; i < players.Length; i++)
                {
                    if (players[i].Name == p.Name)
                    {
                        Console.Write("");
                    }
                    else
                    {
                        Console.WriteLine($"{players[i].Name} is on square ({players[i].PositionX},{players[i].PositionY})");
                    }
                }
                string decision = ChooseBetween("\nWhat would you like to do with your cheese power? " +
                    "You may either roll again or you can fire a \"Cheezy Deathray\" at another player on the board. " +
                    "(Roll again OR Deathray - Choose: R or D)", "R", "D");
                if(decision == "R")
                {
                    p.PositionX = newX;
                    p.PositionY = newY;                    
                    PlayerTurn(p);
                    return p;
                }
                if(decision == "D")
                {
                    //int[] rivalNumber = new int[players.Length - 1];
                    //int j = 1;
                    //int rivalNumberPosition = 0;

                    ////this generates the player[i] and a new array value 
                    //Console.WriteLine("Which of your rivals do you wish to ZAP?");
                    //for (int i = 0; i < players.Length; i++)
                    //{
                    //    if (players[i].Name == p.Name)
                    //    {
                    //        Console.Write("");
                    //    }
                    //    else
                    //    {
                    //        Console.WriteLine($"{players[i].Name} = {j}"); //somehow need the number to be assigned to the player displayed
                    //        rivalNumber[i] = new int { };
                    //        j++;
                    //    }
                    //}
                    //string rivalChosen = Console.In.ReadLine();
                    //Console.WriteLine($"You have chosen {rivalChosen}");


                    //for(int i = 0; i < rivalNumber.Length; i++)
                    //{
                    //    int rivalNumberChosen = rivalNumber[i];
                    //}

                    //rivalNumberPosition += 1;
                    //if (rivalNumberPosition == rivalNumber.Length)
                    //{
                        
                    //}


                    //this generates the player[i] and 
                    Console.WriteLine("Which of your rivals do you wish to ZAP?");
                    for (int i = 0; i < players.Length; i++)
                    {
                        if (players[i].Name == p.Name)
                        {
                            Console.Write("");
                        }
                        else
                        {
                            Console.WriteLine($"{players[i].Name} = {i + 1}");
                        }
                    }
                    int rivalChosen = Convert.ToInt32(Console.In.ReadLine());   //somehow need to ensure they choose one of the valid numbers
                    Console.WriteLine($"You have chosen {players[rivalChosen]}");

                    Console.Write($"\n{players[rivalChosen].Name} which column of row 1 do you wish to move to?: ");
                    Console.ReadLine();
                    //create switch statement for column cases and determine whether they are open or not. Use rocketInSquare method
                    //but instead of taking them to the do while loop, keep prompting them till they choose a column that is empty.

                    


                }
                //if deathray prompt which player they want to shoot, display each players coordinates and have them pick which player to shoot.
                //prompt THAT player and ask them which unoccupied column of row 1 they would like to go to. run the test for rocketInSquare again.
                //end of this player's turn. RocketInSquare(players[rivalChosen].PositionX, players[rivalChosen].PositionY);

            } //end of dealing with cheese power for CheeseInSquare method


            p.PositionX = newX;
            p.PositionY = newY;
            Console.WriteLine($"{p.Name} has landed on boardsquare ({p.PositionX}, {p.PositionY}).\n");


            winStatus = GameOver(p.PositionX, p.PositionY);

            
            if (winStatus == true)
            {               
                Console.WriteLine($"In PlayerTurn {p.Name} has won the game!");
            }

            return p;
            
        } // end PlayerTurn() method;


        // returns true if there is a rocket in the specified square
        static bool RocketInSquare(int newX, int newY)
        {
            for (int i = 0; i < players.Length; i++)
            {
                Console.WriteLine($"player{i + 1} ({players[i].PositionX},{players[i].PositionY})");

                if (players[i].PositionX == newX && players[i].PositionY == newY)
                {
                    Console.WriteLine("rocket in square = true");
                    return true;
                }
            }
            Console.WriteLine("rocket in square = false");
            return false;
        }


        // returns true if there is cheese in the specified square
        static bool CheeseInSquare(int X, int Y)
        {
            return ((X == 0 && Y == 3) || (X == 3 && Y == 5) || (X == 4 && Y == 1) || (X == 6 && Y == 4));
        }


        static bool GameOver(int newX, int newY)
        {
            if(newX == 7 && newY == 7)
            {
                Console.WriteLine("GameOver = true");
                return true;
            }
            Console.WriteLine("GameOver = false");
            return false;
        }




        


        static void ShowStatus(Player[] players)
        {
            Console.WriteLine("\nHyperspace Cheese Battle Report");
            Console.WriteLine("===============================");
            Console.WriteLine($"There are {players.Length} players in the game");
            foreach(Player p in players)
            {
                Console.WriteLine($"{p.Name} is on square ({p.PositionX},{p.PositionY})");
            }
        }


        static string EnterPlayerName()
        {
            string name = ReadString("Please enter a player's name: ");
            return name;
        }


        static int RandomDiceRoll()
        {
            Random random = new Random();
            int roll = random.Next(1, 7);
            return roll;
        }


        //asks user to choose between two values
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


        static string ChooseBetweenThree(string prompt, string option1, string option2, string option3)
        {
            do
            {
                Console.Write(prompt);
                string input = Console.ReadLine().ToUpper().Trim();
                if (input == option1 || input == option2 || input == option3)
                {
                    return input;
                }
                else
                {
                    Console.WriteLine($"Error: Please select {option1}, {option2} or {option3}.");
                }
            } while (true);
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


        
    }
}

