using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What is your name ?");
            var name = Console.ReadLine();
            var date = DateTime.Now;

            Console.WriteLine($"\n Hello, {name}, on {date:d} , at {date:t} !");
            Console.Write("Press any key to enter ..");

            Console.ReadKey(true);

        }
    }
}
