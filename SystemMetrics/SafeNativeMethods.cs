using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SystemMetrics
{
  class SafeNativeMethods
  {
    [DllImport("kernel32")]
    extern public static UInt64 GetTickCount64();
  }
}
