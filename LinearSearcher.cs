using System;
namespace ALevelProject
{
    public class LinearSearcher
    {
        ScreenManager screen = new ScreenManager();

        public void LinearSearch(string[] inputArray, int target)
        {
            screen.writeToProgramOutputHalf(screen.PrintStringArray(inputArray));
            screen.writeToExpHalf("This is the input array.");
            bool found = false;
            while (found == false)
            {
                string temp;
                for (int i = 0; i < inputArray.Length - 1; i++)
                {
                    temp = inputArray[i];
                    inputArray[i] = "[" + inputArray[i] + "]";
                    screen.writeToProgramOutputHalf(screen.PrintStringArray(inputArray));
                    inputArray[i] = temp;
                    screen.writeToExpHalf("Checking " + temp + " and comparing to " + target + ".");
                    if (Convert.ToInt32(temp) == target)
                    {
                        found = true;
                        screen.writeToExpHalf("Target found.");
                        break;
                    }
                }
                if (found == false)
                {
                    screen.writeToExpHalf("Target could not be found");
                }
                
            }
            

        }
        public LinearSearcher()
        {
        }
    }
}
