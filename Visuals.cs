using System.Collections;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
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
            Game.Center("Introducing the most enjoyable learning game on planet earth:");
            Game.Center("\n\n");
            Thread.Sleep(2000);
            Game.Center(@"................................");
            Game.Center("");
            Game.Center(@"   ___                              _                _   _             ");
            Game.Center(@"  / _ \                        _   (_)              | | | |            ");
            Game.Center(@" | | | |____   ____  ____ ____| |_  _  ___  ____    | |_| | ____ _   _ ");
            Game.Center(@" | | | |  _ \ / _  )/ ___/ _  |  _)| |/ _ \|  _ \   |  _  |/ _  | | | |");
            Game.Center(@" | |_| | | | ( (/ /| |  ( ( | | |__| | |_| | | | |  | | | ( ( | |\ V / ");
            Game.Center(@"  \___/| ||_/ \____|_|   \_||_|\___|_|\___/|_| |_|  |_| |_|\_||_| \_/  ");
            Game.Center(@"       |_|                                                             ");
            Game.Center("\n\n");
            Game.Center("................................");
            Thread.Sleep(2000);
            Game.Center("\n\n");
            Game.Center("fun fact: 'hav' is danish for ocean, and that is what the game is about!");
            Thread.Sleep(2000);
            Game.Center("\n\n");
            Game.Center("Press 'Enter' key to start Operation Hav!");
            Game.Center("\n\n\n\n\n\n");
        }

    
        public static void Map(Island? urhere)
        {
            string Sp1 = "     ";
            string Sp2 = "     ";
            string Sp3 = "     ";
            string Sp4 = "     ";
            string Sp5 = "     ";

            if(IslandIndustrial.MinigameWon)
                Sp2 = "CLEAN";
            if(IslandPlastic.MinigameWon)
                Sp3 = "CLEAN";
            if(IslandOil.MinigameWon)
                Sp4 = "CLEAN";
            if(IslandCoral.MinigameWon)
                Sp5 = "CLEAN";

            switch(urhere)
            {
                case IslandIndustrial:
                    Sp2 = "[YOU]";
                    break;
                case IslandPlastic:
                    Sp3 = "[YOU]";
                    break;
                case IslandOil:
                    Sp4 = "[YOU]";
                    break;
                case IslandCoral:
                    Sp5 = "[YOU]";
                    break;
                default:
                    Sp1 = "[YOU]";
                    break;
            }

            Console.Clear();
            Console.WriteLine(@"________________________________________________________________________________________________________________________________________________________________");
            Console.WriteLine(@"|                                                                                                                                                              |");
            Console.WriteLine(@"|                 /\                                                                                                                                           |");
            Console.WriteLine(@"|                /\/\                                                         --- -\                                       /--\----------------\--------\      |");
            Console.WriteLine(@"|               _|/\|_              -------  --\                   ------  --/      -                                    /-    -\     \-        -\       -\    |");
                Console.Write(@"|              |______|  ");
                Game.Text(Sp2, 0, ConsoleColor.Yellow);
                Console.WriteLine(@"   --             --  -\        --                      -\                               |-        -      \         -        -   |");
            Console.WriteLine(@"|               |\/\/|        --/                     --   --/                          -                     ------   |         |      |+- ___--+|        |   |");
            Console.WriteLine(@"|              \|/\/\|   .''`/:                                                           --\        -- -----/         |         |      || (0 0) ||        |   |");
            Console.WriteLine(@"|      :\''.    \`'. |  ||  /  :                                                             --   --/                  |         |      ||  |||  ||        |   |");
                Console.Write(@"|      : \ ||   |\ |||  || /    o                                   ---\                                       ");
                Game.Text(Sp4, 0, ConsoleColor.Yellow);
                Console.WriteLine(@"   |  -/\-   |      |+-------+|        |   |");
            Console.WriteLine(@"|      j _\||__/__\||_\_||/___                            /- --   -/   --                                           /- --\-\/- /-       -         -        -   |");
            Console.WriteLine(@"|       |___________________|                          /----  \---  -/             /\                           /--      -- ----------/---------/--------/     |");
            Console.WriteLine(@"|        |  |   |   |   |  |                         ---/   -\  /   /- -         /-  -\                     / --                             \                 |");
            Console.WriteLine(@"|   ~~~~~~|~~|~~~|~~~|~~~|~~|~~~~~~                         |  -- ---    \      /-      -\                  /                                  -               |");
            Console.WriteLine(@"|                 -                                        / /-    \----\ \    -------------               -        --\           /------ -     /              |");
            Console.WriteLine(@"|                  \-                                      |-        | | --\   |  -------  |                 ------/   -         /         \-  -               |");
            Console.WriteLine(@"|                     -                                               \ \   ---|  |     |  |\                     /-   -----    -                              |");
            Console.WriteLine(@"|                    /                                                | |--/   |  |   0 |  | -\                 /-          \----                              |");
            Console.WriteLine(@"|                 --                                                ---\ \     -------------   --\             -                                               |");
            Console.WriteLine(@"|               -/                                             \---/                              -\          /-                                               |");
            Console.WriteLine(@"|               -                                               - --\                               ---     --                                                 |");
                Console.Write(@"|                \            ");
                Game.Text(Sp3, 0, ConsoleColor.Yellow);
                Console.Write(@"                                 ----\           ");
                Game.Text(Sp1, 0, ConsoleColor.Yellow);
                Console.WriteLine(@"      -----/      /                                        O          |");
            Console.WriteLine(@"|                  _,.---.---.---.--.._                                   ----\          ----/           -                                                     |");
            Console.WriteLine(@"|              _.-' `--.`---.`---'-. _,`--.._                    /-            ---------/                          O                                  O        |");
                Console.Write(@"|             /`--._ .'.     `.     `,`-.`-._\                  -                                       |                                 ");
                Game.Text(Sp5, 0, ConsoleColor.Yellow);
                Console.WriteLine(@"                |");
            Console.WriteLine(@"|            ||   \  `.`---.__`__..-`. ,'`-._/              /-                                          /             O     /`-._                              |");
            Console.WriteLine(@"|      _  ,`\ `-._\   \    `.    `_.-`-._,``-.         /- -                                           |                   /_,.._`:-              O             |");
            Console.WriteLine(@"|    ,`   `-_ \/ `-.`--.\    _\_.-'\__.-`-.`-._`.      -                                                               ,.-'  ,   `-:..-')   /- -        /---   |");
            Console.WriteLine(@"|   (_.o> ,--. `._/'--.-`,--`  \_.-'       \`-._ \   /--                                               \           O  : o ):';      _  {   --/\-\--    --/\-\- |");
            Console.WriteLine(@"|    `---'    `._ `---._/__,----`           `-. `-\--                                                   -\             `-._ `'__,.-'\`-.)  \-\/- /     |-\/-  ||");
            Console.WriteLine(@"|              /_, ,  _..-'                    `-._\                                                      -                `\\  \,.-'`      \   /      \     / |");
            Console.WriteLine(@"|              \_, \/ ._(                                                                                   \                          - -\  \   -      |    | |");
            Console.WriteLine(@"|               \_, \/ ._\                                                                                   -\                     ---/\- -| -\  \-   |    /  |");
            Console.WriteLine(@"|                `._,\/ ._\                                                                                    -   ---\              \-\/-  \   -\  \  \    |  |");
            Console.WriteLine(@"|                  `._// ./`-._                                                                                        ---   ----     \---   |-\  -  \- |  /   |");
            Console.WriteLine(@"|                    `-._-_-_.-'                                                                                                          \-------\    \   |   |");
            Console.WriteLine(@"|                                                                                                                                               \----     /    |");
            Console.WriteLine(@"|______________________________________________________________________________________________________________________________________________________________|");
            Thread.Sleep(3000);
            Console.Clear();
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

        public static void NPC0()
        {
            Console.Clear();
            Console.WriteLine("         --------");
            Console.WriteLine("        !        |");
            Console.WriteLine("       |----------|");
            Console.WriteLine("   |---|          |---|");
            Console.WriteLine("   |------------------|");
            Console.WriteLine("      /    ____    |");
            Console.WriteLine("     |--███ /| ███|");
            Console.WriteLine("     |    |____/    |");
            Console.WriteLine("     -|            /-");
            Console.WriteLine("       ----(  /----");
            Console.WriteLine("         |  --  |");
            Console.WriteLine(" /--- ---|-----|| -----)");
            Console.WriteLine("|     | ~~~~~  |  /    /-");
            Console.WriteLine("|    || ~~~~~  | -    /");
            Console.WriteLine("|    |/---|----|-    /");
            Console.WriteLine("|    |(   |         -");
            Console.WriteLine("|    | ---|--------/");
            Console.WriteLine("------             |");
            Console.WriteLine("(    /-------------|");
            Console.WriteLine(" (--/--------------|");
            Console.WriteLine("     |     |       |");
            Console.WriteLine("     |      -      |");
            Console.WriteLine("     |      |      |");
            Console.WriteLine("     |      |      |");
            Console.WriteLine("     |      |      |");
            Console.WriteLine("     (-----/ (----/");
            Console.WriteLine("      -   |   |  --");
            Console.WriteLine("     --(- |   | -/--");
            Console.WriteLine("    /------   ------|");
            Thread.Sleep(3000);
            Console.Clear();
        }

        public static void NPC1()
        {      
            Console.Clear();  
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("  /-|---------------------------------|                      ");
            Console.WriteLine(" /   -|                 |              -|                    ");
            Console.WriteLine("-      -                 -|              ----                ");
            Console.WriteLine("|      |                   -             |   |               ");
            Console.WriteLine("|      |          -              -       |   |               ");
            Console.WriteLine("-      -        -/             -/        ----                ");
            Console.WriteLine(" |-  -/        /              /        -/                    ");
            Console.WriteLine("   |/ --------------------------------/                      ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
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
            Thread.Sleep(3000);
            Console.ResetColor();
            Console.Clear();
        }

        public static void NPC11()
        {      
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("                                                    ,'   ");
            Console.WriteLine("                                                  ,;     ");
            Console.WriteLine("                                                .'/      ");
            Console.WriteLine("           `-_                                .'.'       ");
            Console.WriteLine("             `;-_                           .' /         ");
            Console.WriteLine("               `.-.        ,_.-'`'--'`'-._.` .'          ");
            Console.WriteLine("                 `.`-.    /    .--.   _.   /             ");
            Console.WriteLine("                   `. '-.'_.._/^ ~ ^ |/`    ||           ");
            Console.WriteLine("                     `.      |'-^Y^- |     //            ");
            Console.WriteLine("                      (`|     |_.~._/|...-;..-.          ");
            Console.WriteLine("                      `._'._,'` ```    _.:---''`         ");
            Console.WriteLine("                         ;-....----'''`                  ");
            Console.WriteLine("                        /   (                            ");
            Console.WriteLine("                        |  (`                            ");
            Console.WriteLine("                        `.^'                             ");
            Thread.Sleep(3000);
            Console.ResetColor();
            Console.Clear();
        }

        public static void NPC111()
        {   
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("                                                    ,'   ");
            Console.WriteLine("                                                  ,;     ");
            Console.WriteLine("                                                .'/      ");
            Console.WriteLine("           `-_                                .'.'       ");
            Console.WriteLine("             `;-_                           .' /         ");
            Console.WriteLine("               `.-.        ,_.-'`'--'`'-._.` .'          ");
            Console.WriteLine("                 `.`-.    /    .--.   _.   /             ");
            Console.WriteLine("                   `. '-.'_.._/x ~ x |/`    ||           ");
            Console.WriteLine("                     `.      |'-^Y^- |     //            ");
            Console.WriteLine("                      (`|     |_.~._/|...-;..-.          ");
            Console.WriteLine("                      `._'._,'` ```    _.:---''`         ");
            Console.WriteLine("                         ;-....----'''`                  ");
            Console.WriteLine("                        /   (                            ");
            Console.WriteLine("                        |  (`                            ");
            Console.WriteLine("                        `.^'                             ");
            Thread.Sleep(3000);
            Console.ResetColor();
            Console.Clear();
        }

        public static void NPC2()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(@"         |\  /|                         ");
            Console.WriteLine(@"         | -- |----------               ");
            Console.WriteLine(@"         |/  \|/------\ |\              ");
            Console.WriteLine(@"         |---         ---               ");
            Console.WriteLine(@"         //  (0)/\(0)  |\               ");
            Console.WriteLine(@"        /-\  : <══> :   |--\            ");
            Console.WriteLine(@"       /   -------------     -          ");
            Console.WriteLine(@"      -       |     |                   ");
            Console.WriteLine(@"      /--------\   /---------           ");
            Console.WriteLine(@"     |      --\ -©- /-       |          ");
            Console.WriteLine(@"     |---|     -- --     |----          ");
            Console.WriteLine(@"     |   |               |   |          ");
            Console.WriteLine(@"     |   |\             /|   |          ");
            Console.WriteLine(@"     |   ||             ||   |          ");
            Console.WriteLine(@"     |   ||             ||   |          ");
            Console.WriteLine(@"     \   //             \\   /          ");
            Console.WriteLine(@"      ---/               \---           ");
            Console.WriteLine(@"        /               ░░\             ");
            Console.WriteLine(@"       |             ░░░▓▓██            ");
            Console.WriteLine(@"       /           ░░▓▓█████            ");
            Console.WriteLine(@"      /           ░░▓▓███████           ");
            Console.WriteLine(@"     /          ░░▓▓██████████          ");
            Console.WriteLine(@"    ----------░░▓▓█████████████         ");
            Console.WriteLine(@"            |  |   ███|                 ");
            Console.WriteLine(@"          - |  |   ███| -               ");
            Console.WriteLine(@"         /------   ██████\              ");
            Thread.Sleep(3000);
            Console.ResetColor();
            Console.Clear();
        }

        public static void NPC22()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(@"         |\  /|                         ");
            Console.WriteLine(@"         | -- |----------               ");
            Console.WriteLine(@"         |/  \|/------\ |\              ");
            Console.WriteLine(@"         |---         ---               ");
            Console.WriteLine(@"         //  (^)/\(^)  |\               ");
            Console.WriteLine(@"        /-\    <══>     |--\            ");
            Console.WriteLine(@"       /   -------------     -          ");
            Console.WriteLine(@"      -       |     |                   ");
            Console.WriteLine(@"      /--------\   /---------           ");
            Console.WriteLine(@"     |      --\ -©- /-       |          ");
            Console.WriteLine(@"     |---|     -- --     |----          ");
            Console.WriteLine(@"     |   |               |   |          ");
            Console.WriteLine(@"     |   |\             /|   |          ");
            Console.WriteLine(@"     |   ||             ||   |          ");
            Console.WriteLine(@"     |   ||             ||   |          ");
            Console.WriteLine(@"     \   //             \\   /          ");
            Console.WriteLine(@"      ---/               \---           ");
            Console.WriteLine(@"        /                 \             ");
            Console.WriteLine(@"       |                   \            ");
            Console.WriteLine(@"       /                   \            ");
            Console.WriteLine(@"      /                     \           ");
            Console.WriteLine(@"     /                       \          ");
            Console.WriteLine(@"    ---------------------------         ");
            Console.WriteLine(@"            |  |   |  |                 ");
            Console.WriteLine(@"          - |  |   |  | -               ");
            Console.WriteLine(@"         /------   ------\              ");
            Thread.Sleep(3000);
            Console.ResetColor();
            Console.Clear();
        }

        public static void NPC3()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("                                  _____                    ");
            Console.WriteLine("                                 |     |                   ");
            Console.WriteLine("                                 | X | |                   ");
            Console.WriteLine("                                 |_____|                   ");
            Console.WriteLine("                           ____ ___|_|___ ____             ");
            Console.WriteLine("                          ()___)         ()___)            ");
            Console.WriteLine("                          // /|           || ||            ");
            Console.WriteLine("                         // / |           | | ||           ");
            Console.WriteLine("                        (___) |___________| (___)          ");
            Console.WriteLine("                          ||    (_______)   (___)          ");
            Console.WriteLine("                          |       (___)     (___)          ");
            Console.WriteLine("                                   |_|      (___)          ");
            Console.WriteLine("                               ___/___|___   | |           ");
            Console.WriteLine("                              |           |  | |           ");
            Console.WriteLine("                              |___________| /___|          ");
            Console.WriteLine("                               |||     ||| //   ||         ");
            Console.WriteLine("                               |||     ||  ||   //         ");
            Console.WriteLine("                               |||     |    || //          ");
            Console.WriteLine("                              ()__)                        ");
            Console.WriteLine("                              ///                          ");
            Console.WriteLine("                             ///                           ");
            Console.WriteLine("                           _///___                         ");
            Console.WriteLine("                          |_______|                        ");
            Thread.Sleep(3000);
            Console.ResetColor();
            Console.Clear();
        }

        public static void NPC33()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("                                  _____                    ");
            Console.WriteLine("                                 |     |                   ");
            Console.WriteLine("                                 | ^ ^ |                   ");
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
            Thread.Sleep(3000);
            Console.ResetColor();
            Console.Clear();
        }

        public static void NPC4() 
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
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
            Thread.Sleep(3000);
            Console.ResetColor();
            Console.Clear();
        }     

        public static void NPC44() 
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(@"                                    _"                                       );
            Console.WriteLine(@"                               _.-~~.)"                                      );
            Console.WriteLine(@"         _.--~~~~~---....__  .' . .,'"                                       );
            Console.WriteLine(@"       ,'. . . . . . . . . .~- ._ ("                                         );
            Console.WriteLine(@"      ( .. .^. . . . . . . . . . .~-._"                                      );
            Console.WriteLine(@"   .~__.-~    ~`. . . . . . . . . . . -."                                    );
            Console.WriteLine(@"   `----..._      ~-=~~-. . . . . . . . ~-."                                 );
            Console.WriteLine(@"             ~-._   `-._ ~=_~~--. . . . . .~."                               );
            Console.WriteLine(@"              | .~-.._  ~--._-.    ~-. . . . ~-."                            );
            Console.WriteLine(@"               | .(   ~~--.._~'       `. . . . .~-.                ,"        );
            Console.WriteLine(@"                `._\         ~~--.._    `. . . . . ~-.    .- .   ,'/"        );
            Console.WriteLine(@"_  . _ . -~|        _ ..  _          ~~--.`_. . . . . ~-_     ,-','`  ."     );
            Console.WriteLine(@"             ` ._           ~                ~--. . . . .~=.-'. /. `"        );
            Console.WriteLine(@"       - . -~            -. _ . - ~ - _   - ~     ~--..__~ _,. /   \  - ~"   );
            Console.WriteLine(@"              . __ ..                   ~-               ~~_. (  `"          );
            Console.WriteLine(@")`. _ _               `-       ..  - .    . - ~ ~ .    |    ~-` ` `  `. _"   );
            Thread.Sleep(5000);
            Console.ResetColor();
            Console.Clear();
        }
    } 
}