using System;

class Program
{
    static void Main()
    {
        WritingHub hub = new WritingHub();

        while (true)
        {
            Console.WriteLine("\n--- Writing & Creativity Hub ---");
            Console.WriteLine("1. Writing Prompts");
            Console.WriteLine("2. Story Tracker");
            Console.WriteLine("3. Character Database");
            Console.WriteLine("4. Worldbuilding Database");
            Console.WriteLine("5. Daily Challenges");
            Console.WriteLine("6. Idea Generator");
            Console.WriteLine("7. Progress Tracker");
            Console.WriteLine("8. View Saved Data");
            Console.WriteLine("9. Save & Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();
            if (choice == "9")
            {
                hub.SaveData();
                Console.WriteLine("Data saved. Exiting program...");
                break;
            }
            else if (choice == "8")
            {
                hub.ViewSavedData();
            }
            else
            {
                int index;
                if (int.TryParse(choice, out index) && index >= 1 && index <= 7)
                {
                    hub.UseTool(index - 1);
                }
                else
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }
            }
        }
    }
}
