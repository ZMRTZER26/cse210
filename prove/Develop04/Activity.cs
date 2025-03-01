using System;

class Activity
{
    // Set the default name, description, and duration of the activities
    protected string _name;
    protected string _description;
    protected int _duration;

    public virtual void StartMessage()
    {
        Console.WriteLine($"Starting {_name}.");
        Console.WriteLine(_description);
        Console.Write("Enter the duration in seconds: ");

        // Allow for user defined duration
        if (!int.TryParse(Console.ReadLine(), out _duration) || _duration <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a positive number.");
            _duration = 10; // Default fallback time
        }
    }

    public virtual void RunActivity()
    {
        Console.WriteLine("Running activity...");
    }

    public virtual void EndMessage()
    {
        Console.WriteLine("Great job! You have completed the activity.");
    }

    public void PauseWithAnimation()
    {
        Console.WriteLine("Pausing...");
        System.Threading.Thread.Sleep(2000);
    }
}
