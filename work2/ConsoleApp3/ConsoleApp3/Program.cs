// See https://aka.ms/new-console-template for more information
class Solution
{
    static void Main(String[] args)
    {
    int[] arry;
    arry=new int[101];
        int m = 2, tt = 0;
        while (tt < 101)
        {
            arry[1] = 1;
            for (int i = 1; i < arry.Length; i++)
                if (i % m == 0 && i != m)
                    arry[i] = 1;
            for(int i = 1; i < arry.Length; i++)
            {
                if (i > m && arry[i] == 0)
                {
                    m = i;
                    break;
                }
            }
            tt++;
        }
        for(int i = 1; i < arry.Length; i++)
        {
            if (arry[i] == 0)
                Console.WriteLine(i);
        }
    }
}
