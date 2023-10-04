using System.Runtime.InteropServices;
public class Solution
{
    int k = 0;
    public int[] RemoveElement(int[] nums, int val)
    {
        nums = QuickSorted(nums, 0, nums.Length - 1, val);
        return nums;

    }
    public int[] QuickSorted(int[] array, int minIndex, int maxIndex, int val)
    {
        if (minIndex >= maxIndex)
        {
            return array;
        }
        int pivotIndex = getPivotIndex(array, minIndex, maxIndex, val);

        QuickSorted(array, minIndex, pivotIndex - 1, val);
        QuickSorted(array, pivotIndex + 1, maxIndex, val);
        return array;
    }

    private int getPivotIndex(int[] array, int minIndex, int maxIndex, int val)
    {
        int pivot = minIndex - 1;
        for (int i = minIndex; i <= maxIndex; i++)
        {
            if (array[i] < array[maxIndex])
            {
                pivot++;
                if (array[i] == val)
                {
                    k++;
                    array[i] = 0;
                }
                Swap(ref array[pivot], ref array[i]);
            }
        }
        pivot++;
        Swap(ref array[pivot], ref array[maxIndex]);

        return pivot;
    }
    private void Swap(ref int leftItem, ref int rightItem)
    {
        int temp = leftItem;
        leftItem = rightItem;
        rightItem = temp;
    }
}

class LeetCode
{
    // static double Variance(int[] arr){
    //     var averageValue = arr.Sum()/arr.Length;
    //     // var avarageValue = arr.Aggregate(0, (total, next) => total + next);
    //     double variance = 0;
    //     foreach (int item in arr)
    //     {
    //         variance += Math.Pow(item - averageValue,2);
    //     }
    //     return variance/(arr.Length-1);
    // }

    static void Main(string[] args)
    {
        Solution solve = new Solution();
        int[] test = { 17, 18, 5, 4, 6, 1 };
        // string one = "try to   next";
        // string two = "aaabbcc";
        int val = 5;
        var arr = solve.RemoveElement(test, val);
        // var arr = solve.RemoveElement(test, val);

        Console.WriteLine($"Sorted array: {string.Join(", ", arr)}");
        // foreach (var item in arr)
        // {
        //     Console.Write($"{item}, ");
        // }

        // int[] numArr = {1, 5, 2, 7, 1, 9, 3, 8, 5, 9};
        // Console.WriteLine(Variance(numArr));
        // Console.WriteLine(Math.Sqrt(Variance(numArr)));

    }
}