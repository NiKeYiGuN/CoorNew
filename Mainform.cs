using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CoorTransform
{
    public partial class Mainform : Form
    {
        private List<BLHAndXYZ> pointInfo = new List<BLHAndXYZ>();
        private List<BLAndXY> flatPoInfo = new List<BLAndXY>();
        DataTable dt = null;
        DataTable bldt = null;
        DataTable fourDt = null;
        DataTable svnDt = null;

        private float size = 12;

        public Mainform()
        {
            InitializeComponent();
            BJToolStripMenuItem.Checked = true;
            XAToolStripMenuItem.Checked = false;
            wGToolStripMenuItem.Checked = false;
        }

        private void BJToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ellipsoid.Instance("北京54坐标");
            BJToolStripMenuItem.Checked = true;
            XAToolStripMenuItem.Checked = false;
            wGToolStripMenuItem.Checked = false;
          
        }

        private void XAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ellipsoid.Instance("西安80坐标");
            BJToolStripMenuItem.Checked = false;
            XAToolStripMenuItem.Checked = true;
            wGToolStripMenuItem.Checked = false;
        }

        private void wGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ellipsoid.Instance("WGS84坐标");
            BJToolStripMenuItem.Checked = false;
            XAToolStripMenuItem.Checked = false;
            wGToolStripMenuItem.Checked = true;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            GetPointData();
            WriteToText("大地坐标(BLH)转空间坐标(XYZ)");
        }

        private void GetPointData()
        {

            if (pointInfo!=null||pointInfo.Count>=0)
            {
                pointInfo.Clear();
            }

            if (fourDt!=null)
            {
                fourDt.Clear();
                fourDt = null;
            }

            if (svnDt != null)
            {
                svnDt.Clear();
                svnDt = null;
            }


            Angle angle = new Angle();
            double[] XY = new double[2];

            OpenFileDialog ofg = new OpenFileDialog();//打开文件获取所有的原始坐标数据
            ofg.Filter = "文本文件|*.txt|所有文件|*.*";
            if (DialogResult.OK == ofg.ShowDialog())//用户点击打开按钮
            {
                string filePath = ofg.FileName;//获取用户选择的文件全路径。

                using (StreamReader sr = new StreamReader(filePath))
                {
                    //sr.ReadLine();//读取并舍去数据表头
                    while (!sr.EndOfStream)//开始读取数据
                    {
                        string strLines = sr.ReadLine();//用strLine去接收读取的数据
                        string[] strLine = strLines.Split(new char[] { ',' });//用“，”将读取的数据分割开来
                        BLHAndXYZ Point = new BLHAndXYZ();//创建一个点类对象
                        Point.PointName = strLine[0];
                        Point.BData = Convert.ToDouble(strLine[1]);
                        Point.LData = Convert.ToDouble(strLine[2]);
                        Point.HData = Convert.ToDouble(strLine[3]);
                        Point.Bstr = BLHOperate.NumToAngle(Point.BData);
                        Point.Lstr = BLHOperate.NumToAngle(Point.LData);
                        Point.XData = BLHOperate.GetXData(angle.GetArc(Point.BData.ToString()), angle.GetArc(Point.LData.ToString()), Point.HData);
                        Point.YData = BLHOperate.GetYData(angle.GetArc(Point.BData.ToString()), angle.GetArc(Point.LData.ToString()), Point.HData);
                        Point.ZData = BLHOperate.GetZData(angle.GetArc(Point.BData.ToString()), Point.HData);
                        pointInfo.Add(Point);

                        BLAndXY flatPoint = new BLAndXY();
                        flatPoint.PointName = strLine[0];
                        flatPoint.BData = Convert.ToDouble(strLine[1]);
                        flatPoint.LData = Convert.ToDouble(strLine[2]);
                        flatPoint.Bstr = BLHOperate.NumToAngle(flatPoint.BData);
                        flatPoint.Lstr = BLHOperate.NumToAngle(flatPoint.LData);
                        XY = BLHOperate.GetFlatXYData(angle.GetArc(flatPoint.BData.ToString()), flatPoint.LData, dhCBX.Text);
                        flatPoint.XData = XY[0];
                        flatPoint.YData = XY[1];

                        flatPoInfo.Add(flatPoint);
                    }
                }

                //初始化表格（列）。
                dt = new DataTable();//初始化表格      
                dt.Columns.Add("点名", typeof(string)); //表头“点名”
                dt.Columns.Add("B", typeof(string)); //表头“B坐标”
                dt.Columns.Add("L", typeof(string)); //表头“L坐标”
                dt.Columns.Add("H", typeof(double)); //表头“H坐标”
                dt.Columns.Add("X", typeof(double)); //表头“X坐标”
                dt.Columns.Add("Y", typeof(double)); //表头“Y坐标”
                dt.Columns.Add("Z", typeof(double)); //表头“Z坐标”

                fourDt = new DataTable();
                fourDt.Columns.Add("点名", typeof(string));
                fourDt.Columns.Add("X", typeof(double)); //表头“Y坐标”
                fourDt.Columns.Add("Y", typeof(double)); //表头“Z坐标”
                fourDt.Columns.Add("X’", typeof(double)); //表头“Y坐标”
                fourDt.Columns.Add("Y’", typeof(double)); //表头“Z坐标”

                svnDt = new DataTable();
                svnDt.Columns.Add("点名", typeof(string));
                svnDt.Columns.Add("X", typeof(double)); //表头“Y坐标”
                svnDt.Columns.Add("Y", typeof(double)); //表头“Z坐标”
                svnDt.Columns.Add("Z", typeof(double)); //表头“Z坐标”
                svnDt.Columns.Add("X’", typeof(double)); //表头“Y坐标”
                svnDt.Columns.Add("Y’", typeof(double)); //表头“Z坐标”
                svnDt.Columns.Add("Z’", typeof(double)); //表头“Z坐标”

                //给表格添加行数据
                for (int i = 0; i < pointInfo.Count; i++)//遍历导入的点数据
                {
                    DataRow row = dt.NewRow();
                    DataRow frow = fourDt.NewRow();
                    DataRow srow = svnDt.NewRow();

                    row["点名"] = pointInfo[i].PointName;
                    row["B"] = pointInfo[i].Bstr;
                    row["L"] = pointInfo[i].Lstr;
                    row["H"] = pointInfo[i].HData;                   
                    row["X"] = pointInfo[i].XData;
                    row["Y"] = pointInfo[i].YData;
                    row["Z"] = pointInfo[i].ZData;
                    dt.Rows.Add(row);

                    frow["点名"] = pointInfo[i].PointName;
                    frow["X"] = pointInfo[i].XData;
                    frow["Y"] = pointInfo[i].YData;
                    frow["X’"] = 0;
                    frow["Y’"] =0;
                    fourDt.Rows.Add(frow);

                    srow["点名"] = pointInfo[i].PointName;
                    srow["X"] = pointInfo[i].XData;
                    srow["Y"] = pointInfo[i].YData;
                    srow["Z"] = pointInfo[i].ZData;
                    srow["X’"] = 0;
                    srow["Y’"] = 0;
                    srow["Z’"] = 0;
                    svnDt.Rows.Add(srow);
                }

                dataGridView1.DataSource = null;
                dataGridView1.Columns.Clear();
                dataGridView1.Rows.Clear();
                dataGridView1.DataSource = dt;
                AutoSizeColumn(dataGridView1);
            }
            else
            {
                return;
            }
        }

        private void WriteToText(string str)
        {
            string textStr = str+ "\r\n"+ "\r\n";
            textStr += "________________________________________" + "\r\n"+ "\r\n";
            textStr += "点名  " + "     B     " + "          L     " + "     H     " + "     X     " + "     Y     " + "     Z     " + "\r\n"+ "\r\n";

            if (dt.Rows.Count<0||dt==null)
            {
                return;
            }

            for (int i=0;i<dt.Rows.Count;i++)
            {
                textStr += @dt.Rows[i]["点名"].ToString()+" "+ dt.Rows[i]["B"].ToString()+ " " + dt.Rows[i]["L"].ToString()
                    + " " + dt.Rows[i]["H"].ToString()+ " " + dt.Rows[i]["X"].ToString() + " " + dt.Rows[i]["Y"].ToString() + " " + dt.Rows[i]["Z"].ToString() + "\r\n"+ "\r\n";
            }
            textBox1.Text = textStr;
        }

        private void Mainform_Load(object sender, EventArgs e)
        {
            UpdateTextPosition();
            Ellipsoid.Instance("北京54坐标");
        }

        private void BLHXYZToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XYZTOBLH("空间坐标(XYZ)转大地坐标(BLH)");
        }

        private void XYZTOBLH(string str)
        {
            textBox1.Clear();
            string textStr = str + "\r\n" + "\r\n";
            textStr += "________________________________________" + "\r\n" + "\r\n";
            //textStr += "点名  " + "     B     " + "          L     " + "     H     " + "     X     " + "     Y     " + "     Z     " + "\r\n" + "\r\n";
            textStr += "点名  " + "     X     " + "     Y     " + "     Z     " + "     B     " + "          L     " + "           H     " + "\r\n" + "\r\n";


            if (pointInfo.Count<0)
            {
                return;
            }

            for (int i=0;i<pointInfo.Count;i++)
            {
                double n = pointInfo[i].XData;
                pointInfo[i].XData += 1000;
                pointInfo[i].YData += 1000;
                pointInfo[i].ZData += 1000;
                pointInfo[i].Lstr = BLHOperate.GetLData(pointInfo[i].XData, pointInfo[i].YData);
                pointInfo[i].Bstr = BLHOperate.GetBData(pointInfo[i].XData, pointInfo[i].YData, pointInfo[i].ZData);
                pointInfo[i].HData=BLHOperate.getHData(pointInfo[i].XData, pointInfo[i].YData, pointInfo[i].ZData);

                textStr+=@pointInfo[i].PointName.ToString() + " " + pointInfo[i].XData.ToString() + " " + pointInfo[i].YData.ToString()
                    + " " + pointInfo[i].ZData.ToString() + " " + pointInfo[i].Bstr.ToString() + " " + pointInfo[i].Lstr.ToString() + " " + pointInfo[i].HData.ToString("f4") + "\r\n" + "\r\n";
            }

            textBox1.Text = textStr;

            tabControl1.SelectedIndex = 2;
        }

        private void XYZBLHToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void XBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dhCBX.Text != "3°" && dhCBX.Text != "6°")
            {
                MessageBox.Show(this, "请选择正确的代号！");
            }

            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            //dt.Clear();
            //dt.Columns.Clear();
            //初始化表格（列）。

            bldt = new DataTable();
            bldt.Columns.Add("点名", typeof(string)); //表头“点名”
            bldt.Columns.Add("B", typeof(string)); //表头“B坐标”
            bldt.Columns.Add("L", typeof(string)); //表头“L坐标”           
            bldt.Columns.Add("X", typeof(double)); //表头“X坐标”
            bldt.Columns.Add("Y", typeof(double)); //表头“Y坐标”          
                                                 //给表格添加行数据
            for (int i = 0; i < flatPoInfo.Count; i++)//遍历导入的点数据
            {
                DataRow row = bldt.NewRow();
                row["点名"] = flatPoInfo[i].PointName;
                row["B"] = flatPoInfo[i].Bstr;
                row["L"] = flatPoInfo[i].Lstr;                
                row["X"] = Math.Round(flatPoInfo[i].XData,4);
                row["Y"] = Math.Round(flatPoInfo[i].YData,4);
                bldt.Rows.Add(row);
            }
            dataGridView1.DataSource = bldt;
            //dataGridView1.Columns
            AutoSizeColumn(dataGridView1);
            BLToXY("大地(BL)转平面(XY)");
            DrawPt();
        }

        private void DrawPt()
        {
            Series dataTable3Series = new Series("bldt");
            dataTable3Series.Points.DataBind(bldt.AsEnumerable(), "X", "Y", "Label=点名");
            dataTable3Series.XValueType = ChartValueType.Double;
            dataTable3Series.ChartType = SeriesChartType.Point;
            dataTable3Series.Color = Color.Black;
            //dataTable3Series.Label = ;
            chart1.Series.Add(dataTable3Series);//加入你的chart1
        }

        private void BLToXY(string str)
        {
            textBox1.Clear();
            string textStr = str + "\r\n" + "\r\n";
            textStr += "________________________________________" + "\r\n" + "\r\n";
            //textStr += "点名  " + "     B     " + "          L     " + "     H     " + "     X     " + "     Y     " + "     Z     " + "\r\n" + "\r\n";
            textStr += "点名  " + "     B     " + "     L     "  + "           X     " + "          Y     "  + "\r\n" + "\r\n";


            if (flatPoInfo.Count < 0)
            {
                return;
            }

            for (int i = 0; i < flatPoInfo.Count; i++)
            {                
                textStr += @flatPoInfo[i].PointName.ToString() + " " + flatPoInfo[i].Bstr.ToString() + " " + flatPoInfo[i].Lstr.ToString()+
                     " " + flatPoInfo[i].XData.ToString("f4") + " " + flatPoInfo[i].YData.ToString("f4") + " "  + "\r\n" + "\r\n";
            }

            textBox1.Text = textStr;

            tabControl1.SelectedIndex = 2;
        }

        private void BXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XYtoBL("平面(XY)转大地(BL)");
        }

        private void XYtoBL(string str)
        {
            string[] BLStr = new string[2];
            textBox1.Clear();
            string textStr = str + "\r\n" + "\r\n";
            textStr += "________________________________________" + "\r\n" + "\r\n";
            textStr += "点名  " + "     X     " + "          Y     " + "          B     " + "          L     " + "\r\n" + "\r\n";
            //textStr += "点名  " + "     X     " + "     Y     " + "     Z     " + "     B     " + "          L     " + "           H     " + "\r\n" + "\r\n";


            if (pointInfo.Count < 0)
            {
                return;
            }

            for (int i = 0; i < pointInfo.Count; i++)
            {
                flatPoInfo[i].XData += 1000;
                flatPoInfo[i].YData += 1000;
                BLStr = BLHOperate.GetBLData(flatPoInfo[i].XData, flatPoInfo[i].YData);
                flatPoInfo[i].Bstr = BLStr[0];
                flatPoInfo[i].Lstr = BLStr[1];

                textStr += @flatPoInfo[i].PointName.ToString() + " " + flatPoInfo[i].XData.ToString() + " " + flatPoInfo[i].YData.ToString()
                    + " " + flatPoInfo[i].Bstr.ToString() + " " + flatPoInfo[i].Lstr.ToString() + " " + "\r\n" + "\r\n";
            }

            textBox1.Text = textStr;

            tabControl1.SelectedIndex = 2;
        }

        /// <summary>
        /// 使DataGridView的列自适应宽度
        /// </summary>
        /// <param name="dgViewFiles"></param>
        private void AutoSizeColumn(DataGridView dgViewFiles)
        {
            int width = 0;
            //使列自使用宽度
            //对于DataGridView的每一个列都调整
            for (int i = 0; i < dgViewFiles.Columns.Count; i++)
            {
                //将每一列都调整为自动适应模式
                dgViewFiles.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCells);
                //记录整个DataGridView的宽度
                width += dgViewFiles.Columns[i].Width;
            }
            //判断调整后的宽度与原来设定的宽度的关系，如果是调整后的宽度大于原来设定的宽度，
            //则将DataGridView的列自动调整模式设置为显示的列即可，
            //如果是小于原来设定的宽度，将模式改为填充。
            if (width > dgViewFiles.Size.Width)
            {
                dgViewFiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
            else
            {
                dgViewFiles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            //冻结某列 从左开始 0，1，2
            dgViewFiles.Columns[1].Frozen = true;
        }

        /// <summary>
        /// 保存报告
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex!=2)
            {
                MessageBox.Show("请切换到报告界面！");
                return;
            }
            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    string path = folderBrowserDialog1.SelectedPath + @"\result.txt";

                    using (StreamWriter writer = new StreamWriter(path))
                    {
                        writer.Write(this.textBox1.Text);
                    }
                    MessageBox.Show(this,"保存成功！");
                }
            }
            catch
            {
                MessageBox.Show(this, "保存失败！");
            }

        }

        /// <summary>
        /// 保存图形
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex!=1)
            {
                MessageBox.Show(this, "请切换到图片栏！");
                return;
            }
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            //选择导出文件位置
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                //导出路径
                string outPath = fbd.SelectedPath.ToString();
                string fileName = outPath + "\\resultPicture"+ ".png";
                //输出图片到指定位置
                chart1.SaveImage(fileName, ImageFormat.Png);
                MessageBox.Show(this, "保存成功！");
            }

        }

        private void UpdateTextPosition()
        {
            Graphics g = this.CreateGraphics();
            Double startingPoint = (this.Width / 2) - (g.MeasureString(this.Text.Trim(), this.Font).Width / 2);
            Double widthOfASpace = g.MeasureString(" ", this.Font).Width;
            String tmp = " ";
            Double tmpWidth = 0;

            while ((tmpWidth + widthOfASpace) < startingPoint)
            {
                tmp += " ";
                tmpWidth += widthOfASpace;
            }

            this.Text = tmp + this.Text.Trim();
        }

        private void ZWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MClength mclength = new MClength();
            mclength.Show();
        }

        private void ZYZWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CMForm cmform = new CMForm();
            cmform.Show();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex!=2)
            {
                MessageBox.Show(this, "请切换到报告栏！");
                return;
            }
            this.size+=1f;
            textBox1.Font = new Font(textBox1.Font.FontFamily, size, textBox1.Font.Style);
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex != 2)
            {
                MessageBox.Show(this, "请切换到报告栏！");
                return;
            }
            this.size -= 1f;
            textBox1.Font = new Font(textBox1.Font.FontFamily, size, textBox1.Font.Style);
        }

        private void FourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FourForm f = new FourForm();
            f.ShowDialog();
        }

        private void SevenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SevenForm s = new SevenForm();
            s.ShowDialog();
        }

        private void ftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FourParam.isSet)
            {
                MessageBox.Show(this, "请先设置四参数！");
                return;
            }

            double x = 0;
            double y = 0;

            for (int i=0;i< fourDt.Rows.Count;i++)
            {
                x = Convert.ToDouble(fourDt.Rows[i]["X"]);
                y = Convert.ToDouble(fourDt.Rows[i]["Y"]);

                fourDt.Rows[i]["X’"] = x * FourParam.M * Math.Cos(FourParam.A)-y*FourParam.M*Math.Sin(FourParam.A)+FourParam.X;
                fourDt.Rows[i]["Y’"]= x * FourParam.M * Math.Sin(FourParam.A) - y * FourParam.M * Math.Sin(FourParam.A) + FourParam.Y;
            }

            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = fourDt;
        }

        private void stToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!SevenParam.isSet)
            {
                MessageBox.Show(this, "请先设置七参数！");
                return;
            }

            double x = 0;
            double y = 0;
            double z = 0;

            for (int i=0;i<svnDt.Rows.Count;i++)
            {
                x = Convert.ToDouble(svnDt.Rows[i]["X"]);
                y = Convert.ToDouble(svnDt.Rows[i]["Y"]);
                z = Convert.ToDouble(svnDt.Rows[i]["Z"]);

                svnDt.Rows[i]["X‘"] = SevenParam.X + (1 + SevenParam.M) * x + SevenParam.N * y - SevenParam.K * z;
                svnDt.Rows[i]["Y‘"] = SevenParam.Y + (1 + SevenParam.M) * y - SevenParam.N * x + SevenParam.A * z;
                svnDt.Rows[i]["Z‘"] = SevenParam.Z + (1 + SevenParam.M) * z + SevenParam.K * x - SevenParam.A *y;
            }

            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = svnDt;
        }

        private void fjToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FourcalForm fc = new FourcalForm();
            fc.Show();
        }

        private void sjToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!FourParam.isSet)
            {
                MessageBox.Show(this, "请先设置四参数！");
                return;
            }

            if (fourDt != null)
            {
                fourDt.Clear();
                fourDt = null;
            }

            fourDt = new DataTable();
            fourDt.Columns.Add("X", typeof(double)); //表头“Y坐标”
            fourDt.Columns.Add("Y", typeof(double)); //表头“Z坐标”
            fourDt.Columns.Add("X’", typeof(double)); //表头“Y坐标”
            fourDt.Columns.Add("Y’", typeof(double)); //表头“Z坐标”

            double x = 0;
            double y = 0;

            OpenFileDialog ofg = new OpenFileDialog();//打开文件获取所有的原始坐标数据
            ofg.Filter = "文本文件|*.txt|所有文件|*.*";
            if (DialogResult.OK == ofg.ShowDialog())//用户点击打开按钮
            {
                string filePath = ofg.FileName;//获取用户选择的文件全路径。

                using (StreamReader sr = new StreamReader(filePath))
                {
                    //sr.ReadLine();//读取并舍去数据表头
                    while (!sr.EndOfStream)//开始读取数据
                    {
                        string strLines = sr.ReadLine();//用strLine去接收读取的数据
                        string[] strLine = strLines.Split(new char[] { ',' });//用“，”将读取的数据分割开来
                        DataRow frow = fourDt.NewRow();
                        x = Convert.ToDouble(strLine[0]);
                        y = Convert.ToDouble(strLine[1]);
                        frow["X"] = Convert.ToDouble(strLine[0]);
                        frow["Y"] = Convert.ToDouble(strLine[1]);
                        frow["X’"] = x * FourParam.M * Math.Cos(FourParam.A) - y * FourParam.M * Math.Sin(FourParam.A) + FourParam.X;
                        frow["Y’"] = x * FourParam.M * Math.Sin(FourParam.A) - y * FourParam.M * Math.Sin(FourParam.A) + FourParam.Y;
                        fourDt.Rows.Add(frow);
                    }
                }
            }
            else
            {
                return;
            }

            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = fourDt;
            AutoSizeColumn(dataGridView1);
        }

        private void szToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!SevenParam.isSet)
            {
                MessageBox.Show(this, "请先设置七参数！");
                return;
            }

            if (svnDt != null)
            {
                svnDt.Clear();
                svnDt = null;
            }

            svnDt = new DataTable();

            svnDt.Columns.Add("X", typeof(double)); //表头“Y坐标”
            svnDt.Columns.Add("Y", typeof(double)); //表头“Z坐标”
            svnDt.Columns.Add("Z", typeof(double)); //表头“Z坐标”
            svnDt.Columns.Add("X’", typeof(double)); //表头“Y坐标”
            svnDt.Columns.Add("Y’", typeof(double)); //表头“Z坐标”
            svnDt.Columns.Add("Z’", typeof(double)); //表头“Z坐标”

            double x = 0;
            double y = 0;
            double z = 0;

            OpenFileDialog ofg = new OpenFileDialog();//打开文件获取所有的原始坐标数据
            ofg.Filter = "文本文件|*.txt|所有文件|*.*";
            if (DialogResult.OK == ofg.ShowDialog())//用户点击打开按钮
            {
                string filePath = ofg.FileName;//获取用户选择的文件全路径。

                using (StreamReader sr = new StreamReader(filePath))
                {
                    //sr.ReadLine();//读取并舍去数据表头
                    while (!sr.EndOfStream)//开始读取数据
                    {
                        string strLines = sr.ReadLine();//用strLine去接收读取的数据
                        string[] strLine = strLines.Split(new char[] { ',' });//用“，”将读取的数据分割开来
                        DataRow srow = svnDt.NewRow();

                        x = Convert.ToDouble(strLine[0]);
                        y = Convert.ToDouble(strLine[1]);
                        z = Convert.ToDouble(strLine[2]);
                        srow["X"] = Convert.ToDouble(strLine[0]);
                        srow["Y"] = Convert.ToDouble(strLine[1]);
                        srow["Z"] = Convert.ToDouble(strLine[1]);
                        srow["X’"] = SevenParam.X + (1 + SevenParam.M) * x + SevenParam.N * y - SevenParam.K * z;
                        srow["Y’"] = SevenParam.Y + (1 + SevenParam.M) * y - SevenParam.N * x + SevenParam.A * z;
                        srow["Z’"] = SevenParam.Z + (1 + SevenParam.M) * z + SevenParam.K * x - SevenParam.A * y;
                        svnDt.Rows.Add(srow);
                    }
                }
            }
            else
            {
                return;
            }
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = svnDt;
            AutoSizeColumn(dataGridView1);
        }
    }
}
