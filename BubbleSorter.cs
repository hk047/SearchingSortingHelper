using System;
namespace ALevelProject
{
    public class BubbleSorter
    {
        ScreenManager screen = new ScreenManager();

        public int[] bubbleSort(int[] inputset)
        {
            screen.writeToProgramOutputHalf(screen.PrintArray(inputset));
            screen.writeToExpHalf("This is the unsorted array of numbers.");
            int temp = 0;
            int inputsize = inputset.Length;
            for (int i = 0; i < inputsize - 1; i++)
            {
                for (int j = 0; j < inputsize - (i + 1); j++)
                {

                    string exp1 = "Picking " + inputset[j] + " and comparing it to " + inputset[j+1];
                    string swap = "[" + inputset[j] + "] & [" + inputset[j+1] + "] " + "--> ["+ inputset[j+1]+ "] & [" + inputset[j] + "]";
                    string successfulSwap = inputset[j] + " is greater than " + inputset[j + 1] + " so they switch positions in the array";
                    screen.writeToExpHalf(exp1);
                    if (inputset[j] > inputset[j + 1])
                    {
                        temp = inputset[j];
                        inputset[j] = inputset[j + 1];
                        screen.writeToProgramOutputHalf(swap);
                        inputset[j + 1] = temp;
                        screen.writeToProgramOutputHalf(screen.PrintArray(inputset));
                        screen.writeToExpHalf(successfulSwap); 
                    }
                    else
                    {
                        string unsuccessfulSwap = inputset[j] + " is not greater than " + inputset[j + 1] + " so they do not switch positions in the array";
                        screen.writeToProgramOutputHalf("still: " + screen.PrintArray(inputset));
                        screen.writeToExpHalf(unsuccessfulSwap);
                    }
                }
            }
            return inputset;
        }

   
        public BubbleSorter()
        {
        }
    }
}
