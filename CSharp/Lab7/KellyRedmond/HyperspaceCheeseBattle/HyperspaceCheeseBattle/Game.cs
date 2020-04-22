using System;
using System.Globalization;

namespace HyperspaceCheeseBattle
{
    public class Game
    {
        private const int MAXPLAYERS = 4;

        public static int NumberPlayersInGame;

        public static Player[] players;

        public static void ResetGame()
        {
            players = CreatePlayers();
            Array.Clear(players, 0, players.Length);
        }

        static Player[] CreatePlayers()
        {
            NumberPlayersInGame = Methods.VerifyNumber("How many players are there today? ", 2, MAXPLAYERS);
            players = new Player[NumberPlayersInGame];
            Console.Clear();

            foreach (var player in players)
            {
                var playerNo = Array.FindIndex(players, x => x.Equals(player)) + 1;
                Console.WriteLine($"Enter the name for Player {playerNo}: ");
                string playerName = GetPlayerName();
                players[playerNo - 1] = new Player(playerName, 0, 0);
                Console.Clear();
            }

            return players;
        }


        private static string GetPlayerName()
        {
            string nameIn = "";
            bool nameAccepted = false;

            while (!nameAccepted)
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

        public static void PlayerTurn(int playerNo)
        {
            Console.WriteLine($"{players[playerNo].Name} it's your turn");
            int playerMove = DiceThrow();
            bool spaceOccupied = true;
            string errorMessage = $"Shucks, {players[playerNo].Name}, your roll was too high. Better luck next turn";

            while (spaceOccupied)
            {
                switch (board[players[playerNo].X, players[playerNo].Y])
                {
                    case Direction.North:
                        spaceOccupied = RocketInSquare(players[playerNo].X, players[playerNo].Y + playerMove) ? true : false;
                        if (players[playerNo].Y + playerMove <= 7)
                        {
                            players[playerNo].Y += playerMove;
                            if (spaceOccupied)
                            {
                                OccupiedMessage(playerMove, playerNo);
                            }
                            break;
                        }

                        Console.WriteLine(errorMessage);
                        break;

                    case Direction.South:
                        spaceOccupied = RocketInSquare(players[playerNo].X, players[playerNo].Y - playerMove) ? true : false;

                        if (players[playerNo].Y - playerMove >= 0 )
                        {
                            players[playerNo].Y -= playerMove;
                            if (spaceOccupied)
                            {
                                OccupiedMessage(playerMove, playerNo);
                            }
                            break;
                        }

                        Console.WriteLine(errorMessage);
                        break;

                    case Direction.East:
                        spaceOccupied = RocketInSquare(players[playerNo].X - playerMove, players[playerNo].Y) ? true : false;
                        if (players[playerNo].X - playerMove >= 0)
                        {
                            players[playerNo].X -= playerMove;
                            if (spaceOccupied)
                            {
                                OccupiedMessage(playerMove, playerNo);
                            }
                            break;
                        }

                        Console.WriteLine(errorMessage);
                        break;


                    case Direction.West:
                        spaceOccupied = RocketInSquare(players[playerNo].X + playerMove, players[playerNo].Y) ? true : false;

                        if (players[playerNo].X + playerMove <= 7)
                        {
                            players[playerNo].X += playerMove;
                            if (spaceOccupied)
                            {
                                OccupiedMessage(playerMove, playerNo);
                            }
                            break;
                        }

                        Console.WriteLine(errorMessage);
                        break;

                    case Direction.Win:
                        Console.WriteLine($"{players[playerNo].Name} Won!!");
                        break;

                    default:
                        Console.WriteLine("An error has occured. Please restart game");
                        break;
                }
            }
            Console.WriteLine($"{players[playerNo].Name} your location is ( {players[playerNo].X}, {players[playerNo].Y} )");
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

        static void OccupiedMessage(int number, int playerNo)
        {
            Console.WriteLine($"Someone was here first, {players[playerNo].Name} is bounced to the next square");
            number = 1;
        }

        static int DiceThrow()
        {
            return 1;
        }

        //public bool TheSame(object obj)
        //{
        //    Player p = (Player)obj;
        //    if ((p.X == X) && (p.Y == Y))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        enum Direction
        {
            North,
            East,
            South,
            West,
            Win
        };


        static Direction[,] board = new Direction[,]
        {
            { Direction.North,Direction.West,Direction.West,Direction.West,Direction.West,Direction.West,Direction.West,Direction.South },
            { Direction.North,Direction.West,Direction.West,Direction.West,Direction.West,Direction.West,Direction.West,Direction.West },
            { Direction.North,Direction.North,Direction.North,Direction.North,Direction.North,Direction.West,Direction.North,Direction.West },
            { Direction.North,Direction.South,Direction.East,Direction.West,Direction.West,Direction.West,Direction.South,Direction.West },
            { Direction.North,Direction.North,Direction.East,Direction.North,Direction.North,Direction.North,Direction.North,Direction.West },
            { Direction.North,Direction.North,Direction.East,Direction.North,Direction.North,Direction.North,Direction.East,Direction.North },
            { Direction.North,Direction.West,Direction.West,Direction.West,Direction.West,Direction.West,Direction.West,Direction.South },
            { Direction.North,Direction.West,Direction.West,Direction.West,Direction.West,Direction.West,Direction.West,Direction.Win },
        };



        //static Direction[,] board = new Direction[,]
        //    {
        //        { Direction.North, Direction.North,Direction.North,Direction.North,Direction.North,Direction.North,Direction.North,Direction.North },
        //        { Direction.East, Direction.East,Direction.North,Direction.South,Direction.North,Direction.North,Direction.West,Direction.West },
        //        { Direction.East, Direction.East,Direction.North,Direction.East,Direction.West,Direction.East,Direction.West,Direction.West },
        //        { Direction.East, Direction.East,Direction.North,Direction.East,Direction.North,Direction.North,Direction.West,Direction.West },
        //        { Direction.East, Direction.East,Direction.North,Direction.East,Direction.North,Direction.North,Direction.West,Direction.West },
        //        { Direction.East, Direction.East,Direction.East,Direction.East,Direction.North,Direction.North,Direction.West,Direction.West },
        //        { Direction.East, Direction.East,Direction.North,Direction.South,Direction.North,Direction.East,Direction.West,Direction.West },
        //        { Direction.South, Direction.East,Direction.East,Direction.East,Direction.East,Direction.East,Direction.South,Direction.Win }
        //    };
    }
}
