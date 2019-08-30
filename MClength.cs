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
    public partial class MClength : Form
    {
        public MClength()
        {
            InitializeComponent();
        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            Angle angle = new Angle();
            double b = angle.GetArc(txtB.Text);
            double X = Ellipsoid.c[0] * b + Ellipsoid.c[1] * Math.Sin(2 * b) + Ellipsoid.c[2] * Math.Sin(4 * b)
                       + Ellipsoid.c[3] * Math.Sin(6 * b) + Ellipsoid.c[4] * Math.Sin(8 * b) + Ellipsoid.c[5] * Math.Sin(10 * b);
            txtMeridianLength.Text = X.ToString();
        }
    }
}
