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
                Game.Text("Thank you for saving the coral reef!", 2);
            }
            else
            {
                Game.Text("\nIt is the only island affected by more than one problem, and those happen to be the ones of ALL the other islands!\n And to make things even worse, it is exactly there where our biggest and most important coral reef is located! Somebody needs to do something before it dies off…", 7, ConsoleColor.DarkRed);
            }
        }

        //We might wanne use this method here for the minigame itself
        public static void Story_Minigame()
        {
            // STORY/INTRODUCTION
            Game.Text("\nYou're driving out to the sea, to get to the coral reef.", 3);
            Game.Text("\nOn your arrival, the biologist says:", 2);
            Game.Text("\n\nThis is where you must go alone. You need to find and remove all the scrap and fishing nets from this coral reef.", 4, ConsoleColor.DarkRed);
            Game.Text("\n If you won't, the coral reef might die and that would lead to marine life losing its habitat\n and nearby coastal areas suffering a food crisis.", 6, ConsoleColor.DarkRed);
            Game.Text("\nIn the meantime, I will speak with local people and try to persuade them from getting close to the coral reef.", 4, ConsoleColor.DarkRed);
            Game.Text("\nWe need to make sure, it's left untouched later.", 3, ConsoleColor.DarkRed);
            Game.Text("\nNow, good luck.", 2, ConsoleColor.DarkRed);
            Game.Text("\n\nYou jump into the water and dive deep down into the riff...", 5);


            //GAME START
            MazeGame(); // first part of the minigame

            Game.MinigameVictory();
            MinigameWon = true;
        }




        private static void MazeGame()
        {
            Game.Text("\n(To move around the maze, use W,A,S,D)", 4);
            Game.Text("\n Remember to collect all scrap! (S)", 4);
            // Maze setup (1 = wall, 0 = free space, 2 = exit, 3 = object(scrap))
            int[,] maze1 = {
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1 },
                { 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1, 0, 1 },
                { 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1 },
                { 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1 },
                { 1, 3, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1 },
                { 1, 1, 1, 0, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1 },
                { 1, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1 },
                { 1, 1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 0, 1 },
                { 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 1, 0, 1, 0, 1 },
                { 1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1 },
                { 1, 0, 1, 0, 1, 0, 1, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1 },
                { 1, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1 },
                { 1, 0, 1, 0, 1, 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1 },
                { 1, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 3, 1 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }};

            int[,] maze2 = {
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                { 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 3, 1, 0, 1 },
                { 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1 },
                { 1, 0, 1, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1 },
                { 1, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 1 },
                { 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1 },
                { 1, 3, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1 },
                { 1, 1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 0, 1 },
                { 1, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1, 1, 0, 1, 0, 1 },
                { 1, 0, 1, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1 },
                { 1, 0, 1, 0, 1, 0, 1, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1 },
                { 1, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 1, 0, 1 },
                { 1, 0, 1, 0, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 0, 1 },
                { 1, 0, 1, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
                { 1, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }};

            int[,] maze3 = {
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 1 },
                { 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 3, 1, 0, 1 },
                { 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 1 },
                { 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1 },
                { 1, 3, 1, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1 },
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

            // Object count
            int scrapCollected = 0;

            // Game loop
            bool loop1 = true;
            while (loop1)
            {
                Console.Clear();
                DisplayMaze(maze1, playerX, playerY); // Render the maze

                ConsoleKey key = Console.ReadKey(true).Key; // Read user input
                MovePlayer(ref playerX, ref playerY, key, maze1); // Update player position

                if (maze1[playerY, playerX] == 3)
                {
                    scrapCollected++;
                    maze1[playerY, playerX] = 0; // Remove object from maze

                }

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

                if (maze2[playerY, playerX] == 3)
                {
                    scrapCollected++;
                    maze2[playerY, playerX] = 0; // Remove object from maze

                }

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

                if (maze3[playerY, playerX] == 3)
                {
                    scrapCollected++;
                    maze3[playerY, playerX] = 0; // Remove object from maze

                }

                if (playerX == 15 && playerY == 1 && scrapCollected == 6)
                {
                    loop3 = false;
                    Console.Clear();
                    Game.Text("Great! You collected all the scrap and made it out!", 3);
                    Game.Text("Thanks to you, the coral reef will be able to regrow now", 3);
                    Game.MinigameVictory();
                    MinigameWon = true;
                }
                else
                {
                    loop3 = false;
                    Console.Clear();
                    Game.Text("You didn't manage the collect all the scrap...\n You need to go back there and try again, otherwise the coral reef will get even more damaged.", 4);
                    Game.Text("\nDo you want to retry? (y/n)\n", 2);
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
                        Game.Text(" * ", 0, ConsoleColor.Cyan); // Player position
                    else if (maze[y, x] == 1)
                        Game.Text(" # ", 0, ConsoleColor.DarkGreen); // Wall
                    else if (maze[y, x] == 2)
                        Game.Text(" G ", 0, ConsoleColor.Black);
                    else if (maze[y, x] == 3)
                        Console.Write(" S ");
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
            if (maze[newY, newX] == 0 || maze[newY, newX] == 3)
            {
                playerX = newX;
                playerY = newY;
            }
        }

    }
}
