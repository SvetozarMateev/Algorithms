using System;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var bst = new BinarySearchTree();
            var linkedList = new System.Collections.Generic.LinkedList<int>(new int[] { 1, 2, 3, 4, 5, 6, 8, 9 });
            bst.ContructFromLinkedList(linkedList.First);

            Console.WriteLine(String.Join(", ", bst.Inorder()));
        }
    }
}
