using Apex.MVVM;
using Apex.DragAndDrop;
using Apex.Adorners;
using System.Windows.Controls;
using System.Windows.Input;

namespace Gallery.DragAndDrop.CanvasSample
{
    /// <summary>
    /// Interaction logic for CanvasSampleView.xaml
    /// </summary>
    [View(typeof(CanvasSampleViewModel))]
    public partial class CanvasSampleView : UserControl
    {
        public CanvasSampleView()
        {
            this.InitializeComponent();

            //var dragAndDropHost = ApexBroker.GetShell().DragAndDropHost;

            dragAndDropHost.DragAndDropStart += this.Instance_DragAndDropStart;
            dragAndDropHost.DragAndDropContinue += this.Instance_DragAndDropContinue;
            dragAndDropHost.DragAndDropEnd += this.Instance_DragAndDropEnd;
        }

        void Instance_DragAndDropEnd(object sender, DragAndDropEventArgs args)
        {
            //var dragAndDropHost = ApexBroker.GetShell().DragAndDropHost;
            var point = Mouse.GetPosition(dragAndDropHost);
            point.Offset(-args.InitialElementOffset.X, -args.InitialElementOffset.Y);

            //  Set the position of the element.
            Canvas.SetLeft(args.DragElement, point.X);
            Canvas.SetTop(args.DragElement, point.Y);

            args.DragElement.Opacity = 1;
        }

        void Instance_DragAndDropContinue(object sender, DragAndDropEventArgs args)
        {
           args.Allow = true;
        }

        void Instance_DragAndDropStart(object sender, DragAndDropEventArgs args)
        {
            args.Allow = true;
            args.DragAdorner = new VisualAdorner(args.DragElement);
            args.DragElement.Opacity = 0;
        }
    }
}
