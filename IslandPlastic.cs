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

        public static void Locals() // I (Noah) think methods for texts are better, because that way we have more freedom using text color, delays etc.
        {
            /*if (MinigameWon)
            {
            Game.Text("\nThis island is closest to the Asian mainland, making it a collecting point for huge quantities of Chinese plastic waste…", 3);
            Game.Text("\nAfter reaching the shore of Såndiægø and walking around a bit, you spot a figure not far away. You approach a man that looks more sophisticated than the average citizen. ", 5);
            Game.Text("\nYou greet each other and he tells you that he was a teacher on this island, before it was made a plastic wasteland. Now he is teaching on Mainø. He comes here when he needs some time alone to think.", 6);
            Game.Text("\nYou ask him if there is anything to be done for the island to gain its former glory. He gives you some insight:", 1);
            Game.Text("\nIn the recent history of this insular republic, two parties have been fighting for the balance of power:", 3);
            Game.Text("\nThe corporations ", 1, ConsoleColor.Yellow);
            Game.Text("and the ", 1);
            Game.Text("environmentalists.", 1, ConsoleColor.Green);
            Game.Text("\nCorporations operate under the name 'Industrial Association'. Their goals are to make money, the health of the ecosystem is not in their agenda.", 3, ConsoleColor.Yellow);
            Game.Text("\nTheir view on the environmentalists is, that they are a group of fearmongerers that are overreacting on the small damage done and that the ecosystem will eventually fix itself.", 5);
            Game.Text("\nThe environmentalists, aka. 'Green Syndicate', strive to mitigate the damage done to the ecosystem and plan to reverse some of its negative consequences.", 4, ConsoleColor.Green);
            Game.Text("\nThose people hate the corporations with all their heart. They think they are blinded by their greediness and that their goals are futile, since no one takes their wealth to their grave.", 5);
            Game.Text("\nWe must act quickly and support the correct side of history before it's too late. You know what to do...", 1);
            Game.Text("\n\n   > ", 0, ConsoleColor.DarkCyan);
            }
            else
            {*/
            Game.Text("\nThis island is closest to the Asian mainland, making it a collecting point for huge quantities of Chinese plastic waste…", 3);
            Game.Text("\nAfter reaching the shore and walking around a bit, you spot a figure not far away. You approach a man that looks more sophisticated than the average citizen. ", 5);
            Game.Text("\nYou greet each other and he tells you that he was a teacher on this island, before it was made a plastic wasteland. He comes here when he needs some time alone to think.", 6);
            Game.Text("\nYou ask him if there is anything to be done for the island to gain its former glory. He gives you some insight:", 1);
            Game.Text("\nIn the recent history of this insular republic, two parties have been fighting for the balance of power:", 3);
            Game.Text("\nThe corporations ", 1, ConsoleColor.Yellow);
            Game.Text("and the ", 1);
            Game.Text("environmentalists.", 1, ConsoleColor.Green);
            Game.Text("\nCorporations operate under the name 'Industrial Association'. Their goals are to make money, the health of the ecosystem is not in their agenda.", 3, ConsoleColor.Yellow);
            Game.Text("\nTheir view on the environmentalists is, that they are a group of fearmongerers that are overreacting on the small damage done and that the ecosystem will eventually fix itself.", 5);
            Game.Text("\nThe environmentalists, aka. 'Green Syndicate', strive to mitigate the damage done to the ecosystem and plan to reverse some of its negative consequences.", 4, ConsoleColor.Green);
            Game.Text("\nThose people hate the corporations with all their heart. They think they are blinded by their greediness and that their goals are futile, since no one takes their wealth to their grave.", 5);
            Game.Text("\nWe must act quickly and support the correct side of history before it's too late. You know what to do...", 1);
            /*}*/

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
                    Game.Text("it's use with consideration.\n\n", 3);
                    Game.Text("   > ", 0, ConsoleColor.DarkCyan);
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
                        corporations.Influence++;
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
                        environmentalists.Influence++;
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
                    Game.Text("enjoying the sun. You supose that someone will collect the trash at some point.\n\n", 0);
                    Game.Text("   > ", 0, ConsoleColor.DarkCyan);

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
                        environmentalists.Influence++;
                        Teenagers = true;
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
                        corporations.Influence++;
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
                    Game.Text("\nor search for an ", 0);
                    Game.Text("alternative?\n\n", 0, ConsoleColor.Green);
                    Game.Text("   > ", 0, ConsoleColor.DarkCyan);

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
                        corporations.Influence++;
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
                        environmentalists.Influence++;
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
                    Game.Text("\nAnother course of action would be to ", 0);
                    Game.Text("ridicule ", 0, ConsoleColor.Yellow);
                    Game.Text("them on social media. Their requests are unbased.\n\n", 0);
                    Game.Text("   > ", 0, ConsoleColor.DarkCyan);

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
                        environmentalists.Influence++;
                        Game.Text("\nSeeing you join them, the already outraged crowd gets more fervorous.", 0);
                        Game.Text("\nMore and more people follow your example and join the protest.", 0);
                        Game.Text("\nOne thing is sure, such an effort will not be ingored by the people in power.", 0);
                        Game.Text("\nFun Fact: Politicians are more likely to act on an issue, if a well-prepared and a passionate crowd demands a solution.", 0);
                        Game.Text("\nYour voice can influence politics and can also help apply policies friendly for the environment. You can also influence other people when your arguments are smart.\n", 0);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(corporations.ToString());
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(environmentalists.ToString());
                        Console.ResetColor();

                    }
                    else if (answer == "ridicule")
                    {
                        corporations.Influence++;
                        Game.Text("\nSo much struggle for such a topic seems unfounded to you.", 0);
                        Game.Text("\nWatching your posts and your negative attitude, people reconsider about joining the demostration and those already there scatter in a matter of minutes.", 0);
                        Game.Text("\nPeople in power will not care about unserious demonstration attempts.", 0);
                        Game.Text("\nFun Fact: Politicians are more likely to act on an issue, if a well-prepared and a passionate crowd demands a solution.", 0);
                        Game.Text("\nYour voice can influence politics and can also help apply policies friendly for the environment. You can also influence other people when your arguments are smart.\n", 0);
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

                    Game.Text("\nThe mysterious teacher you have met when you first visited Såndiægø has proposed that you help raise awareness about water platic pollution at the school he is teaching. ", 0);
                    Game.Text("\nYou would be naive to deny this opportunity and spread your ideas... ", 0);
                    Game.Text("\n...When you enter the classroom the next day ", 0);
                    if (Teenagers == true)
                    {
                        Game.Text("the teenagers you talked to at the beach recognise you and start cheering for you. ", 0);
                    }
                    if (Teenagers == false)
                    {
                        Game.Text("the teenagers laugh about your sunburns, but their teacher calms them down. ", 0);
                    }
                    Game.Text("\nDoing a classic ", 0);
                    Game.Text("presentation ", 0, ConsoleColor.Yellow);
                    Game.Text("you found on Industrial Association's website will be easy enough and also will waste less of your time. ", 0);
                    Game.Text("\nBut you could make it more interactive by helping them make a simple ", 0);
                    Game.Text("videogame ", 0, ConsoleColor.Green);
                    Game.Text("about sea plastic pollution.\n\n ", 0);
                    Game.Text("   > ", 0, ConsoleColor.DarkCyan);

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

                    if (answer == "presentation")
                    {
                        corporations.Influence++;
                        Game.Text("\nYou came unprepared and you deliver a boring presentation. ", 0);
                        Game.Text("\nHalf of the class has almost fallen asleep and the other half learns about plastic pollution from the corporations' point of view. ", 0);
                        Game.Text("\nYou return home having second thoughts about your decisions today. ", 0);
                        Game.Text("\nFun Fact: while searching about plastic pollution on the internet, it is advised to believe only what trusted sources say. Some articles may try to manipulate the reader. \n", 0);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(corporations.ToString());
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(environmentalists.ToString());
                        Console.ResetColor();

                    }
                    else if (answer == "videogame")
                    {
                        environmentalists.Influence++;
                        Game.Text("\nThe students look very motivated with this new way of teaching. This can also encourage them to learn on their own. ", 0);
                        Game.Text("\nA couple of days later, a student group delivers a small game with choices, where the player learns even by making the wrong decisions. They have implemented information such as: ", 0);
                        Game.Text("\nFun Fact:ocean plastic pollution is on track to triple by 2060. ", 0);
                        Game.Text("\nor ", 0);
                        Game.Text("\nFun Fact: the thing about plastic is that it never truly goes away, it just breaks down into smaller and smaller pieces called microplastics.", 0);
                        Game.Text("\nThis means that every plastic we have ever used still exists in some form or another somewhere around the world.\n", 0);

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
                Game.Text("\n\n\n...", 2);
                Game.Text("\nThe population has gathered in the square of the main island tonight. The president is going to announce which party gets to pass its policies.", 2);
                Game.Text("\nAs he steps on the balcony, an eerie silence fills the square. You can feel the tension by looking at the faces around you.", 2);
                Game.Text("\nThe president addresses the crowd and commands a person whom you cannot see to come forward.", 2);
                Game.Text("\nLoud cheering can be heard all around when the representative of the Green Syndicate comes to stand at the side of the president.", 2, ConsoleColor.Green);
                Game.Text("\nWith your help, the president decides that the environmentalists got the support of the people and their policies are going to be implemented.", 0, ConsoleColor.Green);
                Game.Text("\nIn the next days everyone gets to work. Many volunteers help clean up the island of Såndiægø and it becomes a paradise on earth.", 2);
                Game.Text("\nYou feel proud of yourself, your actions helped the island polluted by plastic gain its former glory.", 2);

                Game.MinigameVictory();
                MinigameWon = true;
            }
            else
            {
                Game.Text("\n\n\n...", 2);
                Game.Text("\nThe population has gathered in the square of the main island tonight. The president is going to announce which party gets to pass its policies.", 2);
                Game.Text("\nAs he steps on the balcony, an eerie silence fills the square. You can feel the tension by looking at the faces around you.", 2);
                Game.Text("\nThe president addresses the crowd and commands a person whom you cannot see to come forward.", 2);
                Game.Text("\nLoud cheering can be heard all around when the representative of the Industrial Association comes to stand at the side of the president.", 2, ConsoleColor.Yellow);
                Game.Text("\nYou failed to help the people with the topic of plastic pollution, they are going to learn about it the hard way.", 0, ConsoleColor.Yellow);
                Game.Text("\nThe president decides that he will enforce the policies of the corporaitons. ", 0, ConsoleColor.Yellow);
                Game.Text("\nAfter some time, the situation on Såndiægø gets worse. Even the people who tried the most give up and the western island never recovers.", 2);
                Game.Text("\nYou feel guilty about the sequence of events.\n", 2);
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