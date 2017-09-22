namespace Wumpus
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnNextMove = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.gbPlayerII = new System.Windows.Forms.GroupBox();
            this.playerTwoLog = new System.Windows.Forms.TextBox();
            this.gbPlayerI = new System.Windows.Forms.GroupBox();
            this.playerOneLog = new System.Windows.Forms.TextBox();
            this.btnInit = new System.Windows.Forms.Button();
            this.tmTurns = new System.Windows.Forms.Timer(this.components);
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.imageTable = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.gbPlayerII.SuspendLayout();
            this.gbPlayerI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnNextMove);
            this.panel1.Controls.Add(this.btnStop);
            this.panel1.Controls.Add(this.btnStart);
            this.panel1.Controls.Add(this.gbPlayerII);
            this.panel1.Controls.Add(this.gbPlayerI);
            this.panel1.Controls.Add(this.btnInit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(952, 199);
            this.panel1.TabIndex = 0;
            // 
            // btnNextMove
            // 
            this.btnNextMove.Location = new System.Drawing.Point(817, 99);
            this.btnNextMove.Name = "btnNextMove";
            this.btnNextMove.Size = new System.Drawing.Size(106, 23);
            this.btnNextMove.TabIndex = 5;
            this.btnNextMove.Text = "Next Move";
            this.btnNextMove.UseVisualStyleBackColor = true;
            this.btnNextMove.Click += new System.EventHandler(this.btnNextMove_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(817, 70);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(106, 23);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Stop Game";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(817, 41);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(106, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start Game";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // gbPlayerII
            // 
            this.gbPlayerII.Controls.Add(this.playerTwoLog);
            this.gbPlayerII.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbPlayerII.Location = new System.Drawing.Point(302, 0);
            this.gbPlayerII.Name = "gbPlayerII";
            this.gbPlayerII.Size = new System.Drawing.Size(302, 199);
            this.gbPlayerII.TabIndex = 2;
            this.gbPlayerII.TabStop = false;
            this.gbPlayerII.Text = "Player II";
            // 
            // playerTwoLog
            // 
            this.playerTwoLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playerTwoLog.Location = new System.Drawing.Point(3, 16);
            this.playerTwoLog.Multiline = true;
            this.playerTwoLog.Name = "playerTwoLog";
            this.playerTwoLog.ReadOnly = true;
            this.playerTwoLog.Size = new System.Drawing.Size(296, 180);
            this.playerTwoLog.TabIndex = 0;
            // 
            // gbPlayerI
            // 
            this.gbPlayerI.Controls.Add(this.playerOneLog);
            this.gbPlayerI.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbPlayerI.Location = new System.Drawing.Point(0, 0);
            this.gbPlayerI.Name = "gbPlayerI";
            this.gbPlayerI.Size = new System.Drawing.Size(302, 199);
            this.gbPlayerI.TabIndex = 1;
            this.gbPlayerI.TabStop = false;
            this.gbPlayerI.Text = "Player I";
            // 
            // playerOneLog
            // 
            this.playerOneLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playerOneLog.Location = new System.Drawing.Point(3, 16);
            this.playerOneLog.Multiline = true;
            this.playerOneLog.Name = "playerOneLog";
            this.playerOneLog.ReadOnly = true;
            this.playerOneLog.Size = new System.Drawing.Size(296, 180);
            this.playerOneLog.TabIndex = 0;
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(817, 12);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(106, 23);
            this.btnInit.TabIndex = 0;
            this.btnInit.Text = "Init Game";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // tmTurns
            // 
            this.tmTurns.Interval = 5000;
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "cave.png");
            this.imgList.Images.SetKeyName(1, "pit.jpg");
            this.imgList.Images.SetKeyName(2, "gold.png");
            this.imgList.Images.SetKeyName(3, "wumpus.png");
            // 
            // imageTable
            // 
            this.imageTable.ColumnCount = 6;
            this.imageTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.imageTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.imageTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.imageTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.imageTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.imageTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.imageTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageTable.Location = new System.Drawing.Point(0, 199);
            this.imageTable.Name = "imageTable";
            this.imageTable.RowCount = 6;
            this.imageTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.imageTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.imageTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.imageTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.imageTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.imageTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.imageTable.Size = new System.Drawing.Size(952, 406);
            this.imageTable.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Wumpus.Properties.Resources.cave;
            this.pictureBox1.Location = new System.Drawing.Point(677, 129);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 605);
            this.Controls.Add(this.imageTable);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "Main Form";
            this.panel1.ResumeLayout(false);
            this.gbPlayerII.ResumeLayout(false);
            this.gbPlayerII.PerformLayout();
            this.gbPlayerI.ResumeLayout(false);
            this.gbPlayerI.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.GroupBox gbPlayerII;
        private System.Windows.Forms.GroupBox gbPlayerI;
        private System.Windows.Forms.TextBox playerTwoLog;
        private System.Windows.Forms.TextBox playerOneLog;
        private System.Windows.Forms.Timer tmTurns;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnNextMove;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.TableLayoutPanel imageTable;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

