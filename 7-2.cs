using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<Student> students = new List<Student>();

        Console.Write("Введите количество студентов: ");
        int numStudents = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < numStudents; i++)
        {
            Console.WriteLine($"\nВведите данные о {i + 1}-м студенте:");
            Console.Write("Имя: ");
            string name = Console.ReadLine();

            double totalScore = 0;

            for (int j = 0; j < 4; j++)
            {
                Console.Write($"Оценка за {j + 1}-й экзамен: ");
                double score = Convert.ToDouble(Console.ReadLine());
                totalScore += score;
            }

            double averageScore = totalScore / 4;
            students.Add(new Student(name, averageScore));
        }

        List<Student> passedStudents =
            students.Where(s => s.AverageScore >= 4).OrderByDescending(s => s.AverageScore).ToList();

        Console.WriteLine("\nРезультаты студентов со средним баллом не менее 4:");
        Console.WriteLine("{0,-15} {1,-10} {2,-15}", "Имя", "Ср. балл", "№ студ. билета");

        foreach (var student in passedStudents)
        {
            Console.WriteLine("{0,-15} {1,-10} {2,-15}", student.Name, student.AverageScore, student.StudentID);
        }
    }
}

class Person
{
    public string Name { get; }

    public Person(string name)
    {
        Name = name;
    }
}

class Student : Person
{
    public double AverageScore { get; }
    public string StudentID { get; }

    private static int studentCounter = 1000;

    public Student(string name, double averageScore) : base(name)
    {
        AverageScore = averageScore;
        studentCounter++;
        StudentID = $"{studentCounter}";
    }
}
