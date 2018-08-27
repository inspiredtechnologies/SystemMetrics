namespace SystemMetricsTestGui
{
  partial class FormMain
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.label2 = new System.Windows.Forms.Label();
      this.cmbNwInterfaces = new System.Windows.Forms.ComboBox();
      this.btnStart = new System.Windows.Forms.Button();
      this.lvMain = new System.Windows.Forms.ListView();
      this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
      this.tsslUptime = new System.Windows.Forms.ToolStripStatusLabel();
      this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
      this.tsslInstalledRam = new System.Windows.Forms.ToolStripStatusLabel();
      this.panel1 = new System.Windows.Forms.Panel();
      this.statusStrip1.SuspendLayout();
      this.panel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // timer1
      // 
      this.timer1.Interval = 1000;
      this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(16, 20);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(128, 13);
      this.label2.TabIndex = 6;
      this.label2.Text = "Select Network Interface:";
      // 
      // cmbNwInterfaces
      // 
      this.cmbNwInterfaces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.cmbNwInterfaces.FormattingEnabled = true;
      this.cmbNwInterfaces.Location = new System.Drawing.Point(150, 17);
      this.cmbNwInterfaces.Name = "cmbNwInterfaces";
      this.cmbNwInterfaces.Size = new System.Drawing.Size(369, 21);
      this.cmbNwInterfaces.TabIndex = 7;
      // 
      // btnStart
      // 
      this.btnStart.Location = new System.Drawing.Point(766, 13);
      this.btnStart.Name = "btnStart";
      this.btnStart.Size = new System.Drawing.Size(99, 27);
      this.btnStart.TabIndex = 8;
      this.btnStart.Text = "Start";
      this.btnStart.UseVisualStyleBackColor = true;
      this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
      // 
      // lvMain
      // 
      this.lvMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
      this.lvMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lvMain.Location = new System.Drawing.Point(0, 57);
      this.lvMain.Name = "lvMain";
      this.lvMain.Size = new System.Drawing.Size(887, 180);
      this.lvMain.TabIndex = 11;
      this.lvMain.UseCompatibleStateImageBehavior = false;
      this.lvMain.View = System.Windows.Forms.View.Details;
      // 
      // columnHeader1
      // 
      this.columnHeader1.Text = "Time";
      this.columnHeader1.Width = 131;
      // 
      // columnHeader2
      // 
      this.columnHeader2.Text = "CPU Usage";
      this.columnHeader2.Width = 72;
      // 
      // columnHeader3
      // 
      this.columnHeader3.Text = "Memory Usage";
      this.columnHeader3.Width = 88;
      // 
      // columnHeader4
      // 
      this.columnHeader4.Text = "Network Usage";
      this.columnHeader4.Width = 93;
      // 
      // columnHeader5
      // 
      this.columnHeader5.Text = "CPU Temperature";
      this.columnHeader5.Width = 103;
      // 
      // columnHeader6
      // 
      this.columnHeader6.Text = "Mainboard Temperature";
      this.columnHeader6.Width = 129;
      // 
      // columnHeader7
      // 
      this.columnHeader7.Text = "HDD Temperature";
      this.columnHeader7.Width = 102;
      // 
      // columnHeader8
      // 
      this.columnHeader8.Text = "HDD Usage";
      this.columnHeader8.Width = 85;
      // 
      // columnHeader9
      // 
      this.columnHeader9.Text = "HDD Activity";
      this.columnHeader9.Width = 78;
      // 
      // statusStrip1
      // 
      this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsslUptime,
            this.toolStripStatusLabel2,
            this.tsslInstalledRam});
      this.statusStrip1.Location = new System.Drawing.Point(0, 237);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(887, 22);
      this.statusStrip1.TabIndex = 12;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // toolStripStatusLabel1
      // 
      this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
      this.toolStripStatusLabel1.Size = new System.Drawing.Size(90, 17);
      this.toolStripStatusLabel1.Text = "System Uptime:";
      // 
      // tsslUptime
      // 
      this.tsslUptime.Name = "tsslUptime";
      this.tsslUptime.Size = new System.Drawing.Size(681, 17);
      this.tsslUptime.Spring = true;
      this.tsslUptime.Text = "    ";
      this.tsslUptime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // toolStripStatusLabel2
      // 
      this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
      this.toolStripStatusLabel2.Size = new System.Drawing.Size(82, 17);
      this.toolStripStatusLabel2.Text = "Physical RAM:";
      // 
      // tsslInstalledRam
      // 
      this.tsslInstalledRam.Name = "tsslInstalledRam";
      this.tsslInstalledRam.Size = new System.Drawing.Size(19, 17);
      this.tsslInstalledRam.Text = "    ";
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.label2);
      this.panel1.Controls.Add(this.cmbNwInterfaces);
      this.panel1.Controls.Add(this.btnStart);
      this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
      this.panel1.Location = new System.Drawing.Point(0, 0);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(887, 57);
      this.panel1.TabIndex = 13;
      // 
      // FormMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(887, 259);
      this.Controls.Add(this.lvMain);
      this.Controls.Add(this.panel1);
      this.Controls.Add(this.statusStrip1);
      this.MaximizeBox = false;
      this.Name = "FormMain";
      this.Text = "System Metrics Library Test";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
      this.Load += new System.EventHandler(this.FormMain_Load);
      this.statusStrip1.ResumeLayout(false);
      this.statusStrip1.PerformLayout();
      this.panel1.ResumeLayout(false);
      this.panel1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ComboBox cmbNwInterfaces;
    private System.Windows.Forms.Button btnStart;
    private System.Windows.Forms.ListView lvMain;
    private System.Windows.Forms.ColumnHeader columnHeader1;
    private System.Windows.Forms.ColumnHeader columnHeader2;
    private System.Windows.Forms.ColumnHeader columnHeader3;
    private System.Windows.Forms.ColumnHeader columnHeader4;
    private System.Windows.Forms.ColumnHeader columnHeader5;
    private System.Windows.Forms.ColumnHeader columnHeader6;
    private System.Windows.Forms.ColumnHeader columnHeader7;
    private System.Windows.Forms.ColumnHeader columnHeader8;
    private System.Windows.Forms.ColumnHeader columnHeader9;
    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    private System.Windows.Forms.ToolStripStatusLabel tsslUptime;
    private System.Windows.Forms.Panel panel1;
    private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
    private System.Windows.Forms.ToolStripStatusLabel tsslInstalledRam;
  }
}

