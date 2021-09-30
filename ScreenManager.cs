using System;
using System.Collections.Generic;
using System.Collections;

namespace ALevelProject
{
    public class ScreenManager
    {

        private string[] expHalf;
        private string[] programOutputHalf;
        private int programOutputCounter;
        private int expCounter;


        public void writeToProgramOutputHalf(string message)
        {
            if (programOutputCounter >= programOutputHalf.Length - 1)
            {
                for (int i = 0; i < programOutputHalf.Length - 1; i++)
                {
                    if (programOutputHalf[i + 1] != null)
                    {
                        programOutputHalf[i] = programOutputHalf[i + 1];
                    }
                }
            }
            programOutputHalf[programOutputCounter] = message;
            if (programOutputCounter < programOutputHalf.Length - 1)
            {
                programOutputCounter++;
            }
        }


        public void writeToExpHalf(string message)
        {
            if (expCounter >= expHalf.Length - 1)
            {
                for (int i = 0; i < expHalf.Length - 1; i++)
                {
                    if (expHalf[i + 1] != null)
                    {
                        expHalf[i] = expHalf[i + 1];
                    }
                }
            }
            expHalf[expCounter] = message;
            if (expCounter < expHalf.Length - 1)
            {
                expCounter++;
            }
            ConsoleDisplay();
        }


        public void clearExpHalf()
        {
            for (int i = 0; i < expHalf.Length; i++)
            {
                expHalf[i] = "";
            }
            expCounter = 0;
        }


        public void ConsoleDisplay()
        {
            Console.Clear();
            foreach (string sentence in expHalf)
            {
                Console.WriteLine(sentence);
                Console.WriteLine();
            }
            string lineBreak = "";
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                lineBreak = lineBreak + "=";
            }
            Console.SetCursorPosition((Console.WindowWidth - lineBreak.Length) / 2, Console.WindowHeight / 2);
            Console.WriteLine(lineBreak);
            foreach (string line in programOutputHalf)
            {
                Console.WriteLine(line);
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        public string PrintArrayList(ArrayList inputList)
        {
            string result = "[";
            foreach (int number in inputList)
            {
                result = result + number + " ";
            }
            result = result + "]";
            return result;
        }

        public string PrintArrayOfArrays(int[][] inputset)
        {
            int inputsetLengthI = inputset.Length;

            string result = "[";
            for (int i = 0; i < inputset.Length - 1; i++)
            {
                int inputsetLengthJ = inputset[i].Length;
                for (int j = 0; j < inputset[i].Length; j++)
                {
                    result = result + inputset[i][j] + " ";
                }
            }
            for (int i = inputset.Length - 1; i < inputset.Length; i++)
            {
                int inputsetLengthJ = inputset[i].Length;
                for (int j = 0; j < inputset[i].Length - 1; j++)
                {
                    result = result + inputset[i][j] + " ";
                }
                result = result + inputset[i][inputsetLengthJ - 1];
            }
            result = result + "]";
            return result;
        }
        
        public string PrintArray(int[] inputset, int elements)
        {
            string result = "[";
            for (int i = 0; i <= elements-2; i++)
            {
                result = result + inputset[i] + " ";
            }
            result = result + inputset[elements-1] + "]";
            return result;
        }

        public string PrintArray(int[] inputset)
        {
            string result = "[";
            for (int i = 0; i <= inputset.Length - 2; i++)
            {
                result = result + inputset[i] + " ";
            }
            result = result + inputset[inputset.Length-1] + "]";
            return result;
        }

        public string PrintStringArray(string[] inputset)
        {
            string result = "[";
            for (int i = 0; i < inputset.Length; i++)
            {
                result = result + inputset[i] + " ";
            }
            result = result + "]";
            return result;
        }


        public ScreenManager()
        {
            int windowHeight = Console.WindowHeight;
            int halfHeight = (windowHeight/2);
            programOutputHalf = new string[halfHeight];
            expHalf = new string[halfHeight];
            programOutputCounter = 0;
        }
    }
}