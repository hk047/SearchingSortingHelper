using System;
using System.Collections;

namespace ALevelProject
{
    public class InsertionSorter
    {
        ScreenManager screen = new ScreenManager();

        public int[] insertionSort(int[] inputArray)
        {
            for (int i = 1; i < inputArray.Length; i++)
            {
                screen.writeToProgramOutputHalf(screen.PrintArray(inputArray));
                screen.writeToExpHalf("Select element " + (i + 1).ToString() + " [" + inputArray[i] + "]" + " and insert in correct position in list: ");
                int currentNum = inputArray[i];
                int flag = 0;
                for (int j = i - 1; j >= 0 && flag != 1;)
                {
                    if (currentNum < inputArray[j])
                    {
                        inputArray[j + 1] = inputArray[j];
                        int temp = inputArray[j];
                        j--;
                        inputArray[j + 1] = currentNum;
                        screen.writeToProgramOutputHalf(screen.PrintArray(inputArray));
                        screen.writeToExpHalf(inputArray[j+1] + " is less than " + temp + " so their positions switch. " +
                            "\nKeep comparing " + inputArray[j+1] + " to the number before until is sorted.");
                    }
                    else flag = 1;
                }
                screen.writeToExpHalf("Array sorted up to element " + (i + 1).ToString());

            }
            return inputArray;
        }

       

        

        public InsertionSorter()
        {

        }
    }
}
