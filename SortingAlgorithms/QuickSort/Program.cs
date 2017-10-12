using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSort
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
            Console.WriteLine(string.Join(" ", QuickSorter(numbers)));
        }

        private static List<int> QuickSorter(List<int> numbers)
        {
            if(numbers.Count < 2)
            {
                return numbers;
            }
            int pivot = FindPivot(numbers);
            List<int> left = new List<int>();
            List<int> right = new List<int>();
            for (int i = 0; i < numbers.Count; i++)
            {
                if (i == pivot)
                {
                    continue;
                }
                if (numbers[i] < numbers[pivot]||(numbers[i]==numbers[pivot]&&i<pivot))
                {
                    left.Add(numbers[i]);
                }
                else
                {
                    right.Add(numbers[i]);
                }
            }
            List<int> result = new List<int>();
            result.AddRange(QuickSorter(left));
            result.Add(numbers[pivot]);
            result.AddRange(QuickSorter(right));
            return result;
        }

        private static int FindPivot(List<int> numbers)
        {
            var firstElement = numbers[0];
            var midElement = numbers[numbers.Count / 2];
            var endElement = numbers[numbers.Count - 1];
            if (firstElement <= midElement && midElement <= endElement)
            {
                return numbers.Count/2;
            }
            else if (midElement <= firstElement && firstElement <= endElement)
            {
                return 0;
            }
            else
            {
                return numbers.Count-1;
            }
        }
    }
}
