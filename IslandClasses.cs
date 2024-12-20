using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using OperationHav;

namespace OperationHav
{
    public class Island // headclass for every island
    {
        //public string LongDescription { get; set; }
        public string ShortDescription { get; set; }
        public string Name { get; set; }

        public Dictionary<string, Island> Exits { get; set; } = new();

        public Island(string name, string shortDesc)
        {
            Name = name;
            ShortDescription = shortDesc;
        }

        public void SetExits(Island? north, Island? east, Island? south, Island? west)
        {
            SetExit("north", north);
            SetExit("east", east);
            SetExit("south", south);
            SetExit("west", west);
        }

        public void SetExit(string direction, Island? neighbor)
        {
            if (neighbor != null)
                Exits[direction] = neighbor;
        }
    }
} 

