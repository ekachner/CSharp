using System;

namespace ZachBoardGame1
{
    class Program
    {
        class Player
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

            

            while (!GameOver)
            {
                MakeMoves();
                if (!GameOver)
                {
                    Console.WriteLine("Press return for next turns");
                }
                else if (GameOver)
                {
                    Console.WriteLine("Game is over");
                }
                Console.ReadLine();
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
            Random diceRandom = new Random();
            int spots = diceRandom.Next(1, 7);
            return spots;
        }

        static void PlayerTurn(Player player)
        {
            var moveLength = DiceThrow();
            Directions moveDirection = (Directions)board[player.Y, player.X];
            int newX = player.X;
            int newY = player.Y;


            if (moveDirection == Directions.Up)
            {
                newX = player.X;
                newY = player.Y + moveLength;
                if (newY > 7)
                {
                    Console.WriteLine("You are out of bounds on the board.  Remain on this square.");
                    return;
                }
            }
            else if (moveDirection == Directions.Down)
            {
                newX = player.X;
                newY = player.Y - moveLength;
                if (newY < 0)
                {
                    Console.WriteLine("You are out of bounds on the board.  Remain on this square.");
                    return;
                }
            }
            else if (moveDirection == Directions.Right)
            {
                newX = player.X + moveLength;
                newY = player.Y;
                if (newX > 7)
                {
                    Console.WriteLine("You are out of bounds on the board.  Remain on this square.");
                    return;
                }
            }
            else if (moveDirection == Directions.Left)
            {
                newX = player.X - moveLength;
                newY = player.Y;
                if (newX < 0)
                {
                    Console.WriteLine("You are out of bounds on the board.  Remain on this square.");
                    return;
                }
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

            if ()
            {
                Console.WriteLine("Player " + player.Name + "has landed on a Cheese Powerup!");
                Console.WriteLine("They have the option to roll again or shoot rocket at another player.");
                if 
                Console.ReadLine()
            }




            if ((Directions)board[player.Y, player.X] == Directions.Win)
                GameOver = true;
            
            Console.WriteLine(moveDirection.ToString());
            Console.WriteLine("The dice throw is " + moveLength);
            ShowStatus(player);

            

        }

        static bool GameOver = false;
        
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

        static void MakeMoves()
        {
            int i;
            for (i = 0; i < players.Length; i++)
            {
                PlayerTurn(players[i]);
                if (GameOver == true)
                {
                    Console.WriteLine("Congratulations " + players[i].Name + " has won the game!");
                    return;
                }
            }
            
        }

        static void ResetGame()
        {
            for (int i = 0; i < players.Length; i++)
            {
                var playerNumber = i + 1;
                Console.WriteLine("Enter the name of player " + playerNumber + ": ");
                players[i] = new Player();
                players[i].Name = Console.ReadLine();
                players[i].X = 0;
                players[i].Y = 0;
            }

        }

        static void ShowStatus(Player player)
        {
            Console.WriteLine("Players " + player.Name + " new coordinates: " + player.X + "," + player.Y); 
        }

        static bool CheesePower(int X, int Y)
        {
            bool cheeseSquare = false;

            if ((X == 4 && Y == 1) || (X == 0 && Y == 3) || (X == 6 && Y == 4) || (X == 3 && Y == 5))
            {
                cheeseSquare = true;
            }
            return cheeseSquare;

        }
    }
}
