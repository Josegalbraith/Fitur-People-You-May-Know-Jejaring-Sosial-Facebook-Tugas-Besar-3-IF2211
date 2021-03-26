using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tubes2_13519022
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Tubes2_13519022());
        }
    }
}

namespace DepthFirstSearch
{
    class DataInput
    {
        private string[][] inputData;
        private ArrayList inputNodes;
        public DataInput(string path)
        {
            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            string[] lines = System.IO.File.ReadAllLines(path);
            string[][] inputList = new string[lines.GetLength(0) - 1][];
            for (int i = 1; i < lines.GetLength(0); i++)
            {
                inputList[i - 1] = lines[i].Split(' ');
            }

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
        private string DestinationNode;
        private int[][] AdjMatrix;
        private ArrayList NodeList;
        private string PathResult = "";
        private List<string> PathNode;

        public DFS(string Origin, string Destination, string path)
        {
            // Get Input Data
            DataInput dataInput = new DataInput(path);
            NodeList = dataInput.GetNodes();
            string[][] inputList = dataInput.GetInputs();
            PathNode = new List<string>();

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

        }
        public void Search()
        {
            // Search Iteration
            while (CurrentNode != DestinationNode && LivingNode.Count != 0)
            {
                VisitedNode.Add(CurrentNode);
                CurrentNode = LivingNode[0].ToString();
                LivingNode.RemoveAt(0);

                if (BranchCountPerNodes[BranchCountPerNodes.Count - 1] == 0)
                {
                    for (int j = 2; j < BranchCountPerNodes.Count; j++)
                    {
                        BranchCountPerNodes[BranchCountPerNodes.Count - j] -= 1;
                        if (BranchCountPerNodes[BranchCountPerNodes.Count - j] > 1)
                        {
                            break;
                        }

                    }
                }

                BranchCountPerNodes.Add(0);

                for (int i = AdjMatrix.Length - 1; i >= 0; i--)
                {
                    if (AdjMatrix[NodeList.IndexOf(CurrentNode)][i] == 1 && (!VisitedNode.Contains(NodeList[i])))
                    {
                        LivingNode.Insert(0, NodeList[i]);
                        BranchCountPerNodes[BranchCountPerNodes.Count - 1] += 1;
                    }
                }

            }
        }
        public bool CheckNodeExist(string Origin, string Dest, string path)
        {
            DataInput dataInput = new DataInput(path);
            ArrayList CheckDataList = dataInput.GetNodes();
            return (CheckDataList.Contains(Origin) && CheckDataList.Contains(Dest));
        }
        public void ShowResult()
        {
            // DFS Result
            if (CurrentNode == DestinationNode)
            {

                int NDegree = -1;
                for (int i = 0; i < BranchCountPerNodes.Count; i++)
                {
                    if (BranchCountPerNodes[i] > 0)
                    {
                        this.PathResult += VisitedNode[i].ToString() + " → ";
                        this.PathNode.Add(VisitedNode[i].ToString());
                        NDegree++;
                    }

                }
                if (NDegree == -1)
                {
                    this.PathResult += CurrentNode.ToString();
                    this.PathNode.Add(CurrentNode.ToString());
                }
                else if (NDegree % 10 == 0)
                {
                    this.PathResult += CurrentNode.ToString();
                    string DegreeTxt = NDegree.ToString() + "th-degree connection";
                    this.PathResult = DegreeTxt + "\n" + this.PathResult;
                    this.PathNode.Add(CurrentNode.ToString());
                }
                else if (NDegree % 10 == 1)
                {
                    this.PathResult += CurrentNode.ToString();
                    string DegreeTxt = NDegree.ToString() + "st-degree connection";
                    this.PathResult = DegreeTxt + "\n" + this.PathResult;
                    this.PathNode.Add(CurrentNode.ToString());
                }
                else if (NDegree % 10 == 2)
                {
                    this.PathResult += CurrentNode.ToString();
                    string DegreeTxt = NDegree.ToString() + "nd-degree connection";
                    this.PathResult = DegreeTxt + "\n" + this.PathResult;
                    this.PathNode.Add(CurrentNode.ToString());
                }
                else if (NDegree % 10 == 3)
                {
                    this.PathResult += CurrentNode.ToString();
                    string DegreeTxt = NDegree.ToString() + "rd-degree connection";
                    this.PathResult = DegreeTxt + "\n" + this.PathResult;
                    this.PathNode.Add(CurrentNode.ToString());
                }
                else
                {
                    this.PathResult += CurrentNode.ToString();
                    string DegreeTxt = NDegree.ToString() + "th-degree connection";
                    this.PathResult = DegreeTxt + "\n" + this.PathResult;
                    this.PathNode.Add(CurrentNode.ToString());
                }

            }
            else
            {
                this.PathResult += "Error!! Path Not Exist!";
            }
        }
        public string GetPathResult()
        {
            return this.PathResult;
        }
        public List<string> GetPathNode()
        {
            return this.PathNode;
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

        }
    }
}

namespace BFS
{
    [Serializable]
    public class FileNotFoundException : System.Exception
    {
        public FileNotFoundException() : base() { }
        public FileNotFoundException(string message) : base(message) { }
        public FileNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected FileNotFoundException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    [Serializable]
    public class EmptyFileException : System.Exception
    {
        public EmptyFileException() : base() { }
        public EmptyFileException(string message) : base(message) { }
        public EmptyFileException(string message, Exception inner) : base(message, inner) { }
        protected EmptyFileException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    /*
    Cara penggunaan namespace BFS:

    # Create object BFSGraph (ctor memerlukan 1 argumen: path ke file yang akan dijadikan BFS).

    BFS.BFSGraph bfsGraph = new BFS.BFSGraph(path); 

    # Siapkan container penampung hasil fungsi FriendRecommendation ataupun ExploreFriends, dan panggil kedua fungsi tersebut sesuai contoh.

    Dictionary<string, List<string>> FR = bfsGraph.FriendRecommendation(A);
    List<string> EF = bfsGraph.ExploreFriends(A, H);

    # Ambil hasil fungsi FriendRecommendation dari FR.

    Console.WriteLine("Friend Recommendations for A:");
    foreach (KeyValuePair<string, List<string>> kv in FR)
    {
        Console.WriteLine(kv.Key + " " + kv.Value[0]);
        Console.Write(kv.Value[1] + " " + kv.Value[2]);
        for (int i = 3; i < kv.Value.Count; i++)
        {
            Console.Write(", " + kv.Value[i]);
        }
    }

    # Ambil hasil fungsi ExploreFriends dari EF.

    Console.WriteLine("Nama akun: A dan H");
    Console.WriteLine(EF[0]);
    Console.WriteLine(EF[1]);

    */
    class BFSGraph
    {
        private string sourcePath;
        private int verticeCount;
        private Dictionary<string, int> nodeToIndex;
        private Dictionary<int, string> indexToNode;
        private bool[,] adjacencyMatrix;

