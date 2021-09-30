using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;



namespace ALevelProject
{

    class Program
    {


        private static void DisplayMenu()
        {
            ScreenManager screen = new ScreenManager();

            Console.Clear();
            Console.WriteLine("-------------");
            Console.WriteLine("| Main menu |");
            Console.WriteLine("-------------");
            Console.WriteLine("\nChoose options: ");
            Console.WriteLine("1 - Mergesort.");
            Console.WriteLine("2 - Quicksort.");
            Console.WriteLine("3 - Bubblesort.");
            Console.WriteLine("4 - Insertion Sort.");
            Console.WriteLine("5 - Dijkstra's Algorithm.");
            Console.WriteLine("6 - Binary Search.");
            Console.WriteLine("7 - Linear Search.");
            Console.Write("\nPlease select a number: ");
            string result = Console.ReadLine();

            switch (result)
            {
                case "1":
                    //Console.Clear();
                    MergeSorter mergeSorter = new MergeSorter();
                    int[] unsortedMergeSortArray = TakeUserInputArray();
                    Console.WriteLine("Please maximise your window now.");
                    Console.ReadLine();
                    mergeSorter.MergeSort(unsortedMergeSortArray);
                    Console.ReadLine();
                    break;
                case "2":
                    Console.Clear();
                    QuickSorter quickSorter = new QuickSorter();
                    ArrayList unsortedArrayList = TakeUserInputArrayList();
                    Console.WriteLine("Please maximise your window now.");
                    screen.writeToProgramOutputHalf(screen.PrintArrayList(unsortedArrayList));
                    screen.clearExpHalf();
                    quickSorter.QuickSort(unsortedArrayList);
                    Console.ReadLine();
                    break;
                case "3":
                    Console.Clear();
                    BubbleSorter bubbleSorter = new BubbleSorter();
                    int[] unsortedBubbleSortArray = TakeUserInputArray();
                    Console.WriteLine("Please maximise your window now.");
                    Console.ReadLine();
                    bubbleSorter.bubbleSort(unsortedBubbleSortArray);
                    Console.ReadLine();
                    break;
                case "4":
                    Console.Clear();
                    InsertionSorter insertionSorter = new InsertionSorter();
                    int[] unsortedInsertionSortArray = TakeUserInputArray();
                    Console.WriteLine("Please maximise your window now.");
                    Console.ReadLine();
                    insertionSorter.insertionSort(unsortedInsertionSortArray);
                    Console.ReadLine();
                    break;
                case "5":
                    Console.Clear();
                    Graph firstGraph = new Graph(TakeUserInputGraph());
                    Console.WriteLine("Would you like to view the graph? (Y for yes, anything else for no.");
                    if (Console.ReadLine().ToUpper() == "Y")
                    {
                        firstGraph.displayGraph(firstGraph.complexity);
                    }
                    DijkstrasClass dijkstras = new DijkstrasClass(firstGraph);
                    Console.WriteLine("Please maximise your window now.");
                    Console.ReadLine();
                    dijkstras.findShortestPath(firstGraph.getNode(firstGraph.getUserNode()));
                    break;
                case "6":
                    Console.Clear();
                    TreeNode binarySearchTree = new TreeNode(TakeUserInputArrayBS());
                    Console.Write("Which number would you like to search this data set for? ");
                    int.TryParse(Console.ReadLine(), out int BinarySearchTarget);
                    Console.WriteLine("Please maximise your window now.");
                    Console.ReadLine();
                    binarySearchTree.DisplayTree();
                    binarySearchTree.binarySearch(BinarySearchTarget);
                    Console.ReadLine();
                    break;
                case "7":
                    Console.Clear();
                    LinearSearcher linearSearcher = new LinearSearcher();
                    string[] unsearchedLinearSearchArray = TakeUserInputLinearSearch();
                    Console.Write("Which number would you like to search this data set for? ");
                    int.TryParse(Console.ReadLine(), out int LinearSearchTarget);
                    Console.WriteLine("Please maximise your window now.");
                    Console.ReadLine();
                    linearSearcher.LinearSearch(unsearchedLinearSearchArray, LinearSearchTarget);
                    Console.ReadLine();
                    break;

                default:
                    ErrorMessage();
                    Console.ReadLine();
                    break;
            }


        }

