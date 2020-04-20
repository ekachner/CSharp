using System;

namespace HyperspaceCheeseBattle
{
    class Program
    {

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

        Direction boardsquare;
        boardsquare = Direction.Up;

        // 1D array that holds the player information
        static Player[] players = new Player[4];

        struct Player
        {
            public string Name;
            public int PositionX;
            public int PositionY;
        }

        // makes a move for the player given in playerNo
        private static void PlayerTurn(int playerNo)
        {
            

            int roll = RollDice();

            switch(Direction)
                case 0: Direction.Up + roll;


            
            

        }

        // reads in the player information for a new game
        static void ResetGame()
        {
            //each player moves back to (0,0)
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

        // returns true if there is a rocket in the specified square
        static bool RocketInSquare(int X, int Y)
        {
            
            return true;
        }


        static void Main(string[] args)
        {
            ResetGame();
        }
    }
}




//how do I mark the cheese squares
//