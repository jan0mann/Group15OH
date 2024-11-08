using System.Reflection.Metadata.Ecma335;
using OperationHav;

namespace OperationHav
{
    public class Island // ==> this is the headclass for every island; every class of each island inherits from this class
    {
        public string ShortDescription { get; set; }
        public string LongDescription { get; set;}
        public string Name { get; set;}
        public static bool MinigameWon { get; set;}

        public Dictionary<string, Island> Exits { get; set; } = new();

        public Island(string name, string shortDesc, bool minigameWon)
        {
            Name = name;
            ShortDescription = shortDesc;
            MinigameWon = minigameWon;
        }

         public static void Main_Locals() // I (Noah) think methods for texts are better, because that way we have more freedom using text color, delays etc.
        {
            Console.WriteLine("\nOnce a beautiful paradise, now it is on the brink of becoming a wasteland. \nThere is a harbor nearby, as well as the markedplace, where the locals and their knowledge can be found. \nHere the consequences of all other problems, carry over.");
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
    // Here ends the headclass for all the islands. 



    // Below you'll find the subclasses for each island:


    //Bartek and Noah, please use this class for your island/minigame
    public class IslandIndustrial : Island 
    {   
        public IslandIndustrial(string name, string shortDesc, bool minigameWon) : base(name, shortDesc, minigameWon)
        {
            Name = name;
            ShortDescription = shortDesc;
            MinigameWon = minigameWon;
        }

        public static void Locals() // I (Noah) think methods for texts are better, because that way we have more freedom using text color, delays etc.
        {
            Console.WriteLine("\nThis island suffers from extreme industrial waste, \nbecause it used to serve as a secret industrial outpost to the Soviet-Union during the Cold War. \nEver since the latter fell, however, no one came to clean, or even dismantle the old facilities, \nleaving our island and its surrounding waters a gigantic junkyard ...");
        }

        //You might wanne use this method here for the minigame itself
        public static void Story_Minigame()
        {
            Console.WriteLine("On the shore of the island, you meet an old man.\n You find out that the old factories have polluted the local environment and you need to clean it up.\n Having received from the UN the anti-hazardous suit and special containers, you decide to do it right away.\n");
            Thread.Sleep(4000);

            int minigamePoints = 0;

            Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                string[] wasteTypes = {"plastic", "metal", "radioactive"};
                string pickedWaste = wasteTypes[random.Next(wasteTypes.Length)];

                Console.WriteLine($"You have picked up {pickedWaste} waste. \nWhich container will you put it in? (plastic, metal, radioactive):\n");
                var container = Console.ReadLine()?.ToLower();

                if (container == pickedWaste)
                {
                    Console.WriteLine("Correct! You have placed the waste in the right container.\n");
                    Thread.Sleep(2000);
                    minigamePoints++;
                }
                else
                {
                    Game.InvalidCommand();
                }
            }
                
            if (minigamePoints < 3)
            {

                Console.WriteLine("You scored less than 5 points.");
                Thread.Sleep(3000);
                Game.GameOver();// Quit the game
            }
            else
            {
                Game.MinigameVictory();
                MinigameWon = true;
            }

        }
    }



        //Marcel and Jan, please use this class for your island/minigame
       public class IslandOil : Island 
    {   
        public IslandOil(string name, string shortDesc, bool minigameWon) : base(name, shortDesc, minigameWon)
        {
            Name = name;
            ShortDescription = shortDesc;
            MinigameWon = minigameWon;
        }
        public static void Locals() // I (Noah) think methods for texts are better, because that way we have more freedom using text color, delays etc.
        {
            Console.WriteLine("\nDue to major American trade routes near the island, a lot of spilled oil has gathered around the island, contaminating its waters…");
        }

        //You might wanne use this method here for the minigame itself
        public static void Story_Minigame()
        {

        }
    }



        //serafeim and Darius, please use this class for your island/minigame
       public class IslandPlastic : Island 
    {   
        public IslandPlastic(string name, string shortDesc, bool minigameWon) : base(name, shortDesc, minigameWon)
        {
            Name = name;
            ShortDescription = shortDesc;
            MinigameWon = minigameWon;
        }

        public static void Locals() // I (Noah) think methods for texts are better, because that way we have more freedom using text color, delays etc.
        {
            Console.WriteLine("\nThis island is closest to the Asian mainland, making it a collecting point for huge quantities of Chinese plastic waste…");
        }

        //You might wanne use this method here for the minigame itself
        public static void Story_Minigame()
        {

        }
    }



     //On this island/minigame, we all work together (Darius can create the maze for this game now, of course)
       public class IslandCoral : Island 
    {   
        public IslandCoral(string name, string shortDesc, bool minigameWon) : base(name, shortDesc, minigameWon)
        {
            Name = name;
            ShortDescription = shortDesc;
            MinigameWon = minigameWon;
        }

        public static void Locals() // I (Noah) think methods for texts are better, because that way we have more freedom using text color, delays etc.
        {
            Console.WriteLine("\nIt is the only island affected by more than one problem, and those happen to be the ones of ALL the other islands! And to make things even worse, it is exactly there where our biggest and most important coral reef is located! Somebody needs to do something before it dies off…");
        }

        //We might wanne use this method here for the minigame itself
        public static void Story_Minigame()
        {

        }
    }
}
