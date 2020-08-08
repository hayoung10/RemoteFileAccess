using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;
using System.Net.Sockets;
using System.IO; // DirectoryInfo FileInfo 사용
using System.Diagnostics;

namespace PacketClient
{
    public partial class Form1 : Form
    {
        private NetworkStream m_networkstream;
        private TcpClient m_client;

        private byte[] sendBuffer = new byte[1024 * 4];
        private byte[] readBuffer = new byte[1024 * 4];

        private bool m_bConnect = false;
        private bool m_path = false; // 경로를 선택했을 시 true
        private bool m_svrConnect = false; // "서버연결"-true, "서버끊기"-false

        public Initialize m_initializeClass;
        public Browser m_browserPath;

        private string ServerPath = null; // 서버에서 "경로선택"으로 택한 PATH

        public Form1()
        {
            InitializeComponent();
        }

        public void Send()
        {
            this.m_networkstream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
            this.m_networkstream.Flush(); // 버퍼 전송한 뒤 버퍼를 비우기

            for (int i = 0; i < 1024 * 4; i++)
                this.sendBuffer[i] = 0;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.m_client.Close();
            this.m_networkstream.Close();
        }

        private void btn_svr_Click(object sender, EventArgs e)
        {
            if (!this.m_path) // 경로를 선택하지 않고 서버연결 버튼을 눌렀을 경우
                MessageBox.Show("경로를 선택해주세요", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (!this.m_svrConnect)
                {
                    this.m_client = new TcpClient();
                    try
                    {
                        this.m_client.Connect(this.txt_ip.Text, Int32.Parse(this.txt_port.Text));
                        this.btn_svr.Text = "서버끊기"; // "서버연결" 버튼 클릭 시 -> 텍스트 "서버끊기"로 바꾸기
                        this.btn_svr.ForeColor = Color.Red;
                        this.m_svrConnect = true;
                    }
                    catch
                    {
                        MessageBox.Show("접속 에러");
                        return;
                    }
                    this.m_bConnect = true;
                    this.m_networkstream = this.m_client.GetStream(); // 클라이언트 스트림 가져오기

                    if (!this.m_bConnect)
                        return;

                    Initialize Init = new Initialize();
                    Init.Type = (int)PacketType.초기화; // 서버에게 초기화 데이터 요청
                    Init.buffer = "초기화 데이터 요청..";

                    Packet.Serialize(Init).CopyTo(this.sendBuffer, 0);
                    this.Send(); // 버퍼 보내기

                    int nRead = 0;
                    if (this.m_bConnect)
                    {
                        try
                        {
                            nRead = 0;
                            nRead = this.m_networkstream.Read(readBuffer, 0, 1024 * 4); // 네트워크에서 스트림 읽기
                        }
                        catch
                        {
                            this.m_bConnect = false;
                            this.m_networkstream = null;
                        }
                        Packet packet = (Packet)Packet.Desserialize(this.readBuffer);
                        if ((int)packet.Type == (int)PacketType.초기화) // 서버에게 초기화 요청이 확인되었을 경우
                        {
                            this.m_initializeClass = (Initialize)Packet.Desserialize(this.readBuffer);
                            this.Invoke(new MethodInvoker(delegate ()
                            {
                                ServerPath = this.m_initializeClass.buffer; // 서버에서 설정된 경로 받아오기
                            }));
                            TreeNode root = trvDir.Nodes.Add(ServerPath); // treeview에 경로명으로 노드 추가
                            root.ImageIndex = 1; // 폴더 ICON 설정
                            trvDir.SelectedNode = root; // treeview에 선택된 노드는 루트
                            root.SelectedImageIndex = root.ImageIndex;
                            root.Nodes.Add("");
                        }
                    }
                }
                else
                {
                    this.m_bConnect = false;
                    this.m_svrConnect = false;
                    this.m_client.Close();
                    this.m_networkstream.Close();
                }   
            }
            if (!m_path) // 경로 설정이 안 되어 있을 시
            {
                this.btn_svr.Text = "서버켜기";
                this.btn_svr.ForeColor = Color.Black;
            }
        }

