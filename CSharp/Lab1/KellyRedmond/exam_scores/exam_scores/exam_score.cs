using System;
using static System.Console;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace exam_scores
{
    public struct ExamScore
    {
        public int MinScore;
        public int MaxScore;
        public string Classification;

        public ExamScore(int minScore, int maxScore, string classification)
        {
            MinScore = minScore;
            MaxScore = maxScore;
            Classification = classification;
        }
    }


    public class UserScore
    {
        public int Mark { get; set; }
        public string Degree { get; set; }
    }

    class Program
    {
        static int NumberInput(string prompt, int min, int max)
        {
            int input = 0;

            do
            {
                Write(prompt);
                string numberString = ReadLine();
                input = int.Parse(numberString);
                if (input < min || input > max)
                {
                    WriteLine($"Please input a value between {min} and {max}");
                } else
                {
                    break;
                }
            } while (true);

            return input;
        }

        static string StringInput(string prompt, string value1, string value2)
        {
            string input;

            do
            {
                Write(prompt);
                input = ReadLine().ToUpper();
                if (input == value1 || input == value2)
                {
                    break;
                } else
                {
                    WriteLine($"Please enter a {value1} or {value2}");
                }
            } while (true);

            return input;
        }

        static void Main()
        {
            ArrayList examScores = new ArrayList();

            examScores.Add(new ExamScore (0, 35, "Fail"));
            examScores.Add(new ExamScore (35, 40, "Can be \"compensated\""));
            examScores.Add(new ExamScore (40, 50, "Third class degree - III"));
            examScores.Add(new ExamScore (50, 60, "Lower second class degree - II(ii)"));
            examScores.Add(new ExamScore (60, 70, "Upper second class degree - II(i)"));
            examScores.Add(new ExamScore (70, 100, "First class degree - I"));

            string addAnotherScore;

            var userScores = new List<UserScore>();

            do
            {
                int score = NumberInput("Please enter your mark: ", 0, 100);

                var scoreQuery = from ExamScore es in examScores
                                 where es.MaxScore > score && score >= es.MinScore
                                 select es;

                var degreeName = "a";

                foreach (ExamScore es in scoreQuery)
                {
                    WriteLine(es.Classification);
                    degreeName = es.Classification;
                }

                userScores.Add(new UserScore { Mark = score, Degree = degreeName });

                addAnotherScore = StringInput("Would you like to enter another mark? ( Y / N ): ", "Y", "N");

            } while (addAnotherScore == "Y");

            string printScores = StringInput("Would you like to print the marks entered? ( Y / N ): ", "Y", "N");

            if (printScores == "Y")
            {
                WriteLine("Mark\tDegree Classification");
                foreach (var user in userScores)
                {
                    WriteLine(user.Mark + "\t" + user.Degree);
                }
            }
        }
    }
}