using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите предложение:");
        string sentence = Console.ReadLine();

        int complexity = CalculateComplexity(sentence);
        Console.WriteLine($"\nСложность предложения: {complexity}");

        Console.ReadLine();
    }

    static int CalculateComplexity(string sentence)
    {
        string[] wordsAndPunctuation = Regex.Split(sentence, @"(\W)");
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

        return wordCount + punctuationCount;
    }
}