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
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace PaintClient
{
    public partial class Form2 : Form
    {
        // 통신 변수
        private TcpClient m_client;
        private Thread m_thread;

        private byte[] sendBuffer = new byte[1024 * 4];
        private byte[] readBuffer = new byte[1024 * 4];

        private bool m_bConnect = false;

        public Connect m_connectClass;
        public Paint m_paintClass;
        public Chat m_chatClass;

        public string cf2_ip;
        public string cf2_port;
        public string cf2_id;

        // 그림판 변수
        private bool hand;
        private bool pencil;
        private bool line;
        private bool rect;
        private bool circle;
        private Point start; // 선, 도형의 시작 포인트
        private Point finish; // 선, 도형의 끝 포인트
        private Pen pen; // 펜
        private SolidBrush brush; // 색 채우기
        private int ntotal; // 현재 저장된 모든 도형의 갯수
        private int i;
        private int thick; // 선의 두께
        private MyOrder[] myorder;
        private Pen[] penp; // 연필의 pen
        private Pen[] penl; // 선의 pen
        private Pen[] penr; // 사각형의 pen
        private Pen[] penc; // 원의 pen
        private SolidBrush[] brushr; // 사각형의 brush
        private SolidBrush[] brushc; // 원의 brush
        private string imgpath;

        private bool wheelcheck = false;
        private double ratio = 1.0F;
        private Point pPoint;
        private Rectangle pRect;
        private Point clickPoint;
        private Point LastPoint;

        public Form2()
        {
            InitializeComponent();

            pPoint = new Point(panel1.Width / 2, panel1.Height / 2);
            pRect = new Rectangle(0, 0, panel1.Width, panel1.Height);
            ratio = 1.0;
            clickPoint = pPoint;

            SetupVar();
            panel1.Invalidate();
        }

        public void Send(NetworkStream stream)
        {
            stream.Write(this.sendBuffer, 0, this.sendBuffer.Length);
            stream.Flush(); // 버퍼 비우기

            for (int i = 0; i < 1024 * 4; i++)
                this.sendBuffer[i] = 0;
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            TcpClient client = new TcpClient(cf2_ip, Int32.Parse(cf2_port));
            NetworkStream networkstream = client.GetStream();
            Connect conn = new Connect();
            conn.Type = (int)PacketType.연결;
            conn.connect = false;

            Packet.Serialize(conn).CopyTo(this.sendBuffer, 0);
            this.Send(networkstream); // 버퍼 보내기
            this.m_client.Close();
            this.m_thread.Abort();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.m_client = new TcpClient();
            try
            {
                this.m_client.Connect(cf2_ip, Int32.Parse(cf2_port));
            }
            catch
            {
                return;
            }
            this.m_bConnect = true;
            NetworkStream m_networkstream = this.m_client.GetStream();

            Connect con = new Connect();
            con.Type = (int)PacketType.연결;
            con.username = this.cf2_id;
            con.connect = true;

            Packet.Serialize(con).CopyTo(this.sendBuffer, 0);
            this.Send(m_networkstream); // 버퍼 보내기

            m_thread = new Thread(new ParameterizedThreadStart(GetChat));
            m_thread.Start(this.m_client);
        }

        public void GetChat(object p_client) // 서버에게 정보 받기
        {
            TcpClient client = (TcpClient)p_client;
            NetworkStream stream = client.GetStream();
            int nRead = 0;
            while (this.m_bConnect)
            {
                try
                {
                    nRead = 0;
                    nRead = stream.Read(readBuffer, 0, 1024 * 4); // 네트워크에서 스트림 읽기
                }
                catch
                {
                    this.m_bConnect = false;
                    stream = null;
                }
                if (nRead == 0)
                    this.m_bConnect = false;
                else
                {
                    Packet packet = (Packet)Packet.Desserialize(this.readBuffer);

                    switch ((int)packet.Type)
                    {
                        case (int)PacketType.연결: // 서버에게 연결되었음을 확인하고 초기 그림판 정보 받기
                            {
                                this.m_connectClass = (Connect)Packet.Desserialize(this.readBuffer);
                                this.Invoke(new MethodInvoker(delegate ()
                                {
                                    if (this.m_connectClass.connect == true)
                                    {
                                        imgpath = this.m_connectClass.path;
                                        using (var bmpTemp = new Bitmap(imgpath)) // 해당 경로 이미지 가져오기
                                        {
                                            panel1.BackgroundImage = new Bitmap(bmpTemp);
                                        }
                                    }
                                }));
                                break;
                            }
                        case (int)PacketType.그림판: // 서버에게 그림판 정보 받기
                            {
                                this.m_paintClass = (Paint)Packet.Desserialize(this.readBuffer);
                                this.Invoke(new MethodInvoker(delegate ()
                                {
                                    if(this.m_paintClass.receive == 2)
                                    {
                                        using (var bmpTemp = new Bitmap(imgpath)) // 해당 경로 이미지 가져오기
                                        {
                                            panel1.BackgroundImage = new Bitmap(bmpTemp);
                                        }
                                    }
                                }));
                                break;
                            }
                        case (int)PacketType.채팅: // 서버에게 채팅 내용 받기
                            {
                                this.m_chatClass = (Chat)Packet.Desserialize(this.readBuffer);
                                this.Invoke(new MethodInvoker(delegate ()
                                {
                                    this.txt_chatting.AppendText(this.m_chatClass.say);
                                }));
                                break;
                            }
                    }
                }
            }
        }

        private void btn_say_Click(object sender, EventArgs e)
        {
            try
            {
                this.m_client = new TcpClient(cf2_ip, Int32.Parse(cf2_port));
                NetworkStream m_networkstream = this.m_client.GetStream();

                Chat chats = new Chat();
                chats.Type = (int)PacketType.채팅;
                chats.name = this.cf2_id;
                chats.say = this.txt_say.Text;

                Packet.Serialize(chats).CopyTo(this.sendBuffer, 0);
                this.Send(m_networkstream); // 버퍼 보내기
            }
            catch
            {
                this.txt_chatting.Text = "No..." + Environment.NewLine;
            }
            this.txt_say.Text = "";
        }

        // 그림판 함수
        private void SetupVar()
        {
            i = 0;
            thick = 1;
            hand = false;
            pencil = true;
            line = false;
            rect = false;
            circle = false;
            start = new Point(0, 0);
            finish = new Point(0, 0);
            pen = new Pen(colorDialog1.Color);
            brush = new SolidBrush(colorDialog2.Color);
            myorder = new MyOrder[100000];
            penp = new Pen[100000];
            penl = new Pen[100000];
            penr = new Pen[100000];
            penc = new Pen[100000];
            brushr = new SolidBrush[100000];
            brushc = new SolidBrush[100000];
            ntotal = 0;
            //btm = new Bitmap("Paint.jpg");
            if (System.IO.File.Exists(imgpath))
            {
                Bitmap bb = new Bitmap(imgpath);
                panel1.BackgroundImage = bb;
            }

            SetupMine(); // 연필선, 선, 사각형, 원의 저장 클래스 초기화
        }

        private void SetupMine()
        {
            for (i = 0; i < 100000; i++)
                myorder[i] = new MyOrder();
            for (i = 0; i < 100000; i++)
                penp[i] = new Pen(lineColor_btn.BackColor);
            for (i = 0; i < 100000; i++)
                penl[i] = new Pen(lineColor_btn.BackColor);
            for (i = 0; i < 100000; i++)
                penr[i] = new Pen(lineColor_btn.BackColor);
            for (i = 0; i < 100000; i++)
                penc[i] = new Pen(lineColor_btn.BackColor);
            for (i = 0; i < 100000; i++)
                brushr[i] = new SolidBrush(fillColor_btn.BackColor);
            for (i = 0; i < 100000; i++)
                brushc[i] = new SolidBrush(fillColor_btn.BackColor);
        }

        private void handToolStripMenuItem_Click(object sender, EventArgs e) // Hand 클릭
        {
            hand = true;
            pencil = false;
            line = false;
            rect = false;
            circle = false;
            wheelcheck = true;
        }

        private void panel1_MouseWheel(object sender, MouseEventArgs e) // 마우스휠을 움직였을 때
        {
            if (wheelcheck == true)
            {
                txt_chatting.AppendText("Wheel" + Environment.NewLine);
                int lines = e.Delta * SystemInformation.MouseWheelScrollLines / 120;
                Panel pn = (Panel)sender;

                if (lines > 0)
                {
                    txt_chatting.AppendText("+" + Environment.NewLine);
                    ratio = ratio * 1.1F;
                    if (ratio > 100.0)
                        ratio = 100.0;
                }
                else if (lines < 0)
                {
                    txt_chatting.AppendText("-" + Environment.NewLine);
                    ratio = ratio * 0.9F;
                    if (ratio < 1)
                        ratio = 1;
                }

                pRect.Width = (int)Math.Round(panel1.Width * ratio);
                pRect.Height = (int)Math.Round(panel1.Height * ratio);
                pRect.X = (int)Math.Round(pn.Width / 2 - pPoint.X * ratio);
                pRect.Y = (int)Math.Round(pn.Height / 2 - pPoint.Y * ratio);

                panel1.Invalidate(true);
            }
        }

        private void pencilToolStripMenuItem_Click(object sender, EventArgs e) // Pencil 클릭
        {
            hand = false;
            pencil = true;
            line = false;
            rect = false;
            circle = false;
            wheelcheck = false;
        }

        private void lineToolStripMenuItem_Click(object sender, EventArgs e) // Line 클릭
        {
            hand = false;
            pencil = false;
            line = true;
            rect = false;
            circle = false;
            wheelcheck = false;
        }

        private void circleToolStripMenuItem_Click(object sender, EventArgs e) // Circle 클릭
        {
            hand = false;
            pencil = false;
            line = false;
            rect = false;
            circle = true;
            wheelcheck = false;
        }

        private void rectToolStripMenuItem_Click(object sender, EventArgs e) // Rect 클릭
        {
            hand = false;
            pencil = false;
            line = false;
            rect = true;
            circle = false;
            wheelcheck = false;
        }

        private void thick1toolStripMenuItem_Click(object sender, EventArgs e) // 선 두께 1
        {
            thick = 1;
        }

        private void thick2toolStripMenuItem_Click(object sender, EventArgs e) // 선 두께 2
        {
            thick = 2;
        }

        private void thick3toolStripMenuItem_Click(object sender, EventArgs e) // 선 두께 3
        {
            thick = 3;
        }

        private void thick4toolStripMenuItem_Click(object sender, EventArgs e) // 선 두께 4
        {
            thick = 4;
        }

        private void thick5toolStripMenuItem_Click(object sender, EventArgs e) // 선 두께 5
        {
            thick = 5;
        }

        private void lineColor_btn_Click(object sender, EventArgs e) // 선 색 선택
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                lineColor_btn.BackColor = colorDialog1.Color;
        }

        private void fillColor_btn_Click(object sender, EventArgs e) // 채우는 색 선택
        {
            if (colorDialog2.ShowDialog() == DialogResult.OK)
                fillColor_btn.BackColor = colorDialog2.Color;
        }

        private void fill_btn_Click(object sender, EventArgs e) // "채우기" 버튼 클릭
        {
            if (fill_btn.Checked == true)
                fill_btn.Checked = false;
            else if (fill_btn.Checked == false)
                fill_btn.Checked = true;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e) // 마우스가 눌렸을 때
        {
            if (wheelcheck == true)
            {
                if (e.Button == MouseButtons.Left)
                    clickPoint = new Point(e.X, e.Y);
                panel1.Invalidate();
            }
            else
            {
                start.X = e.X;
                start.Y = e.Y;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e) // 마우스가 움직일 때
        {
            if (wheelcheck == true)
            {
                if (e.Button == MouseButtons.Left)
                {
                    pRect.X = pRect.X + (int)Math.Round((double)(e.X - clickPoint.X) / 5);
                    if (pRect.X >= 0)
                        pRect.X = 0;
                    if (Math.Abs(pRect.X) >= Math.Abs(pRect.Width - panel1.Width))
                        pRect.X = -(pRect.Width - panel1.Width);
                    pRect.Y = pRect.Y + (int)Math.Round((double)(e.Y - clickPoint.Y) / 5);
                    if (pRect.Y >= 0)
                        pRect.Y = 0;
                    if (Math.Abs(pRect.Y) >= Math.Abs(pRect.Height - pRect.Height))
                        pRect.Y = -(pRect.Height - panel1.Height);
                }
                else
                {
                    LastPoint = e.Location;
                }
                panel1.Invalidate(true);
            }
            else
            {
                if ((start.X == 0) && (start.Y == 0))
                    return;

                finish.X = e.X;
                finish.Y = e.Y;

                if (hand == true)
                {
                    start.X = e.X;
                    start.Y = e.Y;
                }

                if (pencil == true)
                {
                    myorder[ntotal++].setPointp(start, finish, thick, lineColor_btn.BackColor);
                    start.X = e.X;
                    start.Y = e.Y;
                }

                if (line == true)
                    myorder[ntotal].setPointl(start, finish, thick, lineColor_btn.BackColor);

                if (rect == true)
                {
                    if (fill_btn.Checked == false) // 채우기X
                        myorder[ntotal].setRect(start, finish, thick, lineColor_btn.BackColor, Color.Empty);
                    else if (fill_btn.Checked == true) // 채우기O
                        myorder[ntotal].setRect(start, finish, thick, lineColor_btn.BackColor, fillColor_btn.BackColor);
                }

                if (circle == true)
                {
                    if (fill_btn.Checked == false) // 채우기X
                        myorder[ntotal].setRectC(start, finish, thick, lineColor_btn.BackColor, Color.Empty);
                    else if (fill_btn.Checked == true) // 채우기O
                        myorder[ntotal].setRectC(start, finish, thick, lineColor_btn.BackColor, fillColor_btn.BackColor);
                }
                panel1.Invalidate(true);
                panel1.Update();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e) // 패널1 그리기
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; // 안티앨리어스 적용

            // 현재 저장된 연필선, 선, 사각형, 원 그리기
            if (pencil == true)
            {
                for (i = 0; i <= ntotal; i++)
                {
                    penp[i].Width = myorder[i].getThick();
                    penp[i].Color = myorder[i].getlColor();

                    e.Graphics.FillRectangle(brushr[i], myorder[i].getRect());
                    e.Graphics.DrawRectangle(penr[i], myorder[i].getRect());
                    e.Graphics.FillEllipse(brushc[i], myorder[i].getRectC());
                    e.Graphics.DrawEllipse(penc[i], myorder[i].getRectC());
                    e.Graphics.DrawLine(penl[i], myorder[i].getPoint1l(), myorder[i].getPoint2l());
                    e.Graphics.DrawLine(penp[i], myorder[i].getPoint1p(), myorder[i].getPoint2p());  
                }
            }
            else if (line == true)
            {
                for (i = 0; i <= ntotal; i++)
                {
                    penl[i].Width = myorder[i].getThick();
                    penl[i].Color = myorder[i].getlColor();

                    e.Graphics.FillRectangle(brushr[i], myorder[i].getRect());
                    e.Graphics.DrawRectangle(penr[i], myorder[i].getRect());
                    e.Graphics.FillEllipse(brushc[i], myorder[i].getRectC());
                    e.Graphics.DrawEllipse(penc[i], myorder[i].getRectC());
                    e.Graphics.DrawLine(penp[i], myorder[i].getPoint1p(), myorder[i].getPoint2p());
                    e.Graphics.DrawLine(penl[i], myorder[i].getPoint1l(), myorder[i].getPoint2l()); 
                }
            }
            else if (rect == true)
            {
                for (i = 0; i <= ntotal; i++)
                {
                    penr[i].Width = myorder[i].getThick();
                    penr[i].Color = myorder[i].getlColor();
                    brushr[i].Color = myorder[i].getfColor();

                    e.Graphics.DrawLine(penp[i], myorder[i].getPoint1p(), myorder[i].getPoint2p());
                    e.Graphics.DrawLine(penl[i], myorder[i].getPoint1l(), myorder[i].getPoint2l());
                    e.Graphics.FillEllipse(brushc[i], myorder[i].getRectC());
                    e.Graphics.DrawEllipse(penc[i], myorder[i].getRectC());
                    e.Graphics.FillRectangle(brushr[i], myorder[i].getRect());
                    e.Graphics.DrawRectangle(penr[i], myorder[i].getRect());
                }
                
            }
            else if (circle == true)
            {
                for (i = 0; i <= ntotal; i++)
                {
                    penc[i].Width = myorder[i].getThick();
                    penc[i].Color = myorder[i].getlColor();
                    brushc[i].Color = myorder[i].getfColor();

                    e.Graphics.DrawLine(penp[i], myorder[i].getPoint1p(), myorder[i].getPoint2p());
                    e.Graphics.DrawLine(penl[i], myorder[i].getPoint1l(), myorder[i].getPoint2l());
                    e.Graphics.FillRectangle(brushr[i], myorder[i].getRect());
                    e.Graphics.DrawRectangle(penr[i], myorder[i].getRect());
                    e.Graphics.FillEllipse(brushc[i], myorder[i].getRectC());
                    e.Graphics.DrawEllipse(penc[i], myorder[i].getRectC());
                }
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e) // 마우스 버튼이 띠어졌을 때
        {
            if (pencil == true)
                ntotal++;
            if (line == true)
                ntotal++;
            if (rect == true)
                ntotal++;
            if (circle == true)
                ntotal++;

            start.X = 0;
            start.Y = 0;
            finish.X = 0;
            finish.Y = 0;

            Bitmap btm2 = new Bitmap(panel1.Width, panel1.Height);
            panel1.DrawToBitmap(btm2, new Rectangle(0, 0, panel1.Width, panel1.Height));
            btm2.Save(imgpath, ImageFormat.Jpeg); // 해당 경로에 이미지 저장

            TcpClient client = new TcpClient(cf2_ip, Int32.Parse(cf2_port));
            NetworkStream networkstream = client.GetStream();
            Paint paint = new Paint();
            paint.Type = (int)PacketType.그림판;
            paint.receive = 1;

            Packet.Serialize(paint).CopyTo(this.sendBuffer, 0);
            this.Send(networkstream); // 버퍼 보내기
        }
    }
}
