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
    public partial class FourForm : Form
    {
        public FourForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FourParam.isSet = true;
            FourParam.X = Convert.ToDouble(textBox1.Text);
            FourParam.Y = Convert.ToDouble(textBox2.Text);
            FourParam.A = Convert.ToDouble(textBox3.Text);
            FourParam.M = Convert.ToDouble(textBox4.Text);

            MessageBox.Show(this, "参数设置成功！");
        }
    }
}
