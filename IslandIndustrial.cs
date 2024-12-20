using System.Net.Mail;
using System.Reflection.PortableExecutable;

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

    

        public static void Story_Minigame()
        {
            // STORY/INTRODUCTION
            Game.Text("You go to meet with the local UN referant, who has been analysing the situation.", 3);
            Game.Text("\nIt turns out, the referant is a... robot?", 3);
            Visuals.NPC3();
            Game.Text("Welcome! Thank you so much for agreeing to help!", 3, ConsoleColor.DarkGray);
            Game.Text("\nPlease don't mind my current condition. We've had some difficulties...", 3, ConsoleColor.DarkGray);
            Game.Text("\nThe UN already supplied special containers, which are provided directly by the spot.", 3, ConsoleColor.DarkGray);
            Console.Clear();
            Game.Text("You put on the anti-hazardous suit which was given to you earlier on Mæinø, and you walk straight into one of the old rusty facilities...", 6);
            Game.Text("\n\nThe building looks really old and the wind from the sea is strong today, so you think it's a good idea to hurry up.", 5, ConsoleColor.Red);
            Game.Text("\n\nThe handicaped referant bot, who is still standing outside, shouts:", 3);
            Game.Text("\n\nCareful! This place can fall apart in any moment!", 3, ConsoleColor.DarkGray);
            Game.Text("\n\nAll of a sudden, the entrance area you just passed, starts collapsing.", 3, ConsoleColor.Red);
            Game.Text("\n\nYou hear the referant shouting:", 3);
            Game.Text("\n\nDo not panick! I will get you help!", 3, ConsoleColor.DarkGray);
            Game.Text("\nThis can take a while though... if you remain able, then maybe already start working!", 4, ConsoleColor.DarkGray);
            Game.Text("\nYou need to pick up all the waste from this place and put it in correct containers.", 5, ConsoleColor.DarkGray);
            Console.Clear();
            Game.Text("Remember: \nYellow stuff belongs to ", 0, ConsoleColor.DarkGray);
            Game.Text("'plastic'! ", 2, ConsoleColor.DarkYellow);
            Game.Text("\nGray stuff to ", 0, ConsoleColor.DarkGray);
            Game.Text("'metal'!", 2, ConsoleColor.DarkGray);
            Game.Text("\nGreen to ", 0, ConsoleColor.DarkGray);
            Game.Text("'atomic'! ", 2, ConsoleColor.Green);
            Game.Text("\nBlue to ", 0, ConsoleColor.DarkGray);
            Game.Text("'rubber'! ", 2, ConsoleColor.DarkBlue);
            Game.Text("\nAnd magenta to ", 0, ConsoleColor.DarkGray);
            Game.Text("'hardware'!", 3, ConsoleColor.DarkMagenta);
            Game.Text("\n\nYou got it? Good luck!", 3, ConsoleColor.DarkGray);
            Console.Clear();
            Game.Text("You look around, as the entrance to the facility is entirely blocked...", 3);
            Game.Text("\nYou start picking up some trash, in order to distract yourself from the shock...", 5);

            //GAMEPLAY
            SortingGame();            
        }

        public static void SortingGame()
        {
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

                Parser parser = new();

                // Filter out waste types that have been selected twice
                var availableWasteTypes = wasteCount.Where(w => w.Value < 2).Select(w => w.Key).ToArray(); // for now this removes waste from pool after it was generated twice but i dont know how it exactly works( used AI)


                string pickedWaste = availableWasteTypes[random.Next(availableWasteTypes.Length)];
                wasteCount[pickedWaste]++; // counting the waste

                Console.Clear();

                Game.Text("You've picked up some ", 0);
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
                Game.Text(". Which container does it belong to? (type the name):", 2);



                Console.ForegroundColor = ConsoleColor.Yellow;
                Game.Text("\n\n   > ", 0);
                string? container = Console.ReadLine()?.ToLower();
                Console.ResetColor();
                Console.Clear();
                if (string.IsNullOrEmpty(container))
                {
                    Game.Empty();
                    continue;
                }
                Command? command = parser.GetCommand(container);
                if (command == null)
                {
                    Game.Invalid();
                    continue;
                }



                if (container == pickedWaste)
                {
                    Console.Clear();

                    Game.Text("Correct! You have placed the waste in the right container.", 2);
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
                else
                {
                    Console.Clear();
                    Game.Text("No! That's the wrong container!", 2);
                }
            }

            //CONCLUSION - VICTORY/FAIL
            Console.Clear();
            Game.Text("You turn around, as you hear some men put the scrap aside which blocks the entrance.", 3);
            Game.Text("\nThe referant carries himself in and says:", 3);
            Game.Text("\n\nWhat a relief to see you well!", 3, ConsoleColor.DarkGray);
            Game.Text("\nLet's see now, how you've done cleaning up this place.", 3, ConsoleColor.DarkGray);
            Console.Clear();
            Game.Text("\n...", 3, ConsoleColor.DarkGray);
            if (minigamePoints < 7)
                Fail();
            else
                Victory();
        }



        static void Fail()
        {
                Game.Text("\nIt seems you've put too much waste in the wrong containers...", 3, ConsoleColor.DarkGray);
                Game.Text("\nNow we have no way to dispose it properly... we need to burn it.", 3, ConsoleColor.DarkGray);
                Game.GameOver();
                Story_Minigame();
        }

        static void Victory()
        {
                Game.Text("\nLooks fantastic!", 3, ConsoleColor.DarkGray);
                Game.Text("\nYou've done a great job sorting the waste. Both my superiors and the locals will be very happy to see this.", 5, ConsoleColor.DarkGray);
                Game.Text("\nWait... You even found my lost parts! Give me some seconds...", 5, ConsoleColor.DarkGray);
                Visuals.NPC33();
                Game.Text("\nNow I'm finally whole again! How could I ever make up for that!", 5, ConsoleColor.DarkGray);
                Game.Text("\nThank you so much for your help!", 5, ConsoleColor.DarkGray);
                Game.MinigameVictory();
                MinigameWon = true;
        }
    }
}