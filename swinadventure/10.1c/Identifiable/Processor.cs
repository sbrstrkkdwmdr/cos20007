using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identifiable
{
    public class Processor
    {
        private Command? _command;
        private List<Command> _commands;

        public Processor()
        {
            _commands = new List<Command>()
            {
                new LookCommand(),
                new MoveCommand(),
            };
        }
        public string Execute(string[] args, Player p)
        {
            switch (args[0]) // check for command based on input
            {
                case "exit": //terminate program
                case "q":
                case "end":
                    ProgramExit();
                    break;
                case "look": // look command
                    _command = _commands[0];
                    break;
                case "move":
                case "go":
                case "head":
                case "leave":// move command
                    _command = _commands[1];
                    break;
                default: // if invalid command, throw an error
                    throw new Exception($"{args[0]} is not a valid command!\nTry again.");
            }
            string output = _command!.Execute(p, args);
            return output;
        }
        private static void ProgramExit()
        {
            Console.WriteLine("Closing program...");
            Environment.Exit(0);
        }
    }
}
