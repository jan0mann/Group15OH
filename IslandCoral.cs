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
        
        public static void Locals() // I (Noah) think methods for texts are better, because that way we have more freedom using text color, delays etc.
        {
            if (MinigameWon)
            {

            }
            else
            {
                Game.Text("\nIt is the only island affected by more than one problem, and those happen to be the ones of ALL the other islands! And to make things even worse, it is exactly there where our biggest and most important coral reef is located! Somebody needs to do something before it dies off…", 7);
            }
        }

        //We might wanne use this method here for the minigame itself
        public static void Story_Minigame()
        {
            // STORY/INTRODUCTION
            Game.Text("\nYou're driving out to the see, to get to the coral riff.", 3);
            Game.Text("\nOn your arrival, the biologist says:", 2);
            Game.Text("\n\nThis is where you must go alone. Good luck.", 2, ConsoleColor.DarkRed);
            Game.Text("\n\nYou jump into the water and dive deep down into the riff...", 5);


            //GAME START

            // Maze setup (1 = wall, 0 = free space)
            int[,] maze = {
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1 },
                { 1, 0, 0, 1, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1 },
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

            // Player starting position
            int playerX = 1;
            int playerY = 13;

            // Game loop
            bool loop = true;
            while (loop)
            {
                Console.Clear();
                DisplayMaze(maze, playerX, playerY); // Render the maze

                ConsoleKey key = Console.ReadKey(true).Key; // Read user input
                MovePlayer(ref playerX, ref playerY, key, maze); // Update player position

                if (playerX == 15 && playerY == 1)
                {
                    loop = false;
                    Console.Clear();
                    Game.Text("Great! You made it out!", 2);
                    Game.MinigameVictory();
                    MinigameWon = true;
                }
            }
        }

        static void DisplayMaze(int[,] maze, int playerX, int playerY)
        {
            Visuals.MazeVisual1();
            for (int y = 0; y < maze.GetLength(0); y++)
            {
                for (int x = 0; x < maze.GetLength(1); x++)
                {
                    if (x == playerX && y == playerY)
                        Game.Text(" * ", 0, ConsoleColor.Cyan); // Player position
                    else if (maze[y, x] == 1)
                        Game.Text(" # ", 0, ConsoleColor.DarkGreen); // Wall
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

            // Validate the new position (check bounds and walls)
            if (maze[newY, newX] == 0)
            {
                playerX = newX;
                playerY = newY;
            }
        }
    }
}
