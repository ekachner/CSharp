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

        public static void Turn(Player[] players)
        {
            int counter = 0;

            int[,] board = Board.CellDirections;

            bool anotherGame = true;
            do
            {
                for (int i = 0; i < players.Length; i++)
                {
                    Console.WriteLine($"{players[i].Name}, it's your turn!");
                    int rollNum = Dice.Roll();
                    int currentCell = board[players[i].Y, players[i].X];

                    switch (currentCell)
                    {
                        case 0:
                            int y = players[i].Y - rollNum;
                            if(Player.InvalidCoordinates(y) == false)
                            {
                                players[i].Y = y;
                                Console.WriteLine($"MOVE {rollNum} SPACES DOWN");
                            }
                            break;
                        case 1:
                            y = players[i].Y + rollNum;
                            if(Player.InvalidCoordinates(y) == false)
                            {
                                players[i].Y = y;
                                Console.WriteLine($"MOVE {rollNum} SPACES UP");
                            }
                            break;
                        case 2:
                            int x = players[i].X - rollNum;
                            if(Player.InvalidCoordinates(x) == false)
                            {
                                players[i].X = x;
                                Console.WriteLine($"MOVE {rollNum} SPACES LEFT");
                            }
                            break;
                        case 3:
                            x = players[i].X + rollNum;
                            if(Player.InvalidCoordinates(x) == false)
                            {
                                players[i].X = x;
                                Console.WriteLine($"MOVE {rollNum} SPACES RIGHT");
                            }
                            break;
                        case 4:
                            Console.WriteLine("You win!!!");
                            int another = Inputs.ReadNumber("Would you like to play another game? [0 = No, 1 = Yes]", 0, 1);
                            if (another == 0)
                            {
                                anotherGame = false;
                            }
                            break;
                        default:
                            Console.WriteLine("INVALID");
                            break;
                    }

                    counter++;
                    Player current = players[i];
                    currentCell = board[players[i].X, players[i].Y];
                }
                
                Player.ShowStatus(players, counter / players.Length);

            } while (anotherGame == true);
        }
    }
}
