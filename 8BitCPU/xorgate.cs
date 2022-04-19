using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8BitCPU
{
    class xorgate
    {
        public int x, y;
        public bool ifInput;
        public andgate[] andgates = new andgate[2];
        public orgate[] orgates = new orgate[1];
        public nandgate[] nands = new nandgate[1];
        public wire[] wires = new wire[30];
        public input[] inputs = new input[2];

        int w = 0;

        public xorgate(int x, int y, bool ifInput)
        {
            this.x = x;
            this.y = y;
            this.ifInput = ifInput;

            if (ifInput)
            {
                inputs[0] = new input(x + 10, y + 55);
                inputs[1] = new input(x + 50, y + 55);
            }

            andgates[0] = new andgate(x + 65, y - 35);
            andgates[1] = new andgate(x + 5, y - 40);
            orgates[0] = new orgate(x, y);
            nands[0] = new nandgate(x + 40, y);

            orgates[0].connect(new wire[] { andgates[1].tranzistors[0].input, andgates[1].tranzistors[0].input, andgates[1].tranzistors[0].baze, andgates[1].tranzistors[0].baze });
            nands[0].connect(new wire[] { andgates[1].tranzistors[1].baze });

            if (ifInput)
            {

                wires[w] = new wire(orgates[0].tranzistors[0].input.x1, orgates[0].tranzistors[0].input.y1, inputs[0].x, inputs[0].y, inputs[0]);
                orgates[0].tranzistors[0].input.addConnection(wires[w++]);

                wires[w] = new wire(orgates[0].tranzistors[0].baze.x1, orgates[0].tranzistors[0].baze.y1, inputs[0].x, inputs[0].y, inputs[0]);
                orgates[0].tranzistors[0].baze.addConnection(wires[w++]);

                wires[w] = new wire(andgates[0].tranzistors[0].input.x1, andgates[0].tranzistors[0].input.y1, inputs[0].x, inputs[0].y, inputs[0]);
                andgates[0].tranzistors[0].input.addConnection(wires[w++]);

                wires[w] = new wire(andgates[0].tranzistors[0].baze.x1, andgates[0].tranzistors[0].baze.y1, inputs[0].x, inputs[0].y, inputs[0]);
                andgates[0].tranzistors[0].baze.addConnection(wires[w++]);

                wires[w] = new wire(nands[0].tranzistors[0].input.x1, nands[0].tranzistors[0].input.y1, inputs[0].x, inputs[0].y, inputs[0]);
                nands[0].tranzistors[0].input.addConnection(wires[w++]);

                wires[w] = new wire(nands[0].tranzistors[0].baze.x1, nands[0].tranzistors[0].baze.y1, inputs[0].x, inputs[0].y, inputs[0]);
                nands[0].tranzistors[0].baze.addConnection(wires[w++]);

                wires[w] = new wire(orgates[0].tranzistors[1].input.x1, orgates[0].tranzistors[1].input.y1, inputs[1].x, inputs[1].y, inputs[1]);
                orgates[0].tranzistors[1].input.addConnection(wires[w++]);

                wires[w] = new wire(orgates[0].tranzistors[1].baze.x1, orgates[0].tranzistors[1].baze.y1, inputs[1].x, inputs[1].y, inputs[1]);
                orgates[0].tranzistors[1].baze.addConnection(wires[w++]);

                wires[w] = new wire(andgates[0].tranzistors[1].baze.x1, andgates[0].tranzistors[1].baze.y1, inputs[1].x, inputs[1].y, inputs[1]);
                andgates[0].tranzistors[1].baze.addConnection(wires[w++]);

                wires[w] = new wire(nands[0].tranzistors[1].baze.x1, nands[0].tranzistors[1].baze.y1, inputs[1].x, inputs[1].y, inputs[1]);
                nands[0].tranzistors[1].baze.addConnection(wires[w++]);
            }
            
        }

        public void drawXORGate(Graphics e)
        {
            andgates[0].drawANDGate(e);
            andgates[1].drawANDGate(e);
            orgates[0].drawORGate(e);
            nands[0].drawNANDGate(e);

            if (ifInput)
            {
                inputs[0].drawInput(e);
                inputs[1].drawInput(e);

                foreach (var wr in wires)
                {
                    if (wr != null)
                    {
                        wr.drawWire(e);
                    }
                    else
                        break;
                }
            }
        }
    }
}
