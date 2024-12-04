namespace OperationHav
{
    public class Program
    {
        /*
       public static void SetConsoleBufferSize()
        {
            try
            {
                // Set the buffer size
                Console.SetBufferSize(200, 50);

                // Optional: Adjust the window size to match the buffer
                if (Console.LargestWindowWidth >= 200 && Console.LargestWindowHeight >= 50)
                {
                    Console.SetWindowSize(200, 50);
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Error: Unable to set console buffer size. " +
                                  "Ensure your terminal supports the specified dimensions.");
                Console.WriteLine($"Details: {ex.Message}");
                Environment.Exit(1); // Exit the program if configuration fails
            }
        }*/
        
        public static void Main()
        {   
        {
            
            
            Game game = new();
            game.Play();
        }
        }
    }
}

