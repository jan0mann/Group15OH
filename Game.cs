using System.ComponentModel;
using System.Drawing;
using System.Net.Http.Headers;
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


        bool beginning_of_game = true;

        public bool harbor = false;

        public static bool gameOver = false;

        public static bool continuePlaying = true;

        public static int playerPoints = 0; 

        public void Play()
        {
            Console.Clear();

            Parser parser = new();

            //Just for testing!!
                //IslandCoral.Story_Minigame();
                //IslandIndustrial.Story_Minigame();
                //IslandOil.Story_Minigame();
                //IslandPlastic.Story_Minigame();

            StartScreen();
            PrintWelcome();
            Choice();

            while (continuePlaying && playerPoints < 4) 
            {
                
                Console.ForegroundColor = ConsoleColor.Yellow;
                Text("\n\n   > ", 0);
                string? input = Console.ReadLine()?.ToLower();
                Console.ResetColor();
                Console.Clear();
                if (string.IsNullOrEmpty(input))
                {
                    Empty();
                    if (beginning_of_game == true)
                        Choice();
                    else if (harbor == true)
                        Harbor();
                    else
                        Instructions();
                    continue;
                }
                Command? command = parser.GetCommand(input);
                if (command == null)
                {
                    Invalid();
                    if (beginning_of_game == true)
                        Choice();
                    else if (harbor == true)
                        Harbor();
                    else
                        Instructions();
                    continue;
                }



                if (beginning_of_game == true)
                {
                    switch(command.Name)
                    {
                        case "accept":
                            beginning_of_game = false;
                            Accepted();
                            break;

                        case "refuse":  //When refusing the offer, a message will be displayed giving the player a learning that he probably should try the game once more because it is needed SDG wise
                            Refused();
                            Play();
                            break;
                    }
                }
                else if (harbor == true)
                {
                    switch(command.Name)
                    {
                        case "north":
                        case "south":
                        case "east" :
                        case "west":
                            {
                                Console.Clear();                                     
                                Move(command.Name);
                            }
                            break;
                        
                        case "back": //going back from where you came from
                            {
                                Console.Clear();
                                harbor = false;
                                Text("You left the harbor.", 2);
                            }   
                            break;
                    }
                }
                else
                    switch(command.Name)
                    {   
                        case "harbor":
                            {
                                harbor = true;
                                Harbor();
                            }
                            break;

                        /*case "locals":  
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
                                    Main_Locals();
                                    break; 
                            }
                            break;

                        case "map":
                            Visuals.Map(currentIsland);
                            Text("\nPress Enter to close the map.", 0);
                            PressEnter();
                            break; */

                        case "start": // starting the minigame
                            switch(currentIsland) 
                            {
                                case IslandIndustrial:  
                                    if(IslandIndustrial.MinigameWon == true)
                                        AlreadyDone();
                                    else
                                        IslandIndustrial.Story_Minigame(); 
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
                            if(previousIsland == null)
                                Invalid();
                            else
                                currentIsland = previousIsland;
                            break;

                        case "info":
                            break;
                        
                        case "quit":
                                Quit();
                            break;
                    }

                if(beginning_of_game==false && harbor==false && playerPoints < 4)
                {
                    Text("Your current status:", 2, ConsoleColor.DarkYellow);
                    Visuals.Map(currentIsland); 
                    Status();
                    Instructions();
                }
            }

            //Once the game is beaten:
            Ending();
        }



        private void Move(string direction)
        {
            if (currentIsland?.Exits.ContainsKey(direction) == true)
            {   
                harbor = false;
                previousIsland = currentIsland;
                currentIsland = currentIsland?.Exits[direction];
                Text($"Alright, we take off towards {currentIsland?.Name}! Lets get you to work!", 3);
                Console.Clear();
            }
            else
            {
                Text($"There is no island in {direction}ern direction!", 2);
                Console.Clear();
                Harbor();
            }
        }



        //Text - Methods !!
        private void StartScreen()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n\n\n\n Please enter the game in full screen of your choosen device! \n Press Enter to continue \n\n\n\n\n\n",0);
            PressEnter();
            
            Visuals.TitleScreen();
            Console.ResetColor();
            PressEnter();
        }

        private void PrintWelcome()
        {
            Text("Welcome to Operation Hav!", 3, ConsoleColor.Yellow);
            Text("\n\nThe United Nations are urgently hiring you, to save life below water surrounding a Danish pacific colony called ,,Økompleks'', which consists of five islands.", 3);
            Text("\nEach islands inhabitants suffer from another problem, which all, however, have one thing in common:", 3);
            Text("\nThey were all caused by man.", 3);
            Console.Clear();
            Text("It is now up to if you either accept the hiring and take on the challenge to work with the UN to stay on track for the goals regarding sustainable goal 14!",4,ConsoleColor.Blue);
            Text("\nYou will get help along the way from locals on each island if you call for them. Elsewise it could get tough to complete all challenges that you will meet along the way.",4,ConsoleColor.Blue);
            Text("\nIf you choose to refuse it would be a huge mess. You are the UN's and locals last hope for a change to the better. Therefore please try to do your best for the people, \nfor the future!\n\n",6,ConsoleColor.Blue);
            Console.Clear();
        }    

        private static void Choice()  
        {  
            Text("Will you ", 0);
            Text("accept", 0, ConsoleColor.Yellow);
            Text(" or ", 0);
            Text("refuse", 0, ConsoleColor.Yellow);
            Text(" to help?", 2);
        }

        private void Accepted()
        {   
            Text("Amazing!", 2);
            Text("\n\nThe UN immediately responded to your acceptance, assuring you everything necessary has been arranged for you.", 3);
            Text("\n\nUnsure, you head to the airport...", 3);
            Console.Clear();
            Text("...you arrive on the island of Mæinø, which lies in the center of Økompleks.", 3);
            Text("\n\nA UN referant walks up to you.", 3);
            Visuals.NPC0();
            Text("Thank you so much for coming. Hopefully we can solve all this with your help.", 3, ConsoleColor.Green);
            Text("\nI am here to hand you a few things before you start:", 3, ConsoleColor.Green);
            Console.Clear();
            Text("First, you'll get from me those two suits: A 'diving suit' and an 'anti-hazardous suit'.", 3, ConsoleColor.Green);
            Text("\nThen I have this 'skimmer' for you. With it you can gather oil pollutions out of the sea.", 3, ConsoleColor.Green);
            Text("\n\nYou don't need those things now, but you'll know when you do, so don't worry.", 3, ConsoleColor.Green);
            Text("\n\nLast but not least, take this 'map'. With it you can always see your position.", 3, ConsoleColor.Green);
            Visuals.Map(currentIsland);
            Text("That's all for now.", 2, ConsoleColor.Green);
            Text("\nThis island here doesn't pose as a problem as of now. But it will if we don't hurry up.", 3, ConsoleColor.Green);
            Text("\nI suggest you go to the harbor and start right away with your work. Good luck.", 3, ConsoleColor.Green);
            Text("\n\nThe referant walks away...", 3);
            Console.Clear();
        }
        
        private void Refused()
        {
            Text("You refused to help and therefore ignored the hiring.", 3);
            Text("\nYou keep on with your everyday life.", 3);
            Console.ForegroundColor = ConsoleColor.Red;
            Text("\n\nYears later, the news flashes grim headlines:", 2);
            Text("\nØkomplex, once a vibrant coastal community, was now completely uninhabitable. ", 2);
            Text("\nRising seas had swallowed the last homes, and saltwater intrusion made the land barren. ", 2);
            Text("\nYou watch in silence, remembering the coral reefs and bustling harbors of the Island Kompleks you once had the chance to save. ", 2);
            Text("\nThen, you turned down the offer not expecting much to happen. You were so wrong!! ", 2);
            Text("\nDismissing efforts to protect life below water resultet in a ghost town — ", 2);
            Text("\nA monument to humanity's neglect.", 2);
            Console.ResetColor();
            GameOver();
        }


        public static void Instructions()
        {
            
            Text("You now have the following options:\n", 2, ConsoleColor.DarkYellow);

            Text("\nType ", 0);
            Text("harbor", 0, ConsoleColor.Yellow);
            Text(" to get to the other islands.", 1); 
            
            /*Text("\n\nTalk to the ", 0);
            Text("locals", 0, ConsoleColor.Yellow);
            Text(". Perhaps they can tell you more about the island you're on, and it's problem.", 1);
            
            Text("\n\nView the ", 0); 
            Text("map", 0, ConsoleColor.Yellow);
            Text(". It will display an illustration of Økompleks, and your current location on it.", 1);   */
            
            Text("\n\nType ", 0); 
            Text("start", 0, ConsoleColor.Yellow);
            Text(" if you're ready to save the island you're currently on.", 1);

            Text("\n\nType ", 0); 
            Text("info", 0, ConsoleColor.Yellow);
            Text(" to see your current status.", 1);

            Text("\n\nType ", 0); 
            Text("quit", 0, ConsoleColor.Yellow);
            Text(" if you want to leave the game.", 1);

            Text("\n\nWhat are you doing?", 0, ConsoleColor.DarkYellow);
        }
        private static void Status()
        {
            Text($"You currently find yourself on {currentIsland?.ShortDescription}.", 2);
            Console.Clear();
            Text("You have saved ", 0);
            Text($"{playerPoints} / 4", 0, ConsoleColor.Green);
            Text(" islands.", 2);
            Console.Clear();
        }

        private static void Harbor()
        {
            Text($"Welcome to the harbor of {currentIsland?.Name}!", 2);
            if (currentIsland?.Name == "Mæinø")
            {
                Text("\nWhat direction do you want to ride to, Captain?", 2);
                Text("\n\nnorth ", 0, ConsoleColor.Yellow);
                Text("for Oslø,", 0); 
                Text("\neast " , 0, ConsoleColor.Yellow);
                Text("for Tokyø,", 0); 
                Text("\nsouth ", 0, ConsoleColor.Yellow); 
                Text("for Sydnø and ", 0); 
                Text("\nwest ", 0, ConsoleColor.Yellow); 
                Text("for Såndiægø ", 0);
                Text("\n\n(type 'back' to leave)\n", 1, ConsoleColor.DarkGray); 
            }
            else
                Text("If you want to return to Mæinø, type ", 0);
                Text("back.", 2, ConsoleColor.Yellow);
        }

        public static void MinigameVictory()
        {   
            Console.Clear();
            playerPoints++; // Player earns a point after completing the minigame       
            Text("Congratulations!", 1, ConsoleColor.Yellow);
            Text($"\n\nYou have completed the task and saved {currentIsland?.Name}!", 3);
            currentIsland = previousIsland;
            Text("\nYou returned to Mæinø.", 1);
            Text($"\n{4 - playerPoints} islands remain!", 3);
            Console.Clear();
        }

        public static void AlreadyDone()
        {
            Text("You have already completed the minigame, and therefore returned to Mæinø.", 3);
            Text($"\nThere are {4 - playerPoints} more islands to save out there!", 3);
            currentIsland = previousIsland;
        }

        private static void Ending()
        {
            Console.Clear();
            Text("Congratulations!", 3, ConsoleColor.DarkYellow);
            Console.Clear();
            Text("You saved all four islands and cleared Operation Hav!", 3, ConsoleColor.DarkYellow);
            Console.Clear();
            Text("We hope you enjoyed our little game and learned something from it!", 5, ConsoleColor.DarkYellow);
            Console.Clear();
            Text("So, in case we don't see ya (anymore):", 3, ConsoleColor.DarkYellow);
            Console.Clear();
            Text("Good afternoon! <3", 1, ConsoleColor.DarkYellow);
            Console.Clear();
            Text("Good evening!   <3", 1, ConsoleColor.DarkYellow);
            Console.Clear();
            Text("Good night!     <3", 1, ConsoleColor.DarkYellow);
            Console.Clear();
            //Environment.Exit(0);
        }

        public static void NoProblemHere()
        {
            Text("There are no problems here to tackle! But for sure the other islands have problems ahead for you.\n", 3);
        }
        public static void Quit()
        {
            Console.Clear();
            Text("\nThank you for playing Operation Hav!",3);
            Text("\n\nWe hope you have learnt something about the SDG 14 regarding 'Life below Water'.", 3);
            Text("\nWe are sorry to see you go already, but therefore we will sum up the most important knowledge for you:\n", 3);
            Text("\n- Biodiversity Preservation: Oceans house over 80% of Earth's species, making them essential for maintaining ecological balance and preventing mass extinctions.", 3, ConsoleColor.DarkMagenta);
            Text("\n- Climate Regulation: Oceans act as a carbon sink, absorbing CO₂ and moderating global temperatures, but their capacity depends on healthy ecosystems like coral reefs and seagrass meadows.", 3, ConsoleColor.DarkMagenta);
            Text("\n- Food Security: Over 3 billion people rely on seafood as their primary protein source; protecting marine life ensures sustainable fisheries for future generations.", 3, ConsoleColor.DarkMagenta);
            Text("\n- Disaster Mitigation: Healthy ecosystems like coral reefs and mangroves buffer coastal areas from storms and rising sea levels, safeguarding communities from devastation.", 3, ConsoleColor.DarkMagenta);
            Environment.Exit(0);
        }

        public static void GameOver()
        {
            Text("\n\n", 0);
            Console.BackgroundColor = ConsoleColor.Red;
            Text("GAME OVER", 5, ConsoleColor.Black);
            Retry();
        }

        public static void Retry()
        {
            Console.Clear();
            Text("Do you want to retry? (y/n)\n", 1);
                var key = Console.ReadKey(intercept: true).Key;
                switch (key)
                {
                    case ConsoleKey.Y:
                        break;
                    case ConsoleKey.N:
                        Environment.Exit(0);
                        break;
                    default:
                        Invalid();
                        Retry();
                        break;
                }
        }


        public static void Empty()
        {
            Text("Please enter a command.", 2, ConsoleColor.DarkGray);
            Console.Clear();
        }
        public static void Invalid()
        {
            Text("Invalid input. Please type again.", 2, ConsoleColor.DarkGray);
            Console.Clear();
        }



        //Displaying methods
        
        public static void Text(string text, int readtime)
        {
            Console.Write(text);
            Thread.Sleep(readtime*1000);
        }
        
        public static void Text(string text, int readtime, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Text(text, readtime);
            Console.ResetColor();
        }
        

        public static void Center(string message)
        {
            int screenWidth = Console.WindowWidth;
	        int stringWidth = message.Length;
	        int spaces = (screenWidth / 2) + (stringWidth / 2);

	        Console.WriteLine(message.PadLeft(spaces));
        }



        public static void PressEnter()
        {
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Enter)
                    break; // Exit the loop when Tab is pressed
            }
            Console.Clear();
        }
    }
}
