using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tubes2_13519022
{
    public partial class Tubes2_13519022 : Form
    {
        private string sourcePath;
        private List<string[]> edges;
        private int edgesCount;
        private List<string> nodes;
        private int nodesCount;


        public Tubes2_13519022()
        {
            InitializeComponent();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {   
                string path = openFileDialog1.FileName;

                // Shows the path in Windows Forms
                labelFilename.Text = path;

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
                            this.edgesCount = Int32.Parse(f_list[0]);
                        }
                        catch (FormatException formatException)
                        {
                            throw formatException;
                        }

                        // Converts f_list into a list of [string, string]
                        this.edges = new List<string[]>();
                        for (int i = 1; i < f_list.Count; i++)
                        {
                            this.edges.Add(f_list[i].Split(' '));
                        }

                        // Create a set of nodes
                        this.nodes = new List<string>();
                        this.nodesCount = 0;
                        foreach (string[] edge in this.edges)
                        {
                            foreach (string node in edge)
                            {
                                if (!this.nodes.Contains(node))
                                {
                                    this.nodes.Add(node);
                                    this.nodesCount++;
                                }
                            }
                        }
                        this.nodes.Sort();

                        // Initialize MSAGL
                        Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");

                        // Create MSAGL graph, each edge should go both ways
                        try
                        {
                            foreach (string[] edge in this.edges)
                            {
                                graph.AddEdge(edge[0], edge[1]).Attr.ArrowheadAtTarget = Microsoft.Msagl.Drawing.ArrowStyle.None;
                            }
                        }
                        catch (IndexOutOfRangeException indexOutOfRangeException)
                        {
                            throw new IndexOutOfRangeException("At least one edge has less than two edges", indexOutOfRangeException);
                        }

                        // Construction complete, path is valid
                        this.sourcePath = path;

                        // Enables UI
                        radioButtonDFS.Enabled = true;
                        radioButtonBFS.Enabled = true;
                        radioButtonDFS.Checked = true;
                        gViewer1.Enabled = true;
                        comboBoxChooseAccount.Enabled = true;
                        comboBoxExploreFriendsWith.Enabled = true;
                        submitButton.Enabled = true;

                        // Adds the list of nodes to the comboboxes, and selects the first item
                        foreach (string node in this.nodes)
                        {
                            comboBoxChooseAccount.Items.Add(node);
                            comboBoxExploreFriendsWith.Items.Add(node);
                        }
                        comboBoxChooseAccount.SelectedIndex = 0;
                        comboBoxExploreFriendsWith.SelectedIndex = 0;

                        // Draw the graph
                        gViewer1.Graph = graph;

                    }
                    else // Throws an error, should never happen
                    {
                        throw new BFS.EmptyFileException("Empty file");
                    }

                }
                else // Throws an error, should never happen
                {
                    throw new BFS.FileNotFoundException("File does not exist");
                }
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            labelFriendRecommendation.Text = "Friend Recommendations for " + comboBoxChooseAccount.Text;
            //BFS.BFSGraph bFSGraph;
            BFS.BFSGraph bfsGraph = new BFS.BFSGraph(this.sourcePath);
            Dictionary<string, List<string>> FR = bfsGraph.FriendRecommendation(comboBoxChooseAccount.Text);
            labelFriendRecommendation.Text += "\n";
            foreach (KeyValuePair<string, List<string>> kv in FR)
            {
                // Console.WriteLine(kv.Key + " " + kv.Value[0]);
                labelFriendRecommendation.Text += kv.Key + " " + kv.Value[0] + "\n";
                labelFriendRecommendation.Text += kv.Value[1] + " " + kv.Value[2];

                //Console.Write(kv.Value[1] + " " + kv.Value[2]);
                for (int i = 3; i < kv.Value.Count; i++)
                {
                    labelFriendRecommendation.Text += ", " + kv.Value[i];
                    // Console.Write(", " + kv.Value[i]);
                }
                labelFriendRecommendation.Text += "\n";
                //Console.WriteLine();
            }

            List<string> traversedNodes = new List<string>();
            if (radioButtonDFS.Checked)
            {
                DepthFirstSearch.DFS dfs = new DepthFirstSearch.DFS(comboBoxChooseAccount.Text, comboBoxExploreFriendsWith.Text, this.sourcePath);
                dfs.Search();
                dfs.ShowResult();
                labelExploreFriends.Text = dfs.GetPathResult();

                // Creates a list of traversed nodes
                foreach (string node in dfs.GetPathNode())
                {
                    traversedNodes.Add(node);
                }
            }
            else
            {
                System.Collections.ArrayList EF = bfsGraph.ExploreFriends(comboBoxChooseAccount.Text, comboBoxExploreFriendsWith.Text);
                labelExploreFriends.Text = EF[0] + "\n" + EF[1];

                // Creates a list of traversed nodes
                foreach (string node in (List<string>)EF[2])
                {
                    traversedNodes.Add(node);
                }

            }

            // Recreates the graph
            Microsoft.Msagl.Drawing.Graph newGraph = new Microsoft.Msagl.Drawing.Graph();
            foreach (string[] edge in this.edges)
            {
                newGraph.AddEdge(edge[0], edge[1]).Attr.ArrowheadAtTarget = Microsoft.Msagl.Drawing.ArrowStyle.None;
            }
            foreach (Microsoft.Msagl.Drawing.Edge edge in newGraph.Edges)
            {
                for (int i = 0; i < (traversedNodes.Count - 1); i++)
                {
                    if ((edge.Source == traversedNodes[i]) && (edge.Target == traversedNodes[i + 1]))
                    {
                        edge.Attr.ArrowheadAtTarget = Microsoft.Msagl.Drawing.ArrowStyle.Normal;
                        edge.Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                        newGraph.FindNode(edge.Source).Attr.FillColor = Microsoft.Msagl.Drawing.Color.PaleGreen;
                        newGraph.FindNode(edge.Target).Attr.FillColor = Microsoft.Msagl.Drawing.Color.PaleGreen;
                    }
                    if ((edge.Source == traversedNodes[i + 1]) && (edge.Target == traversedNodes[i]))
                    {
                        edge.Attr.ArrowheadAtSource = Microsoft.Msagl.Drawing.ArrowStyle.Normal;
                        edge.Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                        newGraph.FindNode(edge.Source).Attr.FillColor = Microsoft.Msagl.Drawing.Color.PaleGreen;
                        newGraph.FindNode(edge.Target).Attr.FillColor = Microsoft.Msagl.Drawing.Color.PaleGreen;
                    }
                }
            }
            gViewer1.Graph = newGraph;
        }
    }
}
