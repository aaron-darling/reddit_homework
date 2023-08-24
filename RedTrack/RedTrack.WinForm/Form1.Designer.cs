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
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(15, 50);
            label.Name = "label";
            label.Size = new Size(69, 15);
            label.TabIndex = 2;
            label.Text = "Last Update";
            // 
            // lblLastUpdate
            // 
            lblLastUpdate.AutoSize = true;
            lblLastUpdate.Location = new Point(131, 50);
            lblLastUpdate.Name = "lblLastUpdate";
            lblLastUpdate.Size = new Size(0, 15);
            lblLastUpdate.TabIndex = 3;
            // 
            // lblUpVotesPostName
            // 
            lblUpVotesPostName.AutoSize = true;
            lblUpVotesPostName.Location = new Point(72, 48);
            lblUpVotesPostName.Margin = new Padding(2, 0, 2, 0);
            lblUpVotesPostName.Name = "lblUpVotesPostName";
            lblUpVotesPostName.Size = new Size(0, 15);
            lblUpVotesPostName.TabIndex = 4;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 48);
            label4.Name = "label4";
            label4.Size = new Size(29, 15);
            label4.TabIndex = 5;
            label4.Text = "Title";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 74);
            label5.Name = "label5";
            label5.Size = new Size(35, 15);
            label5.TabIndex = 6;
            label5.Text = "Votes";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(20, 10);
            label6.Name = "label6";
            label6.Size = new Size(159, 15);
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
            panel1.Location = new Point(59, 84);
            panel1.Name = "panel1";
            panel1.Size = new Size(536, 100);
            panel1.TabIndex = 8;
            // 
            // lblUpVotesNum
            // 
            lblUpVotesNum.AutoSize = true;
            lblUpVotesNum.Location = new Point(72, 74);
            lblUpVotesNum.Margin = new Padding(2, 0, 2, 0);
            lblUpVotesNum.Name = "lblUpVotesNum";
            lblUpVotesNum.Size = new Size(0, 15);
            lblUpVotesNum.TabIndex = 8;
            // 
            // panel3
            // 
            panel3.Controls.Add(lblMostPostsNum);
            panel3.Controls.Add(label10);
            panel3.Controls.Add(label11);
            panel3.Controls.Add(label12);
            panel3.Controls.Add(lblMostPostsAuthor);
            panel3.Location = new Point(59, 202);
            panel3.Name = "panel3";
            panel3.Size = new Size(536, 100);
            panel3.TabIndex = 9;
            // 
            // lblMostPostsNum
            // 
            lblMostPostsNum.AutoSize = true;
            lblMostPostsNum.Location = new Point(119, 74);
            lblMostPostsNum.Name = "lblMostPostsNum";
            lblMostPostsNum.Size = new Size(0, 15);
            lblMostPostsNum.TabIndex = 8;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(20, 10);
            label10.Name = "label10";
            label10.Size = new Size(185, 15);
            label10.TabIndex = 7;
            label10.Text = "User With The Most Popular Posts";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(20, 74);
            label11.Name = "label11";
            label11.Size = new Size(35, 15);
            label11.TabIndex = 6;
            label11.Text = "Posts";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(20, 48);
            label12.Name = "label12";
            label12.Size = new Size(39, 15);
            label12.TabIndex = 5;
            label12.Text = "Name";
            // 
            // lblMostPostsAuthor
            // 
            lblMostPostsAuthor.AutoSize = true;
            lblMostPostsAuthor.Location = new Point(119, 48);
            lblMostPostsAuthor.Name = "lblMostPostsAuthor";
            lblMostPostsAuthor.Size = new Size(0, 15);
            lblMostPostsAuthor.TabIndex = 4;
            // 
            // btnRun
            // 
            btnRun.Enabled = false;
            btnRun.Location = new Point(239, 362);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(75, 23);
            btnRun.TabIndex = 10;
            btnRun.Text = "Start";
            btnRun.UseVisualStyleBackColor = true;
            btnRun.Click += btnRun_Click;
            // 
            // btnStop
            // 
            btnStop.Enabled = false;
            btnStop.Location = new Point(343, 362);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(75, 23);
            btnStop.TabIndex = 11;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(723, 450);
            Controls.Add(btnStop);
            Controls.Add(btnRun);
            Controls.Add(panel3);
            Controls.Add(panel1);
            Controls.Add(lblLastUpdate);
            Controls.Add(label);
            Name = "frmMain";
            Text = "ReTracker";
            Load += frmMain_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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