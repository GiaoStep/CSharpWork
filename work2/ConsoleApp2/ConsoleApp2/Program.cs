// See https://aka.ms/new-console-template for more information
int[] arry=new int[100];
Console.WriteLine("Please enter every number of arrey");
string str=Console.ReadLine();
string []str1 = str.Split(' ');
for(int i = 0; i < str1.Length; i++)
{
    arry[i] = Convert.ToInt32(str1[i]);
}
int sum, max, min;
double avg;
sum  = max = min = arry[0];
for(int i = 1; i < str1.Length; i++)
{
    
    sum = sum + arry[i];
    if (arry[i] >= max)
    {
        max = arry[i];
    }
    else
        min = arry[i];
    avg = sum / str1.Length;
    if (i == str1.Length-1)
    {
        Console.WriteLine("数组最大值是{0},最小值是{1}，平均值是{2}，和为{3}", max, min, avg, sum);
    }
}

