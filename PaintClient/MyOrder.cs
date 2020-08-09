using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Collections;

namespace PaintClient
{
    class MyOrder
    {
        private Point[] pencil_point = new Point[2];
        private Point[] line_point = new Point[2];
        private Rectangle rect;
        private Rectangle rectC;
        private int thick = 1; // 선 두께;
        private Color lcolor = Color.Black; // 선 색;
        private Color fcolor = Color.Empty; // 채우는 색

        public MyOrder()
        {
            pencil_point[0] = new Point();
            pencil_point[1] = new Point();
            line_point[0] = new Point();
            line_point[1] = new Point();
            rect = new Rectangle();
            rectC = new Rectangle();
            thick = 1;
            lcolor = Color.Black;
            fcolor = Color.Empty;
        }

        public void setPointp(Point start, Point finish, int thick, Color lcolor)
        {
            pencil_point[0] = start;
            pencil_point[1] = finish;
            this.thick = thick;
            this.lcolor = lcolor;
        }

        public Point getPoint1p()
        {
            return pencil_point[0];
        }

        public Point getPoint2p()
        {
            return pencil_point[1];
        }

        public void setPointl(Point start, Point finish, int thick, Color lcolor)
        {
            line_point[0] = start;
            line_point[1] = finish;
            this.thick = thick;
            this.lcolor = lcolor;
        }

        public Point getPoint1l()
        {
            return line_point[0];
        }

        public Point getPoint2l()
        {
            return line_point[1];
        }

        public void setRect(Point start, Point finish, int thick, Color lcolor, Color fcolor)
        {
            rect.X = Math.Min(start.X, finish.X);
            rect.Y = Math.Min(start.Y, finish.Y);
            rect.Height = Math.Abs(finish.Y - start.Y);
            rect.Width = Math.Abs(finish.X - start.X);
            this.thick = thick;
            this.lcolor = lcolor;
            this.fcolor = fcolor;
        }

        public Rectangle getRect()
        {
            return rect;
        }

        public void setRectC(Point start, Point finish, int thick, Color lcolor, Color fcolor)
        {
            rectC.X = Math.Min(start.X, finish.X);
            rectC.Y = Math.Min(start.Y, finish.Y);
            rectC.Width = Math.Abs(start.X - finish.X);
            rectC.Height = Math.Abs(start.Y - finish.Y);
            this.thick = thick;
            this.lcolor = lcolor;
            this.fcolor = fcolor;
        }

        public Rectangle getRectC()
        {
            return rectC;
        }

        public int getThick()
        {
            return thick;
        }

        public Color getlColor()
        {
            return lcolor;
        }

        public Color getfColor()
        {
            return fcolor;
        }
    }
}
