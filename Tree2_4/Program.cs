using System;
using System.Collections;
using System.Collections.Generic;
/*4. You are given a binary tree in which each node contains a value. 
             * Design an algorithm to print all paths which sum to a given value. 
             * Note that a path can start or end anywhere in the tree.
             * */
namespace Tree2_4
{
    public class Node
    {
        public int data;
        public Node left, right;

        public Node()
        {
            left = null;
            right = null;
        }
        public Node(int value)
        {
            data = value;
            left = null;
            right = null;
        }
    }

    public class BinaryTree
    {
        public Node root;

        public BinaryTree()
        {
            root = null;
        }

        public void PrintKPath(Node node, int sum, List<int> list)
        {
            if (node == null)
                return;

            // add current node to the path 
            list.Add(node.data);

            // check if there's any k sum path in the left sub-tree. 
            PrintKPath(node.left, sum, list);

            // check if there's any k sum path in the right sub-tree. 
            PrintKPath(node.right, sum, list);

            // check if there's any k sum path that terminates at this node 
            // Traverse the entire path as there can be negative elements too
            int f = 0;
            for (int j = list.Count - 1; j >= 0; j--)
            {
                f = f + Convert.ToInt32(list[j]);

                // If path sum is k, print the path 
                if (f == sum)
                    Print(list, j);
            }

            // Remove the last element from the path
            list.RemoveAt(list.Count - 1);
        }

        public void Print(List<int> list, int i)
        {
            for (int j = i; j < list.Count; j++)
                Console.Write(list[j] + " ");
            Console.WriteLine();
            Console.WriteLine("------");
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Node root = new Node(1);
            root.left = new Node(3);
            root.left.left = new Node(2);
            root.left.right = new Node(1);
            root.left.right.left = new Node(1);
            root.right = new Node(-1);
            root.right.left = new Node(4);
            root.right.left.left = new Node(1);
            root.right.left.right = new Node(2);
            root.right.right = new Node(5);
            root.right.right.left = new Node(1);
            root.right.right.right = new Node(2);
            root.right.right.right.left = new Node(-1);

            int k = 5;
            List<int> list = new List<int>();
            BinaryTree bt = new BinaryTree();
            bt.root = root;

            bt.PrintKPath(root, k, list);

        }
    }
}
