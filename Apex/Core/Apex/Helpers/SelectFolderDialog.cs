using System;
using System.Runtime.InteropServices;
using System.Text;
using Apex.Interop;

namespace Apex.Helpers
{
    public class SelectFolderDialog
    {
        private string initialPath;

        public int OnBrowseEvent(IntPtr hWnd, int msg, IntPtr lp, IntPtr lpData)
        {
            switch (msg)
            {
                case Shell32.BFFM_INITIALIZED: // Required to set initialPath
                {
                    //Win32.SendMessage(new HandleRef(null, hWnd), BFFM_SETSELECTIONA, 1, lpData);
                    // Use BFFM_SETSELECTIONW if passing a Unicode string, i.e. native CLR Strings.
                    User32.SendMessage(new HandleRef(null, hWnd), Shell32.BFFM_SETSELECTIONW, 1, initialPath);
                    break;
                }
                case Shell32.BFFM_SELCHANGED:
                {
                    var pathPtr = Marshal.AllocHGlobal(260 * Marshal.SystemDefaultCharSize);
                    if (Shell32.SHGetPathFromIDList(lp, pathPtr))
                    {
                        User32.SendMessage(new HandleRef(null, hWnd), Shell32.BFFM_SETSTATUSTEXTW, 0, pathPtr);
                    }

                    Marshal.FreeHGlobal(pathPtr);
                    break;
                }
            }

            return 0;
        }

        public bool? ShowDialog()
        {
            this.SelectedFolderPath = this.SelectFolder(this.Caption, null, this.ParentWindowHandle);
            return !string.IsNullOrEmpty(this.SelectedFolderPath);
        }

        private string SelectFolder(string caption, string initialPath, IntPtr parentHandle)
        {
            this.initialPath = initialPath;
            var sb = new StringBuilder(256);
            var bufferAddress = Marshal.AllocHGlobal(256);
            var pidl = IntPtr.Zero;
            var bi = new BROWSEINFO
            {
                hwndOwner = parentHandle,
                pidlRoot = IntPtr.Zero,
                lpszTitle = caption,
                ulFlags = Shell32.BIF_NEWDIALOGSTYLE | Shell32.BIF_SHAREABLE,
                lpfn = this.OnBrowseEvent,
                lParam = IntPtr.Zero,
                iImage = 0
            };

            try
            {
                pidl = Shell32.SHBrowseForFolder(ref bi);
                if (true != Shell32.SHGetPathFromIDList(pidl, bufferAddress))
                {
                    return null;
                }

                sb.Append(Marshal.PtrToStringAuto(bufferAddress));
            }
            finally
            {
                // Caller is responsible for freeing this memory.
                Marshal.FreeCoTaskMem(pidl);
            }

            return sb.ToString();
        }

        public string Caption { get; private set; }
        public IntPtr ParentWindowHandle { get; private set; }
        public string SelectedFolderPath { get; private set; }
    }
}