        private bool close_flag;
        private string close_startNode;
        private int close_maxDegree;
        private List<string> close_closure;
        private List<List<string>> close_pathToClosedNodes;

        private bool search_flag;
        private string search_startNode;
        private string search_endNode;
        private int search_degree;
        private List<string> search_path;
        private List<List<string>> search_pathToSearchedNodes;

        public BFSGraph(string path)
        {
            // Set private flags
            this.close_flag = false;
            this.search_flag = false;

            // Check if the file exists
            if (System.IO.File.Exists(path))
            {
                // Reads the file into f_list
                List<string> f_list = new List<string>();
                using (System.IO.StreamReader f = new System.IO.StreamReader(path))
                {
                    string line;
                    while ((line = f.ReadLine()) != null)
                    {
                        f_list.Add(line);
                    }
                }

                // Check if the file is empty
                if (f_list.Count > 0)
                {
                    // Get # of nodes
                    try
                    {
                        this.verticeCount = Int32.Parse(f_list[0]);
                    }
                    catch (FormatException e)
                    {
                        throw e;
                    }

                    // Converts f_list into a list of [string, string]
                    List<string[]> vertice_list = new List<string[]>();
                    for (int i = 1; i < f_list.Count; i++)
                    {
                        vertice_list.Add(f_list[i].Split(' '));
                    }

                    // Map each node into a number and vice versa
                    this.nodeToIndex = new Dictionary<string, int>();
                    int index = 0;
                    foreach (string[] vertice in vertice_list)
                    {
                        foreach (string node in vertice)
                        {
                            if (!this.nodeToIndex.ContainsKey(node))
                            {
                                this.nodeToIndex.Add(node, index);
                                index++;
                            }
                        }
                    }
                    this.indexToNode = new Dictionary<int, string>();
                    foreach (KeyValuePair<string, int> kv in this.nodeToIndex)
                    {

                        this.indexToNode.Add(kv.Value, kv.Key);
                    }

                    // Creates adjacencyMatrix
                    this.adjacencyMatrix = new bool[this.nodeToIndex.Count, this.nodeToIndex.Count];
                    for (int i = 0; i < this.nodeToIndex.Count; i++)
                    {
                        for (int j = 0; i < this.nodeToIndex.Count; i++)
                        {
                            this.adjacencyMatrix[i, j] = false;
                        }
                    }

                    // A vertice should have two edges
                    try
                    {
                        foreach (string[] vertice in vertice_list)
                        {
                            this.adjacencyMatrix[nodeToIndex[vertice[0]], nodeToIndex[vertice[1]]] = true;
                            this.adjacencyMatrix[nodeToIndex[vertice[1]], nodeToIndex[vertice[0]]] = true;
                        }
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        throw new IndexOutOfRangeException("At least one vertice has less than two edges", e);
                    }

                    // Construction complete, path is valid
                    this.sourcePath = path;

                }
                else // Throws an error, should never happen
                {
                    throw new EmptyFileException("Empty file");
                }

            }
            else // Throws an error, should never happen
            {
                throw new FileNotFoundException("File does not exist");
            }

        }

