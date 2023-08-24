namespace reTrack.WinForm
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label = new Label();
            lblLastUpdate = new Label();
            lblUpVotesPostName = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            panel1 = new Panel();
            lblUpVotesNum = new Label();
            panel2 = new Panel();
            lblDownVotesPostName = new Label();
            lblDownVotesNum = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            panel3 = new Panel();
            lblMostPostsNum = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            lblMostPostsAuthor = new Label();
            btnRun = new Button();
            btnStop = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            timer1 = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(28, 107);
            label.Margin = new Padding(6, 0, 6, 0);
            label.Name = "label";
            label.Size = new Size(139, 32);
            label.TabIndex = 2;
            label.Text = "Last Update";
            // 
            // lblLastUpdate
            // 
            lblLastUpdate.AutoSize = true;
            lblLastUpdate.Location = new Point(243, 107);
            lblLastUpdate.Margin = new Padding(6, 0, 6, 0);
            lblLastUpdate.Name = "lblLastUpdate";
            lblLastUpdate.Size = new Size(0, 32);
            lblLastUpdate.TabIndex = 3;
            // 
            // lblUpVotesPostName
            // 
            lblUpVotesPostName.AutoSize = true;
            lblUpVotesPostName.Location = new Point(134, 102);
            lblUpVotesPostName.Name = "lblUpVotesPostName";
            lblUpVotesPostName.Size = new Size(0, 32);
            lblUpVotesPostName.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(37, 102);
            label4.Margin = new Padding(6, 0, 6, 0);
            label4.Name = "label4";
            label4.Size = new Size(60, 32);
            label4.TabIndex = 5;
            label4.Text = "Title";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(37, 158);
            label5.Margin = new Padding(6, 0, 6, 0);
            label5.Name = "label5";
            label5.Size = new Size(72, 32);
            label5.TabIndex = 6;
            label5.Text = "Votes";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(37, 21);
            label6.Margin = new Padding(6, 0, 6, 0);
            label6.Name = "label6";
            label6.Size = new Size(325, 32);
            label6.TabIndex = 7;
            label6.Text = "Post With The Most Up Votes";
            // 
            // panel1
            // 
            panel1.Controls.Add(lblUpVotesPostName);
            panel1.Controls.Add(lblUpVotesNum);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(109, 179);
            panel1.Margin = new Padding(6);
            panel1.Name = "panel1";
            panel1.Size = new Size(996, 213);
            panel1.TabIndex = 8;
            // 
            // lblUpVotesNum
            // 
            lblUpVotesNum.AutoSize = true;
            lblUpVotesNum.Location = new Point(134, 158);
            lblUpVotesNum.Name = "lblUpVotesNum";
            lblUpVotesNum.Size = new Size(0, 32);
            lblUpVotesNum.TabIndex = 8;
            // 
            // panel2
            // 
            panel2.Controls.Add(lblDownVotesPostName);
            panel2.Controls.Add(lblDownVotesNum);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label9);
            panel2.Location = new Point(1159, 179);
            panel2.Margin = new Padding(6);
            panel2.Name = "panel2";
            panel2.Size = new Size(941, 213);
            panel2.TabIndex = 9;
            // 
            // lblDownVotesPostName
            // 
            lblDownVotesPostName.AutoSize = true;
            lblDownVotesPostName.Location = new Point(221, 102);
            lblDownVotesPostName.Margin = new Padding(6, 0, 6, 0);
            lblDownVotesPostName.Name = "lblDownVotesPostName";
            lblDownVotesPostName.Size = new Size(0, 32);
            lblDownVotesPostName.TabIndex = 4;
            // 
            // lblDownVotesNum
            // 
            lblDownVotesNum.AutoSize = true;
            lblDownVotesNum.Location = new Point(221, 158);
            lblDownVotesNum.Margin = new Padding(6, 0, 6, 0);
            lblDownVotesNum.Name = "lblDownVotesNum";
            lblDownVotesNum.Size = new Size(0, 32);
            lblDownVotesNum.TabIndex = 8;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(37, 21);
            label7.Margin = new Padding(6, 0, 6, 0);
            label7.Name = "label7";
            label7.Size = new Size(357, 32);
            label7.TabIndex = 7;
            label7.Text = "Post With The Most Down Votes";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(37, 158);
            label8.Margin = new Padding(6, 0, 6, 0);
            label8.Name = "label8";
            label8.Size = new Size(72, 32);
            label8.TabIndex = 6;
            label8.Text = "Votes";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(37, 102);
            label9.Margin = new Padding(6, 0, 6, 0);
            label9.Name = "label9";
            label9.Size = new Size(60, 32);
            label9.TabIndex = 5;
            label9.Text = "Title";
            // 
            // panel3
            // 
            panel3.Controls.Add(lblMostPostsNum);
            panel3.Controls.Add(label10);
            panel3.Controls.Add(label11);
            panel3.Controls.Add(label12);
            panel3.Controls.Add(lblMostPostsAuthor);
            panel3.Location = new Point(109, 430);
            panel3.Margin = new Padding(6);
            panel3.Name = "panel3";
            panel3.Size = new Size(996, 213);
            panel3.TabIndex = 9;
            // 
            // lblMostPostsNum
            // 
            lblMostPostsNum.AutoSize = true;
            lblMostPostsNum.Location = new Point(221, 158);
            lblMostPostsNum.Margin = new Padding(6, 0, 6, 0);
            lblMostPostsNum.Name = "lblMostPostsNum";
            lblMostPostsNum.Size = new Size(0, 32);
            lblMostPostsNum.TabIndex = 8;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(37, 21);
            label10.Margin = new Padding(6, 0, 6, 0);
            label10.Name = "label10";
            label10.Size = new Size(374, 32);
            label10.TabIndex = 7;
            label10.Text = "User With The Most Popular Posts";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(37, 158);
            label11.Margin = new Padding(6, 0, 6, 0);
            label11.Name = "label11";
            label11.Size = new Size(68, 32);
            label11.TabIndex = 6;
            label11.Text = "Posts";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(37, 102);
            label12.Margin = new Padding(6, 0, 6, 0);
            label12.Name = "label12";
            label12.Size = new Size(78, 32);
            label12.TabIndex = 5;
            label12.Text = "Name";
            // 
            // lblMostPostsAuthor
            // 
            lblMostPostsAuthor.AutoSize = true;
            lblMostPostsAuthor.Location = new Point(221, 102);
            lblMostPostsAuthor.Margin = new Padding(6, 0, 6, 0);
            lblMostPostsAuthor.Name = "lblMostPostsAuthor";
            lblMostPostsAuthor.Size = new Size(0, 32);
            lblMostPostsAuthor.TabIndex = 4;
            // 
            // btnRun
            // 
            btnRun.Enabled = false;
            btnRun.Location = new Point(966, 812);
            btnRun.Margin = new Padding(6);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(139, 49);
            btnRun.TabIndex = 10;
            btnRun.Text = "Start";
            btnRun.UseVisualStyleBackColor = true;
            btnRun.Click += btnRun_Click;
            // 
            // btnStop
            // 
            btnStop.Enabled = false;
            btnStop.Location = new Point(1159, 812);
            btnStop.Margin = new Padding(6);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(139, 49);
            btnStop.TabIndex = 11;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2195, 960);
            Controls.Add(btnStop);
            Controls.Add(btnRun);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(lblLastUpdate);
            Controls.Add(label);
            Margin = new Padding(6);
            Name = "frmMain";
            Text = "ReTracker";
            Load += frmMain_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion
        private Label label;
        private Label lblLastUpdate;
        private Label lblUpVotesPostName;
        private Label label4;
        private Label label5;
        private Label label6;
        private Panel panel1;
        private Label lblUpVotesNum;
        private Panel panel2;
        private Label lblDownVotesNum;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label lblDownVotesPostName;
        private Panel panel3;
        private Label lblMostPostsNum;
        private Label label10;
        private Label label11;
        private Label label12;
        private Label lblMostPostsAuthor;
        private Button btnRun;
        private Button btnStop;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer timer1;
    }
}