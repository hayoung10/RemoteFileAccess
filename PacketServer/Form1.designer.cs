namespace PacketServer
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
            this.label_ip = new System.Windows.Forms.Label();
            this.label_port = new System.Windows.Forms.Label();
            this.label_path = new System.Windows.Forms.Label();
            this.txt_ip = new System.Windows.Forms.TextBox();
            this.txt_port = new System.Windows.Forms.TextBox();
            this.txt_path = new System.Windows.Forms.TextBox();
            this.btn_svr = new System.Windows.Forms.Button();
            this.btn_path = new System.Windows.Forms.Button();
            this.log = new System.Windows.Forms.GroupBox();
            this.txt_log = new System.Windows.Forms.TextBox();
            this.fbd = new System.Windows.Forms.FolderBrowserDialog();
            this.log.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_ip
            // 
            this.label_ip.AutoSize = true;
            this.label_ip.Location = new System.Drawing.Point(35, 9);
            this.label_ip.Name = "label_ip";
            this.label_ip.Size = new System.Drawing.Size(20, 15);
            this.label_ip.TabIndex = 1;
            this.label_ip.Text = "IP";
            // 
            // label_port
            // 
            this.label_port.AutoSize = true;
            this.label_port.Location = new System.Drawing.Point(24, 50);
            this.label_port.Name = "label_port";
            this.label_port.Size = new System.Drawing.Size(47, 15);
            this.label_port.TabIndex = 2;
            this.label_port.Text = "PORT";
            // 
            // label_path
            // 
            this.label_path.AutoSize = true;
            this.label_path.Location = new System.Drawing.Point(24, 91);
            this.label_path.Name = "label_path";
            this.label_path.Size = new System.Drawing.Size(44, 15);
            this.label_path.TabIndex = 3;
            this.label_path.Text = "PATH";
            // 
            // txt_ip
            // 
            this.txt_ip.Location = new System.Drawing.Point(81, 6);
            this.txt_ip.Name = "txt_ip";
            this.txt_ip.Size = new System.Drawing.Size(382, 25);
            this.txt_ip.TabIndex = 4;
            // 
            // txt_port
            // 
            this.txt_port.Location = new System.Drawing.Point(81, 47);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(382, 25);
            this.txt_port.TabIndex = 5;
            // 
            // txt_path
            // 
            this.txt_path.Location = new System.Drawing.Point(81, 88);
            this.txt_path.Name = "txt_path";
            this.txt_path.ReadOnly = true;
            this.txt_path.Size = new System.Drawing.Size(382, 25);
            this.txt_path.TabIndex = 6;
            // 
            // btn_svr
            // 
            this.btn_svr.Location = new System.Drawing.Point(488, 23);
            this.btn_svr.Name = "btn_svr";
            this.btn_svr.Size = new System.Drawing.Size(103, 42);
            this.btn_svr.TabIndex = 7;
            this.btn_svr.Text = "서버켜기";
            this.btn_svr.UseVisualStyleBackColor = true;
            this.btn_svr.Click += new System.EventHandler(this.btn_svr_Click);
            // 
            // btn_path
            // 
            this.btn_path.Location = new System.Drawing.Point(488, 88);
            this.btn_path.Name = "btn_path";
            this.btn_path.Size = new System.Drawing.Size(103, 23);
            this.btn_path.TabIndex = 8;
            this.btn_path.Text = "경로선택";
            this.btn_path.UseVisualStyleBackColor = true;
            this.btn_path.Click += new System.EventHandler(this.btn_path_Click);
            // 
            // log
            // 
            this.log.Controls.Add(this.txt_log);
            this.log.Location = new System.Drawing.Point(12, 130);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(585, 311);
            this.log.TabIndex = 9;
            this.log.TabStop = false;
            this.log.Text = "log";
            // 
            // txt_log
            // 
            this.txt_log.Location = new System.Drawing.Point(6, 24);
            this.txt_log.Multiline = true;
            this.txt_log.Name = "txt_log";
            this.txt_log.Size = new System.Drawing.Size(573, 281);
            this.txt_log.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 453);
            this.Controls.Add(this.log);
            this.Controls.Add(this.btn_path);
            this.Controls.Add(this.btn_svr);
            this.Controls.Add(this.txt_path);
            this.Controls.Add(this.txt_port);
            this.Controls.Add(this.txt_ip);
            this.Controls.Add(this.label_path);
            this.Controls.Add(this.label_port);
            this.Controls.Add(this.label_ip);
            this.Name = "Form1";
            this.Text = "File Manager - Server";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.log.ResumeLayout(false);
            this.log.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_ip;
        private System.Windows.Forms.Label label_port;
        private System.Windows.Forms.Label label_path;
        private System.Windows.Forms.TextBox txt_ip;
        private System.Windows.Forms.TextBox txt_port;
        private System.Windows.Forms.TextBox txt_path;
        private System.Windows.Forms.Button btn_svr;
        private System.Windows.Forms.Button btn_path;
        private System.Windows.Forms.GroupBox log;
        private System.Windows.Forms.TextBox txt_log;
        private System.Windows.Forms.FolderBrowserDialog fbd;
    }
}

