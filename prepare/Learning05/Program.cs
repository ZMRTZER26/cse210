using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        Square s1 = new Square("Square", 6);
        shapes.Add(s1);

        Rectangle s2 = new Rectangle("Rectangle", 2, 3);
        shapes.Add(s2);

        Circle s3 = new Circle("Circle", 4);
        shapes.Add(s3);

        foreach (Shape s in shapes)
        {
            string color = s.GetColor();

            double area = s.GetArea();

            Console.WriteLine($"The shape, {color}, has an area of {area:F2}.");
        }
    }
}