        private static void ErrorMessage()
        {
            Console.WriteLine("Please try again. Invalid input.");
            Console.WriteLine("Press enter.");
        }



        public static int[] TakeUserInputArray()
        {
            bool successfulInput = false;
            int inputsize = 0;
            while (successfulInput == false)
            {
                Console.WriteLine("How many numbers would you like to sort? (8 or less)");
                inputsize = int.Parse(Console.ReadLine());
                if (inputsize >= 9)
                {
                    Console.WriteLine("Invalid input, try again.");
                }
                else
                {
                    successfulInput = true;
                }
            }
            int[] inputset = new int[inputsize];
            int i = 1;
            do
            {
                Console.WriteLine("Please enter data input No.{0}", i);
                if (!int.TryParse(Console.ReadLine(), out inputset[i - 1]))
                {
                    Console.WriteLine("Please type an integer.");
                    i--;
                }
                i++;
            } while (inputsize >= i);
            return inputset;
        }

        public static ArrayList TakeUserInputArrayList()
        {
            int inputsize = 0;
            bool successfulInput = false;
            while (successfulInput == false)
            {
                Console.WriteLine("How many numbers would you like to sort? (8 or less)");
                inputsize = int.Parse(Console.ReadLine());
                if (inputsize >= 9)
                {
                    Console.WriteLine("Invalid input, try again.");
                }
                else
                {
                    successfulInput = true;
                }
            }
            ArrayList inputset = new ArrayList();
            int tempInt;
            int i = 1;
            do
            {
                Console.WriteLine("Please enter data input No.{0}", i);
                if (!int.TryParse(Console.ReadLine(), out tempInt))
                {
                    Console.WriteLine("Please type an integer.");
                    i--;
                }
                else
                {
                    inputset.Add(tempInt);
                }
                i++;
            } while (inputsize >= i);
            return inputset;
        }

        public static string TakeUserInputGraph()
        {
            Console.Write("Please type the complexity of graph you'd like to use: \nBasic or Complex: ");
            string answer = Console.ReadLine();
            while (answer != "basic" && answer != "complex")
            {
                Console.WriteLine("Invalid input. Please type your answer again: ");
                answer = Console.ReadLine();
            }
            return answer;
        }

        public static string[] TakeUserInputLinearSearch()
        {
            Console.WriteLine("How many numbers would you like to search through?");
            int.TryParse(Console.ReadLine(), out int inputsize);
            string[] inputset = new string[inputsize];
            int i = 1;
            do
            {
                Console.WriteLine("Please enter data input No.{0}", i);
                if (!int.TryParse(Console.ReadLine(), out int temp))
                {
                    Console.WriteLine("Please type an integer.");
                    i--;
                }
                inputset[i - 1] = temp.ToString();
                i++;
            } while (inputsize >= i);
            return inputset;
        }

        public static int[] TakeUserInputArrayBS()
        {
            int inputsize = 0;
            while (true)
            {
                Console.WriteLine("How many numbers would you like to search through? (up to 20)");
                inputsize = int.Parse(Console.ReadLine());
                if (inputsize < 21)
                {
                    break;
                }
            }
            int[] inputset = new int[inputsize];
            int i = 1;
            do
            {
                Console.WriteLine("Please enter data input No.{0}", i);
                if (!int.TryParse(Console.ReadLine(), out inputset[i - 1]))
                {
                    Console.WriteLine("Please type an integer.");
                    i--;
                }
                i++;
            } while (inputsize >= i);
            return inputset;
        }

            static void Main(string[] args)
            {

                while (true)
                {
                    DisplayMenu();
                }

            }
        }
    }

