using System;
using System.Collections.Generic;

namespace GraphAlgorithms
{
    public class Program
    {
        public static void Main()
        {
            var startNode = int.Parse(Console.ReadLine());

            var graph = new Dictionary<int, HashSet<int>>
            {
                { 1, new HashSet<int>() { 2, 3 } },
                { 2, new HashSet<int>() { 1, 4 } },
                { 3, new HashSet<int>() { 1, 5, 6 } },
                { 4, new HashSet<int>() { 2, 7 } },
                { 5, new HashSet<int>() { 3, 7, 8, 6 } },
                { 6, new HashSet<int>() { 3, 5 } },
                { 7, new HashSet<int>() { 4, 5 } },
                { 8, new HashSet<int>() { 5, 9, 10 } },
                { 9, new HashSet<int>() { 8, 10 } },
                { 10, new HashSet<int>() { 8, 9 } }
            };

            Console.WriteLine("Depth-First Search: " + DFS(graph, startNode));
            Console.WriteLine("Breadth-First Search: " + BFS(graph, startNode));
            Console.WriteLine("Depth-First Search Recursive: " + DFSRecursive(graph, startNode, new bool[graph.Count], new List<string>()));
        }

        public static string DFS(Dictionary<int, HashSet<int>> graph, int startNode)
        {
            var visited = new bool[graph.Count];
            var answer = new List<int>();
            var stack = new Stack<int>();

            stack.Push(startNode);

            while (stack.Count > 0)
            {
                var currNode = stack.Pop();
                if (visited[currNode - 1])
                {
                    continue;
                }

                visited[currNode - 1] = true;
                answer.Add(currNode);

                foreach (int neighbour in graph[currNode])
                {
                    stack.Push(neighbour);
                }
            }
            return string.Join(", ", answer);
        }

        public static string DFSRecursive(Dictionary<int, HashSet<int>> graph, int currNode, bool[] visited, List<string> answer)
        {
            visited[currNode - 1] = true;
            answer.Add(currNode.ToString());

            foreach (int neighbour in graph[currNode])
            {
                if (visited[neighbour - 1] == false)
                {
                    DFSRecursive(graph, neighbour, visited, answer);
                }
            }

            return string.Join(", ", answer);
        }

        public static string BFS(Dictionary<int, HashSet<int>> graph, int startNode)
        {
            var visited = new bool[graph.Count];
            var answer = new List<int>();
            var queue = new Queue<int>();

            queue.Enqueue(startNode);

            while (queue.Count > 0)
            {
                var currNode = queue.Dequeue();
                if (visited[currNode - 1])
                {
                    continue;
                }

                visited[currNode - 1] = true;
                answer.Add(currNode);

                foreach (int neighbour in graph[currNode])
                {
                    queue.Enqueue(neighbour);
                }
            }
            return string.Join(", ", answer);
        }
    }

}
