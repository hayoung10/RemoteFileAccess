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
using System.Threading;
using System.Net; // IPAddress 사용
using System.IO; // DirectoryInfo FileInfo 사용

namespace PacketServer
{
    public partial class Form1 : Form
    {
        private NetworkStream m_networkstream;
        private TcpListener m_listener;

        private byte[] sendBuffer = new byte[1024 * 4];
        private byte[] readBuffer = new byte[1024 * 4];

        private bool m_bClientOn = false;
        private bool m_path = false; // 경로를 선택했을 시 true
        public string CurrentPath = null; // "경로선택"으로 택한 PATH

        private Thread m_thread;

        public Initialize m_initializeClass;
        public Browser m_browserClass;
        public Detail m_detailClass;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void btn_path_Click(object sender, EventArgs e)
        {
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                this.txt_path.Text = fbd.SelectedPath; // folder browser dialog으로 선택한 경로 textbox에 삽입
                CurrentPath = this.txt_path.Text;
                this.txt_log.AppendText(fbd.SelectedPath + "로 경로가 수정되었습니다." + Environment.NewLine); // log 창에 선택한 경로 출력
                m_path = true;
            }
        }

        public void Send()
        {
            this.m_networkstream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
            this.m_networkstream.Flush(); // 버퍼 전송한 뒤 버퍼를 비우기

            for (int i = 0; i < 1024 * 4; i++)
                this.sendBuffer[i] = 0;
        }

        public void RUN()
        {
            this.m_listener = new TcpListener(IPAddress.Parse(this.txt_ip.Text),Int32.Parse(this.txt_port.Text));
            this.m_listener.Start();

            if (!this.m_bClientOn)
            {
                this.Invoke(new MethodInvoker(delegate ()
                {
                    this.txt_log.AppendText("클라이언트 접속 대기중..." + Environment.NewLine);
                }));
                this.btn_svr.Text = "서버끊기"; // "서버켜기" 버튼 클릭 시 -> 텍스트 "서버끊기"로 바꾸기
                this.btn_svr.ForeColor = Color.Red;
            }

            TcpClient client = this.m_listener.AcceptTcpClient(); // 클라이언트와 접속

            if (client.Connected) // 클라이언트 연결 시
            {
                this.m_bClientOn = true;
                this.Invoke(new MethodInvoker(delegate ()
                {
                    this.txt_log.AppendText("클라이언트 접속" + Environment.NewLine);
                }));
                m_networkstream = client.GetStream(); // 클라이언트 스트림 가져오기
            }

            int nRead = 0;
            while (this.m_bClientOn) // 클라이언트와 연결 중인 동안 실행
            {
                try
                {
                    nRead = 0;
                    nRead = this.m_networkstream.Read(readBuffer, 0, 1024 * 4); // 네트워크에서 스트림 읽기
                }
                catch
                {
                    this.m_bClientOn = false;
                    this.txt_ip.AppendText("close");
                    this.m_networkstream = null;
                }
                if (nRead == 0)
                    this.m_bClientOn = false;
                else
                {
                    Packet packet = (Packet)Packet.Desserialize(this.readBuffer);

                    switch ((int)packet.Type)
                    {
                        case (int)PacketType.초기화: // 초기화 데이터 요청 시
                            {
                                this.m_initializeClass = (Initialize)Packet.Desserialize(this.readBuffer);
                                this.Invoke(new MethodInvoker(delegate ()
                                {
                                    this.txt_log.AppendText(this.m_initializeClass.buffer + Environment.NewLine); // log창에 메시지 출력
                                }));
                                Initialize Path = new Initialize();
                                Path.Type = (int)PacketType.초기화;
                                Path.buffer = CurrentPath; // 클라이언트에게 설정된 경로 보내기

                                Packet.Serialize(Path).CopyTo(this.sendBuffer, 0);
                                this.Send(); // 버퍼 보내기
                                break;
                            }
                        case (int)PacketType.탐색기: // 파일탐색 요청 시
                            {
                                this.m_browserClass = (Browser)Packet.Desserialize(this.readBuffer);
                                this.Invoke(new MethodInvoker(delegate ()
                                {
                                    Browser Brows = new Browser();
                                    Brows.Type = (int)PacketType.탐색기;
                                    DirectoryInfo dir = new DirectoryInfo(this.m_browserClass.fullpath);
                                    Brows.di = dir.GetDirectories(); // 하위 디렉토리 탐색 결과 보내기

                                    if (this.m_browserClass.num == 2) // beforeSelect일 경우
                                    {
                                        this.txt_log.AppendText(this.m_browserClass.message + Environment.NewLine); // log창에 메시지 출력
                                        Brows.fi = dir.GetFiles(); // 하위 파일 탐색 결과 보내기
                                    }
                                    else if (this.m_browserClass.num == 1) // beforeExpand일 경우
                                    {
                                        this.txt_log.AppendText(this.m_browserClass.message + Environment.NewLine); // log창에 메시지 출력
                                    }
                                    Packet.Serialize(Brows).CopyTo(this.sendBuffer, 0);
                                    this.Send(); // 버퍼 보내기
                                }));
                                break;
                            }
                        case (int)PacketType.상세화: // 상세정보 및 다운로드 요청 시
                            {
                                this.m_detailClass = (Detail)Packet.Desserialize(this.readBuffer);
                                this.Invoke(new MethodInvoker(delegate ()
                               {
                                   this.txt_log.AppendText(this.m_detailClass.message + Environment.NewLine); // log창에 메시지 출력
                               }));
                                break;
                            }
                    }
                }
            }
        }

        private void btn_svr_Click(object sender, EventArgs e)
        {
            if (m_path == false) // 경로를 선택하지 않고 서버켜기 버튼을 눌렀을 경우
            {
                MessageBox.Show("경로를 선택해주세요", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.btn_svr.Text = "서버켜기";
                this.btn_svr.ForeColor = Color.Black;
            }
            else
            {
                this.m_thread = new Thread(new ThreadStart(RUN));
                this.m_thread.Start();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.m_listener.Stop();
            this.m_networkstream.Close();
            this.m_thread.Abort();
        }
    }
}