using System.ComponentModel;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;

namespace OperationHav
{
    public class Game
    {
        private Island? currentIsland;
        private Island? previousIsland;
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
  
            Main_Island = new("\nYou are on main island in the center of the archipelago.", "\nOnce a beautiful paradise, now it is on the brink of becoming a wasteland. \nThere is a harbor nearby, as well as the markedplace, where the locals and their knowledge can be found. \nHere the consequences of all other problems, carry over.", "you talked with the locals");
            Northern_Island = new("\nThe northern island.", "\nThis island suffers from extreme industrial waste, because it used to serve as a secret industrial outpost to the Soviet-Union during the Cold War. Ever since the latter fell, however, no one came to clean, or even dismantle the old facilities, leaving our island and its surrounding waters a gigantic junkyard ...","On the shore of the island, you meet an old man.\n You find out that the old factories have polluted the local environment and you need to clean it up.\n Having received from the UN the anti-hazardous suit and special containers, you decide to do it right away.\n");
            Eastern_Island = new("\nThe eastern island.", "\nDue to major American trade routes near the island, a lot of spilled oil has gathered around the island, contaminating its waters…","you talked with the locals");
            Western_Island = new("\nThe western island.", "\nThis island is closest to the Asian mainland, making it a collecting point for huge quantities of Chinese plastic waste…","you talked with the locals");
            Southern_Island = new("\nThe southern island.", "\nIt is the only island affected by more than one problem, and those happen to be the ones of ALL the other islands! And to make things even worse, it is exactly there where our biggest and most important coral reef is located! Somebody needs to do something before it dies off…","you talked with the locals");

            Main_Island.SetExits(Northern_Island, Eastern_Island, Southern_Island, Western_Island); // North, East, South, West

            Northern_Island.SetExit("south", Main_Island);

            Eastern_Island.SetExit("west", Main_Island);

            Southern_Island.SetExit("north", Main_Island);

            Western_Island.SetExit("east", Main_Island);
            
            currentIsland = Main_Island;
        }



        bool beginning_of_game = true;
    
        public bool harbor = false;
 

        public static int playerPoints = 0; // player score system, if (for example!) player will have 3 points, one for each completed mini game, he can enter coral reef


