using System;

namespace Week12Lab_PotatoGrading
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The following potato (looking at you, Brett) weight grades are given below:");
            Console.WriteLine("Less than 200 gms – Grade X");
            Console.WriteLine("Between 200 and 400 gms – Grade A");
            Console.WriteLine("Between 400 and 800 gms – Grade B");
            Console.WriteLine("Above 800 gms – Grade Z");
            Console.WriteLine("Document results:");
            string PotatoInput = Console.ReadLine();
            int Potato = int.Parse(PotatoInput);

            if (Potato < 200)
            {
                Console.WriteLine("This potato weighs " + PotatoInput + " gms, and is therefore Grade X.");
            } else if (Potato >= 200 && Potato <= 400)
            {
                Console.WriteLine("This potato weighs " + PotatoInput + " gms, and is therefore Grade A.");
            } else if (Potato >= 400 && Potato <= 800)
            {
                Console.WriteLine("This potato weighs " + PotatoInput + " gms, and is therefore Grade B.");
            } else if (Potato > 800)
            {
                Console.WriteLine("This potato weighs " + PotatoInput + " gms, and is therefore Grade Z.");
            } else
            {
                Console.WriteLine("ERROR: Insufficient Value.");
            }
        }
    }
}
