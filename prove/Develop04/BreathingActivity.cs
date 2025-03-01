using System;
using System.Threading;

class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        // Set the name and description of the activity
        _name = "Breathing Activity";
        _description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public override void RunActivity()
    {
        StartMessage(); // Ask the user for duration

        int elapsedTime = 0;
        int cycleDuration = 8; // Each cycle consists of 4 seconds inhale + 4 seconds exhale

        while (elapsedTime < _duration)
        {
            // Perform the breathing in and out sequences
            Breathe("Breathe in...", 4, true);
            Breathe("BREATHE OUT...", 4, false);
            elapsedTime += cycleDuration;
        }

        EndMessage();
    }

    private void Breathe(string message, int seconds, bool isInhale)
    {
        for (int i = seconds; i > 0; i--)
        {
            // Determine the display format based on inhale/exhale and timing
            string displayMessage = isInhale
                ? (i == seconds ? message.ToLower()  // Start lowercase
                : i == 3 ? message                 // Normal capitalization
                : i == 2 ? message.ToUpper()       // Uppercase
                : i == 1 ? message                 // Back to normal capitalization
                : message)
                
                : (i == seconds ? message.ToUpper() // Start uppercase
                : i == 3 ? message.Substring(0, 1).ToUpper() + message.Substring(1).ToLower() // Capitalized
                : i == 2 ? message.ToLower()       // Lowercase
                : i == 1 ? message.Substring(0, 1).ToUpper() + message.Substring(1).ToLower() // End capitalized
                : message);
            
            Console.Write($"\r{displayMessage} {i} "); // Print the message and countdown timer
            Thread.Sleep(1000); // Pause for 1 second
        }
        Console.WriteLine(); // Move to the next line after countdown completes
    }
}