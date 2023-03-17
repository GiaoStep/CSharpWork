// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

namespace Shapes
{
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
        // 定义一个形状类型的枚举
        public enum ShapeType
        {
            Rectangle,
            Square,
            Triangle
        }

        // 简单工厂类，用于创建不同类型的形状对象
        public static class ShapeFactory
        {
            public static Shape CreateShape(ShapeType type, params double[] args)
            {
                switch (type)
                {
                    case ShapeType.Rectangle:
                        return new Rectangle(args[0], args[1]);
                    case ShapeType.Square:
                        return new Square(args[0]);
                    case ShapeType.Triangle:
                        return new Triangle(args[0], args[1], args[2]);
                    default:
                        throw new ArgumentException("Invalid shape type.");
                }
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                // 随机生成10个形状对象，并计算它们的面积之和
                Random rand = new Random();
                List<Shape> shapes = new List<Shape>();
                double totalArea = 0;
                for (int i = 0; i < 10; i++)
                {
                    // 随机选择一个形状类型
                    ShapeType type = (ShapeType)rand.Next(0, 3);

                    // 根据类型和参数创建形状对象
                    Shape shape;
                    switch (type)
                    {
                        case ShapeType.Rectangle:
                            double length = rand.Next(1, 10);
                            double width = rand.Next(1, 10);
                            shape = ShapeFactory.CreateShape(type, length, width);
                            break;
                        case ShapeType.Square:
                            double sideLength = rand.Next(1, 10);
                            shape = ShapeFactory.CreateShape(type, sideLength);
                            break;
                        case ShapeType.Triangle:
                            double side1 = rand.Next(1, 10);
                            double side2 = rand.Next(1, 10);
                            double side3 = side1 + side2 + rand.Next(1, 10);
                            shape = ShapeFactory.CreateShape(type, side1, side2, side3);
                            break;
                        default:
                            throw new ArgumentException("Invalid shape type.");
                    }

                    // 计算面积并加入总面积
                    if (shape.IsValid())
                    {
                        totalArea += shape.Area();
                        shapes.Add(shape);
                    }
                }

                // 输出每个形状的面积和总面积
                foreach (Shape shape in shapes)
                {
                    Console.WriteLine("{0} area: {1}", shape.GetType().Name, shape.Area());
                }
                Console.WriteLine("Total area: " + totalArea);

                Console.ReadKey();
            }
        }
    }
}

