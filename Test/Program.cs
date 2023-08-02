using System;
using System.Numerics;

public class Solution
{
    public int LargestPerimeter(int[] nums) {
        int k = 3;
        // var test = returnFirstK(nums,k);
        // for (int i = k; i < nums.Length; i++)
        // {
            // if(nums[k-1] < nums[i]){
            //     break;
            // }
        // }
        reverse(nums,k-1);
        return 0;
    }

    public void swap(int[] sequince, int j, int i){
        (sequince[i], sequince[j]) = (sequince[j], sequince[i]);

    }
    public int[] k_permution_of_n(int[] nums, int k){
        int len = nums.Length;
        int i = k;
        for (; i < len && nums[i] < nums[k - 1]; i++)
        {
        }
        
        if(i < len){
            swap(nums, k-1, i);
            
        }
        else{
            reverse(nums,k-1);
            int j = k - 2;
            for (;j > 0 && nums[j] > nums[j+1]; j--)
            { 
            }
            if(j<0) 
                return new int[0];
            else{
                i = len - 1;
                for (; i > j; )
                {
                    if (nums[i] > nums[j])
                        break;
                    i--;
                }
                swap(nums, i, j);
                reverse(nums, j);
            }
        }
        return nums.Take(k).ToArray();
    }
    public void reverse(int[] sequince, int index){
        var shift = index + 1;
        int len = sequince.Length;
        for (int i = 0; i < (len-shift)/2; i++)
        {
            (sequince[shift+i], sequince[len-1-i]) = (sequince[len-1-i], sequince[shift+i]);
        }
    }
    public static void Main()
    {
        Solution test1 = new Solution();
        int[] n = new[]{0,1,2,3,4};
        int[] nums = n.Take(3).ToArray();
        for (int i = 0;  n.Length!=0 ; i++)
        {
            Console.WriteLine(nums);
            nums = test1.k_permution_of_n(n,3);
            
        }

    }

}