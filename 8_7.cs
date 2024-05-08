using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите текст:");
        string text = Console.ReadLine();

        Console.WriteLine("Введите последовательность букв:");
        string sequence = Console.ReadLine();

        List<string> wordsContainingSequence = FindWordsContainingSequence(text, sequence);

        Console.WriteLine($"\nСлова, содержащие последовательность '{sequence}':");
        foreach (string word in wordsContainingSequence)
        {
            Console.WriteLine(word);
        }
    }

    static List<string> FindWordsContainingSequence(string text, string sequence)
    {
        List<string> wordsContainingSequence = new List<string>();

        string[] words = Regex.Split(text, @"\W+");

        foreach (string word in words)
        {
            if (word.Contains(sequence, StringComparison.OrdinalIgnoreCase))
                wordsContainingSequence.Add(word);
        }

        return wordsContainingSequence;
    }
}