        public void Play()
        {
            Parser parser = new();
            PrintWelcome();

            bool continuePlaying = true;
            string invalid_command = "\nInvalid. Type again.";
            while (continuePlaying)
            {
                if(beginning_of_game == false)
                {
                    Console.WriteLine(currentIsland?.ShortDescription);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("\n   > ");
                    Console.ResetColor();
                }

                string? input = Console.ReadLine().ToLower();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("\nPlease enter a command:");
                    continue;
                }
                

                Command? command = parser.GetCommand(input);

                if (command == null)
                {
                    Console.WriteLine(invalid_command);
                    continue;
                }

                
                    switch(command.Name)
                    {

                        case "look":
                            if (beginning_of_game == false) //Solution for 'locking' the other cases when accept or refuse isn't typed in yet
                                Console.WriteLine(currentIsland?.LongDescription);
                            else 
                                Console.WriteLine(invalid_command);
                            break; 

                        case "harbor":
                            if ((beginning_of_game == false) && (currentIsland.ShortDescription == "\nYou are on main island in the center of the archipelago."))
                            {
                                harbor = true;
                                Console.WriteLine("\n Welcome to the harbor of ,,''! \nWhat direction do you want to ride to, Captain? \n(Type 'back' to leave)");
                                
                            }
                            else 
                                Console.WriteLine(invalid_command);
                            break;
                        

                        case "locals": // adding locals
                            if (beginning_of_game == false)
                            {
                                 if ( currentIsland is IslandIndustrial & playerPoints >= 1) // preventing the player from repeating the minigame
                                {
                                    Console.WriteLine("You have already completed the minigame");
                                    currentIsland = previousIsland;
                                }
                                else 

                                Console.WriteLine(currentIsland?.Locals);
                                Thread.Sleep(4000);
                                if (currentIsland is IslandIndustrial) // making the minigame start only in IslandIndustrial
                                {
                                IslandIndustrial.Minigame(); // start the minigame
                                } // here the minigame in industrial starts

                            }
                            else
                                Console.WriteLine(invalid_command);
                            break;


                        case "back": //going back from where you came from
                            if (harbor == true)
                            {
                                Console.WriteLine("\nYou left the harbor.");
                                harbor = false;
                            }   
                            else if (previousIsland == null)
                                Console.WriteLine("You can't go back from here!");
                            else
                                currentIsland = previousIsland;
                            break;


                        case "north":
                        case "south":
                        case "east" :
                        case "west":
                            if ((beginning_of_game == false) && (harbor == true))   
                            {                   
                                Move(command.Name);
                                harbor = false;
                            }
                            else 
                                Console.WriteLine(invalid_command);
                            break;


                        case "quit":
                            if (beginning_of_game == false)
                                Console.WriteLine("\nThank you for playing Operation Hav!");
                                continuePlaying = false;
                            break;

                        case "refuse": //When refusing the offer, the game will end with a message giving the player a learning that he probably should try the game because it is needed SDG wise
                            if (beginning_of_game == true)
                            {
                                Console.WriteLine("You refused to help and therefore ignored the hiring. \nYou keep on with your everyday life. \nA few months later, you see in the news that ,,” has by now become completely uninhabitable, \nall of its surviving people having to be evacuated...");
                                continuePlaying = false;
                            }
                            else 
                                Console.WriteLine(invalid_command);
                            break;
                        

                        case "accept": //When accepting the offer, the real part of the game begins
                            if (beginning_of_game == true)
                            {  
                                beginning_of_game = false;
                                Accepted();
                                PrintHelp();
                            }
                            else 
                                Console.WriteLine(invalid_command);
                            break;


                        case "help": //printing the print help (direction info)
                            if (beginning_of_game == false)
                                PrintHelp();
                            else 
                                Console.WriteLine(invalid_command);
                            break;


                        default:
                            Console.WriteLine(invalid_command);
                            break;
                    }
            }

            
        }


        private void Move(string direction)
        {
            if (currentIsland?.Exits.ContainsKey(direction) == true)
            {
                previousIsland = currentIsland;
                currentIsland = currentIsland?.Exits[direction];
            }
            else
            {
                Console.WriteLine($"You can't go {direction}!");
            }
        }


        private static void PrintWelcome()
        {
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n"); //only for visibility
            Console.ForegroundColor = ConsoleColor.Yellow; //also for visibility, were the current terminal output starts
            Console.WriteLine("Welcome to Operation Hav!\n");
            Console.ResetColor();
            Console.WriteLine("The United Nations are urgently hiring you, to save the sea waters surrounding pacific archipelago IslandComplex, which consists of five islands. \nEach islands inhabitants suffer from another problem, which all, however, have one thing in common: They were all caused by mankind. (wait)");
            Thread.Sleep(5000);
            Console.WriteLine("\nDo you accept the invitation to save IslandComplex? (type accept or refuse) \n");
            
        }

        private static void Accepted()
        {   
            Console.WriteLine("\nAmazing! \n\nThe UN immediately responded to your acceptance, assuring you everything necessary has been arranged for you. \nUnsure, you head to the airport... (wait)\n");
            Thread.Sleep(5000);
            Console.WriteLine("... you arrive on the island of ,,”, which lies in the center of the archipelago.");
            Thread.Sleep(2500);
            Console.WriteLine("\nYou return to this island by default when leaving an island or finishing its problem.");
            Thread.Sleep(2500);
            Console.WriteLine("\nIt is also here, where you get to choose your next step.");
            Thread.Sleep(2500);
        }

        private static void PrintHelp()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n\nYou now have the following options:\n");
            Console.ResetColor();

            Console.Write("Check the current local ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("situation");
            Console.ResetColor();
            Console.Write(". By doing that, you'll find out your progress and what impact your previous choices/actions had.\n"); 

            Console.Write("Go to the ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("harbor");
            Console.ResetColor();
            Console.Write(". Choose an island to go there and solve its problem.\n"); 

            Console.Write("Talk to the ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("locals");
            Console.ResetColor();
            Console.Write(". Choose an island to get a description of it and its problem, or ask for help.\n");

            Console.Write("Check your ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("inventory"); 
            Console.ResetColor();
            Console.Write(". You'll see the items and resources that you've collected so far.\n");

            Console.Write("View the "); 
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("map");
            Console.ResetColor();
            Console.Write(". It will display the archipelago and tell you your current location.\n");

            Console.Write("\nType");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" help"); 
            Console.ResetColor();
            Console.Write(" to print this message again.\n");

            Console.Write("Type");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" quit");
            Console.ResetColor();
            Console.Write(" to exit the game.\n");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\nWhat are you doing?");
            Console.ResetColor();
            Console.Write(" (type the colored word)\n");
        }
    }
}
