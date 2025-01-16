using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished");

        int number = -1;
        List<int> numbers = new List<int>();

        while (number != 0)
        {
            Console.Write("Enter number: ");

            string userNumber = Console.ReadLine();
            number = int.Parse(userNumber);

            if (number != 0)
            {
                numbers.Add(number);
            }
        }

        int sum = 0;
        foreach (int numberList in numbers)
        {
            sum += numberList;
        }

        Console.WriteLine($"The sum is: {sum}");

        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        int max = numbers[0];
        int min = int.MaxValue;

        foreach (int largest in numbers)
        {
            if (largest > max)
            {
                max = largest;
            }
        }
        Console.WriteLine($"The largest number is: {max}");

        foreach (int smallest in numbers)
        {
            if (smallest > 0 && smallest < min)
            {
                min = smallest;
            }
        }
        Console.WriteLine($"The smallest positive number is: {min}");

        Console.WriteLine("The sorted list is:");
        numbers.Sort();
        foreach (int sortedNumber in numbers)
        {
            Console.WriteLine(sortedNumber);
        }
    }
}