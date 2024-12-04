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
            Main_Island = new("Mæinø", "Mæinø, the central island of Økompleks");
            Northern_Island = new("Oslø", "Oslø, the northern island");
            Eastern_Island = new("Tokyø", "Tokyø, the eastern island");
            Western_Island = new("Såndiægø", "Såndiægø, the western island");
            Southern_Island = new("Sydnø", "Sydnø, the southern island");

            Main_Island.SetExits(Northern_Island, Eastern_Island, Southern_Island, Western_Island); // North, East, South, West

            Northern_Island.SetExit("south", Main_Island);

            Eastern_Island.SetExit("west", Main_Island);

            Southern_Island.SetExit("north", Main_Island);

            Western_Island.SetExit("east", Main_Island);
            
            currentIsland = Main_Island;
        }


        //Conditions (or estates), fx: when you're in the harbor, the 'harbor-estate' is activated

        bool startscreen = true;
        bool beginning_of_game = true;

        public bool harbor = false;
 
        public static bool minigame = false;

        public static bool gameOver = false;

        public static bool continuePlaying = true;

        public static int playerPoints = 0; // player score system, if (for example!) player will have 3 points, one for each completed mini game, he can enter coral reef

        public static int totalScore = 0;

        public void Play()
        {
            Parser parser = new();

            //Just for testing!!
                //IslandCoral.Story_Minigame();
                //IslandIndustrial.Story_Minigame();
                //IslandOil.Story_Minigame();
                //IslandPlastic.Story_Minigame();

            StartScreen();

            ConsoleKey start = Console.ReadKey(true).Key;

            if (start == ConsoleKey.Spacebar) 
            {
                PrintWelcome();
                startscreen = false;
            }
            else
                Play();

            while (continuePlaying && startscreen == false)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Text("\n\n   > ", 0);
                string? input = Console.ReadLine()?.ToLower();
                Console.ResetColor();
                Console.Clear();

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

                        case "refuse":  //When refusing the offer, a message will be displayed giving the player a learning that he probably should try the game once more because it is needed SDG wise
                            Refused();
                            break;

                        default:
                            InvalidCommand();
                            break;
                    }
                }
                else if (gameOver == true)
                {
                    switch(command.Name)
                    {
                        case "accept":
                            
                            break;
                        case "refuse":
                            Environment.Exit(0);
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
                            if (playerPoints > 0)
                                Text($"You so far have saved {playerPoints} out of 4 Islands!\n", 0);
                            else
                                Text("You haven't made any progress yet.\n", 0);
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
                            Visuals.Map();
                            break;    

                        case "start": // starting the minigame
                                minigame = true;
                                switch(currentIsland) 
                                {
                                        case IslandIndustrial:  // making the minigame start only in IslandIndustrial
                                            if(IslandIndustrial.MinigameWon == true)
                                                AlreadyDone();
                                            else
                                                IslandIndustrial.Story_Minigame(); // here the minigame in industrial starts
                                            break;
                                        case IslandOil:
                                            if(IslandOil.MinigameWon == true)
                                                AlreadyDone();
                                            else
                                               IslandOil.Story_Minigame(); 
                                            break;
                                        case IslandPlastic:
                                            if(IslandPlastic.MinigameWon == true)
                                                AlreadyDone();
                                            else
                                                IslandPlastic.Story_Minigame(); 
                                            break;
                                        case IslandCoral:
                                            if(IslandCoral.MinigameWon == true)
                                                AlreadyDone();
                                            else
                                                IslandCoral.Story_Minigame(); 
                                            break;
                                        default:
                                            NoProblemHere();
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
                                Console.Clear();                                     
                                Move(command.Name);
                            }
                            else
                                InvalidCommand();                       
                            break;

                        case "quit":
                                Quitted();
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
                Text("\nFor further instructions, type 'help'.", 1, ConsoleColor.DarkGray);
                Text("\nTo leave the game, type 'quit'.", 1, ConsoleColor.DarkGray);
            }

            }
        }





        private void Move(string direction)
        {
            if (currentIsland?.Exits.ContainsKey(direction) == true)
            {   
                previousIsland = currentIsland;
                currentIsland = currentIsland?.Exits[direction];
                Text($"\nAlright, we take off towards {currentIsland?.Name}! Lets get you to work!\n", 3);
                harbor = false;
            }
            else
            {
                Text($"\nYou can't go {direction}! \n(type 'back' to leave the harbor)", 2);
            }
        }










        //Text - Methods !!
        private void StartScreen()
        {
            Console.Clear();
            Text("OpHav", 5);
            Text("Please press 'space' to start", 0);
        }

        private void PrintWelcome()
        {
            Console.Clear();
            Text("Welcome to Operation Hav!\n", 3);
            Text("The United Nations are urgently hiring you, to save life below water surrounding a Danish pacific colony called ,,Økompleks'', which consists of five islands.", 3);
            Text("Each islands inhabitants suffer from another problem, which all, however, have one thing in common: They were all caused by man.\n", 3);
            Text("\nIt is now up to if you either accept the hiring and take on the challenge to work with the UN to stay on track for the goals regarding sustainable goal 14!",0,ConsoleColor.Blue);
            Text("\nYou will get help along the way from locals on each island if you call for them. Elsewise it could get tough to complete all challenges that you will meet along the way.",0,ConsoleColor.Blue);
            Text("\nIf you choose to refuse it would be a huge mess. You are the UN's and locals last hope for a change to the better. Therefore please try to do your best for the people, for the future!\n",0,ConsoleColor.Blue);
            Text("\nWhat will you do? ", 0, ConsoleColor.Yellow);
            Text("(type accept or refuse)", 0);
        }

        private void Accepted()
        {   
            Text("\nAmazing!", 2);
            Console.Clear();
            Text("\nThe UN immediately responded to your acceptance, assuring you everything necessary has been arranged for you. \nUnsure, you head to the airport...", 3);
            Text("\n\n\n... you arrive on the island of Mæinø, which lies in the center of Økompleks.", 3);
            Text("\nIt is here, where you get to choose your next step.", 3);
            Console.Clear();
        }
        
        private void Refused()
        {
            Text("\nYou refused to help and therefore ignored the hiring.", 3);
            Text("\nYou keep on with your everyday life.", 3);
            Console.ForegroundColor = ConsoleColor.Red;
            Text("\n\nYears later, the news flashes grim headlines:", 2);
            Text("\nØkomplex, once a vibrant coastal community, was now completely uninhabitable. ", 2);
            Text("\nRising seas had swallowed the last homes, and saltwater intrusion made the land barren. ", 2);
            Text("\nYou watch in silence, remembering the coral reefs and bustling harbors of the Island Kompleks you once had the chance to save. ", 2);
            Text("\nThen, you turned down the offer not expecting much to happen. You were so wrong!! ", 2);
            Text("\nDismissing efforts to protect life below water resultet in a ghost town — ", 2);
            Text("\nA monument to humanity’s neglect.", 2);
            Console.ResetColor();
            GameOver();
            Environment.Exit(0);
        }


        private static void Instructions()
        {
            Text("What are you doing?\n", 1, ConsoleColor.DarkYellow);

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
            Text("\n\n'north' ", 0, ConsoleColor.Yellow);
            Text("for Oslø,", 0); 
            Text("'east'" , 0, ConsoleColor.Yellow);
            Text("for Tokyø,", 0); 
            Text("'south' ", 0, ConsoleColor.Yellow); 
            Text("for Sydnø and ", 0); 
            Text("'west' ", 0, ConsoleColor.Yellow); 
            Text("for Såndiægø ", 0);
            Text("(type 'back' to leave)\n", 1); 
        }

        public static void MinigameVictory()
        {   
            Console.Clear();
            playerPoints++; // Player earns a point after completing the minigame
            minigame = false;        
            Text("\n\nCongratulations!\n", 1, ConsoleColor.Yellow);
            Text($"\nYou have completed the task and saved {currentIsland?.Name}!", 3);
            currentIsland = previousIsland;
            Text($"\nYou returned to Mæinø. \n{4 - playerPoints} islands remain!\n", 3);
            Console.Clear();
        }

        public static void AlreadyDone()
        {
            Text($"\nYou have already completed the minigame, and therefore returned to Mæinø. \nThere are {4 - playerPoints} more islands to save out there!", 3);
            minigame = false;
            currentIsland = previousIsland;
        }

        public static void NoProblemHere()
        {
            Text("There are no problems here to tackle! But for sure other islands have problems ahead for you.\n", 3);
            minigame = false;
        }
        public static void Quitted()
        {
            Console.Clear();
            Text("\nThank you for playing Operation Hav!",3);
            Text("\nWe hope you have learnt something about the SDG 14 regarding 'Life below Water'.", 3);
            Text("\nWe are sorry to see you go already, but therefore we will sum up the most important knowledge for you:\n", 3);
            Text("\n- Biodiversity Preservation: Oceans house over 80% of Earth's species, making them essential for maintaining ecological balance and preventing mass extinctions.\n", 3, ConsoleColor.DarkMagenta);
            Text("- Climate Regulation: Oceans act as a carbon sink, absorbing CO₂ and moderating global temperatures, but their capacity depends on healthy ecosystems like coral reefs and seagrass meadows.\n", 3, ConsoleColor.DarkMagenta);
            Text("- Food Security: Over 3 billion people rely on seafood as their primary protein source; protecting marine life ensures sustainable fisheries for future generations.\n", 3, ConsoleColor.DarkMagenta);
            Text("- Disaster Mitigation: Healthy ecosystems like coral reefs and mangroves buffer coastal areas from storms and rising sea levels, safeguarding communities from devastation.\n\n", 3, ConsoleColor.DarkMagenta);
            Environment.Exit(0);
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
