using System;
using System.Linq;

namespace CountingSort
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter array size: ");
            String inputSize = Console.ReadLine();
            int arraySize = int.Parse(inputSize);

            Random r = new Random();
            int[] integers = new int[arraySize];
            for (int i = 0; i < integers.Length; i++)
                integers[i] = r.Next(0, 9);
            int[] comparisonArray = Program.comparisonCountingSort(integers);
            int[] distributionArray = Program.distributionCountingSort(integers);
            Program.showArrays(integers, comparisonArray, "ComparisonSort");
            Program.showArrays(integers, distributionArray, "DistributionSort");
        }

        public static int[] comparisonCountingSort(int[] inputArray) //Excecution time for 1 million values = +1 hour 
        {
            int range = inputArray.Length;
            int[] count = new int[range];
            int[] outputArray = new int[range];
            for (int i = 0; i < range-1; i++) 
                for(int j = i+1; j < range; j++)
                {
                    if (inputArray[i] < inputArray[j])
                        count[j] = count[j] + 1;
                    else
                        count[i] = count[i] + 1;
                }
            for(int l = 0; l < range; l++)
                outputArray[count[l]] = inputArray[l]; 

            return outputArray;
        }

        public static int[] distributionCountingSort(int[] inputArray) //Excecution time for 1 million values = +1 hour
        {
            int maxValue = inputArray.Max();
            int[] countArray = new int[inputArray.Length];
            int[] outputArray = new int[inputArray.Length];
            for (int i = 0; i < inputArray.Length; i++)
                countArray[inputArray[i]]++;

            for (int j = 1; j < inputArray.Length; j++)
                countArray[j] = countArray[j-1] + countArray[j];

            for (int i = 0; i < inputArray.Length; i++)
            {
                int position = countArray[inputArray[i]];
                outputArray[position-1] = inputArray[i];
                countArray[inputArray[i]] = countArray[inputArray[i]] - 1;
            }
            return outputArray;
        }

        public static void showArrays(int[] inputArray, int[] sortedArray, String sortType) 
        {
            Console.WriteLine("\n\n ------------" + sortType + "\n");
            Console.WriteLine("\n Generated array: ");
            for (int i = 0; i < inputArray.Length; i++)
                Console.Write("\t" + inputArray[i]);

            Console.WriteLine("\n Sorted array: ");

            for (int i = 0; i < sortedArray.Length; i++)
                Console.Write("\t" + sortedArray[i]);
        }
    }
}
