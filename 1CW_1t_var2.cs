// See https://aka.ms/new-console-template for more information
using System;

struct Point
{
    private int[] coordinates;

    public Point(int x, int y)
    {
        coordinates = new int[2];
        coordinates[0] = x;
        coordinates[1] = y;
    }

    public static double CalculateDistance(Point p1, Point p2)
    {
        return Math.Sqrt(Math.Pow(p2.coordinates[0] - p1.coordinates[0], 2) + Math.Pow(p2.coordinates[1] - p1.coordinates[1], 2));
    }

    public static void PrintPointInfo(Point p1, Point p2)
    {
        Console.WriteLine($"Coordinates of Point 1: ({p1.coordinates[0]}, {p1.coordinates[1]})");
        Console.WriteLine($"Coordinates of Point 2: ({p2.coordinates[0]}, {p2.coordinates[1]})");
        Console.WriteLine($"Distance between the points: {CalculateDistance(p1, p2)}");
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        Point[] points = new Point[3];
        points[0] = new Point(1, 2);
        points[1] = new Point(3, 4);
        points[2] = new Point(5, 6);

        Console.WriteLine("Point Information:");
        Console.WriteLine("------------------");

        for (int i = 0; i < points.Length - 1; i++)
        {
            Point.PrintPointInfo(points[i], points[i + 1]);
        }
    }
}