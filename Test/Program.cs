using System;
public class Solution
{

    public bool IsValid(string s)
    {
        char curr = s[0];
        char expected = '\0';
        bool res = false;
        Stack<char> c = new Stack<char>();
        if (s.Length % 2 == 1 ){
            return res;
        }
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(' || s[i] == '{' || s[i] == '['){
                c.Push(s[i]);
            }
            else {
                if(c.Count == 0){
                    return false;
                }
                curr = s[i];
                if (curr == ')')
                {
                    expected = '(';
                }
                if (curr == ']')
                {
                    expected = '[';
                }
                if (curr == '}')
                {
                    expected = '{';
                }
                if(expected == c.Pop()){
                    res = true;
                }
                else{
                    return false;
                }
            }
        }
        if (c.Count != 0){
            return false;
        }
        return res;
    }

    public static void Main()
    {
        string test = new string("[[[]");
        Solution test1 = new Solution();
        Console.WriteLine(test1.IsValid(test));
    }

}