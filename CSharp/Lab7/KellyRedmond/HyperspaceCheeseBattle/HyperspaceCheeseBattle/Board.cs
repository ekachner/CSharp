using System;
namespace HyperspaceCheeseBattle
{
        //enum Direction
        //{
        //    North,
        //    East,
        //    South,
        //    West,
        //    Win
        //};
    public class Board
    {
        public Board()
        {
        }


        //public static Direction[,] board = new Direction[,]
        //{
        //    { Direction.North,Direction.West,Direction.West,Direction.West,Direction.West,Direction.West,Direction.West,Direction.South },
        //    { Direction.North,Direction.West,Direction.West,Direction.West,Direction.West,Direction.West,Direction.West,Direction.West },
        //    { Direction.North,Direction.North,Direction.North,Direction.North,Direction.North,Direction.West,Direction.North,Direction.West },
        //    { Direction.North,Direction.South,Direction.East,Direction.West,Direction.West,Direction.West,Direction.South,Direction.West },
        //    { Direction.North,Direction.North,Direction.East,Direction.North,Direction.North,Direction.North,Direction.North,Direction.West },
        //    { Direction.North,Direction.North,Direction.East,Direction.North,Direction.North,Direction.North,Direction.East,Direction.North },
        //    { Direction.North,Direction.West,Direction.West,Direction.West,Direction.West,Direction.West,Direction.West,Direction.South },
        //    { Direction.North,Direction.West,Direction.West,Direction.West,Direction.West,Direction.West,Direction.West,Direction.Win },
        //};


        //public static void DisplayBoard()
        //{
        //    for (int i = 7; i >= Direction.North; i--)
        //    {
        //        for (int k = Direction.North; k <= 7; k++)
        //        {
        //            Console.Write($" {PrintDirection(board[i, k].ToString())}");
        //        }
        //        Console.WriteLine();
        //    }
        //}

        public static string PrintDirection(string direction)
        {
            return direction switch
                {
                    "North" => "^",
                    "East" => ">",
                    "South" => "v",
                    "West" => "<",
                    _ => throw new Exception("Invalid state"),
                };
        }
}
}
