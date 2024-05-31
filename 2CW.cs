using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Json;
using System.Text.Json.Serialization;
abstract class Task
{
    public Task(string text) { }

}
class Task_1 : Task
{
    private string _text;
    public Task_1(string text) : base(text)
    {
        _text = text;
    }

    public string[] ParseText(string text)
    {
        return text.Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Split(' ').Last()).ToArray();
    }
    public override string ToString()
    {
        return $"Последние слова предложений: {string.Join(", ", ParseText(_text))}";
    }
}
class Task_2 : Task
{
    private string _text;
    public Task_2(string text) : base(text)
    {
        _text = text;
    }
    public int ParseText(string text)
    {
        int maxdlina = 0;
        int dlina = 0;
        char Char1 = '\0';
        foreach (char c in text)
        {
            if (c == Char1)
            {
                dlina++;
            }
            else
            {
                dlina = 1;
            }
            Char1 = c;
            maxdlina = Math.Max(maxdlina, dlina);
        }
        return maxdlina;
    }

    public override string ToString()
    {
        return $"Наибольшее количество символов: {ParseText(_text)}";
    }
}

class Program
{
    public static void Main()
    {
        string text = "Чудесный день. А, может, вообще не чудесный.";
        Task task = new Task_2(text);
        Console.WriteLine(task.ToString());
        Task task2 = new Task_1(text);
        Console.WriteLine(task2.ToString());
        string path = @"C:\Users\m2310666";
        string folderName = "Test";
        path = Path.Combine(path, folderName);
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        string fileName1 = "task_1.json";
        string fileName2 = "task_2.json";
    }
}