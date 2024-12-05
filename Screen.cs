namespace OperationHav
{

    public class Screen 
    {
         public static void CenterWrite(string text)
    {
        // Get console window width
        int windowWidth = Console.WindowWidth;
        
        // Calculate left padding to center the text
        int leftPadding = (windowWidth - text.Length) / 2;
        
        // Set cursor position to create left padding
        Console.SetCursorPosition(leftPadding, Console.CursorTop);
        
        // Write the text
        Console.WriteLine(text);
    }

    // Method 2: Using string padding for centering
    public static void CenterWritePadded(string text)
    {
        int windowWidth = Console.WindowWidth;
        Console.WriteLine(text.PadLeft((windowWidth + text.Length) / 2));
    }

    // Method 3: More flexible centering method
    public static void CenterWriteAdvanced(string text, bool addNewLine = true)
    {
        int windowWidth = Console.WindowWidth;
        
        // Calculate left padding to center the text
        int leftPadding = (windowWidth - text.Length) / 2;
        
        // Create a string with left padding
        string centeredText = new string(' ', leftPadding) + text;
        
        if (addNewLine)
            Console.WriteLine(centeredText);
        else
            Console.Write(centeredText);
    }
        public static void StartScreen()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();
            Game.Text("\n\n\n\n\n\n\n\n Please enter the game in full screen of your choosen device! \n Press Tab to continue \n\n\n\n\n\n",0);
            while (true)
            {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Tab)
                    {
                    break; // Exit the loop when Tab is pressed
                    }
            }
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Game.Text(".............\n\n\n\n\n\n\n\n\n\n",3);
            Console.WriteLine("""
                                                                    _                _                 
                                                               _   (_)              | |                
                                   ___  ____   ____  ____ ____| |_  _  ___  ____    | | _   ____ _   _ 
                                  / _ \|  _ \ / _  )/ ___/ _  |  _)| |/ _ \|  _ \   | || \ / _  | | | |
                                 | |_| | | | ( (/ /| |  ( ( | | |__| | |_| | | | |  | | | ( ( | |\ V / 
                                  \___/| ||_/ \____|_|   \_||_|\___|_|\___/|_| |_|  |_| |_|\_||_| \_/  
                                       |_|                                                             
            """);
            Game.Text("\n\n\n\nPress 'Enter' key to start Operation Hav!",1);
            Game.Text(".............\n\n\n\n\n\n\n\n\n\n",0);
            while (true)
            {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.Enter)
                    {
                    break; // Exit the loop when Tab is pressed
                    }
            }
        }
    }
}