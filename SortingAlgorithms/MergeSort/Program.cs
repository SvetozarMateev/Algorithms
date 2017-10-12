using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            for (int i = 1; i <= 100; i++)
            {
                numbers.Add(i);
            }

            numbers = numbers.OrderBy(x => Guid.NewGuid()).ToList();
            Console.WriteLine(string.Join(" ", MergeSorter(numbers)));
        }

        private static List<int> MergeSorter(List<int> numbers)
        {
            if (numbers.Count < 2)
            {
                return numbers;
            }
            List<int> left = MergeSorter(numbers.Take(numbers.Count / 2).ToList());
            List<int> right = MergeSorter(numbers.Skip(numbers.Count / 2).ToList());
            return MergeSortedLists(left, right);
        }

        private static List<int> MergeSortedLists(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();
            int leftIndexer = 0;
            int rightIndexer = 0;
            while (leftIndexer<left.Count&&rightIndexer<right.Count)
            {
                if (left[leftIndexer] < right[rightIndexer])
                {
                    result.Add(left[leftIndexer]);
                    leftIndexer++;
                }
                else
                {
                    result.Add(right[rightIndexer]);
                    rightIndexer++;
                }
            }
            while (leftIndexer<left.Count)
            {
                result.Add(left[leftIndexer]);
                leftIndexer++;
            }
            while (rightIndexer < right.Count)
            {
                result.Add(right[rightIndexer]);
                rightIndexer++;
            }
            return result;
        }
    }
}
