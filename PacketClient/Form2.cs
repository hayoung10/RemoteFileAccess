using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; // DirectoryInfo FileInfo 사용

namespace PacketClient
{
    public partial class DetailForm : Form
    {
        public DirectoryInfo tdis;
        public FileInfo fis;
        public int num = 0;

        public DetailForm()
        {
            InitializeComponent();
        }

        private void DetailForm_Load(object sender, EventArgs e)
        {
            if (num == 1) // 디렉토리인 경우
            {
                this.pictureBox1.Image = imageList1.Images[1]; // 폴더 ICON 이미지
                this.txt_name.Text = tdis.Name; // 디렉토리명
                this.label_type2.Text = tdis.Name.Substring(tdis.Name.Length - 3); // 파일 형식
                this.label_loc2.Text = tdis.FullName; // 위치
                this.label_size2.Text = ""; // 크기
                this.label_made2.Text = tdis.CreationTime.ToString(); // 만든 날짜
                this.label_mod2.Text = tdis.LastWriteTime.ToString(); // 수정한 날짜
                this.label_acc2.Text = tdis.LastAccessTime.ToString(); // 엑세스한 날짜
            }
            else if (num == 2) // 파일인 경우
            {
                this.txt_name.Text = fis.Name; // 파일명
                string type = fis.Name.Substring(fis.Name.Length - 4); // 경로에서 파일 확장자 추출
                switch (type) // 파일 확장자 알아내기
                {
                    case ".avi":
                        this.pictureBox1.Image = imageList1.Images[0]; break;
                    case ".png":
                        this.pictureBox1.Image = imageList1.Images[2]; break;
                    case ".mp3":
                        this.pictureBox1.Image = imageList1.Images[3]; break;
                    case ".txt":
                        this.pictureBox1.Image = imageList1.Images[5]; break;
                    default:
                        this.pictureBox1.Image = imageList1.Images[4]; break;
                }
                this.label_type2.Text = type.Substring(1); // 파일 형식
                this.label_loc2.Text = fis.FullName; // 위치
                this.label_size2.Text = fis.Length.ToString() + " 바이트"; // 크기
                this.label_made2.Text = fis.CreationTime.ToString(); // 만든 날짜
                this.label_mod2.Text = fis.LastWriteTime.ToString(); // 수정한 날짜
                this.label_acc2.Text = fis.LastAccessTime.ToString(); // 엑세스한 날짜
            }
        }

        private void btn_check_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}