        public void Close(string startNode)
        {
            // Does not need to re-close if this.close_flag = true and this.close_startNode = startNode
            if (!(this.close_flag && (this.close_startNode.Equals(startNode))))
            {
                // Set the flags
                this.close_startNode = startNode;
                this.close_maxDegree = -2;
                if (this.close_flag)
                {
                    this.close_closure.Clear();
                    for (int nodeIndex = 0; nodeIndex < this.close_pathToClosedNodes.Count; nodeIndex++)
                    {
                        this.close_pathToClosedNodes[nodeIndex].Clear();
                    }
                    this.close_pathToClosedNodes.Clear();
                }
                else
                {
                    this.close_closure = new List<string>();
                    this.close_pathToClosedNodes = new List<List<string>>();
                }
                this.close_flag = true;

                // Get the index of nodes from nodeToIndex
                int startIndex = this.nodeToIndex[startNode];

                // Initialize boolean array
                bool[] hasBeenQueued = new bool[this.nodeToIndex.Count];
                for (int nodeIndex = 0; nodeIndex < this.nodeToIndex.Count; nodeIndex++)
                {
                    hasBeenQueued[nodeIndex] = false;
                }

                // Initialize queue
                Queue<int> queue = new Queue<int>();
                if (this.ValidateNode(startNode))
                {
                    queue.Enqueue(startIndex);
                    hasBeenQueued[startIndex] = true;
                    this.close_closure.Add(this.indexToNode[startIndex]);
                    this.close_pathToClosedNodes.Add(new List<string>());
                    this.close_pathToClosedNodes[this.close_pathToClosedNodes.Count - 1].Add(this.indexToNode[startIndex]);
                }

                // Initialize BFS
                int i;
                while (queue.Count > 0)
                {
                    i = queue.Dequeue();
                    for (int j = 0; j < this.nodeToIndex.Count; j++)
                    {
                        if (this.adjacencyMatrix[i, j] && !hasBeenQueued[j])
                        {
                            queue.Enqueue(j);
                            hasBeenQueued[j] = true;
                            this.close_closure.Add(this.indexToNode[j]);
                            for (int k = 0; k < this.close_pathToClosedNodes.Count; k++)
                            {
                                if (this.close_pathToClosedNodes[k][this.close_pathToClosedNodes[k].Count - 1].Equals(this.indexToNode[i]))
                                {
                                    this.close_pathToClosedNodes.Add(new List<string>());
                                    foreach (string node in this.close_pathToClosedNodes[k])
                                    {
                                        this.close_pathToClosedNodes[this.close_pathToClosedNodes.Count - 1].Add(node);
                                    }
                                    this.close_pathToClosedNodes[this.close_pathToClosedNodes.Count - 1].Add(this.indexToNode[j]);
                                    break;
                                }
                            }
                        }
                    }
                }

                // Calculate the longest possible path, -2 if there's no path
                if (this.close_pathToClosedNodes.Count > 0)
                {
                    this.close_maxDegree = this.close_pathToClosedNodes[this.close_pathToClosedNodes.Count - 1].Count - 2;
                }
            }
        }

