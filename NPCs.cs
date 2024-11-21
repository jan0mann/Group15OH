namespace OperationHav
{
    //we may need to change the name of the file into, for instance, balance of power or opposing parties in case Darius wants to make NPCs.
    public class NPCs
    {
        public string Name { get; }

        private int Influence { get; set; }

        private int Support { get; set; }

        public NPCs(string name, int influence, int support)
        {
            //each party will attack the influence of the other with the support it has gotten
            //When influence reaches 0, the other party wins
            //We have to make the choices to be an odd number to avoid ties
            Name = name;
            Influence = influence;
            Support = support;
        }

        //just a new way of making a method instead of curly parentheses
        public int SupportGot() => Support;

        public void DecreaseReputation(int reputation)
        {
            Influence = Math.Max(0, Influence - reputation);
        }

        public bool HasInfluence => Influence > 0;

        public override string ToString() => $"{Name} - Influence:{Influence}";



    }
}

