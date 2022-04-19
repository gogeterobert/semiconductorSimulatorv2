using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8BitCPU
{
    class wire
    {
        public bool isOn;
        public int x1, y1, x2, y2;
        public wire[] connection = new wire[10];
        public input input;
        public int c = 0;

        public wire(int x1, int y1, int x2, int y2, input input)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.input = input;
        }

        public void addConnection(wire connection)
        {
            this.connection[c++] = connection;
        }

        public void drawWire(Graphics e)
        {
            Pen pen;
            if (this.isOn)
                pen = new Pen(Color.Red);
            else
                pen = new Pen(Color.Gray);

            e.DrawLine(pen, this.x1, this.y1, this.x2, this.y2);

            Point[] points = new Point[4];
            points[0] = new Point(this.x1 + 2, this.y1);
            points[1] = new Point(this.x1, this.y1 + 2);
            points[2] = new Point(this.x1 - 2, this.y1);
            points[3] = new Point(this.x1, this.y1 - 2);

            e.DrawClosedCurve(pen, points);
        }

        public int checkWireClick(int x, int y, string button)
        {
            if (button == "Left" && this != null)
            {
                if (this.x1 - x < 2 && this.x1 - x > -2 && this.y1 - y < 2 && this.y1 - y > -2)
                    return 1;
                if (this.x2 - x < 2 && this.x2 - x > -2 && this.y2 - y < 2 && this.y2 - y > -2)
                    return 2;
            }
            return 0;
        }
    }
}
