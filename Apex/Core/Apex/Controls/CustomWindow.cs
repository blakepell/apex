using System;
using System.Windows;
using System.Windows.Interop;
using Apex.Interop;
using System.Runtime.InteropServices;

namespace Apex.Controls
{
    /// <summary>
    /// A Custom Window is a Window that has its chrome entirely
    /// drawn by WPF.
    /// </summary>
    public class CustomWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomWindow"/> class.
        /// </summary>
        public CustomWindow()
        {
            //  Custom shells have no border and no window style.
            this.ResizeMode = ResizeMode.NoResize;
            this.WindowStyle = WindowStyle.None;

            this.SourceInitialized += this.CustomShell_SourceInitialized;
        }

        void CustomShell_SourceInitialized(object sender, EventArgs e)
        {
            var handle = (new WindowInteropHelper(this)).Handle;
            HwndSource.FromHwnd(handle).AddHook(WindowProc);
            dwmapi.DropShadow(handle);
        }

        private static IntPtr WindowProc(
              IntPtr hwnd,
              int msg,
              IntPtr wParam,
              IntPtr lParam,
              ref bool handled)
        {
            switch (msg)
            {
                case 0x0024:/* WM_GETMINMAXINFO */
                    WmGetMinMaxInfo(hwnd, lParam);
                    handled = true;
                    break;
            }

            return (IntPtr)0;
        }

        private static void WmGetMinMaxInfo(IntPtr hwnd, IntPtr lParam)
        {
            var mmi = (MINMAXINFO)Marshal.PtrToStructure(lParam, typeof(MINMAXINFO));

            // Adjust the maximized size and position to fit the work area of the correct monitor
            int MONITOR_DEFAULTTONEAREST = 0x00000002;
            var monitor = User32.MonitorFromWindow(hwnd, MONITOR_DEFAULTTONEAREST);

            if (monitor != IntPtr.Zero)
            {

                var monitorInfo = new MONITORINFO();
                User32.GetMonitorInfo(monitor, monitorInfo);
                var rcWorkArea = monitorInfo.rcWork;
                var rcMonitorArea = monitorInfo.rcMonitor;
                mmi.ptMaxPosition.x = Math.Abs(rcWorkArea.left - rcMonitorArea.left);
                mmi.ptMaxPosition.y = Math.Abs(rcWorkArea.top - rcMonitorArea.top);
                mmi.ptMaxSize.x = Math.Abs(rcWorkArea.right - rcWorkArea.left);
                mmi.ptMaxSize.y = Math.Abs(rcWorkArea.bottom - rcWorkArea.top);
            }

            Marshal.StructureToPtr(mmi, lParam, true);
        }

        /// <summary>
        /// The DependencyProperty for the HasDropShadow property.
        /// </summary>
        private static readonly DependencyProperty HasDropShadowProperty =
          DependencyProperty.Register("HasDropShadow", typeof(bool), typeof(CustomWindow),
          new PropertyMetadata(true, OnHasDropShadowChanged));

        /// <summary>
        /// Gets or sets HasDropShadow.
        /// </summary>
        /// <value>The value of HasDropShadow.</value>
        public bool HasDropShadow
        {
            get => (bool)this.GetValue(HasDropShadowProperty);
            set => this.SetValue(HasDropShadowProperty, value);
        }

        /// <summary>
        /// Called when HasDropShadow is changed.
        /// </summary>
        /// <param name="o">The dependency object.</param>
        /// <param name="args">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnHasDropShadowChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            var me = o as CustomWindow;
        }
    }
}
