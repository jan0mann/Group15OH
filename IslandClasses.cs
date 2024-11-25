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
            Game.Text("\nDon't panik! I'll get you help! But you need to put the waste in the correct container in there!", 3, ConsoleColor.DarkGreen);
            Game.Text("\nRemember: \nYellow belongs to 'plastic'! \nGrey to 'metal'! \nGreen to 'atomic'! \nBlue to 'rubber'! \nAnd magenta to 'hardware'! \n\nGood luck!", 5, ConsoleColor.DarkGreen);
            Game.Text("\n You look around...", 2);
            Game.Text("\nSort the waste? Now??", 2, ConsoleColor.Cyan);




            //GAME START
            int minigamePoints = 0;
            Random random = new();
            Dictionary<string, int> wasteCount = new() // implementing the dictionary to see how many times each waste type was selected
{
    { "plastic", 0 },
    { "metal", 0 },
    { "atomic", 0 },
    { "rubber", 0 },
    { "hardware", 0 }
};

            for (int i = 0; i < 10; i++)
            {
                // Filter out waste types that have been selected twice
                var availableWasteTypes = wasteCount.Where(w => w.Value < 2).Select(w => w.Key).ToArray(); // for now this removes waste from pool after it was generated twice but i dont know how it exactly works( used AI)


                string pickedWaste = availableWasteTypes[random.Next(availableWasteTypes.Length)];
                wasteCount[pickedWaste]++; // counting the waste

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

                    if (pickedWaste == "plastic" && wasteCount[pickedWaste] == 1) // adding the text after correctly typed waste
                    {
                        Game.Text("\n It is very important to clean up this plastic. 100,000 marine animals die from plastic pollution every year,\n so by picking this up we contribute to reducing these numbers. ", 2, ConsoleColor.DarkYellow);
                    }

                    if (pickedWaste == "plastic" && wasteCount[pickedWaste] == 2)
                    {
                        Game.Text("\n We need to remember that 1 in 3 fish caught for human consumption contains plastic.\n This may lead to very serious health issues so we need to make sure all of this is cleaned.  ", 2, ConsoleColor.DarkYellow);
                    }

                    if (pickedWaste == "metal" && wasteCount[pickedWaste] == 1)
                    {
                        Game.Text("\n Good job picking up this copper. Its very toxic to marine organisms.", 2, ConsoleColor.DarkGray);
                    }

                    if (pickedWaste == "metal" && wasteCount[pickedWaste] == 2)
                    {
                        Game.Text("\n You removed all the lead from the water!.\n It is highly toxic to marine life and affects the reproduction, you did very good job finding and removing it.", 2, ConsoleColor.DarkGray);
                    }

                    if (pickedWaste == "atomic" && wasteCount[pickedWaste] == 1)
                    {
                        Game.Text("\nsome text", 2, ConsoleColor.Green);
                    }

                    if (pickedWaste == "atomic" && wasteCount[pickedWaste] == 2)
                    {
                        Game.Text("\nsome text", 2, ConsoleColor.Green);
                    }

                    if (pickedWaste == "rubber" && wasteCount[pickedWaste] == 1)
                    {
                        Game.Text("\nsome text", 2, ConsoleColor.DarkBlue);
                    }

                    if (pickedWaste == "rubber" && wasteCount[pickedWaste] == 2)
                    {
                        Game.Text("\nsome text", 2, ConsoleColor.DarkBlue);
                    }

                    if (pickedWaste == "hardware" && wasteCount[pickedWaste] == 1)
                    {
                        Game.Text("\nsome text", 2, ConsoleColor.DarkMagenta);
                    }

                    if (pickedWaste == "hardware" && wasteCount[pickedWaste] == 2)
                    {
                        Game.Text("\nsome text", 2, ConsoleColor.DarkMagenta);
                    }
                }
                else
                {
                    Game.Text("\nNo! \nThat's the wrong container!", 2);
                }
            }

            if (minigamePoints < 7)
            {
                Game.Text("\n...", 2);
                Game.Text("\nYou've put too much waste in the wrong containers...", 0);
                Game.GameOver();
                Console.Clear();
                Game.Text("Do you want to retry? (y/n)\n", 1);
                string? yN = Console.ReadLine()?.ToLower();
                switch (yN)
                {
                    case "y":
                        Story_Minigame();
                        break;
                    case "n":
                        Console.Clear();
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
        // Define the dimensions and position of the display area
        private static int areaTop = 5;
        private static int areaHeight = 10;
        private static int areaWidth = 40;

        private static List<string> displayArea = new List<string>();

        // Position of the character
        private static int charX = 0;
        private static int charY = 0;

        // Random generator
        private static Random random = new Random();

        // Special characters and their positions
        private static Dictionary<(int x, int y), char> specialCharacters = new Dictionary<(int x, int y), char>();

        // Score counter
        private static int score = 0;
        private const int maxScore = 20;

        // Movement delay
        private const int movementDelay = 10; // Milliseconds

        public static void Story_Minigame()
        {
            Game.minigame = true;
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear(); // Ensure background is fully colored

            InitializeDisplayArea();

            // Place the character initially
            MoveCharacter(charX, charY);

            // Spawn initial special characters
            SpawnSpecialCharacter();

            // Start movement loop
            MovementLoop();
        }

        static void InitializeDisplayArea()
        {
            for (int i = 0; i < areaHeight; i++)
            {
                displayArea.Add(new string('░', areaWidth)); // Fill with empty lines
            }

            RenderDisplayArea();
        }

        static void RenderDisplayArea()
        {
            for (int i = 0; i < areaHeight; i++)
            {
                Console.SetCursorPosition(0, areaTop + i);
                foreach (var c in displayArea[i])
                {
                    if (c == '█')
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else if (c == 'O')
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    else if (c == '░')
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    Console.Write(c);
                }
            }

            // Display the score
            Console.SetCursorPosition(0, areaTop + areaHeight + 1);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Score: {score}/{maxScore}".PadRight(areaWidth));
        }

        static void UpdateDisplayArea(int line, string content)
        {
            if (line < 0 || line >= areaHeight)
            {
                Console.SetCursorPosition(0, areaTop + areaHeight);
                Console.WriteLine("Error: Line index out of bounds.");
                return;
            }

            displayArea[line] = content.Length > areaWidth
                ? content.Substring(0, areaWidth) // Truncate if too long
                : content.PadRight(areaWidth, '░');    // Pad if too short

            RenderDisplayArea();
        }

        static void ClearDisplayArea()
        {
            for (int i = 0; i < areaHeight; i++)
            {
                displayArea[i] = new string('░', areaWidth);
            }
            RenderDisplayArea();
        }

        static void MoveCharacter(int x, int y)
        {
            // Clear the previous character position
            for (int i = 0; i < areaHeight; i++)
            {
                displayArea[i] = displayArea[i].Replace('O', '░');
            }

            // Check for collision with special characters
            if (specialCharacters.ContainsKey((x, y)))
            {
                specialCharacters.Remove((x, y)); // Remove the special character
                score++;
                if (score < maxScore) SpawnSpecialCharacter(); // Spawn a new one if score is below max
            }

            // Place the character at the new position
            var row = displayArea[y].ToCharArray();
            row[x] = 'O';
            displayArea[y] = new string(row);

            // Render special characters
            foreach (var kvp in specialCharacters)
            {
                var (sx, sy) = kvp.Key;
                displayArea[sy] = displayArea[sy].Remove(sx, 1).Insert(sx, kvp.Value.ToString());
            }

            RenderDisplayArea();
        }

        static void HandleMovement(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.W: // Up
                    if (charY > 0) charY--;
                    break;
                case ConsoleKey.S: // Down
                    if (charY < areaHeight - 1) charY++;
                    break;
                case ConsoleKey.A: // Left
                    if (charX > 0) charX--;
                    break;
                case ConsoleKey.D: // Right
                    if (charX < areaWidth - 1) charX++;
                    break;
            }

            MoveCharacter(charX, charY);
        }

        static void SpawnSpecialCharacter()
        {
            // Generate a random position
            int x, y;
            do
            {
                x = random.Next(0, areaWidth);
                y = random.Next(0, areaHeight);
            } while (specialCharacters.ContainsKey((x, y)) || (x == charX && y == charY));

            // Add the special character
            specialCharacters[(x, y)] = '█';

            // Update display area
            var row = displayArea[y].ToCharArray();
            row[x] = '█';
            displayArea[y] = new string(row);

            RenderDisplayArea();
        }

        static void MovementLoop()
        {
            while (score < maxScore)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(intercept: true).Key;
                    HandleMovement(key);

                    // Flush additional keypresses to allow interruption
                    while (Console.KeyAvailable)
                    {
                        Console.ReadKey(intercept: true);
                    }
                }
                Thread.Sleep(movementDelay); // Limit the movement speed
            }

            MinigameWon = true;
            Game.MinigameVictory();
            // Game ends when the score reaches maxScore
            Console.SetCursorPosition(0, areaTop + areaHeight + 2);
            Console.WriteLine("Congratulations! You've collected all the items!");

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
            for (int i = 0; i < 5; i++)
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
                    string? answer = Console.ReadLine()?.ToLower();

                    if (string.IsNullOrEmpty(answer))
                    {
                        Game.Text("\nPlease enter a command:", 0);
                        continue;
                    }

                    Parser parser = new();
                    Command? command = parser.GetCommand(answer);

                    if (command == null)
                    {
                        Game.InvalidCommand();
                        continue;
                    }




                    if (answer == "admit")
                    {
                        corporations.Influence = corporations.Influence + 1;
                        Game.Text("\nYou admit that plastic doesn't cause as big issues on the environment as some people think. Industries can continue producing it in big numbers", 5);
                        Game.Text("\nFun Fact: this is incorrect because, --fact-- ", 0);

                    }
                    else if (answer == "advise")
                    {
                        environmentalists.Influence = environmentalists.Influence + 1;
                        Game.Text("\nYou advise that plastic can be very harmful if used thoughtlessly. The industry must limit the production of plastic and search for alternatives.", 0);
                        Game.Text("\nFun fact: Some alternatives can be: ", 0);
                    }
                    else
                    {
                        Game.InvalidCommand();
                    }

                }

                if (i == 1)
                {

                    Game.Text("\nYou woke up today and it was warm and sunny, so you decided to go swimming at a nearby beach.", 3);
                    Game.Text("\nWhile you are relaxing and sunbathing, you watch a group of teenagers leaving the beach. It annoys you that they have left their plastic bottles and bags behind.", 5);
                    Game.Text("\nYou think about talking to them and", 0);
                    Game.Text("\nsuggest ", 0, ConsoleColor.Green);
                    Game.Text("\npicking up their trash together. But you could just .", 0);
                    Game.Text("\ncontinue ", 0, ConsoleColor.Yellow);
                    Game.Text("\nenjoying the sun", 0);



                    string? answer = Console.ReadLine()?.ToLower();

                    if (answer == "continue")
                    {
                        corporations.Influence = corporations.Influence + 1;
                        Game.Text("\nYou ignore your consciousness, sunbathing was too pleasant to abandon. The beach stays littered and the teenagers will probably do it again.", 0);
                        Game.Text("\nFun Fact: Each one of us should take responsibility of our actions. Protecting the environment is not something only a trash man should do, it's a personal responsibility", 0);

                    }
                    else if (answer == "suggest")
                    {
                        environmentalists.Influence = environmentalists.Influence + 1;
                    }
                    else
                    {
                        Game.InvalidCommand();
                    }
                }

                if (i == 2)
                {


                    string? answer = Console.ReadLine()?.ToLower();

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

                if (i == 3)
                {


                    string? answer = Console.ReadLine()?.ToLower();

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

                if (i == 4)
                {


                    string? answer = Console.ReadLine()?.ToLower();

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

            }

            if (corporations.Influence < environmentalists.Influence)
            {
                Game.MinigameVictory();
                MinigameWon = true;
            }
            else
            {
                Game.Text("\n...", 2);
                Game.Text("\nWith your help, the corporations got to pass their policies. After some time, the situation on the island gets worse. It gets abandoned and never recovers.", 0);
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
