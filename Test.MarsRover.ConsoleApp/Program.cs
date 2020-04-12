using System;
using Test.MarsRover.Core;

namespace Test.MarsRover.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MarsRoverManager manager = new MarsRoverManager();
            manager.Start();
            manager.WriteOutput();
            Console.ReadKey();
        }
    }
}
