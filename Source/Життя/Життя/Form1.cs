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

        }
        int[,] a = new int[100, 100];
        int[,] b = new int[100, 100];
        int[,] w = new int[100, 100];
        List<int> l = new List<int>();
        Random r = new Random();
        Graphics g;
        int s;
        int ss;
        int sk;
        int d = 0;
        int xod = 0;
        double k = 0;
        int zvet = 1;
        int col = 1;
        int so;
        double ro2;
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
            if (rdBtn1.Checked == true)
                zvet = 1;
            if (rdBtn2.Checked == true)
                zvet = 2;
            if (d == 1)
            {
                Point p = this.Location;
                int x = MousePosition.X - p.X - pctr1.Location.X - 3;
                int y = MousePosition.Y - p.Y - pctr1.Location.Y - 3;
                x = x / 7 - 1;
                y = y / 7 - 4;
                if ((x >= 0) & (x <= 99) & (y >= 0) & (y <= 99))
                {
                    if (a[x, y] == 0)
                    {
                        if (col != 9)
                        {
                            if (zvet == 1)
                                g.FillRectangle(Brushes.Blue, x * 7 + 1, y * 7 + 1, 6, 6);
                            if (zvet == 2)
                                g.FillRectangle(Brushes.Red, x * 7 + 1, y * 7 + 1, 6, 6);
                            a[x, y] = zvet;
                            b[x, y] = zvet;
                        }
                        else
                        {
                            so = int.Parse(txtBx1.Text);
                            SolidBrush br = new SolidBrush(Color.FromArgb(255 - 31 * so, 255 - 31 * so, 31 * so));
                            so++;
                            if (so == 3)
                                br.Color = Color.Red;
                            if (so == 4)
                                br.Color = Color.DarkOrange;
                            if (so == 1)
                                br.Color = Color.Black;
                            if (so == 2)
                                br.Color = Color.MidnightBlue;
                            g.FillRectangle(br, x * 7 + 1, y * 7 + 1, 6, 6);
                            a[x, y] = so;
                            b[x, y] = so;
                        }
                        k++;
                    }
                    else
                    {
                        g.FillRectangle(Brushes.White, x * 7 + 1, y * 7 + 1, 6, 6);
                        a[x, y] = 0;
                        b[x, y] = 0;
                        k--;
                    }
                }
            }
            lbl2.Text = "Живых клеток: " + k;
            ro2 = k / 100;
            ro2 = Math.Round(ro2, 2);
            lbl3.Text = "Щільність (%): " + ro2;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            k = 0;
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    if (b[i, j] == 0)
                    {
                        g.FillRectangle(Brushes.White, i * 7 + 1, j * 7 + 1, 6, 6);
                    }
                    else
                    {
                        if (col != 9)
                        {
                            if (b[i, j] == 1)
                                g.FillRectangle(Brushes.Blue, i * 7 + 1, j * 7 + 1, 6, 6);
                            if (b[i, j] == 2)
                                g.FillRectangle(Brushes.Red, i * 7 + 1, j * 7 + 1, 6, 6);
                            k++;
                        }
                        else
                        {
                            SolidBrush br = new SolidBrush(Color.FromArgb(255 - 31 * (b[i, j] - 1), 255 - 31 * (b[i, j] - 1), 31 * (b[i, j] - 1)));
                            if (b[i, j] == 3)
                                br.Color = Color.Red;
                            if (b[i, j] == 4)
                                br.Color = Color.DarkOrange;
                            if (b[i, j] == 1)
                                br.Color = Color.Black;
                            if (b[i, j] == 2)
                                br.Color = Color.MidnightBlue;
                            g.FillRectangle(br, i * 7 + 1, j * 7 + 1, 6, 6);
                            k++;
                        }
                    }
                }
            }
            lbl2.Text = "Живих клітин: " + k;
            ro2 = k / 100;
            ro2 = Math.Round(ro2, 2);
            lbl3.Text = "Щільність (%): " + ro2;
            Array.Copy(b, a, 10000);
            if ((xod % 2 == 1) | (chkbx1.Checked == false))
            {
                for (int i = 0; i < 100; i++)
                {
                    for (int j = 0; j < 100; j++)
                    {
                        s = 0;
                        if ((i == 0) | (j == 0))
                        {
                            if (i == 0)
                            {
                                if (j == 0)
                                {
                                    if (a[99, 99] != 0)
                                    { s++; l.Add(a[99, 99]); }
                                    if (a[i, 99] != 0)
                                    { s++; l.Add(a[i, 99]); }
                                    if (a[(i + 1) % 100, 99] != 0)
                                    { s++; l.Add(a[(i + 1) % 100, 99]); }
                                    if (a[99, j] != 0)
                                    { s++; l.Add(a[99, j]); }
                                    if (a[99, (j + 1) % 100] != 0)
                                    { s++; l.Add(a[99, (j + 1) % 100]); }
                                    if (a[i, (j + 1) % 100] != 0)
                                    { s++; l.Add(a[i, (j + 1) % 100]); }
                                    if (a[(i + 1) % 100, j] != 0)
                                    { s++; l.Add(a[(i + 1) % 100, j]); }
                                    if (a[(i + 1) % 100, (j + 1) % 100] != 0)
                                    { s++; l.Add(a[(i + 1) % 100, (j + 1) % 100]); }
                                    if (col == 2)
                                    {
                                        if (a[99, 99] == 1)
                                            ss++;
                                        if (a[99, 99] == 2)
                                            sk++;
                                        if (a[i, 99] == 1)
                                            ss++;
                                        if (a[i, 99] == 2)
                                            sk++;
                                        if (a[(i + 1) % 100, 99] == 1)
                                            ss++;
                                        if (a[(i + 1) % 100, 99] == 2)
                                            sk++;
                                        if (a[99, j] == 1)
                                            ss++;
                                        if (a[99, j] == 2)
                                            sk++;
                                        if (a[99, (j + 1) % 100] == 1)
                                            ss++;
                                        if (a[99, (j + 1) % 100] == 2)
                                            sk++;
                                        if (a[i, (j + 1) % 100] == 1)
                                            ss++;
                                        if (a[i, (j + 1) % 100] == 2)
                                            sk++;
                                        if (a[(i + 1) % 100, j] == 1)
                                            ss++;
                                        if (a[(i + 1) % 100, j] == 2)
                                            sk++;
                                        if (a[(i + 1) % 100, (j + 1) % 100] == 1)
                                            ss++;
                                        if (a[(i + 1) % 100, (j + 1) % 100] == 2)
                                            sk++;
                                    }
                                }
                                else
                                {
                                    if (a[99, j - 1] != 0)
                                    { s++; l.Add(a[99, j - 1]); }
                                    if (a[i, j - 1] != 0)
                                    { s++; l.Add(a[i, j - 1]); }
                                    if (a[(i + 1) % 100, j - 1] != 0)
                                    { s++; l.Add(a[(i + 1) % 100, j - 1]); }
                                    if (a[99, j] != 0)
                                    { s++; l.Add(a[99, j]); }
                                    if (a[99, (j + 1) % 100] != 0)
                                    { s++; l.Add(a[99, (j + 1) % 100]); }
                                    if (a[i, (j + 1) % 100] != 0)
                                    { s++; l.Add(a[i, (j + 1) % 100]); }
                                    if (a[(i + 1) % 100, j] != 0)
                                    { s++; l.Add(a[(i + 1) % 100, j]); }
                                    if (a[(i + 1) % 100, (j + 1) % 100] != 0)
                                    { s++; l.Add(a[(i + 1) % 100, (j + 1) % 100]); }
                                    if (col == 2)
                                    {
                                        if (a[99, j - 1] == 1)
                                            ss++;
                                        if (a[99, j - 1] == 2)
                                            sk++;
                                        if (a[i, j - 1] == 1)
                                            ss++;
                                        if (a[i, j - 1] == 2)
                                            sk++;
                                        if (a[(i + 1) % 100, j - 1] == 1)
                                            ss++;
                                        if (a[(i + 1) % 100, j - 1] == 2)
                                            sk++;
                                        if (a[99, j] == 1)
                                            ss++;
                                        if (a[99, j] == 2)
                                            sk++;
                                        if (a[99, (j + 1) % 100] == 1)
                                            ss++;
                                        if (a[99, (j + 1) % 100] == 2)
                                            sk++;
                                        if (a[i, (j + 1) % 100] == 1)
                                            ss++;
                                        if (a[i, (j + 1) % 100] == 2)
                                            sk++;
                                        if (a[(i + 1) % 100, j] == 1)
                                            ss++;
                                        if (a[(i + 1) % 100, j] == 2)
                                            sk++;
                                        if (a[(i + 1) % 100, (j + 1) % 100] == 1)
                                            ss++;
                                        if (a[(i + 1) % 100, (j + 1) % 100] == 2)
                                            sk++;
                                    }
                                }
                            }
                            else
                            {
                                if (j == 0)
                                {
                                    if (a[i - 1, 99] != 0)
                                    { s++; l.Add(a[i - 1, 99]); }
                                    if (a[i, 99] != 0)
                                    { s++; l.Add(a[i, 99]); }
                                    if (a[(i + 1) % 100, 99] != 0)
                                    { s++; l.Add(a[(i + 1) % 100, 99]); }
                                    if (a[i - 1, j] != 0)
                                    { s++; l.Add(a[i - 1, j]); }
                                    if (a[i - 1, (j + 1) % 100] != 0)
                                    { s++; l.Add(a[i - 1, (j + 1) % 100]); }
                                    if (a[i, (j + 1) % 100] != 0)
                                    { s++; l.Add(a[i, (j + 1) % 100]); }
                                    if (a[(i + 1) % 100, j] != 0)
                                    { s++; l.Add(a[(i + 1) % 100, j]); }
                                    if (a[(i + 1) % 100, (j + 1) % 100] != 0)
                                    { s++; l.Add(a[(i + 1) % 100, (j + 1) % 100]); }
                                    if (col == 2)
                                    {
                                        if (a[i - 1, 99] == 1)
                                            ss++;
                                        if (a[i - 1, 99] == 2)
                                            sk++;
                                        if (a[i, 99] == 1)
                                            ss++;
                                        if (a[i, 99] == 2)
                                            sk++;
                                        if (a[(i + 1) % 100, 99] == 1)
                                            ss++;
                                        if (a[(i + 1) % 100, 99] == 2)
                                            sk++;
                                        if (a[i - 1, j] == 1)
                                            ss++;
                                        if (a[i - 1, j] == 2)
                                            sk++;
                                        if (a[i - 1, (j + 1) % 100] == 1)
                                            ss++;
                                        if (a[i - 1, (j + 1) % 100] == 2)
                                            sk++;
                                        if (a[i, (j + 1) % 100] == 1)
                                            ss++;
                                        if (a[i, (j + 1) % 100] == 2)
                                            sk++;
                                        if (a[(i + 1) % 100, j] == 1)
                                            ss++;
                                        if (a[(i + 1) % 100, j] == 2)
                                            sk++;
                                        if (a[(i + 1) % 100, (j + 1) % 100] == 1)
                                            ss++;
                                        if (a[(i + 1) % 100, (j + 1) % 100] == 2)
                                            sk++;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (a[i - 1, j - 1] != 0)
                            { s++; l.Add(a[i - 1, j - 1]); }
                            if (a[i, j - 1] != 0)
                            { s++; l.Add(a[i, j - 1]); }
                            if (a[(i + 1) % 100, j - 1] != 0)
                            { s++; l.Add(a[(i + 1) % 100, j - 1]); }
                            if (a[i - 1, j] != 0)
                            { s++; l.Add(a[i - 1, j]); }
                            if (a[i - 1, (j + 1) % 100] != 0)
                            { s++; l.Add(a[i - 1, (j + 1) % 100]); }
                            if (a[i, (j + 1) % 100] != 0)
                            { s++; l.Add(a[i, (j + 1) % 100]); }
                            if (a[(i + 1) % 100, j] != 0)
                            { s++; l.Add(a[(i + 1) % 100, j]); }
                            if (a[(i + 1) % 100, (j + 1) % 100] != 0)
                            { s++; l.Add(a[(i + 1) % 100, (j + 1) % 100]); }
                            if (col == 2)
                            {
                                if (a[i - 1, j - 1] == 1)
                                    ss++;
                                if (a[i - 1, j - 1] == 2)
                                    sk++;
                                if (a[i, j - 1] == 1)
                                    ss++;
                                if (a[i, j - 1] == 2)
                                    sk++;
                                if (a[(i + 1) % 100, j - 1] == 1)
                                    ss++;
                                if (a[(i + 1) % 100, j - 1] == 2)
                                    sk++;
                                if (a[i - 1, j] == 1)
                                    ss++;
                                if (a[i - 1, j] == 2)
                                    sk++;
                                if (a[i - 1, (j + 1) % 100] == 1)
                                    ss++;
                                if (a[i - 1, (j + 1) % 100] == 2)
                                    sk++;
                                if (a[i, (j + 1) % 100] == 1)
                                    ss++;
                                if (a[i, (j + 1) % 100] == 2)
                                    sk++;
                                if (a[(i + 1) % 100, j] == 1)
                                    ss++;
                                if (a[(i + 1) % 100, j] == 2)
                                    sk++;
                                if (a[(i + 1) % 100, (j + 1) % 100] == 1)
                                    ss++;
                                if (a[(i + 1) % 100, (j + 1) % 100] == 2)
                                    sk++;
                            }
                        }
                        if (col != 9)
                        {
                            if ((s == 3) & (a[i, j] == 0))
                            {
                                if (col == 1)
                                    b[i, j] = 1;
                                else
                                {
                                    if (ss > sk)
                                        b[i, j] = 1;
                                    else
                                        b[i, j] = 2;
                                    ss = 0;
                                    sk = 0;
                                }
                            }
                            else
                                b[i, j] = a[i, j];
                            if (s == 2)
                                b[i, j] = a[i, j];
                            if ((s != 2) & (s != 3))
                                b[i, j] = 0;
                        }
                        else
                        {
                            if ((s == 3) & (a[i, j] != 4))
                            {
                                b[i, j] = l[r.Next(0, 3)];
                            }
                            if ((s != a[i, j] - 1) & (a[i, j] != 0))
                            {
                                b[i, j] = 0;
                            }
                            if (s == a[i, j] - 1)
                            {
                                b[i, j] = a[i, j];
                            }
                        }
                        l.Clear();
                    }
                }
            }
            else
            {
                for (int i = 1; i < 99; i++)
                {
                    for (int j = 1; j < 99; j++)
                    {
                        s = 0;
                        if (a[i - 1, j - 1] != 0)
                            s++;
                        if (a[i, j - 1] != 0)
                            s++;
                        if (a[(i + 1) % 100, j - 1] != 0)
                            s++;
                        if (a[i - 1, j] != 0)
                            s++;
                        if (a[i - 1, (j + 1) % 100] != 0)
                            s++;
                        if (a[i, (j + 1) % 100] != 0)
                            s++;
                        if (a[(i + 1) % 100, j] != 0)
                            s++;
                        if (a[(i + 1) % 100, (j + 1) % 100] != 0)
                            s++;
                        w[i, j] = s;
                    }
                }
                for (int i2 = 3; i2 < 98; i2++)
                {
                    for (int j2 = 3; j2 < 98; j2++)
                    {
                        for (int i = i2 - 2; i < i2 + 2; i++)
                        {
                            for (int j = j2 - 2; j < j2 + 2; j++)
                            {
                                s = 0;
                                if (a[i - 1, j - 1] != 0)
                                    s++;
                                if (a[i, j - 1] != 0)
                                    s++;
                                if (a[(i + 1) % 100, j - 1] != 0)
                                    s++;
                                if (a[i - 1, j] != 0)
                                    s++;
                                if (a[i - 1, (j + 1) % 100] != 0)
                                    s++;
                                if (a[i, (j + 1) % 100] != 0)
                                    s++;
                                if (a[(i + 1) % 100, j] != 0)
                                    s++;
                                if (a[(i + 1) % 100, (j + 1) % 100] != 0)
                                    s++;
                                w[i, j] = s;
                            }
                        }
                        if (a[i2, j2] != 0)
                        {
                            if (((a[i2, j2] - 1 == w[i2, j2]) & (col == 9)) | (((4 == w[i2, j2]) | (3 == w[i2, j2])) & (col != 9)))
                            { b[i2, j2] = a[i2, j2]; break; }
                            if (((a[i2, j2] == w[i2 - 1, j2 - 1]) & (col == 9)) | ((((4 == w[i2 - 1, j2 - 1]) | (3 == w[i2 - 1, j2 - 1])) & (col != 9)) & (a[i2 - 1, j2 - 1] == 0) & (b[i2 - 1, j2 - 1] == 0)))
                            { b[i2 - 1, j2 - 1] = a[i2, j2]; a[i2, j2] = 0; b[i2, j2] = 0; break; }
                            if (((a[i2, j2] == w[i2 - 1, j2]) & (col == 9)) | ((((4 == w[i2 - 1, j2]) | (3 == w[i2 - 1, j2])) & (col != 9)) & (a[i2 - 1, j2] == 0) & (b[i2 - 1, j2] == 0)))
                            { b[i2 - 1, j2] = a[i2, j2]; a[i2, j2] = 0; b[i2, j2] = 0; break; }
                            if (((a[i2, j2] == w[i2 - 1, j2 + 1]) & (col == 9)) | ((((4 == w[i2 - 1, j2 + 1]) | (3 == w[i2 - 1, j2 + 1])) & (col != 9)) & (a[i2 - 1, j2 + 1] == 0) & (b[i2 - 1, j2 + 1] == 0)))
                            { b[i2 - 1, j2 + 1] = a[i2, j2]; a[i2, j2] = 0; b[i2, j2] = 0; break; }
                            if (((a[i2, j2] == w[i2, j2 - 1]) & (col == 9)) | ((((4 == w[i2, j2 - 1]) | (3 == w[i2, j2 - 1])) & (col != 9)) & (a[i2, j2 - 1] == 0) & (b[i2, j2 - 1] == 0)))
                            { b[i2, j2 - 1] = a[i2, j2]; a[i2, j2] = 0; b[i2, j2] = 0; break; }
                            if (((a[i2, j2] == w[i2, j2 + 1]) & (col == 9)) | ((((4 == w[i2, j2 + 1]) | (3 == w[i2, j2 + 1])) & (col != 9)) & (a[i2, j2 + 1] == 0) & (b[i2, j2 + 1] == 0)))
                            { b[i2, j2 + 1] = a[i2, j2]; a[i2, j2] = 0; b[i2, j2] = 0; break; }
                            if (((a[i2, j2] == w[i2 + 1, j2 - 1]) & (col == 9)) | ((((4 == w[i2 + 1, j2 - 1]) | (3 == w[i2 + 1, j2 - 1])) & (col != 9)) & (a[i2 + 1, j2 - 1] == 0) & (b[i2 + 1, j2 - 1] == 0)))
                            { b[i2 + 1, j2 - 1] = a[i2, j2]; a[i2, j2] = 0; b[i2, j2] = 0; break; }
                            if (((a[i2, j2] == w[i2 + 1, j2]) & (col == 9)) | ((((4 == w[i2 + 1, j2]) | (3 == w[i2 + 1, j2])) & (col != 9)) & (a[i2 + 1, j2] == 0) & (b[i2 + 1, j2] == 0)))
                            { b[i2 + 1, j2] = a[i2, j2]; a[i2, j2] = 0; b[i2, j2] = 0; break; }
                            if (((a[i2, j2] == w[i2 + 1, j2 + 1]) & (col == 9)) | ((((4 == w[i2 + 1, j2 + 1]) | (3 == w[i2 + 1, j2 + 1])) & (col != 9)) & (a[i2 + 1, j2 + 1] == 0) & (b[i2 + 1, j2 + 1] == 0)))
                            { b[i2 + 1, j2 + 1] = a[i2, j2]; a[i2, j2] = 0; b[i2, j2] = 0; break; }
                        }
                    }
                }
            }
            xod++;
            lbl1.Text = "Ходів: " + xod;
            if (chkbx1.Checked == true)
                lbl1.Text = "Ходів: " + (xod / 2);
            ro2 = k / 100;
            ro2 = Math.Round(ro2, 2);
            lbl3.Text = "Щільність (%): " + ro2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            k = 0;
            xod = 0;
            lbl2.Text = "Живих клітин: " + k;
            lbl1.Text = "Ходів: " + xod;
            ro2 = k / 100;
            ro2 = Math.Round(ro2, 2);
            lbl3.Text = "Щільність (%): " + ro2;
            g = pctr1.CreateGraphics();
            g.Clear(Color.White);
            for (int i = 0; i < 101; i++)
            {
                g.DrawLine(Pens.Black, i * 7, 0, i * 7, pctr1.Width - 1);
                g.DrawLine(Pens.Black, 0, i * 7, pctr1.Height - 1, i * 7);
            }
            btn1.Visible = true;
            d = 1;
            Array.Clear(a, 0, 10000);
            Array.Clear(b, 0, 10000);
            openFileDialog1.InitialDirectory = Application.StartupPath;
            openFileDialog1.Filter = "Файли TXT (*.txt)|*.txt";
            openFileDialog1.FileName = "0000.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
                string[] ast = File.ReadAllLines(filename, Encoding.UTF8);
                if ((ast[0] == "1") | (ast[0] == "3"))
                {
                    col = 1;
                }
                else
                {
                    col = 2;
                }
                for (int i = 1; i <= 100; i++)
                {
                    string st1 = ast[i];
                    for (int j = 0; j <= 99; j++)
                    {
                        if (st1[j] == '1')
                        {
                            g.FillRectangle(Brushes.Blue, (i - 1) * 7 + 1, j * 7 + 1, 6, 6);
                            a[i - 1, j] = 1;
                            b[i - 1, j] = 1;
                            k++;
                        }
                        if (st1[j] == '2')
                        {
                            g.FillRectangle(Brushes.Red, (i - 1) * 7 + 1, j * 7 + 1, 6, 6);
                            a[i - 1, j] = 2;
                            b[i - 1, j] = 2;
                            k++;
                        }
                        if (st1[j] == '3')
                        {
                            g.FillRectangle(Brushes.Green, (i - 1) * 7 + 1, j * 7 + 1, 6, 6);
                            a[i - 1, j] = 3;
                            b[i - 1, j] = 3;
                            k++;
                        }
                        lbl2.Text = "Живих клітик: " + k;
                        ro2 = k / 100;
                        ro2 = Math.Round(ro2, 2);
                        lbl3.Text = "Щільність (%): " + ro2;
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
            col = 2;
            timer1.Stop();
            btn4.Visible = true;
            k = 0;
            xod = 0;
            lbl2.Text = "Живих клітин: " + k;
            ro2 = k / 100;
            ro2 = Math.Round(ro2, 2);
            lbl3.Text = "Щільність (%): " + ro2;
            lbl1.Text = "Ходів: " + xod;
            g = pctr1.CreateGraphics();
            g.Clear(Color.White);
            for (int i = 0; i < 101; i++)
            {
                g.DrawLine(Pens.Black, i * 7, 0, i * 7, pctr1.Width - 1);
                g.DrawLine(Pens.Black, 0, i * 7, pctr1.Height - 1, i * 7);
            }
            btn1.Visible = true;
            d = 1;
            Array.Clear(a, 0, 10000);
            Array.Clear(b, 0, 10000);
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
            col = 1;
            btn4.Visible = true;
            k = 0;
            xod = 0;
            lbl2.Text = "Живих клітин: " + k;
            ro2 = k / 100;
            ro2 = Math.Round(ro2, 2);
            lbl3.Text = "Щільність (%): " + ro2;
            lbl1.Text = "Ходів: " + xod;
            g = pctr1.CreateGraphics();
            g.Clear(Color.White);
            for (int i = 0; i < 101; i++)
            {
                g.DrawLine(Pens.Black, i * 7, 0, i * 7, pctr1.Width - 1);
                g.DrawLine(Pens.Black, 0, i * 7, pctr1.Height - 1, i * 7);
            }
            btn1.Visible = true;
            d = 1;
            Array.Clear(a, 0, 10000);
            Array.Clear(b, 0, 10000);
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
            col = 3;
            btn4.Visible = true;
            k = 0;
            xod = 0;
            lbl2.Text = "Живих клітин: " + k;
            ro2 = k / 100;
            ro2 = Math.Round(ro2, 2);
            lbl3.Text = "Щільність (%): " + ro2;
            lbl1.Text = "Ходів: " + xod;
            g = pctr1.CreateGraphics();
            g.Clear(Color.White);
            for (int i = 0; i < 101; i++)
            {
                g.DrawLine(Pens.Black, i * 7, 0, i * 7, pctr1.Width - 1);
                g.DrawLine(Pens.Black, 0, i * 7, pctr1.Height - 1, i * 7);
            }
            btn1.Visible = true;
            d = 1;
            Array.Clear(a, 0, 10000);
            Array.Clear(b, 0, 10000);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            saveFileDialog1.InitialDirectory = Application.StartupPath;
            saveFileDialog1.Filter = "Файли TXT (*.txt)|*.txt";
            saveFileDialog1.FileName = "Нове життя.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = saveFileDialog1.FileName;
                StreamWriter sw = new StreamWriter(filename);
                if (col == 1)
                    sw.Write("1");
                if (col == 2)
                    sw.Write("2");
                if (col == 9)
                    sw.Write("9");
                for (int i = 0; i <= 99; i++)
                {
                    sw.WriteLine("");
                    for (int j = 0; j <= 99; j++)
                    {
                        sw.Write(a[i, j].ToString());
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
            col = 9;
            timer1.Stop();
            btn4.Visible = true;
            k = 0;
            xod = 0;
            lbl2.Text = "Живих клітин: " + k;
            ro2 = k / 100;
            ro2 = Math.Round(ro2, 2);
            lbl3.Text = "Щільність (%): " + ro2;
            lbl1.Text = "Ходів: " + xod;
            g = pctr1.CreateGraphics();
            g.Clear(Color.White);
            for (int i = 0; i < 101; i++)
            {
                g.DrawLine(Pens.Black, i * 7, 0, i * 7, pctr1.Width - 1);
                g.DrawLine(Pens.Black, 0, i * 7, pctr1.Height - 1, i * 7);
            }
            btn1.Visible = true;
            d = 1;
            Array.Clear(a, 0, 10000);
            Array.Clear(b, 0, 10000);
            if (rdBtn7.Checked == true)
            {
                txtBx1.Visible = true;
                grpBx1.Visible = false;
            }
        }

        private void rdBtn1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btn6_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            k = 0;
            xod = 0;
            lbl2.Text = "Живих клітин: " + k;
            ro2 = k / 100;
            ro2 = Math.Round(ro2, 2);
            lbl3.Text = "Щільність (%): " + ro2;
            lbl1.Text = "Ходів: " + xod;
            g = pctr1.CreateGraphics();
            g.Clear(Color.White);
            for (int i = 0; i < 101; i++)
            {
                g.DrawLine(Pens.Black, i * 7, 0, i * 7, pctr1.Width - 1);
                g.DrawLine(Pens.Black, 0, i * 7, pctr1.Height - 1, i * 7);
            }
            btn1.Visible = true;
            d = 1;
            Array.Clear(a, 0, 10000);
            Array.Clear(b, 0, 10000);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btn7_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            k = 0;
            xod = 0;
            lbl2.Text = "Живих клітин: " + k;
            ro2 = k / 100;
            ro2 = Math.Round(ro2, 2);
            lbl3.Text = "Щільність (%): " + ro2;
            lbl1.Text = "Ходів: " + xod;
            g = pctr1.CreateGraphics();
            g.Clear(Color.White);
            for (int i = 0; i < 101; i++)
            {
                g.DrawLine(Pens.Black, i * 7, 0, i * 7, pctr1.Width - 1);
                g.DrawLine(Pens.Black, 0, i * 7, pctr1.Height - 1, i * 7);
            }
            btn1.Visible = true;
            d = 1;
            Array.Clear(a, 0, 10000);
            Array.Clear(b, 0, 10000);
            int ro = int.Parse(txtBx2.Text);
            int x;
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    x = r.Next(1, 101);
                    if (x <= ro)
                    {
                        x = r.Next(1, col + 1);
                        a[i, j] = x;
                        b[i, j] = x;
                        k++;
                    }
                    else
                    {
                        a[i, j] = 0;
                        b[i, j] = 0;
                    }
                }
            }
            lbl2.Text = "Живих клітин: " + k;
            ro2 = k / 100;
            ro2 = Math.Round(ro2, 2);
            lbl3.Text = "Щільність (%): " + ro2;
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    if (b[i, j] == 0)
                    {
                        g.FillRectangle(Brushes.White, i * 7 + 1, j * 7 + 1, 6, 6);
                    }
                    else
                    {
                        if (col != 9)
                        {
                            if (b[i, j] == 1)
                                g.FillRectangle(Brushes.Blue, i * 7 + 1, j * 7 + 1, 6, 6);
                            if (b[i, j] == 2)
                                g.FillRectangle(Brushes.Red, i * 7 + 1, j * 7 + 1, 6, 6);
                            k++;
                        }
                        else
                        {
                            SolidBrush br = new SolidBrush(Color.FromArgb(255 - 31 * (b[i, j] - 1), 255 - 31 * (b[i, j] - 1), 31 * (b[i, j] - 1)));
                            if (b[i, j] == 3)
                                br.Color = Color.Red;
                            if (b[i, j] == 4)
                                br.Color = Color.DarkOrange;
                            if (b[i, j] == 1)
                                br.Color = Color.Black;
                            if (b[i, j] == 2)
                                br.Color = Color.MidnightBlue;
                            g.FillRectangle(br, i * 7 + 1, j * 7 + 1, 6, 6);
                            k++;
                        }
                    }
                }
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
            if (txtBx2.Text != "")
            {
                int x = int.Parse(txtBx2.Text);
                if ((x < 0) | (x > 100))
                {
                    MessageBox.Show("Введіть число від 0 до 100");
                    txtBx2.Text = "20";
                }
            }
        }

        private void txtBx1_TextChanged(object sender, EventArgs e)
        {
            if (txtBx1.Text != "")
            {
                int x = int.Parse(txtBx1.Text);
                if ((x < 0) | (x > 8))
                {
                    MessageBox.Show("Введіть число від 0 до 8");
                    txtBx1.Text = "3";
                }
            }
        }
    }
}
