using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace OperationHav
{
    public class IslandCoral : Island
    {
        public IslandCoral(string name, string shortDesc) : base(name, shortDesc)
        {
            Name = name;
            ShortDescription = shortDesc;
        }
        public static bool MinigameWon = false;
        
 

        public static void Story_Minigame()
        {
            // STORY/INTRODUCTION
            Game.Text("You start equipping yourself with the diving suit given to you on Mæinø.", 3);
            Game.Text("\nAfter that, you head to the shore in order to somehow get to the coral reef.", 3);
            Game.Text("\nBy the shore, you encounter a little dolphin. ", 3);
            Visuals.NPC4();
            Game.Text("Hey, I've been waiting for you!", 3, ConsoleColor.Blue);
            Game.Text("\nYou want to clean the coral reef, right?", 3, ConsoleColor.Blue);
            Game.Text("\nPlease, let me help you with that! Hold onto me, I will bring you there!", 3, ConsoleColor.Blue);
            Game.Text("\n\nYou accept the offer and jump into the water, holding onto the dolphin as it swims out.", 4);
            Console.Clear();
            Game.Text("You observe the reef more and more as you're getting closer to it.", 3);
            Game.Text("\nOn your arrival, the dolphin says:", 3);
            Game.Text("\n\nWe're there then.", 3, ConsoleColor.Blue);
            Game.Text("\nI'm afraid this is where you must go alone.", 3, ConsoleColor.Blue);
            Game.Text("\nRemeber to use ", 0, ConsoleColor.Blue);
            Game.Text("W A S D (or Arrow-keys)", 0, ConsoleColor.Yellow);
            Game.Text(" to move around down there.", 3); 
            Game.Text("\nAlso, remember that the trash looks like this:", 0);
            Game.Text("G", 3, ConsoleColor.Black);
            Game.Text("Good luck. Please return safely!", 3, ConsoleColor.Blue);
            Game.Text("\n\nYou let go of the dolphin and dive deep down into the reef...", 5);


            //GAMEPLAY
            MazeGame();

            //CONCLUSION
            Game.Text("Great! You collected all the scrap and made it out!", 3);
            Game.Text("\nThe dolphin sees you and swims happily towards you.", 5);
            Visuals.NPC44();
            Game.Text("You made it!", 3, ConsoleColor.Blue);
            Game.Text("\nThe reef will hopefully recover from all this soon!", 3, ConsoleColor.Blue);
            Game.Text("\nIn any case, this wouldn't have been possible without you!", 4, ConsoleColor.Blue);
            Game.Text("\nThank you so much for your help!", 3, ConsoleColor.Blue);
            Game.Text("\nLet me get you back to the shore.", 3, ConsoleColor.Blue);
            Game.Text("\n\nYou grab once again onto the dolphin. Together, you return to the island.", 5);
            Game.MinigameVictory();
            MinigameWon = true;
        }
        



        private static void MazeGame()
        {
            // Maze setup (1 = wall, 0 = free space)
            int[,] maze1 = {
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 2, 1 },
                { 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1 },
                { 1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1 },
                { 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1 },
                { 1, 1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 0, 1 },
                { 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 1, 0, 1, 0, 1 },
                { 1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1 },
                { 1, 0, 1, 0, 1, 0, 1, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1 },
                { 1, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1 },
                { 1, 0, 1, 0, 1, 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1 },
                { 1, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }};

                int[,] maze2 = {
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1 },
                { 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1 },
                { 1, 0, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1 },
                { 1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1 },
                { 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1 },
                { 1, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1 },
                { 1, 1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 0, 1 },
                { 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 1, 0, 1, 0, 1 },
                { 1, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1 },
                { 1, 0, 1, 0, 1, 0, 1, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1 },
                { 1, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1 },
                { 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1 },
                { 1, 2, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }};

                int[,] maze3 = {
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1 },
                { 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1 },
                { 1, 0, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1 },
                { 1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1 },
                { 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1 },
                { 1, 2, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1 },
                { 1, 1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 0, 1 },
                { 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 1, 0, 1, 0, 1 },
                { 1, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1 },
                { 1, 0, 1, 0, 1, 0, 1, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1 },
                { 1, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1 },
                { 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1 },
                { 1, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }};

                int[,] maze4 = {
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 2, 1, 0, 1 },
                { 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1 },
                { 1, 0, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1 },
                { 1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1 },
                { 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1 },
                { 1, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1 },
                { 1, 1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 0, 1 },
                { 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 1, 0, 1, 0, 1 },
                { 1, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1 },
                { 1, 0, 1, 0, 1, 0, 1, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1 },
                { 1, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1 },
                { 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1 },
                { 1, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }};

                int[,] maze5 = {
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1 },
                { 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1 },
                { 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1 },
                { 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1 },
                { 1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1 },
                { 1, 1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 0, 1 },
                { 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 1, 0, 1, 0, 1 },
                { 1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1 },
                { 1, 0, 1, 0, 1, 0, 1, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1 },
                { 1, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1 },
                { 1, 0, 1, 0, 1, 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1 },
                { 1, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }};

            // Player starting position
            int playerX = 1;
            int playerY = 13;

            // Game loop
            bool loop1 = true;
            while (loop1)
            {
                Console.Clear();
                DisplayMaze(maze1, playerX, playerY); // Render the maze

                ConsoleKey key = Console.ReadKey(true).Key; // Read user input
                MovePlayer(ref playerX, ref playerY, key, maze1); // Update player position

                if (playerX == 15 && playerY == 1)
                {
                    loop1 = false;
                    Console.Clear();
                }
            }

            bool loop2 = true;
            while (loop2)
            {
                Console.Clear();
                DisplayMaze(maze2, playerX, playerY); // Render the maze

                ConsoleKey key = Console.ReadKey(true).Key; // Read user input
                MovePlayer(ref playerX, ref playerY, key, maze2); // Update player position

                if (playerX == 1 && playerY == 13)
                {
                    loop2 = false;
                    Console.Clear();
                }
            }

            bool loop3 = true;
            while (loop3)
            {
                Console.Clear();
                DisplayMaze(maze3, playerX, playerY); // Render the maze

                ConsoleKey key = Console.ReadKey(true).Key; // Read user input
                MovePlayer(ref playerX, ref playerY, key, maze3); // Update player position

                if (playerX == 1 && playerY == 6)
                {
                    loop3 = false;
                    Console.Clear();
                }
            }

            bool loop4 = true;
            while (loop4)
            {
                Console.Clear();
                DisplayMaze(maze4, playerX, playerY); // Render the maze

                ConsoleKey key = Console.ReadKey(true).Key; // Read user input
                MovePlayer(ref playerX, ref playerY, key, maze4); // Update player position

                if (playerX == 13 && playerY == 1)
                {
                    loop4 = false;
                    Console.Clear();
                }
            }

            bool loop5 = true;
            while (loop5)
            {
                Console.Clear();
                DisplayMaze(maze5, playerX, playerY); // Render the maze

                ConsoleKey key = Console.ReadKey(true).Key; // Read user input
                MovePlayer(ref playerX, ref playerY, key, maze5); // Update player position

                if (playerX == 15 && playerY == 1)
                {
                    loop5 = false;
                    Console.Clear();
                }
            }
        }
        
        public static void DisplayMaze(int[,] maze, int playerX, int playerY)
        {
            Visuals.MazeVisual1();
            for (int y = 0; y < maze.GetLength(0); y++)
            {
                for (int x = 0; x < maze.GetLength(1); x++)
                {
                    if (x == playerX && y == playerY)
                        Game.Text(" O ", 0, ConsoleColor.Yellow); // Player position
                    else if (maze[y, x] == 1)
                        Game.Text(" # ", 0, ConsoleColor.DarkGreen); // Wall
                    else if (maze[y, x] == 2)
                        Game.Text(" G ", 0, ConsoleColor.Black);
                    else
                        Game.Text("   ", 0); // Free space
                }
                Console.WriteLine();
            }
            Visuals.MazeVisual2();
        }
        static void MovePlayer(ref int playerX, ref int playerY, ConsoleKey key, int[,] maze)
        {
            int newX = playerX;
            int newY = playerY;

            // Determine new position based on input
            if (key == ConsoleKey.W) newY--; // Up
            else if (key == ConsoleKey.S) newY++; // Down
            else if (key == ConsoleKey.A) newX--; // Left
            else if (key == ConsoleKey.D) newX++; // Right
            else if (key == ConsoleKey.UpArrow) newY--; //Up
            else if (key == ConsoleKey.DownArrow) newY++; // Down
            else if (key == ConsoleKey.LeftArrow) newX--; // Left
            else if (key == ConsoleKey.RightArrow) newX++; // Right

            // Validate the new position (check bounds and walls)
            if (maze[newY, newX] == 0 || maze[newY, newX] == 2)
            {
                playerX = newX;
                playerY = newY;
            }
        }
        
    }
}
