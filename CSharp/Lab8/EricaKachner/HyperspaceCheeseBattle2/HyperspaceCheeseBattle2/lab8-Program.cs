using System;

namespace HyperspaceCheeseBattle
{
    class Program
    {
        static bool winStatus = false;
        static Player[] players;

        static void Main(string[] args)
        {
            string decision;

            do
            {
                ResetGame();
                
                while (winStatus == false)
                {
                    for (var i = 0; i < players.Length; i++)
                    {
                        PlayerTurn(players[i]);
                        if(winStatus == true)
                        {
                            break;
                        }
                    }
                    ShowStatus(players);
                }

                decision = ChooseBetween("\nWould you like to play again? (Y or N)", "Y", "N");

            } while (decision == "Y");

            Console.WriteLine("\nThank you for playing!");
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
            {0,2,2,2,2,2,0,5}, //row 7
        };

        
        private enum Direction
        {
            Down = 0,
            Up = 1,
            Right = 2,
            Left = 3,
            Win = 5
        }


        class Player
        {
            public string Name;
            public int PositionX;
            public int PositionY;
        }


        // reads in the player information for a new game
        static void ResetGame()
        {
            int numberOfPlayers = ReadInteger("How many players are there?: ", 2, 4);
            players = new Player[numberOfPlayers];

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


        static void PlayerTurn(Player p)
        {
            Console.WriteLine($"\nIt's {p.Name}'s turn");
            Console.Write($"{p.Name} please roll your dice (ENTER)");
            Console.ReadLine();
            Console.WriteLine("=========================================");
            int rollValue = RandomDiceRoll();
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
                    return;
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
                    return;
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
                    return;
                }
            }
            else //left
            {
                if (p.PositionX - rollValue >= 0)
                {
                    newX -= rollValue;
                }
                else
                {
                    Console.WriteLine(loseTurn);
                    return;
                }
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
            } 
            p.PositionX = newX;
            p.PositionY = newY;      


            bool cheeseInSquare = CheeseInSquare(newX, newY);

            if(cheeseInSquare == true)
            {
                Console.WriteLine($"new coordinates = ({p.PositionX},{p.PositionY})");
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
                    return;
                }
                if (decision == "D")
                {
                    int rivalChosen = ChooseRival(p);   //somehow need to ensure they choose one of the valid numbers
                    Console.WriteLine($"You have chosen {players[rivalChosen].Name}");

                    ChooseColumnNumber(players[rivalChosen]);                                    
                }                
            }

            p.PositionX = newX;
            p.PositionY = newY;
            Console.WriteLine($"{p.Name} has landed on boardsquare ({p.PositionX}, {p.PositionY}).\n");

            winStatus = GameOver(p.PositionX, p.PositionY);
            
