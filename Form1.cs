using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Tubes2Stima;
using DepthFirstSearch;
using Microsoft.Msagl.Drawing;

namespace Tubes2Stima
{
    public partial class Form1 : Form
    {
        private string inputPath;
        private string[][] InputData;
        private List<string> PathNode;

        public Form1()
        {
            InitializeComponent();
        }
       private void LoadData()
        {
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
            //create the graph content 
           
            foreach (string[] line in InputData)
            {
                graph.AddEdge(line[0], line[1]).Attr.ArrowheadAtTarget = Microsoft.Msagl.Drawing.ArrowStyle.None;
            }

            gViewer1.Graph = graph;


        }
        private void LoadRoute()
        {
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
            //create the graph content 


            foreach (string[] line in InputData)
            {
                graph.AddEdge(line[0], line[1]).Attr.ArrowheadAtTarget = Microsoft.Msagl.Drawing.ArrowStyle.None;
            }
            foreach (Edge edge in graph.Edges)
            {
                for (int i = 0; i < this.PathNode.Count() - 1; i++)
                {
                    if (edge.Source == PathNode[i] && edge.Target == PathNode[i + 1])
                    {
                        edge.Attr.ArrowheadAtTarget = ArrowStyle.Normal;
                        edge.Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                        graph.FindNode(edge.Source).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                        graph.FindNode(edge.Target).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                    }
                    if (edge.Source == PathNode[i+1] && edge.Target == PathNode[i ] )
                    {
                        edge.Attr.ArrowheadAtSource = ArrowStyle.Normal;
                        edge.Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                        graph.FindNode(edge.Source).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                        graph.FindNode(edge.Target).Attr.Color = Microsoft.Msagl.Drawing.Color.Red;
                    }
                }

            }
            gViewer1.Graph = graph;
        }
        private void btn_browse_Click(object sender, EventArgs e)
        {
            Stream myStream;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if(openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if ((myStream = openFileDialog1.OpenFile()) != null) {
                    string strfilename = openFileDialog1.FileName;
                    //string filetext = File.ReadAllText(strfilename);
                    DataInput dataInput = new DataInput(strfilename);
                    string txt = "";
                    foreach(string line in dataInput.GetNodes())
                    {
                        txt += line + " ";
                        cmb_choose_acc.Items.Add(line);
                        cmb_explore.Items.Add(line);
                    }
                
                    lbl_filename.Text = strfilename;
                    this.inputPath = strfilename;
                    this.InputData = dataInput.GetInputs();
                    cmb_choose_acc.SelectedIndex = 0;
                    cmb_explore.SelectedIndex = 0;
                    LoadData();
 
                }
            }
        }

        private void rdr_DFS_CheckedChanged(object sender, EventArgs e)
        {
    
        }

        private void rdr_BFS_CheckedChanged(object sender, EventArgs e)
        {
     
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            lbl_text_friendrec.Text = "Friends Recommendations for " + cmb_choose_acc.Text;
            //BFS.BFSGraph bFSGraph;
            BFS.BFSGraph bfsGraph = new BFS.BFSGraph(this.inputPath);
            Dictionary<string, List<string>> FR = bfsGraph.FriendRecommendation(cmb_choose_acc.Text);
            string FriendRecommendTxt = "";
            foreach (KeyValuePair<string, List<string>> kv in FR)
            {
               // Console.WriteLine(kv.Key + " " + kv.Value[0]);
                FriendRecommendTxt += kv.Key + " " + kv.Value[0] +"\n";
                FriendRecommendTxt += kv.Value[1] + " " + kv.Value[2] ;

                //Console.Write(kv.Value[1] + " " + kv.Value[2]);
                for (int i = 3; i < kv.Value.Count; i++)
                {
                   FriendRecommendTxt += ", " + kv.Value[i];
                   // Console.Write(", " + kv.Value[i]);
                }
                FriendRecommendTxt += "\n";
                //Console.WriteLine();
            }
            richTextBox1.Text = FriendRecommendTxt;
            if (cmb_choose_acc.Text== cmb_explore.Text)
            {
                richTextBox2.Text = cmb_choose_acc.Text;
            }
            else
            {
                if (rdr_DFS.Checked == true)
                {
                    DFS dfs = new DFS(cmb_choose_acc.Text, cmb_explore.Text, this.inputPath);
                    dfs.Search();
                    dfs.ShowResult();
                    richTextBox2.Text = dfs.GetPathResult();
                    this.PathNode = dfs.GetPathNode();
                    SuspendLayout();
                    LoadRoute();
                    ResumeLayout();


                }
                else
                {
                    //bFSGraph = new BFS.BFSGraph(this.inputPath);
                    System.Collections.ArrayList EF = bfsGraph.ExploreFriends(cmb_choose_acc.Text.ToString(), cmb_explore.Text.ToString());
                    richTextBox2.Text = EF[0] + "\n" + EF[1];
                    this.PathNode = (List<string>)EF[2];
                    SuspendLayout();
                    LoadRoute();
                    ResumeLayout();
                }
            }
            

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void rtb_test_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cmb_choose_acc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmb_explore_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void gViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
