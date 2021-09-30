using System;
using System.Collections;
namespace ALevelProject
{
    class DijkstrasClass
    {
        ScreenManager screen = new ScreenManager();
        public Graph graph;
        ArrayList explored = new ArrayList();
        ArrayList unexplored = new ArrayList();

        public DijkstrasClass(Graph inputGraph)
        {
            this.graph = inputGraph;
        }

        public ArrayList findShortestPath(Node startingNode)
        {
            //Setup 

            foreach (Node node in graph.nodes)
            {
                unexplored.Add(node);
                node.distFromSource = 999999999;
                node.pathFromSource = "";
            }
            startingNode.distFromSource = 0;

            //Main loop 

            while (unexplored.Count != 0)
            {
                //Pick node
                Node currentNode = null;
                foreach (Node node in unexplored)
                {
                    if ((currentNode == null) || (node.distFromSource < currentNode.distFromSource))
                    {
                        currentNode = node;
                    }

                }
                unexplored.Remove(currentNode);
                explored.Add(currentNode);

                screen.writeToProgramOutputHalf("Node " + currentNode.name + " selected");

                if (currentNode == startingNode)
                {
                    screen.writeToExpHalf("Select start node");
                }
                else
                {
                    screen.writeToExpHalf("Select unexplored node with shortest path");
                }

                screen.writeToExpHalf("Expand all edges of selected node");
                // expand edges 
                foreach (Edge edge in graph.edges)
                {
                    if (edge.currentNode == currentNode)
                    {
                        screen.writeToProgramOutputHalf("Edge " + edge.name + " expanded");
                        if (edge.destNode.distFromSource > currentNode.distFromSource + edge.cost)
                        {
                            edge.destNode.distFromSource = currentNode.distFromSource + edge.cost;
                            edge.destNode.pathFromSource = currentNode.pathFromSource + ", " + edge.name;
                            //screen.writeToExpHalf(edge.destNode.name + " updated");
                        }
                    }
                }
                screen.writeToExpHalf("Update new shortest paths of neighbour nodes");
                screen.writeToExpHalf("Current Node: " + currentNode.name + ". Total cost of reaching this node: " + currentNode.distFromSource.ToString() +
                    ". Edges travelled to reach current node: " + currentNode.pathFromSource +".");

                screen.writeToProgramOutputHalf(currentNode.name + " " + currentNode.distFromSource.ToString() + " " + currentNode.pathFromSource);
                //update new shortest paths 

            }

            return explored;
        }


    }
}
