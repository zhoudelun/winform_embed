using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication5
{
    public    class classHelper
    { 
        ///// <summary>
        ///// 获取应用程序窗口句柄
        ///// </summary>
        ///// <param name="processId"></param>
        ///// <returns></returns>
        //private IntPtr GetWindowHandle(int processId)
        //{
        //    var windowHandle = IntPtr.Zero;
        //    EnumThreadWindowsCallback windowsCallback = new EnumThreadWindowsCallback(FindMainWindow);
        //    EnumWindows(windowsCallback, IntPtr.Zero);
        //    //保持循环
        //    GC.KeepAlive(windowsCallback);

        //    bool FindMainWindow(IntPtr handle, IntPtr extraParameter)
        //    {
        //        int num;
        //        GetWindowThreadProcessId(new HandleRef(this, handle), out num);
        //        if (num == processId && IsWindowExist(handle))
        //        {
        //            windowHandle = handle;
        //            return true;
        //        }
        //        return false;
        //    }

        //    return windowHandle;
        //}
        public delegate bool EnumThreadWindowsCallback(IntPtr hWnd, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool EnumWindows(EnumThreadWindowsCallback callback, IntPtr extraData);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowThreadProcessId(HandleRef handle, out int processId);
      

    }
}
