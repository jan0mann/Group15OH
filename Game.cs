using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace OperationHav
{
    public class Game
    {
        private static Island? currentIsland;
        private static Island? previousIsland;


        private Island? Main_Island;
        private IslandIndustrial? Northern_Island;
        private IslandOil? Eastern_Island;
        private IslandPlastic? Western_Island;
        private IslandCoral? Southern_Island;
        
        
        public Game()
        {
            CreateIslands();
        }

        public void CreateIslands()
        {
            Main_Island = new("Mæinø", "Mæinø, the centeral island of Økompleks.", "\nOnce a beautiful paradise, now it is on the brink of becoming a wasteland. \nThere is a harbor nearby, as well as the markedplace, where the locals and their knowledge can be found. \nHere the consequences of all other problems, carry over.", false);
            Northern_Island = new("Oslø", "Oslø, the northern island.", "\nThis island suffers from extreme industrial waste, because it used to serve as a secret industrial outpost to the Soviet-Union during the Cold War. Ever since the latter fell, however, no one came to clean, or even dismantle the old facilities, leaving our island and its surrounding waters a gigantic junkyard ...", false);
            Eastern_Island = new("Tokyø", "Tokyø, the eastern island.", "\nDue to major American trade routes near the island, a lot of spilled oil has gathered around the island, contaminating its waters…", false);
            Western_Island = new("Såndiægø", "Såndiægø, the western island.", "\nThis island is closest to the Asian mainland, making it a collecting point for huge quantities of Chinese plastic waste…", false);
            Southern_Island = new("Sydnø", "Sydnø, the southern island.", "\nIt is the only island affected by more than one problem, and those happen to be the ones of ALL the other islands! And to make things even worse, it is exactly there where our biggest and most important coral reef is located! Somebody needs to do something before it dies off…", false);

            Main_Island.SetExits(Northern_Island, Eastern_Island, Southern_Island, Western_Island); // North, East, South, West

            Northern_Island.SetExit("south", Main_Island);

            Eastern_Island.SetExit("west", Main_Island);

            Southern_Island.SetExit("north", Main_Island);

            Western_Island.SetExit("east", Main_Island);
            
            currentIsland = Main_Island;
        }


        //Conditions (or estates), fx: when you're in the harbor, the 'harbor-estate' is activated
        bool beginning_of_game = true;

        public bool harbor = false;
 
        public bool minigame = false;


        public static bool continuePlaying = true;

        public static int playerPoints = 0; // player score system, if (for example!) player will have 3 points, one for each completed mini game, he can enter coral reef



        public void Play()
        {

            Parser parser = new();
            
    
            PrintWelcome();

            while (continuePlaying)
            {

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\n   > ");
                string? input = Console.ReadLine()?.ToLower();
                Console.ResetColor();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("\nPlease enter a command:");
                    continue;
                }
                
                Command? command = parser.GetCommand(input);

                if (command == null)
                {
                    InvalidCommand();
                    continue;
                }



                if (beginning_of_game == true)
                {
                    switch(command.Name)
                    {
                        case "accept":
                            beginning_of_game = false;
                            Accepted();
                            PrintHelpMain();
                            break;

                        case "refuse":  //When refusing the offer, the game will end with a message giving the player a learning that he probably should try the game because it is needed SDG wise
                            Refused();
                            break;

                        default:
                            InvalidCommand();
                            break;
                    }
                }

                else if (continuePlaying == true && beginning_of_game == false && minigame == false)
                    switch(command.Name)
                    {
                        //case "check":
                        //    break;
                        
                        case "harbor":
                            if (harbor == true)
                                InvalidCommand();
                            else
                                harbor = true;
                                Console.WriteLine($"\nWelcome to the harbor of {currentIsland?.Name}! \nWhat direction do you want to ride to, Captain? \n(Type 'back' to leave)");
                            break;

                        case "locals":  
                                Console.WriteLine(currentIsland?.LongDescription);
                            break;

                        //case "map":
                        //    break;    

                        case "start": // starting the minigame
                                switch(currentIsland) 
                                    {
                                        case IslandIndustrial:  // making the minigame start only in IslandIndustrial
                                            if(IslandIndustrial.MinigameWon)
                                                AlreadyDone();
                                            else
                                                IslandIndustrial.StoryMinigame(); // here the minigame in industrial starts
                                            break;

                                        //case IslandOil:
                                        //    if(IslandOil.MinigameWon)
                                        //        AlreadyDone();
                                        //    else
                                        //        IslandOil.Minigame(); 
                                        //    break;
                                        
                                        //case IslandPlastic:
                                        //    if(IslandPlastic.MinigameWon)
                                        //        AlreadyDone();
                                        //    else
                                        //        IslandPlastic.Minigame(); 
                                        //    break;

                                        //case IslandCoral:
                                        //    if(IslandCoral.MinigameWon)
                                        //        AlreadyDone();
                                        //    else
                                        //        IslandCoral.Minigame(); 
                                        //    break;
                                    }   
                                break;

                        case "back": //going back from where you came from
                            if (harbor == true)
                            {
                                Console.WriteLine("\nYou left the harbor.");
                                harbor = false;
                            }   
                            else if (previousIsland == null)
                                InvalidCommand();
                            else
                                currentIsland = previousIsland;
                            break;

                        case "north":
                        case "south":
                        case "east" :
                        case "west":
                            if (harbor == true)
                            {                                     
                                Move(command.Name);
                                harbor = false;
                            }
                            else
                                InvalidCommand();                       
                            break;

                        case "quit":
                                Console.WriteLine("\nThank you for playing Operation Hav!\n");
                                
                                Environment.Exit(0);
                            break;

                        case "help": //printing the print help (direction info)
                                PrintHelpMain();
                            break;

                        default:
                                InvalidCommand();
                            break;
                     }

                     Console.WriteLine($"\n(You are on {currentIsland?.ShortDescription})");

            }
        }



        private void Move(string direction)
        {
            if (currentIsland?.Exits.ContainsKey(direction) == true)
            {   
                previousIsland = currentIsland;
                currentIsland = currentIsland?.Exits[direction];
                Console.WriteLine($"\nAlright, we take off towards {currentIsland?.Name}!");
            }
            else
            {
                Console.WriteLine($"\nYou can't go {direction}!");
            }
        }



        //Text - Methods !!
        private void PrintWelcome()
        {
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n"); //only for visibility
            Console.ForegroundColor = ConsoleColor.Yellow; //also for visibility, were the current terminal output starts
            Console.WriteLine("Welcome to Operation Hav!\n");
            Console.ResetColor();
            Thread.Sleep(2500);
            Console.WriteLine("The United Nations are urgently hiring you, to save the sea waters surrounding a Danish pacific colony called ,,Økompleks'', which consists of five islands. \nEach islands inhabitants suffer from another problem, which all, however, have one thing in common: They were all caused by mankind. (wait)");
            Thread.Sleep(5000);
            Console.WriteLine("\nDo you accept the invitation to save Økompleks? (type accept or refuse)");
            
        }

        private void Accepted()
        {   
            Console.WriteLine("\nAmazing!\n");
            Thread.Sleep(1500);
            Console.WriteLine("\nThe UN immediately responded to your acceptance, assuring you everything necessary has been arranged for you. \nUnsure, you head to the airport... \n");
            Thread.Sleep(5000);
            Console.WriteLine("\n\n... you arrive on the island of Mæinø, which lies in the center of the archipelago.");
            Thread.Sleep(2500);
            Console.WriteLine("\nYou return to this island by default when leaving an island or finishing its problem.");
            Thread.Sleep(2500);
            Console.WriteLine("\nIt is also here, where you get to choose your next step.");
            Thread.Sleep(2500);
        }
        
        private void Refused()
        {
            Console.WriteLine("\nYou refused to help and therefore ignored the hiring. \n");
            Thread.Sleep(2500);
            Console.WriteLine("\nYou keep on with your everyday life. \n");
            Thread.Sleep(2500);
            Console.WriteLine("\nA few months later, you see in the news that Økomplex has by now become completely uninhabitable, \nall of its surviving people having to be evacuated...\n");
            Thread.Sleep(5000);
            GameOver();
        }


        private static void PrintHelpMain()
        {

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n\nYou now have the following options:\n");
            Console.ResetColor();
            Thread.Sleep(1000);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Check");
            Console.ResetColor();
            Console.Write(" the current local situation. By doing that, you'll find out your progress and performance.\n"); 
            Thread.Sleep(1000);

            Console.Write("Go to the ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("harbor");
            Console.ResetColor();
            Console.Write(". Choose an island, go there and solve its problem.\n"); 
            Thread.Sleep(1000);

            Console.Write("Talk to the ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("locals");
            Console.ResetColor();
            Console.Write(". They can tell you more about the island you're on, and it's problem.\n");
            Thread.Sleep(1000);

            Console.Write("View the "); 
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("map");
            Console.ResetColor();
            Console.Write(". It will display the archipelago and tell you your current location.\n");
            Thread.Sleep(1000);

            Console.Write("\nIf you're on an island that still has a problem, you might want to "); 
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("start");
            Console.ResetColor();
            Console.Write(" solving it for good.\n");
            Thread.Sleep(1000);

            Console.Write("\n(Type");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.Write(" help"); 
            Console.ResetColor();
            Console.Write(" to print this message again.)\n");
            Thread.Sleep(1000);

            Console.Write("(Type");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" quit");
            Console.ResetColor();
            Console.Write(" to exit the game.)\n");
            Thread.Sleep(1000);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\nWhat are you doing?");
            Console.ResetColor();
            Console.Write(" (type the colored word)\n");

        }

        public static void MinigameVictory()
        {
            Console.WriteLine($"Congratulations! \nYou have completed the task and saved {currentIsland?.Name}!");
            playerPoints++; // Player earns a point after completing the minigame
            Thread.Sleep(3000);
            Console.WriteLine($"\nYou returned to Mæinø. \n{4 - playerPoints} islands remain!");
            currentIsland = previousIsland;
        }

        public static void AlreadyDone()
        {
            Console.WriteLine("\nYou have already completed the minigame, and therefore returned to Mæinø. \nThere are more islands to save out there!");
            currentIsland = previousIsland;
        }

        public static void GameOver()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Write("GAME OVER");
            Console.ResetColor();
            Console.WriteLine("\n\n\n");
            Thread.Sleep(2000);
            Environment.Exit(0);
        }
        public static void InvalidCommand()
        {
            Console.WriteLine("\nInvalid. Type again.");
            Thread.Sleep(1000);
        }
    }
}
