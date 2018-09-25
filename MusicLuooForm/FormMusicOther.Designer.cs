namespace MusicLuoo
{
    partial class FormMusicOther
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
            this.txtKey = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.song_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.author = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.album_title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.si_proxycompany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.file_extension = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.file_size = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pic_small = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pic_big = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lrclink = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.file_link = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PictureColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.download = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnDownload = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(22, 12);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(289, 21);
            this.txtKey.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(335, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 27);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "搜索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvData
            // 
            this.dgvData.AllowUserToAddRows = false;
            this.dgvData.AllowUserToDeleteRows = false;
            this.dgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.song_id,
            this.title,
            this.author,
            this.album_title,
            this.si_proxycompany,
            this.file_extension,
            this.file_size,
            this.pic_small,
            this.pic_big,
            this.lrclink,
            this.file_link,
            this.PictureColumn,
            this.download});
            this.dgvData.Location = new System.Drawing.Point(16, 52);
            this.dgvData.Name = "dgvData";
            this.dgvData.ReadOnly = true;
            this.dgvData.RowTemplate.Height = 90;
            this.dgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvData.Size = new System.Drawing.Size(1371, 579);
            this.dgvData.TabIndex = 2;
            this.dgvData.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvData_RowsAdded);
            this.dgvData.SelectionChanged += new System.EventHandler(this.dgvData_SelectionChanged);
            // 
            // song_id
            // 
            this.song_id.DataPropertyName = "song_id";
            this.song_id.HeaderText = "ID";
            this.song_id.Name = "song_id";
            this.song_id.ReadOnly = true;
            // 
            // title
            // 
            this.title.DataPropertyName = "title";
            this.title.HeaderText = "名称";
            this.title.Name = "title";
            this.title.ReadOnly = true;
            // 
            // author
            // 
            this.author.DataPropertyName = "author";
            this.author.HeaderText = "作家";
            this.author.Name = "author";
            this.author.ReadOnly = true;
            // 
            // album_title
            // 
            this.album_title.DataPropertyName = "album_title";
            this.album_title.HeaderText = "专辑名";
            this.album_title.Name = "album_title";
            this.album_title.ReadOnly = true;
            // 
            // si_proxycompany
            // 
            this.si_proxycompany.DataPropertyName = "si_proxycompany";
            this.si_proxycompany.HeaderText = "出品公司";
            this.si_proxycompany.Name = "si_proxycompany";
            this.si_proxycompany.ReadOnly = true;
            // 
            // file_extension
            // 
            this.file_extension.DataPropertyName = "file_extension";
            this.file_extension.HeaderText = "文件类型";
            this.file_extension.Name = "file_extension";
            this.file_extension.ReadOnly = true;
            // 
            // file_size
            // 
            this.file_size.DataPropertyName = "file_size";
            this.file_size.HeaderText = "文件大小";
            this.file_size.Name = "file_size";
            this.file_size.ReadOnly = true;
            // 
            // pic_small
            // 
            this.pic_small.DataPropertyName = "pic_small";
            this.pic_small.HeaderText = "小图";
            this.pic_small.Name = "pic_small";
            this.pic_small.ReadOnly = true;
            // 
            // pic_big
            // 
            this.pic_big.DataPropertyName = "pic_big";
            this.pic_big.HeaderText = "大图";
            this.pic_big.Name = "pic_big";
            this.pic_big.ReadOnly = true;
            // 
            // lrclink
            // 
            this.lrclink.DataPropertyName = "lrclink";
            this.lrclink.HeaderText = "歌词";
            this.lrclink.Name = "lrclink";
            this.lrclink.ReadOnly = true;
            // 
            // file_link
            // 
            this.file_link.DataPropertyName = "file_link";
            this.file_link.HeaderText = "文件下载";
            this.file_link.Name = "file_link";
            this.file_link.ReadOnly = true;
            // 
            // PictureColumn
            // 
            this.PictureColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PictureColumn.HeaderText = "图片";
            this.PictureColumn.Name = "PictureColumn";
            this.PictureColumn.ReadOnly = true;
            this.PictureColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PictureColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.PictureColumn.Width = 54;
            // 
            // download
            // 
            this.download.HeaderText = "下载";
            this.download.Name = "download";
            this.download.ReadOnly = true;
            this.download.Text = "下载";
            this.download.UseColumnTextForButtonValue = true;
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(427, 8);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 27);
            this.btnDownload.TabIndex = 3;
            this.btnDownload.Text = "下载";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // FormMusicOther
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1405, 643);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtKey);
            this.Name = "FormMusicOther";
            this.Text = "FormMusicOther";
            this.Load += new System.EventHandler(this.FormMusicOther_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.DataGridViewTextBoxColumn song_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn title;
        private System.Windows.Forms.DataGridViewTextBoxColumn author;
        private System.Windows.Forms.DataGridViewTextBoxColumn album_title;
        private System.Windows.Forms.DataGridViewTextBoxColumn si_proxycompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn file_extension;
        private System.Windows.Forms.DataGridViewTextBoxColumn file_size;
        private System.Windows.Forms.DataGridViewTextBoxColumn pic_small;
        private System.Windows.Forms.DataGridViewTextBoxColumn pic_big;
        private System.Windows.Forms.DataGridViewTextBoxColumn lrclink;
        private System.Windows.Forms.DataGridViewTextBoxColumn file_link;
        private System.Windows.Forms.DataGridViewImageColumn PictureColumn;
        private System.Windows.Forms.DataGridViewButtonColumn download;
        private System.Windows.Forms.Button btnDownload;
    }
}