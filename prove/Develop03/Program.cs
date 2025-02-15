using System;

class Program
{
    static void Main()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Scripture Memorization Program!\n");

        Scripture scripture = new Scripture();
        ScriptureEntry selectedScripture;

        Console.WriteLine("Would you like to enter your own scripture? (yes/no)");
        string choice = Console.ReadLine().Trim().ToLower();

        if (choice == "yes")
        {
            selectedScripture = scripture.GetUserScripture();
        }
        else
        {
            selectedScripture = scripture.GetRandomScripture();
        }

        Console.Clear();
        selectedScripture.Display();

        while (true)
        {
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit.");
            string input = Console.ReadLine().Trim().ToLower();

            if (input == "quit")
            {
                Console.WriteLine("\nProgram Ended. Thanks for playing!");
                break;
            }

            selectedScripture.HideWords(2);
            Console.Clear();
            selectedScripture.Display();

            if (selectedScripture.IsFullyHidden())
            {
                Console.WriteLine("\nAll words are hidden. Program complete!");
                break;
            }
        }
    }
}
