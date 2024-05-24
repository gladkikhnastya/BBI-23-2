// See https://aka.ms/new-console-template for more information
using System;

class Point
{
    private int x;
    private int y;

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public int X { get { return x; } }
    public int Y { get { return y; } }
}

abstract class Fourangle
{
    protected Point[] points;

    public Fourangle(Point p1, Point p2, Point p3, Point p4)
    {
        points = new Point[4];
        points[0] = p1;
        points[1] = p2;
        points[2] = p3;
        points[3] = p4;
    }

    public abstract double CalculateArea();

    public abstract double CalculatePerimeter();

    protected Point[] Points { get { return points; } }
}

class Square : Fourangle
{
    public Square(Point p1, Point p2, Point p3, Point p4) : base(p1, p2, p3, p4)
    {
    }

    public override double CalculateArea()
    {
        double side = Math.Sqrt(Math.Pow(Points[0].X - Points[1].X, 2) + Math.Pow(Points[0].Y - Points[1].Y, 2));
        return side * side;
    }

    public override double CalculatePerimeter()
    {
        double side = Math.Sqrt(Math.Pow(Points[0].X - Points[1].X, 2) + Math.Pow(Points[0].Y - Points[1].Y, 2));
        return 4 * side;
    }
}

class Rectangle : Fourangle
{
    public Rectangle(Point p1, Point p2, Point p3, Point p4) : base(p1, p2, p3, p4)
    {
    }

    public override double CalculateArea()
    {
        double side1 = Math.Sqrt(Math.Pow(Points[0].X - Points[1].X, 2) + Math.Pow(Points[0].Y - Points[1].Y, 2));
        double side2 = Math.Sqrt(Math.Pow(Points[1].X - Points[2].X, 2) + Math.Pow(Points[1].Y - Points[2].Y, 2));
        return side1 * side2;
    }

    public override double CalculatePerimeter()
    {
        double side1 = Math.Sqrt(Math.Pow(Points[0].X - Points[1].X, 2) + Math.Pow(Points[0].Y - Points[1].Y, 2));
        double side2 = Math.Sqrt(Math.Pow(Points[1].X - Points[2].X, 2) + Math.Pow(Points[1].Y - Points[2].Y, 2));
        return 2 * (side1 + side2);
    }
}

class Trapezium : Fourangle
{
    public Trapezium(Point p1, Point p2, Point p3, Point p4) : base(p1, p2, p3, p4)
    {
    }

    public override double CalculateArea()
    {
        return 0;
    }

    public override double CalculatePerimeter()
    {
        return 0;
    }
}

class Program
{
    static void Main()
    {
        Square[] squares = new Square[]
        {
            new Square(new Point(0, 0), new Point(0, 4), new Point(4, 4), new Point(4, 0)),
            new Square(new Point(0, 0), new Point(0, 3), new Point(3, 3), new Point(3, 0)),
            new Square(new Point(0, 0), new Point(0, 5), new Point(5, 5), new Point(5, 0))
        };

        Rectangle[] rectangles = new Rectangle[]
        {
            new Rectangle(new Point(0, 0), new Point(0, 6), new Point(8, 6), new Point(8, 0)),
            new Rectangle(new Point(0, 0), new Point(0, 4), new Point(6, 4), new Point(6, 0)),
            new Rectangle(new Point(0, 0), new Point(0, 7), new Point(9, 7), new Point(9, 0))
        };

        Trapezium[] trapeziums = new Trapezium[]
        {
            new Trapezium(new Point(0, 0), new Point(0, 6), new Point(8, 6), new Point(8, 0)),
            new Trapezium(new Point(0, 0), new Point(0, 4), new Point(6, 4), new Point(6, 0)),
            new Trapezium(new Point(0, 0), new Point(0, 7), new Point(9, 7), new Point(9, 0))
        };

        PrintTable("Squares", squares);
        PrintTable("Rectangles", rectangles);
        PrintTable("Trapeziums", trapeziums);
    }

    static void PrintTable(string title, Fourangle[] shapes)
    {
        Console.WriteLine($"\\n{title}:");
        Console.WriteLine("Name\\tPerimeter\\tArea");

        foreach (var shape in shapes)
        {
            Console.WriteLine($"{shape.GetType().Name}\\t{shape.CalculatePerimeter()}\\t{shape.CalculateArea()}");
        }
    }
}