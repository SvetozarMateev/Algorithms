using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSort
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
            Console.WriteLine(string.Join(" ", BubbleSorter(numbers)));
        }

        private static List<int> BubbleSorter(List<int> numbers)
        {
            bool isSorted = false;
            while (isSorted==false)
            {
                isSorted = true;
                for (int i = 0; i < numbers.Count-1; i++)
                {
                    if (numbers[i] > numbers[i + 1])
                    {
                        var oldNum = numbers[i];
                        var newNum = numbers[i + 1];
                        numbers[i] = newNum;
                        numbers[i + 1] = oldNum;
                        isSorted = false;
                    }
                }
            }
            return numbers;
        }
    }
}
