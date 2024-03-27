using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace Kernel
{
    public class Kernel : Sys.Kernel
    {
        public static readonly string Version = "0.1";

        protected override void BeforeRun()
        {
            Terminal.InitTerminal();
        }

        protected override void Run()
        {
            Terminal.RunTerminal();
        }
    }
}
