using System;
using System.Collections.Generic;
using System.Linq;


namespace SelectionSort
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
            Console.WriteLine(string.Join(" ", SelectionSorter(numbers)));
        }

        private static List<int> SelectionSorter(List<int> numbers)
        {          
            for (int i = 0; i < numbers.Count; i++)
            {
                int best = i;
                for (int j = i; j < numbers.Count; j++)
                {
                    if (numbers[best] > numbers[j])
                    {
                        best = j;
                    }
                }
                if (numbers[best] != numbers[i])
                {
                    var oldValue = numbers[i];
                    var newNums = numbers[best];
                    numbers[i] = newNums;
                    numbers[best] = oldValue;
                }
            }
            return numbers;
        }
    }
}
