// See https://aka.ms/new-console-template for more information
using System;

namespace Shapes
{
    // 定义一个接口，包含计算面积和判断形状是否合法的方法
    public interface IShape
    {
        double Area();
        bool IsValid();
    }

    // 定义一个抽象类，提供形状的基本属性和方法
    public abstract class Shape : IShape
    {
        // 形状的长度、宽度等属性
        protected double Length { get; set; }
        protected double Width { get; set; }

        // 计算面积的方法，需要在子类中实现
        public abstract double Area();

        // 判断形状是否合法的方法，需要在子类中实现
        public abstract bool IsValid();
    }

    // 长方形类
    public class Rectangle : Shape
    {
        public Rectangle(double length, double width)
        {
            Length = length;
            Width = width;
        }

        public override double Area()
        {
            return Length * Width;
        }

        public override bool IsValid()
        {
            return Length > 0 && Width > 0;
        }
    }

    // 正方形类，继承自长方形类
    public class Square : Rectangle
    {
        public Square(double sideLength) : base(sideLength, sideLength)
        {
        }
    }

    // 三角形类
    public class Triangle : Shape
    {
        private double _side1;
        private double _side2;
        private double _side3;

        public Triangle(double side1, double side2, double side3)
        {
            _side1 = side1;
            _side2 = side2;
            _side3 = side3;
        }

        public override double Area()
        {
            // 使用海伦公式计算三角形面积
            double s = (_side1 + _side2 + _side3) / 2;
            return Math.Sqrt(s * (s - _side1) * (s - _side2) * (s - _side3));
        }

        public override bool IsValid()
        {
            // 判断三角形是否合法
            return _side1 + _side2 > _side3 &&
                   _side2 + _side3 > _side1 &&
                   _side1 + _side3 > _side2;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Rectangle rect = new Rectangle(5, 10);
            Console.WriteLine("Rectangle area: " + rect.Area());
            Console.WriteLine("Rectangle is valid: " + rect.IsValid());

            Square square = new Square(7);
            Console.WriteLine("Square area: " + square.Area());
            Console.WriteLine("Square is valid: " + square.IsValid());

            Triangle triangle = new Triangle(3, 4, 5);
            Console.WriteLine("Triangle area: " + triangle.Area());
            Console.WriteLine("Triangle is valid: " + triangle.IsValid());

            Console.ReadKey();
        }
    }
}

