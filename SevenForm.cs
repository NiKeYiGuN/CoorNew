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
    public partial class SevenForm : Form
    {
        public SevenForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SevenParam.isSet = true;
            SevenParam.X = Convert.ToDouble(textBox1.Text);
            SevenParam.Y = Convert.ToDouble(textBox2.Text);
            SevenParam.Z = Convert.ToDouble(textBox5.Text);
            SevenParam.A = Convert.ToDouble(textBox3.Text);
            SevenParam.K = Convert.ToDouble(textBox4.Text);
            SevenParam.N = Convert.ToDouble(textBox6.Text);
            SevenParam.M = Convert.ToDouble(textBox7.Text);

            MessageBox.Show(this, "参数设置成功！");
        }
    }
}
