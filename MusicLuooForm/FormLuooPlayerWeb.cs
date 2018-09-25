using System;
using System.Windows.Forms;
using MusicLuooUnity;

namespace MusicLuoo
{
    public partial class FormLuooPlayerWeb : Form
    {
        public FormLuooPlayerWeb()
        {
            InitializeComponent();
        }

        private void FormLuooPlayerWeb_Load(object sender, EventArgs e)
        {
            //Consts.MusicLuooUrl
            webBrow.Navigate("http://10.100.17.89:9008/index.aspx?c=100");
        }
    }
}
