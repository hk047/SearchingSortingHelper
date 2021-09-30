using System;
using System.Collections.Generic;
namespace ALevelProject
{

    public class TreeNode
    {
        ScreenManager screen = new ScreenManager();
        private int key;
        private TreeNode left;
        private TreeNode right;

        public TreeNode(int input)
        {
            this.key = input;
            this.left = null;
            this.right = null;
        }

        public TreeNode(int[] input)
        {
            foreach (int num in input)
            {
                if (num == input[0])
                {
                    this.key = num;
                }
                else
                {
                    insert(num);
                }
            }
        }

        public int getKey()
        {
            return this.key;
        }

        public void SetLeft(TreeNode inputNode)
        {
            this.left = inputNode;
        }

        public TreeNode GetLeft()
        {
            return this.left;
        }

        public void SetRight(TreeNode inputNode)
        {
            this.right = inputNode;
        }

        public TreeNode GetRight()
        {
            return this.right;
        }

        public void DisplayTree()
        {
            if (left != null)
            {
                left.DisplayTree();
            }
            Console.WriteLine(key.ToString());
            if (right != null)
            {
                right.DisplayTree();
            }
        }
        public string getString()
        {
            string myString = "";
            if (left != null)
            {
                myString = myString + left.getString();
            }
            myString = myString + (" " + key.ToString() + " ");
            if (right != null)
            {
                myString = myString + right.getString();
            }
            return myString;
        }

        public bool HasLeft()
        {
            return (this.left != null);
        }

        public bool HasRight()
        {
            return (this.right != null);
        }


        public void insert(int item)
        {
            if (item > key)
            {
                if (HasRight())
                {
                    right.insert(item);
                }
                else
                {
                    right = new TreeNode(item);
                }
            }
            else
            {
                if (HasLeft())
                {
                    left.insert(item);
                }
                else
                {
                    left = new TreeNode(item);
                }
            }
        }

        public bool binarySearch(int item)
        {
            screen.writeToProgramOutputHalf(getString());
            screen.writeToExpHalf(("These are the inputted numbers, sorted.  The algorithm sorts them and then inserts them into a binary tree structure.\nTake the root of the tree: " + key.ToString()) + ", and compare to target item: " + item);

            if (key < item)
            {
                screen.writeToExpHalf("The target is larger than the root, so now we follow the right-hand side of the tree structure down the path where the numbers are greater than the current root.  First, we double check that " +
                    "there is a node beyond this one.");
                //explanation about traversing right
                if (HasRight())
                {
                    screen.writeToExpHalf("There is a node here.  Calling the binarySearch method recursively on the right hand branch of the root!");
                    //there exists a node on the right so call Binary search on that 
                    return right.binarySearch(item);
                }
            }
            else if (key > item)
            {
                screen.writeToExpHalf("The target is smaller than the root, so now we follow the left-hand side of the tree structure down the path where the numbers are less than the current root.  First, we double check that " +
                    "there is a node beyond this one.");
                if (HasLeft())
                {
                    screen.writeToExpHalf("There is a node here.  Calling the binarySearch method recursively on the left hand branch of the root!");
                    return left.binarySearch(item);
                }
            }
            else
            {
                screen.writeToExpHalf("We've found the target!");
                return true;
            }
            screen.writeToExpHalf("Search Failed. Your chosen target was not in the data set.");
            return false;
        }



    }





    public class BinarySearcher
    {
        public void PreOrder(Dictionary<int, int[]> inputTree, int start)
        {
            if (inputTree.ContainsKey(start))
            {
                Console.WriteLine(start);
                int[] branches = inputTree[start];

                for (int i = 0; i < branches.Length; i++)
                {
                    PreOrder(inputTree, branches[i]);
                }
            }
        }

        public void binarySearch(Dictionary<int, int[]> inputTree, int currentNode, int target) ///
        {
            int[] value;
            Console.WriteLine("Searching node " + currentNode.ToString());
            inputTree.TryGetValue(currentNode, out value);
            if (currentNode == target)
            {
                Console.WriteLine("Target found");
                return;
            }
            else if (value != null && currentNode > target)
            {
                foreach (int number in value)
                {
                    if (number < currentNode)
                    {
                        binarySearch(inputTree, number, target);                //Expand left node
                        return;
                    }
                }
            }
            else if (value != null && currentNode < target)                     //expand right node 
            {
                foreach (int number in value)
                {
                    if (number > currentNode)
                    {
                        binarySearch(inputTree, number, target);
                        return;
                    }
                }

            }
            Console.WriteLine("Search Failed");
        }


        public BinarySearcher()
        {
        }

    }



}
