using System;

namespace TurnManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var turnManager = new TurnManagerQueue<string>(3);

            Read(turnManager);

            //EachNames(turnManager);
            //Write(turnManager);
            //   Write<long>(turnManager);
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
            //TODO: 03 -  Llamo a mi ToEnumerable pasando como parametro una funciona lambda generica
            var listParser = turnManager.ToEnumerable<int>((string param) =>
            {
                int.TryParse(param, out var item);
                return item;
            });

            foreach (var item in listParser)
                Console.WriteLine(item);
        }
        // private static void Write<T>(ITurnManager<string> turnManager)
        // {
        //     var listParser = turnManager.ToEnumerable<T>();

        //     foreach (var item in listParser)
        //         Console.WriteLine(item);
        // }
        // private static void Write(ITurnManager<string> turnManager)
        // {

        //     while (!turnManager.IsEmpty())
        //     {
        //         //Mientras no sea Empty sigo iterando
        //         Console.WriteLine(turnManager.Get());
        //     }
        // }
        private static void EachNames(ITurnManager<string> turnManager)
        {

            foreach (var item in turnManager)
            {
                if (item == "Juan")
                    Console.WriteLine($"**{item}**");
                else
                    Console.WriteLine(item);
            }
        }
    }

}