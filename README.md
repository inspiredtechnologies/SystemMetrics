# SystemMetrics
A C# library for retrieving Windows OS, hardware information and resource usage.

SystemMetrics is a compilation of .NET classes for retrieving hardware metrics and Windows OS performance counters. The HardwareMetrics class, which is based on the OpenHardwareMonitor library, reports the following hardware status: CPU temperature, mainboard temperature, HDD temperature and HDD usage. The OsMetrics class reports these Windows OS information: CPU usage, memory usage, network activity, HDD activity and system up time. Future releases will add a resource monitoring class that will enable alerts triggering when one or more metrics hit preset limits, such as when the CPU usage exceeds 90%. 

The HardwareMetrics class requires privilege elevation in order to read hardware sensors such as mainboard and HDD temperatures. This is explicitly requested for in the app manifest file.
