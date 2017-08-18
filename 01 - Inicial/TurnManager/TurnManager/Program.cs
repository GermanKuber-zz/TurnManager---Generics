using System;

namespace TurnManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var turnManager = new TurnManager(3);
           
           
            while (true)
            {
                //Itero y leo lo que el usuario ingresa
                var value = Console.ReadLine();

                if (int.TryParse(value, out var parse))
                {
                    turnManager.Add(parse);
                }
                else
                {
                    break;
                }

            }
            while (!turnManager.IsEmpty())
            {
                //Mientras no sea Empty sigo iterando
                Console.WriteLine(turnManager.Get());
            }
            Console.ReadKey();
        }
    }

}