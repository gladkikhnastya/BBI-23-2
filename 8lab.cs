using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

abstract class Task
{
    public abstract string Process(string input);
}

class ReverseTextTask : Task
{
    public override string Process(string input)
    {
        string[] words = input.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            words[i] = ReverseWordPreservingPunctuation(words[i]);
        }
        return string.Join(" ", words);
    }

    private string ReverseWordPreservingPunctuation(string word)
    {
        char[] chars = word.ToCharArray();
        char[] result = new char[chars.Length];
        int left = 0;
        int right = chars.Length - 1;

        while (left <= right)
        {
            if (!char.IsLetterOrDigit(chars[left]))
            {
                result[left] = chars[left];
                left++;
            }
            else if (!char.IsLetterOrDigit(chars[right]))
            {
                result[right] = chars[right];
                right--;
            }
            else
            {
                result[left] = chars[right];
                result[right] = chars[left];
                left++;
                right--;
            }
        }

        return new string(result);
    }
}

class WordPunctuationAnalyzer : Task
{
    public override string Process(string input)
    {
        string[] wordsAndPunctuation = Regex.Split(input, @"(\W)");
        int wordCount = 0;
        int punctuationCount = 0;

        foreach (string item in wordsAndPunctuation)
        {
            if (!string.IsNullOrWhiteSpace(item))
            {
                if (char.IsLetterOrDigit(item[0]))
                    wordCount++;
                else
                    punctuationCount++;
            }
        }

        return $"Сложность предложения: {wordCount + punctuationCount}";
    }
}

class LetterFrequencyAnalyzer : Task
{
    public override string Process(string input)
    {
        Dictionary<char, int> letterFrequencies = new Dictionary<char, int>();

        string[] words = input.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (string word in words)
        {
            if (!string.IsNullOrEmpty(word))
            {
                char firstLetter = word[0];

                if (char.IsLetter(firstLetter))
                {
                    if (letterFrequencies.ContainsKey(firstLetter))
                        letterFrequencies[firstLetter]++;
                    else
                        letterFrequencies[firstLetter] = 1;
                }
            }
        }

        var sortedFrequencies = letterFrequencies.OrderByDescending(pair => pair.Value);

        StringBuilder result = new StringBuilder();
        result.AppendLine("Буквы, на которые начинаются слова в тексте, в порядке убывания частоты их употребления:");
        foreach (var pair in sortedFrequencies)
        {
            result.AppendLine($"{pair.Key}: {pair.Value}");
        }

        return result.ToString();
    }
}

class SequenceAnalyzer : Task
{
    public override string Process(string input)
    {
        Console.WriteLine("Введите последовательность букв:");
        string sequence = Console.ReadLine();

        List<string> wordsContainingSequence = new List<string>();
        string[] words = Regex.Split(input, @"\W+");

        foreach (string word in words)
        {
            if (word.Contains(sequence, StringComparison.OrdinalIgnoreCase))
                wordsContainingSequence.Add(word);
        }

        return $"Слова, содержащие последовательность '{sequence}': {string.Join(", ", wordsContainingSequence)}";
    }
}

class SurnameSortingTask : Task
{
    public override string Process(string input)
    {
        string[] surnames = input.Split(',').Select(s => s.Trim()).OrderBy(s => s).ToArray();
        return string.Join(", ", surnames);
    }
}

class NumberSumTask : Task
{
    public override string Process(string input)
    {
        int sum = 0;
        string[] words = input.Split(new[] { ' ', ',', '.', '!', '?', ':', ';', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (string word in words)
        {
            if (int.TryParse(word, out int number) && number >= 1 && number <= 10)
                sum += number;
        }

        return $"Сумма чисел от 1 до 10 в тексте: {sum}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Выберите задание: ");
        Console.WriteLine("1) Зашифровать и расшифровать сообщение.");
        Console.WriteLine("2) Определить сложность предложения.");
        Console.WriteLine("3) Вывести буквы, на которые начинаются слова в тексте, в порядке убывания частоты их употребления.");
        Console.WriteLine("4) Вывести слова, содержащие заданную последовательность букв.");
        Console.WriteLine("5) Упорядочить список фамилий по алфавиту.");
        Console.WriteLine("6) Найти сумму чисел от 1 до 10 в тексте.");
        Console.Write("Ваш выбор: ");

        int choice = int.Parse(Console.ReadLine());

        Task task;
        switch (choice)
        {
            case 1:
                task = new ReverseTextTask();
                break;
            case 2:
                task = new WordPunctuationAnalyzer();
                break;
            case 3:
                task = new LetterFrequencyAnalyzer();
                break;
            case 4:
                task = new SequenceAnalyzer();
                break;
            case 5:
                task = new SurnameSortingTask();
                break;
            case 6:
                task = new NumberSumTask();
                break;
            default:
                Console.WriteLine("Недопустимый выбор.");
                return;
        }

        Console.Write("Введите текст: ");
        string input = Console.ReadLine();

        string result = task.Process(input);
        Console.WriteLine($"Результат:\n{result}");
    }
}
