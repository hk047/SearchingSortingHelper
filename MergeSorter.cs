using System;
using System.Diagnostics;
using System.Threading;
namespace ALevelProject
{
    public class MergeSorter
    {
        ScreenManager screen = new ScreenManager();
        private int counter;
        Stopwatch sw = new Stopwatch();

        public int[] MergeSort(int[] inputArray)
        {
            if (inputArray.Length <= 1)
            {
                return inputArray;
            }
            else
            {
                counter = 0;
                int[][] splitArray = Split(inputArray);
                int[] left = splitArray[0];
                int[] right = splitArray[1];
                int[] sortedArray = Merge(MergeSort(left), MergeSort(right));
                return sortedArray;
            }
        }

        //this is all about combining lists
        private int[] Merge(int[] left, int[] right)
        {
            if (left.Length == 0)
            {
                return right;
            }
            else if (right.Length == 0)
            {
                return left;
            }
            int leftMin = 0;
            int leftMax = left.Length - 1;
            int rightMin = 0;
            int rightMax = right.Length - 1;
            int[] temp = new int[(right.Length + left.Length)];     ///create array of however many 0s
            int tempPointer = 0;
            string explanation;
            screen.writeToExpHalf("Merge " + screen.PrintArray(left) + " and " + screen.PrintArray(right));
            while ((leftMin <= leftMax) && (rightMin <= rightMax))
            {
                if (left[leftMin] < right[rightMin])
                {
                    explanation = (left[leftMin].ToString() + " is less than " + right[rightMin].ToString() + " so pick " + left[leftMin].ToString() + " to add to the output array");
                    temp[tempPointer] = left[leftMin];
                    leftMin++;
                }
                else
                {
                    explanation = (left[leftMin].ToString() + " is greater than " + right[rightMin].ToString() + " so pick " + right[rightMin].ToString() + " to add to the output array");
                    temp[tempPointer] = right[rightMin];
                    rightMin++;
                }

                tempPointer++;
                //screen.writeToProgramOutputHalf(screen.PrintArray(temp, tempPointer));

                screen.writeToProgramOutputHalf(screen.PrintArray(left) + " & " + screen.PrintArray(right) + " --> " + screen.PrintArray(temp, tempPointer));
                screen.writeToExpHalf(explanation);
            }
            if (leftMin <= leftMax)
            {
                while (leftMin <= leftMax)
                {
                    temp[tempPointer] = left[leftMin];
                    leftMin++;
                    tempPointer++;
                    screen.writeToProgramOutputHalf(screen.PrintArray(left) + " & " + screen.PrintArray(right) + " --> " + screen.PrintArray(temp, tempPointer));
                    screen.writeToExpHalf("All elements from the right array have already been added, so add " + left[leftMin - 1].ToString() + " to output array");
                }
            }
            if (rightMin <= rightMax)
            {
                while (rightMin <= rightMax)
                {
                    temp[tempPointer] = right[rightMin];
                    rightMin++;
                    tempPointer++;
                    screen.writeToProgramOutputHalf(screen.PrintArray(left) + " & " + screen.PrintArray(right) + " --> " + screen.PrintArray(temp, tempPointer));
                    screen.writeToExpHalf("All elements from the left array have already been added, so add " + right[rightMin - 1].ToString() + " to output array");
                }
            }




            counter++;
            
            Console.ReadLine();
            return (temp);
        }



        //this is about splitting lists
        private int[][] Split(int[] inputArray)
        {
            //calculate midpoint and create arrays
            int midpoint = inputArray.Length / 2;
            int[] left = new int[midpoint];
            int[] right = new int[inputArray.Length - midpoint];
            //populate left array
            Array.ConstrainedCopy(inputArray, 0, left, 0, midpoint);

            //populate right array
            Array.ConstrainedCopy(inputArray, left.Length, right, 0, right.Length);

            int[][] splitArray = { left, right };

            screen.writeToProgramOutputHalf(screen.PrintArrayOfArrays(splitArray));
            screen.clearExpHalf();
            screen.writeToExpHalf("Size of the array is greater than 1, so split the array in half.");

            counter++;

            return splitArray;

        }


        public MergeSorter()
        {

        }
    }
}

