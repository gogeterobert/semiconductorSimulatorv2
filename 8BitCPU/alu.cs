using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8BitCPU
{
    class alu
    {
        public xorgate[] xorgates = new xorgate[100];
        public wire[] wires = new wire[30];
        public int x, y;
        int xor = 0, w = 0;

        public alu(int x, int y, int bits)
        {
            this.x = x;
            this.y = y;

            xorgates[xor++] = new xorgate(x, y, true);

            for (int j = 0; j < bits; j++)
            {
                if (j == 0)
                {
                    wire wr1 = xorgates[xor - 1].andgates[0].tranzistors[1].output;
                    xorgates[xor++] = new xorgate(x + (j + 1) * 110, y, true);
                    xorgates[xor++] = new xorgate(x + (j + 1) * 110, y - 80, false);
                    wire wr2 = xorgates[xor - 1].andgates[0].tranzistors[1].output;

                    wires[w] = new wire(xorgates[xor - 1].orgates[0].tranzistors[0].input.x1, xorgates[xor - 1].orgates[0].tranzistors[0].input.y1, wr1.x1, wr1.y1, null);
                    wires[w].addConnection(wr1);
                    xorgates[xor - 1].orgates[0].tranzistors[0].input.addConnection(wires[w++]);

                    wires[w] = new wire(xorgates[xor - 1].orgates[0].tranzistors[0].baze.x1, xorgates[xor - 1].orgates[0].tranzistors[0].baze.y1, wr1.x1, wr1.y1, null);
                    wires[w].addConnection(wr1);
                    xorgates[xor - 1].orgates[0].tranzistors[0].baze.addConnection(wires[w++]);

                    wires[w] = new wire(xorgates[xor - 1].andgates[0].tranzistors[0].input.x1, xorgates[xor - 1].andgates[0].tranzistors[0].input.y1, wr1.x1, wr1.y1, null);
                    wires[w].addConnection(wr1);
                    xorgates[xor - 1].andgates[0].tranzistors[0].input.addConnection(wires[w++]);

                    wires[w] = new wire(xorgates[xor - 1].andgates[0].tranzistors[0].baze.x1, xorgates[xor - 1].andgates[0].tranzistors[0].baze.y1, wr1.x1, wr1.y1, null);
                    wires[w].addConnection(wr1);
                    xorgates[xor - 1].andgates[0].tranzistors[0].baze.addConnection(wires[w++]);

                    wires[w] = new wire(xorgates[xor - 1].nands[0].tranzistors[0].input.x1, xorgates[xor - 1].nands[0].tranzistors[0].input.y1, wr1.x1, wr1.y1, null);
                    wires[w].addConnection(wr1);
                    xorgates[xor - 1].nands[0].tranzistors[0].input.addConnection(wires[w++]);

                    wires[w] = new wire(xorgates[xor - 1].nands[0].tranzistors[0].baze.x1, xorgates[xor - 1].nands[0].tranzistors[0].baze.y1, wr1.x1, wr1.y1, null);
                    wires[w].addConnection(wr1);
                    xorgates[xor - 1].nands[0].tranzistors[0].baze.addConnection(wires[w++]);

                    /*
                    xorgates[xor - 1].orgates[0].tranzistors[1].input.addConnection(wr1);
                    xorgates[xor - 1].orgates[0].tranzistors[1].baze.addConnection(wr1);
                    xorgates[xor - 1].nands[0].tranzistors[0].input.addConnection(wr2);
                    xorgates[xor - 1].nands[0].tranzistors[0].baze.addConnection(wr2);
                    xorgates[xor - 1].nands[0].tranzistors[1].input.addConnection(wr1);
                    xorgates[xor - 1].nands[0].tranzistors[1].baze.addConnection(wr1);
                    xorgates[xor - 1].andgates[0].tranzistors[0].input.addConnection(wr2);
                    xorgates[xor - 1].andgates[0].tranzistors[0].baze.addConnection(wr2);
                    xorgates[xor - 1].andgates[0].tranzistors[1].baze.addConnection(wr1);*/
                }
                else
                {
                    wire wr1 = xorgates[xor - 2].andgates[0].tranzistors[1].output;
                    xorgates[xor++] = new xorgate(x + (j + 1) * 110, y, true);
                    xorgates[xor++] = new xorgate(x + (j + 1) * 110, y - 80, false);
                    wire wr2 = xorgates[xor - 1].andgates[0].tranzistors[1].output;

                    wires[w] = new wire(xorgates[xor - 1].orgates[0].tranzistors[0].input.x1, xorgates[xor - 1].orgates[0].tranzistors[0].input.y1, wr1.x1, wr1.y1, null);
                    wires[w].addConnection(wr1);
                    xorgates[xor - 1].orgates[0].tranzistors[0].input.addConnection(wires[w++]);

                    wires[w] = new wire(xorgates[xor - 1].orgates[0].tranzistors[0].baze.x1, xorgates[xor - 1].orgates[0].tranzistors[0].baze.y1, wr1.x1, wr1.y1, null);
                    wires[w].addConnection(wr1);
                    xorgates[xor - 1].orgates[0].tranzistors[0].baze.addConnection(wires[w++]);

                    wires[w] = new wire(xorgates[xor - 1].andgates[0].tranzistors[0].input.x1, xorgates[xor - 1].andgates[0].tranzistors[0].input.y1, wr1.x1, wr1.y1, null);
                    wires[w].addConnection(wr1);
                    xorgates[xor - 1].andgates[0].tranzistors[0].input.addConnection(wires[w++]);

                    wires[w] = new wire(xorgates[xor - 1].andgates[0].tranzistors[0].baze.x1, xorgates[xor - 1].andgates[0].tranzistors[0].baze.y1, wr1.x1, wr1.y1, null);
                    wires[w].addConnection(wr1);
                    xorgates[xor - 1].andgates[0].tranzistors[0].baze.addConnection(wires[w++]);

                    wires[w] = new wire(xorgates[xor - 1].nands[0].tranzistors[0].input.x1, xorgates[xor - 1].nands[0].tranzistors[0].input.y1, wr1.x1, wr1.y1, null);
                    wires[w].addConnection(wr1);
                    xorgates[xor - 1].nands[0].tranzistors[0].input.addConnection(wires[w++]);

                    wires[w] = new wire(xorgates[xor - 1].nands[0].tranzistors[0].baze.x1, xorgates[xor - 1].nands[0].tranzistors[0].baze.y1, wr1.x1, wr1.y1, null);
                    wires[w].addConnection(wr1);
                    xorgates[xor - 1].nands[0].tranzistors[0].baze.addConnection(wires[w++]);
                }
            }
        }
    }
}
