using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationHav
{
    public class Command
    {
        public string Name { get; }

        public Command(string name, string? secondWord = null)
        {
            Name = name;
        }
    }
}
