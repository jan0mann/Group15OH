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
            Game.Center("\n\n\n\n\n\n");
            Game.Center("Introducing the most enjoayable learning game on planet earth:");
            Game.Center("\n\n");
            Thread.Sleep(2000);
            Game.Center(@"................................");
            Game.Center("");
            Game.Center(@"                                    _                _                 ");
            Game.Center(@"                               _   (_)              | |                ");
            Game.Center(@"   ___  ____   ____  ____ ____| |_  _  ___  ____    | | _   ____ _   _ ");
            Game.Center(@"  / _ \|  _ \ / _  )/ ___/ _  |  _)| |/ _ \|  _ \   | || \ / _  | | | |");
            Game.Center(@" | |_| | | | ( (/ /| |  ( ( | | |__| | |_| | | | |  | | | ( ( | |\ V / ");
            Game.Center(@"  \___/| ||_/ \____|_|   \_||_|\___|_|\___/|_| |_|  |_| |_|\_||_| \_/  ");
            Game.Center(@"       |_|                                                             ");
            Game.Center("\n\n");
            Game.Center("................................");
            Thread.Sleep(2000);
            Game.Center("\n\n");
            Game.Center("fun fact: 'hav' is danish for ocean, and that is what the game is all about!");
            Thread.Sleep(2000);
            Game.Center("\n\n");
            Game.Center("Press 'Enter' key to start Operation Hav!");
            Game.Center("\n\n\n\n\n\n");
        }

    
        public static void Map()
        {
            Console.WriteLine("                                                                                                                                                              ");
            Console.WriteLine("                                                                                                                                                              ");
            Console.WriteLine("                 /Y                                                                                                                                           ");
            Console.WriteLine("                /Y/Y                                                         --- -Y                                       /--Y----------------Y--------Y      ");
            Console.WriteLine("               _|/Y|_              -------  --Y                   ------  --/      -                                    /-    -Y     Y-        -Y       -Y    ");
            Console.WriteLine("              |______|          --             --  -Y        --                      -Y                               |-        -      Y         -        -   ");
            Console.WriteLine("               |Y/Y/|        --/                     --   --/                          -                     ------   |         |      |+- ___--+|        |   ");
            Console.WriteLine("              Y|/Y/Y|   .''`/:                                                           --Y        -- -----/         |         |      || (0 0) ||        |   ");
            Console.WriteLine("      :Y''.    Y`'. |  ||  /  :                                                             --   --/                  |         |      ||  |||  ||        |   ");
            Console.WriteLine("      : Y ||   |Y |||  || /    o                                   ---Y                                               |  -/Y-   |      |+-------+|        |   ");
            Console.WriteLine("      j _Y||__/__Y||_Y_||/___                            /- --   -/   --                                           /- --Y-Y/- /-       -         -        -   ");
            Console.WriteLine("        |___________________|                          /----  Y---  -/             /Y                           /--      -- ----------/---------/--------/    ");
            Console.WriteLine("         |  |   |   |   |  |                         ---/   -Y  /   /- -         /-  -Y                     / --                             Y                ");
            Console.WriteLine("   ~~~~~~|~~|~~~|~~~|~~~|~~|~~~~~~                         |  -- ---    Y      /-      -Y                  /                                  -               ");
            Console.WriteLine("                 -                                        / /-    Y----Y Y    -------------               -        --Y           /------ -     /              ");
            Console.WriteLine("                  Y-                                      |-        | | --Y   |  -------  |                 ------/   -         /         Y-  -               ");
            Console.WriteLine("                     -                                               Y Y   ---|  |     |  |Y                     /-   -----    -                              ");
            Console.WriteLine("                    /                                                | |--/   |  |   0 |  | -Y                 /-          Y----                              ");
            Console.WriteLine("                 --                                                ---Y Y     -------------   --Y             -                                               ");
            Console.WriteLine("               -/                                             Y---/                              -Y          /-                                               ");
            Console.WriteLine("               -                                               - --Y                               ---     --                                                 ");
            Console.WriteLine("                Y                                                   ----Y                    -----/      /                                        O           ");
            Console.WriteLine("                  _,.---.---.---.--.._                                   ----Y          ----/           -                                                     ");
            Console.WriteLine("              _.-' `--.`---.`---'-. _,`--.._                    /-            ---------/                          O                                  O        ");
            Console.WriteLine("             /`--._ .'.     `.     `,`-.`-._Y                  -                                       |                                                      ");
            Console.WriteLine("            ||   Y  `.`---.__`__..-`. ,'`-._/              /-                                          /             O     /`-._                              ");
            Console.WriteLine("       _  ,`Y `-._Y   Y    `.    `_.-`-._,``-.         /- -                                           |                   /_,.._`:-               O           ");
            Console.WriteLine("    ,`   `-_ Y/ `-.`--.Y    _Y_.-'Y__.-`-.`-._`.      -                                                               ,.-'  ,   `-:..-')   /- -        /---   ");
            Console.WriteLine("   (_.o> ,--. `._/'--.-`,--`  Y_.-'       Y`-._ Y   /--                                               Y           O  : o ):';      _  {   --/Y-Y--    --/Y-Y- ");
            Console.WriteLine("    `---'    `._ `---._/__,----`           `-. `-Y--                                                   -Y             `-._ `'__,.-'Y`-.)  Y-Y/- /     |-Y/-  |");
            Console.WriteLine("              /_, ,  _..-'                    `-._Y                                                      -                `YY  Y,.-'`      Y   /      Y     / ");
            Console.WriteLine("              Y_, Y/ ._(                                                                                   Y                          - -Y  Y   -      |    | ");
            Console.WriteLine("               Y_, Y/ ._Y                                                                                   -Y                     ---/Y- -| -Y  Y-   |    /  ");
            Console.WriteLine("                `._,Y/ ._Y                                                                                    -   ---Y              Y-Y/-  Y   -Y  Y  Y    |  ");
            Console.WriteLine("                  `._// ./`-._                                                                                        ---   ----     Y---   |-Y  -  Y- |  /   ");
            Console.WriteLine("                    `-._-_-_.-'                                                                                                          Y-------Y    Y   |   ");
            Console.WriteLine("                                                                                                                                               Y----     /    ");
        }

        public static void NPC0()
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

        public static void NPC01()
        {
            Console.WriteLine("         --------");
            Console.WriteLine("        !        !");
            Console.WriteLine("       |----------|");
            Console.WriteLine("   |---|          |---|");
            Console.WriteLine("   |------------------|");
            Console.WriteLine("      /    ____    !");
            Console.WriteLine("     |--███ /! ███|");
            Console.WriteLine("     |    !____/    |");
            Console.WriteLine("     -!            /-");
            Console.WriteLine("       ----(  /----");
            Console.WriteLine("         |  --  |");
            Console.WriteLine(" /--- ---|-----|| -----(");
            Console.WriteLine("|     | ~~~~~  |  /    /-");
            Console.WriteLine("|    || ~~~~~  | -    /");
            Console.WriteLine("|    |/---|----|-    /");
            Console.WriteLine("|    |(   |         -");
            Console.WriteLine("|    | ---|--------/");
            Console.WriteLine("------             |");
            Console.WriteLine("(    /-------------|");
            Console.WriteLine(" (--/--------------|");
            Console.WriteLine("     |     I       |");
            Console.WriteLine("     |      -      |");
            Console.WriteLine("     |      |      |");
            Console.WriteLine("     |      |      |");
            Console.WriteLine("     |      |      |");
            Console.WriteLine("     (-----/ (----/");
            Console.WriteLine("      -   |   |  --");
            Console.WriteLine("     --(- |   | -/--");
            Console.WriteLine("    /------   ------(");
        }
        public static void NPC1()
{           Console.WriteLine("  /-|---------------------------------|                      ");
            Console.WriteLine(" /   -|                 |              -|                    ");
            Console.WriteLine("-      -                 -|              ----                ");
            Console.WriteLine("|      |                   -             |   |               ");
            Console.WriteLine("|      |          -              -       |   |               ");
            Console.WriteLine("-      -        -/             -/        ----                ");
            Console.WriteLine(" |-  -/        /              /        -/                    ");
            Console.WriteLine("   |/ --------------------------------/                      ");
            Console.WriteLine("                                                    ,'       ");
            Console.WriteLine("                                                  ,;         ");
            Console.WriteLine("                                                .'/          ");
            Console.WriteLine("           `-_                                .'.'           ");
            Console.WriteLine("             `;-_                           .' /             ");
            Console.WriteLine("               `.-.        ,_.-'`'--'`'-._.` .'              ");
            Console.WriteLine("                 `.`-.    /    .--.   _.   /                 ");
            Console.WriteLine("                   `. '-.'_.._/0 ~ 0 |/`    ||               ");
            Console.WriteLine("                     `.      |'-^Y^- |     //                ");
            Console.WriteLine("                      |`|     |_.~._/|...-;..-.              ");
            Console.WriteLine("                      `._'._,'` ```    _.:---''`             ");
            Console.WriteLine("                         ;-....----'''`                      ");
            Console.WriteLine("                        /   |                                ");
            Console.WriteLine("                        |  |`                                ");
            Console.WriteLine("                        `.^'                                 ");
}
         public static void NPC11()
{      
            Console.WriteLine("                                                    ,'   ");
            Console.WriteLine("                                                  ,;     ");
            Console.WriteLine("                                                .'/      ");
            Console.WriteLine("           `-_                                .'.'       ");
            Console.WriteLine("             `;-_                           .' /         ");
            Console.WriteLine("               `.-.        ,_.-'`'--'`'-._.` .'          ");
            Console.WriteLine("                 `.`-.    /    .--.   _.   /             ");
            Console.WriteLine("                   `. '-.'_.._/0 ~ 0 |/`    ||           ");
            Console.WriteLine("                     `.      |'-^Y^- |     //            ");
            Console.WriteLine("                      (`|     |_.~._/|...-;..-.          ");
            Console.WriteLine("                      `._'._,'` ```    _.:---''`         ");
            Console.WriteLine("                         ;-....----'''`                  ");
            Console.WriteLine("                        /   (                            ");
            Console.WriteLine("                        |  (`                            ");
            Console.WriteLine("                        `.^'                             ");
}

        public static void NPC2()
        {
            Console.WriteLine("         |Y  /|                         ");
            Console.WriteLine("         | -- |----------               ");
            Console.WriteLine("         |/  Y|/------Y |Y              ");
            Console.WriteLine("         |---___  ___ ---               ");
            Console.WriteLine("         //  (■)/Y(■)  |Y               ");
            Console.WriteLine("        /-Y    <══>     |--Y            ");
            Console.WriteLine("       /   -------------     -          ");
            Console.WriteLine("      -       |     |                   ");
            Console.WriteLine("      /--------Y   /---------           ");
            Console.WriteLine("     |      --Y -©- /-       |          ");
            Console.WriteLine("     |---|     -- --     |----          ");
            Console.WriteLine("     |   |               |   |          ");
            Console.WriteLine("     |   |Y             /|   |          ");
            Console.WriteLine("     |   ||             ||   |          ");
            Console.WriteLine("     |   ||             ||   |          ");
            Console.WriteLine("     Y   //             YY   /          ");
            Console.WriteLine("      ---/               Y---           ");
            Console.WriteLine("        /               ░░Y             ");
            Console.WriteLine("       |             ░░░▓▓██            ");
            Console.WriteLine("       /           ░░▓▓█████            ");
            Console.WriteLine("      /           ░░▓▓███████           ");
            Console.WriteLine("     /          ░░▓▓██████████          ");
            Console.WriteLine("    ----------░░▓▓█████████████         ");
            Console.WriteLine("            |  |   ███|                 ");
            Console.WriteLine("          - |  |   ███| -               ");
            Console.WriteLine("         /------   ██████Y              ");

        }

         public static void NPC22()
        {
            Console.WriteLine("         |Y  /|                         ");
            Console.WriteLine("         | -- |----------               ");
            Console.WriteLine("         |/  Y|/------Y |Y              ");
            Console.WriteLine("         |---___  ___ ---               ");
            Console.WriteLine("         //  (■)/Y(■)  |Y               ");
            Console.WriteLine("        /-Y    <══>     |--Y            ");
            Console.WriteLine("       /   -------------     -          ");
            Console.WriteLine("      -       |     |                   ");
            Console.WriteLine("      /--------Y   /---------           ");
            Console.WriteLine("     |      --Y -©- /-       |          ");
            Console.WriteLine("     |---|     -- --     |----          ");
            Console.WriteLine("     |   |               |   |          ");
            Console.WriteLine("     |   |Y             /|   |          ");
            Console.WriteLine("     |   ||             ||   |          ");
            Console.WriteLine("     |   ||             ||   |          ");
            Console.WriteLine("     Y   //             YY   /          ");
            Console.WriteLine("      ---/               Y---           ");
            Console.WriteLine("        /                 Y             ");
            Console.WriteLine("       |                   Y            ");
            Console.WriteLine("       /                   Y            ");
            Console.WriteLine("      /                     Y           ");
            Console.WriteLine("     /                       Y          ");
            Console.WriteLine("    ---------------------------         ");
            Console.WriteLine("            |  |   |  |                 ");
            Console.WriteLine("          - |  |   |  | -               ");
            Console.WriteLine("         /------   ------Y              ");

        }

        public static void NPC3()
        {
            Console.WriteLine("                                  _____                    ");
            Console.WriteLine("                                 |     |                   ");
            Console.WriteLine("                                 | | | |                   ");
            Console.WriteLine("                                 |_____|                   ");
            Console.WriteLine("                           ____ ___|_|___ ____             ");
            Console.WriteLine("                          ()___)         ()___)            ");
            Console.WriteLine("                          // /|           || ||            ");
            Console.WriteLine("                         // / |           | | ||           ");
            Console.WriteLine("                        (___) |___________| (___)          ");
            Console.WriteLine("                        (___)   (_______)   (___)          ");
            Console.WriteLine("                        (___)     (___)     (___)          ");
            Console.WriteLine("                        (___)      |_|      (___)          ");
            Console.WriteLine("                        (___)  ___/___|___   | |           ");
            Console.WriteLine("                         | |  |           |  | |           ");
            Console.WriteLine("                         | |  |___________| /___|          ");
            Console.WriteLine("                        /___|  |||     ||| //   ||         ");
            Console.WriteLine("                       //   || |||     ||| ||   //         ");
            Console.WriteLine("                       ||   // |||     |||  || //          ");
            Console.WriteLine("                        || // ()__)   (__()                ");
            Console.WriteLine("                              ///       |||                ");
            Console.WriteLine("                             ///         |||               ");
            Console.WriteLine("                           _///___     ___|||_             ");
            Console.WriteLine("                          |_______|   |_______|            ");

        }


        public static void NPC4() 
        {

            Console.WriteLine("                                  __"            );
            Console.WriteLine("                               _.-~  )"          );
            Console.WriteLine("                    _..--~~~~,'   ,-/     _"     );
            Console.WriteLine("                 .-'. . . .'   ,-','    ,' )"    );
            Console.WriteLine("               ,'. . . _   ,--~,-'__..-'  ,'"    );
            Console.WriteLine("             ,'. . .  (@)' ---~~~~      ,'"      );
            Console.WriteLine("            /. . . . '~~             ,-'"        );
            Console.WriteLine("           /. . . . .             ,-'"           );
            Console.WriteLine("          ; . . . .  - .        ,'"              );
            Console.WriteLine("         : . . . .       _     /"                );
            Console.WriteLine("        . . . . .          `-.:"                 );
            Console.WriteLine("       . . . ./  - .          )"                 );
            Console.WriteLine("      .  . . |  _____..---.._/ _________"        );
            Console.WriteLine("~---~~~~----~~~~             ~~"                 );

        }     

         public static void NPC44() 
        {
            Console.WriteLine("                                    _"                                       );
            Console.WriteLine("                               _.-~~.)"                                      );
            Console.WriteLine("         _.--~~~~~---....__  .' . .,'"                                       );
            Console.WriteLine("       ,'. . . . . . . . . .~- ._ ("                                         );
            Console.WriteLine("      ( .. .g. . . . . . . . . . .~-._"                                      );
            Console.WriteLine("   .~__.-~    ~`. . . . . . . . . . . -."                                    );
            Console.WriteLine("   `----..._      ~-=~~-. . . . . . . . ~-."                                 );
            Console.WriteLine("             ~-._   `-._ ~=_~~--. . . . . .~."                               );
            Console.WriteLine("              | .~-.._  ~--._-.    ~-. . . . ~-."                            );
            Console.WriteLine("               | .(   ~~--.._~'       `. . . . .~-.                ,"        );
            Console.WriteLine("                `._Y         ~~--.._    `. . . . . ~-.    .- .   ,'/"        );
            Console.WriteLine("_  . _ . -~|        _ ..  _          ~~--.`_. . . . . ~-_     ,-','`  ."     );
            Console.WriteLine("             ` ._           ~                ~--. . . . .~=.-'. /. `"        );
            Console.WriteLine("       - . -~            -. _ . - ~ - _   - ~     ~--..__~ _,. /   Y  - ~"   );
            Console.WriteLine("              . __ ..                   ~-               ~~_. (  `"          );
            Console.WriteLine(")`. _ _               `-       ..  - .    . - ~ ~ .    |    ~-` ` `  `. _"   );
            Console.WriteLine("");
        }
    } 
}