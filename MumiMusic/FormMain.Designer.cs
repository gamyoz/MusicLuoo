using System.Windows.Forms;

namespace MumiMusic
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.Title = new System.Windows.Forms.Label();
            this.small = new System.Windows.Forms.Label();
            this.Closes = new System.Windows.Forms.Label();
            this.pmusicdown = new System.Windows.Forms.Panel();
            this.pmusicup = new System.Windows.Forms.Panel();
            this.btnPrev = new System.Windows.Forms.PictureBox();
            this.btnPlay = new System.Windows.Forms.PictureBox();
            this.btnNext = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timerPlayState = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.axPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.timer5 = new System.Windows.Forms.Timer(this.components);
            this.panel6 = new System.Windows.Forms.Panel();
            this.lvSong = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAuthor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAlbum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSongNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label13 = new System.Windows.Forms.Label();
            this.txtMusicNum = new System.Windows.Forms.Label();
            this.lbSongName = new System.Windows.Forms.Label();
            this.btnPlayNextType = new System.Windows.Forms.Button();
            this.pmusicdown.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPlay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNext)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axPlayer)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Title.ForeColor = System.Drawing.Color.White;
            this.Title.Location = new System.Drawing.Point(5, 6);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(69, 17);
            this.Title.TabIndex = 0;
            this.Title.Text = "GamMusic";
            this.toolTip1.SetToolTip(this.Title, "GamMusic");
            // 
            // small
            // 
            this.small.AutoSize = true;
            this.small.BackColor = System.Drawing.Color.Transparent;
            this.small.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.small.ForeColor = System.Drawing.Color.White;
            this.small.Location = new System.Drawing.Point(350, 6);
            this.small.Name = "small";
            this.small.Size = new System.Drawing.Size(18, 17);
            this.small.TabIndex = 2;
            this.small.Text = "__";
            this.toolTip1.SetToolTip(this.small, "最小化");
            this.small.Click += new System.EventHandler(this.small_Click);
            this.small.MouseLeave += new System.EventHandler(this.small_MouseLeave);
            this.small.MouseMove += new System.Windows.Forms.MouseEventHandler(this.small_MouseMove);
            // 
            // Closes
            // 
            this.Closes.AutoSize = true;
            this.Closes.BackColor = System.Drawing.Color.Transparent;
            this.Closes.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Closes.ForeColor = System.Drawing.Color.White;
            this.Closes.Location = new System.Drawing.Point(379, 9);
            this.Closes.Name = "Closes";
            this.Closes.Size = new System.Drawing.Size(16, 17);
            this.Closes.TabIndex = 3;
            this.Closes.Text = "X";
            this.toolTip1.SetToolTip(this.Closes, "关闭");
            this.Closes.Click += new System.EventHandler(this.Close_Click);
            this.Closes.MouseLeave += new System.EventHandler(this.Close_MouseLeave);
            this.Closes.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Close_MouseMove);
            // 
            // pmusicdown
            // 
            this.pmusicdown.BackColor = System.Drawing.Color.Black;
            this.pmusicdown.Controls.Add(this.pmusicup);
            this.pmusicdown.Location = new System.Drawing.Point(48, 95);
            this.pmusicdown.Name = "pmusicdown";
            this.pmusicdown.Size = new System.Drawing.Size(310, 3);
            this.pmusicdown.TabIndex = 4;
            this.pmusicdown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pmusicdown_MouseDown);
            this.pmusicdown.MouseEnter += new System.EventHandler(this.pmusicdown_MouseEnter);
            this.pmusicdown.MouseLeave += new System.EventHandler(this.pmusicdown_MouseLeave);
            this.pmusicdown.MouseHover += new System.EventHandler(this.pmusicdown_MouseHover);
            // 
            // pmusicup
            // 
            this.pmusicup.BackColor = System.Drawing.Color.White;
            this.pmusicup.Location = new System.Drawing.Point(0, 0);
            this.pmusicup.Name = "pmusicup";
            this.pmusicup.Size = new System.Drawing.Size(0, 3);
            this.pmusicup.TabIndex = 5;
            this.pmusicup.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pmusicup_MouseDown);
            this.pmusicup.MouseEnter += new System.EventHandler(this.pmusicup_MouseEnter);
            this.pmusicup.MouseLeave += new System.EventHandler(this.pmusicup_MouseLeave);
            this.pmusicup.MouseHover += new System.EventHandler(this.pmusicup_MouseHover);
            // 
            // btnPrev
            // 
            this.btnPrev.BackColor = System.Drawing.Color.Transparent;
            this.btnPrev.BackgroundImage = global::MumiMusic.Properties.Resources.preview_on;
            this.btnPrev.Location = new System.Drawing.Point(45, 123);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(29, 26);
            this.btnPrev.TabIndex = 5;
            this.btnPrev.TabStop = false;
            this.toolTip1.SetToolTip(this.btnPrev, "上一曲");
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            this.btnPrev.MouseEnter += new System.EventHandler(this.btnPrev_MouseEnter);
            this.btnPrev.MouseLeave += new System.EventHandler(this.btnPrev_MouseLeave);
            // 
            // btnPlay
            // 
            this.btnPlay.BackColor = System.Drawing.Color.Transparent;
            this.btnPlay.Image = global::MumiMusic.Properties.Resources.pause_on;
            this.btnPlay.Location = new System.Drawing.Point(118, 123);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(29, 29);
            this.btnPlay.TabIndex = 6;
            this.btnPlay.TabStop = false;
            this.toolTip1.SetToolTip(this.btnPlay, "播放/暂停");
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            this.btnPlay.MouseEnter += new System.EventHandler(this.btnPlay_MouseEnter);
            this.btnPlay.MouseLeave += new System.EventHandler(this.btnPlay_MouseLeave);
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.Image = global::MumiMusic.Properties.Resources.next_on;
            this.btnNext.Location = new System.Drawing.Point(191, 123);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(29, 29);
            this.btnNext.TabIndex = 7;
            this.btnNext.TabStop = false;
            this.toolTip1.SetToolTip(this.btnNext, "下一曲");
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            this.btnNext.MouseEnter += new System.EventHandler(this.btnNext_MouseEnter);
            this.btnNext.MouseLeave += new System.EventHandler(this.btnNext_MouseLeave);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Image = global::MumiMusic.Properties.Resources.favorite_on;
            this.pictureBox4.Location = new System.Drawing.Point(264, 123);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(29, 29);
            this.pictureBox4.TabIndex = 8;
            this.pictureBox4.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox4, "喜欢");
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            this.pictureBox4.MouseEnter += new System.EventHandler(this.pictureBox4_MouseEnter);
            this.pictureBox4.MouseLeave += new System.EventHandler(this.pictureBox4_MouseLeave);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(268, 168);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(100, 3);
            this.panel1.TabIndex = 10;
            this.toolTip1.SetToolTip(this.panel1, "音量");
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseEnter += new System.EventHandler(this.panel1_MouseEnter);
            this.panel1.MouseLeave += new System.EventHandler(this.panel1_MouseLeave);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(35, 3);
            this.panel2.TabIndex = 11;
            this.toolTip1.SetToolTip(this.panel2, "音量");
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel2.MouseEnter += new System.EventHandler(this.panel2_MouseEnter);
            this.panel2.MouseLeave += new System.EventHandler(this.panel2_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(46, 108);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "00:00";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(323, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "00:00";
            // 
            // timerPlayState
            // 
            this.timerPlayState.Enabled = true;
            this.timerPlayState.Tick += new System.EventHandler(this.timerPlayState_Tick);
            // 
            // axPlayer
            // 
            this.axPlayer.Enabled = true;
            this.axPlayer.Location = new System.Drawing.Point(45, 30);
            this.axPlayer.Name = "axPlayer";
            this.axPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axPlayer.OcxState")));
            this.axPlayer.Size = new System.Drawing.Size(10, 10);
            this.axPlayer.TabIndex = 15;
            this.axPlayer.Visible = false;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.Controls.Add(this.label4);
            this.panel5.Location = new System.Drawing.Point(69, 73);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(268, 21);
            this.panel5.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(3, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(262, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Mumi  Music";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // timer4
            // 
            this.timer4.Interval = 50;
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // timer5
            // 
            this.timer5.Enabled = true;
            this.timer5.Tick += new System.EventHandler(this.timer5_Tick);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Transparent;
            this.panel6.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel6.BackgroundImage")));
            this.panel6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel6.Controls.Add(this.lvSong);
            this.panel6.Location = new System.Drawing.Point(9, 198);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(391, 167);
            this.panel6.TabIndex = 18;
            // 
            // lvSong
            // 
            this.lvSong.BackColor = System.Drawing.SystemColors.Control;
            this.lvSong.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvSong.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colAuthor,
            this.colAlbum,
            this.colSongNo});
            this.lvSong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSong.FullRowSelect = true;
            this.lvSong.GridLines = true;
            this.lvSong.Location = new System.Drawing.Point(0, 0);
            this.lvSong.MultiSelect = false;
            this.lvSong.Name = "lvSong";
            this.lvSong.Size = new System.Drawing.Size(391, 167);
            this.lvSong.TabIndex = 0;
            this.lvSong.UseCompatibleStateImageBehavior = false;
            this.lvSong.View = System.Windows.Forms.View.Details;
            this.lvSong.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvSong_MouseDoubleClick);
            // 
            // colName
            // 
            this.colName.Text = "名称";
            this.colName.Width = 180;
            // 
            // colAuthor
            // 
            this.colAuthor.Text = "作者";
            this.colAuthor.Width = 90;
            // 
            // colAlbum
            // 
            this.colAlbum.Text = "专辑";
            this.colAlbum.Width = 90;
            // 
            // colSongNo
            // 
            this.colSongNo.Width = 0;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(34, 183);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 12);
            this.label13.TabIndex = 19;
            this.label13.Text = "共有歌曲:";
            // 
            // txtMusicNum
            // 
            this.txtMusicNum.AutoSize = true;
            this.txtMusicNum.BackColor = System.Drawing.Color.Transparent;
            this.txtMusicNum.ForeColor = System.Drawing.Color.White;
            this.txtMusicNum.Location = new System.Drawing.Point(99, 183);
            this.txtMusicNum.Name = "txtMusicNum";
            this.txtMusicNum.Size = new System.Drawing.Size(11, 12);
            this.txtMusicNum.TabIndex = 20;
            this.txtMusicNum.Text = "0";
            // 
            // lbSongName
            // 
            this.lbSongName.AutoEllipsis = true;
            this.lbSongName.BackColor = System.Drawing.Color.Transparent;
            this.lbSongName.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSongName.ForeColor = System.Drawing.Color.White;
            this.lbSongName.Location = new System.Drawing.Point(69, 40);
            this.lbSongName.Name = "lbSongName";
            this.lbSongName.Size = new System.Drawing.Size(265, 30);
            this.lbSongName.TabIndex = 1;
            this.lbSongName.Text = "Mumi  Music";
            this.lbSongName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPlayNextType
            // 
            this.btnPlayNextType.Font = new System.Drawing.Font("宋体", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPlayNextType.Location = new System.Drawing.Point(320, 134);
            this.btnPlayNextType.Name = "btnPlayNextType";
            this.btnPlayNextType.Size = new System.Drawing.Size(35, 18);
            this.btnPlayNextType.TabIndex = 21;
            this.btnPlayNextType.Text = "随机";
            this.btnPlayNextType.UseVisualStyleBackColor = true;
            this.btnPlayNextType.Click += new System.EventHandler(this.btnPlayNextType_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(407, 370);
            this.Controls.Add(this.btnPlayNextType);
            this.Controls.Add(this.lbSongName);
            this.Controls.Add(this.txtMusicNum);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.axPlayer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.pmusicdown);
            this.Controls.Add(this.Closes);
            this.Controls.Add(this.small);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MumiMusic";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseDown);
            this.MouseLeave += new System.EventHandler(this.FormMain_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseMove);
            this.Move += new System.EventHandler(this.FormMain_Move);
            this.pmusicdown.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnPrev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPlay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNext)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axPlayer)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label small;
        private System.Windows.Forms.Label Closes;
        private System.Windows.Forms.Panel pmusicdown;
        private System.Windows.Forms.Panel pmusicup;
        private System.Windows.Forms.PictureBox btnPrev;
        private System.Windows.Forms.PictureBox btnPlay;
        private System.Windows.Forms.PictureBox btnNext;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private AxWMPLib.AxWindowsMediaPlayer axPlayer;
        private System.Windows.Forms.Timer timerPlayState;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.Timer timer5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label txtMusicNum;
        private System.Windows.Forms.ListView lvSong;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colAuthor;
        private System.Windows.Forms.ColumnHeader colAlbum;
        private System.Windows.Forms.ColumnHeader colSongNo;
        private Label lbSongName;
        private Button btnPlayNextType;
    }
}

