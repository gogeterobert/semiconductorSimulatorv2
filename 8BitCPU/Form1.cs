using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8BitCPU
{
    public partial class Form1 : Form
    {
        int x, y, x2, y2;
        bool clicked = false;

        string button;

        wire[] wires = new wire[100];
        tranzistor[] tranzistors = new tranzistor[50];
        input[] inputs = new input[20];
        not[] nots = new not[20];
        andgate[] ands = new andgate[20];
        orgate[] ors = new orgate[20];
        nandgate[] nands = new nandgate[20];
        xorgate[] xors = new xorgate[50];
        alu alu;


        int w = 0, t = 0, i = 0, n = 0, a = 0, o = 0, nd = 0, xor = 0;
        bool con = false;
        wire conn;
        input ip;

        string type;

        Timer timer = new Timer();
        

        public Form1()
        {
            InitializeComponent();

            timer.Interval = 100;
            timer.Enabled = true;

            Graphics e = this.CreateGraphics();

            timer.Tick += delegate
            {
                if (clicked)
                {
                    clicked = false;

                    if (button == "Right")
                    {
                        if (type == "T")
                        {
                            tranzistors[t++] = new tranzistor(x, y);
                        }
                        if (type == "I")
                        {
                            inputs[i++] = new input(x, y);
                        }
                        if (type == "N")
                        {
                            nots[n++] = new not(x, y);
                        }
                        if (type == "Q")
                        {
                            checkInputsClick(inputs);
                            checkXORClick(xors);
                            if (alu != null)
                                checkXORClick(alu.xorgates);
                        }
                        if (type == "D1")
                        {
                            ands[a++] = new andgate(x, y);
                        }
                        if (type == "D2")
                        {
                            ors[o++] = new orgate(x, y);
                        }
                        if (type == "D3")
                        {
                            nands[nd++] = new nandgate(x, y);
                        }
                        if (type == "D4")
                        {
                            xors[xor++] = new xorgate(x, y, false);
                        }
                        if (type == "D5")
                        {
                            xors[xor++] = new xorgate(x, y, true);
                        }
                        if (type == "D6")
                        {
                            alu = new alu(x, y, 4);
                        }
                    }
                    else
                    {
                        //checkWiresClick();

                        checkTranzistorsClick(tranzistors);
                        checkANDClick(ands);
                        checkORClick(ors);
                        checkNANDClick(nands);
                        checkXORClick(xors);
                        if (alu != null)
                            checkXORClick(alu.xorgates);

                        checkInputsClick(inputs);
                        

                        checkNotsClick(nots);
                    }
                }

                updateWires(wires);
                if (alu != null)
                    updateWires(alu.wires);
                updateTranzistors(tranzistors);
                updateNots(nots);
                updateAND(ands);
                updateOR(ors);
                updateNAND(nands);
                updateXOR(xors);
                if (alu != null)
                    updateXOR(alu.xorgates);

                drawTranzistors(e);
                drawWires(e, wires);
                if (alu != null)
                    drawWires(e, alu.wires);
                drawInputs(e);
                drawNots(e);
                drawANDGates(e);
                drawORGates(e);
                drawNANDGates(e);
                drawXORGates(e, xors);
                if (alu != null)
                    drawXORGates(e, alu.xorgates);
            };
        }

        private void updateWires(wire[] wires)
        {
            for (int j = 0; j < wires.Length; j++)
            {
                if (wires[j] != null)
                {
                    if (wires[j].connection != null)
                    {
                        bool on = false;
                        foreach (var con in wires[j].connection)
                        {
                            if (con != null)
                            {
                                if (con.isOn)
                                {
                                    on = true;
                                    break;
                                }
                            }
                            else
                                break;
                        }

                        if (on)
                        {
                            wires[j].isOn = true;
                        }
                        if (on == false)
                        {
                            wires[j].isOn = false;
                        }

                        if (wires[j].input != null && wires[j].input.isOn)
                        {
                            wires[j].isOn = true;
                        }
                        if (wires[j].input != null && !wires[j].input.isOn)
                        {
                            wires[j].isOn = false;
                        }
                    }
                }
                else
                    break;
            }
            
        }

        

        private void drawWires(Graphics e, wire[] wires)
        { 
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

        private void drawTranzistors(Graphics e)
        {
            foreach (var tranz in tranzistors)
            {
                if (tranz != null)
                {
                    tranz.drawTranzistor(e);
                }
                else
                    break;
            }
        }

        private void drawInputs(Graphics e)
        {
            foreach(var inp in inputs)
            {
                if (inp != null)
                {
                    inp.drawInput(e);
                }
                else
                    break;
            }
        }

        private void drawNots(Graphics e)
        {
            foreach (var n in nots)
            {
                if (n != null)
                {
                    n.drawNot(e);
                }
                else
                    break;
            }
        }

        private void drawANDGates(Graphics e)
        {
            foreach(var g in ands)
            {
                if (g != null)
                {
                    g.drawANDGate(e);
                }
                else
                    break;
            }
        }

        private void drawORGates(Graphics e)
        {
            foreach (var o in ors)
            {
                if (o != null)
                {
                    o.drawORGate(e);
                }
                else
                    break;
            }
        }

        private void drawNANDGates(Graphics e)
        {
            foreach (var a in nands)
            {
                if (a != null)
                {
                    a.drawNANDGate(e);
                }
                else
                    break;
            }
        }

        private void drawXORGates(Graphics e, xorgate[] xors)
        {
            foreach (var x in xors)
            {
                if (x != null)
                {
                    x.drawXORGate(e);
                }
                else
                    break;
            }
        }

        private void checkWiresClick()
        {
            foreach (var wr in wires)
            {
                if (wr != null)
                {
                    if (wr.checkWireClick(x, y, button) == 1)
                    {
                        if (con == false)
                        {
                            con = true;
                            x2 = wr.x1;
                            y2 = wr.y1;
                            conn = wr;
                        }
                        else
                        {
                            wires[w++] = new wire(x, y, x2, y2, ip);
                            con = false;
                            ip = null;
                        }
                        
                        break;
                    }
                }
                else
                    break;
            }
        }

        private void checkTranzistorsClick(tranzistor[] tranzistors)
        {
            foreach (var tr in tranzistors)
            {
                if (tr != null)
                {
                    if (tr.input.checkWireClick(x, y, button) == 1)
                    {
                        if (con == true)
                        {
                            wire a = new wire(x, y, x2, y2, ip);
                            a.addConnection(conn);
                            wires[w++] = a;
                            con = false;
                            tr.input.addConnection(wires[w - 1]);
                            ip = null;
                        }
                        else
                        {
                            con = true;
                            x2 = tr.input.x1;
                            y2 = tr.input.y1;
                            conn = tr.input;
                        }
                        break;
                    }
                    if (tr.baze.checkWireClick(x, y, button) == 1)
                    {
                        if (con == true)
                        {
                            wire a = new wire(x, y, x2, y2, ip);
                            a.addConnection(conn);
                            wires[w++] = a;
                            con = false;
                            tr.baze.addConnection(wires[w - 1]);
                            ip = null;
                        }
                        else
                        {
                            con = true;
                            x2 = tr.baze.x1;
                            y2 = tr.baze.y1;
                            conn = tr.baze;
                        }
                        break;
                    }
                    if (tr.output.checkWireClick(x, y, button) == 1)
                    {
                        if (con == true)
                        {
                            wire a = new wire(x, y, x2, y2, ip);
                            a.addConnection(conn);
                            wires[w++] = a;
                            tr.output.addConnection(wires[w - 1]);
                            con = false;
                            ip = null;
                        }
                        else
                        {
                            con = true;
                            x2 = tr.output.x1;
                            y2 = tr.output.y1;
                            conn = tr.output;
                        }
                        break;
                    }
                }
                else
                    break;
            }
        }

        private void checkInputsClick(input[] inputs)
        {
            foreach(var inp in inputs)
            {
                if (inp!= null && inp.checkInputClick(x, y))
                {
                    if (button == "Right")
                    {
                        inp.isOn = !inp.isOn;
                    }
                    if (button == "Left")
                    {
                        inp.isOn = !inp.isOn;
                        if (con == false)
                        {
                            con = true;
                            x2 = inp.x;
                            y2 = inp.y;
                            ip = inp;
                        }
                    }
                }
            }
        }

        private void checkNotsClick(not[] nots)
        {
            foreach (var n in nots)
            {
                if (n != null)
                {
                    if (n.input.checkWireClick(x, y, button) == 1)
                    {
                        if (con == true)
                        {
                            wire a = new wire(x, y, x2, y2, ip);
                            a.addConnection(conn);
                            wires[w++] = a;
                            con = false;
                            n.input.addConnection(wires[w - 1]);
                            ip = null;
                        }
                        else
                        {
                            con = true;
                            x2 = n.input.x1;
                            y2 = n.input.y1;
                            conn = n.input;
                        }
                        break;
                    }
                    if (n.output.checkWireClick(x, y, button) == 1)
                    {
                        if (con == true)
                        {
                            wire a = new wire(x, y, x2, y2, ip);
                            a.addConnection(conn);
                            wires[w++] = a;
                            n.output.addConnection(wires[w - 1]);
                            con = false;
                            ip = null;
                        }
                        else
                        {
                            con = true;
                            x2 = n.output.x1;
                            y2 = n.output.y1;
                            conn = n.output;
                        }
                        break;
                    }
                }
                else
                    break;
            }
        }

        private void checkANDClick(andgate[] ands)
        {
            foreach(var a in ands)
            {
                if (a != null)
                {
                    checkTranzistorsClick(a.tranzistors);
                }
                else
                    break;
            }
        }

        private void checkORClick(orgate[] ors)
        {
            foreach (var o in ors)
            {
                if (o != null)
                {
                    checkTranzistorsClick(o.tranzistors);
                }
                else
                    break;
            }
        }

        private void checkNANDClick(nandgate[] nands)
        {
            foreach (var n in nands)
            {
                if (n != null)
                {
                    checkTranzistorsClick(n.tranzistors);
                    checkNotsClick(n.nots);
                }
                else break;
            }
        }

        private void checkXORClick(xorgate[] xors)
        {
            foreach(var x in xors)
            {
                if (x != null)
                {
                    checkANDClick(x.andgates);
                    checkORClick(x.orgates);
                    checkNANDClick(x.nands);
                    checkInputsClick(x.inputs);
                }
                else
                    break;
            }
        }

        private void updateTranzistors(tranzistor[] tranzistors)
        {
            for (int j = 0; j < tranzistors.Length; j++)
            {
                if (tranzistors[j] != null)
                {
                    if (tranzistors[j].input.connection != null)
                    {
                        bool on = false;
                        foreach (var con in tranzistors[j].input.connection)
                        {
                            if (con != null)
                            {
                                if (con.isOn)
                                {
                                    on = true;
                                    break;
                                }
                            }
                            else
                                break;
                        }

                        if (on)
                        {
                            tranzistors[j].input.isOn = true;
                        }
                        if (on == false)
                        {
                            tranzistors[j].input.isOn = false;
                        }
                    }

                    if (tranzistors[j] != null && tranzistors[j].baze.connection != null)
                    {
                        bool on = false;
                        foreach (var con in tranzistors[j].baze.connection)
                        {
                            if (con != null)
                            {
                                if (con.isOn)
                                {
                                    on = true;
                                    break;
                                }
                            }
                            else
                                break;
                        }

                        if (on)
                        {
                            tranzistors[j].baze.isOn = true;
                        }
                        if (on == false)
                        {
                            tranzistors[j].baze.isOn = false;
                        }
                    }


                    if (tranzistors[j].input.isOn && tranzistors[j].baze.isOn)
                    {
                        tranzistors[j].output.isOn = true;
                    }
                    else
                        tranzistors[j].output.isOn = false;
                }
                else
                    break;
            }
        }

        private void updateNots(not[] nots)
        {
            for (int j = 0; j < nots.Length; j++)
            {
                if (nots[j] != null)
                {
                    if (nots[j].input.connection != null)
                    {
                        bool on = false;
                        foreach (var con in nots[j].input.connection)
                        {
                            if (con != null)
                            {
                                if (con.isOn)
                                {
                                    on = true;
                                    break;
                                }
                            }
                            else
                                break;
                        }
                        if (on)
                        {
                            nots[j].input.isOn = true;
                            nots[j].output.isOn = false;
                        }
                        else
                        {
                            nots[j].input.isOn = false;
                            nots[j].output.isOn = true;
                        }
                    }
                }
                else
                    break;
            }
        }

        private void updateAND(andgate[] ands)
        {
            foreach(var a in ands)
            {
                if (a != null)
                {
                    updateTranzistors(a.tranzistors);
                    updateWires(a.wire);
                }
                else
                    break;
            }
        }

        private void updateOR(orgate[] ors)
        {
            foreach (var o in ors)
            {
                if (o != null)
                {
                    updateTranzistors(o.tranzistors);
                    updateWires(o.wire);
                }
                else
                    break;
            }
        }

        private void updateNAND(nandgate[] nands)
        {
            foreach (var a in nands)
            {
                if (a != null)
                {
                    updateTranzistors(a.tranzistors);
                    updateWires(a.wire);
                    updateNots(a.nots);
                }
                else
                    break;
            }
        }

        private void updateXOR(xorgate[] xors)
        {
            foreach (var x in xors)
            {
                if (x != null)
                {
                    updateAND(x.andgates);
                    updateOR(x.orgates);
                    updateNAND(x.nands);
                    updateWires(x.wires);
                }
                else
                    break;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            clicked = true;
            button = e.Button.ToString();
            x = e.X;
            y = e.Y;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            type = e.KeyData.ToString();
        }
    }
}
