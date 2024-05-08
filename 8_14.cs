class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите текст:");
        string text = Console.ReadLine();

        int sum = CalculateNumberSum(text);

        Console.WriteLine($"\nСумма чисел в тексте: {sum}");
    }

    static int CalculateNumberSum(string text)
    {
        int sum = 0;
        string[] words = text.Split(new[] { ' ', ',', '.', '!', '?', ':', ';', '\n', '\r', '\t' },
            StringSplitOptions.RemoveEmptyEntries);

        foreach (string word in words)
        {
            int number;
            if (int.TryParse(word, out number) && number >= 1 && number <= 10)
                sum += number;
        }

        return sum;
    }
}