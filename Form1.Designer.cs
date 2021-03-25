
namespace Tubes2Stima
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_title = new System.Windows.Forms.Label();
            this.lbl_graph_file = new System.Windows.Forms.Label();
            this.lbl_algorithm_opsi = new System.Windows.Forms.Label();
            this.rdr_DFS = new System.Windows.Forms.RadioButton();
            this.rdr_BFS = new System.Windows.Forms.RadioButton();
            this.btn_browse = new System.Windows.Forms.Button();
            this.rtb_test = new System.Windows.Forms.RichTextBox();
            this.lbl_filename = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_title.Location = new System.Drawing.Point(156, 6);
            this.lbl_title.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(236, 27);
            this.lbl_title.TabIndex = 0;
            this.lbl_title.Text = "People You May Know";
            // 
            // lbl_graph_file
            // 
            this.lbl_graph_file.AutoSize = true;
            this.lbl_graph_file.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_graph_file.Location = new System.Drawing.Point(35, 65);
            this.lbl_graph_file.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_graph_file.Name = "lbl_graph_file";
            this.lbl_graph_file.Size = new System.Drawing.Size(80, 19);
            this.lbl_graph_file.TabIndex = 1;
            this.lbl_graph_file.Text = "Graph File :";
            // 
            // lbl_algorithm_opsi
            // 
            this.lbl_algorithm_opsi.AutoSize = true;
            this.lbl_algorithm_opsi.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_algorithm_opsi.Location = new System.Drawing.Point(35, 95);
            this.lbl_algorithm_opsi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_algorithm_opsi.Name = "lbl_algorithm_opsi";
            this.lbl_algorithm_opsi.Size = new System.Drawing.Size(75, 19);
            this.lbl_algorithm_opsi.TabIndex = 2;
            this.lbl_algorithm_opsi.Text = "Algorithm :";
            // 
            // rdr_DFS
            // 
            this.rdr_DFS.AutoSize = true;
            this.rdr_DFS.Location = new System.Drawing.Point(120, 97);
            this.rdr_DFS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdr_DFS.Name = "rdr_DFS";
            this.rdr_DFS.Size = new System.Drawing.Size(46, 17);
            this.rdr_DFS.TabIndex = 3;
            this.rdr_DFS.TabStop = true;
            this.rdr_DFS.Text = "DFS";
            this.rdr_DFS.UseVisualStyleBackColor = true;
            // 
            // rdr_BFS
            // 
            this.rdr_BFS.AutoSize = true;
            this.rdr_BFS.Location = new System.Drawing.Point(169, 97);
            this.rdr_BFS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rdr_BFS.Name = "rdr_BFS";
            this.rdr_BFS.Size = new System.Drawing.Size(45, 17);
            this.rdr_BFS.TabIndex = 4;
            this.rdr_BFS.TabStop = true;
            this.rdr_BFS.Text = "BFS";
            this.rdr_BFS.UseVisualStyleBackColor = true;
            // 
            // btn_browse
            // 
            this.btn_browse.Location = new System.Drawing.Point(120, 62);
            this.btn_browse.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(81, 25);
            this.btn_browse.TabIndex = 5;
            this.btn_browse.Text = "Browse File";
            this.btn_browse.UseVisualStyleBackColor = true;
            this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // rtb_test
            // 
            this.rtb_test.Location = new System.Drawing.Point(48, 133);
            this.rtb_test.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rtb_test.Name = "rtb_test";
            this.rtb_test.Size = new System.Drawing.Size(437, 83);
            this.rtb_test.TabIndex = 6;
            this.rtb_test.Text = "";
            // 
            // lbl_filename
            // 
            this.lbl_filename.AutoSize = true;
            this.lbl_filename.Location = new System.Drawing.Point(209, 69);
            this.lbl_filename.Name = "lbl_filename";
            this.lbl_filename.Size = new System.Drawing.Size(0, 13);
            this.lbl_filename.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 292);
            this.Controls.Add(this.lbl_filename);
            this.Controls.Add(this.rtb_test);
            this.Controls.Add(this.btn_browse);
            this.Controls.Add(this.rdr_BFS);
            this.Controls.Add(this.rdr_DFS);
            this.Controls.Add(this.lbl_algorithm_opsi);
            this.Controls.Add(this.lbl_graph_file);
            this.Controls.Add(this.lbl_title);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Label lbl_graph_file;
        private System.Windows.Forms.Label lbl_algorithm_opsi;
        private System.Windows.Forms.RadioButton rdr_DFS;
        private System.Windows.Forms.RadioButton rdr_BFS;
        private System.Windows.Forms.Button btn_browse;
        private System.Windows.Forms.RichTextBox rtb_test;
        private System.Windows.Forms.Label lbl_filename;
    }
}