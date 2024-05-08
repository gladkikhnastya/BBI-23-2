// class Program
// {
//     static void Main(string[] args)
//     {
//         List<Group> groups = new List<Group>();
//
//         for (int i = 0; i < 3; i++)
//         {
//             Console.WriteLine($"\nВведите данные о группе {i + 1}:");
//             Console.Write("Название группы: ");
//             string groupName = Console.ReadLine();
//             
//             double totalScore = 0;
//             for (int j = 0; j < 5; j++)
//             {
//                 Console.Write($"Средний балл за {j + 1}-й экзамен: ");
//                 double score = Convert.ToDouble(Console.ReadLine());
//                 totalScore += score;
//             }
//             
//             double averageScore = totalScore / 5;
//             groups.Add(new Group(groupName, averageScore));
//         }
//
//         groups = groups.OrderByDescending(g => g.AverageScore).ToList();
//
//         Console.WriteLine("\nРезультаты среднего балла для трех групп:");
//         Console.WriteLine("{0,-20} {1,-10}", "Название группы", "Средний балл");
//
//         foreach (var group in groups)
//         {
//             Console.WriteLine("{0,-20} {1,-10}", group.Name, group.AverageScore);
//         }
//     }
// }
//
// class Group
// {
//     public string Name { get; }
//     public double AverageScore { get; }
//     
//     public Group(string name, double averageScore)
//     {
//         Name = name;
//         AverageScore = averageScore;
//     }
// }