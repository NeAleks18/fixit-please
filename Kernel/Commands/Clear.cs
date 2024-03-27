using Kernel.Commands.Logic;
using System;

namespace Kernel.Commands
{
    public class ClearCommand : Command
    {
        public override string Name => "clear";
        public override string Alias => "clr";

        public override void Execute(string[] arguments)
        {
            Console.Clear();
        }
    }
}
