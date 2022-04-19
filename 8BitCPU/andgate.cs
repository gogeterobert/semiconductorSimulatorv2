using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8BitCPU
{
    class andgate
    {
        public int x, y;
        public tranzistor[] tranzistors = new tranzistor[3];
        public wire[] wire = new wire[2];
        public andgate(int x, int y)
        {
            this.x = x;
            this.y = y;
            tranzistors[0] = new tranzistor(x, y);
            tranzistors[1] = new tranzistor(x + 20, y);
            wire[0] = new wire(tranzistors[0].output.x1, tranzistors[0].output.y1, tranzistors[1].input.x1, tranzistors[1].input.y1, null);
            wire[0].addConnection(tranzistors[0].output);
            tranzistors[1].input.addConnection(wire[0]);
        }

        public void drawANDGate(Graphics e)
        {
            Pen pen = new Pen(Color.Black);

            tranzistors[0].drawTranzistor(e);
            tranzistors[1].drawTranzistor(e);
            wire[0].drawWire(e);
        }
    }
}
