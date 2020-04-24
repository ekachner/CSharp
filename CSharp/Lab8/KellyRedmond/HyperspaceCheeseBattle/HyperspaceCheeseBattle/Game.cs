using System;
using System.Globalization;
using System.Collections.Generic;

namespace HyperspaceCheeseBattle
{
    public class Game
    {
        private const int MAXPLAYERS = 4;
        public static int NumberPlayersInGame;
        public static Player[] players;
        public static bool gameOver = false;
        static int[] diceValues;
        static int diceValuePos = 0;
        static Random diceRandom = new Random();
        static bool testModeResult = false;

        public static void ResetGame()
        {
            if (!testModeResult)
                Welcome();
            
            players = CreatePlayers();
        }

        public static void PlayGame()
        {
            while(!gameOver)
            {
                MakeMove();
                if (gameOver)
                {
                    break;
                }
                Console.WriteLine();
                ShowStatus();
                Console.Write("Press return for the next round");
                Console.ReadLine();
                Console.Clear();
            }
        }

        public static void ResetXY()
        {
            for(int i = 0; i < players.Length; i++)
            {
                players[i].X = 0;
                players[i].Y = 0;
            }
            return;
        }

        static void Welcome()
        {
            Console.WriteLine("============================================\n\n      Hyperspace Cheese Battle      \n\n============================================");
        }

        static Player[] CreatePlayers()
        {
            NumberPlayersInGame = Methods.VerifyNumber("How many players are there today? ", 2, MAXPLAYERS);
            players = new Player[NumberPlayersInGame];
            Console.Clear();

            foreach (var player in players)
            {
                int playerNo = PlayerIndex(player);
                //name needs to be unique
                Console.WriteLine($"Enter the name for Player {playerNo + 1}: ");
                string playerName = GetPlayerName();
                players[playerNo] = new Player(playerName, 0, 0);
                Console.Clear();
            }

            return players;
        }


        private static string GetPlayerName()
        {
            string nameIn = "";
            bool nameAccepted = false;

            while (!nameAccepted) //add && players[p].Name != nameIn
            {
                nameIn = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(Console.ReadLine().Trim());

                if (nameIn.Length > 0 && !nameIn.Contains(" "))
                {
                    break;
                }
                Console.WriteLine("Name not entered correctly.");
                Console.Write("Enter the players name: ");
            }
            return nameIn;
        }

        public static void MakeMove()
        {
            foreach (var player in players)
            {
                PlayerTurn(PlayerIndex(player));
                if (gameOver)
                {
                    break;
                }
                //Console.WriteLine("Press enter for next players turn");
                //Console.ReadLine();
            }
        }

        public static void PlayerTurn(int playerNo)
        {
            bool spaceOccupied = true;
            string errorMessage = $"Shucks, {players[playerNo].Name}, your roll was too high. Better luck next turn";
            string alreadyOccupied = $"Someone was here first, {players[playerNo].Name} is bounced to the next square";

            //Console.WriteLine($"{players[playerNo].Name} it's your turn\nPress enter to roll");
            //Console.ReadLine();

            int playerMove = (testModeResult == true) ? PresetDiceThrow() : RandomDiceThrow();

            Console.WriteLine($"{players[playerNo].Name} rolled a {playerMove}");

            while (spaceOccupied)
            {
                switch (board[players[playerNo].X, players[playerNo].Y])
                {
                    case Direction.North:
                        spaceOccupied = RocketInSquare(players[playerNo].X, players[playerNo].Y + playerMove) ? true : false;
                        if (players[playerNo].Y + playerMove <= 7)
                        {
                            players[playerNo].Y += playerMove;
                            if (spaceOccupied == true)
                            {
                                Console.WriteLine(alreadyOccupied);
                                playerMove = 1;
                            }
                            break;
                        }
                        Console.WriteLine(errorMessage);
                        break;

                    case Direction.South:
                        spaceOccupied = RocketInSquare(players[playerNo].X, players[playerNo].Y - playerMove) ? true : false;
                        if (players[playerNo].Y - playerMove >= 0)
                        {
                            players[playerNo].Y -= playerMove;
                            if (spaceOccupied == true)
                            {
                                Console.WriteLine(alreadyOccupied);
                                playerMove = 1;
                            }
                            break;
                        }
                        Console.WriteLine(errorMessage);
                        break;

                    case Direction.East:
                        spaceOccupied = RocketInSquare(players[playerNo].X + playerMove, players[playerNo].Y) ? true : false;
                        if (players[playerNo].X + playerMove <= 7)
                        {
                            players[playerNo].X += playerMove;
                            if (spaceOccupied == true)
                            {
                                Console.WriteLine(alreadyOccupied);
                                playerMove = 1;
                            }
                            break;
                        }
                        Console.WriteLine(errorMessage);
                        break;

                    case Direction.West:
                        spaceOccupied = RocketInSquare(players[playerNo].X - playerMove, players[playerNo].Y) ? true : false;
                        if (players[playerNo].X - playerMove >= 0)
                        {
                            players[playerNo].X -= playerMove;
                            if (spaceOccupied == true)
                            {
                                Console.WriteLine(alreadyOccupied);
                                playerMove = 1;
                            }
                            break;
                        }
                        Console.WriteLine(errorMessage);
                        break;

                    //should never run but just in case
                    case Direction.Win:
                        Console.WriteLine($"{players[playerNo].Name} Won!!");
                        gameOver = true;
                        spaceOccupied = false;
                        break;

                    default:
                        Console.WriteLine("An error has occured. Please restart game");
                        break;
                }
            }

            players[playerNo].PlayerPosition(); 

            bool cheeseChoice = CheesePower(players[playerNo].X, players[playerNo].Y);

            if (cheeseChoice == true)
            {
                CheeseQuestions(playerNo);
            }

            gameOver = CheckWin(playerNo);

        }

