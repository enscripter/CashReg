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
            new CommandLineRegisterInterpreter().Run();
        }
    }
}
