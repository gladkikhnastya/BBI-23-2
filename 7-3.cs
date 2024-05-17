class Program
{
    static void Main(string[] args)
    {
        List<Group> groups = new List<Group>();

        List<Student> studentsA = new List<Student>
         {
             new Student("Иванов", 4.5),
             new Student("Петров", 4.8),
             new Student("Сидоров", 4.2),
             new Student("Козлов", 4.7),
             new Student("Смирнов", 4.9)
         };

        List<Student> studentsB = new List<Student>
         {
             new Student("Smith", 4.3),
             new Student("Johnson", 4.6),
             new Student("Williams", 4.4),
             new Student("Brown", 4.9),
             new Student("Jones", 4.8)
         };

        List<Student> studentsC = new List<Student>
         {
             new Student("Li", 4.2),
             new Student("Wang", 4.4),
             new Student("Zhang", 4.3),
             new Student("Chen", 4.5),
             new Student("Yang", 4.6)
         };

        GroupA groupA = new GroupA("Группа A", studentsA);
        groups.Add(groupA);

        GroupB groupB = new GroupB("Группа B", studentsB);
        groups.Add(groupB);

        GroupC groupC = new GroupC("Группа C", studentsC);
        groups.Add(groupC);

        groupA.CalculateAverageScore();
        groupB.CalculateAverageScore();
        groupC.CalculateAverageScore();

        Console.WriteLine("\nРезультаты среднего балла для трех групп:");
        Console.WriteLine("{0,-20} {1,-10}", "Название группы", "Средний балл");

        foreach (var group in groups)
        {
            Console.WriteLine("{0,-20} {1,-10:F2}", group.Name, group.CalculateAverageScore());
        }

        Console.WriteLine("\nСписок студентов всех групп:");
        Console.WriteLine("{0,-20} {1,-10} {2,-10}", "Имя", "Номер группы", "Средний балл");

        foreach (var group in groups)
        {
            foreach (var student in group.Students)
            {
                Console.WriteLine("{0,-20} {1,-10} {2,-10}", student.Name, group.Name, student.AverageScore);
            }
        }
    }
}

class Group
{
    public string Name { get; }
    public List<double> ExamScores { get; } = new List<double>();
    public List<Student> Students { get; }

    public Group(string name, List<Student> students)
    {
        Name = name;
        Students = students;
    }

    public virtual double CalculateAverageScore()
    {
        foreach (var student in Students)
        {
            ExamScores.Add(student.AverageScore);
        }

        return ExamScores.Average();
    }
}

class GroupA : Group
{
    public GroupA(string name, List<Student> students) : base(name, students)
    {
    }

    public override double CalculateAverageScore()
    {
        double additionalSubjectMultiplier = 1.1;

        return Math.Clamp(base.CalculateAverageScore() * additionalSubjectMultiplier, 1, 5);
    }
}

class GroupB : Group
{
    public GroupB(string name, List<Student> students) : base(name, students)
    {
    }

    public override double CalculateAverageScore()
    {
        double additionalSubjectMultiplier = 1.05;

        return Math.Clamp(base.CalculateAverageScore() * additionalSubjectMultiplier, 1, 5);
    }
}

class GroupC : Group
{
    public GroupC(string name, List<Student> students) : base(name, students)
    {
    }

    public override double CalculateAverageScore()
    {
        double additionalSubjectMultiplier = 1.07;

        return Math.Clamp(base.CalculateAverageScore() * additionalSubjectMultiplier, 1, 5);
    }
}

class Student
{
    public string Name { get; }
    public double AverageScore { get; }

    public Student(string name, double averageScore)
    {
        Name = name;
        AverageScore = averageScore;
    }
}
