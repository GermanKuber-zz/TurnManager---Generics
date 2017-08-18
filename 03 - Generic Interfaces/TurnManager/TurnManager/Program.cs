using System;

namespace TurnManager
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: Utilizo generics para indicar que mis parametros seran del tipo string
            var turnManager = new TurnManagerQueue<string>(3);

            Read(turnManager);
            Write(turnManager);

            Console.ReadKey();
        }

        ///Metodo de lectura de lineas
        private static void Read(ITurnManager<string> turnManager)
        {
            while (true)
            {
                //Itero y leo lo que el usuario ingresa
                var value = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(value))
                    break;
                else
                    turnManager.Add(value);
            }
        }
        private static void Write(ITurnManager<string> turnManager)
        {

            while (!turnManager.IsEmpty())
            {
                //Mientras no sea Empty sigo iterando
                Console.WriteLine(turnManager.Get());
            }
        }
    }

}