        public static void ShowStatus()
        {
            Console.WriteLine("Hyperspace Cheese Battle Status Report");
            Console.WriteLine("======================================\n");
            Console.WriteLine($"There are {NumberPlayersInGame} players in the game");

            foreach (Player player in players)
            {
                player.PlayerPosition();
                //Console.WriteLine(board[players[PlayerIndex(player)].X, players[PlayerIndex(player)].Y]);
            }
        }

        static bool RocketInSquare(int X, int Y)
        {
            for (int i = 0; i < players.Length; i++)
            {
                if (players[i].X == X && players[i].Y == Y)
                {
                    return true;
                }
            }

            return false;
        }

        static bool CheesePower(int x, int y)  
        {
            if (
                x == 4 && y == 1 ||
                x == 0 && y == 3 ||
                x == 6 && y == 4 ||
                x == 3 && y == 5
                )
            {
                return true;
            }

            return false;
        }

        static void CheeseQuestions(int playerNo)
        {
            Console.WriteLine($"{players[playerNo].Name}, you have landed on a cheese power square!\nYou can use this power to either:");
            Console.WriteLine("\t1. Fire the Cheese Deathray at another player\n\t   and zap them to the bottom row\n\tOR\n\t2. Roll the dice and move again");
            string cheeseChoice = Methods.StringChoice("Enter 1 to FIRE or 2 to ROLL: ", "1", "2");
            if (cheeseChoice == "1")
            {
                CheeseFire(playerNo);
                return;
            }

            CheeseRoll(playerNo);
            return;
        }

        static void CheeseFire(int playerNo)
        {
            Player[] deathrayOptions = new Player[players.Length -1];
            Console.WriteLine("\nCheese Deathray has been activated!\n\tTarget options are: ");

            int count = 0;
            for(int i = 0; i < players.Length; i++)
            {
                if (players[i].NameEquals(players[playerNo]))
                {
                    continue;
                }
                else
                {
                    deathrayOptions[count] = new Player(name: players[i].Name, x: players[i].X, y: players[i].Y); 
                    Console.WriteLine(value: $"\t   {count + 1}. {deathrayOptions[count].Name}");
                    count += 1;
                }
            }

            Console.WriteLine(deathrayOptions.ToString());
            int attackedPlayer = Methods.VerifyNumber("\t   Enter the Number of the Player you wish to attack: ", 1, deathrayOptions.Length);
            for(int i = 0; i < deathrayOptions.Length; i++)
            {
                if (deathrayOptions[attackedPlayer - 1].Name == deathrayOptions[i].Name)
                {
                    Console.WriteLine($"\nPlayer {deathrayOptions[i].Name} you can choose which space you would like to land in.\nOptions are:");
                    List<int> bottomRow = new List<int>() { 0, 1, 2, 3, 4, 5, 6, 7 };
                    foreach (Player p in players)
                    {
                        if (players[PlayerIndex(p)].Y == 0)
                        {
                            bottomRow.Remove(players[PlayerIndex(p)].X);
                        }
                    }
                    Console.Write("\t");
                    Console.Write(String.Join("\t", bottomRow));
                    int spaceSelected = Methods.VerifyNumber($"\nWhere would you like to land Player {deathrayOptions[i].Name}? ", 1, bottomRow.Count);
                    int updatePlayerIndex = Array.FindIndex(players, x => x.Equals(deathrayOptions[i]));
                    players[updatePlayerIndex].Y = spaceSelected - 1;
                    players[updatePlayerIndex].X = 0;
                    players[updatePlayerIndex].PlayerPosition();
                    return;
                }
            }
        }

