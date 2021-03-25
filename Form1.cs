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

namespace Tubes2Stima
{
    public partial class Form1 : Form
    {
        private string inputPath;
        public Form1()
        {
            InitializeComponent();
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
                    rtb_test.Text = txt ;
                    lbl_filename.Text = strfilename;
                    this.inputPath = strfilename;
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
            lbl_text_friendrec.Text = "Friends Recommendations for " ;
            richTextBox1.Text = cmb_choose_acc.Text +"\n"+cmb_explore.Text;
            DFS dfs = new DFS(cmb_choose_acc.Text, cmb_explore.Text, this.inputPath);
            dfs.Search();
            dfs.ShowResult();
            richTextBox2.Text = dfs.GetPathResult()+" Hey";
            


            
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
    }
}