        public void Search(string startNode, string endNode)
        {
            // Does not need to re-search if this.search_flag = true, this.closure_startNode = startNode, and this.closure_endNode = endNode
            if (!(this.search_flag && (this.search_startNode.Equals(startNode)) && (this.search_endNode.Equals(endNode))))
            {
                // Only needs to iterate through

                // Set the flags!
                this.search_startNode = startNode;
                this.search_endNode = endNode;
                this.search_degree = -2;
                if (this.search_flag)
                {
                    this.search_path.Clear();
                    for (int nodeIndex = 0; nodeIndex < this.search_pathToSearchedNodes.Count; nodeIndex++)
                    {
                        this.search_pathToSearchedNodes[nodeIndex].Clear();
                    }
                    this.search_pathToSearchedNodes.Clear();
                }
                else
                {
                    this.search_path = new List<string>();
                    this.search_pathToSearchedNodes = new List<List<string>>();
                }
                this.search_flag = true;

                // Only needs to iterate through close_pathToClosedNodes if a closure of startNode has been made
                if (this.close_flag && (this.close_startNode.Equals(startNode)))
                {
                    foreach (List<string> path in this.close_pathToClosedNodes)
                    {
                        this.search_pathToSearchedNodes.Add(new List<string>());
                        foreach (string node in path)
                        {
                            this.search_pathToSearchedNodes[this.search_pathToSearchedNodes.Count - 1].Add(node);
                        }
                        if (path[path.Count - 1].Equals(endNode))
                        {
                            foreach (string node in path)
                            {
                                this.search_path.Add(node);
                                this.search_degree += 1;
                            }
                            break;
                        }
                    }

                }
                else
                {
                    // Get the index of nodes from nodeToIndex
                    int startIndex = this.nodeToIndex[startNode];
                    int endIndex = this.nodeToIndex[endNode];

                    // Initialize boolean array
                    bool[] hasBeenQueued = new bool[this.nodeToIndex.Count];
                    for (int nodeIndex = 0; nodeIndex < this.nodeToIndex.Count; nodeIndex++)
                    {
                        hasBeenQueued[nodeIndex] = false;
                    }

                    // Initialize queue
                    Queue<int> queue = new Queue<int>();
                    if (this.ValidateNode(startNode))
                    {
                        queue.Enqueue(startIndex);
                        hasBeenQueued[startIndex] = true;
                        this.search_pathToSearchedNodes.Add(new List<string>());
                        this.search_pathToSearchedNodes[this.search_pathToSearchedNodes.Count - 1].Add(this.indexToNode[startIndex]);
                    }

                    // You can never be too careful
                    bool isFound;
                    if (startIndex == endIndex)
                    {
                        isFound = true;
                    }
                    else
                    {
                        isFound = false;
                    }

                    // Initialize BFS
                    int i;
                    while ((!isFound) && (queue.Count > 0))
                    {
                        i = queue.Dequeue();
                        for (int j = 0; j < this.nodeToIndex.Count; j++)
                        {
                            if (this.adjacencyMatrix[i, j] && !hasBeenQueued[j])
                            {
                                queue.Enqueue(j);
                                hasBeenQueued[j] = true;
                                for (int k = 0; k < this.search_pathToSearchedNodes.Count; k++)
                                {
                                    if (this.search_pathToSearchedNodes[k][this.search_pathToSearchedNodes[k].Count - 1].Equals(this.indexToNode[i]))
                                    {
                                        this.search_pathToSearchedNodes.Add(new List<string>());
                                        foreach (string node in this.search_pathToSearchedNodes[k])
                                        {
                                            this.search_pathToSearchedNodes[this.search_pathToSearchedNodes.Count - 1].Add(node);
                                        }
                                        this.search_pathToSearchedNodes[this.search_pathToSearchedNodes.Count - 1].Add(this.indexToNode[j]);
                                        break;
                                    }
                                }
                                if (j == endIndex)
                                {
                                    isFound = true;
                                    break;
                                }
                            }
                        }
                    }

                    // If there's a match, set the results
                    if (isFound)
                    {
                        foreach (string node in this.search_pathToSearchedNodes[this.search_pathToSearchedNodes.Count - 1])
                        {
                            this.search_path.Add(node);
                            this.search_degree += 1;
                        }
                    }
                }

            }

        }

        public bool ValidateNode(string node)
        {
            return this.nodeToIndex.ContainsKey(node);
        }

        public List<string> GetSearchPath()
        {
            if (this.search_flag)
            {
                return this.search_path;
            }
            else
            {
                throw new NullReferenceException("You must initialize a search on the graph first (call BFSGraph.Search(startNode, endNode))");
            }
        }