        static void CheeseRoll(int playerNo)
        {
            PlayerTurn(playerNo);
        }

        static bool CheckWin(int playerNo)
        {
            if (players[playerNo].X == 7 && players[playerNo].Y == 7)
            {
                Console.WriteLine($"\n---- CONGRATULATIONS ----\n{players[playerNo].Name} WON HYPERSPACE CHEESE BATTLE!!");
                return true;
            }

            return false;
        }

        public static bool TestMode()
        {
            string chooseTestMode = Methods.StringChoice("Would you like to play in Test Mode? ( Y / N ): ", "Y", "N");
            testModeResult = (chooseTestMode == "Y") ? true : false;
            if (testModeResult == true)
            {
                GetDiceValues();
                return testModeResult;
            }

            Console.Clear();
            return testModeResult;
        }

        public static void GetDiceValues()
        {
            int numberOfDice = Methods.VerifyNumber("Enter how many dice values you would like to use: ", 1, 6);

            diceValues = new int[numberOfDice];
            for (int i = 0; i < diceValues.Length; i++)
            {
                int dieValue = Methods.VerifyNumber($"Enter the value for die {i + 1}: ", 1, 7);
                diceValues[i] = dieValue;
            }
            Console.Clear();
        }

        static int PresetDiceThrow()
        {
            int spots = diceValues[diceValuePos];

            diceValuePos += 1;

            if (diceValuePos == diceValues.Length)
            {
                diceValuePos = 0;
            }

            return spots;
        }

        static int RandomDiceThrow()
        {
            int spots = diceRandom.Next(1, 7);
            return spots;
        }

        enum Direction
        {
            North,
            East,
            South,
            West,
            Win
        };

        static int PlayerIndex(Player player)
        {
            int playerIndex = Array.FindIndex(players, x => x.Equals(player));
            return playerIndex;
        }


        static Direction[,] board = new Direction[,]
        {
            { Direction.North,Direction.East,Direction.East,Direction.East,Direction.East,Direction.East,Direction.East,Direction.South },
            { Direction.North,Direction.East,Direction.East,Direction.East,Direction.East,Direction.East,Direction.East,Direction.East },
            { Direction.North,Direction.North,Direction.North,Direction.North,Direction.North,Direction.East,Direction.North,Direction.East },
            { Direction.North,Direction.South,Direction.East,Direction.East,Direction.East,Direction.East,Direction.South,Direction.East },
            { Direction.North,Direction.North,Direction.West,Direction.North,Direction.North,Direction.North,Direction.North,Direction.East },
            { Direction.North,Direction.North,Direction.East,Direction.North,Direction.North,Direction.North,Direction.East,Direction.East },
            { Direction.North,Direction.West,Direction.West,Direction.West,Direction.West,Direction.West,Direction.West,Direction.South },
            { Direction.North,Direction.West,Direction.West,Direction.West,Direction.West,Direction.West,Direction.West,Direction.Win },
        };

        public static string PrintDirectionBoard(string direction)
        {
            return direction switch
            {
                "North" => " \u2191 ",
                "West" => " \u2192 ",
                "South" => " \u2193 ",
                "East" => " \u2190 ",
                "Win" => " Win",
                _ => throw new Exception("Invalid state"),
            };
        }

        public static void DisplayBoard()
        {
            for (int i = 7; i >= 0; i--)
            {
                for (int k = 0; k <= 7; k++)
                {
                    Console.Write(PrintDirectionBoard(board[k, i].ToString()));
                }
                Console.WriteLine();
            }
        }
    }
}