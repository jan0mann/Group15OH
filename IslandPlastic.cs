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
            Game.Text("\nThis island is closest to the Asian mainland, making it a collecting point for huge quantities of Chinese plastic waste…", 3);
        }

        //You might wanne use this method here for the minigame itself
        public static void Story_Minigame()
        {
            MinigameWon = true;
        }
    }
}