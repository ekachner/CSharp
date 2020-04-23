using System;

namespace ZachBoardGame1
{
    class Program
    {
        struct Player
        {
            public string Name;
            public int X;
            public int Y;
            public Directions Move;
        }
        enum Directions
        {
            Up = 1,
            Down = 2,
            Left = 3,
            Right = 4,
            Win = 0
        };

        static Player[] players = new Player[4];

        static void Main(string[] args)
        {
            ResetGame();

            for (int i = 0; i < players.Length; i++)
            {
               players[i] = PlayerTurn(players[i]);
            }
          
        }

        static int[,] board = new int[,]
        {
            {1,1,1,1,1,1,1,1}, // row 0
            {4,4,1,2,1,1,3,3}, // row 1
            {4,4,1,4,3,4,3,3}, // row 2
            {4,4,1,4,1,1,3,3}, // row 3
            {4,4,1,4,1,1,3,3}, // row 4
            {4,4,4,4,1,1,3,3}, // row 5
            {4,4,1,2,1,4,3,3}, // row 6
            {2,4,4,4,4,4,2,0}  // row 7
        };

        static int DiceThrow()
        {
            return 1;
        }

        static Player PlayerTurn(Player player)
        {
            var moveLength = DiceThrow();
            Directions moveDirection = (Directions)board[player.Y, player.X];
            int newX = player.X;
            int newY = player.Y;

         
            if (moveDirection == Directions.Up)
            {
                newX = player.X;
                newY = player.Y + moveLength;
            }
            else if (moveDirection == Directions.Down)
            {
                newX = player.X;
                newY = player.Y - moveLength;
            }
            else if (moveDirection == Directions.Right)
            {
                newX = player.X + moveLength;
                newY = player.Y;
            }
            else if (moveDirection == Directions.Left)
            {
                newX = player.X - moveLength;
                newY = player.Y;
            }


            bool rocketInSquare = RocketInSquare(newX, newY);
            

            if (rocketInSquare)
            {
                do
                {
                    Directions newMoveDirection = (Directions)board[newY, newX];

                    if (newMoveDirection == Directions.Up)
                        newY += 1;
                    else if (newMoveDirection == Directions.Down)
                        newY -= 1;
                    else if (newMoveDirection == Directions.Right)
                        newX += 1;
                    else if (newMoveDirection == Directions.Left)
                        newX -= 1;
                    rocketInSquare = RocketInSquare(newX, newY);
                    
                }
                while (rocketInSquare);
            }
            player.X = newX;
            player.Y = newY;
            Console.WriteLine("Players " + player.Name + " new coordinates: " + player.X + "," + player.Y);
            return player;
        } 



        static bool RocketInSquare(int X, int Y)
        {
            bool playerInSquare = false;

            for (int i = 0; i < players.Length; i++)
            {
                if (players[i].X == X && players[i].Y == Y)
                {
                    playerInSquare = true;
                    break;
                }
            }
            

            return playerInSquare;

        }

        static void ResetGame()
        {
            for (int i = 0; i < players.Length; i++)
            {
                var playerNumber = i + 1;
                Console.WriteLine("Enter the name of player " + playerNumber + ": ");
                players[i].Name = Console.ReadLine();
                players[i].X = 0;
                players[i].Y = 0;
            }
            
        }

        static void ShowStatus()
        {

        }
    }
}
