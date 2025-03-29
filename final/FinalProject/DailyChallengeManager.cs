using System;

class DailyChallengeManager : WritingTool
{
    private string _latestChallenge;

    public override void DisplayMenu()
    {
        Console.WriteLine("\n--- Daily Challenge Manager ---");
        string[] challenges = { "Write 500 words today.", "Describe a sunset in detail.", "Write a scene with only dialogue." };
        Random rand = new Random();
        _latestChallenge = challenges[rand.Next(challenges.Length)];
        Console.WriteLine("Challenge: " + _latestChallenge);
    }

    public override string ExportData() => _latestChallenge;
    public override void ImportData(string data) => _latestChallenge = data;
}
