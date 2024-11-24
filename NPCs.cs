namespace OperationHav
{
    //we may need to change the name of the file into, for instance, balance of power or opposing parties in case Darius wants to make NPCs.
    public class NPCs
    {
        public string Name { get; }

        public int Influence { get; set; }


        public NPCs(string name, int influence)
        {
            //We have to make the choices to be an odd number to avoid ties
            Name = name;
            Influence = influence;
        }


        public override string ToString() => $"{Name} - Influence:{Influence}";



    }
}

