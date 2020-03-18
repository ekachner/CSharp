using System;

namespace Potato
{
    class Program
    {
        static void Main(string[] args)
        {
            RequestPotatoWeight();
        }

        static void RequestPotatoWeight()
        {
            int potatoGrms;
            string potatoInput;
            Console.WriteLine("How much does your potato weigh in gms?");
            potatoInput = Console.ReadLine();

            bool result = int.TryParse(potatoInput, out potatoGrms);

            if (result)
            {
                if (potatoGrms > 0 && potatoGrms < 200)
                {
                    Console.WriteLine("Your potato's grade is X");
                } else if (potatoGrms >= 200 && potatoGrms < 400)
                {
                    Console.WriteLine("Your potato's grade is A");
                } else if (potatoGrms >= 400 && potatoGrms <= 800)
                {
                    Console.WriteLine("Your potato's grade is B");
                } else if (potatoGrms > 800)
                {
                    Console.WriteLine("Your potato's grade is Z");
                }
            } else
            {
                Console.WriteLine("Invalid entry. Do not include the units (gm) in your entry.");
                RequestPotatoWeight();
            }

        }
    }
}
