using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2._1
{
    class Point
    {
        private double x;
        private double y;
        private string name;

        public double X
        {
            get { return x; }
        }

        public double Y
        {
            get { return y; }
        }

        public string Name
        {
            get { return name; }
        }

        public Point(double x, double y, string name)
        {
            this.x = x;
            this.y = y;
            this.name = name;
        }
    }

    class Figure
    {
        private Point[] points;
        private double perimeter;

        public Figure(Point A, Point B, Point C)
        {
            points = new Point[] { A, B, C };
            CalculatePerimeter();
        }

        public Figure(Point A, Point B, Point C, Point D) : this(A, B, C)
        {
            Array.Resize(ref points, 4);
            points[3] = D;
            CalculatePerimeter();
        }

        public Figure(Point A, Point B, Point C, Point D, Point E) : this(A, B, C, D)
        {
            Array.Resize(ref points, 5);
            points[4] = E;
            CalculatePerimeter();
        }
        public double GetSideLength(Point A, Point B)
        {
            return Math.Sqrt(Math.Pow(B.X - A.X, 2) + Math.Pow(B.Y - A.Y, 2));
        }

        public void CalculatePerimeter()
        {
            perimeter = 0;
            for (int i = 0; i < points.Length; i++)
            {
                Point current = points[i];
                Point next = points[(i + 1) % points.Length]; 
                perimeter += GetSideLength(current, next);
            }
        }

        public void ShowFigureInfo()
        {
            string figureName = points.Length == 3 ? "Трикутник" :
                                points.Length == 4 ? "Чотирикутник" :
                                points.Length == 5 ? "П'ятикутник" : "Багатокутник";

            Console.WriteLine($"{figureName}, периметр: {perimeter}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Point A = new Point(0, 0, "A");
            Point B = new Point(3, 0, "B");
            Point C = new Point(3, 4, "C");
            Point D = new Point(0, 4, "D");

            Figure triangle = new Figure(A, B, C);
            triangle.ShowFigureInfo();

            Figure rectangle = new Figure(A, B, C, D);
            rectangle.ShowFigureInfo();
        }
    }
}
