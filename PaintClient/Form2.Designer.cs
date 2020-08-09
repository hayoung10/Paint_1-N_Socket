namespace PaintClient
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.txt_chatting = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolChoose_btn = new System.Windows.Forms.ToolStripDropDownButton();
            this.handToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pencilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.circleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thickChoose_btn = new System.Windows.Forms.ToolStripDropDownButton();
            this.thick1toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thick2toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thick3toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thick4toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thick5toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fill_btn = new System.Windows.Forms.ToolStripButton();
            this.lineColor_btn = new System.Windows.Forms.ToolStripButton();
            this.fillColor_btn = new System.Windows.Forms.ToolStripButton();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.colorDialog2 = new System.Windows.Forms.ColorDialog();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_say = new System.Windows.Forms.Button();
            this.txt_say = new System.Windows.Forms.TextBox();
            this.panel1 = new PaintClient.DoubleBuffering();
            this.toolStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_chatting
            // 
            this.txt_chatting.Location = new System.Drawing.Point(-3, 0);
            this.txt_chatting.Multiline = true;
            this.txt_chatting.Name = "txt_chatting";
            this.txt_chatting.Size = new System.Drawing.Size(663, 100);
            this.txt_chatting.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolChoose_btn,
            this.thickChoose_btn,
            this.fill_btn,
            this.lineColor_btn,
            this.fillColor_btn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(660, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolChoose_btn
            // 
            this.toolChoose_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolChoose_btn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.handToolStripMenuItem,
            this.pencilToolStripMenuItem,
            this.lineToolStripMenuItem,
            this.circleToolStripMenuItem,
            this.rectToolStripMenuItem});
            this.toolChoose_btn.Image = global::PaintClient.Properties.Resources.연필;
            this.toolChoose_btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolChoose_btn.Name = "toolChoose_btn";
            this.toolChoose_btn.Size = new System.Drawing.Size(34, 24);
            this.toolChoose_btn.Text = "toolStripDropDownButton1";
            // 
            // handToolStripMenuItem
            // 
            this.handToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("handToolStripMenuItem.Image")));
            this.handToolStripMenuItem.Name = "handToolStripMenuItem";
            this.handToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
            this.handToolStripMenuItem.Text = "Hand";
            this.handToolStripMenuItem.Click += new System.EventHandler(this.handToolStripMenuItem_Click);
            // 
            // pencilToolStripMenuItem
            // 
            this.pencilToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("pencilToolStripMenuItem.Image")));
            this.pencilToolStripMenuItem.Name = "pencilToolStripMenuItem";
            this.pencilToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
            this.pencilToolStripMenuItem.Text = "Pencil";
            this.pencilToolStripMenuItem.Click += new System.EventHandler(this.pencilToolStripMenuItem_Click);
            // 
            // lineToolStripMenuItem
            // 
            this.lineToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("lineToolStripMenuItem.Image")));
            this.lineToolStripMenuItem.Name = "lineToolStripMenuItem";
            this.lineToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
            this.lineToolStripMenuItem.Text = "Line";
            this.lineToolStripMenuItem.Click += new System.EventHandler(this.lineToolStripMenuItem_Click);
            // 
            // circleToolStripMenuItem
            // 
            this.circleToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("circleToolStripMenuItem.Image")));
            this.circleToolStripMenuItem.Name = "circleToolStripMenuItem";
            this.circleToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
            this.circleToolStripMenuItem.Text = "Circle";
            this.circleToolStripMenuItem.Click += new System.EventHandler(this.circleToolStripMenuItem_Click);
            // 
            // rectToolStripMenuItem
            // 
            this.rectToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("rectToolStripMenuItem.Image")));
            this.rectToolStripMenuItem.Name = "rectToolStripMenuItem";
            this.rectToolStripMenuItem.Size = new System.Drawing.Size(125, 26);
            this.rectToolStripMenuItem.Text = "Rect";
            this.rectToolStripMenuItem.Click += new System.EventHandler(this.rectToolStripMenuItem_Click);
            // 
            // thickChoose_btn
            // 
            this.thickChoose_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.thickChoose_btn.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thick1toolStripMenuItem,
            this.thick2toolStripMenuItem,
            this.thick3toolStripMenuItem,
            this.thick4toolStripMenuItem,
            this.thick5toolStripMenuItem});
            this.thickChoose_btn.Image = ((System.Drawing.Image)(resources.GetObject("thickChoose_btn.Image")));
            this.thickChoose_btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.thickChoose_btn.Name = "thickChoose_btn";
            this.thickChoose_btn.Size = new System.Drawing.Size(34, 24);
            this.thickChoose_btn.Text = "toolStripDropDownButton2";
            // 
            // thick1toolStripMenuItem
            // 
            this.thick1toolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("thick1toolStripMenuItem.Image")));
            this.thick1toolStripMenuItem.Name = "thick1toolStripMenuItem";
            this.thick1toolStripMenuItem.Size = new System.Drawing.Size(92, 26);
            this.thick1toolStripMenuItem.Text = "1";
            this.thick1toolStripMenuItem.Click += new System.EventHandler(this.thick1toolStripMenuItem_Click);
            // 
            // thick2toolStripMenuItem
            // 
            this.thick2toolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("thick2toolStripMenuItem.Image")));
            this.thick2toolStripMenuItem.Name = "thick2toolStripMenuItem";
            this.thick2toolStripMenuItem.Size = new System.Drawing.Size(92, 26);
            this.thick2toolStripMenuItem.Text = "2";
            this.thick2toolStripMenuItem.Click += new System.EventHandler(this.thick2toolStripMenuItem_Click);
            // 
            // thick3toolStripMenuItem
            // 
            this.thick3toolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("thick3toolStripMenuItem.Image")));
            this.thick3toolStripMenuItem.Name = "thick3toolStripMenuItem";
            this.thick3toolStripMenuItem.Size = new System.Drawing.Size(92, 26);
            this.thick3toolStripMenuItem.Text = "3";
            this.thick3toolStripMenuItem.Click += new System.EventHandler(this.thick3toolStripMenuItem_Click);
            // 
            // thick4toolStripMenuItem
            // 
            this.thick4toolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("thick4toolStripMenuItem.Image")));
            this.thick4toolStripMenuItem.Name = "thick4toolStripMenuItem";
            this.thick4toolStripMenuItem.Size = new System.Drawing.Size(92, 26);
            this.thick4toolStripMenuItem.Text = "4";
            this.thick4toolStripMenuItem.Click += new System.EventHandler(this.thick4toolStripMenuItem_Click);
            // 
            // thick5toolStripMenuItem
            // 
            this.thick5toolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("thick5toolStripMenuItem.Image")));
            this.thick5toolStripMenuItem.Name = "thick5toolStripMenuItem";
            this.thick5toolStripMenuItem.Size = new System.Drawing.Size(92, 26);
            this.thick5toolStripMenuItem.Text = "5";
            this.thick5toolStripMenuItem.Click += new System.EventHandler(this.thick5toolStripMenuItem_Click);
            // 
            // fill_btn
            // 
            this.fill_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fill_btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fill_btn.Name = "fill_btn";
            this.fill_btn.Size = new System.Drawing.Size(58, 24);
            this.fill_btn.Text = "채우기";
            this.fill_btn.Click += new System.EventHandler(this.fill_btn_Click);
            // 
            // lineColor_btn
            // 
            this.lineColor_btn.BackColor = System.Drawing.Color.Black;
            this.lineColor_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.lineColor_btn.Image = ((System.Drawing.Image)(resources.GetObject("lineColor_btn.Image")));
            this.lineColor_btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.lineColor_btn.Name = "lineColor_btn";
            this.lineColor_btn.Size = new System.Drawing.Size(23, 24);
            this.lineColor_btn.Text = "toolStripButton2";
            this.lineColor_btn.Click += new System.EventHandler(this.lineColor_btn_Click);
            // 
            // fillColor_btn
            // 
            this.fillColor_btn.BackColor = System.Drawing.Color.Gray;
            this.fillColor_btn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.fillColor_btn.Image = ((System.Drawing.Image)(resources.GetObject("fillColor_btn.Image")));
            this.fillColor_btn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fillColor_btn.Name = "fillColor_btn";
            this.fillColor_btn.Size = new System.Drawing.Size(23, 24);
            this.fillColor_btn.Text = "toolStripButton3";
            this.fillColor_btn.Click += new System.EventHandler(this.fillColor_btn_Click);
            // 
            // colorDialog2
            // 
            this.colorDialog2.Color = System.Drawing.Color.Gray;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_say);
            this.panel2.Controls.Add(this.txt_chatting);
            this.panel2.Controls.Add(this.txt_say);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 354);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(660, 134);
            this.panel2.TabIndex = 5;
            // 
            // btn_say
            // 
            this.btn_say.Location = new System.Drawing.Point(610, 105);
            this.btn_say.Name = "btn_say";
            this.btn_say.Size = new System.Drawing.Size(47, 26);
            this.btn_say.TabIndex = 4;
            this.btn_say.Text = "Say";
            this.btn_say.UseVisualStyleBackColor = true;
            this.btn_say.Click += new System.EventHandler(this.btn_say_Click);
            // 
            // txt_say
            // 
            this.txt_say.Location = new System.Drawing.Point(0, 105);
            this.txt_say.Name = "txt_say";
            this.txt_say.Size = new System.Drawing.Size(607, 25);
            this.txt_say.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(660, 326);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            this.panel1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseWheel);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 488);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form2";
            this.Text = "세계그림판";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_chatting;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolChoose_btn;
        private System.Windows.Forms.ToolStripMenuItem handToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pencilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem circleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rectToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton thickChoose_btn;
        private System.Windows.Forms.ToolStripMenuItem thick1toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thick2toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thick3toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thick4toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thick5toolStripMenuItem;
        private System.Windows.Forms.ToolStripButton fill_btn;
        private System.Windows.Forms.ToolStripButton lineColor_btn;
        private System.Windows.Forms.ToolStripButton fillColor_btn;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ColorDialog colorDialog2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_say;
        private System.Windows.Forms.TextBox txt_say;
        public DoubleBuffering panel1;
    }
}