using System.Drawing;

namespace OperationHav
{
    public class Game
    {
        private Island? currentIsland;
        private Island? previousIsland;

        public Game()
        {
            CreateIslands();
        }

        private void CreateIslands()
        {
  
            Island? Main_Island = new("\nYou are on main island in the center of the archipelago.", "\nOnce a beautiful paradise, now it is on the brink of becoming a wasteland. \nThere is a harbor nearby, as well as the markedplace, where the locals and their knowledge can be found. \nHere the consequences of all other problems, carry over.");
            IslandIndustrial? Northern_Island = new("\nThe northern island.", "\nThis island suffers from extreme industrial waste, because it used to serve as a secret industrial outpost to the Soviet-Union during the Cold War. Ever since the latter fell, however, no one came to clean, or even dismantle the old facilities, leaving our island a gigantic junkyard ...");
            IslandOil? Eastern_Island = new("\nThe eastern island.", "\nDue to major American trade routes near the island, a lot of spilled oil has gathered around the island, contaminating its waters…");
            IslandPlastic? Western_Island = new("\nThe western island.", "\nThis island is closest to the Asian mainland, making it a collecting point for huge quantities of Chinese plastic waste…");
            IslandCoral? Southern_Island = new("\nThe southern island.", "\nIt is the only island affected by more than one problem, and those happen to be the ones of ALL the other islands! And to make things even worse, it is exactly there where our biggest and most important coral reef is located! Somebody needs to do something before it dies off…");

            Main_Island.SetExits(Northern_Island, Eastern_Island, Southern_Island, Western_Island); // North, East, South, West

            Northern_Island.SetExit("south", Main_Island);

            Eastern_Island.SetExit("west", Main_Island);

            Southern_Island.SetExit("north", Main_Island);

            Western_Island.SetExit("east", Main_Island);
            
            currentIsland = Main_Island;
        }

        bool beginning_of_game = true;
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

                string? input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Please enter a command:");
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


                    case "back": //going back from where you came from
                        if (previousIsland == null)
                            Console.WriteLine("You can't go back from here!");
                        else
                            currentIsland = previousIsland;
                        break;


                    case "north":
                    case "south":
                    case "east" :
                    case "west":
                        if (beginning_of_game == false)
                            Move(command.Name);
                        else 
                            Console.WriteLine(invalid_command);
                        break;


                    case "quit":
                        if (beginning_of_game == false)
                            Console.WriteLine("Thank you for playing Operation Hav!");
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
                            Console.WriteLine("\nAmazing! \nThe UN immediately responded to your acceptance, assuring you everything necessary has been arranged for you. \nUnsure, you head to the airport...");
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
            Console.WriteLine("Welcome to Operation Hav!");
            Console.ResetColor();
            Console.WriteLine("The United Nations are urgently hiring you, to save the sea waters surrounding pacific archipelago IslandComplex, which consists of five islands. \nEach islands inhabitants suffer from another problem, which all, however, have one thing in common: They were all caused by mankind.");
            Console.WriteLine("Do you accept the invitation to save IslandComplex? (type accept or refuse) ");
            
        }

        private static void PrintHelp()
        {
            Console.WriteLine();
            Console.Write("Navigate by typing"); 
            Console.ForegroundColor = ConsoleColor.Yellow; //highligting the commands
            Console.Write(" north");
            Console.ResetColor();
            Console.Write(",");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" south");
            Console.ResetColor();
            Console.Write(","); 
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" east");
            Console.ResetColor();
            Console.Write(", or"); 
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" west");
            Console.ResetColor();
            Console.Write(":\n");
            Console.Write("Type");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" look"); 
            Console.ResetColor();
            Console.Write(" for more details.\n");
            Console.Write("Type"); 
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" back");
            Console.ResetColor();
            Console.Write(" to go to the previous Island.\n");
            Console.Write("Type");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" help"); 
            Console.ResetColor();
            Console.Write(" to print this message again.\n");
            Console.Write("Type");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" quit");
            Console.ResetColor();
            Console.Write(" to exit the game.");
        }
    }
}
