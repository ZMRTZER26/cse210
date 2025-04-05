// Polymorphism is found in the Execute() method in WritingTool where each class overrides it to perform their functions
// Inheritance is found in the WritingTool class being inherited by nearly every other class
// Encapsulation is found in all classes hiding details with private attributes and using public methods for controlled interaction
// Abstraction is found in separating functions across multiple classes. WritingHub handles data management and interaction
// While the classes inheriting from WritingTool focus on their specific tasks
class Program
{
    static void Main()
    {
        // Initialize the main hub that manages writing tools and data
        WritingHub hub = new WritingHub();
        bool running = true;

        while (running)
        {
            // Display the main menu
            Console.WriteLine("\n===== Writing & Creativity Hub =====");
            Console.WriteLine("1. Generate Prompt");
            Console.WriteLine("2. Daily Challenge");
            Console.WriteLine("3. Story Title");
            Console.WriteLine("4. Create a Character");
            Console.WriteLine("5. Expand your World");
            Console.WriteLine("6. Save Data");
            Console.WriteLine("7. Show your Work");
            Console.WriteLine("8. Track your Progress");
            Console.WriteLine("9. Load Data");
            Console.WriteLine("10. Exit");
            Console.Write("Select an option: ");

            // Get user input
            string input = Console.ReadLine();
            Console.WriteLine();

            // Validate user input
            switch (input)
            {
                case "1":
                    hub.UseTool(0); // PromptGenerator - Generates a writing prompt
                    break;
                case "2":
                    hub.UseTool(1); // DailyChallengeManager - Provides a daily writing challenge
                    break;
                case "3":
                    hub.UseTool(2); // StoryTracker- Manages writing projects
                    break;
                case "4":
                    hub.UseTool(3); // CharacterDatabase - Stores character profiles
                    break;
                case "5":
                    hub.UseTool(4); // WorldbuildingDatabase - Stores worldbuilding elements
                    break;
                case "6":
                    hub.SaveData(); // Saves data to a txt file
                    break;
                case "7":
                    hub.DisplayStoryData(); // Displays the stored and sorted story-related data
                    break;
                case "8":
                    hub.UseTool(5); // ProgressTracker - Tracks writing progress (word count)
                    break;
                case "9":
                    hub.LoadData(); // Load saved data form file
                    break;
                case "10":
                    Console.WriteLine("Exiting program. Goodbye!");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
