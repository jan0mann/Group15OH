using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualBasic;

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
            Main_Island = new("Mæinø", "Mæinø, the centeral island of Økompleks", false);
            Northern_Island = new("Oslø", "Oslø, the northern island", false);
            Eastern_Island = new("Tokyø", "Tokyø, the eastern island", false);
            Western_Island = new("Såndiægø", "Såndiægø, the western island", false);
            Southern_Island = new("Sydnø", "Sydnø, the southern island", false);

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
 
        public static bool minigame = false;


        public static bool continuePlaying = true;

        public static int playerPoints = 0; // player score system, if (for example!) player will have 3 points, one for each completed mini game, he can enter coral reef

        public static int totalScore = 0;

        public void Play()
        {

            Parser parser = new();
            
    
            PrintWelcome();

            while (continuePlaying)
            {

                Console.ForegroundColor = ConsoleColor.Cyan;
                Text("\n   > ", 0);
                string? input = Console.ReadLine()?.ToLower();
                Console.ResetColor();

                if (string.IsNullOrEmpty(input))
                {
                    Text("\nPlease enter a command:", 0);
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
                            Instructions();
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
                        case "check":
                            break;
                        
                        case "harbor":
                            if (harbor == true)
                                InvalidCommand();
                            else
                                harbor = true;
                                Harbor();
                            break;

                        case "locals":  
                            switch(currentIsland)
                            {
                                case IslandIndustrial:
                                    IslandIndustrial.Locals();
                                    break;
                                case IslandOil:
                                    IslandOil.Locals();
                                    break;
                                case IslandPlastic:
                                    IslandPlastic.Locals();
                                    break;
                                case IslandCoral:
                                    IslandCoral.Locals();
                                    break;
                                default:
                                    Island.Main_Locals();
                                    break; 
                                }
                            break;

                        case "map":
                            break;    

                        case "start": // starting the minigame
                                minigame = true;
                                switch(currentIsland) 
                                {
                                        case IslandIndustrial:  // making the minigame start only in IslandIndustrial
                                            if(IslandIndustrial.MinigameWon)
                                                AlreadyDone();
                                            else
                                                IslandIndustrial.Story_Minigame(); // here the minigame in industrial starts
                                            break;
                                        case IslandOil:
                                            if(IslandOil.MinigameWon)
                                                AlreadyDone();
                                            else
                                               IslandOil.Story_Minigame(); 
                                            break;
                                        case IslandPlastic:
                                            if(IslandPlastic.MinigameWon)
                                                AlreadyDone();
                                            else
                                                IslandPlastic.Story_Minigame(); 
                                            break;
                                        case IslandCoral:
                                            if(IslandCoral.MinigameWon)
                                                AlreadyDone();
                                            else
                                                IslandCoral.Story_Minigame(); 
                                            break;
                                        default:
                                            Text("No problem here!", 1);
                                            break;
                                }   
                                break;

                        case "back": //going back from where you came from
                            if (harbor == true)
                            {
                                Text("\nYou left the harbor.", 0);
                                harbor = false;
                            }   
                            else if(previousIsland == null)
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
                            }
                            else
                                InvalidCommand();                       
                            break;

                        case "quit":
                                Text("\nThank you for playing Operation Hav!\n", 0);
                                Environment.Exit(0);
                            break;

                        case "help": //printing the print help (direction info)
                                Instructions();
                            break;

                        default:
                                InvalidCommand();
                            break;
                     }

            if(beginning_of_game==false) 
            {       
                Text($"\nYou find yourself on {currentIsland?.ShortDescription}.", 1);
                Text("\nFor further instructions, type 'help'.", 1);
                Text("\nTo leave the game, type 'quit'.", 1);
            }

            }
        }





        private void Move(string direction)
        {
            if (currentIsland?.Exits.ContainsKey(direction) == true)
            {   
                previousIsland = currentIsland;
                currentIsland = currentIsland?.Exits[direction];
                Text($"\nAlright, we take off towards {currentIsland?.Name}!", 3);
                harbor = false;
            }
            else
            {
                Text($"\nYou can't go {direction}! \n(type 'back' to leave the harbor)", 2);
            }
        }










        //Text - Methods !!
        private void PrintWelcome()
        {
            Text("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n", 0); //only for visibility
            Text("Welcome to Operation Hav!\n", 3, ConsoleColor.DarkYellow);
            Text("The United Nations are urgently hiring you, to save the sea waters surrounding a Danish pacific colony called ,,Økompleks'', which consists of five islands.", 3);
            Text("Each islands inhabitants suffer from another problem, which all, however, have one thing in common: They were all caused by man.", 3);
            Text("\nWhat will you do? ", 0, ConsoleColor.Yellow);
            Text("(type accept or refuse)", 0);
        }

        private void Accepted()
        {   
            Text("\nAmazing!", 1);
            Text("\nThe UN immediately responded to your acceptance, assuring you everything necessary has been arranged for you. \nUnsure, you head to the airport...", 3);
            Text("\n\n\n... you arrive on the island of Mæinø, which lies in the center of Økompleks.", 3);
            Text("\n.", 3);
            Text("\nIt is here, where you get to choose your next step.", 3);
        }
        
        private void Refused()
        {
            Text("\nYou refused to help and therefore ignored the hiring.", 3);
            Text("\nYou keep on with your everyday life.", 3);
            Text("\nA few months later, you see in the news that Økomplex has by now become completely uninhabitable, \nall of its surviving people having to be evacuated...", 0);
            GameOver();
            Environment.Exit(0);
        }


        private static void Instructions()
        {
            Text("\n\nWhat are you doing?\n", 1, ConsoleColor.DarkYellow);

            Text("Check", 0, ConsoleColor.Yellow);
            Text(" the current local situation. By doing that, you'll find out your progress and performance.\n", 1); 

            Text("Go to the ", 0);
            Text("harbor", 0, ConsoleColor.Yellow);
            Text(". From there, you can reach the other islands.\n", 1); 

            Text("Talk to the ", 0);
            Text("locals", 0, ConsoleColor.Yellow);
            Text(". They can tell you more about the island you're on, and it's problem.\n", 1);

            Text("View the ", 0); 
            Text("map", 0, ConsoleColor.Yellow);
            Text(". It will display an illustration of Økompleks, and your current location on it.\n", 1);

            Text("\nType ", 0); 
            Text("start", 0, ConsoleColor.Yellow);
            Text(" if you're ready to save the island you're currently on.\n", 1);

            Text("\n(type the colored word)\n", 1);

        }

        private static void Harbor()
        {
            Text($"\nWelcome to the harbor of {currentIsland?.Name}!", 2);
            Text("\nWhat ", 0);
            Text("direction", 0, ConsoleColor.Yellow);
            Text(" do you want to ride to, Captain?", 2);
            Text("(type 'back' to leave)", 1); 
        }

        public static void MinigameVictory()
        {   
            playerPoints++; // Player earns a point after completing the minigame
            minigame = false;        
            Text("\nCongratulations!", 1, ConsoleColor.Yellow);
            Text($"\nYou have completed the task and saved {currentIsland?.Name}!", 3);
            currentIsland = previousIsland;
            Text($"\nYou returned to Mæinø. \n{4 - playerPoints} islands remain!", 3);
        }

        public static void AlreadyDone()
        {
            Text("\nYou have already completed the minigame, and therefore returned to Mæinø. \nThere are more islands to save out there!", 0);
            minigame = false;
            currentIsland = previousIsland;
        }
        public static void GameOver()
        {
            Text("\n\n", 4);
            Console.BackgroundColor = ConsoleColor.Red;
            Text("GAME OVER", 0, ConsoleColor.Black);
            Text("\n\n\n", 2);
        }

        public static void InvalidCommand()
        {
            Text("\nInvalid. Type again.", 1);
        }

        public static void Text(string text, int readtime, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Thread.Sleep(readtime*1000);
            Console.ResetColor();
        }
        public static void Text(string text, int readtime)
        {
            Console.Write(text);
            Thread.Sleep(readtime*1000);
        }
    }
}
