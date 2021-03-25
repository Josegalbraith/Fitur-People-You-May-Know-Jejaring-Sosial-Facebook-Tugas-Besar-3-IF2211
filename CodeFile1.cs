using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tubes2Stima;

namespace DepthFirstSearch
{
    class DataInput
    {
        private string[][] inputData;
        private ArrayList inputNodes;
        public DataInput()
        {
            string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"../../test.txt");

            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            string[] lines = System.IO.File.ReadAllLines(path);
            string[][] inputList = new string[lines.GetLength(0) - 1][];
            for (int i = 1; i < lines.GetLength(0); i++)
            {
                inputList[i - 1] = lines[i].Split(' ');
            }

            /* Display the file contents by using a foreach loop. */

            //Console.WriteLine("Contents of WriteLines2.txt = ");
            //foreach (string[] line in inputList)
            //{
            //    Console.WriteLine("({0},{1})", line[0], line[1]);
            //}
            this.inputData = inputList;
            // Identifying Nodes in Input 
            ArrayList NodeList = new ArrayList();
            foreach (string[] row in inputList)
            {
                foreach (string col in row)
                {
                    if (!(NodeList.Contains(col)))
                    {
                        NodeList.Add(col);
                    }
                }
            }

            // Sort The Nodes in Input 
            NodeList.Sort();
            //Console.WriteLine("Sorted Node");
            //foreach (string line in NodeList)
            //{
            //    Console.Write(line + " ");

