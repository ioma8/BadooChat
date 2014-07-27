namespace WindowsFormsApplication1
{
    partial class Form3
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
            this.components = new System.ComponentModel.Container();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showWebProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writeMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFromThisListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pagesCount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.statusText = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pagesCount)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.ContextMenuStrip = this.contextMenuStrip1;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(199, 472);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showWebProfileToolStripMenuItem,
            this.writeMessageToolStripMenuItem,
            this.removeFromThisListToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(175, 70);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // showWebProfileToolStripMenuItem
            // 
            this.showWebProfileToolStripMenuItem.Name = "showWebProfileToolStripMenuItem";
            this.showWebProfileToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.showWebProfileToolStripMenuItem.Text = "Show web profile";
            this.showWebProfileToolStripMenuItem.Click += new System.EventHandler(this.showWebProfileToolStripMenuItem_Click);
            // 
            // writeMessageToolStripMenuItem
            // 
            this.writeMessageToolStripMenuItem.Name = "writeMessageToolStripMenuItem";
            this.writeMessageToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.writeMessageToolStripMenuItem.Text = "Write message";
            this.writeMessageToolStripMenuItem.Click += new System.EventHandler(this.writeMessageToolStripMenuItem_Click);
            // 
            // removeFromThisListToolStripMenuItem
            // 
            this.removeFromThisListToolStripMenuItem.Name = "removeFromThisListToolStripMenuItem";
            this.removeFromThisListToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.removeFromThisListToolStripMenuItem.Text = "Remove from this list";
            this.removeFromThisListToolStripMenuItem.Click += new System.EventHandler(this.removeFromThisListToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(217, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(219, 39);
            this.button1.TabIndex = 1;
            this.button1.Text = "search online users";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(217, 194);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(369, 225);
            this.textBox1.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(217, 425);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(175, 59);
            this.button2.TabIndex = 3;
            this.button2.Text = "write message for all";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(214, 178);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "message";
            // 
            // pagesCount
            // 
            this.pagesCount.Location = new System.Drawing.Point(539, 23);
            this.pagesCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.pagesCount.Name = "pagesCount";
            this.pagesCount.Size = new System.Drawing.Size(47, 20);
            this.pagesCount.TabIndex = 5;
            this.pagesCount.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(442, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "pages of search";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(217, 65);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(218, 39);
            this.button3.TabIndex = 7;
            this.button3.Text = "remove old (written)\r\nand disabled users";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(214, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Status:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // statusText
            // 
            this.statusText.AutoSize = true;
            this.statusText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusText.Location = new System.Drawing.Point(260, 107);
            this.statusText.Name = "statusText";
            this.statusText.Size = new System.Drawing.Size(38, 13);
            this.statusText.TabIndex = 9;
            this.statusText.Text = "ready";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 493);
            this.Controls.Add(this.statusText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pagesCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form3";
            this.Text = "searcher";
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pagesCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown pagesCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showWebProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem writeMessageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeFromThisListToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label statusText;
    }
}