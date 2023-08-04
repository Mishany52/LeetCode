using System.Reflection;
using System.Runtime.Intrinsics.X86;
using System.Collections;
using System;
using System.Numerics;
// Definition for a Node.
public class Node {
    public int val;
    public List<Node> children;

    public Node()
    {
    }

    public Node(int _val) {
        val = _val;
    }

    public Node(int _val,List<Node> _children) {
        val = _val;
        children = _children;
    }

    void tree(Node node){
        if(node.children.Count<0) return;
        for (int i = 0; i < node.children.Count; i++)
        {
            tree(node.children[i]);
        }
    }

    
}
public class Solution
{
    public IList<int> Preorder(Node root)
    {
        List<int> output = new List<int>();
        AddList(root, output);
        return output;
    }

    private void AddList(Node cur, List<int> output)
    {
        if (cur == null) return;
        output.Add(cur.val);
        if (cur.children != null)
        {
            for (int i = 0; i < cur.children.Count(); i++)
            {
                AddList(cur.children[i], output);
            }
        }
    }
    public static void Main(string[] args)
    {
        
        // Здесь вы можете создать свой пример дерева и вызвать метод Preorder
        // Пример:
        Node root = new Node(1, new List<Node>
        {
            new Node(3, new List<Node>
            {
                new Node(5),
            }),
            new Node(2, new List<Node> {new Node(6)}),
            new Node(4)
        });

        Solution solution = new Solution();
        IList<int> result = solution.Preorder(root);
        Console.WriteLine(string.Join(", ", result));
    }

}