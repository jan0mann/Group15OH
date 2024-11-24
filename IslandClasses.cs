using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using OperationHav;

namespace OperationHav
{
    public class Island // ==> this is the headclass for every island; every class of each island inherits from this class
    {
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Name { get; set; }
        public static bool MinigameWon { get; set; }

        public Dictionary<string, Island> Exits { get; set; } = new();

        public Island(string name, string shortDesc, bool minigameWon)
        {
            Name = name;
            ShortDescription = shortDesc;
            MinigameWon = minigameWon;
        }

        public static void Main_Locals() // I (Noah) think methods for texts are better, because that way we have more freedom using text color, delays etc.
        {
            Game.Text("\nOnce a beautiful paradise, now it is on the brink of becoming a wasteland. \nThere is a harbor nearby, as well as the markedplace, where the locals and their knowledge can be found.", 4);
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
            Game.Text("\nNear the shore you meet an old man, who used to work in the factories.", 3);
            Game.Text("\nYou start asking him about those old factories, which litter the entire island in trash.\nHe explains:", 1);
            Game.Text("\nOslø has been suffering for decades now from extreme industrial waste, \nbecause it used to serve as a secret industrial outpost to the Soviet-Union during the Cold War.", 3, ConsoleColor.DarkGreen);
            Game.Text("\nEver since the latter fell, however, no one came to clean, or even dismantle all those facilities, \nleaving our island and its surrounding waters a gigantic junkyard ...", 3, ConsoleColor.DarkGreen);
        }