        public string GetSearchPathString()
        {
            if (this.search_flag)
            {
                string s = "";
                bool skipFirstChar = false;
                foreach (string c in this.GetSearchPath())
                {
                    if (skipFirstChar)
                    {
                        s += " → ";
                    }
                    s += c;
                    skipFirstChar = true;
                }
                return s;
            }
            else
            {
                throw new NullReferenceException("You must initialize a search on the graph first (call BFSGraph.Search(startNode, endNode))");
            }
        }

        public string[] GetAllNthDegreeRelationNodes(int degree)
        {
            if (this.close_flag)
            {
                int arrayLength = 0;
                foreach (List<string> path in this.close_pathToClosedNodes)
                {
                    if ((path.Count - 2) == degree)
                    {
                        arrayLength += 1;
                    }
                }
                string[] nodes = new string[arrayLength];
                int i = 0;
                foreach (List<string> path in this.close_pathToClosedNodes)
                {
                    if ((path.Count - 2) == degree)
                    {
                        nodes[i] = path[path.Count - 1];
                        i++;
                    }
                }
                return nodes;
            }
            else
            {
                throw new NullReferenceException("You must close the graph first (call BFSGraph.Close(startNode))");
            }
        }

        public string Ordinal(int x)
        {
            int i = x % 10;
            int ii = (x / 10) % 10;
            string th;
            if (ii == 1)
            {
                th = "th";
            }
            else
            {
                if (i == 1)
                {
                    th = "st";
                }
                else if (i == 2)
                {
                    th = "nd";
                }
                else if (i == 3)
                {
                    th = "rd";
                }
                else
                {
                    th = "th";
                }
            }
            return x.ToString() + th;
        }

        // Fungsi Friend Recommendation.
        // Misalnya A di-recommend berteman dengan F dengan mutual friend B, C, D, dan H dengan mutual friend C, G
        // FriendRecommendation(A)
        // Output:
        // { "F" : ["(A → B → F, 1st Degree)", "3 Mutual Friends:", "B", "C", "D"],
        //   "H" : ["(A → C → H, 1st Degree)", "2 Mutual Friends:", "C", "G"]     }
        public Dictionary<string, List<string>> FriendRecommendation(string startNode)
        {
            Dictionary<string, List<string>> FR = new Dictionary<string, List<string>>();

            // Close the graph
            this.Close(startNode);

            // Get all 1st degree relation nodes
            string[] recommendedFriends = this.GetAllNthDegreeRelationNodes(1);

            // Get all 0th degree relation nodes
            string[] mutualFriends = this.GetAllNthDegreeRelationNodes(0);

            // Construct FR
            List<string> value;
            foreach (string recommendedFriend in recommendedFriends)
            {
                this.Search(startNode, recommendedFriend);
                value = new List<string>();
                value.Add("(" + this.GetSearchPathString() + ", 1st Degree)");
                foreach (string mutualFriend in mutualFriends)
                {
                    if ((this.adjacencyMatrix[this.nodeToIndex[startNode], this.nodeToIndex[mutualFriend]]) && (this.adjacencyMatrix[this.nodeToIndex[recommendedFriend], this.nodeToIndex[mutualFriend]]))
                    {
                        value.Add(mutualFriend);
                    }
                }
                string mutualFriendsMessage;
                if (value.Count == 2)
                {
                    mutualFriendsMessage = "1 Mutual Friend:";
                }
                else
                {
                    mutualFriendsMessage = (value.Count - 1).ToString() + " Mutual Friends:";
                }
                value.Insert(1, mutualFriendsMessage);
                FR.Add(recommendedFriend, value);

            }

            return FR;
        }

        // Fungsi Explore Friends.
        // Misalnya ingin diketahui hubungan antara A dengan H, dan mereka terhubung lewat A → B → F → H
        // ExploreFriends("A", "H")
        // Output:
        // ["2nd-degree connection", "A → B → F → H", ["A", "B", "F", "H"]]
        // Catatan: Jika tidak ada hubungan, outputnya otomatis:
        // ["Tidak ada jalur koneksi yang tersedia", "Anda harus memulai koneksi baru itu sendiri.", []]
        public ArrayList ExploreFriends(string startNode, string endNode)
        {
            this.Search(startNode, endNode);
            ArrayList EF = new ArrayList();
            if (this.search_degree < 0)
            {
                EF.Add("Tidak ada jalur koneksi yang tersedia");
                EF.Add("Anda harus memulai koneksi baru itu sendiri.");
                EF.Add(new List<string>());
            }
            else
            {
                EF.Add(Ordinal(this.search_degree) + "-degree connection");
                EF.Add(this.GetSearchPathString());
                EF.Add(this.GetSearchPath());
            }

            return EF;
        }
    }
}