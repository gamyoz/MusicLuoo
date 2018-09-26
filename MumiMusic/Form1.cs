using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using MusicLuooUnity;

namespace MumiMusic
{
    public partial class Form1 : Form
    {
        private Thread thread1;
        set_Text setLrcText;
        set_Text setLableLrc;

        delegate void set_Text(string s);

        ShowLrc lrc = new ShowLrc();
        Lrc L = new Lrc();

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        protected static extern bool AnimateWindow(IntPtr hWnd, int dwTime, int dwFlags);

        public const Int32 AW_BLEND = 0x00080000;
        public const Int32 AW_CENTER = 0x00000010;
        public const Int32 AW_ACTIVATE = 0x00020000;
        public const Int32 AW_HIDE = 0x00010000;
        public const Int32 AW_SLIDE = 0x00040000;

        [DllImport("User32.dll")]
        public static extern bool PtInRect(ref Rectangle Rects, Point lpPoint);

        public Form1()
        {
            InitializeComponent();
            SetClassLong(this.Handle, GCL_STYLE, GetClassLong(this.Handle, GCL_STYLE) | CS_DropSHADOW);
                //API函数加载，实现窗体边框阴影效果
            this.SetStyle(
                ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        }

        #region 窗体边框阴影效果变量申明

        const int CS_DropSHADOW = 0x20000;
        const int GCL_STYLE = (-26);
        //声明Win32 API
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SetClassLong(IntPtr hwnd, int nIndex, int dwNewLong);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetClassLong(IntPtr hwnd, int nIndex);

        #endregion

        #region 窗体拖动代码

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }

        #endregion

        bool isplay = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            AnimateWindow(this.Handle, 500, AW_BLEND | AW_CENTER | AW_ACTIVATE);
            setLrcText = new set_Text(set_lableText);
            setLableLrc = new set_Text(set_lableLrc);
            thread1 = new Thread(new ThreadStart(SerchLrc));
            GetMusicList();
            getNum();
            try
            {

                this.axPlayer.settings.volume = 100; //初始化声音为35
                play(_songs[musicNum]);
                isplay = true;
            }
            catch (Exception)
            {

                isplay = false;
            }
            setControlEnter();
            setMusicList(1);
        }

        #region 窗体隐藏

