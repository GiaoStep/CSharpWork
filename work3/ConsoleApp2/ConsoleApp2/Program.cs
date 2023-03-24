// See https://aka.ms/new-console-template for more information
using System;

public class Node<T>
{
    public Node<T> Next { get; set; }
    public T Data { get; set; }

    public Node(T t)
    {
        Next = null;
        Data = t;
    }
}

public class GenericList<T>
{
    private Node<T> head;
    private Node<T> tail;

    public GenericList()
    {
        tail = head = null;
    }

    public Node<T> Head
    {
        get => head;
    }

    public void Add(T t)
    {
        Node<T> n = new Node<T>(t);

        if (tail == null)
        {
            head = tail = n;
        }
        else
        {
            tail.Next = n;
            tail = n;
        }
    }

    public void ForEach(Action<T> action)
    {
        for (Node<T> node = head; node != null; node = node.Next)
        {
            action(node.Data);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // 整型List
        GenericList<int> intList = new GenericList<int>();
        for (int x = 0; x < 10; x++)
        {
            intList.Add(x);
        }

        // 打印链表元素
        Console.Write("intList: ");
        intList.ForEach((n) => Console.Write($"{n} "));

        // 求最大值
        int max = int.MinValue;
        intList.ForEach((n) =>
        {
            if (n > max)
            {
                max = n;
            }
        });
        Console.WriteLine($"\nintList最大值: {max}");

        // 求最小值
        int min = int.MaxValue;
        intList.ForEach((n) =>
        {
            if (n < min)
            {
                min = n;
            }
        });
        Console.WriteLine($"intList最小值: {min}");

        // 求和
        int sum = 0;
        intList.ForEach((n) => sum += n);
        Console.WriteLine($"intList求和: {sum}");

        // 字符串型List
        GenericList<string> strList = new GenericList<string>();
        for (int x = 0; x < 10; x++)
        {
            strList.Add($"str{x}");
        }

        // 打印链表元素
        Console.Write("strList: ");
        strList.ForEach((n) => Console.Write($"{n} "));
    }
}

