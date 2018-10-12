using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using MusicLuooUnity;
using WMPLib;

namespace MumiMusic
{
    public partial class FormMain : Form
    {
        private Thread thread1;
        set_Text setLrcText;
        set_Text setLableLrc;

        delegate void set_Text(string s);

        ShowLrc lrc = new ShowLrc();
        Lrc L = new Lrc();

        bool plays = false;
        bool isplay = false;
        private DateTime _playStartTime;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        protected static extern bool AnimateWindow(IntPtr hWnd, int dwTime, int dwFlags);

        public const Int32 AW_BLEND = 0x00080000;
        public const Int32 AW_CENTER = 0x00000010;
        public const Int32 AW_ACTIVATE = 0x00020000;
        public const Int32 AW_HIDE = 0x00010000;
        public const Int32 AW_SLIDE = 0x00040000;

        [DllImport("User32.dll")]
        public static extern bool PtInRect(ref Rectangle Rects, Point lpPoint);

        public FormMain()
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

        private void FormMain_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }

        #endregion


        private void FormMain_Load(object sender, EventArgs e)
        {
            AnimateWindow(this.Handle, 500, AW_BLEND | AW_CENTER | AW_ACTIVATE);
            setLrcText = new set_Text(set_lableText);
            setLableLrc = new set_Text(set_lableLrc);
            thread1 = new Thread(new ThreadStart(SerchLrc));
            GetMusicList();
            setVoice(100);
            try
            {

                this.axPlayer.settings.volume = 100; //初始化声音为35
                play(_songs[0]);
                isplay = true;
            }
            catch (Exception)
            {

                isplay = false;
            }
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


        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region 按钮颜色变化

        private void btnPrev_MouseEnter(object sender, EventArgs e)
        {
            btnPrev.Image = Properties.Resources.preview_down;
        }

        private void btnPlay_MouseEnter(object sender, EventArgs e)
        {
            if (plays == false)
            {
                btnPlay.Image = Properties.Resources.play_down;
            }
            else
            {
                btnPlay.Image = Properties.Resources.pause_down;
            }

        }

        private void btnNext_MouseEnter(object sender, EventArgs e)
        {
            btnNext.Image = Properties.Resources.next_down;
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.Image = Properties.Resources.favorite_down;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Image = Properties.Resources.favorite_on;
        }

        private void btnNext_MouseLeave(object sender, EventArgs e)
        {
            btnNext.Image = Properties.Resources.next_on;
        }

        private void btnPlay_MouseLeave(object sender, EventArgs e)
        {
            if (plays == false)
            {
                btnPlay.Image = Properties.Resources.play_on;
            }
            else
            {
                btnPlay.Image = Properties.Resources.pause_on;
            }

        }

        private void btnPrev_MouseLeave(object sender, EventArgs e)
        {
            btnPrev.Image = Properties.Resources.preview_on;
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
        int[] musicNum = {4,3,2,1,0};
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
            thread1.Start();
            isplay = true;
            plays = true;
            timerPlayState.Enabled = true;
            getmusicTime();
            _playStartTime = DateTime.Now;
            if (plays == true)
            {
                btnPlay.Image = Properties.Resources.pause_on;
            }

            if (!string.IsNullOrEmpty(namepath.ImgUrl))
            {
                this.BackgroundImage = Image.FromStream(System.Net.WebRequest.Create(namepath.ImgUrl).GetResponse().GetResponseStream());
            }
            lbSongName.Text = getFileName(namepath);

            for (int i = 0; i < lvSong.Items.Count; i++)
            {
                if (lvSong.Items[i].SubItems[3].Text.ToString() == namepath.SongNo.ToString())
                {
                    lvSong.Items[i].Selected = true;//选中行
                    lvSong.EnsureVisible(i);//滚动到指定的行位置
                    break;
                }
            }

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
            if (_songs != null)
            {
                int index = 1;

                lvSong.BeginUpdate();
                foreach (var s in _songs)
                {
                    ListViewItem lv = new ListViewItem();
                    lv.Text = s.SongName;
                    lv.SubItems.Add(s.Author);
                    lv.SubItems.Add(s.AlbumName);
                    lv.SubItems.Add(s.SongNo.ToString());
                    lvSong.Items.Add(lv);
                    index++;
                }
                lvSong.EndUpdate();
            }
        }


        private void btnPlay_Click(object sender, EventArgs e)
        {

            if (plays == false)
            {
                this.axPlayer.Ctlcontrols.play();
                timerPlayState.Enabled = true;
                btnPlay.Image = Properties.Resources.pause_down;
                plays = true;
            }
            else
            {
                btnPlay.Image = Properties.Resources.play_down;
                this.axPlayer.Ctlcontrols.pause();
                timerPlayState.Enabled = false;
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

        private void timerPlayState_Tick(object sender, EventArgs e)
        {
            if (isplay)
            {
                getmusicTime();
                this.label1.Text = this.axPlayer.Ctlcontrols.currentPositionString;
                this.label2.Text = this.axPlayer.currentMedia.durationString;
                //已完成，或1.5s后仍然是ready状态（播放的url无效的情况）
                if (axPlayer.playState == WMPPlayState.wmppsStopped || (axPlayer.playState == WMPPlayState.wmppsReady && (DateTime.Now - _playStartTime).TotalSeconds >= 1.5))
                {
                    label1.Text = "00:00";
                    try
                    {
                        btnNext_Click(null, null);
                    }
                    catch (Exception)
                    {
                        timerPlayState.Enabled = false;
                    }
                }
                else if (axPlayer.playState.ToString() == "" && (DateTime.Now - _playStartTime).TotalSeconds > 2)
                {
                    
                }
            }
        }


        private void btnPrev_Click(object sender, EventArgs e)
        {
            GetPlayIndex(false);
            try
            {
                play(_songs[musicNum.Last()]);
            }
            catch (Exception)
            {
                GetPlayIndex(false);
            }
        }

        private void GetPlayIndex(bool next)
        {
            int index = musicNum.Last();
            string txt = btnPlayNextType.Text;
            if (txt == "随机")
            {
                Random ran = new Random();
                index = ran.Next(_songs.Count - 1);
                while (musicNum.Contains(index))
                {
                    index = ran.Next(_songs.Count - 1);
                }
            }
            else if (txt == "循环")
            {
                index = next ? index++ : index--;
                if (index < 0)
                    index = _songs.Count - 1;
                if (index >= _songs.Count)
                {
                    index = 0;
                }
            }
            else
            {
            }
            musicNum[4] = index;
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

        private void btnNext_Click(object sender, EventArgs e)
        {
            GetPlayIndex(true);
            try
            {
                play(_songs[musicNum.Last()]);
            }
            catch (Exception)
            {
                GetPlayIndex(true);
            }
        }

        private void small_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
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
        

        private void FormMain_MouseMove(object sender, MouseEventArgs e)
        {
            WindowShowHide();
        }

        private void FormMain_Move(object sender, EventArgs e)
        {
            WindowShowHide();
        }
       
        private void FormMain_MouseLeave(object sender, EventArgs e)
        {
            WindowShowHide();
        }

        private void lvSong_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < lvSong.Items.Count; i++)
            {
                if (lvSong.Items[i].Selected)
                {
                    play(_songs[i]);
                    break;
                }
            }
        }

        private void btnPlayNextType_Click(object sender, EventArgs e)
        {
            string txt = btnPlayNextType.Text;
            if (txt == "随机")
            {
                txt = "循环";
            }
            else if (txt == "循环")
            {
                txt = "单循";
            }
            else
            {
                txt = "随机";
            }
            btnPlayNextType.Text = txt;
        }
    }
}
