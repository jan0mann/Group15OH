namespace OperationHav
{
    public class Island
    {
        public string ShortDescription { get; set; }
        public string LongDescription { get; set;}
        public string Locals{ get; set;} // adding "locals" option for every island so if you go to an island you can talk with the locals
        public Dictionary<string, Island> Exits { get; set; } = new();

        public Island(string shortDesc, string longDesc, string locals)
        {
            ShortDescription = shortDesc;
            LongDescription = longDesc;
            Locals = locals;
        }

        public void SetExits(Island? north, Island? east, Island? south, Island? west)
        {
            SetExit("north", north);
            SetExit("east", east);
            SetExit("south", south);
            SetExit("west", west);
        }

        public void SetExit(string direction, Island? neighbor)
        {
            if (neighbor != null)
                Exits[direction] = neighbor;
        }
    }



    // Here ends the headclass for all the islands. 
    // Below you'll find the subclasses for each island.



    //Bartek and Noah, please use this class for your island/minigame
    public class IslandIndustrial : Island 
    {   
        public IslandIndustrial(string shortDesc, string longDesc, string locals) : base (shortDesc, longDesc, locals )
        {
            ShortDescription = shortDesc;
            LongDescription = longDesc;
            Locals = locals;
        }

        //You might wanne use this method here for the game itself
        public void IndustrialWaste()
        {
       
         

         }
        
    }



        //Marcel and Jan, please use this class for your island/minigame
       public class IslandOil : Island 
    {   
        public IslandOil(string shortDesc, string longDesc, string locals) : base(shortDesc, longDesc, locals)
        {
            ShortDescription = shortDesc;
            LongDescription = longDesc;
            Locals = locals;
        }

        //You might wanne use this method here for the game itself
        public void OilSpill()
        {

        }
    }



        //serafeim and Darius, please use this class for your island/minigame
       public class IslandPlastic : Island 
    {   
        public IslandPlastic(string shortDesc, string longDesc, string locals) : base(shortDesc, longDesc, locals)
        {
            ShortDescription = shortDesc;
            LongDescription = longDesc;
            Locals = locals;
        }

        //You might wanne use this method here for the game itself
        public void PlasticWaste()
        {

        }
    }



     //On this island/minigame, we all work together (Darius can create the maze for this game now, of course)
       public class IslandCoral : Island 
    {   
        public IslandCoral(string shortDesc, string longDesc, string locals) : base(shortDesc, longDesc, locals)
        {
            ShortDescription = shortDesc;
            LongDescription = longDesc;
            Locals = locals;
        }

        //We might wanne use this method here for the game itself
        public void CoralReef()
        {

        }
    }
}
