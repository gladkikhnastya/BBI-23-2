using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите список фамилий, разделенных запятыми:");
        string input = Console.ReadLine();

        string[] surnames = input.Split(',');

        for (int i = 0; i < surnames.Length; i++)
        {
            surnames[i] = surnames[i].Trim();
        }

        Array.Sort(surnames);

        Console.WriteLine("\nОтсортированный список фамилий:");
        foreach (string surname in surnames)
        {
            Console.WriteLine(surname);
        }
    }
}