using OperationHav;

namespace OperationHav
{

    public class Visuals
    {

    
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
            Game.Text("\n      {.-}                              O  o", 0, ConsoleColor.Green);
            Game.Text("\n     ;_.-')                        _]_   o ", 0, ConsoleColor.DarkYellow);
            Game.Text("\n    {    _.}_            >('>   ])/  o) .", 0, ConsoleColor.Green);
            Game.Text("\n     (.-' /  `,                 //(___=", 0, ConsoleColor.DarkYellow);
            Game.Text("\n      (  |    /                    ''", 0, ConsoleColor.Green);
            Game.Text("\n       ( |  ,/", 0, ConsoleColor.DarkYellow);
            Game.Text("\n        (|_/\n\n", 0, ConsoleColor.Green);
        }
    } 
}