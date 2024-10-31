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
  
            Island? outside = new("You are on main island in the center of the archipelago.", "You are standing outside the main entrance of the university. To the east is a large building, to the south is a computing lab, and to the west is the campus pub. There is a key on the ground");
            Island? theatre = new("The northern island.", "This island suffers from extreme industrial waste, because it used to serve as a secret industrial outpost to the Soviet-Union during the Cold War. Ever since the latter fell, however, no one came to clean, or even dismantle the old facilities, leaving our island a gigantic junkyard ...");
            Island? pub = new("The eastern island.", "Due to major American trade routes near the island, a lot of spilled oil has gathered around the island, contaminating its waters…");
            Island? lab = new("The western island.", "This island is closest to the Asian mainland, making it a collecting point for huge quantities of Chinese plastic waste…");
            Island? office = new("The southern island.", "It is the only island affected by more than one problem, and those happen to be the ones of ALL the other islands! And to make things even worse, it is exactly there where our biggest and most important coral reef is located! Somebody needs to do something before it dies off…");

            outside.SetExits(null, theatre, lab, pub); // North, East, South, West

            theatre.SetExit("west", outside);

            pub.SetExit("east", outside);

            lab.SetExits(outside, office, null, null);

            office.SetExit("west", lab);

            currentIsland = outside;
        }

        bool beginning_of_game = true;
        public void Play()
        {
            Parser parser = new();

            PrintWelcome();

            bool continuePlaying = true;
            string invalid_command = "Invalid. Type again.";
            while (continuePlaying)
            {
                if( beginning_of_game == true){
               
                }
                else
                Console.WriteLine(currentIsland?.ShortDescription);
                Console.Write("\n"); //adding space in between program output and user input
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("   > ");
                Console.ResetColor();
                

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
