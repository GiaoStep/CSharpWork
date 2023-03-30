// See https://aka.ms/new-console-template for more information
using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Random rnd = new Random();
        int[] numbers = Enumerable.Range(1, 100)
            .Select(i => rnd.Next(0, 1000))
            .ToArray();

        Console.WriteLine("排序前的整数：");
        Console.WriteLine(string.Join(",", numbers));

        var sortedNumbers = numbers.OrderByDescending(n => n);
        int sum = sortedNumbers.Sum();
        double average = sortedNumbers.Average();

        Console.WriteLine("排序后的整数：");
        Console.WriteLine(string.Join(",", sortedNumbers));

        Console.WriteLine("总和：{0}", sum);
        Console.WriteLine("平均数：{0:F2}", average);

        Console.ReadLine();
    }
}

