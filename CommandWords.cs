using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationHav
{
    public class CommandWords
    {
        public List<string> ValidCommands { get; } = new List<string> { "north", "east", "south", "west", "look", "back", "quit", "help", "refuse", "accept", "situation", "harbor", "locals", "inventory", "map", "plastic", "metal", "radioactive" };// adding 4 more commands

        public bool IsValidCommand(string command)
        {
            return ValidCommands.Contains(command);
        }
    }

}