        //You might wanne use this method here for the minigame itself
        public static void Story_Minigame()
        {
            // STORY/INTRODUCTION
            Game.Text("\nYou go to meet with the local UN referant at the biggest factory, who has been analysing the situation.", 3);
            Game.Text("\nHe speaks to you:", 1);
            Game.Text("\nWelcome! Thank you so much for agreeing to help!", 2, ConsoleColor.DarkGreen);
            Game.Text("\nThe UN supplied us with anti-hazardous suits, as well as special containers, which are provided directly by the spot.", 3, ConsoleColor.DarkGreen);
            Game.Text("\nYou put on the suit and you two walk straight into the old rusty facility...", 2);
            Game.Text("\nAll of a sudden, the building starts to shake!", 2);
            Game.Text("\nThe referant, who is still standing outside, shouts:", 2);
            Game.Text("\nDon't panic! I'll get you help! But you need to put the waste in the correct container in there!", 3, ConsoleColor.DarkGreen);
            Game.Text("\nRemember: \nYellow belongs to 'plastic'! \nGrey to 'metal'! \nGreen to 'atomic'! \nBlue to 'rubber'! \nAnd magenta to 'hardware'! \n\nGood luck!", 5, ConsoleColor.DarkGreen);
            Game.Text("\n You look around...", 2);
            Game.Text("\nSort the waste? Now??", 2, ConsoleColor.Cyan);




            //GAME START
            int minigamePoints = 0;

            Random random = new();

            for (int i = 0; i < 10; i++)
            {
                string[] wasteTypes = ["plastic", "metal", "atomic", "rubber", "hardware"];
                string pickedWaste = wasteTypes[random.Next(wasteTypes.Length)];


                Game.Text("\nYou have picked up some ", 0);
                switch (pickedWaste)
                {
                    case "plastic":
                        Game.Text("waste", 0, ConsoleColor.DarkYellow);
                        break;
                    case "metal":
                        Game.Text("waste", 0, ConsoleColor.DarkGray);
                        break;
                    case "atomic":
                        Game.Text("waste", 0, ConsoleColor.Green);
                        break;
                    case "rubber":
                        Game.Text("waste", 0, ConsoleColor.DarkBlue);
                        break;
                    case "hardware":
                        Game.Text("waste", 0, ConsoleColor.DarkMagenta);
                        break;
                }
                Game.Text(". Which container does it belong to? (type the word):\n", 0);

                string? container = Console.ReadLine()?.ToLower();

                if (container == pickedWaste)
                {
                    Game.Text("\nCorrect! \nYou have placed the waste in the right container.", 2);
                    minigamePoints++;
                }
                else if (container != pickedWaste)
                {
                    Game.Text("\nNo! \nThats the wrong container!", 2);
                }
                else
                    Game.InvalidCommand();

            }

            if (minigamePoints < 7)
            {
                Game.Text("\n...", 2);
                Game.Text("\nYou've put too much waste in the wrong containers...", 0);
                Game.GameOver();
                Game.Text("Do you want to retry? (y/n)\n", 1);
                string? yN = Console.ReadLine()?.ToLower();
                switch (yN)
                {
                    case "y":
                        Story_Minigame();
                        break;
                    case "n":
                        Environment.Exit(0);
                        break;
                    default:
                        Game.InvalidCommand();
                        break;
                }

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
            Game.Text("\nDue to major American trade routes near the island, a lot of spilled oil has gathered around the island, contaminating its waters…", 4);
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
            Game.Text("\nThis island is closest to the Asian mainland, making it a collecting point for huge quantities of Chinese plastic waste…", 3);
            Game.Text("\nAfter reaching the shore and walking around a bit, you spot a figure not far away. You approach a man that looks more sophisticated than the average citizen. ", 5);
            Game.Text("\nYou greet each other and he tells you that he was a teacher on this island, before it was made a plastic wasteland. He comes here when he needs some time alone to think.", 6);
            Game.Text("\nYou ask him if there is anything to be done for the island to gain its former glory. He gives you some insight:", 1);
            Game.Text("\nIn the recent history of this insular republic, two parties have been fighting for the balance of power:", 3);
            Game.Text("\nThe corporations ", 1, ConsoleColor.Yellow);
            Game.Text("and the ", 1);
            Game.Text("environmentalists.", 1, ConsoleColor.Green);
            Game.Text("\nCorporations' goals are to make money, the health of the ecosystem is not in their agenda.", 3);
            Game.Text("\nTheir view on the environmentalists is, that they are a group of fearmongerers that are overreacting on the small damage done and that the ecosystem will eventually fix itself.", 5);
            Game.Text("\nThe environmentalists strive to mitigate the damage done to the ecosystem and plan to reverse some of its negative consequences.", 4);
            Game.Text("\nThose people hate the corporations with all their heart. They think they are blinded by their greediness and that their goals are futile, since no one takes their wealth to their grave.", 5);
            Game.Text("\nWe must act quickly and support the correct side of history before it's too late. You know what to do...", 1);

        }

        //You might wanne use this method here for the minigame itself
        public static void Story_Minigame()
        {
            Game.Text("\n\n\nYou are now called to make decisions for the future of the island.", 3);
            Game.Text("\nWith your succeess over the improvement of the situation on the other islands, you have gained the trust of the locals.", 4);
            Game.Text("\nThe citizens will follow your guidance and example.", 3);
            Game.Text("\nEach of the two parties exerts influence on the island and its people.", 3);
            Game.Text("\nWith your choices, you change the balance of power by taking actions that support each party.", 3);
            Game.Text("\nThe side that has the most support of the population, will decide the republics policies.", 4);
            Game.Text("\nWho will you support?", 3, ConsoleColor.Blue);

            Corporations corporations = new("Industrial Assosiation", 0);
            Environmentalists environmentalists = new("Green Syndicate", 0);
            for (int i = 0; 1 < 5; i++)
            {
                if (i == 0)
                {
                    Game.Text("\nYou have been invited for an interview at the biggest broadcasting channel on the island", 3);
                    Game.Text("\nAt some point the interviewer asks you about your opinion on plastic", 3);
                    Game.Text("\nYou can either ", 1);
                    Game.Text("\nadmit ", 0, ConsoleColor.Yellow);
                    Game.Text("\nthat plastic does not pose that much of a threat or ", 0);
                    Game.Text("\nadvise ", 0);
                    Game.Text("\nit's use with caution.", 3, ConsoleColor.Green);
                    string answer = Console.ReadLine();

                    if (answer == "admit")
                    {
                        corporations.Influence = 1;
                    }
                    else if (answer == "advise")
                    {
                        environmentalists.Influence = 1;
                    }
                    else
                    {
                        Game.InvalidCommand();
                    }

                }

                if (i == 1)
                {

                }

                if (i == 2)
                {

                }

                if (i == 3)
                {

                }

                if (i == 4)
                {

                }

            }

            if (corporations.Influence > environmentalists.Influence)
            {

            }


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
            Game.Text("\nIt is the only island affected by more than one problem, and those happen to be the ones of ALL the other islands! And to make things even worse, it is exactly there where our biggest and most important coral reef is located! Somebody needs to do something before it dies off…", 7);
        }

        //We might wanne use this method here for the minigame itself
        public static void Story_Minigame()
        {

        }
    }
}
