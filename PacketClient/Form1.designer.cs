namespace PacketClient
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label_ip = new System.Windows.Forms.Label();
            this.label_dwn = new System.Windows.Forms.Label();
            this.txt_ip = new System.Windows.Forms.TextBox();
            this.label_port = new System.Windows.Forms.Label();
            this.txt_dwn = new System.Windows.Forms.TextBox();
            this.txt_port = new System.Windows.Forms.TextBox();
            this.btn_svr = new System.Windows.Forms.Button();
            this.btn_path = new System.Windows.Forms.Button();
            this.btn_open = new System.Windows.Forms.Button();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.cmuListView = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDwn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuList = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSmall = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLarge = new System.Windows.Forms.ToolStripMenuItem();
            this.fbd = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lvwFiles = new System.Windows.Forms.ListView();
            this.colorFileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colorFileSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colorFileDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.trvDir = new System.Windows.Forms.TreeView();
            this.cmuListView.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_ip
            // 
            this.label_ip.AutoSize = true;
            this.label_ip.Location = new System.Drawing.Point(25, 20);
            this.label_ip.Name = "label_ip";
            this.label_ip.Size = new System.Drawing.Size(25, 15);
            this.label_ip.TabIndex = 0;
            this.label_ip.Text = "IP:";
            // 
            // label_dwn
            // 
            this.label_dwn.AutoSize = true;
            this.label_dwn.Location = new System.Drawing.Point(25, 51);
            this.label_dwn.Name = "label_dwn";
            this.label_dwn.Size = new System.Drawing.Size(107, 15);
            this.label_dwn.TabIndex = 1;
            this.label_dwn.Text = "다운로드 경로:";
            // 
            // txt_ip
            // 
            this.txt_ip.Location = new System.Drawing.Point(56, 17);
            this.txt_ip.Name = "txt_ip";
            this.txt_ip.Size = new System.Drawing.Size(365, 25);
            this.txt_ip.TabIndex = 2;
            // 
            // label_port
            // 
            this.label_port.AutoSize = true;
            this.label_port.Location = new System.Drawing.Point(445, 20);
            this.label_port.Name = "label_port";
            this.label_port.Size = new System.Drawing.Size(52, 15);
            this.label_port.TabIndex = 3;
            this.label_port.Text = "PORT:";
            // 
            // txt_dwn
            // 
            this.txt_dwn.Location = new System.Drawing.Point(140, 48);
            this.txt_dwn.Name = "txt_dwn";
            this.txt_dwn.ReadOnly = true;
            this.txt_dwn.Size = new System.Drawing.Size(465, 25);
            this.txt_dwn.TabIndex = 4;
            // 
            // txt_port
            // 
            this.txt_port.Location = new System.Drawing.Point(503, 17);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(102, 25);
            this.txt_port.TabIndex = 5;
            // 
            // btn_svr
            // 
            this.btn_svr.Location = new System.Drawing.Point(108, 79);
            this.btn_svr.Name = "btn_svr";
            this.btn_svr.Size = new System.Drawing.Size(101, 32);
            this.btn_svr.TabIndex = 6;
            this.btn_svr.Text = "서버연결";
            this.btn_svr.UseVisualStyleBackColor = true;
            this.btn_svr.Click += new System.EventHandler(this.btn_svr_Click);
            // 
            // btn_path
            // 
            this.btn_path.Location = new System.Drawing.Point(273, 79);
            this.btn_path.Name = "btn_path";
            this.btn_path.Size = new System.Drawing.Size(101, 32);
            this.btn_path.TabIndex = 7;
            this.btn_path.Text = "경로설정";
            this.btn_path.UseVisualStyleBackColor = true;
            this.btn_path.Click += new System.EventHandler(this.btn_path_Click);
            // 
            // btn_open
            // 
            this.btn_open.Location = new System.Drawing.Point(423, 79);
            this.btn_open.Name = "btn_open";
            this.btn_open.Size = new System.Drawing.Size(101, 32);
            this.btn_open.TabIndex = 8;
            this.btn_open.Text = "폴더열기";
            this.btn_open.UseVisualStyleBackColor = true;
            this.btn_open.Click += new System.EventHandler(this.btn_open_Click);
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "avi.png");
            this.imgList.Images.SetKeyName(1, "folder.png");
            this.imgList.Images.SetKeyName(2, "image.png");
            this.imgList.Images.SetKeyName(3, "music.png");
            this.imgList.Images.SetKeyName(4, "temp.png");
            this.imgList.Images.SetKeyName(5, "text.png");
            // 
            // cmuListView
            // 
            this.cmuListView.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmuListView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInfo,
            this.mnuDwn,
            this.toolStripMenuItem1,
            this.mnuDetail,
            this.mnuList,
            this.mnuSmall,
            this.mnuLarge});
            this.cmuListView.Name = "contextMenuStrip1";
            this.cmuListView.Size = new System.Drawing.Size(154, 154);
            // 
            // mnuInfo
            // 
            this.mnuInfo.Name = "mnuInfo";
            this.mnuInfo.Size = new System.Drawing.Size(153, 24);
            this.mnuInfo.Text = "상세정보";
            this.mnuInfo.Click += new System.EventHandler(this.mnuInfo_Click);
            // 
            // mnuDwn
            // 
            this.mnuDwn.Name = "mnuDwn";
            this.mnuDwn.Size = new System.Drawing.Size(153, 24);
            this.mnuDwn.Text = "다운로드";
            this.mnuDwn.Click += new System.EventHandler(this.mnuDwn_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(150, 6);
            // 
            // mnuDetail
            // 
            this.mnuDetail.Name = "mnuDetail";
            this.mnuDetail.Size = new System.Drawing.Size(153, 24);
            this.mnuDetail.Text = "자세히";
            this.mnuDetail.Click += new System.EventHandler(this.mnuView_Click);
            // 
            // mnuList
            // 
            this.mnuList.Name = "mnuList";
            this.mnuList.Size = new System.Drawing.Size(153, 24);
            this.mnuList.Text = "간단히";
            this.mnuList.Click += new System.EventHandler(this.mnuView_Click);
            // 
            // mnuSmall
            // 
            this.mnuSmall.Name = "mnuSmall";
            this.mnuSmall.Size = new System.Drawing.Size(153, 24);
            this.mnuSmall.Text = "작은아이콘";
            this.mnuSmall.Click += new System.EventHandler(this.mnuView_Click);
            // 
            // mnuLarge
            // 
            this.mnuLarge.Name = "mnuLarge";
            this.mnuLarge.Size = new System.Drawing.Size(153, 24);
            this.mnuLarge.Text = "큰아이콘";
            this.mnuLarge.Click += new System.EventHandler(this.mnuView_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label_ip);
            this.panel1.Controls.Add(this.txt_ip);
            this.panel1.Controls.Add(this.label_dwn);
            this.panel1.Controls.Add(this.txt_dwn);
            this.panel1.Controls.Add(this.label_port);
            this.panel1.Controls.Add(this.btn_open);
            this.panel1.Controls.Add(this.txt_port);
            this.panel1.Controls.Add(this.btn_path);
            this.panel1.Controls.Add(this.btn_svr);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(643, 123);
            this.panel1.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lvwFiles);
            this.panel2.Controls.Add(this.splitter1);
            this.panel2.Controls.Add(this.trvDir);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 123);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(643, 339);
            this.panel2.TabIndex = 13;
            // 
            // lvwFiles
            // 
            this.lvwFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colorFileName,
            this.colorFileSize,
            this.colorFileDate});
            this.lvwFiles.ContextMenuStrip = this.cmuListView;
            this.lvwFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwFiles.LargeImageList = this.imgList;
            this.lvwFiles.Location = new System.Drawing.Point(190, 0);
            this.lvwFiles.Name = "lvwFiles";
            this.lvwFiles.Size = new System.Drawing.Size(453, 339);
            this.lvwFiles.SmallImageList = this.imgList;
            this.lvwFiles.TabIndex = 2;
            this.lvwFiles.UseCompatibleStateImageBehavior = false;
            this.lvwFiles.DoubleClick += new System.EventHandler(this.lvwFiles_DoubleClick);
            // 
            // colorFileName
            // 
            this.colorFileName.Text = "파일이름";
            // 
            // colorFileSize
            // 
            this.colorFileSize.Text = "파일크기";
            // 
            // colorFileDate
            // 
            this.colorFileDate.Text = "수정한날짜";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(187, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 339);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // trvDir
            // 
            this.trvDir.Dock = System.Windows.Forms.DockStyle.Left;
            this.trvDir.ImageIndex = 0;
            this.trvDir.ImageList = this.imgList;
            this.trvDir.Location = new System.Drawing.Point(0, 0);
            this.trvDir.Name = "trvDir";
            this.trvDir.SelectedImageIndex = 0;
            this.trvDir.Size = new System.Drawing.Size(187, 339);
            this.trvDir.TabIndex = 0;
            this.trvDir.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvDir_BeforeExpand);
            this.trvDir.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.trvDir_BeforeSelect);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 462);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "File Manager - Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.cmuListView.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_ip;
        private System.Windows.Forms.Label label_dwn;
        private System.Windows.Forms.TextBox txt_ip;
        private System.Windows.Forms.Label label_port;
        private System.Windows.Forms.TextBox txt_dwn;
        private System.Windows.Forms.TextBox txt_port;
        private System.Windows.Forms.Button btn_svr;
        private System.Windows.Forms.Button btn_path;
        private System.Windows.Forms.Button btn_open;
        private System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.ContextMenuStrip cmuListView;
        private System.Windows.Forms.ToolStripMenuItem mnuInfo;
        private System.Windows.Forms.ToolStripMenuItem mnuDwn;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuDetail;
        private System.Windows.Forms.ToolStripMenuItem mnuList;
        private System.Windows.Forms.ToolStripMenuItem mnuSmall;
        private System.Windows.Forms.ToolStripMenuItem mnuLarge;
        private System.Windows.Forms.FolderBrowserDialog fbd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lvwFiles;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TreeView trvDir;
        private System.Windows.Forms.ColumnHeader colorFileName;
        private System.Windows.Forms.ColumnHeader colorFileSize;
        private System.Windows.Forms.ColumnHeader colorFileDate;
    }
}

