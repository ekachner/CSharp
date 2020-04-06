using System;

namespace CricketScores
{
    public class SortOptions
    {
        public static void HighToLow(Player[] arr)
        {
            bool swap;
            do
            {
                swap = false;

                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i].Score < arr[i + 1].Score)
                    {
                        Player temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        swap = true;
                    }
                }
            } while (swap);
        }

        public static void LowToHigh(Player[] arr)
        {
            bool swap;
            do
            {
                swap = false;

                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i].Score > arr[i + 1].Score)
                    {
                        Player temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        swap = true;
                    }
                }
            } while (swap);
        }

        public static void ByFirstName(Player[] arr)
        {
            bool swap;
            do
            {
                swap = false;
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i].FirstName.CompareTo(arr[i + 1].FirstName) > 0)
                    {
                        Player temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        swap = true;
                    }
                }
            } while (swap);
        }

        public static void ByLastName(Player[] arr)
        {
            bool swap;
            do
            {
                swap = false;
                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i].LastName.CompareTo(arr[i + 1].LastName) > 0)
                    {
                        Player temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        swap = true;
                    }
                }
            } while (swap);
        }
    }
}
