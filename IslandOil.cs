namespace OperationHav
{
    public class IslandOil : Island 
    {   
        public IslandOil(string name, string shortDesc) : base(name, shortDesc)
        {
            Name = name;
            ShortDescription = shortDesc;
        }
        public static bool MinigameWon = false;

        public static void Locals() // I (Noah) think methods for texts are better, because that way we have more freedom using text color, delays etc.
        {
            if (MinigameWon)
            {

            }
            else
            {
                Game.Text("\nDue to major American trade routes near the island, a lot of spilled oil has gathered around the island, contaminating its waters…", 4);
            }
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
        {   Game.minigame = true;
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

}