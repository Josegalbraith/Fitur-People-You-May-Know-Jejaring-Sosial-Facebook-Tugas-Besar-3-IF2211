
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lbl_title = new System.Windows.Forms.Label();
            this.lbl_graph_file = new System.Windows.Forms.Label();
            this.lbl_algorithm_opsi = new System.Windows.Forms.Label();
            this.rdr_DFS = new System.Windows.Forms.RadioButton();
            this.rdr_BFS = new System.Windows.Forms.RadioButton();
            this.btn_browse = new System.Windows.Forms.Button();
            this.lbl_filename = new System.Windows.Forms.Label();
            this.lbl_choose_acc = new System.Windows.Forms.Label();
            this.lbl_explore_with = new System.Windows.Forms.Label();
            this.btn_submit = new System.Windows.Forms.Button();
            this.cmb_choose_acc = new System.Windows.Forms.ComboBox();
            this.cmb_explore = new System.Windows.Forms.ComboBox();
            this.lbl_text_friendrec = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.gViewer1 = new Microsoft.Msagl.GraphViewerGdi.GViewer();
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
            this.rdr_DFS.Checked = true;
            this.rdr_DFS.Location = new System.Drawing.Point(120, 97);
            this.rdr_DFS.Margin = new System.Windows.Forms.Padding(2);
            this.rdr_DFS.Name = "rdr_DFS";
            this.rdr_DFS.Size = new System.Drawing.Size(46, 17);
            this.rdr_DFS.TabIndex = 3;
            this.rdr_DFS.TabStop = true;
            this.rdr_DFS.Text = "DFS";
            this.rdr_DFS.UseVisualStyleBackColor = true;
            this.rdr_DFS.CheckedChanged += new System.EventHandler(this.rdr_DFS_CheckedChanged);
            // 
            // rdr_BFS
            // 
            this.rdr_BFS.AutoSize = true;
            this.rdr_BFS.Location = new System.Drawing.Point(169, 97);
            this.rdr_BFS.Margin = new System.Windows.Forms.Padding(2);
            this.rdr_BFS.Name = "rdr_BFS";
            this.rdr_BFS.Size = new System.Drawing.Size(45, 17);
            this.rdr_BFS.TabIndex = 4;
            this.rdr_BFS.Text = "BFS";
            this.rdr_BFS.UseVisualStyleBackColor = true;
            this.rdr_BFS.CheckedChanged += new System.EventHandler(this.rdr_BFS_CheckedChanged);
            // 
            // btn_browse
            // 
            this.btn_browse.Location = new System.Drawing.Point(120, 62);
            this.btn_browse.Margin = new System.Windows.Forms.Padding(2);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(81, 25);
            this.btn_browse.TabIndex = 5;
            this.btn_browse.Text = "Browse File";
            this.btn_browse.UseVisualStyleBackColor = true;
            this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // lbl_filename
            // 
            this.lbl_filename.AutoSize = true;
            this.lbl_filename.Location = new System.Drawing.Point(209, 69);
            this.lbl_filename.Name = "lbl_filename";
            this.lbl_filename.Size = new System.Drawing.Size(0, 13);
            this.lbl_filename.TabIndex = 7;
            // 
            // lbl_choose_acc
            // 
            this.lbl_choose_acc.AutoSize = true;
            this.lbl_choose_acc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_choose_acc.Location = new System.Drawing.Point(45, 301);
            this.lbl_choose_acc.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_choose_acc.Name = "lbl_choose_acc";
            this.lbl_choose_acc.Size = new System.Drawing.Size(117, 19);
            this.lbl_choose_acc.TabIndex = 8;
            this.lbl_choose_acc.Text = "Choose Account :";
            // 
            // lbl_explore_with
            // 
            this.lbl_explore_with.AutoSize = true;
            this.lbl_explore_with.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_explore_with.Location = new System.Drawing.Point(45, 337);
            this.lbl_explore_with.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_explore_with.Name = "lbl_explore_with";
            this.lbl_explore_with.Size = new System.Drawing.Size(148, 19);
            this.lbl_explore_with.TabIndex = 9;
            this.lbl_explore_with.Text = "Explore Friends With : ";
            // 
            // btn_submit
            // 
            this.btn_submit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_submit.Location = new System.Drawing.Point(39, 383);
            this.btn_submit.Name = "btn_submit";
            this.btn_submit.Size = new System.Drawing.Size(63, 32);
            this.btn_submit.TabIndex = 10;
            this.btn_submit.Text = "Submit";
            this.btn_submit.UseVisualStyleBackColor = true;
            this.btn_submit.Click += new System.EventHandler(this.btn_submit_Click);
            // 
            // cmb_choose_acc
            // 
            this.cmb_choose_acc.FormattingEnabled = true;
            this.cmb_choose_acc.Location = new System.Drawing.Point(169, 302);
            this.cmb_choose_acc.Name = "cmb_choose_acc";
            this.cmb_choose_acc.Size = new System.Drawing.Size(66, 21);
            this.cmb_choose_acc.TabIndex = 11;
            this.cmb_choose_acc.SelectedIndexChanged += new System.EventHandler(this.cmb_choose_acc_SelectedIndexChanged);
            // 
            // cmb_explore
            // 
            this.cmb_explore.FormattingEnabled = true;
            this.cmb_explore.Location = new System.Drawing.Point(198, 335);
            this.cmb_explore.Name = "cmb_explore";
            this.cmb_explore.Size = new System.Drawing.Size(66, 21);
            this.cmb_explore.TabIndex = 12;
            this.cmb_explore.SelectedIndexChanged += new System.EventHandler(this.cmb_explore_SelectedIndexChanged);
            // 
            // lbl_text_friendrec
            // 
            this.lbl_text_friendrec.AutoSize = true;
            this.lbl_text_friendrec.Location = new System.Drawing.Point(45, 437);
            this.lbl_text_friendrec.Name = "lbl_text_friendrec";
            this.lbl_text_friendrec.Size = new System.Drawing.Size(0, 13);
            this.lbl_text_friendrec.TabIndex = 13;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.richTextBox1.Location = new System.Drawing.Point(36, 453);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(449, 208);
            this.richTextBox1.TabIndex = 14;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.richTextBox2.Location = new System.Drawing.Point(322, 301);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(163, 64);
            this.richTextBox2.TabIndex = 15;
            this.richTextBox2.Text = "";
            this.richTextBox2.TextChanged += new System.EventHandler(this.richTextBox2_TextChanged);
            // 
            // gViewer1
            // 
            this.gViewer1.ArrowheadLength = 10D;
            this.gViewer1.AsyncLayout = false;
            this.gViewer1.AutoScroll = true;
            this.gViewer1.BackwardEnabled = false;
            this.gViewer1.BuildHitTree = true;
            this.gViewer1.CurrentLayoutMethod = Microsoft.Msagl.GraphViewerGdi.LayoutMethod.UseSettingsOfTheGraph;
            this.gViewer1.EdgeInsertButtonVisible = true;
            this.gViewer1.FileName = "";
            this.gViewer1.ForwardEnabled = false;
            this.gViewer1.Graph = null;
            this.gViewer1.InsertingEdge = false;
            this.gViewer1.LayoutAlgorithmSettingsButtonVisible = true;
            this.gViewer1.LayoutEditingEnabled = true;
            this.gViewer1.Location = new System.Drawing.Point(39, 119);
            this.gViewer1.LooseOffsetForRouting = 0.25D;
            this.gViewer1.MouseHitDistance = 0.05D;
            this.gViewer1.Name = "gViewer1";
            this.gViewer1.NavigationVisible = true;
            this.gViewer1.NeedToCalculateLayout = true;
            this.gViewer1.OffsetForRelaxingInRouting = 0.6D;
            this.gViewer1.PaddingForEdgeRouting = 8D;
            this.gViewer1.PanButtonPressed = false;
            this.gViewer1.SaveAsImageEnabled = true;
            this.gViewer1.SaveAsMsaglEnabled = true;
            this.gViewer1.SaveButtonVisible = true;
            this.gViewer1.SaveGraphButtonVisible = true;
            this.gViewer1.SaveInVectorFormatEnabled = true;
            this.gViewer1.Size = new System.Drawing.Size(461, 176);
            this.gViewer1.TabIndex = 16;
            this.gViewer1.TightOffsetForRouting = 0.125D;
            this.gViewer1.ToolBarIsVisible = true;
            this.gViewer1.Transform = ((Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation)(resources.GetObject("gViewer1.Transform")));
            this.gViewer1.UndoRedoButtonsVisible = true;
            this.gViewer1.WindowZoomButtonPressed = false;
            this.gViewer1.ZoomF = 1D;
            this.gViewer1.ZoomWindowThreshold = 0.05D;
            this.gViewer1.Load += new System.EventHandler(this.gViewer1_Load);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 701);
            this.Controls.Add(this.gViewer1);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.lbl_text_friendrec);
            this.Controls.Add(this.cmb_explore);
            this.Controls.Add(this.cmb_choose_acc);
            this.Controls.Add(this.btn_submit);
            this.Controls.Add(this.lbl_explore_with);
            this.Controls.Add(this.lbl_choose_acc);
            this.Controls.Add(this.lbl_filename);
            this.Controls.Add(this.btn_browse);
            this.Controls.Add(this.rdr_BFS);
            this.Controls.Add(this.rdr_DFS);
            this.Controls.Add(this.lbl_algorithm_opsi);
            this.Controls.Add(this.lbl_graph_file);
            this.Controls.Add(this.lbl_title);
            this.Margin = new System.Windows.Forms.Padding(2);
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
        private System.Windows.Forms.Label lbl_filename;
        private System.Windows.Forms.Label lbl_choose_acc;
        private System.Windows.Forms.Label lbl_explore_with;
        private System.Windows.Forms.Button btn_submit;
        private System.Windows.Forms.ComboBox cmb_choose_acc;
        private System.Windows.Forms.ComboBox cmb_explore;
        private System.Windows.Forms.Label lbl_text_friendrec;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private Microsoft.Msagl.GraphViewerGdi.GViewer gViewer1;
    }
}