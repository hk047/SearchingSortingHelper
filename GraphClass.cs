using System;
using System.Collections.Generic;
using System.IO;


namespace ALevelProject
{
    class Node
    {
        public string name;
        public int distFromSource;
        public string pathFromSource;


        public Node(string name)
        {
            this.name = name;
        }


    }

    class Edge
    {
        public Node currentNode;
        public Node destNode;
        public int cost;
        public string name;

        public Edge(Node Node1, Node Node2, int cost)
        {
            this.currentNode = Node1;
            this.destNode = Node2;
            this.cost = cost;
            this.name = Node1.name + Node2.name + ", " + cost;
        }
    }

    class Graph
    {
        public Edge[] edges;
        public Node[] nodes;
        public string complexity;

        public Graph(Edge[] edges, Node[] nodes)
        {
            this.edges = edges;
            this.nodes = nodes;
        }


        public Node getNode(string nodeLetter)
        {
            foreach (Node node in nodes)
            {
                if (string.Compare((node.name).ToString(), nodeLetter, StringComparison.CurrentCulture) == 1)
                {
                    return node;
                }

            }
            return null;
        }

        public string getUserNode()
        {
            Console.Clear();
            Console.Write("[");
            for (int i = 0; i < nodes.Length-1; i++)
            {
                Console.Write(nodes[i].name + ", ");
            }
            int nodeArrayLength = nodes.Length;
            Console.WriteLine(nodes[nodeArrayLength-1].name + "]");
            Console.WriteLine("Please select a node from the displayed list");
            string userNode = Console.ReadLine();
            int c = 0;
            for (int i = 0; i < nodes.Length; i++)
            {
                if (nodes[i].name == userNode.ToUpper())
                {
                    c++;
                    break;
                }
                
            }

            if (c>0)
            {
                return userNode;
            }
            else
            {
                Console.WriteLine("Invalid input.");
                userNode = Console.ReadLine();
                return getUserNode();
            }
            
        }


        public void getEdgesFromNode(Node currentNode)
        {
            List<Edge> edgesFromNode = new List<Edge>();
             
            foreach (var edge in edges)
            {
                if (edge.currentNode == currentNode)
                {
                    Console.WriteLine(edge.name);
                }
            }
            
        }

        public static string PrintNodeArray(Node[] nodes)
        {
            string result = "";
            for (int i = 0; i < nodes.Length; i++)
            {
                result = result + nodes[i].name;
            }
            return result;
        }

        public void displayGraph(string complexity)
        {
            string lineReader;
            string preGraphDisplayMessage = "Press enter to view graph.  Zoom out until it is clear, " +
                "and zoom back in once you have finished viewing, then ensure that the window is minimised and remaximised.";
            if (complexity == "complex")
            {
                DirectoryInfo d = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
                FileInfo[] files = d.GetFiles("medium.rtf");
                FileInfo complexFile = files[0];
                Console.WriteLine(preGraphDisplayMessage);
                Console.ReadLine();
                lineReader = complexFile.OpenText().ReadToEnd();
                Console.WriteLine(lineReader);
                Console.ReadLine();
            }
            else if(complexity == "basic")
            {
                DirectoryInfo d = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
                FileInfo[] files = d.GetFiles("basic.rtf");
                FileInfo basicFile = files[0];
                Console.WriteLine(preGraphDisplayMessage);
                Console.ReadLine();
                lineReader = basicFile.OpenText().ReadToEnd();
                Console.WriteLine(lineReader);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("The graph could not be displayed.");
            }
        }

        public Graph(string complexityIdentifier)
        {
            if (complexityIdentifier == "basic")
            {
                Node nodeA = new Node("A");
                Node nodeB = new Node("B");
                Node nodeC = new Node("C");
                Node nodeD = new Node("D");
                Node nodeE = new Node("E");

                Edge AB = new Edge(nodeA, nodeB, 4);
                Edge AD = new Edge(nodeA, nodeD, 1);

                Edge BA = new Edge(nodeB, nodeA, 4);
                Edge BE = new Edge(nodeB, nodeE, 5);
                Edge BD = new Edge(nodeB, nodeD, 3);
                Edge BC = new Edge(nodeB, nodeC, 1);

                Edge CB = new Edge(nodeC, nodeB, 1);
                Edge CD = new Edge(nodeC, nodeD, 1);

                Edge DC = new Edge(nodeD, nodeC, 1);
                Edge DB = new Edge(nodeD, nodeB, 3);
                Edge DA = new Edge(nodeD, nodeA, 1);

                Edge EB = new Edge(nodeE, nodeB, 5);

                Node[] nodes = { nodeA, nodeB, nodeC, nodeD, nodeE };
                Edge[] edges = { AB, AD, BA, BE, BD, BC, CB, CD, DC, DB, DA, EB };

                this.edges = edges;
                this.nodes = nodes;
                this.complexity = "basic";

            }

            if(complexityIdentifier == "complex")
            {
                Node nodeA = new Node("A");
                Node nodeB = new Node("B");
                Node nodeC = new Node("C");
                Node nodeD = new Node("D");
                Node nodeE = new Node("E");
                Node nodeF = new Node("F");
                Node nodeG = new Node("G");
                Node nodeH = new Node("H");
                Node nodeI = new Node("I");

                Edge AB = new Edge(nodeA, nodeB, 4);
                Edge AI = new Edge(nodeA, nodeI, 3);

                Edge BC = new Edge(nodeB, nodeC, 1);
                Edge BI = new Edge(nodeB, nodeI, 2);
                Edge BA = new Edge(nodeB, nodeA, 4);

                Edge CD = new Edge(nodeC, nodeD, 3);
                Edge CI = new Edge(nodeC, nodeI, 3);
                Edge CB = new Edge(nodeC, nodeB, 1);

                Edge DE = new Edge(nodeD, nodeE, 1);
                Edge DC = new Edge(nodeD, nodeC, 3);

                Edge EG = new Edge(nodeE, nodeG, 5);
                Edge ED = new Edge(nodeE, nodeD, 1);

                Edge GH = new Edge(nodeG, nodeH, 4);
                Edge GF = new Edge(nodeG, nodeF, 2);
                Edge GE = new Edge(nodeG, nodeE, 5);

                Edge HI = new Edge(nodeH, nodeI, 1);
                Edge HG = new Edge(nodeH, nodeG, 5);

                Edge FI = new Edge(nodeF, nodeI, 8);
                Edge FG = new Edge(nodeF, nodeG, 2);

                Edge IA = new Edge(nodeI, nodeA, 3);
                Edge IB = new Edge(nodeI, nodeB, 2);
                Edge IC = new Edge(nodeI, nodeC, 3);
                Edge IH = new Edge(nodeI, nodeH, 1);
                Edge IF = new Edge(nodeI, nodeF, 8);

                Node[] nodes = { nodeA, nodeB, nodeC, nodeD, nodeE, nodeF, nodeG, nodeH, nodeI };
                Edge[] edges = { AB, AI, BC, BI, BA, CD, CI, CB, DE, DC, EG, ED, GH, GF, GE, HI, HG,
                    FI, FG, IA, IB, IC, IH, IF };

                this.edges = edges;
                this.nodes = nodes;
                this.complexity = "complex";


            }
        }

    }

    


}

