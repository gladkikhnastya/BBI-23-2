class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите текст:");
        string text = Console.ReadLine();

        Dictionary<char, int> letterFrequencies = CountLetterFrequencies(text);

        Console.WriteLine("\nБуквы, на которые начинаются слова в тексте, в порядке убывания частоты их употребления:");
        foreach (var pair in letterFrequencies.OrderByDescending(pair => pair.Value))
        {
            Console.WriteLine($"{pair.Key}: {pair.Value}");
        }
    }

    static Dictionary<char, int> CountLetterFrequencies(string text)
    {
        Dictionary<char, int> letterFrequencies = new Dictionary<char, int>();

        string[] words = text.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

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

        return letterFrequencies;
    }
}