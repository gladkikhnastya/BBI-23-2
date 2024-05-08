// class Program
// {
//     static void Main(string[] args)
//     {
//         List<Student> students = new List<Student>();
//         
//         Console.Write("Введите количество студентов: ");
//         int numStudents = Convert.ToInt32(Console.ReadLine());
//
//         for (int i = 0; i < numStudents; i++)
//         {
//             Console.WriteLine($"\nВведите данные о {i + 1}-м студенте:");
//             Console.Write("Имя: ");
//             string name = Console.ReadLine();
//
//             double totalScore = 0;
//
//             for (int j = 0; j < 4; j++)
//             {
//                 Console.Write($"Оценка за {j + 1}-й экзамен: ");
//                 double score = Convert.ToDouble(Console.ReadLine());
//                 totalScore += score;
//             }
//
//             double averageScore = totalScore / 4;
//             students.Add(new Student(name, averageScore));
//         }
//
//         List<Student> passedStudents =
//             students.Where(s => s.AverageScore >= 4).OrderByDescending(s => s.AverageScore).ToList();
//
//         Console.WriteLine("\nРезультаты студентов со средним баллом не менее 4:");
//         Console.WriteLine("{0,-15} {1,-10}", "Имя", "Средний балл");
//
//         foreach (var student in passedStudents)
//         {
//             Console.WriteLine("{0,-15} {1,-10}", student.Name, student.AverageScore);
//         }
//     }
// }
//
// class Student
// {
//     public string Name { get; }
//     public double AverageScore { get; }
//
//     public Student(string name, double averageScore)
//     {
//         Name = name;
//         AverageScore = averageScore;
//     }
// }