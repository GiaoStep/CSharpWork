double num1 = 0;
double num2 = 0;
Console.WriteLine("Welcome to Calculator\n");
Console.WriteLine("Please enter a number as num1");
num1 = Convert.ToDouble (Console.ReadLine());
Console.WriteLine("Please enter a number as num2");
num2 = Convert.ToDouble(Console.ReadLine());
Console.WriteLine("Please choose an operator\n");
Console.WriteLine("\tpress 1 for -- add");
Console.WriteLine("\tpress 2 for -- subtract");
Console.WriteLine("\tpress 3 for -- multiply");
Console.WriteLine("\tpress 4 for -- divide");

string op = "0";
op = Convert.ToString (Console.ReadLine());
switch (op)
{
    case "1":
        Console.WriteLine("Answer: num1 + num2 = "+(num1+num2));
        break;
    case "2":
        Console.WriteLine("Answer: num1 - num2 = "+( num1 - num2));
        break;
    case "3":
        Console.WriteLine("Answer: num1 * num2 = "+ (num1 * num2));
        break;
    case "4":
        Console.WriteLine("Answer: num1 / num2 = "+ (num1 / num2));
        break;
}
