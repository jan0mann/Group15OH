using System.Security.Cryptography.X509Certificates;

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
        private static bool Teenagers;

        /*public static void Locals() 
        {
                Game.Text("After reaching the shore and walking around a bit, you spot a figure not far away. You approach a man that looks more ", 4);
                Game.Text("\nsophisticated than the average citizen.", 4); 
                Game.Text("\nYou greet each other and start talking. He says:", 4);
                Game.Text("\nThis island is closest to the Asian mainland, making it a collecting point for huge quantities of plastic waste…", 4, ConsoleColor.DarkCyan);
                Game.Text("\nHe keeps on telling you that he used to be a teacher on this island, ", 4);
                Game.Text("\nbefore it was made a plastic wasteland. He comes here when he needs some time alone to think.", 4);
                Game.Text("\nYou ask him if there is anything to be done for the island to gain its former glory. He gives you some insight:", 4);
                Game.Text("\nIn the recent history of this insular republic, two parties have been fighting for the balance of power:", 4, ConsoleColor.DarkCyan);
                Game.Text("\nThe corporations ", 1, ConsoleColor.Red);
                Game.Text("and the ", 0, ConsoleColor.DarkCyan);
                Game.Text("environmentalists.", 1, ConsoleColor.Green);
                Game.Text("\nCorporations operate under the name 'Industrial Association'. Their goals are to make money, the health of the ecosystem is not in their agenda.", 5, ConsoleColor.Red);
                Game.Text("\nTheir view on the environmentalists is, that they are a group of fearmongerers that are overreacting on the small damage done and that the ecosystem will eventually fix itself.", 6, ConsoleColor.DarkCyan);
                Game.Text("\nThe environmentalists, aka. 'Green Syndicate', strive to mitigate the damage done to the ecosystem and plan to reverse some of its negative consequences.", 5, ConsoleColor.Green);
                Game.Text("\nThose people hate the corporations with all their heart. They think they are blinded by their greediness and that their goals are futile, since no one takes their wealth to their grave.", 6, ConsoleColor.DarkCyan);
                Game.Text("\nWe must act quickly and support the correct side of history before it's too late. You know what to do...\n\n", 1, ConsoleColor.DarkCyan);
        }*/


        public static void Story_Minigame()
        {

            Faction corporations = new("Industrial Assosiation", 0);
            Faction environmentalists = new("Green Syndicate", 0);

            Game.Text("You are now called to make decisions for the future of the island and its marine life.", 3);
            Game.Text("\nWith your success over the improvement of the situation on the other islands, you have gained the trust of the locals.", 4);
            Game.Text("\nThe citizens will follow your guidance and example.", 3);
            Game.Text("\nEach of the two parties exerts influence on the island and its people.", 3);
            Game.Text("\nWith your choices, you change the balance of power by taking actions that support each party.", 3);
            Game.Text("\nThe mayor has announced, that by the end of this month, the side that has the most support of the population, will help the president the republic's policies.", 6);
            Game.Text("\n\nWho will you support? Will you save the island's health and its life underwater?", 5, ConsoleColor.Blue);

            Visuals.NPC1();


            int i = 0;

            while (i < 5)
            {
                Parser parser = new();

                if (i == 0)
                {
                    Game.Text("You have been invited for an interview at the biggest broadcasting channel on the island.", 4);
                    Game.Text("\nAt some point, the interviewer asks you about your opinion on plastic.", 3);
                    Game.Text("\nYou can either ", 1);
                    Game.Text("\nadmit ", 0, ConsoleColor.Yellow);
                    Game.Text("that plastic does not pose that much of a threat, or ", 2);
                    Game.Text("\nadvise ", 0, ConsoleColor.Yellow);
                    Game.Text("it's use with consideration.", 2);


                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Game.Text("\n\n   > ", 0);
                    string? answer = Console.ReadLine()?.ToLower();
                    Console.ResetColor();
                    Console.Clear();
                    if (string.IsNullOrEmpty(answer))
                    {
                        Game.Empty();
                        continue;
                    }
                    Command? command = parser.GetCommand(answer);
                    if (command == null)
                    {
                        Game.Invalid();
                        continue;
                    }


                    if (answer == "admit")
                    {
                        corporations.Influence++;
                        Game.Text("You admit that plastic doesn't cause as big issues on the environment as some people think. Industries can continue producing it in big numbers.", 5);
                        Game.Text("\n\nFun Fact: This is incorrect, because fish, seabirds, sea turtles, and marine mammals can become entangled in or ingest plastic debris, causing suffocation, starvation, and drowning.", 6, ConsoleColor.Blue);
                        Game.Text("\nFun fact: Some alternatives can be: bamboo straws, bags made of fabric or even fishing nets made from micro-algae, making them biodegradable.", 5, ConsoleColor.Blue);
                    }
                    else if (answer == "advise")
                    {
                        environmentalists.Influence++;
                        Game.Text("You advise that plastic can be very harmful if used thoughtlessly. The industry must limit the production of plastic and search for alternatives.", 5);
                        Game.Text("\n\nFun Fact: Your advise is correct, because fish, seabirds, sea turtles, and marine mammals can become entangled in or ingest plastic debris, causing suffocation, starvation, and drowning.", 6, ConsoleColor.Blue);
                        Game.Text("\nFun fact: Some alternatives can be: bamboo straws, bags made of fabric or even fishing nets made from micro-algae, making them biodegradable.", 5, ConsoleColor.Blue);
                    }
                }

                if (i == 1)
                {
                    Game.Text("You woke up today and it was warm and sunny, so you decided to go swimming at a nearby beach.", 3);
                    Game.Text("\nWhile you are relaxing and sunbathing, you watch a group of teenagers leaving the beach. It annoys you that they have left their plastic bottles and bags behind.", 5);
                    Game.Text("\nYou think about talking to them and", 1);
                    Game.Text("\nteach ", 0, ConsoleColor.Yellow);
                    Game.Text("them about responsibility by picking up their trash together. But you could just ", 2);
                    Game.Text("\ncontinue ", 0, ConsoleColor.Yellow);
                    Game.Text("enjoying the sun. You supose that someone will collect the trash at some point.", 2);
                    

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Game.Text("\n\n   > ", 0);
                    string? answer = Console.ReadLine()?.ToLower();
                    Console.ResetColor();
                    Console.Clear();
                    if (string.IsNullOrEmpty(answer))
                    {
                        Game.Empty();
                        continue;
                    }
                    Command? command = parser.GetCommand(answer);
                    if (command == null)
                    {
                        Game.Invalid();
                        continue;
                    }


                    if (answer == "teach")
                    {
                        environmentalists.Influence++;
                        Teenagers = true;
                        Game.Text("You catch up to the youngsters and politely try to make them see sense. You teach them what practises are good and bad and then you help them dispose of their trash. Motivated by your words, the teens go on and clean the whole beach.", 7);
                        Game.Text("\n\nFun Fact: Seas and oceans belong to all of us, they are part of the earth which is our home. It should be our responsibility to keep them clean and healthy.", 5, ConsoleColor.Blue);
                    }
                    else if (answer == "continue")
                    {
                        corporations.Influence++;
                        Game.Text("You ignore your consciousness, sunbathing was too pleasant to abandon. The beach stays littered and the teenagers will probably do it again.", 5);
                        Game.Text("\n\nFun Fact: Seas and oceans belong to all of us, they are part of the earth which is our home. It should be our responsibility to keep them clean and healthy.", 5, ConsoleColor.Blue);
                    }
                }

                if (i == 2)
                {
                    Game.Text("You are at the supermarket and go to the cashier counter to pay for the items.", 3);
                    Game.Text("\nThe person infront of you turns around, she recognises you from the TV. Her face gets a displeased expression when she spots the single-use bottles in your bag.", 5);
                    Game.Text("\nShe asks:'Why buy such bottles? They can be a waste of resources and also harmful for our seas'.", 4);
                    Game.Text("\nBefore you are able to answer, the man behind you seizes the initiative.", 3);
                    Game.Text("\nYou know him as a representative of the plastic bottle company. He tells the woman that you are free to chose and that environmentalists' fake news must not influence your decision.", 6);
                    Game.Text("\nYou stop to think for a bit.", 2);
                    Game.Text("\nWill you ", 1);
                    Game.Text("\nbuy ", 0, ConsoleColor.Yellow);
                    Game.Text("the bottles ", 2);
                    Game.Text("\nor search for an ", 0);
                    Game.Text("alternative?", 2, ConsoleColor.Yellow);
                    

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Game.Text("\n\n   > ", 0);
                    string? answer = Console.ReadLine()?.ToLower();
                    Console.ResetColor();
                    Console.Clear();
                    if (string.IsNullOrEmpty(answer))
                    {
                        Game.Empty();
                        continue;
                    }
                    Command? command = parser.GetCommand(answer);
                    if (command == null)
                    {
                        Game.Invalid();
                        continue;
                    }


                    if (answer == "buy")
                    {
                        corporations.Influence++;
                        Game.Text("You tell the woman that you are an adult and your desicions are your own. The man applauds you, he will spread the word of your actions. The woman remains disappointed.", 5);
                        Game.Text("\n\nFun Fact: Plastic bottles can accumulate in sensitive coastal ecosystems and coral reefs.", 3, ConsoleColor.Blue);
                        Game.Text("\nOver time, plastic bottles break down into smaller particles, releasing harmful chemicals into the water", 4, ConsoleColor.Blue);
                        Game.Text("\nBetter alternatives to plastic bottles are: glass bottles, stainless steel bottles, aluminum bottles. They can be used for long periods of time.\n", 4, ConsoleColor.Blue);
                    }
                    else if (answer == "alternative")
                    {
                        environmentalists.Influence++;
                        Game.Text("You tell the man that facts say otherwise. Plastic bottles can indeed pose a serious threat to our seas. The woman applauds you, she will spread the word of your actions. The man tried to suppress his anger.", 6);
                        Game.Text("\n\nFun Fact: Plastic bottles can accumulate in sensitive coastal ecosystems and coral reefs.", 3, ConsoleColor.Blue);
                        Game.Text("\nOver time, plastic bottles break down into smaller particles, releasing harmful chemicals into the water", 4, ConsoleColor.Blue);
                        Game.Text("\nBetter alternatives to plastic bottles are: glass bottles, stainless steel bottles, aluminum bottles. They can be used for long periods of time.\n", 4, ConsoleColor.Blue);
                    }
                }

                if (i == 3)
                {
                    Game.Text("The next day begins with loud voices out of your window. ", 2);
                    Game.Text("\nYou have totally forgotten about the demonstration calling to stop the production of single-use plastic in such numbers.", 4);
                    Game.Text("\nThe people need a strong and prestigious individual to help them with their cause.", 3);
                    Game.Text("\nYou could certainly ", 1);
                    Game.Text("\njoin ", 0, ConsoleColor.Yellow);
                    Game.Text("them. Their demands are noble. ", 2);
                    Game.Text("\nAnother course of action would be to ", 0);
                    Game.Text("\nridicule ", 0, ConsoleColor.Yellow);
                    Game.Text("them on social media. Their requests are unbased.", 2);
                    

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Game.Text("\n\n   > ", 0);
                    string? answer = Console.ReadLine()?.ToLower();
                    Console.ResetColor();
                    Console.Clear();
                    if (string.IsNullOrEmpty(answer))
                    {
                        Game.Empty();
                        continue;
                    }
                    Command? command = parser.GetCommand(answer);
                    if (command == null)
                    {
                        Game.Invalid();
                        continue;
                    }


                    if (answer == "join")
                    {
                        environmentalists.Influence++;
                        Game.Text("Seeing you join them, the already outraged crowd gets more fervorous.", 3);
                        Game.Text("\nMore and more people follow your example and join the protest.", 3);
                        Game.Text("\nOne thing is sure, such an effort will not be ingored by the people in power.", 3);
                        Game.Text("\n\nFun Fact: Politicians are more likely to act on an issue, if a well-prepared and a passionate crowd demands a solution.", 4, ConsoleColor.Blue);
                        Game.Text("\nYour voice can influence politics and can also help apply policies friendly for the environment. You can also influence other people by using smart and well-formulated arguments.", 5, ConsoleColor.Blue);  
                    }
                    else if (answer == "ridicule")
                    {
                        corporations.Influence++;
                        Game.Text("So much struggle for such a topic seems unfounded to you.", 3);
                        Game.Text("\nWatching your posts and your negative attitude, people reconsider about joining the demostration and those already there scatter in a matter of minutes.", 5);
                        Game.Text("\nPeople in power will not care about unserious demonstration attempts.", 3);
                        Game.Text("\n\nFun Fact: Politicians are more likely to act on an issue, if a well-prepared and a passionate crowd demands a solution.", 4, ConsoleColor.Blue);
                        Game.Text("\nYour voice can influence politics and can also help apply policies friendly for the environment. You can also influence other people by using smart and well-formulated arguments.", 5, ConsoleColor.Blue);
                    }
                }

                if (i == 4)
                {
                    Game.Text("The mysterious teacher you have met when you first visited Såndiægø, has proposed that you help raise awareness about water plastic pollution at the school he is teaching. ", 5);
                    Game.Text("\nYou would be naive to deny this opportunity and spread your ideas... ", 3);
                    Game.Text("\n...When you enter the classroom the next day ", 2);
                    if (Teenagers == true)
                    {
                        Game.Text("the teenagers you talked to at the beach recognise you and start cheering for you. ", 3);
                    }
                    if (Teenagers == false)
                    {
                        Game.Text("the teenagers laugh about your sunburns, but their teacher calms them down. ", 3);
                    }
                    Game.Text("\nDoing a classic ", 1);
                    Game.Text("\npresentation ", 0, ConsoleColor.Yellow);
                    Game.Text("you found on Industrial Association's website will be easy enough and also will waste less of your time. ", 3);
                    Game.Text("\nBut you could make it more interactive by helping them make a simple ", 2);
                    Game.Text("\nvideogame ", 0, ConsoleColor.Yellow);
                    Game.Text("about sea plastic pollution.", 3);
                    

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Game.Text("\n\n   > ", 0);
                    string? answer = Console.ReadLine()?.ToLower();
                    Console.ResetColor();
                    Console.Clear();
                    if (string.IsNullOrEmpty(answer))
                    {
                        Game.Empty();
                        continue;
                    }
                    Command? command = parser.GetCommand(answer);
                    if (command == null)
                    {
                        Game.Invalid();
                        continue;
                    }


                    if (answer == "presentation")
                    {
                        corporations.Influence++;
                        Game.Text("You came unprepared and you deliver a boring presentation. ", 2);
                        Game.Text("\nHalf of the class has almost fallen asleep and the other half learns about plastic pollution from the corporations' point of view. ", 4);
                        Game.Text("\nYou return home having second thoughts about your decisions today. ", 2);
                        Game.Text("\n\nFun Fact: While searching about plastic pollution on the internet, it is advised to believe only what trusted sources say. Some articles may try to manipulate the reader.", 5, ConsoleColor.Blue);
                    }
                    else if (answer == "videogame")
                    {
                        environmentalists.Influence++;
                        Game.Text("The students look very motivated with this new way of teaching. This can also encourage them to learn on their own. ", 4);
                        Game.Text("\nA couple of days later, a student group delivers a small game with choices, where the player learns even by making the wrong decisions. \nThey have implemented information such as: ", 5);
                        Game.Text("\n\nFun Fact: Ocean plastic pollution is on track to triple by 2060. ", 2, ConsoleColor.Blue);
                        Game.Text("\nFun Fact: The thing about plastic is that it never truly goes away, it just breaks down into smaller and smaller pieces called microplastics.", 4, ConsoleColor.Blue);
                        Game.Text("\nThis means that every plastic we have ever used still exists in some form or another somewhere around the world.", 4, ConsoleColor.Blue);  
                    }
                }
                Console.Clear();
                Game.Text(corporations.ToString(), 2, ConsoleColor.Red);
                Game.Text("\n" + environmentalists.ToString(), 3, ConsoleColor.Green);
                Console.Clear();
                i++;
            }


            //CONCLUSION
            Game.Text("...", 2);
            Game.Text("\nThe population has gathered in the square of the main island tonight. The president is going to announce which party gets to pass its policies.", 4);
            Game.Text("\nAs he steps on the balcony, an eerie silence fills the square. You can feel the tension by looking at the faces around you.", 4);
            Game.Text("\nThe president addresses the crowd and commands a person whom you cannot see to come forward.", 3);
            if (corporations.Influence < environmentalists.Influence)
            {
                Game.Text("\nLoud cheering can be heard all around when the representative of the Green Syndicate comes to stand at the side of the president.", 4, ConsoleColor.Green);
                Game.Text("\nWith your help, the president decides that the environmentalists got the support of the people and their policies are going to be implemented.", 4, ConsoleColor.Green);
                Game.Text("\nIn the next days everyone gets to work. Many volunteers help clean up the island of Såndiægø and it becomes a paradise on earth.", 4);
                Game.Text("\nYou feel proud of yourself, your actions helped the island polluted by plastic gain its former glory. When you see the sea animals swimming happily in the distance, you get a new wave of hope for this world.", 6);
                Visuals.NPC11();

                Game.MinigameVictory();
                MinigameWon = true;
            }
            else
            {
                Game.Text("\nLoud cheering can be heard all around when the representative of the Industrial Association comes to stand at the side of the president.", 4, ConsoleColor.Yellow);
                Game.Text("\nYou failed to help the people with the topic of plastic pollution, they are going to learn about it the hard way.", 4, ConsoleColor.Yellow);
                Game.Text("\nThe president decides that he will enforce the policies of the corporaitons. ", 0, ConsoleColor.Yellow);
                Game.Text("\nAfter some time, the situation on Såndiægø gets worse. Even the people who tried the most give up and the western island never recovers.", 4);
                Game.Text("\nAll the animals have either died or emigrated. You feel guilty about the sequence of events.", 3);
                Visuals.NPC111();

                Game.GameOver();
                Story_Minigame();
            }
        }

        public class Faction
        {
            public string Name { get; }

            public int Influence { get; set; }

            public Faction(string name, int influence)
            {
                //We have to make the choices to be an odd number to avoid ties
                Name = name;
                Influence = influence;
            }

            public override string ToString() => $"{Name} - Influence: {Influence}";
        }
    }
}