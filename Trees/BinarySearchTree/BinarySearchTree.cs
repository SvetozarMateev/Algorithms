using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BinarySearchTree
{
    class BinarySearchTree
    {
        private Node root;

        public BinarySearchTree()
        {

        }
        public BinarySearchTree(int[] arr)
        {
            //root = ContructRecursivelyFromCollection(arr, new Index() { Value = 0 }, arr[0], int.MinValue, int.MaxValue);
            root = ConstructIterativelyFromCollection(arr);
        }

        public void ConstructFromBinaryTree(Node root)
        {
            root = ConstructFromBinaryTreeCore(root);
        }

        public void ContructFromLinkedList(LinkedListNode<int> firstNode)
        {
            if (firstNode.Previous != null)
            {
                throw new Exception("Please provide the first element of the linked list");
            }

            root = ConstructFromLinkedListSimple(firstNode);
        }

        public void Insert(int number)
        {
            root = InsertCore(root, number);
        }

        public IEnumerable<int> Inorder()
        {
            return InorderCore(root);
        }

        public void Delete(int number)
        {
            root = DeleteCore(root, number);
        }

        private List<int> InorderCore(Node node)
        {
            var result = new List<int>();

            if (node == null)
            {
                return result;
            }

            result.AddRange(InorderCore(node.Left));
            result.Add(node.Key);
            result.AddRange(InorderCore(node.Right));

            return result;
        }

        private Node InsertCore(Node root, int number)
        {
            if (root == null)
            {
                return new Node() { Key = number };
            }

            if (number < root.Key)
            {
                root.Left = InsertCore(root.Left, number);
            }
            else if (number > root.Key)
            {
                root.Right = InsertCore(root.Right, number);
            }

            return root;
        }

        private Node DeleteCore(Node root, int number)
        {
            if (root == null)
            {
                return root;
            }

            if (number < root.Key)
            {
                root.Left = DeleteCore(root.Left, number);
            }
            else if (number > root.Key)
            {
                root.Right = DeleteCore(root.Right, number);
            }
            else
            {
                if (root.Left == null)
                {
                    return root.Right;
                }
                else if (root.Right == null)
                {
                    return root.Left;
                }
                else
                {
                    root.Key = MinValue(root.Right).Key;

                    root.Right = DeleteCore(root.Right, root.Key);
                }
            }

            return root;
        }

        private Node MinValue(Node node)
        {
            var result = node;

            while (result.Left != null)
            {
                result = result.Left;
            }

            return result;
        }

        private Node ContructRecursivelyFromCollection(int[] arr, Index prevIndex, int key, int min, int max)
        {
            if (arr.Length <= prevIndex.Value)
            {
                return null;
            }
            Node root = null;

            if (min < key && key < max)
            {
                root = new Node() { Key = key };
                prevIndex.Value++;

                if (prevIndex.Value < arr.Length)
                {
                    root.Left = ContructRecursivelyFromCollection(arr, prevIndex, arr[prevIndex.Value], min, key);
                }

                if (prevIndex.Value < arr.Length)
                {
                    root.Right = ContructRecursivelyFromCollection(arr, prevIndex, arr[prevIndex.Value], key, max);
                }
            }


            return root;
        }

        private Node ConstructIterativelyFromCollection(int[] arr)
        {
            var stack = new Stack<Node>();

            var root = new Node() { Key = arr[0] };

            stack.Push(root);

            for (int i = 1; i < arr.Length; i++)
            {
                Node temp = null;

                while (stack.Count > 0 && arr[i] > stack.Peek().Key)
                {
                    temp = stack.Pop();
                }

                if (temp != null)
                {
                    var newNode = new Node() { Key = arr[i] };
                    temp.Right = newNode;
                    stack.Push(temp.Right);
                }
                else
                {
                    var newNode = new Node() { Key = arr[i] };
                    temp = stack.Peek();
                    temp.Left = newNode;
                    stack.Push(newNode);
                }
            }

            return root;
        }

        private Node ConstructFromBinaryTreeCore(Node root)
        {
            var binaryTreeInorder = InorderCore(root).OrderBy(x => x).ToArray();

            PopulateDFS(root, binaryTreeInorder, new Index() { Value = 0 });

            return root;
        }

        private Node ConstructFromLinkedListSimple(LinkedListNode<int> node)
        {
            var length = node.List.Count;

            if (length == 0)
            {
                return null;
            }

            var middleElement = GetElementByIndex(node, length / 2);

            var treeNode = new Node() { Key = middleElement.Value };

            var previousSubList = TransferPreviousElementsToList(middleElement);
            var nextSubList = TransferNextElementsToList(middleElement);

            if (previousSubList.Count > 0)
            {
                treeNode.Left = ConstructFromLinkedListSimple(previousSubList.First);
            }

            if (nextSubList.Count > 0)
            {
                treeNode.Right = ConstructFromLinkedListSimple(nextSubList.First);
            }

            return treeNode;
        }

        private LinkedList<int> TransferPreviousElementsToList(LinkedListNode<int> node)
        {
            var list = new LinkedList<int>();

            var currentNode = node.Previous;

            while (currentNode != null)
            {
                list.AddFirst(new LinkedListNode<int>(currentNode.Value));
                currentNode = currentNode.Previous;
            }

            return list;
        }

        private LinkedList<int> TransferNextElementsToList(LinkedListNode<int> node)
        {
            var list = new LinkedList<int>();

            var currentNode = node.Next;

            while (currentNode != null)
            {
                list.AddLast(new LinkedListNode<int>(currentNode.Value));
                currentNode = currentNode.Next;
            }

            return list;
        }

        private LinkedListNode<int> GetElementByIndex(LinkedListNode<int> node, int index)
        {
            var count = 0;
            LinkedListNode<int> result = node;

            while (count < index)
            {
                result = result.Next;
                count++;
            }

            return result;
        }

        private void PopulateDFS(Node root, int[] sortedBinaryTree, Index currentIndex)
        {
            if (root.Left != null)
            {
                PopulateDFS(root.Left, sortedBinaryTree, currentIndex);
            }

            root.Key = sortedBinaryTree[currentIndex.Value];

            currentIndex.Value++;

            if (root.Right != null)
            {
                PopulateDFS(root.Right, sortedBinaryTree, currentIndex);
            }
        }
    }
}
