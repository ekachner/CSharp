using System;
namespace Hyperspace_Cheese_Battle
{
    public class Player
    {
        public string Name;
        public int X;
        public int Y;

        public static bool InvalidCoordinates(int x)
        {
            if(x > 7 || x < 0)
            {
                Console.WriteLine("This would take you off the board! Please wait until your next turn.");
                return true;
            } else
            {
                return false;
            }
        }

        public static void PrintPlayerNames(Player[] players)
        {
            int counter = 1;
            for(int i = 0; i < players.Length; i++)
            {
                Console.WriteLine($"{counter}. {players[i].Name}");
                counter++;
            }
        }

        public static void ShowStatus(Player [] players, int round)
        {
            Console.Clear();
            Console.WriteLine("HYPERSPACE CHEESE BATTLE STATUS REPORT");
            Console.WriteLine($"AFTER ROUND {round}:");

            foreach(var Player in players)
            {
                Console.WriteLine($"{Player.Name}:    Current Position: ({Player.X}, {Player.Y})");
            }
        }

        public static void PlayerTurn(Player player, Player[] players, int[,] board, bool anotherRound)
        {
            anotherRound = true;
            Console.WriteLine($"{player.Name}, it's your turn!");
            int rollNum = Dice.Roll();
            int currentCell = board[player.Y, player.X];

            switch (currentCell)
            {
                case 0:
                    int y = player.Y - rollNum;
                    if (InvalidCoordinates(y) == false)
                    {
                        player.Y = y;
                        Console.WriteLine($"MOVE {rollNum} SPACES DOWN");
                    }
                    break;
                case 1:
                    y = player.Y + rollNum;
                    if (InvalidCoordinates(y) == false)
                    {
                        player.Y = y;
                        Console.WriteLine($"MOVE {rollNum} SPACES UP");
                    }
                    break;
                case 2:
                    int x = player.X - rollNum;
                    if (InvalidCoordinates(x) == false)
                    {
                        player.X = x;
                        Console.WriteLine($"MOVE {rollNum} SPACES LEFT");
                    }
                    break;
                case 3:
                    x = player.X + rollNum;
                    if (InvalidCoordinates(x) == false)
                    {
                        player.X = x;
                        Console.WriteLine($"MOVE {rollNum} SPACES RIGHT");
                    }
                    break;
                case 4:
                    Board.CheeseSquare(players, player);
                    player.X++;
                    player.Y++;
                    break;
                case 5:
                    Console.WriteLine("You win!");
                    anotherRound = false;
                    break;
                default:
                    Console.WriteLine("INVALID");
                    break;
            }

            currentCell = board[player.Y, player.X];
        }
    }
}
