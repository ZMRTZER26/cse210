using System;
using System.Collections.Generic;

// Manages daily challenges by selecting a random one each time
class DailyChallenge
{
    // List of possible daily challenges
    private static List<string> _challenges = new List<string>
    {
        "Drink 8 glasses of water",
        "Take a 10-minute walk",
        "Read for 15 minutes",
        "Write down three things you're grateful for",
        "Meditate for 5 minutes",
        "Do 20 push-ups",
        "Avoid social media for an hour",
        "Compliment someone today"
    };

    // Randomly selects a challenge from the list
    public static string GetRandomChallenge()
    {
        Random random = new Random();
        int index = random.Next(_challenges.Count);
        return _challenges[index];
    }
}
