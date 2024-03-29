// See https://aka.ms/new-console-template for more information

//1.2
using System;

abstract class Running
{
    protected string name;
    protected double time;

    public Running(string name, double time)
    {
        this.name = name;
        this.time = time;
    }

    public abstract void DisplayInfo();
}

class Running100m : Running
{
    public Running100m(string name, double time) : base(name, time) { }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Name: {name}, Distance: 100m, Time: {time} seconds");
    }
}

class Running500m : Running
{
    public Running500m(string name, double time) : base(name, time) { }

    public override void DisplayInfo()
    {
        Console.WriteLine($"Name: {name}, Distance: 500m, Time: {time} seconds");
    }
}

struct Sportsmen
{
    private string name;
    private string surname;
    private string group;
    private string tutor;
    private double result;

    public Sportsmen(string name, string surname, string group, string tutor, double result)
    {
        this.name = name;
        this.surname = surname;
        this.group = group;
        this.tutor = tutor;
        this.result = result;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Имя: {name}, Фамилия: {surname}, Группа: {group}, Тренер: {tutor}, Результат: {result}");
    }

    public double GetResult()
    {
        return result;
    }
}

class Program
{
    static void Main()
    {
        Running[] runners = new Running[]
        {
            new Running100m("Иванова Катя", 12.5),
            new Running100m("Петрова Маша", 11.8),
            new Running100m("Сидорова Лера", 13.2),
            new Running500m("Кузнецова Соня", 60.3),
            new Running500m("Макарова Валя", 58.9)
        };

        Console.WriteLine("Results for 100m race:");
        Console.WriteLine("-----------------------");
        foreach (var runner in runners)
        {
            if (runner is Running100m)
            {
                runner.DisplayInfo();
            }
        }

        Console.WriteLine("\nResults for 500m race:");
        Console.WriteLine("-----------------------");
        foreach (var runner in runners)
        {
            if (runner is Running500m)
            {
                runner.DisplayInfo();
            }
        }
    }
}

//2.1
using System;

class Person
{
    protected string firstName;
    protected string lastName;
    protected string patronymic;

    public Person(string firstName, string lastName, string patronymic)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        this.patronymic = patronymic;
    }

    public string GetFullName()
    {
        return $"{lastName} {firstName} {patronymic}";
    }
}

class Student : Person
{
    private int studentId;
    private double[] grades;
    private double averageGrade;

    public Student(string firstName, string lastName, string patronymic, int studentId, double[] grades) : base(firstName, lastName, patronymic)
    {
        this.studentId = studentId;
        this.grades = grades;
        CalculateAverageGrade();
        Console.WriteLine($"ФИО: {GetFullName()}, № студ. билета: {studentId}, Средний балл: {averageGrade}");
    }

    private void CalculateAverageGrade()
    {
        double sum = 0;
        foreach (double grade in grades)
        {
            sum += grade;
        }
        averageGrade = sum / grades.Length;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Student[] students = new Student[3];
        students[0] = new Student("Иван", "Наумов", "Петрович", 12345, new double[] { 5.0, 5.0, 5.0, 5.0, 5.0 });
        students[1] = new Student("Петр", "Селиванов", "Иванович", 54321, new double[] { 2.0, 2.0, 3.0, 4.0, 4.0 });
        students[2] = new Student("Алексей", "Аборин", "Сергеевич", 98765, new double[] { 5.0, 4.0, 4.0, 4.0, 4.0 });

        Console.WriteLine();

        for (int i = 0; i < students.Length - 1; i++)
        {
            double max = students[i].averageGrade;
            int index = i;
            for (int j = i + 1; j < students.Length; j++)
            {
                if (students[j].averageGrade > max)
                {
                    max = students[j].averageGrade;
                    index = j;
                }

                Student temp = students[index];
                students[index] = students[i];
                students[i] = temp;
            }
        }

        Console.WriteLine();
        for (int i = 0; i < students.Length; i++)
        {
            if (students[i].averageGrade >= 4)
            {
                Console.WriteLine($"ФИО: {students[i].GetFullName()}, № студ. билета: {students[i].studentId}, Средний балл: {students[i].averageGrade}");
            }
        }
    }
}




//3.1
using System;

class Group
{
    public string Name { get; private set; }
    protected int[] examScores;
    protected string[] subjects;

    public Group(string name, int[] scores, string[] subjects)
    {
        Name = name;
        examScores = scores;
        this.subjects = subjects;
    }

    public virtual double GetAverageScore()
    {
        int sum = 0;
        foreach (int score in examScores)
        {
            sum += score;
        }
        return (double)sum / examScores.Length;
    }

    public void PrintStudents()
    {
        Console.WriteLine($"Group: {Name}");
        for (int i = 0; i < examScores.Length; i++)
        {
            Console.WriteLine($"Student {i + 1}: Average Score - {GetAverageScore()} | Subjects: {string.Join(", ", subjects)}");
        }
        Console.WriteLine();
    }
}

class GroupA : Group
{
    public GroupA(string name, int[] scores) : base(name, scores, new string[] { "Math", "Physics" }) { }

    public override double GetAverageScore()
    {
        // Custom calculation for GroupA average score
        return base.GetAverageScore() * 1.1; // Adding 10%
    }
}

class GroupB : Group
{
    public GroupB(string name, int[] scores) : base(name, scores, new string[] { "English", "History" }) { }

    public override double GetAverageScore()
    {
        // Custom calculation for GroupB average score
        return base.GetAverageScore() * 0.9; // Subtracting 10%
    }
}

class GroupC : Group
{
    public GroupC(string name, int[] scores) : base(name, scores, new string[] { "Chemistry", "Biology" }) { }

    public override double GetAverageScore()
    {
        // Custom calculation for GroupC average score
        return base.GetAverageScore(); // No change
    }
}

class Program
{
    static void Main()
    {
        Group[] groups = new Group[3];
        groups[0] = new GroupA("1", new int[] { 5, 5, 5, 5, 5 });
        groups[1] = new GroupB("2", new int[] { 2, 2, 3, 4, 4 });
        groups[2] = new GroupC("3", new int[] { 5, 4, 4, 4, 4 });

        Console.WriteLine("Students from all groups:");
        foreach (var group in groups)
        {
            group.PrintStudents();
        }
    }
}

