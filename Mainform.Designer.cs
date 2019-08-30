namespace CoorTransform
{
    partial class Mainform
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainform));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.XYZBLHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BLHXYZToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.XBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.BJToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.XAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.FourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SevenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fjToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sjToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.ZWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ZYZWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dhCBX = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.fzToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.szToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem7,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem6,
            this.toolStripMenuItem4,
            this.dhCBX,
            this.toolStripMenuItem5});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(739, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(68, 25);
            this.toolStripMenuItem1.Text = "打开文件";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.XYZBLHToolStripMenuItem,
            this.BLHXYZToolStripMenuItem,
            this.XBToolStripMenuItem,
            this.BXToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(68, 25);
            this.toolStripMenuItem2.Text = "坐标转换";
            // 
            // XYZBLHToolStripMenuItem
            // 
            this.XYZBLHToolStripMenuItem.Name = "XYZBLHToolStripMenuItem";
            this.XYZBLHToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.XYZBLHToolStripMenuItem.Text = "大地转空间平面";
            this.XYZBLHToolStripMenuItem.Click += new System.EventHandler(this.XYZBLHToolStripMenuItem_Click);
            // 
            // BLHXYZToolStripMenuItem
            // 
            this.BLHXYZToolStripMenuItem.Name = "BLHXYZToolStripMenuItem";
            this.BLHXYZToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.BLHXYZToolStripMenuItem.Text = "空间直角转大地";
            this.BLHXYZToolStripMenuItem.Click += new System.EventHandler(this.BLHXYZToolStripMenuItem_Click);
            // 
            // XBToolStripMenuItem
            // 
            this.XBToolStripMenuItem.Name = "XBToolStripMenuItem";
            this.XBToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.XBToolStripMenuItem.Text = "大地转平面";
            this.XBToolStripMenuItem.Click += new System.EventHandler(this.XBToolStripMenuItem_Click);
            // 
            // BXToolStripMenuItem
            // 
            this.BXToolStripMenuItem.Name = "BXToolStripMenuItem";
            this.BXToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.BXToolStripMenuItem.Text = "平面转大地";
            this.BXToolStripMenuItem.Click += new System.EventHandler(this.BXToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BJToolStripMenuItem,
            this.XAToolStripMenuItem,
            this.wGToolStripMenuItem});
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(68, 25);
            this.toolStripMenuItem3.Text = "基准转换";
            // 
            // BJToolStripMenuItem
            // 
            this.BJToolStripMenuItem.Name = "BJToolStripMenuItem";
            this.BJToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.BJToolStripMenuItem.Text = "北京54坐标";
            this.BJToolStripMenuItem.Click += new System.EventHandler(this.BJToolStripMenuItem_Click);
            // 
            // XAToolStripMenuItem
            // 
            this.XAToolStripMenuItem.Name = "XAToolStripMenuItem";
            this.XAToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.XAToolStripMenuItem.Text = "西安80坐标";
            this.XAToolStripMenuItem.Click += new System.EventHandler(this.XAToolStripMenuItem_Click);
            // 
            // wGToolStripMenuItem
            // 
            this.wGToolStripMenuItem.Name = "wGToolStripMenuItem";
            this.wGToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.wGToolStripMenuItem.Text = "WG84坐标";
            this.wGToolStripMenuItem.Click += new System.EventHandler(this.wGToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FourToolStripMenuItem,
            this.SevenToolStripMenuItem,
            this.fjToolStripMenuItem,
            this.sjToolStripMenuItem,
            this.ftToolStripMenuItem,
            this.stToolStripMenuItem});
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(128, 25);
            this.toolStripMenuItem6.Text = "四参数和七参数设置";
            // 
            // FourToolStripMenuItem
            // 
            this.FourToolStripMenuItem.Name = "FourToolStripMenuItem";
            this.FourToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.FourToolStripMenuItem.Text = "四参数设置";
            this.FourToolStripMenuItem.Click += new System.EventHandler(this.FourToolStripMenuItem_Click);
            // 
            // SevenToolStripMenuItem
            // 
            this.SevenToolStripMenuItem.Name = "SevenToolStripMenuItem";
            this.SevenToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.SevenToolStripMenuItem.Text = "七参数设置";
            this.SevenToolStripMenuItem.Click += new System.EventHandler(this.SevenToolStripMenuItem_Click);
            // 
            // fjToolStripMenuItem
            // 
            this.fjToolStripMenuItem.Name = "fjToolStripMenuItem";
            this.fjToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fjToolStripMenuItem.Text = "四参数计算";
            this.fjToolStripMenuItem.Visible = false;
            this.fjToolStripMenuItem.Click += new System.EventHandler(this.fjToolStripMenuItem_Click);
            // 
            // sjToolStripMenuItem
            // 
            this.sjToolStripMenuItem.Name = "sjToolStripMenuItem";
            this.sjToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sjToolStripMenuItem.Text = "七参数计算";
            this.sjToolStripMenuItem.Visible = false;
            this.sjToolStripMenuItem.Click += new System.EventHandler(this.sjToolStripMenuItem_Click);
            // 
            // ftToolStripMenuItem
            // 
            this.ftToolStripMenuItem.Name = "ftToolStripMenuItem";
            this.ftToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ftToolStripMenuItem.Text = "四参数转换";
            this.ftToolStripMenuItem.Click += new System.EventHandler(this.ftToolStripMenuItem_Click);
            // 
            // stToolStripMenuItem
            // 
            this.stToolStripMenuItem.Name = "stToolStripMenuItem";
            this.stToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.stToolStripMenuItem.Text = "七参数转换";
            this.stToolStripMenuItem.Click += new System.EventHandler(this.stToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ZWToolStripMenuItem,
            this.ZYZWToolStripMenuItem});
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(68, 25);
            this.toolStripMenuItem4.Text = "参数计算";
            // 
            // ZWToolStripMenuItem
            // 
            this.ZWToolStripMenuItem.Name = "ZWToolStripMenuItem";
            this.ZWToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ZWToolStripMenuItem.Text = "子午弧长";
            this.ZWToolStripMenuItem.Click += new System.EventHandler(this.ZWToolStripMenuItem_Click);
            // 
            // ZYZWToolStripMenuItem
            // 
            this.ZYZWToolStripMenuItem.Name = "ZYZWToolStripMenuItem";
            this.ZYZWToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ZYZWToolStripMenuItem.Text = "中央子午线";
            this.ZYZWToolStripMenuItem.Click += new System.EventHandler(this.ZYZWToolStripMenuItem_Click);
            // 
            // dhCBX
            // 
            this.dhCBX.Items.AddRange(new object[] {
            "3°",
            "6°"});
            this.dhCBX.Name = "dhCBX";
            this.dhCBX.Size = new System.Drawing.Size(121, 25);
            this.dhCBX.Text = "3°";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(44, 25);
            this.toolStripMenuItem5.Text = "帮助";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton4,
            this.toolStripButton2,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 29);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(739, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "保存报告";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "保存图形";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "放大";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "缩小";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 54);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(739, 423);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(731, 397);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "数据";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(725, 391);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chart1);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(731, 397);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "图形";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(731, 397);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.textBox1);
            this.tabPage3.Location = new System.Drawing.Point(4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(731, 397);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "报告";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(731, 397);
            this.textBox1.TabIndex = 0;
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fzToolStripMenuItem,
            this.szToolStripMenuItem});
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(131, 25);
            this.toolStripMenuItem7.Text = "打开平面XY坐标文件";
            // 
            // fzToolStripMenuItem
            // 
            this.fzToolStripMenuItem.Name = "fzToolStripMenuItem";
            this.fzToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.fzToolStripMenuItem.Text = "四参数转换";
            this.fzToolStripMenuItem.Click += new System.EventHandler(this.fzToolStripMenuItem_Click);
            // 
            // szToolStripMenuItem
            // 
            this.szToolStripMenuItem.Name = "szToolStripMenuItem";
            this.szToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.szToolStripMenuItem.Text = "七参数转换";
            this.szToolStripMenuItem.Click += new System.EventHandler(this.szToolStripMenuItem_Click);
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 477);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Mainform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "坐标转换(Coortrans)V1.0";
            this.Load += new System.EventHandler(this.Mainform_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem BXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem XBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem BLHXYZToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem XYZBLHToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem BJToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem ZWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ZYZWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem XAToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem wGToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripComboBox dhCBX;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem FourToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SevenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fjToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sjToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem fzToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem szToolStripMenuItem;
    }
}

