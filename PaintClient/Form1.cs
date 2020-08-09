using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            PaintClient.Form2 cform2 = new PaintClient.Form2();
            cform2.cf2_ip = this.txt_ip.Text;
            cform2.cf2_port = this.txt_port.Text;
            cform2.cf2_id = this.txt_id.Text;
            cform2.Show(); // Form2 열기
        }
    }
}
