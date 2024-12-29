using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OperationHav
{
    public class CommandWords
    {
        public List<string> ValidCommands { get; } = new List<string> { "accept", "refuse", "harbor", "quit", "start", "info", "north","east","south","west","back","plastic", "metal", "rubber", "hardware", "atomic", "advise", "admit", "teach", "continue", "buy", "alternative", "join", "ridicule", "videogame", "presentation" };

        public bool IsValidCommand(string command)
        {
            return ValidCommands.Contains(command);
        }
    }

}
