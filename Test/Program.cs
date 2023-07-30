using System;
using System.Numerics;
public class Solution
{
    public int ArraySign(int[] nums) {
        int negative = 0;
        bool zero = false;
        foreach (int item in nums)
        {
            if (item < 0) {
                negative++;
            }
            else if (item == 0){
                zero = true;
            }
        }
        if (negative%2 != 0 && !zero)
        {
            return -1;
        }
        else if (zero){
            return 0;
        }
        else return 1;
    }
    public int signFunc(long product){
        if(product > 0) return 1;
        else if (product < 0) return -1;
        else return 0;
    }
    public int Way(int x1, int y1, int x2, int y2)
    {
        return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
    }
    public static void Main()
    {
        Solution test1 = new Solution();
        int[] points = new int[] {-1,0,1};
        Console.WriteLine(test1.ArraySign(points));

    }

}