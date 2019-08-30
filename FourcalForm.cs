using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoorTransform
{
    public partial class FourcalForm : Form
    {
        public FourcalForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double X1 = Convert.ToDouble(textBox1.Text);
            double Y1 = Convert.ToDouble(textBox3.Text);
            double X2 = Convert.ToDouble(textBox2.Text);
            double Y2 = Convert.ToDouble(textBox4.Text);
            double sX1 = Convert.ToDouble(textBox5.Text);
            double sY1 = Convert.ToDouble(textBox7.Text);
            double sX2 = Convert.ToDouble(textBox6.Text);
            double sY2 = Convert.ToDouble(textBox8.Text);


        }
    }
}
