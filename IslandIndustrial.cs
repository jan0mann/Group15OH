namespace OperationHav
{
    public class IslandIndustrial : Island
    {
        public IslandIndustrial(string name, string shortDesc) : base(name, shortDesc)
        {
            Name = name;
            ShortDescription = shortDesc;
        }
        public static bool MinigameWon = false;

        public static void Locals() // I (Noah) think methods for texts are better, because that way we have more freedom using text color, delays etc.
        {
            if (MinigameWon)
            {
                Game.Text("Thank you for saving our island!", 3);
            }
            else
            {
                Game.Text("\nNear the shore you meet an old man, who used to work in the factories.", 3);
                Game.Text("\nYou start asking him about those old factories, which litter the entire island in trash.\nHe explains:", 3);
                Game.Text("\nOslø has been suffering for decades now from extreme industrial waste, \nbecause it used to serve as a secret industrial outpost during the war.", 3, ConsoleColor.DarkGreen);
                Game.Text("\nHowever, ever since the war ended, no one came to clean, or even dismantle all those facilities, \nleaving our island and its surrounding waters a gigantic junkyard ...", 3, ConsoleColor.DarkGreen);
            }
        }


        //You might wanne use this method here for the minigame itself
        public static void Story_Minigame()
        {
            // STORY/INTRODUCTION
            Game.Text("\nYou go to meet with the local UN referant, who has been analysing the situation.", 3);
            Game.Text("\n\nHe speaks to you:", 1);
            Game.Text("\n\nWelcome! Thank you so much for agreeing to help!", 2, ConsoleColor.DarkGreen);
            Game.Text("\nThe UN supplied us with anti-hazardous suits, as well as special containers, which are provided directly by the spot.", 3, ConsoleColor.DarkGreen);
            Game.Text("\n\nYou put on the suit and you walk straight into the old rusty facility...", 2);
            Game.Text("\n\nThe building looks really old, so you think it's a good idea to hurry up.", 3, ConsoleColor.Red);
            Game.Text("\n\nThe referant, who is still standing outside, shouts:", 2);
            Game.Text("\n\nThis place can fall apart in any moment!", 3, ConsoleColor.DarkGreen);
            Game.Text("\nIf another storm or hurricane happens, the buillding will surely collapse and all of the waste will end up in the water.", 3, ConsoleColor.DarkGreen);
            Game.Text("\nYou need to pick up all the waste from this place and put it in correct containers.", 3, ConsoleColor.DarkGreen);
            Game.Text("\nRemember to sort it properly, otherwise it can have negative impact for environment and can pose safety risks to workers at recycling facilities.", 3, ConsoleColor.DarkGreen);
            Game.Text("I don't have proper equipment to help but I installed a little camera in your suit so I can see your progress. We will stay in contact through the radio.\n Now, let's get to work.", 5, ConsoleColor.DarkGreen);
            Game.Text("\nRemember: \nYellow stuff belongs to ", 0, ConsoleColor.DarkGreen);
            Game.Text("'plastic'! ", 1, ConsoleColor.DarkYellow);
            Game.Text("\nGray stuff to ", 0, ConsoleColor.DarkGreen);
            Game.Text("'metal'!", 1, ConsoleColor.DarkGray);
            Game.Text("\nGreen to ", 0, ConsoleColor.DarkGreen);
            Game.Text("'atomic'! ", 1, ConsoleColor.Green);
            Game.Text("\nBlue to ", 0, ConsoleColor.DarkGreen);
            Game.Text("'rubber'! ", 1, ConsoleColor.DarkBlue);
            Game.Text("\nAnd magenta to ", 0, ConsoleColor.DarkGreen);
            Game.Text("'hardware'!", 2, ConsoleColor.DarkMagenta);
            Game.Text("\n\nYou got it? Good luck!", 2, ConsoleColor.DarkGreen);
            Game.Text("\n\nYou look around, as the entrance to the facility is entirely blocked...", 5);
            Game.Text("\n\nSort the waste? Now??", 5, ConsoleColor.Cyan);

            //GAME START
            int minigamePoints = 0;
            Random random = new();
            Dictionary<string, int> wasteCount = new() // implementing the dictionary to see how many times each waste type was selected
            {
                { "plastic", 0 },
                { "metal", 0 },
                { "atomic", 0 },
                { "rubber", 0 },
                { "hardware", 0 }
            };

            for (int i = 0; i < 10; i++)
            {
                // Filter out waste types that have been selected twice
                var availableWasteTypes = wasteCount.Where(w => w.Value < 2).Select(w => w.Key).ToArray(); // for now this removes waste from pool after it was generated twice but i dont know how it exactly works( used AI)


                string pickedWaste = availableWasteTypes[random.Next(availableWasteTypes.Length)];
                wasteCount[pickedWaste]++; // counting the waste

                Console.Clear();

                if (minigamePoints == 5)
                {
                    Game.Text("\nAs you pick up the rubbish, parts of the roof suddenly start falling down, blocking the entrance to the building.", 4);
                    Game.Text("\nYou can hear the referant speaking through the radio:", 3);
                    Game.Text("\nDon't worry, I'll get some help, hurry up!", 3, ConsoleColor.DarkGreen);
                }

                Game.Text("\nYou have picked up some ", 0);
                switch (pickedWaste)
                {
                    case "plastic":
                        Game.Text("waste", 0, ConsoleColor.DarkYellow);
                        break;
                    case "metal":
                        Game.Text("waste", 0, ConsoleColor.DarkGray);
                        break;
                    case "atomic":
                        Game.Text("waste", 0, ConsoleColor.Green);
                        break;
                    case "rubber":
                        Game.Text("waste", 0, ConsoleColor.DarkBlue);
                        break;
                    case "hardware":
                        Game.Text("waste", 0, ConsoleColor.DarkMagenta);
                        break;

                }
                Game.Text(". Which container does it belong to? (type the word):\n", 2);

                string? container = Console.ReadLine()?.ToLower();

                if (container == pickedWaste)
                {
                    Console.Clear();

                    Game.Text("\nCorrect! You have placed the waste in the right container.", 2);
                    minigamePoints++;

                    if (pickedWaste == "plastic" && wasteCount[pickedWaste] == 1) // adding the text after correctly typed waste
                    {
                        Game.Text("\n It is very important to clean up this plastic. 100,000 marine animals die from plastic pollution every year,\n so by picking this up we contribute to reducing these numbers. ", 4, ConsoleColor.DarkYellow);
                    }

                    if (pickedWaste == "plastic" && wasteCount[pickedWaste] == 2)
                    {
                        Game.Text("\n We need to remember that 1 in 3 fish caught for human consumption contains plastic.\n This may lead to very serious health issues so we need to make sure all of this is cleaned.  ", 4, ConsoleColor.DarkYellow);
                    }

                    if (pickedWaste == "metal" && wasteCount[pickedWaste] == 1)
                    {
                        Game.Text("\n Good job picking up this copper. Its very toxic to marine organisms.", 3, ConsoleColor.DarkGray);
                    }

                    if (pickedWaste == "metal" && wasteCount[pickedWaste] == 2)
                    {
                        Game.Text("\n You removed all the lead from the water!.\n It is highly toxic to marine life and affects the reproduction, you did very good job finding and removing it.", 4, ConsoleColor.DarkGray);
                    }

                    if (pickedWaste == "atomic" && wasteCount[pickedWaste] == 1)
                    {
                        Game.Text("\n Oh, you found some radioactive waste. We need to be sure that all of it is removed from the water\n because it increases cancer rates and causes birth defects.", 4, ConsoleColor.Green);
                    }

                    if (pickedWaste == "atomic" && wasteCount[pickedWaste] == 2)
                    {
                        Game.Text("\n Good job on removing all of the radioactive waste. It could have been the cause of the alterations to marine species DNA's.\n Also, remember to never remove it without special equipment designed for this.\n", 5, ConsoleColor.Green);
                    }

                    if (pickedWaste == "rubber" && wasteCount[pickedWaste] == 1)
                    {
                        Game.Text("\n I can see you have found some old tires. We need to remove them from the water too\n because they are partially made from microplastics which accounts for up to 10% of\n microplastic waste in the world's oceans.", 5, ConsoleColor.DarkBlue);
                    }

                    if (pickedWaste == "rubber" && wasteCount[pickedWaste] == 2)
                    {
                        Game.Text("\n Rubber waste can decompose in the water what may lead to oxygen level in water being reduced and cause harm to marine life.\n It's great that you managed to remove all of it. ", 5, ConsoleColor.DarkBlue);
                    }

                    if (pickedWaste == "hardware" && wasteCount[pickedWaste] == 1)
                    {
                        Game.Text("\n If we don't remove this hardware, the heavy metals it contains will leach into water sources and might cause some health issues. Make sure that you will find all of it.", 4, ConsoleColor.DarkMagenta);
                    }

                    if (pickedWaste == "hardware" && wasteCount[pickedWaste] == 2)
                    {
                        Game.Text("\n You have managed to remove all the hardware. It's important to remember that toxic substances from it can accumulate in tissues of marine organisms\n causing harm to people who consume these contaminated fish.", 5, ConsoleColor.DarkMagenta);
                    }
                }
                else if (string.IsNullOrEmpty(container))
                {
                    Game.Text("\nPlease enter a command:", 0);
                    continue;
                }
                else
                {
                    Console.Clear();

                    Game.Text("\nNo! \nThat's the wrong container!", 2);
                }
            }

            if (minigamePoints < 7)
            {
                Console.Clear();

                Game.Text("\nYou turn around, as you hear some men put the scrap aside which blocks the entrance.", 3);
                Game.Text("\nThe referant comes in and says:", 2);
                Game.Text("\n\nWhat a relief to see you well!", 2, ConsoleColor.DarkGreen);
                Game.Text("\nLet's see now, how you've done cleaning up this place.", 3, ConsoleColor.DarkGreen);
                Game.Text("\n...", 3, ConsoleColor.DarkGreen);
                Game.Text("\nYou've put too much waste in the wrong containers...", 0, ConsoleColor.DarkGreen);
                Game.GameOver();
                Console.Clear();
                Game.Text("Do you want to retry? (y/n)\n", 1);
                string? yN = Console.ReadLine()?.ToLower();
                switch (yN)
                {
                    case "y":
                        Story_Minigame();
                        break;
                    case "n":
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    default:
                        Game.InvalidCommand();
                        break;
                }
            }
            else
            {
                Console.Clear();

                Game.Text("\nYou turn around, as you hear some men put the scrap aside which blocks the entrance.", 3);
                Game.Text("\nThe referant comes in and says:", 2);
                Game.Text("\n\nWhat a relief to see you well!", 2, ConsoleColor.DarkGreen);
                Game.Text("\nLet's see now, how you've done cleaning up this place.", 3, ConsoleColor.DarkGreen);
                Game.Text("\n...", 3, ConsoleColor.DarkGreen);
                Game.Text("\nLooks fantastic!", 2, ConsoleColor.DarkGreen);
                Game.Text("\nYou've done a great job sorting the waste. Both my superiors and the locals will be happy to see this.", 5, ConsoleColor.DarkGreen);
                Game.Text("\nThank you so much for your help! From what I've heard, nearby Islands also need help.", 5, ConsoleColor.DarkGreen);
                Game.Text("\nIf you haven't done it yet, I suggest you sail west or east, otherwise,\nyou should check if you can help save the southern island. Good luck!", 7, ConsoleColor.DarkGreen);
                Game.MinigameVictory();
                MinigameWon = true;
            }
        }
    }
}