using System;
public class Solution
{

    public string LongestCommonPrefix(string[] strs)
    {
        string res = "";

        for (int i = 0; i < strs[0].Length; i++)
        {
            foreach (string s in strs)
            {
                if(i == s.Length || s[i] != strs[0][i]){
                    return res;
                }
                
            }
            res += strs[0][i];
        }
        return res;

    }

    public static void Main()
    {
        string[] test = new string[3] {"c","acc","ccc"};
        Solution test1 = new Solution();
        Console.WriteLine(test1.LongestCommonPrefix(test));
    }

}