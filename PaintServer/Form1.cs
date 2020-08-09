using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_opsvr_Click(object sender, EventArgs e)
        {
            PaintServer.Form2 sform2 = new PaintServer.Form2();
            sform2.f2_ip = this.txt_ip.Text;
            sform2.f2_port = this.txt_port.Text;
            sform2.Show(); // Form2 열기
        }
    }
}
