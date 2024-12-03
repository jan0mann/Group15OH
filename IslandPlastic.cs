namespace OperationHav
{
    public class IslandPlastic : Island
    {
        public IslandPlastic(string name, string shortDesc) : base(name, shortDesc)
        {
            Name = name;
            ShortDescription = shortDesc;
        }
        public static bool MinigameWon = false;
        
        public static void Locals() // I (Noah) think methods for texts are better, because that way we have more freedom using text color, delays etc.
        {
            if (MinigameWon)
            {

            }
            else
            {
                Game.Text("\nThis island is closest to the Asian mainland, making it a collecting point for huge quantities of Chinese plastic waste…", 3);
                Game.Text("\nAfter reaching the shore and walking around a bit, you spot a figure not far away. You approach a man that looks more sophisticated than the average citizen. ", 5);
                Game.Text("\nYou greet each other and he tells you that he was a teacher on this island, before it was made a plastic wasteland. He comes here when he needs some time alone to think.", 6);
                Game.Text("\nYou ask him if there is anything to be done for the island to gain its former glory. He gives you some insight:", 1);
                Game.Text("\nIn the recent history of this insular republic, two parties have been fighting for the balance of power:", 3);
                Game.Text("\nThe corporations ", 1, ConsoleColor.Yellow);
                Game.Text("and the ", 1);
                Game.Text("environmentalists.", 1, ConsoleColor.Green);
                Game.Text("\nCorporations operate under the name 'Industrial Association'. Their goals are to make money, the health of the ecosystem is not in their agenda.", 3);
                Game.Text("\nTheir view on the environmentalists is, that they are a group of fearmongerers that are overreacting on the small damage done and that the ecosystem will eventually fix itself.", 5);
                Game.Text("\nThe environmentalists, aka. 'Green Syndicate', strive to mitigate the damage done to the ecosystem and plan to reverse some of its negative consequences.", 4);
                Game.Text("\nThose people hate the corporations with all their heart. They think they are blinded by their greediness and that their goals are futile, since no one takes their wealth to their grave.", 5);
                Game.Text("\nWe must act quickly and support the correct side of history before it's too late. You know what to do...", 1);
            }
        }

        //You might wanne use this method here for the minigame itself
        public static void Story_Minigame()
        {   

            Corporations corporations = new("Industrial Assosiation", 0);
            Environmentalists environmentalists = new("Green Syndicate", 0);

            Game.Text("\n\n\nYou are now called to make decisions for the future of the island.", 3);
            Game.Text("\nWith your succeess over the improvement of the situation on the other islands, you have gained the trust of the locals.", 4);
            Game.Text("\nThe citizens will follow your guidance and example.", 3);
            Game.Text("\nEach of the two parties exerts influence on the island and its people.", 3);
            Game.Text("\nWith your choices, you change the balance of power by taking actions that support each party.", 3);
            Game.Text("\nThe side that has the most support of the population, will help the president the republic's policies.", 4);
            Game.Text("\nWho will you support?", 3, ConsoleColor.Blue);

            
            for (int i = 0; i < 5; i++)
            {
                if (i == 0)
                {
                    Game.Text("\n\n\nYou have been invited for an interview at the biggest broadcasting channel on the island", 3);
                    Game.Text("\nAt some point the interviewer asks you about your opinion on plastic", 3);
                    Game.Text("\nYou can either ", 1);
                    Game.Text("\nadmit ", 0, ConsoleColor.Yellow);
                    Game.Text("that plastic does not pose that much of a threat or ", 0);
                    Game.Text("\nadvise ", 0, ConsoleColor.Green);
                    Game.Text("it's use with consideration.\n", 3);
                    string? answer = Console.ReadLine()?.ToLower();

                    if (string.IsNullOrEmpty(answer))
                    {
                        Game.Text("\n\nPlease enter a command:", 0);
                    }

                    Parser parser = new();
                    Command? command = parser.GetCommand(answer);

                    if (command == null)
                    {
                        Game.InvalidCommand();
                    }




                    if (answer == "admit")
                    {
                        corporations.Influence ++;
                        Game.Text("\n\nYou admit that plastic doesn't cause as big issues on the environment as some people think. Industries can continue producing it in big numbers", 5);
                        Game.Text("\nFun Fact: this is incorrect, because fish, seabirds, sea turtles, and marine mammals can become entangled in or ingest plastic debris, causing suffocation, starvation, and drowning ", 0);
                        Game.Text("\nFun fact: Some alternatives can be: bamboo straws, bags made of fabric or even fishing nets made from micro-algae, making them biodegradable.\n", 0);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(corporations.ToString());
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(environmentalists.ToString());
                        Console.ResetColor();


                    }
                    else if (answer == "advise")
                    {
                        environmentalists.Influence ++;
                        Game.Text("\n\nYou advise that plastic can be very harmful if used thoughtlessly. The industry must limit the production of plastic and search for alternatives.", 0);
                        Game.Text("\nFun Fact: your advise is correct, because fish, seabirds, sea turtles, and marine mammals can become entangled in or ingest plastic debris, causing suffocation, starvation, and drowning ", 0);
                        Game.Text("\nFun fact: Some alternatives can be: bamboo straws, bags made of fabric or even fishing nets made from micro-algae, making them biodegradable.\n", 0);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(corporations.ToString());
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(environmentalists.ToString());
                        Console.ResetColor();

                    }
                    else
                    {
                        Game.InvalidCommand();
                    }

                }

                if (i == 1)
                {

                    Game.Text("\n\n\nYou woke up today and it was warm and sunny, so you decided to go swimming at a nearby beach.", 3);
                    Game.Text("\nWhile you are relaxing and sunbathing, you watch a group of teenagers leaving the beach. It annoys you that they have left their plastic bottles and bags behind.", 5);
                    Game.Text("\nYou think about talking to them and", 0);
                    Game.Text("\nteach ", 0, ConsoleColor.Green);
                    Game.Text("them about responsibility by picking up their trash together. But you could just .", 0);
                    Game.Text("\ncontinue ", 0, ConsoleColor.Yellow);
                    Game.Text("enjoying the sun. You supose that someone will collect the trash at some point.\n", 0);



                    string? answer = Console.ReadLine()?.ToLower();

                    if (string.IsNullOrEmpty(answer))
                    {
                        Game.Text("\n\nPlease enter a command:", 0);
                        continue;
                    }

                    Parser parser = new();
                    Command? command = parser.GetCommand(answer);

                    if (command == null)
                    {
                        Game.InvalidCommand();
                        continue;
                    }

                    if (answer == "teach")
                    {
                        environmentalists.Influence ++;
                        Game.Text("\n\nYou catch up to the youngsters and politely try to make them see sense. You teach them what practises are good and bad and then you help them dispose of their trash. Motivated by your words, the teens go on and clean the whole beach", 7);
                        Game.Text("\nFun Fact: Seas and oceans belong to all of us, they are part of the earth which is our home. It should be our responsibility to keep them clean and healthy.\n", 5);                      
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(corporations.ToString());
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(environmentalists.ToString());
                        Console.ResetColor();
                        

                    }
                    else if (answer == "continue")
                    {
                        corporations.Influence ++;
                        Game.Text("\n\nYou ignore your consciousness, sunbathing was too pleasant to abandon. The beach stays littered and the teenagers will probably do it again.", 0);
                        Game.Text("\nFun Fact: Seas and oceans belong to all of us, they are part of the earth which is our home. It should be our responsibility to keep them clean and healthy.\n", 5);                 
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(corporations.ToString());
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(environmentalists.ToString());
                        Console.ResetColor();
                    }
                    else
                    {
                        Game.InvalidCommand();
                    }
                }

                if (i == 2)
                {

                    Game.Text("\n\n\nYou are at the supermarket and go to the cashier counter to pay for the items.", 0);
                    Game.Text("\nThe person infront of you turns around, she recognises you from the TV. Her face gets a displeased expression when she spots the single-use bottles in your bag.", 0);
                    Game.Text("\nShe asks:'Why buy such bottles? They can be a waste of resources and also harmful for our seas'.", 0);
                    Game.Text("\nBefore you are able to answer, the man behind you seizes the initiative.", 0);
                    Game.Text("\nYou know him as a representative of the plastic bottle company in ... island. He tells the woman that you are free to chose and that environmentalists' fake news must not influence your decision.", 0);
                    Game.Text("\nYou stop a think for a bit.", 0);
                    Game.Text("\nWill you ", 0);
                    Game.Text("\nbuy ", 0, ConsoleColor.Yellow);
                    Game.Text("the bottles ", 0);
                    Game.Text("\nor search for an alternative?\n", 0, ConsoleColor.Green);


                    string? answer = Console.ReadLine()?.ToLower();

                    if (string.IsNullOrEmpty(answer))
                    {
                        Game.Text("\n\nPlease enter a command:", 0);
                        continue;
                    }

                    Parser parser = new();
                    Command? command = parser.GetCommand(answer);

                    if (command == null)
                    {
                        Game.InvalidCommand();
                        continue;
                    }


                    if (answer == "buy")
                    {
                        corporations.Influence ++;
                        Game.Text("\nYou tell the woman that you are an adult and your desicions are your own.The man congratulates you, he will spread the word of your actions. The woman remains disappointed.", 0);
                        Game.Text("\nFun Fact: Plastic bottles can accumulate in sensitive coastal ecosystems and coral reefs.", 0);
                        Game.Text("\nOver time, plastic bottles break down into smaller particles, releasing harmful chemicals into the water", 0);
                        Game.Text("\nBetter alternatives to plastic bottles are: glass bottles, stainless steel bottles, aluminum bottles. They can be used for long periods of time.\n", 0);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(corporations.ToString());
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(environmentalists.ToString());
                        Console.ResetColor();

                    }
                    else if (answer == "alternative")
                    {
                        environmentalists.Influence ++;
                        Game.Text("\nYou tell the man that facts say otherwise. Plastic bottles can indeed pose a serious threat to our seas. The woman congratulates you, she will spread the word of your actions. The man tried to suppress his anger.", 0);
                        Game.Text("\nFun Fact: Plastic bottles can accumulate in sensitive coastal ecosystems and coral reefs.", 0);
                        Game.Text("\nOver time, plastic bottles break down into smaller particles, releasing harmful chemicals into the water", 0);
                        Game.Text("\nBetter alternatives to plastic bottles are: glass bottles, stainless steel bottles, aluminum bottles. They can be used for long periods of time.\n", 0);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(corporations.ToString());
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(environmentalists.ToString());
                        Console.ResetColor();

                    }
                    else
                    {
                        Game.InvalidCommand();
                    }
                }

                if (i == 3)
                {

                    Game.Text("\nThe next day begins with loud voices out of your window. ", 0);
                    Game.Text("\nYou have totally forgotten about the demonstration calling to stop the production of single-use plastic in such numbers.", 0);
                    Game.Text("\nThe people need a strong and prestigious individual to help them with their cause.", 0);
                    Game.Text("\nYou could certainly ", 0);
                    Game.Text("join ", 0, ConsoleColor.Green);
                    Game.Text("them. Their demands are noble.", 0);
                    Game.Text("\nAnother course of action would be to", 0);
                    Game.Text("ridicule", 0, ConsoleColor.Yellow);
                    Game.Text("them on social media. Their requests are unbased.\n", 0);

                    string? answer = Console.ReadLine()?.ToLower();

                    if (string.IsNullOrEmpty(answer))
                    {
                        Game.Text("\n\nPlease enter a command:", 0);
                        continue;
                    }

                    Parser parser = new();
                    Command? command = parser.GetCommand(answer);

                    if (command == null)
                    {
                        Game.InvalidCommand();
                        continue;
                    }



                    if (answer == "join")
                    {
                        corporations.Influence ++;
                        Game.Text("\nSeeing you join them, the already outraged crowd gets more fervorous.", 0);
                        Game.Text("\nMore and more people follow your example and join the protest", 0);
                        Game.Text("\nOne thing is sure, such an effort will not be ingored by the people in power.", 0);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(corporations.ToString());
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(environmentalists.ToString());
                        Console.ResetColor();

                    }
                    else if (answer == "ridicule")
                    {
                        environmentalists.Influence ++;
                        Game.Text("\nSo much struggle for such a topic seems unfounded to you.", 0);
                        Game.Text("\nWatching your posts and your negative attitude, people reconsider about joining the demostration and those already there scatter in a matter of minutes.", 0);
                        Game.Text("\nPeople in power will not care about unserious demonstration attempts.", 0);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(corporations.ToString());
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(environmentalists.ToString());
                        Console.ResetColor();

                    }
                    else
                    {
                        Game.InvalidCommand();
                    }
                }

                if (i == 4)
                {


                    string? answer = Console.ReadLine()?.ToLower();

                    if (string.IsNullOrEmpty(answer))
                    {
                        Game.Text("\n\nPlease enter a command:", 0);
                        continue;
                    }

                    Parser parser = new();
                    Command? command = parser.GetCommand(answer);

                    if (command == null)
                    {
                        Game.InvalidCommand();
                        continue;
                    }

                    if (answer == "admit")
                    {
                        corporations.Influence ++;

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(corporations.ToString());
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(environmentalists.ToString());
                        Console.ResetColor();

                    }
                    else if (answer == "advise")
                    {
                        environmentalists.Influence ++;

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(corporations.ToString());
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(environmentalists.ToString());
                        Console.ResetColor();

                    }
                    else
                    {
                        Game.InvalidCommand();
                    }
                }

            }

            if (corporations.Influence < environmentalists.Influence)
            {
                Game.MinigameVictory();
                MinigameWon = true;
            }
            else
            {
                Game.Text("\n\n\n...", 2);
                Game.Text("\nWith your help, the corporations got to pass their policies. After some time, the situation on the island gets worse. It gets abandoned and never recovers.", 0);
                Game.GameOver();
                Game.Text("Do you want to retry? (y/n)\n", 1);
                string? yN = Console.ReadLine()?.ToLower();
                switch (yN)
                {
                    case "y":
                        Story_Minigame();
                        break;
                    case "n":
                        Environment.Exit(0);
                        break;
                    default:
                        Game.InvalidCommand();
                        break;
                }
            }
        }
    }
}