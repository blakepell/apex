﻿using System;
using System.Runtime.InteropServices;
using System.Drawing.Printing;

namespace Apex.Interop
{
    internal class Dwmapi
    {
        [DllImport("dwmapi.dll", PreserveSig = true)]
        internal static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport("dwmapi.dll")]
        internal static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref Margins pMarInset);

        /// <summary>
        /// The actual method that makes API calls to drop the shadow to the window
        /// </summary>
        /// <param name="windowHandle">The window handle.</param>
        /// <returns>
        /// True if the method succeeded, false if not
        /// </returns>
        public static bool DropShadow(IntPtr windowHandle)
        {
            try
            {
                int val = 2;
                int ret1 = DwmSetWindowAttribute(windowHandle, 2, ref val, 4);

                if (ret1 == 0)
                {
                    var m = new Margins { Bottom = 0, Left = 0, Right = 0, Top = 0 };
                    int ret2 = DwmExtendFrameIntoClientArea(windowHandle, ref m);
                    return ret2 == 0;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                // Probably dwmapi.dll not found (incompatible OS)
                return false;
            }
        }
    }
}