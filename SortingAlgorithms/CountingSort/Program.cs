using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingSort
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            for (int i = -50; i <= 50; i++)
            {
                numbers.Add(i);
            }

            numbers = numbers.OrderBy(x => Guid.NewGuid()).ToList();
            int minNumber = -50;
            int maxNumber = 50;
            Console.WriteLine(string.Join(" ", CountingSorter(numbers,minNumber,maxNumber)));

        }

        private static List<int> CountingSorter(List<int> numbers, int minNumber, int maxNumber)
        {
            int[] helperArr = new int[maxNumber - minNumber + 1];
            for (int i = 0; i < numbers.Count; i++)
            {
                helperArr[numbers[i]-minNumber]++;
            }
            List<int> result = new List<int>();
            for (int i = 0; i < helperArr.Length; i++)
            {
                for (int a = 0; a < helperArr[i]; a++)
                {
                    result.Add(i+minNumber);
                }
            }
            return result;
        }
    }
}
