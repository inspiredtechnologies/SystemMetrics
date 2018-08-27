using System;
using System.Windows.Forms;
using SystemMetrics;

namespace SystemMetricsTestGui
{
  public partial class FormMain : Form
  {
    private string[] _NicInterfaces;

    public FormMain()
    {
      InitializeComponent();
    }

    private void FormMain_Load(object sender, EventArgs e)
    {
      try
      {
        cmbNwInterfaces.Items.Clear();
        cmbNwInterfaces.Items.Add("< Disable Network Monitoring >");
        _NicInterfaces = OsMetrics.EnumerateNetworkInterfaces();
        foreach (string nicInterface in _NicInterfaces)
        {
          cmbNwInterfaces.Items.Add(nicInterface);
        }
        cmbNwInterfaces.SelectedIndex = 0;

        tsslInstalledRam.Text = ((double)OsMetrics.GetInstalledPhysicalMemory() / 1024 / 1024).ToString("0.0") + " GB";
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.ToString());
      }
    }

    private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
    {
      timer1.Enabled = false;
    }

    private void timer1_Tick(object sender, EventArgs e)
    {
      ListViewItem item;
      if (lvMain.Items.Count == 0)
      {
        item = lvMain.Items.Add(DateTime.Now.ToString());
        for (int i = 0; i < 8; i++)
        {
          item.SubItems.Add(string.Empty);
        }
      }
      else
      {
        item = lvMain.Items[0];
        item.SubItems[0].Text = DateTime.Now.ToString();
      }

      try
      {
        string driveName = OsMetrics.GetSystemPartitionLabel();
        item.SubItems[1].Text = OsMetrics.GetCpuUsage().ToString() + " %";
        item.SubItems[2].Text = OsMetrics.GetMemoryUsage().ToString() + " %";

        double nwUtil = double.NaN;
        if (cmbNwInterfaces.SelectedIndex > 0)
        {
          nwUtil = OsMetrics.GetNetworkUtilization(cmbNwInterfaces.Text);
        }
        item.SubItems[3].Text = double.IsNaN(nwUtil) ? string.Empty : nwUtil.ToString("0.0") + " %";

        double temperature = HardwareMetrics.GetCpuTemperature();
        item.SubItems[4].Text = (temperature == 0.0) ? string.Empty : temperature.ToString("0.0") + " °C";

        temperature = HardwareMetrics.GetMainBoardTemperature();
        item.SubItems[5].Text = (temperature == 0.0) ? string.Empty : temperature.ToString("0.0") + " °C";

        temperature = HardwareMetrics.GetHddTemperature();
        item.SubItems[6].Text = (temperature == 0.0) ? string.Empty : temperature.ToString("0.0") + " °C";

        item.SubItems[7].Text = HardwareMetrics.GetHddUsage().ToString("0.0") + " %";
        item.SubItems[8].Text = (100.0 - OsMetrics.GetDiskUtilization(driveName)).ToString("0.0") + " %";

        TimeSpan uptime = OsMetrics.GetUpTime();
        tsslUptime.Text = uptime.Days.ToString() + " days, " + uptime.Hours.ToString() + " hours, " +
          uptime.Minutes.ToString() + " mins, " + uptime.Seconds.ToString() + " secs";
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }
    }

    private void btnStart_Click(object sender, EventArgs e)
    {
      if (btnStart.Text.StartsWith("Start"))
      {
        cmbNwInterfaces.Enabled = false;
        HardwareMetrics.EnableHardwareMonitoring(true);
        timer1.Enabled = true;
        btnStart.Text = "Stop";
      }
      else
      {
        timer1.Enabled = false;
        btnStart.Text = "Start";
        cmbNwInterfaces.Enabled = true;
        HardwareMetrics.EnableHardwareMonitoring(false);
      }
    }
  }
}