        private void btn_path_Click(object sender, EventArgs e)
        {
            if(fbd.ShowDialog() == DialogResult.OK)
            {
                this.txt_dwn.Text = fbd.SelectedPath; // folder browser dialog으로 선택한 경로 textbox에 삽입
                m_path = true;
            }
        }

        public void setPlus(TreeNode node)
        {
            if (m_bConnect)
            {
                Browser Brows = new Browser();
                Brows.Type = (int)PacketType.탐색기;
                Brows.fullpath = node.FullPath; // 해당 경로에 대한 파일탐색 요청하기

                Packet.Serialize(Brows).CopyTo(this.sendBuffer, 0);
                this.Send(); // 버퍼 보내기

                int nRead = 0;
                try
                {
                    nRead = 0;
                    nRead = this.m_networkstream.Read(readBuffer, 0, 1024 * 4); // 네트워크에서 스트림 읽기
                }
                catch
                {
                    this.m_bConnect = false;
                    this.m_networkstream = null;
                }
                Packet packet = (Packet)Packet.Desserialize(this.readBuffer);
                if((int)packet.Type == (int)PacketType.탐색기) // 파일탐색 결과 받기
                {
                    this.m_browserPath = (Browser)Packet.Desserialize(this.readBuffer);
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                        if (this.m_browserPath.di.Length > 0) // 하위 디렉토리 존재 시 노드 확장
                            node.Nodes.Add("");
                    }));
                }
            }
        }

        public void OpenFiles() // 파일 열기
        {
            ListView.SelectedListViewItemCollection siList = lvwFiles.SelectedItems;

            foreach (ListViewItem item in siList)
                OpenItem(item);
        }

        public void OpenItem(ListViewItem item)
        {
            TreeNode node = trvDir.SelectedNode;
            TreeNode child;

            if (item.Tag.ToString() == "D") // 선택된 아이템이 디렉토리일 경우
            {
                node.Expand();
                child = node.FirstNode;

                while(child!=null) // 선택된 디렉토리의 하위 파일들을 트리구조로 노드에 삽입
                {
                    if(child.Text == item.Text)
                    {
                        trvDir.SelectedNode = child;
                        trvDir.Focus();
                        break;
                    }
                    child = child.NextNode;
                }
            }
            else if (item.Tag.ToString() == "F") // 선택된 아이템이 파일일 경우
            {
                if (m_bConnect)
                {
                    Detail dt = new Detail();
                    dt.Type = (int)PacketType.상세화; // 상세정보 요청하기
                    dt.message = "상세정보 데이터 요청..";

                    Packet.Serialize(dt).CopyTo(this.sendBuffer, 0);
                    this.Send(); // 버퍼 보내기

                    string path = node.FullPath + "\\" + item.Text;
                    DetailForm df = new DetailForm();
                    df.fis = new FileInfo(path); // 파일 정보 넘기기
                    df.num = 2; // 파일임을 알리기
                    df.Show(); // DetailForm 열기
                }
            }
        }

        public int fileImage(string path) // 파일에서 ICON 선택
        {
            int index = 0;
            string type = path.Substring(path.Length - 4); // 경로에서 파일 확장자 추출
            switch (type) // 파일 확장자 알아내기
            {
                case ".avi":
                        index = 0; break;
                case ".png":
                        index = 2; break;
                case ".mp3":
                        index = 3; break;
                case ".txt":
                        index = 5; break;
                default:
                        index = 4; break;
            }
            return index; // 파일 확장자에 맞는 imagelist의 index 리턴
        }

        private void trvDir_BeforeExpand(object sender, TreeViewCancelEventArgs e) // treeview의 확장버튼 클릭 시
        {
            TreeNode node;

            if (m_bConnect)
            {
                e.Node.Nodes.Clear();

                Browser Brows = new Browser();
                Brows.Type = (int)PacketType.탐색기;
                Brows.message = "beforeExpand 데이터 요청..";
                Brows.num = 1; // beforeExpand에서의 요청임을 알리기
                Brows.fullpath = e.Node.FullPath; // 해당 경로에 대한 파일탐색 요청하기

                Packet.Serialize(Brows).CopyTo(this.sendBuffer, 0);
                this.Send(); // 버퍼 보내기

                int nRead = 0;
                try
                {
                    nRead = 0;
                    nRead = this.m_networkstream.Read(readBuffer, 0, 1024 * 4); // 네트워크에서 스트림 읽기
                }
                catch
                {
                    this.m_bConnect = false;
                    this.m_networkstream = null;
                }
                Packet packet = (Packet)Packet.Desserialize(this.readBuffer);
                if ((int)packet.Type == (int)PacketType.탐색기) // 파일탐색 결과 받기
                {
                    this.m_browserPath = (Browser)Packet.Desserialize(this.readBuffer);
                    this.Invoke(new MethodInvoker(delegate ()
                   {
                       foreach (DirectoryInfo dirs in this.m_browserPath.di) // 하위 디렉토리 리스트 검사
                       {
                           node = e.Node.Nodes.Add(dirs.Name); // 하위 디렉토리들을 트리구조로 노드에 삽입
                           setPlus(node);
                       }
                   }));
                }
            }
        }

        private void trvDir_BeforeSelect(object sender, TreeViewCancelEventArgs e) // treeview의 메뉴 선택 시
        {
            ListViewItem item;

            if (m_bConnect)
            {
                Browser Brows = new Browser();
                Brows.Type = (int)PacketType.탐색기;
                Brows.message = "beforeSelect 데이터 요청..";
                Brows.num = 2; // beforeSelect에서의 요청임을 알리기
                Brows.fullpath = e.Node.FullPath; // 해당 경로에 대한 파일탐색 요청하기

                Packet.Serialize(Brows).CopyTo(this.sendBuffer, 0);
                this.Send(); // 버퍼 보내기

                lvwFiles.Items.Clear();

                int nRead = 0;
                try
                {
                    nRead = 0;
                    nRead = this.m_networkstream.Read(readBuffer, 0, 1024 * 4); // 네트워크에서 스트림 읽기
                }
                catch
                {
                    this.m_bConnect = false;
                    this.m_networkstream = null;
                }
                Packet packet = (Packet)Packet.Desserialize(this.readBuffer);
                if ((int)packet.Type == (int)PacketType.탐색기) // 파일탐색 결과 받기
                {
                    this.m_browserPath = (Browser)Packet.Desserialize(this.readBuffer);
                    this.Invoke(new MethodInvoker(delegate ()
                    {
                    }));
                    foreach (DirectoryInfo tdis in this.m_browserPath.di) // 하위 디렉토리 리스트 검사
                    {
                        item = lvwFiles.Items.Add(tdis.Name); // listview에 디렉토리명으로 아이템 삽입
                        item.SubItems.Add(""); // 디렉터리의 크기는 표시하지 않음
                        item.SubItems.Add(tdis.LastWriteTime.ToString()); // 수정한 날짜 설정
                        item.ImageIndex = 1; // 폴더 ICON으로 설정
                        item.Tag = "D"; // 디렉토리임을 알리는 "D" 태그 설정
                    }
                    foreach (FileInfo fis in this.m_browserPath.fi) // 하위 파일 리스트 검사
                    {
                        item = lvwFiles.Items.Add(fis.Name); // listview에 파일명으로 아이템 삽입
                        item.SubItems.Add(fis.Length.ToString()); // 크기(byte) 설정
                        item.SubItems.Add(fis.LastWriteTime.ToString()); // 수정한 날짜 설정
                        item.ImageIndex = fileImage(fis.Name); // 파일 ICON 설정
                        item.Tag = "F"; // 파일임을 알리는 "F" 태그 설정

                    }
                }
            }
        }

        private void lvwFiles_DoubleClick(object sender, EventArgs e)
        {
            OpenFiles(); // 파일 열기
        }

        private void mnuView_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            mnuDetail.Checked = false;
            mnuList.Checked = false;
            mnuSmall.Checked = false;
            mnuLarge.Checked = false;

            switch (item.Text)
            {
                case "자세히":
                    mnuDetail.Checked = true;
                    lvwFiles.View = View.Details;
                    break;
                case "간단히":
                    mnuList.Checked = true;
                    lvwFiles.View = View.List;
                    break;
                case "작은아이콘":
                    mnuSmall.Checked = true;
                    lvwFiles.View = View.SmallIcon;
                    break;
                case "큰아이콘":
                    mnuLarge.Checked = true;
                    lvwFiles.View = View.LargeIcon;
                    break;
            }
        }

        private void mnuInfo_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection siList = lvwFiles.SelectedItems;
            ListViewItem item;
            TreeNode node = trvDir.SelectedNode;

            if (siList.Count == 1) // 선택된 아이템이 1개일 때 실행
            {
                item = siList[0];

                if (m_bConnect)
                {
                    Detail dt = new Detail();
                    dt.Type = (int)PacketType.상세화; // 상세정보 요청하기
                    dt.message = "상세정보 데이터 요청..";

                    Packet.Serialize(dt).CopyTo(this.sendBuffer, 0);
                    this.Send(); // 버퍼 보내기

                    string path = node.FullPath + "\\" + item.Text;
                    DetailForm df = new DetailForm();
                    if (item.Tag.ToString() == "D") // 아이템이 디렉토리일 경우
                    {
                        df.tdis = new DirectoryInfo(path); // 디렉토리 정보 넘기기
                        df.num = 1; // 디렉토리임을 알리기
                    }
                    else if (item.Tag.ToString() == "F") // 아이템이 파일일 경우
                    {
                        df.fis = new FileInfo(path); // 파일 정보 넘기기
                        df.num = 2; // 파일임을 알리기
                    }
                    df.Show(); // DetailForm 열기
                }
            }   
        }

        private void btn_open_Click(object sender, EventArgs e)
        {
            if (!this.m_path) // 경로를 선택하지 않고 폴더열기 버튼을 눌렀을 경우
                MessageBox.Show("경로를 선택해주세요", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                Process.Start(this.txt_dwn.Text); // 설정한 경로위치로 폴더 열기
        }

        private void mnuDwn_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection siList = lvwFiles.SelectedItems;
            ListViewItem item;
            TreeNode node = trvDir.SelectedNode;

            if (siList.Count == 1) // 선택된 아이템이 1개일 때 실행
            {
                item = siList[0];
                string path = node.FullPath + "\\" + item.Text;

                if (item.Tag.ToString() == "D") // 아이템이 디렉토리일 경우 - 다운로드를 지원하지 않음을 알리기
                {
                    MessageBox.Show("폴더는 다운로드를 지원하지 않습니다", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (item.Tag.ToString() == "F") // 아이템이 폴더일 경우
                {
                    try
                    {
                        File.Copy(path, this.txt_dwn.Text + "\\" + item.Text, true); // 아이템을 설정한 경로로 복사
                    }
                    catch
                    {
                        MessageBox.Show("다운로드 에러");
                        return;
                    }
                    if (m_bConnect)
                    {
                        Detail dt = new Detail();
                        dt.Type = (int)PacketType.상세화; // 다운로드 요청하기
                        dt.message = path + " 데이터 다운로드 완료..."; // 다운로드가 되었음을 알리기

                        Packet.Serialize(dt).CopyTo(this.sendBuffer, 0);
                        this.Send(); // 버퍼 보내기
                    }
                }
            }
        }
    }
}