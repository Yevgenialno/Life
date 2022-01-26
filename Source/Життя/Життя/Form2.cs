using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Життя
{
    public partial class Form2 : Form
    {
        public Form1 Next_form = new Form1();
        public Form2()
        {
            InitializeComponent();
            AddOwnedForm(Next_form);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Next_form.StartPosition = FormStartPosition.CenterScreen;
            Next_form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
