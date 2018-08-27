using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OpenHardwareMonitor.Hardware;

namespace SystemMetrics
{
  /// <summary>
  /// Hardware sensor metrics reporting library based in part on the OpenHardwareMonitor library.
  /// Note some sensor readings, such as CPU temperature or HDD temperature, will require Administrator rights.
  /// </summary>
  public static class HardwareMetrics
  {
    private static Computer _ThisMachine = new Computer() { CPUEnabled = true, MainboardEnabled = true, HDDEnabled = true };

    public static void EnableHardwareMonitoring(bool enable)
    {
      try
      {
        if (enable)
        {
          _ThisMachine.Open();
        }
        else
        {
          _ThisMachine.Close();
        }
      }
      catch
      {
        throw;
      }
    }

    /// <summary>
    /// Gets the CPU Package temperature in deg C
    /// </summary>
    /// <returns></returns>
    public static double GetCpuTemperature()
    {
      try
      {
        foreach (var hardwareItem in _ThisMachine.Hardware)
        {
          if (hardwareItem.HardwareType == HardwareType.CPU)
          {
            hardwareItem.Update();
            foreach (IHardware subHardware in hardwareItem.SubHardware)
              subHardware.Update();

            foreach (var sensor in hardwareItem.Sensors)
            {
              if (sensor.SensorType == SensorType.Temperature && sensor.Name.StartsWith("CPU Package", 
                StringComparison.InvariantCultureIgnoreCase))
              {
                return (sensor.Value != null ? sensor.Value.Value : -1.0);
              }
            }
          }
        }
        return 0.0;
      }
      catch
      {
        throw;
      }
    }

    /// <summary>
    /// Gets the mainboard temperature in deg C
    /// </summary>
    /// <returns></returns>
    public static double GetMainBoardTemperature()
    {
      double temp = 0.0;
      int count = 0;

      try
      {
        foreach (var hardwareItem in _ThisMachine.Hardware)
        {
          if (hardwareItem.HardwareType == HardwareType.Mainboard)
          {
            hardwareItem.Update();
            foreach (IHardware subHardware in hardwareItem.SubHardware)
              subHardware.Update();

            foreach (var sensor in hardwareItem.Sensors)
            {
              if (sensor.SensorType == SensorType.Temperature)
              {
                temp += sensor.Value.Value;
                count++;
              }
            }
          }
        }
        return (count > 0) ? (temp / count) : 0.0;
      }
      catch
      {
        throw;
      }
    }

    /// <summary>
    /// Gets the harddisk temperature in deg C
    /// </summary>
    /// <returns></returns>
    public static double GetHddTemperature()
    {
      double temp = 0.0;
      int count = 0;

      try
      {
        foreach (var hardwareItem in _ThisMachine.Hardware)
        {
          if (hardwareItem.HardwareType == HardwareType.HDD)
          {
            hardwareItem.Update();
            foreach (IHardware subHardware in hardwareItem.SubHardware)
              subHardware.Update();

            foreach (var sensor in hardwareItem.Sensors)
            {
              if (sensor.SensorType == SensorType.Temperature)
              {
                temp += sensor.Value.Value;
                count++;
              }
            }
          }
        }
        return (count > 0) ? (temp / count) : 0.0;
      }
      catch
      {
        throw;
      }
    }

    /// <summary>
    /// Gets the harddisk utilized space in percent
    /// </summary>
    /// <returns></returns>
    public static double GetHddUsage()
    {
      try
      {
        foreach (var hardwareItem in _ThisMachine.Hardware)
        {
          if (hardwareItem.HardwareType == HardwareType.HDD)
          {
            hardwareItem.Update();
            foreach (IHardware subHardware in hardwareItem.SubHardware)
              subHardware.Update();

            foreach (var sensor in hardwareItem.Sensors)
            {
              if (sensor.SensorType == SensorType.Load)
              {
                return sensor.Value.Value;
              }
            }
          }
        }
        return 0.0;
      }
      catch
      {
        throw;
      }
    }

  }
}
