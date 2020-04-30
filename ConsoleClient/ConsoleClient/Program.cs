using System;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ClientCaller caller = new ClientCaller();
            caller.CallServiceInParallel(500);
        }
    }
}
