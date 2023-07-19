using System;
public class Solution
{

    public int CountOdds(int low, int high)
    {

        if ((low % 2 == 1) || (high % 2 == 1))
        {
            return (high - low) / 2 + 1;
        }
        else if (low % 2 == 1 && high % 2 == 1)
        {
            return (high - low) / 2 - 1;
        }
        else
        {
            return (high - low) / 2;
        }

    }


    public static void Main()
    {
        Solution test1 = new Solution();
        Console.WriteLine(test1.CountOdds(0, 10));
    }

}