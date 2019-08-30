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
    public partial class CMForm : Form
    {
        public CMForm()
        {
            InitializeComponent();
        }

        private void btnCal_Click(object sender, EventArgs e)
        {
            double longitude = Convert.ToDouble(txtlongitude.Text);
            if (rb3.Checked)
            {
                ProjectionZone myProject = new ProjectionZone(longitude, ZoneType.ThreeZone);
                txtZoneNumber.Text = myProject.ZoneNumber.ToString();
                txtCentralMeridianLongitude.Text = myProject.CentralMeridianLongitude.ToString();
            }
            else if (rb6.Checked)
            {
                ProjectionZone myProject = new ProjectionZone(longitude, ZoneType.SixZone);
                txtZoneNumber.Text = myProject.ZoneNumber.ToString();
                txtCentralMeridianLongitude.Text = myProject.CentralMeridianLongitude.ToString();
            }
            else
            {
                MessageBox.Show("请选择投影带，再计算！！！");
                return;
            }
        }
    }
}
