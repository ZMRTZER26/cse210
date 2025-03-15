using System;
using System.Collections.Generic;
using System.IO;

// The Manager class handles goal tracking, daily challenges, score management, saving, and loading.
class Manager
{
    private int _score; // Tracks the user's total score.
    private List<Goal> _goals; // Stores all goals created by the user.
    private int _dailyChallengeIndex = -1; // Keeps track of the index of the daily challenge goal.

    // Constructor initializes the score and goal list.
    public Manager()
    {
        _score = 0;
        _goals = new List<Goal>();
    }

    // Adds a new goal to the list.
    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    // Displays all goals and their progress.
    public void DisplayGoals()
    {
        Console.WriteLine("\nGoals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.Write($"{i + 1} "); // Numbers each goal for selection.
            _goals[i].DisplayProgress(); // Calls each goal's DisplayProgress method.
        }
    }

    // Records an event for the specified goal and updates the score accordingly.
    public void RecordEvent(int index)
    {
        if (index >= 0 && index < _goals.Count) // Ensures the index is valid.
        {
            _goals[index].RecordEvent(); // Calls the specific goal's event recording method.

            // Updates the score based on the goal type:
            _score += _goals[index] is ChecklistGoal checklistGoal && checklistGoal.GetType() == typeof(ChecklistGoal)
                ? checklistGoal.SaveData().Split(',').Length > 5 && int.Parse(checklistGoal.SaveData().Split(',')[5]) == int.Parse(checklistGoal.SaveData().Split(',')[4])
                    ? int.Parse(checklistGoal.SaveData().Split(',')[3]) + int.Parse(checklistGoal.SaveData().Split(',')[4]) // Adds both regular points and bonus.
                    : int.Parse(checklistGoal.SaveData().Split(',')[3]) // Adds only regular points.
                : int.Parse(_goals[index].SaveData().Split(',')[3]); // Default case for other goal types.

            // If the goal completed is the daily challenge, reset the challenge index.
            if (index == _dailyChallengeIndex)
            {
                _dailyChallengeIndex = -1;
            }
        }
        else
        {
            Console.WriteLine("Invalid goal index."); // Handles invalid index errors.
        }
    }

    // Sets a new daily challenge by replacing the previous one.
    public void SetDailyChallenge()
    {
        string challengeText = DailyChallenge.GetRandomChallenge(); // Retrieves a random challenge.

        // If a daily challenge already exists, remove it before adding a new one.
        if (_dailyChallengeIndex != -1 && _dailyChallengeIndex < _goals.Count)
        {
            _goals.RemoveAt(_dailyChallengeIndex);
        }

        // Creates a new daily challenge goal and adds it to the list.
        SimpleGoal dailyChallenge = new SimpleGoal(10, "Daily Challenge", challengeText, false);
        _goals.Add(dailyChallenge);
        _dailyChallengeIndex = _goals.Count - 1; // Updates the index to the new daily challenge.

        Console.WriteLine($"New Daily Challenge added: {challengeText}");
    }

    // Displays the user's total score.
    public void DisplayScore()
    {
        Console.WriteLine($"Total Score: {_score} points");
    }

    // Saves all goals and the score to a specified file.
    public void Save(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename)) // Opens the file for writing.
        {
            writer.WriteLine(_score); // Saves the total score as the first entry.

            // Writes each goal's data to the file.
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.SaveData());
            }
        }
        Console.WriteLine("Data saved successfully.");
    }

    // Loads goals and the score from a specified file.
    public void Load(string filename)
    {
        if (File.Exists(filename)) // Ensures the file exists before attempting to read it.
        {
            _goals.Clear(); // Clears existing goals before loading new ones.
            string[] lines = File.ReadAllLines(filename); // Reads all lines from the file.

            if (lines.Length == 0) // Handles the case where the save file is empty.
            {
                Console.WriteLine("Save file is empty.");
                return;
            }

            if (!int.TryParse(lines[0], out _score))
            {
                Console.WriteLine("Error: Invalid score format in save file.");
                return;
            }

            // Loops through the remaining lines to reconstruct goals from saved data.
            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(','); // Splits the line into components.

                // Ensures the line has at least 4 parts to be considered a valid goal.
                if (parts.Length < 4)
                {
                    Console.WriteLine($"Skipping invalid entry: {lines[i]}"); // Skips malformed lines.
                    continue;
                }

                string type = parts[0]; // Determines the goal type.
                string name = parts[1]; // Extracts the goal name.
                string description = parts[2]; // Extracts the goal description.

                // Attempts to parse the points value; defaults to 10 if parsing fails.
                int points = int.TryParse(parts[3], out int p) ? p : 10;

                // Determines the goal type and reconstructs the corresponding object.
                if (type == "SimpleGoal")
                {
                    // Parses the completion status, defaulting to false if parsing fails.
                    bool isCompleted = parts.Length > 4 && bool.TryParse(parts[4], out bool result) && result;
                    _goals.Add(new SimpleGoal(points, name, description, isCompleted));
                }
                else if (type == "EternalGoal")
                {
                    _goals.Add(new EternalGoal(points, name, description)); // Eternal goals don't need extra values.
                }
                else if (type == "ChecklistGoal")
                {
                    // Parses bonus, target, and current progress values with safe defaults.
                    int bonus = int.TryParse(parts[4], out int b) ? b : 0;
                    int target = int.TryParse(parts[5], out int t) ? t : 0;
                    int current = int.TryParse(parts[6], out int c) ? c : 0;

                    _goals.Add(new ChecklistGoal(points, name, description, bonus, target, current));
                }
            }

            Console.WriteLine("Goals successfully loaded!");
        }
        else
        {
            Console.WriteLine("Save file not found."); // Displays an error if the file does not exist.
        }
    }
}
