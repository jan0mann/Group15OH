using OperationHav;

namespace OperationHav
{

    public class Visuals
    {

        public static void TitleScreen()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();
            Game.center("\n\n\n\n\n\n");
            Game.center("Introducing the most enjoayable learning game on planet earth:");
            Game.center("\n\n");
            Thread.Sleep(2000);
            Game.center(@"................................");
            Game.center("");
            Game.center(@"                                    _                _                 ");
            Game.center(@"                               _   (_)              | |                ");
            Game.center(@"   ___  ____   ____  ____ ____| |_  _  ___  ____    | | _   ____ _   _ ");
            Game.center(@"  / _ \|  _ \ / _  )/ ___/ _  |  _)| |/ _ \|  _ \   | || \ / _  | | | |");
            Game.center(@" | |_| | | | ( (/ /| |  ( ( | | |__| | |_| | | | |  | | | ( ( | |\ V / ");
            Game.center(@"  \___/| ||_/ \____|_|   \_||_|\___|_|\___/|_| |_|  |_| |_|\_||_| \_/  ");
            Game.center(@"       |_|                                                             ");
            Game.center("\n\n");
            Game.center("................................");
            Thread.Sleep(2000);
            Game.center("\n\n");
            Game.center("fun fact: 'hav' is danish for ocean, and that is what the game is all about!");
            Thread.Sleep(2000);
            Game.center("\n\n");
            Game.center("Press 'Enter' key to start Operation Hav!");
            Game.center("\n\n\n\n\n\n");
        }

    
        public static void Map()
        {

        }

        public static void NPC1()
        {
            Game.Text("\n\n         --------", 0);
            Game.Text("\n        !        !", 0);
            Game.Text("\n       |----------|", 0);
            Game.Text("\n   |---|          |---|", 0);
            Game.Text("\n   |------------------|", 0);
            Game.Text("\n      /    ____    !", 0);
            Game.Text("\n     |--███ /! ███|", 0);
            Game.Text("\n     |    !____/    |", 0);
            Game.Text("\n     -!            /-", 0);
            Game.Text("\n       ----(  /----", 0);
            Game.Text("\n|  --  |", 0);
            Game.Text("\n /--- ---|-----|| -----(", 0);
            Game.Text("\n|     | ~~~~~  |  /    /-", 0);
            Game.Text("\n|    || ~~~~~  | -    /", 0);
            Game.Text("\n|    |/---|----|-    /", 0);
            Game.Text("\n|    |(   |         -", 0);
            Game.Text("\n|    | ---|--------/", 0);
            Game.Text("\n------             |", 0);
            Game.Text("\n(    /-------------|", 0);
            Game.Text("\n (--/--------------|", 0);
            Game.Text("\n     |     I       |", 0);
            Game.Text("\n     |      -      |", 0);
            Game.Text("\n     |      |      |", 0);
            Game.Text("\n     |      |      |", 0);
            Game.Text("\n     |      |      |", 0);
            Game.Text("\n     (-----/ (----/", 0);
            Game.Text("\n      -   |   |  --", 0);
            Game.Text("\n     --(- |   | -/--", 0);
            Game.Text("\n    /------   ------(", 4);
        }

        public static void MazeVisual1()
        {
            Game.Text("\n                   v  ~.      v", 0, ConsoleColor.DarkMagenta);
            Game.Text("\n          v           /|", 0, ConsoleColor.DarkRed);
            Game.Text("\n                     / |          v", 0, ConsoleColor.DarkMagenta);
            Game.Text("\n              v     /__|__", 0, ConsoleColor.DarkRed);
            Game.Text("\n                  [--------/", 0, ConsoleColor.DarkMagenta);
            Game.Text("\n~~~~~~~~~~~~~~~~~~~`~~~~~~'~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~\n\n", 0, ConsoleColor.DarkBlue);
        }

        public static void MazeVisual2()
        {
            Game.Text("\n\n       /)", 0, ConsoleColor.DarkYellow);
            Game.Text("\n      {.-}                              O  o", 0, ConsoleColor.DarkCyan);
            Game.Text("\n     ;_.-')                        _]_   o ", 0, ConsoleColor.DarkYellow);
            Game.Text("\n    {    _.}_            >('>   ])/  o) .", 0, ConsoleColor.DarkCyan);
            Game.Text("\n     (.-' /  `,                 //(___=", 0, ConsoleColor.DarkYellow);
            Game.Text("\n      (  |    /                    ''", 0, ConsoleColor.DarkCyan);
            Game.Text("\n       ( |  ,/", 0, ConsoleColor.DarkYellow);
            Game.Text("\n        (|_/\n\n", 0, ConsoleColor.DarkCyan);
        }
    } 
}