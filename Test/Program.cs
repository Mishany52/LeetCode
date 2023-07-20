using System;
public class Solution
{
    public double Average(int[] salary) {
        double res = salary.Aggregate((acc, x) => acc + x);
        res = res - (salary.Min() + salary.Max()) / (salary.Length - 2);
        return res;
    
    }

    public static void Main()
    {
        int[] test = new int [] {48000,59000,99000,13000,78000,45000,31000,17000,39000,37000,93000,77000,33000,28000,4000,54000,67000,6000,1000,11000};
        Solution test1 = new Solution();
        Console.WriteLine(test1.Average(test));
    }

}