﻿using System;

namespace HyperspaceCheeseBattle
{
    class Program
    {
        // 1D array that holds the player information
        static Player[] players = new Player[4];



        static void Main(string[] args)
        {
            ResetGame(players);
        }


        // 2D array that holds the board
        static int[,] board = new int[,]
        {
            {0,2,2,2,2,2,0,0}, // row 0
            {2,2,1,0,1,2,3,3}, // row 1
            {2,2,2,2,1,1,3,3}, // row 2
            {2,2,2,2,1,1,3,3}, // row 3
            {2,2,1,2,1,1,3,3}, // row 4
            {2,2,1,2,3,2,3,3}, // row 5
            {2,2,1,0,1,1,3,3}, // row 6
            {1,1,1,1,1,1,1,1}  // row 7
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


        // reads in the player information for a new game
        static void ResetGame(Player[] players)
        {
            players[0] = new Player
            {
                Name = "Player1",
                PositionX = 0,
                PositionY = 0
            };

            players[1] = new Player
            {
                Name = "Player2",
                PositionX = 0,
                PositionY = 0
            };

            players[2] = new Player
            {
                Name = "Player3",
                PositionX = 0,
                PositionY = 0
            };

            players[3] = new Player
            {
                Name = "Player4",
                PositionX = 0,
                PositionY = 0
            };
        }


        // returns the value of the next dice throw
        static int RollDice()
        {
            //Random random = new Random();
            //int roll = random.Next(1, 7);
            //Console.WriteLine("You just rolled: " + roll);
            //return roll;

            return 1;
        }


        // makes a move for the player given in playerNo
        private static void PlayerTurn(int playerNo)
        {


            int roll = RollDice();
            playerNo = roll;

            //switch (Direction)
            //{
            //    case 0:
            //        MoveDown(roll);
            //        break;

            //    case 1:
            //        //MoveUp(roll);
            //        break;

            //    case 2:
            //        //MoveRight(roll);
            //        break;

            //    case 3:
            //        //MoveLeft(roll);
            //        break;

            //    default:
            //        //cheese square
            //        break;
            //}
        }


        static int MoveDown(int roll, int PositionY)
        {            
            PositionY -= roll;
            return PositionY;
        }

        static int MoveUp(int roll, int PositionY)
        {
            PositionY += roll;
            return PositionY;
        }

        static int MoveLeft(int roll, int PositionX)
        {
            PositionX -= roll;
            return PositionX;
        }

        static int MoveRight(int roll, int PositionX)
        {
            PositionX += roll;
            return PositionX;
        }


        

        

        // returns true if there is a rocket in the specified square
        static bool RocketInSquare(int X, int Y)
        {

            return true;
        }


        
    }
}




//how do I mark the cheese squares
//