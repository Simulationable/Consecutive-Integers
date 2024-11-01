using System.Diagnostics;

public class Program
{
    public static void Main()
    {
        Console.Write("Enter the number of consecutive integers: ");
        if (!int.TryParse(Console.ReadLine(), out int consecutiveCount) || consecutiveCount < 2)
        {
            Console.WriteLine("Please enter a valid number greater than or equal to 2.");
            return;
        }

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        List<int> result = FindConsecutiveIntegers(consecutiveCount);

        if (result.Count > 0)
        {
            Console.WriteLine("The first set of consecutive integers with the required distinct prime factors:");
            result.ForEach(Console.WriteLine);
        }
        else
        {
            Console.WriteLine("No such integers found.");
        }

        stopwatch.Stop();
        Console.WriteLine($"\nExecution Time: {stopwatch.ElapsedMilliseconds} ms");
    }

    public static List<int> FindConsecutiveIntegers(int consecutiveCount)
    {
        List<int> result = new List<int>();
        int currentNumber = 2;
        int foundCount = 0;

        while (true)
        {
            if (CountDistinctPrimeFactors(currentNumber) == consecutiveCount)
            {
                foundCount++;
                if (foundCount == consecutiveCount)
                {
                    for (int i = 0; i < consecutiveCount; i++)
                    {
                        result.Add(currentNumber - consecutiveCount + 1 + i);
                    }
                    break;
                }
            }
            else
            {
                foundCount = 0;
            }
            currentNumber++;
        }

        return result;
    }

    public static int CountDistinctPrimeFactors(int number)
    {
        HashSet<int> primeFactors = new HashSet<int>();
        int factor = 2;
        while (number > 1)
        {
            if (number % factor == 0)
            {
                primeFactors.Add(factor);
                number /= factor;
            }
            else
            {
                factor++;
            }
        }
        return primeFactors.Count;
    }
}