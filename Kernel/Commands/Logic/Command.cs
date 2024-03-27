namespace Kernel.Commands.Logic
{
    public abstract class Command
    {
        public abstract string Name { get; }
        public abstract string Alias { get; }

        public abstract void Execute(string[] arguments);

    }
}
