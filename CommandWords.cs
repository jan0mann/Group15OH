using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationHav
{
    public class CommandWords
    {
        public List<string> ValidCommands { get; } = new List<string> {"accept", "refuse",  "check", "harbor", "north","east","south","west","back", "locals", "map", "help", "quit", "start", "plastic", "metal", "radioactive", "advise", "admit", "teach", "continue", "buy", "alternative" };

        public bool IsValidCommand(string command)
        {
            return ValidCommands.Contains(command);
        }
    }

}
