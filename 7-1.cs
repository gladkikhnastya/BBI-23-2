class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\nЗабег на 100 метров ");
        Run100MEvent run100M = new Run100MEvent();
        run100M.RunEvent();

        Console.WriteLine("\nЗабег на 500 метров =====");
        Run500MEvent run500M = new Run500MEvent();
        run500M.RunEvent();

        Console.WriteLine("\nВведите количество секунд для норматива:");
        int norm = Convert.ToInt32(Console.ReadLine());

        run100M.CheckNorm(norm);
        run500M.CheckNorm(norm);
    }
}

abstract class RunningEvent
{
    protected List<Runner> runners = new List<Runner>();

    public abstract void RunEvent();

    public void InputRunnersData(int count)
    {
        Console.WriteLine("Введите данные о каждой участнице:");
        for (int i = 0; i < count; i++)
        {
            Console.WriteLine("Введите фамилию участницы:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Введите группу участницы:");
            string group = Console.ReadLine();

            Console.WriteLine("Введите фамилию преподавателя участницы:");
            string teacherLastName = Console.ReadLine();

            Console.WriteLine("Введите результат участницы (в секундах):");
            double result = Convert.ToDouble(Console.ReadLine());

            runners.Add(new Runner(lastName, group, teacherLastName, result));
        }
    }

    public void CheckNorm(int norm)
    {
        int countWithNorm = runners.Count(p => p.Result <= norm);
        Console.WriteLine("\nКоличество участниц, выполнивших норматив (результат <= {0} сек): {1}", norm,
            countWithNorm);
    }
}

class Run100MEvent : RunningEvent
{
    public override void RunEvent()
    {
        Console.WriteLine("Введите количество участниц для забега на 100 метров:");
        int count = Convert.ToInt32(Console.ReadLine());

        InputRunnersData(count);

        runners = runners.OrderBy(p => p.Result).ToList();

        Console.WriteLine("{0,-15} {1,-15} {2,-20} {3}", "Фамилия", "Группа", "Фамилия преподавателя",
            "Результат (сек)");
        foreach (var participant in runners)
        {
            Console.WriteLine("{0,-15} {1,-15} {2,-20} {3}", participant.LastName, participant.Group,
                participant.TeacherLastName, participant.Result);
        }
    }
}

class Run500MEvent : RunningEvent
{
    public override void RunEvent()
    {
        Console.WriteLine("Введите количество участниц для забега на 500 метров:");
        int count = Convert.ToInt32(Console.ReadLine());

        InputRunnersData(count);

        runners = runners.OrderBy(p => p.Result).ToList();

        Console.WriteLine("{0,-15} {1,-15} {2,-20} {3}", "Фамилия", "Группа", "Фамилия преподавателя",
            "Результат (сек)");
        foreach (var participant in runners)
        {
            Console.WriteLine("{0,-15} {1,-15} {2,-20} {3}", participant.LastName, participant.Group,
                participant.TeacherLastName, participant.Result);
        }
    }
}

class Runner
{
    public string LastName { get; }
    public string Group { get; }
    public string TeacherLastName { get; }
    public double Result { get; }

    public Runner(string lastName, string group, string teacherLastName, double result)
    {
        LastName = lastName;
        Group = group;
        TeacherLastName = teacherLastName;
        Result = result;
    }
}