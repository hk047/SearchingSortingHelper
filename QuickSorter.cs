using System;
using System.Collections;


namespace ALevelProject
{
    public class QuickSorter
    {
        ScreenManager screen = new ScreenManager();
        private int counter = 0;

        public ArrayList QuickSort(ArrayList inputArrayList)
        {
            screen.writeToExpHalf("Now sort array: " + screen.PrintArrayList(inputArrayList));
            if (inputArrayList.Count <= 1)
            {
                screen.writeToExpHalf("This is an array of " + inputArrayList.Count + " or less item(s), therefore it must be 'sorted'");
                return inputArrayList;
            }
            else
            {
                ArrayList higher = new ArrayList();
                ArrayList lower = new ArrayList();

                int pivot = (int)inputArrayList[0];
                foreach (int number in inputArrayList.GetRange(1, inputArrayList.Count - 1))
                {
                    if (pivot > number)
                    {
                        lower.Add(number);
                    }
                    else
                    {
                        higher.Add(number);
                    }

                }
                ArrayList outputArrayList = new ArrayList();
                screen.writeToProgramOutputHalf("Main array: " + screen.PrintArrayList(inputArrayList));
                if (counter == 0)
                {
                    screen.writeToExpHalf("Pick the first number in the array as the pivot.  Find all the numbers smaller than the pivot, and all the numbers above the pivot, separating them into two separate arrays.");
                    counter++;
                }
                else
                {
                    screen.clearExpHalf();
                    screen.writeToExpHalf("Pick the first number in the array as the pivot.  Find all the numbers smaller than the pivot, and all the numbers above the pivot, separating them into two separate arrays.");
                }
                screen.writeToProgramOutputHalf("Lower array: " + screen.PrintArrayList(lower) + " \nPivot integer: " + pivot.ToString()
                + " \nHigher array: " + screen.PrintArrayList(higher));

                ArrayList sortedLower = QuickSort(lower);
                outputArrayList.AddRange(sortedLower);
                screen.writeToExpHalf("Insert sorted lower ArrayList : " + screen.PrintArrayList(sortedLower));

                outputArrayList.Add(pivot);
                screen.writeToExpHalf("Insert pivot : [" + pivot.ToString() + "]");

                ArrayList sortedHigher = QuickSort(higher);
                outputArrayList.AddRange(sortedHigher);
                screen.writeToExpHalf("Insert sorted higher ArrayList : " + screen.PrintArrayList(sortedHigher));

                screen.writeToProgramOutputHalf(screen.PrintArrayList(outputArrayList));
                screen.writeToExpHalf("");
                return outputArrayList;
            }


        }

        public QuickSorter()
        {

        }
    }
}