            //}
            this.inputNodes = NodeList;
        }
        public ArrayList GetNodes()
        {
            return this.inputNodes;
        }
        public string[][] GetInputs()
        {
            return this.inputData;
        }
    }
    class DFS
    {
        private List<int> BranchCountPerNodes;
        private ArrayList VisitedNode;
        private string CurrentNode;
        private ArrayList LivingNode;
        private string OriginNode;
        private string DestinationNode ;
        private int[][] AdjMatrix;
        private ArrayList NodeList;
        public DFS(string Origin, string Destination)
        {
            // Get Input Data
            DataInput dataInput = new DataInput();
            NodeList = dataInput.GetNodes();
            string[][] inputList = dataInput.GetInputs();

            // Make The Adjacency Matrix
            AdjMatrix = AdjacencyMatrixMaker(NodeList, inputList);

            // Initialize Variables And Containers
            BranchCountPerNodes = new List<int>();
            VisitedNode = new ArrayList();
            LivingNode = new ArrayList();
            OriginNode = Origin;
            DestinationNode = Destination;

            // Initialize Origin Node
            CurrentNode = OriginNode;

            // Initialize Living Nodes
            BranchCountPerNodes.Add(0);
            for (int i = AdjMatrix.Length - 1; i >= 0; i--)
            {   
                if (AdjMatrix[NodeList.IndexOf(CurrentNode)][i] == 1 && (!VisitedNode.Contains(NodeList[i])))
                {
                    LivingNode.Insert(0, NodeList[i]);
                    BranchCountPerNodes[BranchCountPerNodes.Count - 1] += 1;
                }
            }
            VisitedNode.Add(CurrentNode);
            CurrentNode = LivingNode[0].ToString();
            LivingNode.RemoveAt(0);
        }
        public void Search()
        {
            // Search Iteration
            while (CurrentNode != DestinationNode && LivingNode.Count != 0)
            {
                ////debug
                //console.writeline();
                //console.writeline("current node: " + currentnode+" with index : "+ nodelist.indexof(currentnode));
                //console.writeline("visited node: ");
                //for (int i = 0; i < visitednode.count; i++)
                //{
                //    console.write(visitednode[i] + " ");

                //}
                //console.writeline();
                //console.writeline("living node: ");
                //for (int i = 0; i < livingnode.count; i++)
                //{
                //    console.write(livingnode[i] + " ");

                //}
                //console.writeline();
                //console.writeline();
                //// ####
                for (int j = 1; j < BranchCountPerNodes.Count; j++)
                {
                    if (BranchCountPerNodes[BranchCountPerNodes.Count - j] - 1 >= 0)
                    {
                        BranchCountPerNodes[BranchCountPerNodes.Count - j] -= 1;
                        break;
                    }
                }

                BranchCountPerNodes.Add(0);

                for (int i = AdjMatrix.Length - 1; i >= 0; i--)
                {   //debug
                    //Console.WriteLine("Checking Node : "+ NodeList[i]);
                    if (AdjMatrix[NodeList.IndexOf(CurrentNode)][i] == 1 && (!VisitedNode.Contains(NodeList[i])))
                    {
                        LivingNode.Insert(0, NodeList[i]);
                        BranchCountPerNodes[BranchCountPerNodes.Count - 1] += 1;
                    }
                }
                VisitedNode.Add(CurrentNode);
                CurrentNode = LivingNode[0].ToString();
                LivingNode.RemoveAt(0);


            }
        }
        static bool CheckNodeExist(string Origin,string Dest)
        {
            DataInput dataInput = new DataInput();
            ArrayList CheckDataList = dataInput.GetNodes();
            return (CheckDataList.Contains(Origin) && CheckDataList.Contains(Dest));
        }
        public void ShowResult()
        {
            // DFS Result
            if (CurrentNode == DestinationNode)
            {
                // DEBUG
                //Console.WriteLine();
                //Console.WriteLine("Result");

                //for (int i = 0; i < VisitedNode.Count; i++)
                //{
                //    Console.Write(VisitedNode[i] + " ");

                //}
                //Console.WriteLine();

                //for (int i = 0; i < BranchCountPerNodes.Count; i++)
                //{
                //    Console.Write(BranchCountPerNodes[i] + " ");

                //}

                Console.WriteLine();
                Console.WriteLine("Path To Destination : ");
                for (int i = 0; i < BranchCountPerNodes.Count; i++)
                {
                    if (BranchCountPerNodes[i] > 0)
                    {
                        Console.Write(VisitedNode[i] + "-");
                    }

                }
                Console.Write(CurrentNode);
                Console.WriteLine();

            }
            else
            {
                Console.WriteLine("Error!! Path Not Exist!");
            }
        }
        private static int[][] AdjacencyMatrixMaker(ArrayList NodeList, string[][] inputList)
        {
            int[][] AdjMatrix = new int[NodeList.Count][];
            for (int i = 0; i < NodeList.Count; i++)
            {
                AdjMatrix[i] = new int[NodeList.Count];
                for (int j = 0; j < NodeList.Count; j++)
                {
                    AdjMatrix[i][j] = 0;
                }

            }
            foreach (string[] line in inputList)
            {

                int i = NodeList.IndexOf(line[0]);
                int j = NodeList.IndexOf(line[1]);
                AdjMatrix[i][j] = 1;
                AdjMatrix[j][i] = 1;
            }
            return AdjMatrix;
            // DEBUG
            //Console.WriteLine();
            //Console.WriteLine("Adjacency Matrix");
            //for (int i = 0; i < AdjMatrix.Length; i++)
            //{
            //    for (int j = 0; j < AdjMatrix[i].Length; j++)
            //        Console.Write(AdjMatrix[i][j] + " ");
            //    Console.WriteLine();
            //}
            //Console.WriteLine();
            //Console.WriteLine("Adjacency Triangle");
            //for (int i = 0; i < AdjMatrix.Length; i++)
            //{
            //    for (int j = 0; j <i; j++)
            //        Console.Write(AdjMatrix[i][j] + " ");
            //    Console.WriteLine();
            //}
        }
        
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            //Console.Write("Enter a Origin Node  - ");
            //String Origin = Console.ReadLine();
            //Console.WriteLine();
            //Console.Write("Enter a Dest Node  - ");
            //String Dest = Console.ReadLine();
            //Console.WriteLine();
            //if (CheckNodeExist(Origin, Dest))
            //{
            //    DFS SearchPath = new DFS(Origin, Dest);
            //    SearchPath.Search();
            //    SearchPath.ShowResult();

            //}
            //else
            //{
            //    Console.WriteLine("Input Node Not Exist!");
            //}

        }
    }
}
