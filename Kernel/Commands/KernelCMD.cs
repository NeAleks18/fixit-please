using Kernel.Commands.Logic;
using System;
using System.Linq;

namespace Kernel.Commands
{
    public class KernelCommand : Command
    {
        public override string Name => "kernel";
        public override string Alias => "krnl";

        public override void Execute(string[] arguments)
        {
            if (arguments.Contains("-v") || arguments.Contains("--version"))
            {
                Terminal.Write($"Version Kernel: {Kernel.Version}", true, 3);
            }
            else if (arguments.Contains("-i"))
            {
                Terminal.Write($"CPU: {Cosmos.Core.CPU.GetCPUBrandString()}", true);
            }
            else if (arguments.Contains("-s") || arguments.Contains("--shutdown"))
            {
                Cosmos.System.Power.Shutdown();
            }
            else
            {
                Terminal.Write("using: kernel [option] \nexample: kernel -v", true, 3);
            }
        }
    }
}
