using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using Apex.Extensions;

namespace Apex.Adorners 
{
    /// <summary>
    /// A Visual Adorner.
    /// </summary>
    public class VisualAdorner : Adorner
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VisualAdorner"/> class.
        /// </summary>
        /// <param name="visual">The visual.</param>
        public VisualAdorner(FrameworkElement visual)
        {
            //  Create a brush that draws the visual.
#if !SILVERLIGHT
            //VisualBrush _brush = new VisualBrush(visual);

            var _brush = new ImageBrush(visual.RenderBitmap());
#else
            SolidColorBrush _brush = new SolidColorBrush(Colors.Red);
#endif

            //  Create a rectangle that will be painted with the visual.
            var r = new Rectangle
            {
                //  Set the rectangle dimensions to the be the same as the visual.
                Width = visual.ActualWidth,
                Height = visual.ActualHeight,
                Fill = _brush,
                Opacity = 1,
                IsHitTestVisible = false
            };

            this.UIElement = r;
        }
    }
}
