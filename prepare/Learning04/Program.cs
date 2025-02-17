using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment a1 = new Assignment("John Deer", "Farming");
        Console.WriteLine(a1.GetSummary());

        MathAssignment a2 = new MathAssignment("Jane Doe", "Math", "1.5", "3-5");
        Console.WriteLine(a2.GetSummary());
        Console.WriteLine(a2.GetHomeworkList());

        WritingAssignment a3 = new WritingAssignment("Random Name", "Essay", "I ran out of ideas");
        Console.WriteLine(a3.GetSummary());
        Console.WriteLine(a3.GetWritingInformation());
    }
}