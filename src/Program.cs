using System;
using System.Collections.Generic;
using System.Linq;
using CashReg.objects;

namespace CashReg
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Welcome to CashReg type \"help\" to see more info");
            new CommandLineRegisterInterpreter().Run();
        }
    }
}
