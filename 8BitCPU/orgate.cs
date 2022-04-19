using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8BitCPU
{
    class orgate
    {
        public int x, y;
        public tranzistor[] tranzistors = new tranzistor[3];
        public wire[] wire = new wire[50];
        int w = 0;

        public orgate(int x, int y)
        {
            this.x = x;
            this.y = y;
            tranzistors[0] = new tranzistor(x, y);
            tranzistors[1] = new tranzistor(x + 20, y);
        }

        public void drawORGate(Graphics e)
        {
            Pen pen = new Pen(Color.Black);

            tranzistors[0].drawTranzistor(e);
            tranzistors[1].drawTranzistor(e);
            
            foreach(var wr in wire)
            {
                if (wr != null)
                {
                    wr.drawWire(e);
                }
                else
                    break;
            }
        }

        public void connect(wire[] wires)
        { 
            foreach(var wr in wires)
            {
                if (wr != null)
                {
                    wire[w] = new wire(tranzistors[0].output.x1, tranzistors[0].output.y1, wr.x1, wr.y1, null);
                    wire[w].addConnection(tranzistors[0].output);
                    wr.addConnection(wire[w++]);
                    wire[w] = new wire(tranzistors[1].output.x1, tranzistors[1].output.y1, wr.x1, wr.y1, null);
                    wire[w].addConnection(tranzistors[1].output);
                    wr.addConnection(wire[w++]);
                }
                else
                    break;
            }
        }
    }
}
