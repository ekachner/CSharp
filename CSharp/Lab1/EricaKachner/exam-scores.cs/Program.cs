using System;

namespace exam_scores.cs
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter your exam score to retrieve your degree classification: ");
            string examScore = Console.ReadLine();
            int score = int.Parse(examScore);

            if(score > 100 || score < 0)
            {
                Console.WriteLine("This is not a valid exam score");
            }

            if(score >= 70 && score <= 100)
            {
                Console.WriteLine("Congratulations! You earned a First Class Degree - I");
            }

            if (score >= 60 && score < 70)
            {
                Console.WriteLine("You earned an Upper Second Class Degree - II(i)");
            }

            if (score >= 50 && score < 60)
            {
                Console.WriteLine("You earned a Lower Second Class Degree - II(ii)");
            }

            if (score >= 40 && score < 50)
            {
                Console.WriteLine("You earned a Third Class Degree - III");
            }

            if (score >= 35 && score < 40)
            {
                Console.WriteLine("You earned a \"compensational\" degree");
            }

            if (score < 35)
            {
                Console.WriteLine("Exam Failed.");
            }
        }
    }
}

