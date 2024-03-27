using Kernel.Commands.Logic;
using System;
using System.Linq;
using System.Reflection;

namespace Kernel
{
    public static class Terminal
    {
        private static ConsoleColor DefaultTextColor = ConsoleColor.White;

        private static Command[] commands;

        static Terminal()
        {
            var commandTypes = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsSubclassOf(typeof(Command)) && !t.IsAbstract);
            commands = commandTypes.Select(t => (Command)Activator.CreateInstance(t)).ToArray();
        }

        private static Command FindCommand(string cmd)
        {
            var command = commands.FirstOrDefault(c => c.Name == cmd);
            if (command != null)
            {
                return command;
            }

            // Try to find the command with an alias if the initial search returns null
            return commands.FirstOrDefault(c => c.Alias != null && c.Alias.ToLower() == cmd.ToLower());
        }

        public static void ClearAndInit()
        {
            Console.Clear();
            Console.WriteLine("Welcome to C# OS by everyofflineuser version 0.1");
        }

        public static void InitTerminal()
        {
            ClearAndInit();
        }

        public static void Write(string output, bool newline, short color = 0)
        {
            // NOT WORKING: Encoding not change. Cyrillic not supported.
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Setting Color
            switch (color)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;

                case 2:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;

                case 3:
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;

                case 4:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;

                case 5:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;

                case 6:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;

                case 7:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;

                case 8:
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }

            // Checking New Line?
            if (newline) Console.WriteLine(output);
            else Console.Write(output);

            // Set Color to Default
            if (color != 0) Console.ForegroundColor = DefaultTextColor;
        }

        public static void Execute(string fullcmd)
        {
            var cmd = fullcmd.Split(' ')[0];
            var arguments = fullcmd.Split(' ').Skip(1).ToArray();

            var command = FindCommand(cmd);
            if (command != null)
            {
                command.Execute(arguments);
            }
            else
            {
                Write(fullcmd + ": Unknown command. Please contact us.", true, 4);
            }
        }

        public static void RunTerminal()
        {
            Console.InputEncoding = System.Text.Encoding.UTF8;
            Write("$Kernel SHELL ", false, 3);
            Write(">> ", false, 7);
            var cmd = Console.ReadLine();

            Execute(cmd);
        }
    }
}
