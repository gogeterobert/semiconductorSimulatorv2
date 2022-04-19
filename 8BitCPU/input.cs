using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8BitCPU
{
    class input
    {
        public int x, y;
        public bool isOn = true;

        int w = 0;
        
        public input(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void drawInput(Graphics e)
        {
            Pen pen;
            if (this.isOn)
                pen = new Pen(Color.Red);
            else
                pen = new Pen(Color.Gray);

            Point[] points = new Point[4];
            points[0] = new Point(this.x + 5, this.y);
            points[1] = new Point(this.x, this.y + 5);
            points[2] = new Point(this.x - 5, this.y);
            points[3] = new Point(this.x, this.y - 5);

            e.DrawClosedCurve(pen, points);
        }

        public bool checkInputClick(int x, int y)
        {
            if (this != null)
            {
                if (this.x - x < 5 && this.x - x > -5 && this.y - y < 5 && this.y - y > -5)
                    return true;
                return false;
            }
            else
                return false;
        }
    }
}
