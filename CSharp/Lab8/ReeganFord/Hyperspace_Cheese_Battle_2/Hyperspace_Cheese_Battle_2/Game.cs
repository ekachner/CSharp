using System;
namespace Hyperspace_Cheese_Battle
{
    public class Game
    {
        public static Player[] StartGame()
        {
            Console.WriteLine("HYPERSPACE CHEESE BATTLE!");
            int numOfPlayers = Inputs.ReadNumber("How many players?: ", 2, 4);

            Player[] players = new Player[numOfPlayers];
            int counter = 0;

            for (int i = 0; i < numOfPlayers; i++)
            {
                counter++;
                Player newPlayer = new Player
                {
                    Name = Inputs.ReadString($"Name of player {counter}: "),
                    X = 0,
                    Y = 0
                };

                players[i] = newPlayer;
            }
            counter = 0;

            Player.ShowStatus(players, 0);

            return players;
        }

        public static void Round(Player[] players, bool anotherGame)
        {
            int round = 0;
            int[,] board = Board.CellDirections;
            bool anotherRound = true;

            do
            {
                for (int i = 0; i < players.Length; i++)
                {
                    Player.PlayerTurn(players[i], players, board, anotherRound);
                    round++;
                    if(players[i].X == 7 && players[i].Y == 7)
                    {
                        anotherGame = false;
                    }
                }

                bool pressedEnter = false;
                do
                {
                    if (Console.ReadKey().Key == ConsoleKey.Enter)
                    {
                        Player.ShowStatus(players, round);
                        pressedEnter = true;
                    }
                    else
                    {
                        Console.WriteLine("Wrong key. Please try again.");
                    }
                } while (pressedEnter == false);

            } while (anotherRound == true);
        }

        public static void GameOver(bool anotherGame)
        {
            int another = Inputs.ReadNumber("Would you like to play again? [0 = No, 1 = Yes]: ", 0, 1);
            if(another == 0)
            {
                Console.Clear();
                Console.WriteLine("Thanks for playing HYPERSPACE CHEESE BATTLE!");
            } else
            {
                anotherGame = true;
            }
        }
    }
}






//bool anotherGame = true;
//do
//{


//        counter++;
//        Player current = players[i];
//        currentCell = board[players[i].X, players[i].Y];

//        if(currentCell == 5)
//        {
//            Console.WriteLine($"{players[i].Name}, you win!");
//            int another = Inputs.ReadNumber("Would you like to play another game? [0 = No, 1 = Yes]", 0, 1);
//            if (another == 0)
//            {
//                anotherGame = false;
//            }
//            break;
//        }

//    }
//    Console.WriteLine("Press enter to advance to the next round!");
//    round++;
//bool pressedEnter = false;
//                do
//                {
//                    if (Console.ReadKey().Key == ConsoleKey.Enter)
//                    {
//                        Player.ShowStatus(players, round);
//                        pressedEnter = true;
//                    }
//                    else
//                    {
//                        Console.WriteLine("Wrong key. Please try again.");
//                    }
//                } while (pressedEnter == false);

            //} while (anotherGame == true);
//        }
//}
//}





//for (int i = 0; i<players.Length; i++)
                //{
//                    Console.WriteLine($"{players[i].Name}, it's your turn!");
//                    int rollNum = Dice.Roll();
//int currentCell = board[players[i].Y, players[i].X];

//                    switch (currentCell)
//                    {
//                        case 0:
//                            int y = players[i].Y - rollNum;
//                            if(Player.InvalidCoordinates(y) == false)
//                            {
//                                players[i].Y = y;
//                                Console.WriteLine($"MOVE {rollNum} SPACES DOWN");
//                            }
//                            break;
//                        case 1:
//                            y = players[i].Y + rollNum;
//                            if(Player.InvalidCoordinates(y) == false)
//                            {
//                                players[i].Y = y;
//                                Console.WriteLine($"MOVE {rollNum} SPACES UP");
//                            }
//                            break;
//                        case 2:
//                            int x = players[i].X - rollNum;
//                            if(Player.InvalidCoordinates(x) == false)
//                            {
//                                players[i].X = x;
//                                Console.WriteLine($"MOVE {rollNum} SPACES LEFT");
//                            }
//                            break;
//                        case 3:
//                            x = players[i].X + rollNum;
//                            if(Player.InvalidCoordinates(x) == false)
//                            {
//                                players[i].X = x;
//                                Console.WriteLine($"MOVE {rollNum} SPACES RIGHT");
//                            }
//                            break;
//                        case 4:
//                            Board.CheeseSquare(players);
//                            break;
//                        case 5:
//                            Console.WriteLine("Game over!!!");
//                            Console.Clear();
//                            break;
//                        default:
//                            Console.WriteLine("INVALID");
//                            break;
//                    }


