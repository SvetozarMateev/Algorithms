using System;
using System.Collections.Generic;
using System.Linq;


namespace InsertionSort
{
   public class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            for (int i = 1; i <= 100; i++)
            {
                numbers.Add(i);
            }

            numbers = numbers.OrderBy(x => Guid.NewGuid()).ToList();
            Console.WriteLine(string.Join(" ", InsertionSorter(numbers)));
        }

        private static List<int> InsertionSorter(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count-1; i++)
            {
                int position = i;
                while (position>=0&&numbers[position]>numbers[position+1])
                {
                    var oldNums = numbers[position];
                    var newNums = numbers[position + 1];
                    numbers[position] = newNums;
                    numbers[position + 1] = oldNums;
                    position--;
                }
            }
            return numbers;
        }
    }
}
