using Apex.MVVM;
using Apex.DragAndDrop;
using System.Collections.ObjectModel;
using Apex.Adorners;
using System.Windows.Controls;

namespace Gallery.DragAndDrop.ItemsControlSample
{
    /// <summary>
    /// Interaction logic for ItemsControlSampleView.xaml
    /// </summary>
    [View(typeof(ItemsControlSampleViewModel))]
    public partial class ItemsControlSampleView : UserControl
    {
        public ItemsControlSampleView()
        {
            this.InitializeComponent(); dragAndDropHost.DragAndDropStart += this.Instance_DragAndDropStart;
            dragAndDropHost.DragAndDropContinue += this.Instance_DragAndDropContinue;
            dragAndDropHost.DragAndDropEnd += this.Instance_DragAndDropEnd;
        }

        void Instance_DragAndDropEnd(object sender, DragAndDropEventArgs args)
        {
            var from =
                ((ItemsControl)args.DragSource).ItemsSource as ObservableCollection<string>;
            var to =
                ((ItemsControl)args.DropTarget).ItemsSource as ObservableCollection<string>;
            from.Remove((string)args.DragData);
            to.Add((string)args.DragData);
        }

        void Instance_DragAndDropContinue(object sender, DragAndDropEventArgs args)
        {
            args.Allow = true;
        }

        void Instance_DragAndDropStart(object sender, DragAndDropEventArgs args)
        {
            args.Allow = true;
            args.DragAdorner = new VisualAdorner(args.DragElement);
        }
    }
}
