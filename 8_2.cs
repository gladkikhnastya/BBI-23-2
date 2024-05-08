using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите сообщение для шифрования:");
        string message = Console.ReadLine();

        string encryptedMessage = Encrypt(message);
        Console.WriteLine("\nЗашифрованное сообщение: " + encryptedMessage);

        string decryptedMessage = Decrypt(encryptedMessage);
        Console.WriteLine("Расшифрованное сообщение: " + decryptedMessage);

        Console.ReadLine();
    }

    static string Encrypt(string message)
    {
        string[] words = message.Split(' ');
        StringBuilder encryptedMessage = new StringBuilder();

        foreach (string word in words)
        {
            char[] characters = word.ToCharArray();
            Array.Reverse(characters);
            encryptedMessage.Append(new string(characters) + " ");
        }

        return encryptedMessage.ToString().Trim();
    }

    static string Decrypt(string encryptedMessage)
    {
        string[] words = encryptedMessage.Split(' ');
        StringBuilder decryptedMessage = new StringBuilder();

        foreach (string word in words)
        {
            char[] characters = word.ToCharArray();
            Array.Reverse(characters);
            decryptedMessage.Append(new string(characters) + " ");
        }

        return decryptedMessage.ToString().Trim();
    }
}