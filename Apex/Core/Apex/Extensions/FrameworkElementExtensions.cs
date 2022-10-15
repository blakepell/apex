using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Apex.Extensions
{
    internal static class FrameworkElementExtensions
    {
        /// <summary>
        /// Get the window container of framework element.
        /// </summary>
        public static Window GetParentWindow(this FrameworkElement element)
        {
            DependencyObject dp = element;
            while (dp != null)
            {
                var tp = LogicalTreeHelper.GetParent(dp);
                if (tp is Window window)
                {
                    return window;
                }
                else
                {
                    dp = tp;
                }
            }

            return null;
        }

        public static FrameworkElement GetTopLevelParent(this FrameworkElement element)
        {
            var p = element;
            while (p != null)
            {
                if (p.Parent == null)
                {
                    return p;
                }

                p = p.Parent as FrameworkElement;
            }

            return null;
        }

        public static BitmapSource RenderBitmap(this FrameworkElement element)
        {
            //  Create a visual brush from the element.
            var elementBrush = new VisualBrush(element);

            //  Create a visual.
            var visual = new DrawingVisual();

            //  Open the visual to get a drawing context.
            var dc = visual.RenderOpen();

            //  Draw the element in the appropriately sized rectangle.
            dc.DrawRectangle(elementBrush, null, new Rect(0, 0, element.ActualWidth, element.ActualHeight));

            //  Close the drawing context.
            dc.Close();

            //  WPF uses 96 DPI - this is defined in System.Windows.SystemParameters.DPI
            //  but it is internal, so we must use a magic number.
            double systemDPI = 96;

            //  Create the bitmap and render it.
            var bitmap = new RenderTargetBitmap((int)element.ActualWidth, (int)element.ActualHeight, systemDPI,
                systemDPI, PixelFormats.Default);
            bitmap.Render(visual);

            //  Return the bitmap.
            return bitmap;
        }
    }
}