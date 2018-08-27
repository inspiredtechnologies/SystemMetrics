using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SystemMetrics
{
  /// <summary>
  /// Windows OS performance metrics reporting library
  /// </summary>
  public static class OsMetrics
  {
    private static string _LastNicInterface = string.Empty;
    private static string _LastDiskPartition = string.Empty;
    private static PerformanceCounter _PerfCpuCounter = new PerformanceCounter("Processor Information", "% Processor Time", "_Total");
    private static PerformanceCounter _PerfMemCounter = new PerformanceCounter("Memory", "Available MBytes");
    private static PerformanceCounterCategory _NicCategories = new PerformanceCounterCategory("Network Interface");

    private static PerformanceCounter _BandwidthCounter = null;
    private static PerformanceCounter _DataSentCounter = null;
    private static PerformanceCounter _DataReceivedCounter = null;

    private static PerformanceCounter _DiskIdlePercentCounter = null;

    public static long TotalPhysicalMemory { get; set; }
    public static float NetworkBandwidth { get; set; }

    [DllImport("kernel32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool GetPhysicallyInstalledSystemMemory(out long TotalMemoryInKilobytes);

    // ----------------------------------------------------------

    #region Public Methods

    /// <summary>
    /// Gets the combined CPU utilization in percent
    /// </summary>
    /// <returns></returns>
    public static int GetCpuUsage()
    {
      return (int)_PerfCpuCounter.NextValue();
    }

    /// <summary>
    /// Gets the system memory utilization in percent
    /// </summary>
    /// <returns></returns>
    public static int GetMemoryUsage()
    {
      try
      {
        long totalPhysicalMemory;
        if (!GetPhysicallyInstalledSystemMemory(out totalPhysicalMemory))
          return 0;   // error
        else
          TotalPhysicalMemory = totalPhysicalMemory;

        double availableMBytes = (double)_PerfMemCounter.NextValue();
        totalPhysicalMemory /= 1024;
        return (int)((totalPhysicalMemory - availableMBytes) * 100.0 / (double)totalPhysicalMemory);
      }
      catch
      {
        throw;
      }
    }

    /// <summary>
    /// Returns the total installed physical memory in kilobytes
    /// </summary>
    /// <returns></returns>
    public static long GetInstalledPhysicalMemory()
    {
      try
      {
        if (TotalPhysicalMemory == 0)
        {
          long totalPhysicalMemory;
          if (!GetPhysicallyInstalledSystemMemory(out totalPhysicalMemory))
            return 0;   // error
          else
            TotalPhysicalMemory = totalPhysicalMemory;
        }
        return TotalPhysicalMemory;
      }
      catch
      {
        throw;
      }
    }

    /// <summary>
    /// Gets the list of network interfaces on the local machine.
    /// </summary>
    /// <returns></returns>
    public static string[] EnumerateNetworkInterfaces()
    {
      try
      {
        string[] nicInterfaces = _NicCategories.GetInstanceNames();
        return nicInterfaces;
      }
      catch
      {
        throw;
      }
    }

    /// <summary>
    /// Gets the bandwidth utilization of the specified network interface in percent
    /// </summary>
    /// <param name="networkInterface"></param>
    /// <returns></returns>
    public static double GetNetworkUtilization(string networkInterface)
    {
      try
      {
        if (string.IsNullOrWhiteSpace(networkInterface))
          return 0.0;
        else
        {
          if (!_LastNicInterface.Equals(networkInterface, StringComparison.InvariantCulture) ||
            _BandwidthCounter == null || _DataSentCounter == null || _DataReceivedCounter == null)
          {
            _LastNicInterface = networkInterface;
            _BandwidthCounter = new PerformanceCounter("Network Interface", "Current Bandwidth", networkInterface);
            _DataSentCounter = new PerformanceCounter("Network Interface", "Bytes Sent/sec", networkInterface);
            _DataReceivedCounter = new PerformanceCounter("Network Interface", "Bytes Received/sec", networkInterface);
          }
        }

        const int numberOfIterations = 10;
        float bandwidth = _BandwidthCounter.NextValue();
        float sendSum = 0;
        float receiveSum = 0;
        NetworkBandwidth = bandwidth;

        for (int index = 0; index < numberOfIterations; index++)
        {
          sendSum += _DataSentCounter.NextValue();
          receiveSum += _DataReceivedCounter.NextValue();
        }

        float dataSent = sendSum;
        float dataReceived = receiveSum;

        double utilization = (8 * (dataSent + dataReceived)) / (bandwidth * numberOfIterations) * 100;
        return utilization;
      }
      catch
      {
        throw;
      }
    }

    /// <summary>
    /// Gets the partition label of the system partition (e.g. "C:")
    /// </summary>
    /// <returns>Returns null if the system partition cannot be identified or located</returns>
    public static string GetSystemPartitionLabel()
    {
      try
      {
        string systemPartition = Path.GetPathRoot(Environment.SystemDirectory);
        if (!string.IsNullOrEmpty(systemPartition))
        {
          systemPartition = systemPartition.Replace(@"\", "");
          var perfCategory = new System.Diagnostics.PerformanceCounterCategory("PhysicalDisk");
          string[] instanceNames = perfCategory.GetInstanceNames();

          foreach (string name in instanceNames)
          {
            if (name.IndexOf(systemPartition) > 0)
            {
              return name;
            }
          }
        }
        return null;
      }
      catch
      {
        throw;
      }
    }

    /// <summary>
    /// Gets the disk activity rate of the specified hard disk in percent
    /// </summary>
    /// <param name="partitionLabel"></param>
    /// <returns></returns>
    public static double GetDiskUtilization(string partitionLabel)
    {
      try
      {
        if (string.IsNullOrWhiteSpace(partitionLabel))
          return 0.0;
        else
        {
          if (!_LastDiskPartition.Equals(partitionLabel, StringComparison.InvariantCulture) ||
            _DiskIdlePercentCounter == null)
          {
            _LastDiskPartition = partitionLabel;
            _DiskIdlePercentCounter = new PerformanceCounter("PhysicalDisk", "% Idle Time", partitionLabel);
          }
        }

        float idlePercent = _DiskIdlePercentCounter.NextValue();

        if (idlePercent > 100)
        {
          idlePercent = 100;
        }
        return idlePercent;
      }
      catch
      {
        throw;
      }
    }

    /// <summary>
    /// Returns the system uptime since the last reboot
    /// </summary>
    /// <returns></returns>
    public static TimeSpan GetUpTime()
    {
      return TimeSpan.FromMilliseconds(SafeNativeMethods.GetTickCount64());
    }

    #endregion

    // ----------------------------------------------------------

  }
}
