namespace MumiMusic
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Title = new System.Windows.Forms.Label();
            this.small = new System.Windows.Forms.Label();
            this.Closes = new System.Windows.Forms.Label();
            this.pmusicdown = new System.Windows.Forms.Panel();
            this.pmusicup = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pname = new System.Windows.Forms.Panel();
            this.musicName = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.axPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.timer5 = new System.Windows.Forms.Timer(this.components);
            this.panel6 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPageCount = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPageNum = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.pictureBox13 = new System.Windows.Forms.PictureBox();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtMusicNum = new System.Windows.Forms.Label();
            this.pmusicdown.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel1.SuspendLayout();
            this.pname.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axPlayer)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
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
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::MumiMusic.Properties.Resources.preview_on;
            this.pictureBox1.Location = new System.Drawing.Point(45, 123);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(29, 26);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, "上一曲");
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseLeave += new System.EventHandler(this.pictureBox1_MouseLeave);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::MumiMusic.Properties.Resources.pause_on;
            this.pictureBox2.Location = new System.Drawing.Point(118, 123);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(29, 29);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox2, "播放/暂停");
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            this.pictureBox2.MouseEnter += new System.EventHandler(this.pictureBox2_MouseEnter);
            this.pictureBox2.MouseLeave += new System.EventHandler(this.pictureBox2_MouseLeave);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = global::MumiMusic.Properties.Resources.next_on;
            this.pictureBox3.Location = new System.Drawing.Point(191, 123);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(29, 29);
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox3, "下一曲");
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            this.pictureBox3.MouseEnter += new System.EventHandler(this.pictureBox3_MouseEnter);
            this.pictureBox3.MouseLeave += new System.EventHandler(this.pictureBox3_MouseLeave);
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
            // pname
            // 
            this.pname.BackColor = System.Drawing.Color.Transparent;
            this.pname.Controls.Add(this.musicName);
            this.pname.Location = new System.Drawing.Point(104, 30);
            this.pname.Name = "pname";
            this.pname.Size = new System.Drawing.Size(199, 37);
            this.pname.TabIndex = 11;
            // 
            // musicName
            // 
            this.musicName.AutoSize = true;
            this.musicName.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.musicName.ForeColor = System.Drawing.Color.White;
            this.musicName.Location = new System.Drawing.Point(57, 12);
            this.musicName.Name = "musicName";
            this.musicName.Size = new System.Drawing.Size(228, 21);
            this.musicName.TabIndex = 0;
            this.musicName.Text = "Welcome to use MumiMusic";
            // 
            // timer1
            // 
            this.timer1.Interval = 48;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 48;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
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
            // timer3
            // 
            this.timer3.Enabled = true;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
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
            this.panel6.Controls.Add(this.label12);
            this.panel6.Controls.Add(this.txtPageCount);
            this.panel6.Controls.Add(this.label11);
            this.panel6.Controls.Add(this.txtPageNum);
            this.panel6.Controls.Add(this.label10);
            this.panel6.Controls.Add(this.pictureBox13);
            this.panel6.Controls.Add(this.pictureBox12);
            this.panel6.Controls.Add(this.label9);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Controls.Add(this.label7);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Location = new System.Drawing.Point(9, 198);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(391, 167);
            this.panel6.TabIndex = 18;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(253, 148);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 12);
            this.label12.TabIndex = 13;
            this.label12.Text = "页";
            // 
            // txtPageCount
            // 
            this.txtPageCount.AutoSize = true;
            this.txtPageCount.Location = new System.Drawing.Point(233, 148);
            this.txtPageCount.Name = "txtPageCount";
            this.txtPageCount.Size = new System.Drawing.Size(11, 12);
            this.txtPageCount.TabIndex = 12;
            this.txtPageCount.Text = "1";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(189, 148);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 12);
            this.label11.TabIndex = 11;
            this.label11.Text = "页,共";
            // 
            // txtPageNum
            // 
            this.txtPageNum.AutoSize = true;
            this.txtPageNum.Location = new System.Drawing.Point(164, 148);
            this.txtPageNum.Name = "txtPageNum";
            this.txtPageNum.Size = new System.Drawing.Size(11, 12);
            this.txtPageNum.TabIndex = 10;
            this.txtPageNum.Text = "1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(110, 148);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 12);
            this.label10.TabIndex = 9;
            this.label10.Text = "当前第:";
            // 
            // pictureBox13
            // 
            this.pictureBox13.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox13.Image")));
            this.pictureBox13.Location = new System.Drawing.Point(69, 138);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new System.Drawing.Size(29, 22);
            this.pictureBox13.TabIndex = 8;
            this.pictureBox13.TabStop = false;
            this.pictureBox13.Click += new System.EventHandler(this.pictureBox13_Click);
            // 
            // pictureBox12
            // 
            this.pictureBox12.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox12.Image")));
            this.pictureBox12.Location = new System.Drawing.Point(292, 138);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(29, 22);
            this.pictureBox12.TabIndex = 7;
            this.pictureBox12.TabStop = false;
            this.pictureBox12.Click += new System.EventHandler(this.pictureBox12_Click);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(20, 112);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(344, 23);
            this.label9.TabIndex = 4;
            this.label9.Tag = "4";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label9.DoubleClick += new System.EventHandler(this.lable_DoubleClick);
            this.label9.MouseEnter += new System.EventHandler(this.label_MouseEnter);
            this.label9.MouseLeave += new System.EventHandler(this.lable_MouseLeava);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(20, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(344, 23);
            this.label8.TabIndex = 3;
            this.label8.Tag = "3";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label8.DoubleClick += new System.EventHandler(this.lable_DoubleClick);
            this.label8.MouseEnter += new System.EventHandler(this.label_MouseEnter);
            this.label8.MouseLeave += new System.EventHandler(this.lable_MouseLeava);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(20, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(344, 23);
            this.label7.TabIndex = 2;
            this.label7.Tag = "2";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label7.DoubleClick += new System.EventHandler(this.lable_DoubleClick);
            this.label7.MouseEnter += new System.EventHandler(this.label_MouseEnter);
            this.label7.MouseLeave += new System.EventHandler(this.lable_MouseLeava);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(20, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(344, 23);
            this.label6.TabIndex = 1;
            this.label6.Tag = "1";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label6.DoubleClick += new System.EventHandler(this.lable_DoubleClick);
            this.label6.MouseEnter += new System.EventHandler(this.label_MouseEnter);
            this.label6.MouseLeave += new System.EventHandler(this.lable_MouseLeava);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(20, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(344, 23);
            this.label5.TabIndex = 0;
            this.label5.Tag = "0";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label5.DoubleClick += new System.EventHandler(this.lable_DoubleClick);
            this.label5.MouseEnter += new System.EventHandler(this.label_MouseEnter);
            this.label5.MouseLeave += new System.EventHandler(this.lable_MouseLeava);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(407, 370);
            this.Controls.Add(this.txtMusicNum);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.axPlayer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pname);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pmusicdown);
            this.Controls.Add(this.Closes);
            this.Controls.Add(this.small);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.label2);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MumiMusic";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseLeave += new System.EventHandler(this.Form1_MouseLeave);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.Move += new System.EventHandler(this.Form1_Move);
            this.pmusicdown.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pname.ResumeLayout(false);
            this.pname.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axPlayer)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label small;
        private System.Windows.Forms.Label Closes;
        private System.Windows.Forms.Panel pmusicdown;
        private System.Windows.Forms.Panel pmusicup;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel pname;
        private System.Windows.Forms.Label musicName;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private AxWMPLib.AxWindowsMediaPlayer axPlayer;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.Timer timer5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox13;
        private System.Windows.Forms.PictureBox pictureBox12;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label txtPageCount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label txtPageNum;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label txtMusicNum;
    }
}

