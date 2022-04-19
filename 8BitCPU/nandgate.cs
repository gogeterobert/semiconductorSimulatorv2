using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8BitCPU
{
    class nandgate
    {
        public int x, y;
        public tranzistor[] tranzistors = new tranzistor[3];
        public wire[] wire = new wire[50];
        public not[] nots = new not[1];
        int w = 0;
        public nandgate(int x, int y)
        {
            this.x = x;
            this.y = y;
            tranzistors[0] = new tranzistor(x, y);
            tranzistors[1] = new tranzistor(x + 20, y);
            nots[0] = new not(x + 10, y - 25);
            wire[w] = new wire(tranzistors[0].output.x1, tranzistors[0].output.y1, tranzistors[1].input.x1, tranzistors[1].input.y1, null);
            wire[w++].addConnection(tranzistors[0].output);
            wire[w] = new wire(tranzistors[1].output.x1, tranzistors[1].output.y1, nots[0].input.x1, nots[0].input.y1, null);
            wire[w++].addConnection(tranzistors[1].output);
            nots[0].input.addConnection(wire[1]);
            tranzistors[1].input.addConnection(wire[0]);
        }

        public void drawNANDGate(Graphics e)
        {
            Pen pen = new Pen(Color.Black);

            tranzistors[0].drawTranzistor(e);
            tranzistors[1].drawTranzistor(e);

            foreach (var wr in wire)
            {
                if (wr != null)
                {
                    wr.drawWire(e);
                }
                else
                    break;
            }

            nots[0].drawNot(e);
        }

        public void connect(wire[] wires)
        {
            foreach (var wr in wires)
            {
                if (wr != null)
                {
                    wire[w] = new wire(nots[0].output.x1, nots[0].output.y1, wr.x1, wr.y1, null);
                    wire[w].addConnection(nots[0].output);
                    wr.addConnection(wire[w++]);
                }
                else
                    break;
            }
        }
    }
}
