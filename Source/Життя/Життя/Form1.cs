using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Життя
{

    public partial class Form1 : Form
    {
        public Form2 main_form;
        public Form1()
        {
            InitializeComponent();
            AddOwnedForm(main_form);
        }

        private void Frm1_Load(object sender, EventArgs e)
        {
            pctr1.BringToFront();
        }

        const int fieldSize = 100;
        const int cellSize = 6;
        const int lineWidth = 1;
        const int elementSize = cellSize + lineWidth;

        int[,] cells = new int[fieldSize, fieldSize];
        int[,] cellsFuture = new int[fieldSize, fieldSize];
        int[,] neighbors = new int[fieldSize, fieldSize];

        Random r = new Random();
        Graphics g;

        int neighborCount;
        int blueNeighborCount;
        int redNeighborCount;
        int cycleNumber = 0;
        double cellCount = 0;
        int enteringColour = 1;
        int colourCount = 1;
        int enteredColour;
        int prevX = -1;
        int prevY = -1;
        double density;
        string filename;
        private void btn1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            btn3.Visible = true;
            btn4.Enabled = false;
            btn4.Visible = true;
        }

        private void pctr1_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            g = pctr1.CreateGraphics();
            cellCount = 0;
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    if (cellsFuture[i, j] == 0)
                    {
                        g.FillRectangle(Brushes.White, i * elementSize + lineWidth, j * elementSize + lineWidth, cellSize, cellSize);
                    }
                    else
                    {
                        if (colourCount != 9)
                        {
                            if (cellsFuture[i, j] == 1)
                                g.FillRectangle(Brushes.Blue, i * elementSize + lineWidth, j * elementSize + lineWidth, cellSize, cellSize);
                            if (cellsFuture[i, j] == 2)
                                g.FillRectangle(Brushes.Red, i * elementSize + lineWidth, j * elementSize + lineWidth, cellSize, cellSize);
                            cellCount++;
                        }
                        else
                        {
                            SolidBrush br = new SolidBrush(Color.FromArgb(255 - 31 * (cellsFuture[i, j] - 1), 255 - 31 * (cellsFuture[i, j] - 1), 31 * (cellsFuture[i, j] - 1)));
                            if (cellsFuture[i, j] == 3)
                                br.Color = Color.Red;
                            if (cellsFuture[i, j] == 4)
                                br.Color = Color.DarkOrange;
                            if (cellsFuture[i, j] == 1)
                                br.Color = Color.Black;
                            if (cellsFuture[i, j] == 2)
                                br.Color = Color.MidnightBlue;
                            g.FillRectangle(br, i * elementSize + lineWidth, j * elementSize + lineWidth, cellSize, cellSize);
                            cellCount++;
                        }
                    }
                }
            }
            lbl2.Text = cellCount.ToString();
            density = cellCount / 100;
            density = Math.Round(density, 2);
            lbl3.Text = density.ToString();
            Array.Copy(cellsFuture, cells, 10000);
            if ((cycleNumber % 2 == 1) | (chkbx1.Checked == false))
            {
                for (int i = 0; i < 100; i++)
                {
                    for (int j = 0; j < 100; j++)
                    {
                        neighborCount = 0;
                        blueNeighborCount = 0;
                        redNeighborCount = 0;
                        for (int t = 0; t < 3; t++)
                        {
                            for (int s = 0; s < 3; s++)
                            {
                                if ((cells[((i + t) + 99) % 100, ((j + s) + 99) % 100] != 0) && ((t != 1) || (s != 1)))
                                {
                                    neighborCount++;
                                }
                            }
                        }

                        if (colourCount != 9)
                        {
                            if (neighborCount == 3)
                            {
                                if (colourCount == 1)
                                    cellsFuture[i, j] = 1;
                                else
                                {
                                    for (int t = 0; t < 3; t++)
                                    {
                                        for (int s = 0; s < 3; s++)
                                        {
                                            if ((cells[((i + t) + 99) % 100, ((j + s) + 99) % 100] == 1) && ((t != 1) || (s != 1)))
                                            {
                                                blueNeighborCount++;
                                            }
                                            if ((cells[((i + t) + 99) % 100, ((j + s) + 99) % 100] == 2) && ((t != 1) || (s != 1)))
                                            {
                                                redNeighborCount++;
                                            }
                                        }
                                    }
                                    if (blueNeighborCount > redNeighborCount)
                                        cellsFuture[i, j] = 1;
                                    else
                                        cellsFuture[i, j] = 2;
                                }
                            }
                            if (neighborCount == 2)
                                cellsFuture[i, j] = cells[i, j];
                            if ((neighborCount != 2) & (neighborCount != 3))
                                cellsFuture[i, j] = 0;
                        }
                        else
                        {
                            if (cells[i, j] == 0)
                            {
                                if (neighborCount == 3)
                                {
                                    for (int t = 0; t < 3; t++)
                                    {
                                        for (int s = 0; s < 3; s++)
                                        {
                                            int n = r.Next(0, 3);
                                            int k = 0;
                                            if (cells[((i + t) + 99) % 100, ((j + s) + 99) % 100] != 0)
                                            {
                                                if (k == n)
                                                    cellsFuture[i, j] = cells[((i + t) + 99) % 100, ((j + s) + 99) % 100];
                                                else
                                                    k++;
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if ((cells[i, j] != neighborCount + 1) && (cells[i, j] != neighborCount + 2))
                                {
                                    cellsFuture[i, j] = 0;
                                }
                                else
                                {
                                    cellsFuture[i, j] = cells[i, j];
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < 100; i++)
                {
                    for (int j = 0; j < 100; j++)
                    {
                        neighborCount = 0;
                        blueNeighborCount = 0;
                        redNeighborCount = 0;
                        for (int t = 0; t < 3; t++)
                        {
                            for (int s = 0; s < 3; s++)
                            {
                                if ((cells[((i + t) + 99) % 100, ((j + s) + 99) % 100] != 0) && ((t != 1) || (s != 1)))
                                {
                                    neighborCount++;
                                }
                            }
                        }
                        neighbors[i, j] = neighborCount;
                    }
                }

                for (int i = 0; i < 100; i++)
                {
                    for (int j = 0; j < 100; j++)
                    {
                        if ((cells[i, j] != 0) && (neighbors[i, j] != 2) && (neighbors[i, j] != 3))
                        {
                            for (int t = 0; t < 3; t++)
                            {
                                for (int s = 0; s < 3; s++)
                                {
                                    if (((neighbors[((i + t) + 99) % 100, ((j + s) + 99) % 100] == 4) || 
                                        (neighbors[((i + t) + 99) % 100, ((j + s) + 99) % 100] == 3)) && 
                                        (cells[((i + t) + 99) % 100, ((j + s) + 99) % 100] == 0) && ((t != 1) || (s != 1)))
                                    {
                                        cells[((i + t) + 99) % 100, ((j + s) + 99) % 100] = cells[i, j];
                                        cells[i, j] = 0;
                                    }
                                    neighbors[(i + 99) % 100, (j + 99) % 100]--;
                                    neighbors[i, (j + 99) % 100]--;
                                    neighbors[(i + 1) % 100, (j + 99) % 100]--;
                                    neighbors[(i + 99) % 100, j]--;
                                    neighbors[i, j]--;
                                    neighbors[(i + 1) % 100, j]--;
                                    neighbors[(i + 99) % 100, (j + 1) % 100]--;
                                    neighbors[i, (j + 1) % 100]--;
                                    neighbors[(i + 1) % 100, (j + 1) % 100]--;

                                    neighbors[((i + t) + 98) % 100, ((j + s) + 98) % 100]++;
                                    neighbors[((i + t) + 99) % 100, ((j + s) + 98) % 100]++;
                                    neighbors[(i + t) % 100, ((j + s) + 98) % 100]++;
                                    neighbors[((i + t) + 98) % 100, ((j + s) + 99) % 100]++;
                                    neighbors[((i + t) + 99) % 100, ((j + s) + 99) % 100]++;
                                    neighbors[(i + t) % 100, ((j + s) + 99) % 100]++;
                                    neighbors[((i + t) + 98) % 100, (j + s) % 100]++;
                                    neighbors[((i + t) + 99) % 100, (j + s) % 100]++;
                                    neighbors[(i + t) % 100, (j + s) % 100]++;
                                }
                            }
                        }
                    }
                }
            }
            cycleNumber++;
            lbl1.Text = cycleNumber.ToString();
            if (chkbx1.Checked == true)
                lbl1.Text = (cycleNumber / 2).ToString();
            density = cellCount / 100;
            density = Math.Round(density, 2);
            lbl3.Text = density.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pctr1.BringToFront();
            timer1.Stop();
            cellCount = 0;
            cycleNumber = 0;
            lbl2.Text = cellCount.ToString();
            lbl1.Text = cycleNumber.ToString();
            density = cellCount / 100;
            density = Math.Round(density, 2);
            lbl3.Text = density.ToString();
            g = pctr1.CreateGraphics();
            g.Clear(Color.White);
            for (int i = 0; i < 101; i++)
            {
                g.DrawLine(Pens.Black, i * 7, 0, i * 7, pctr1.Width - 1);
                g.DrawLine(Pens.Black, 0, i * 7, pctr1.Height - 1, i * 7);
            }
            btn1.Visible = true;
            Array.Clear(cells, 0, 10000);
            Array.Clear(cellsFuture, 0, 10000);
            openFileDialog1.InitialDirectory = Application.StartupPath;
            openFileDialog1.Filter = "Файли TXT (*.txt)|*.txt";
            openFileDialog1.FileName = "0000.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
                string[] ast = File.ReadAllLines(filename, Encoding.UTF8);
                if ((ast[0] == "1") | (ast[0] == "3"))
                {
                    colourCount = 1;
                }
                else
                {
                    colourCount = 2;
                }
                for (int i = 1; i <= 100; i++)
                {
                    string st1 = ast[i];
                    for (int j = 0; j <= 99; j++)
                    {
                        if (st1[j] == '1')
                        {
                            g.FillRectangle(Brushes.Blue, (i - 1) * elementSize + lineWidth, j * elementSize + lineWidth, cellSize, cellSize);
                            cells[i - 1, j] = 1;
                            cellsFuture[i - 1, j] = 1;
                            cellCount++;
                        }
                        if (st1[j] == '2')
                        {
                            g.FillRectangle(Brushes.Red, (i - 1) * elementSize + lineWidth, j * elementSize + lineWidth, cellSize, cellSize);
                            cells[i - 1, j] = 2;
                            cellsFuture[i - 1, j] = 2;
                            cellCount++;
                        }
                        lbl2.Text = cellCount.ToString();
                        density = cellCount / 100;
                        density = Math.Round(density, 2);
                        lbl3.Text = density.ToString();
                    }
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void Frm1_LocationChanged(object sender, EventArgs e)
        {

        }

        private void btn3_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            btn4.Enabled = true;
        }

        private void rdBtn4_CheckedChanged(object sender, EventArgs e)
        {
            colourCount = 2;
            timer1.Stop();
            btn4.Visible = true;
            cellCount = 0;
            cycleNumber = 0;
            lbl2.Text = cellCount.ToString();
            density = cellCount / 100;
            density = Math.Round(density, 2);
            lbl3.Text = density.ToString();
            lbl1.Text = cycleNumber.ToString();
            g = pctr1.CreateGraphics();
            g.Clear(Color.White);
            for (int i = 0; i < 101; i++)
            {
                g.DrawLine(Pens.Black, i * 7, 0, i * 7, pctr1.Width - 1);
                g.DrawLine(Pens.Black, 0, i * 7, pctr1.Height - 1, i * 7);
            }
            btn1.Visible = true;
            Array.Clear(cells, 0, 10000);
            Array.Clear(cellsFuture, 0, 10000);
            if (rdBtn5.Checked == true)
            {
                rdBtn1.Checked = true;
                rdBtn2.Enabled = true;
                txtBx1.Visible = false;
                grpBx1.Visible = true;
            }
        }

        private void rdBtn4_CheckedChanged_1(object sender, EventArgs e)
        {
            timer1.Stop();
            colourCount = 1;
            btn4.Visible = true;
            cellCount = 0;
            cycleNumber = 0;
            lbl2.Text = cellCount.ToString();
            density = cellCount / 100;
            density = Math.Round(density, 2);
            lbl3.Text = density.ToString();
            lbl1.Text = cycleNumber.ToString();
            g = pctr1.CreateGraphics();
            g.Clear(Color.White);
            for (int i = 0; i < 101; i++)
            {
                g.DrawLine(Pens.Black, i * 7, 0, i * 7, pctr1.Width - 1);
                g.DrawLine(Pens.Black, 0, i * 7, pctr1.Height - 1, i * 7);
            }
            btn1.Visible = true;
            Array.Clear(cells, 0, 10000);
            Array.Clear(cellsFuture, 0, 10000);
            if (rdBtn4.Checked == true)
            {
                rdBtn1.Checked = true;
                rdBtn2.Enabled = false;
                txtBx1.Visible = false;
                grpBx1.Visible = true;
            }
        }

        private void rdBtn6_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Stop();
            colourCount = 3;
            btn4.Visible = true;
            cellCount = 0;
            cycleNumber = 0;
            lbl2.Text = cellCount.ToString();
            density = cellCount / 100;
            density = Math.Round(density, 2);
            lbl3.Text = density.ToString();
            lbl1.Text = cycleNumber.ToString();
            g = pctr1.CreateGraphics();
            g.Clear(Color.White);
            for (int i = 0; i < 101; i++)
            {
                g.DrawLine(Pens.Black, i * 7, 0, i * 7, pctr1.Width - 1);
                g.DrawLine(Pens.Black, 0, i * 7, pctr1.Height - 1, i * 7);
            }
            btn1.Visible = true;
            Array.Clear(cells, 0, 10000);
            Array.Clear(cellsFuture, 0, 10000);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = Application.StartupPath;
            saveFileDialog1.Filter = "Файли TXT (*.txt)|*.txt";
            saveFileDialog1.FileName = "New Life.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = saveFileDialog1.FileName;
                StreamWriter sw = new StreamWriter(filename);
                if (colourCount == 1)
                    sw.Write("1");
                if (colourCount == 2)
                    sw.Write("2");
                if (colourCount == 9)
                    sw.Write("9");
                for (int i = 0; i <= 99; i++)
                {
                    sw.WriteLine();
                    for (int j = 0; j <= 99; j++)
                    {
                        sw.Write(cells[i, j].ToString());
                    }
                }
                sw.Close();
            }
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void rdBtn7_CheckedChanged(object sender, EventArgs e)
        {
            colourCount = 9;
            timer1.Stop();
            btn4.Visible = true;
            cellCount = 0;
            cycleNumber = 0;
            lbl2.Text = cellCount.ToString();
            density = cellCount / 100;
            density = Math.Round(density, 2);
            lbl3.Text = density.ToString();
            lbl1.Text = cycleNumber.ToString();
            g = pctr1.CreateGraphics();
            g.Clear(Color.White);
            for (int i = 0; i < 101; i++)
            {
                g.DrawLine(Pens.Black, i * 7, 0, i * 7, pctr1.Width - 1);
                g.DrawLine(Pens.Black, 0, i * 7, pctr1.Height - 1, i * 7);
            }
            btn1.Visible = true;
            Array.Clear(cells, 0, 10000);
            Array.Clear(cellsFuture, 0, 10000);
            if (rdBtn7.Checked)
            {
                txtBx1.Visible = true;
                grpBx1.Visible = false;
            }
        }

        private void rdBtn1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdBtn1.Checked)
                enteringColour = 1;
            else
                enteringColour = 2;
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            pctr1.BringToFront();
            timer1.Stop();
            cellCount = 0;
            cycleNumber = 0;
            lbl2.Text = cellCount.ToString();
            density = cellCount / 100;
            density = Math.Round(density, 2);
            lbl3.Text = density.ToString();
            lbl1.Text = cycleNumber.ToString();
            g = pctr1.CreateGraphics();
            g.Clear(Color.White);
            for (int i = 0; i < 101; i++)
            {
                g.DrawLine(Pens.Black, i * elementSize, 0, i * elementSize, pctr1.Width - lineWidth);
                g.DrawLine(Pens.Black, 0, i * elementSize, pctr1.Height - 1, i * elementSize);
            }
            btn1.Visible = true;
            Array.Clear(cells, 0, 10000);
            Array.Clear(cellsFuture, 0, 10000);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btn7_Click(object sender, EventArgs e)
        {
            pctr1.BringToFront();
            timer1.Stop();
            cellCount = 0;
            cycleNumber = 0;
            lbl2.Text = cellCount.ToString();
            density = cellCount / 100;
            density = Math.Round(density, 2);
            lbl3.Text = density.ToString();
            lbl1.Text = cycleNumber.ToString();
            g = pctr1.CreateGraphics();
            g.Clear(Color.White);
            for (int i = 0; i < 101; i++)
            {
                g.DrawLine(Pens.Black, i * elementSize, 0, i * elementSize, pctr1.Width - lineWidth);
                g.DrawLine(Pens.Black, 0, i * elementSize, pctr1.Height - lineWidth, i * elementSize);
            }
            btn1.Visible = true;
            Array.Clear(cells, 0, 10000);
            Array.Clear(cellsFuture, 0, 10000);
            int ro = 0;
            if (int.TryParse(txtBx2.Text, out ro))
            {
                int x;
                for (int i = 0; i < 100; i++)
                {
                    for (int j = 0; j < 100; j++)
                    {
                        x = r.Next(1, 101);
                        if (x <= ro)
                        {
                            x = r.Next(1, colourCount + 1);
                            cells[i, j] = x;
                            cellsFuture[i, j] = x;
                            cellCount++;
                        }
                        else
                        {
                            cells[i, j] = 0;
                            cellsFuture[i, j] = 0;
                        }
                    }
                }
                lbl2.Text = cellCount.ToString();
                density = cellCount / 100;
                density = Math.Round(density, 2);
                lbl3.Text = density.ToString();
                for (int i = 0; i < 100; i++)
                {
                    for (int j = 0; j < 100; j++)
                    {
                        if (cellsFuture[i, j] == 0)
                        {
                            g.FillRectangle(Brushes.White, i * elementSize + lineWidth, j * elementSize + lineWidth, cellSize, cellSize);
                        }
                        else
                        {
                            if (colourCount != 9)
                            {
                                if (cellsFuture[i, j] == 1)
                                    g.FillRectangle(Brushes.Blue, i * elementSize + lineWidth, j * elementSize + lineWidth, cellSize, cellSize);
                                if (cellsFuture[i, j] == 2)
                                    g.FillRectangle(Brushes.Red, i * elementSize + lineWidth, j * elementSize + lineWidth, cellSize, cellSize);
                                cellCount++;
                            }
                            else
                            {
                                SolidBrush br = new SolidBrush(Color.FromArgb(255 - 31 * (cellsFuture[i, j] - 1), 255 - 31 * (cellsFuture[i, j] - 1), 31 * (cellsFuture[i, j] - 1)));
                                if (cellsFuture[i, j] == 3)
                                    br.Color = Color.Red;
                                if (cellsFuture[i, j] == 4)
                                    br.Color = Color.DarkOrange;
                                if (cellsFuture[i, j] == 1)
                                    br.Color = Color.Black;
                                if (cellsFuture[i, j] == 2)
                                    br.Color = Color.MidnightBlue;
                                g.FillRectangle(br, i * elementSize + lineWidth, j * elementSize + lineWidth, cellSize, cellSize);
                                cellCount++;
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Enter number between 0 and 101");
                txtBx2.Text = "20";
            }
        }

        private void grpBx1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }

        private void txtBx2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtBx1_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtBx1.Text, out enteredColour))
            {
                if ((enteredColour < 0) || (enteredColour > 8))
                {
                    MessageBox.Show("Enter number between 0 and 9");
                    txtBx1.Text = "3";
                }
            }
            else
            {
                MessageBox.Show("Enter number between 0 and 9");
                txtBx1.Text = "3";
            }
        }

        private void chkbx1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void timerEntering_Tick(object sender, EventArgs e)
        {
            Point p = this.Location;
            int x = MousePosition.X - p.X - pctr1.Location.X - 3;
            int y = MousePosition.Y - p.Y - pctr1.Location.Y - 3;
            x = x / elementSize - 1;
            y = y / elementSize - 4;
            if ((x >= 0) & (x <= 99) & (y >= 0) & (y <= 99) & ((x != prevX) || (y != prevY)))
            {
                if (cells[x, y] == 0)
                {
                    if (colourCount != 9)
                    {
                        if (enteringColour == 1)
                            g.FillRectangle(Brushes.Blue, x * elementSize + lineWidth, y * elementSize + lineWidth, cellSize, cellSize);
                        if (enteringColour == 2)
                            g.FillRectangle(Brushes.Red, x * elementSize + lineWidth, y * elementSize + 1, cellSize, cellSize);
                        cells[x, y] = enteringColour;
                        cellsFuture[x, y] = enteringColour;
                    }
                    else
                    {
                        //enteredColour = int.Parse(txtBx1.Text);
                        SolidBrush br = new SolidBrush(Color.FromArgb(255 - 31 * enteredColour, 255 - 31 * enteredColour, 31 * enteredColour));
                        enteredColour++;
                        if (enteredColour == 3)
                            br.Color = Color.Red;
                        if (enteredColour == 4)
                            br.Color = Color.DarkOrange;
                        if (enteredColour == 1)
                            br.Color = Color.Black;
                        if (enteredColour == 2)
                            br.Color = Color.MidnightBlue;
                        g.FillRectangle(br, x * elementSize + lineWidth, y * elementSize + lineWidth, cellSize, cellSize);
                        cells[x, y] = enteredColour;
                        cellsFuture[x, y] = enteredColour;
                    }
                    cellCount++;
                }
                else
                {
                    g.FillRectangle(Brushes.White, x * elementSize + lineWidth, y * elementSize + 1, cellSize, cellSize);
                    cells[x, y] = 0;
                    cellsFuture[x, y] = 0;
                    cellCount--;
                }
              prevX = x;
              prevY = y;
            }
        }

        private void pctr1_MouseUp(object sender, MouseEventArgs e)
        {
            timerEntering.Stop();
            lbl2.Text = cellCount.ToString();
            density = (cellCount / (fieldSize * fieldSize)) * 100;
            density = Math.Round(density, 2);
            lbl3.Text = density.ToString();
            prevX = -1;
            prevY = -1;
        }

        private void pctr1_MouseDown(object sender, MouseEventArgs e)
        {
            timerEntering.Start();
        }
    }
}
