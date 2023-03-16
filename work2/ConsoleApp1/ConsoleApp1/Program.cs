// See https://aka.ms/new-console-template for more information
class Fun
{
    static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());  
        for(int i = 2; i <= n;)
        {
            if (n % i == 0)
            {
                n = n / i;
                Console.WriteLine(i);
            }
            else
            {
                i++;
            }
        }
    }
}
