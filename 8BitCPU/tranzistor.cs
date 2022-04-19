using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8BitCPU
{
    class tranzistor
    {
        public int x1, y1;
        public wire input, output, baze;

        public tranzistor(int x1, int y1)
        {
            this.x1 = x1;
            this.y1 = y1;

            input = new wire(x1 + 3, y1 + 25, x1 + 3, y1 + 5, null);
            baze = new wire(x1 + 9, y1 + 25, x1 + 9, y1 + 5, null);
            output = new wire(x1 + 15, y1 + 25, x1 + 15, y1 + 5, null);
        }

        public void drawTranzistor(Graphics e)
        {
            Pen pen = new Pen(Color.Black);

            e.DrawRectangle(pen, new Rectangle(this.x1, this.y1, 18, 10));

            this.input.drawWire(e);
            this.output.drawWire(e);
            this.baze.drawWire(e);
        }
    }
}
