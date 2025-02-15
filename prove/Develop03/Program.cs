using System;

class Program
{
    static void Main()
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Scripture Memorization Program!\n");

        Scripture scripture = new Scripture();
        ScriptureEntry selectedScripture;

        //Allow for user to input their own scripture for memorization
        //Otherwise a random scripture from the list in Scripture.cs will be selected
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

            //Defaultly hides 2 words at a time
            //Change the number inside the parenthesis to adjust this as needed
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
