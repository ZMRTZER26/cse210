using System;

class Program
{
    static void Main()
    {
        // Create a Manager object to handle all goals and scoring
        Manager manager = new Manager();
        
        while (true) // Infinite loop to keep the program running until the user exits
        {
            // Display menu options
            Console.WriteLine("\n1. Create a goal");
            Console.WriteLine("2. Daily Challenge");
            Console.WriteLine("3. Record an event");
            Console.WriteLine("4. Display goals");
            Console.WriteLine("5. Show score");
            Console.WriteLine("6. Save goals");
            Console.WriteLine("7. Load goals");
            Console.WriteLine("8. Exit");
            Console.Write("Choose an option: ");
            
            string choice = Console.ReadLine(); // Read user input
            
            switch (choice) // Perform actions based on user input
            {
                case "1": // Create a new goal
                    Console.Write("Enter goal type (simple, eternal, checklist): ");
                    string type = Console.ReadLine().ToLower(); // Get goal type from user
                    Console.Write("Enter name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter description: ");
                    string description = Console.ReadLine();
                    Console.Write("Enter points: ");
                    int points = int.Parse(Console.ReadLine());
                    
                    // Create appropriate goal based on user input
                    if (type == "simple")
                        manager.AddGoal(new SimpleGoal(points, name, description));
                    else if (type == "eternal")
                        manager.AddGoal(new EternalGoal(points, name, description));
                    else if (type == "checklist")
                    {
                        Console.Write("Enter target count: ");
                        int target = int.Parse(Console.ReadLine());
                        Console.Write("Enter bonus points: ");
                        int bonus = int.Parse(Console.ReadLine());
                        manager.AddGoal(new ChecklistGoal(points, name, description, bonus, target));
                    }
                    break;
                case "2":
                    manager.SetDailyChallenge(); // Assign a daily challenge
                    break;
                case "3":
                    manager.DisplayGoals(); // Show all goals
                    Console.Write("Enter goal index to record: ");
                    manager.RecordEvent(int.Parse(Console.ReadLine()) - 1); // Record progress for a goal
                    break;
                case "4":
                    manager.DisplayGoals(); // Show all goals
                    break;
                case "5":
                    manager.DisplayScore(); // Show total score
                    break;
                case "6":
                    manager.Save("goals.txt"); // Save goals to a file
                    break;
                case "7":
                    manager.Load("goals.txt"); // Load goals from a file
                    break;
                case "8":
                    return; // Exit the program
            }
        }
    }
}
