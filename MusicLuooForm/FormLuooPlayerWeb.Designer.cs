namespace MusicLuoo
{
    partial class FormLuooPlayerWeb
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLuooPlayerWeb));
            this.webBrow = new WebKit.WebKitBrowser();
            this.SuspendLayout();
            // 
            // webBrow
            // 
            this.webBrow.BackColor = System.Drawing.Color.White;
            this.webBrow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrow.Location = new System.Drawing.Point(0, 0);
            this.webBrow.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrow.Name = "webBrow";
            this.webBrow.Size = new System.Drawing.Size(1147, 523);
            this.webBrow.TabIndex = 4;
            this.webBrow.Url = new System.Uri("http://www.baidu.com", System.UriKind.Absolute);
            // 
            // FormLuooPlayerWeb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1147, 523);
            this.Controls.Add(this.webBrow);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLuooPlayerWeb";
            this.Text = "FormLuooPlayerWeb";
            this.Load += new System.EventHandler(this.FormLuooPlayerWeb_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private WebKit.WebKitBrowser webBrow;
    }
}