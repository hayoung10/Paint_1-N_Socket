using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HW6;
using System.Net.Sockets;
using System.Threading;
using System.Net; // IPAddress 사용
using System.Collections;
using System.Drawing.Imaging;

namespace PaintServer
{
    public partial class Form2 : Form
    {
        private TcpListener m_listener;
        private TcpClient client;
        static int user = 0; // 사용자 수
        private Dictionary<TcpClient, string> clientList = new Dictionary<TcpClient, string>();

        private byte[] sendBuffer = new byte[1024 * 4];
        private byte[] readBuffer = new byte[1024 * 4];

        private bool m_bClinetOn = false;

        private Thread m_thread;
        private string path;

        public Paint m_paintClass;
        public Chat m_chatClass;
        public Connect m_connectClass;

        public string f2_ip;
        public string f2_port;

        public Form2()
        {
            InitializeComponent();
        }

        public void Send(NetworkStream stream)
        {
            stream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
            stream.Flush(); // 버퍼 비우기

            for (int i = 0; i < 1024 * 4; i++)
                this.sendBuffer[i] = 0;
        }

        public void RUN()
        {
            this.m_listener = new TcpListener(IPAddress.Parse(f2_ip), Int32.Parse(f2_port));
            this.client = default(TcpClient); // 소켓 설정
            this.m_listener.Start();
            this.m_bClinetOn = true;

            int nRead = 0;
            while (this.m_bClinetOn) // 클라이언트와 연결 중인 동안 실행
            {
                try
                {
                    user++;
                    client = this.m_listener.AcceptTcpClient(); // 클라이언트와 접속
                    NetworkStream m_networkstream = client.GetStream();

                    nRead = m_networkstream.Read(readBuffer, 0, 1024 * 4); // 네트워크에서 스트림 읽기  
                    Packet packet = (Packet)Packet.Desserialize(this.readBuffer);
                    switch ((int)packet.Type)
                    {
                        case (int)PacketType.그림판: // 클라이언트로부터 그림판에 그려진 정보를 받았을 때
                            {
                                this.m_paintClass = (Paint)Packet.Desserialize(this.readBuffer);
                                this.Invoke(new MethodInvoker(delegate ()
                                {
                                    if (this.m_paintClass.receive == 1)
                                    {
                                        using (var bmpTemp = new Bitmap(path)) // 해당 경로의 이미지 가져오기
                                        {
                                            panel1.BackgroundImage = new Bitmap(bmpTemp);
                                        }
                                    }
                                    foreach(var pair in clientList) // 모든 클라이언트에게 그림판 정보 보내기
                                    {
                                        TcpClient cclient = pair.Key as TcpClient;
                                        NetworkStream stream = cclient.GetStream();
                                        Paint paint = new Paint();
                                        paint.Type = (int)PacketType.그림판;
                                        paint.receive = 2;

                                        Packet.Serialize(paint).CopyTo(this.sendBuffer, 0);
                                        this.Send(stream); // 버퍼 보내기
                                    }
                                }));
                                break;
                            }
                        case (int)PacketType.채팅: // 클라이언트에게 채팅 내용 받기
                            {
                                this.m_chatClass = (Chat)Packet.Desserialize(this.readBuffer);
                                this.Invoke(new MethodInvoker(delegate ()
                                {
                                    string content = this.m_chatClass.name + ":" + this.m_chatClass.say + Environment.NewLine;
                                    this.txt_chat.AppendText(content);

                                    foreach(var pair in clientList) // 모든 클라이언트에게 채팅 내용 보내기
                                    {
                                        TcpClient cclient = pair.Key as TcpClient;
                                        NetworkStream stream = cclient.GetStream();
                                        Chat chats = new Chat();
                                        chats.Type = (int)PacketType.채팅;
                                        chats.say = content;

                                        Packet.Serialize(chats).CopyTo(this.sendBuffer, 0);
                                        this.Send(stream); // 버퍼 보내기
                                    }
                                }));
                                break;
                            }
                        case (int)PacketType.연결: // 클라이언트에서 연결 요청 및 연결 취소
                            {
                                this.m_connectClass = (Connect)Packet.Desserialize(this.readBuffer);
                                this.Invoke(new MethodInvoker(delegate ()
                                {
                                    if (this.m_connectClass.connect == true)
                                    {
                                        if (clientList.Count < 10) // 최대 10개의 클라이언트 접속
                                        {
                                            clientList.Add(client, this.m_connectClass.username);

                                            foreach (var pair in clientList)
                                            {
                                                TcpClient cclient = pair.Key as TcpClient;
                                                NetworkStream stream = cclient.GetStream();
                                                Connect conn = new Connect();
                                                conn.Type = (int)PacketType.연결;
                                                conn.path = this.path;
                                                conn.connect = true;

                                                Packet.Serialize(conn).CopyTo(this.sendBuffer, 0);
                                                this.Send(stream);
                                            }
                                        }
                                    }
                                    else if (this.m_connectClass.connect == false)
                                    {
                                        if (clientList.ContainsKey(client))
                                        {
                                            clientList.Remove(client); // 리스트에서 클라이언트 지우기
                                        }
                                    }
                                }));
                                break;
                            }
                    }
                }
                catch (SocketException)
                {
                    this.m_bClinetOn = false;
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            path = Application.StartupPath + "/paint.jpg"; // 서버 정보가 저장되는 곳
            if (System.IO.File.Exists("paint.jpg")) // 저장된 서버 정보가 있는 경우
            {
                using (var bmpTemp = new Bitmap(path)) // 해당 경로의 이미지 가져오기
                {
                    panel1.BackgroundImage = new Bitmap(bmpTemp);
                }
            }
            else // 저장된 서버 정보가 없는 경우
            {
                Bitmap bitmap = new Bitmap(panel1.Width, panel1.Height);
                panel1.DrawToBitmap(bitmap, new Rectangle(0, 0, panel1.Width, panel1.Height));
                bitmap.Save(path, ImageFormat.Jpeg);
            }
            this.m_thread = new Thread(new ThreadStart(RUN));
            this.m_thread.IsBackground = true;
            this.m_thread.Start();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.m_listener.Stop();
            this.m_thread.Abort();
            Bitmap btm = new Bitmap(panel1.Width, panel1.Height);
            panel1.DrawToBitmap(btm, new Rectangle(0, 0, panel1.Width, panel1.Height));
            btm.Save(path, ImageFormat.Jpeg); // 서버에 그려진 그림 정보 저장
        }
    }
}