        private void WindowShowHide()
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                Point cursorPoint = new Point(Cursor.Position.X, Cursor.Position.Y);
                Rectangle rectgle = new Rectangle(this.Left, this.Top, this.Left + this.Width, this.Top + this.Height);
                bool ptInRect = PtInRect(ref rectgle, cursorPoint);
                if (ptInRect)
                {
                    if (this.Top < 0)
                    {
                        this.Top = 0;
                    }
                    else if (this.Left < 0)
                    {
                        this.Left = 0;
                    }
                    else if (this.Right > Screen.PrimaryScreen.WorkingArea.Width)
                    {
                        this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
                    }
                }
                else
                {
                    if (this.Top < 5)
                    {
                        this.Top = -this.Height + 5;
                    }
                    else if (this.Left < 5)
                    {
                        this.Left = -this.Width + 5;
                    }
                    else if (this.Right > Screen.PrimaryScreen.WorkingArea.Width - 5)
                    {
                        this.Left = Screen.PrimaryScreen.WorkingArea.Width - 5;
                    }
                }
            }
        }

        #endregion



        //设置一个变量来判断是否快进
        bool next = false;

        #region 当歌词超出panle长度时 设置左右移动变换

        //int lefti=0;//设置移动次数
        int y = 0;
        int bb;
        int rx;
        int lx;
        int bl;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (lx >= -100)
            {
                musicName.Location = new Point(bl - 1, y);
                bl--;
                lx--;
            }
            else
            {

                timer1.Enabled = false;
                timer2.Enabled = true;
            }
        }

        //获得移动次数
        public void getNum()
        {
            bl = 0;
            rx = 0;
            lx = 0;
            musicName.Location = new Point(57, 13);
            if (musicName.Size.Width > 150)
            {
                bb = bl = rx = lx = musicName.Location.X + 100;
                y = musicName.Location.Y;
                timer1.Enabled = true;
            }
            else
            {
                timer1.Enabled = false;
            }
        }

        #endregion

        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region 按钮颜色变化

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.preview_down;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            if (plays == false)
            {
                pictureBox2.Image = Properties.Resources.play_down;
            }
            else
            {
                pictureBox2.Image = Properties.Resources.pause_down;
            }

        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.next_down;
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.Image = Properties.Resources.favorite_down;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Image = Properties.Resources.favorite_on;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = Properties.Resources.next_on;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            if (plays == false)
            {
                pictureBox2.Image = Properties.Resources.play_on;
            }
            else
            {
                pictureBox2.Image = Properties.Resources.pause_on;
            }

        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.preview_on;
        }

        #endregion


        #region lable颜色变化

        private void small_MouseMove(object sender, MouseEventArgs e)
        {
            small.ForeColor = Color.Black;
        }

        private void Close_MouseMove(object sender, MouseEventArgs e)
        {
            Closes.ForeColor = Color.Black;
        }

        private void small_MouseLeave(object sender, EventArgs e)
        {
            small.ForeColor = Color.White;
        }

        private void Close_MouseLeave(object sender, EventArgs e)
        {
            Closes.ForeColor = Color.White;

        }

        #endregion

        #region 音量和进度

        int panleX; //获取当前panle的X

        //音量的
        private void panel2_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void panel2_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void panel1_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            voice = e.Location.X;
            setVoice(voice);
            panel2.Size = new Size(e.Location.X, 3);
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            voice = e.Location.X;
            panel2.Size = new Size(e.Location.X, 3);
            setVoice(voice);
        }

        private void pmusicdown_MouseDown(object sender, MouseEventArgs e)
        {
            pmusicup.Size = new Size(e.Location.X, 3);
            panleX = e.Location.X;
            changeTime(310, panleX);
            next = true;

        }

        private void pmusicdown_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void pmusicdown_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void pmusicup_MouseDown(object sender, MouseEventArgs e)
        {
            pmusicup.Size = new Size(e.Location.X, 3);
            panleX = e.Location.X;
            changeTime(310, panleX);
            next = true;
        }

        private void pmusicup_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.Hand;
        }

        private void pmusicup_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        #endregion



        //string[] names;//获取歌曲路径集合
        int voice; //声音
        int musicNum = 0;
        private List<LuooVolSongModel> _songs;



        //播放
        public void play(LuooVolSongModel namepath)
        {
            timer4.Enabled = false;
            if (thread1.IsAlive)
            {
                thread1.Abort(); //撤消thread1
            }
            thread1 = new Thread(new ThreadStart(SerchLrc));
            this.axPlayer.URL = namepath.DownloadUrl;
            musicName.Text = this.axPlayer.currentMedia.name;
            thread1.Start();
            getNum();
            isplay = true;
            plays = true;
            timer3.Enabled = true;
            getmusicTime();
            if (plays == true)
            {
                pictureBox2.Image = Properties.Resources.pause_on;
            }

            if (!string.IsNullOrEmpty(namepath.ImgUrl))
                this.BackgroundImage = Image.FromStream(System.Net.WebRequest.Create(namepath.ImgUrl).GetResponse().GetResponseStream());
        }
        
        public void getResult()
        {
            MessageBox.Show(this.axPlayer.playState.ToString());
        }

        //读取方法
        public void GetMusicList()
        {
            int num;
            if (!int.TryParse(PubConstant.GetAppSetting("MusicNumber"), out num))
                num = 1000;
            _songs = MusicLuooUnity.BLL.LuooSongHelper.GetListPager(1, num, "");
            txtMusicNum.Text = _songs.Count.ToString();
        }

        Boolean plays = false;

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            if (plays == false)
            {
                this.axPlayer.Ctlcontrols.play();
                timer3.Enabled = true;
                pictureBox2.Image = Properties.Resources.pause_down;
                plays = true;
            }
            else
            {
                pictureBox2.Image = Properties.Resources.play_down;
                this.axPlayer.Ctlcontrols.pause();
                timer3.Enabled = false;
                plays = false;
            }
        }

        //设置声音大小

        public void setVoice(int voice)
        {
            this.axPlayer.settings.volume = voice;
        }

        //设置透明度的方法
        int op; //透明度

        public void setOpacity(int op)
        {
            this.Opacity = (double) op/100;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (isplay == true)
            {
                getmusicTime();
                this.label1.Text = this.axPlayer.Ctlcontrols.currentPositionString;
                this.label2.Text = this.axPlayer.currentMedia.durationString;
                if (this.axPlayer.playState.ToString() == "wmppsStopped")
                {
                    timer1.Enabled = false;
                    label1.Text = "00:00";
                    try
                    {
                        musicNum++;
                        play(_songs[musicNum]);
                    }
                    catch (Exception)
                    {

                        timer3.Enabled = false;
                    }
                }
            }
            else
            {

            }

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            musicNum--;
            try
            {
                play(_songs[musicNum]);
            }
            catch (Exception)
            {

                musicNum += 1;
            }
        }


        double alltime; //全部时间
        double thistime; //当前时间
        double bfb; //百分比
        double thisX;
        //改变进度条长度
        public void getmusicTime()
        {
            try
            {
                thistime = this.axPlayer.Ctlcontrols.currentPosition;
                alltime = this.axPlayer.currentMedia.duration;
                bfb = thistime / alltime;
                thisX = 310 * bfb;
                pmusicup.Size = new Size((int)thisX, 3);
            }
            catch (Exception ex)
            {
                
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            musicNum++;
            try
            {
                play(_songs[musicNum]);
            }
            catch (Exception)
            {

                musicNum -= 1;
            }
        }

        private void small_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (lx < 57)
            {
                musicName.Location = new Point(bl + 1, y);
                bl++;
                lx++;
            }
            else
            {
                timer2.Enabled = false;
                timer1.Enabled = true;
            }
        }

        //获取当前进度
        double Alltime;
        double thisTime;
        Double b;
        public void changeTime(double all,double thisp)
        {
            try
            {
                b = thisp / all;
                Alltime = this.axPlayer.currentMedia.duration;
                thisTime = Alltime * b;
                this.axPlayer.Ctlcontrols.currentPosition = thisTime;
            }
            catch (Exception)
            {
                
               //
            }
        }

        private void pmusicup_MouseHover(object sender, EventArgs e)
        {
            this.toolTip1.SetToolTip(pmusicup, label1.Text);
        }

        private void pmusicdown_MouseHover(object sender, EventArgs e)
        {
            this.toolTip1.SetToolTip(pmusicdown, label1.Text);
        }
        string title;

        private void SerchLrc()
        {
            label4.Invoke(setLrcText , new object[] { "正在搜索歌词..." });
            try
            {
                title = axPlayer.currentMedia.getItemInfo("Title");
                string[] sArray = title.Split('-');
                title = sArray[sArray.Length - 1];
                ChangeLable(L.getLrc(title.Trim()));
            }
            catch (Exception)
            {
                
                
            }
            
        }

        string[] Ltime=new string[200];//时间
        string[] Ltext=new string[200];//歌词
        bool timer=false;
        /// <summary>
        /// 改变歌词lable的方法 并且加载显示歌词方法
        /// </summary> 
        /// <param name="text">传入的返回值</param>
        private void ChangeLable(string text)
        {
            Ltime = new string[200];
            Ltext = new string[200];
            if (text == "歌词找到并下载成功！" || text == "正在解析歌词...")
            {
                label4.Invoke(setLrcText, new object[] { text });
                lrc.getLrc(string.Format(".\\Lrc\\{0}.Lrc", L.returnPath()));
                Ltext = lrc.returnText();
                Ltime = lrc.returnTime();
                label4.Invoke(setLableLrc, new object[] { Ltext[0] });
                timer = true;
            }
            else
            {
                label4.Invoke(setLableLrc, new object[] { text });
            }
        }
        /// <summary>
        /// 多线程给lable传值
        /// </summary>
        /// <param name="s"></param>
        private void set_lableText(string s)
        {
            label4.Text = s;
        }
        private void set_lableLrc(string text)
        {
            label4.Text = text;
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (thread1.IsAlive) //判断thread1是否存在，不能撤消一个不存在的线程，否则会引发异常
            {
                thread1.Abort(); //撤消thread1
            }
            AnimateWindow(this.Handle, 500, AW_CENTER | AW_BLEND | AW_HIDE); 
        }

        

        /// <summary>
        /// 显示歌词方法
        /// </summary>
        public void showLrc()
        {
            timer4.Enabled = true;
        }

        //计算左右偏移
        string BigTime;
        string SmallTime;
        public void LeftRight()
        {
            string time = this.axPlayer.Ctlcontrols.currentPositionString + ":00";
            try
            {
                int start = int.Parse(time.Substring(0, 2));
                string zj = time.Substring(3, 2);
                int zjnum = int.Parse(zj);
                BigTime = time.Substring(0, 3) + (zjnum + 2).ToString() + ":00";
                if (zjnum >= 2)
                {
                    SmallTime = time.Substring(0, 3) + (zjnum - 2).ToString() + ":00";
                }
                else if (zjnum == 00 && start > 0)
                {
                    SmallTime = "0" + (start - 1).ToString() + ":" + 58.ToString() + ":00";
                }
            }
            catch (Exception)
            {
                
            }
            
            
        }
        private void timer4_Tick(object sender, EventArgs e)
        {
            string time;
            time = this.axPlayer.Ctlcontrols.currentPositionString +":00";
            if (next == true)
            {
                LeftRight();
                for (int i = 0; i < 100; i++)
                {
                    if ( Ltime[i]==BigTime||Ltime[i]==SmallTime)
                    {
                        label4.Text = Ltext[i];
                        next = false;
                    }
                }
            }
            for (int i = 0; i < 100; i++)
            {
                if (time == Ltime[i])
                {
                    label4.Text = Ltext[i];
                }
            }
        }
        /// <summary>
        /// timer5用来监听timer4 因为在线程里无法操作timer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer5_Tick(object sender, EventArgs e)
        {
            if (timer == true)
            {
                timer4.Enabled = true;
            }
            else if (timer == false)
            {
                timer4.Enabled = false;
            }
        }

        //绘制界面
        private void Draw(Graphics formGp)
        {
            Bitmap bitmap = new Bitmap(300, 100);
            Graphics gp = Graphics.FromImage(bitmap);
            //this.DrawBg(gp);
            //if (this.list != null)
            //{
            //    this.list.Draw(gp);
            //}
            //this.DrawCountClick(gp);

            formGp.DrawImage(bitmap, 200, 200);
        }
        
        /// <summary>
        /// 批量设置lable鼠标事件
        /// </summary>
        private void setControlEnter()
        {
            label5.MouseEnter += new EventHandler(label_MouseEnter);
            label6.MouseEnter += new EventHandler(label_MouseEnter);
            label7.MouseEnter += new EventHandler(label_MouseEnter);
            label8.MouseEnter += new EventHandler(label_MouseEnter);
            label9.MouseEnter += new EventHandler(label_MouseEnter);
        }

        private void label_MouseEnter(object sender, EventArgs e)
        {
            Label lb = (Label)sender;
            lb.Image = Properties.Resources.s;
        }
        private void lable_MouseLeava(object sender, EventArgs e)
        {
            Label lb = (Label)sender;
            lb.Image = null;
        }

        //获取歌曲列表显示
        /// <summary>
        /// 返回歌曲名字
        /// </summary>
        /// <param name="path">从文件中读取的歌曲地址</param>
        /// <returns>歌曲的名字 string类型</returns>
        private string getFileName(LuooVolSongModel path)
        {
            return path.SongName + "(" + path.Author + ")";
        }
        int index=0;//下标
        private void setMusicList(int page)
        {
            if (_songs != null)
            {
                label5.Text = null;
                label6.Text = null;
                label7.Text = null;
                label8.Text = null;
                label9.Text = null;
                //label5.Visible = false;
                //label6.Visible = false;
                //label7.Visible = false;
                //label8.Visible = false;
                //label9.Visible = false;
                index = (page - 1) * 5;
                //if (page <= pages)
                //{
                //    MessageBox.Show("我进来了");
                //    if (noMusic == 1)
                //    {
                //        label6.Visible = false;
                //        label7.Visible = false;
                //        label8.Visible = false;
                //        label9.Visible = false;
                //    }
                //    else if (noMusic == 2)
                //    {
                //        label7.Visible = false;
                //        label8.Visible = false;
                //        label9.Visible = false;
                //    }
                //    else if (noMusic == 3)
                //    {
                //        label8.Visible = false;
                //        label9.Visible = false;
                //    }
                //    else if (noMusic == 4)
                //    {
                //        label9.Visible = false;
                //    }
                //    else
                //    {
                //        label5.Visible = true;
                //        label6.Visible = true;
                //        label7.Visible = true;
                //        label8.Visible = true;
                //        label9.Visible = true;
                //    }
                try
                {
                    label5.Text = getFileName(_songs[index + 0]);
                    label6.Text = getFileName(_songs[index + 1]);
                    label7.Text = getFileName(_songs[index + 2]);
                    label8.Text = getFileName(_songs[index + 3]);
                    label9.Text = getFileName(_songs[index + 4]);
                }
                catch (Exception)
                {
                    
                   
                }
                //}
                txtPageCount.Text = (_songs.Count / 5+1).ToString();
            }
        }
        int mpage = 1;
        public void pictureBox13_Click(object sender, EventArgs e)
        {
            if (mpage > 1)
            {
                setMusicList(mpage - 1);
                mpage--;
                txtPageNum.Text = mpage.ToString();
            }
        }

        public void pictureBox12_Click(object sender, EventArgs e)
        {
                if (mpage < (int)_songs.Count / 5 + 1)
                {
                    setMusicList(mpage + 1);
                    mpage++;
                    txtPageNum.Text = mpage.ToString();
                }
        }


        //双击播放列表播放歌曲事件
        private void lable_DoubleClick(object sender, EventArgs e)
        {
            Label lb = (Label)sender;
            try
            {
                play(_songs[(mpage - 1) * 5 + Convert.ToInt32(lb.Tag)]);
                musicNum = (mpage - 1) * 5 + Convert.ToInt32(lb.Tag);
            }
            catch (Exception)
            {
                
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            WindowShowHide();
        }

        private void Form1_Move(object sender, EventArgs e)
        {
            WindowShowHide();
        }
        // 下载于www.mycodes.net
        private void Form1_MouseLeave(object sender, EventArgs e)
        {
            WindowShowHide();
        }
    }
}
