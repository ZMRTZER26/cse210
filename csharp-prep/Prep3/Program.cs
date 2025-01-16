using System;

class Program
{
    static void Main(string[] args)
    {
        //Console.Write("What is the magic number? ");
        //int number = int.Parse(Console.ReadLine());

        Random randomGenerator = new Random();
        int randomNumber = randomGenerator.Next(1,101);

        int guess = 0;

        while (guess != randomNumber)
        {
            Console.Write("What is the number? ");
            guess = int.Parse(Console.ReadLine());

            if (randomNumber > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (randomNumber < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("Correct!");
            }
        }
    }
}