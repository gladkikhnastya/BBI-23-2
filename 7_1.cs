// class Program
// {
//     static void Main(string[] args)
//     {
//         List<Runner> runners = new List<Runner>();
//         
//         Console.WriteLine("Введите количество участниц:");
//         int count = Convert.ToInt32(Console.ReadLine());
//
//         Console.WriteLine("Введите данные о каждой участнице)");
//         for (int i = 0; i < count; i++)
//         {
//             Console.WriteLine("Введите фамилию участницы:");
//             string lastName = Console.ReadLine();
//
//             Console.WriteLine("Введите группу участницы:");
//             string group = Console.ReadLine();
//
//             Console.WriteLine("Введите фамилию преподавателя участницы:");
//             string teacherLastName = Console.ReadLine();
//
//             Console.WriteLine("Введите результат участницы (в секундах):");
//             double result = Convert.ToDouble(Console.ReadLine());
//
//             runners.Add(new Runner(lastName, group, teacherLastName, result));
//         }
//
//         runners = runners.OrderBy(p => p.Result).ToList();
//
//         Console.WriteLine("\nРезультирующая таблица:");
//         Console.WriteLine("{0,-15} {1,-15} {2,-20} {3}", "Фамилия", "Группа", "Фамилия преподавателя",
//             "Результат (сек)");
//
//         foreach (var participant in runners)
//         {
//             Console.WriteLine("{0,-15} {1,-15} {2,-20} {3}", participant.LastName, participant.Group,
//                 participant.TeacherLastName, participant.Result);
//         }
//
//         Console.WriteLine("\nВведите количество секунд для норматива:");
//         int norm = Convert.ToInt32(Console.ReadLine());
//         
//         int countWithNorm = runners.Count(p => p.Result <= norm);
//         Console.WriteLine("\nКоличество участниц, выполнивших норматив (результат <= {0} сек): {1}", norm,
//             countWithNorm);
//     }
// }
//
// class Runner
// {
//     public string LastName { get; set; }
//     public string Group { get; set; }
//     public string TeacherLastName { get; set; }
//     public double Result { get; set; }
//
//     public Runner(string lastName, string group, string teacherLastName, double result)
//     {
//         LastName = lastName;
//         Group = group;
//         TeacherLastName = teacherLastName;
//         Result = result;
//     }
// }