            if (winStatus == true)
            {               
                Console.WriteLine($"{p.Name} has won the game!");
            }
            return;            
        } // end PlayerTurn() method;

       
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


        static void ChooseColumnNumber(Player p)
        {
            int column;
            bool rivalInSquare = false;
            int newX;
            int newY;

            do
            {
                column = ChooseColumn($"{p.Name} please select the column of row 1 you would like to be sent to.\n Your options are: 1, 2, 3, 4, 5, 6, 7, 8: ", 1, 2, 3, 4, 5, 6, 7, 8);
                switch (column)
                {
                    case 1:
                        newY = 0;
                        newX = 0;
                        Console.WriteLine($"column {(newX, newY)} was chosen");
                        if (RocketInSquare(newX, newY) == true)
                        {
                            rivalInSquare = RocketInSquare(p.PositionX, p.PositionY);
                            Console.WriteLine("There's already someone here, please choose another column");
                            break;
                        }
                        p.PositionX = newX;
                        p.PositionY = newY;
                        Console.WriteLine($"new coordinates for {p.Name} are ({p.PositionX}, {p.PositionY})");
                        return;
                    case 2:
                        newY = 0;
                        newX = 1;
                        Console.WriteLine($"column {(newX, newY)} was chosen");
                        if (RocketInSquare(newX, newY) == true)
                        {
                            rivalInSquare = RocketInSquare(p.PositionX, p.PositionY);
                            Console.WriteLine("There's already someone here, please choose another column");
                            break;
                        }
                        p.PositionX = newX;
                        p.PositionY = newY;
                        Console.WriteLine($"new coordinates for {p.Name} are ({p.PositionX}, {p.PositionY})");
                        return;
                    case 3:
                        newY = 0;
                        newX = 2;
                        Console.WriteLine($"column {(newX, newY)} was chosen");
                        if (RocketInSquare(newX, newY) == true)
                        {
                            rivalInSquare = RocketInSquare(p.PositionX, p.PositionY);
                            Console.WriteLine("There's already someone here, please choose another column");
                            break;
                        }
                        p.PositionX = newX;
                        p.PositionY = newY;
                        Console.WriteLine($"new coordinates for {p.Name} are ({p.PositionX}, {p.PositionY})");
                        return;
                    case 4:
                        newY = 0;
                        newX = 3;
                        Console.WriteLine($"column {(newX, newY)} was chosen");
                        if (RocketInSquare(newX, newY) == true)
                        {
                            rivalInSquare = RocketInSquare(p.PositionX, p.PositionY);
                            Console.WriteLine("There's already someone here, please choose another column");
                            break;
                        }
                        p.PositionX = newX;
                        p.PositionY = newY;
                        Console.WriteLine($"new coordinates for {p.Name} are ({p.PositionX}, {p.PositionY})");
                        return;
                    case 5:
                        newY = 0;
                        newX = 4;
                        Console.WriteLine($"column {(newX, newY)} was chosen");
                        if (RocketInSquare(newX, newY) == true)
                        {
                            rivalInSquare = RocketInSquare(p.PositionX, p.PositionY);
                            Console.WriteLine("There's already someone here, please choose another column");
                            break;
                        }
                        p.PositionX = newX;
                        p.PositionY = newY;
                        Console.WriteLine($"new coordinates for {p.Name} are ({p.PositionX}, {p.PositionY})");
                        return;
                    case 6:
                        newY = 0;
                        newX = 5;
                        Console.WriteLine($"column {(newX, newY)} was chosen");
                        if (RocketInSquare(newX, newY) == true)
                        {
                            rivalInSquare = RocketInSquare(p.PositionX, p.PositionY);
                            Console.WriteLine("There's already someone here, please choose another column");
                            break;
                        }
                        p.PositionX = newX;
                        p.PositionY = newY;
                        Console.WriteLine($"new coordinates for {p.Name} are ({p.PositionX}, {p.PositionY})");
                        return;
                    case 7:
                        newY = 0;
                        newX = 6;
                        Console.WriteLine($"column {(newX, newY)} was chosen");
                        if (RocketInSquare(newX, newY) == true)
                        {
                            rivalInSquare = RocketInSquare(p.PositionX, p.PositionY);
                            Console.WriteLine("There's already someone here, please choose another column");
                            break;
                        }
                        p.PositionX = newX;
                        p.PositionY = newY;
                        Console.WriteLine($"new coordinates for {p.Name} are ({p.PositionX}, {p.PositionY})");
                        return;
                    case 8:
                        newY = 0;
                        newX = 7;
                        Console.WriteLine($"column {(newX, newY)} was chosen");
                        if (RocketInSquare(newX, newY) == true)
                        {
                            rivalInSquare = RocketInSquare(p.PositionX, p.PositionY);
                            Console.WriteLine("There's already someone here, please choose another column");
                            break;
                        }
                        p.PositionX = newX;
                        p.PositionY = newY;
                        Console.WriteLine($"new coordinates for {p.Name} are ({p.PositionX}, {p.PositionY})");
                        return;
                }
            } while (rivalInSquare == true);
        }


        // returns true if there is cheese in the specified square
        static bool CheeseInSquare(int X, int Y)
        {
            return ((X == 0 && Y == 3) || (X == 3 && Y == 5) || (X == 4 && Y == 1) || (X == 6 && Y == 4));
        }

        //checks if a player has reached square (7,7)
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


        //displays players coordinates after one round of gameplay
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


        //in the reset method to manually enter a name for a player
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


        static int[] diceValues = new int[] { 2, 2, 2, 3 };
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


        static int ChooseRival(Player p)
        {
            int input;
            int i;

            do
            {
                try
                {
                    Console.Write("\nWhich of your rivals do you wish to ZAP?\n");
                    for (i = 0; i < players.Length; i++)
                    {
                            if (players[i].Name != p.Name)
                            {
                                Console.WriteLine($"{players[i].Name} = {i + 1}");  //outputting eligible players 
                            }
                    }
                    input = int.Parse(Console.ReadLine());
                    input -= 1;               
                    if (players[input].Name != p.Name)
                    {                        
                        return input;
                    }
                    else
                    {
                        Console.WriteLine("\nYou can't choose yourself...turd!");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"\n{(e.Message)} \n" +
                        $"Please select one of the eligible candidates");
                }
            } while (true);  
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


        static int ChooseColumn(string prompt, int column1, int column2, int column3, int column4, int column5, int column6, int column7, int column8)
        {
            int inputValue = 0;
            do
            {
                try
                {
                    Console.Write(prompt);
                    string input = Console.ReadLine().Trim();
                    inputValue = int.Parse(input);
                    if (inputValue == column1 || inputValue == column2 || inputValue == column3 || inputValue == column4 || inputValue == column5 || inputValue == column6 || inputValue == column7 || inputValue == column8)
                    {
                        return inputValue;
                    }
                    else
                    {
                        Console.WriteLine($"Error: Please select {column1}, {column2}, {column3}, {column4}, {column5}, {column6}, {column7} or {column8}.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {(e.Message)}.");
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