using System.Windows.Controls;
using Apex.MVVM;

namespace Gallery.DragAndDrop
{
    /// <summary>
    /// Interaction logic for DragAndDropView.xaml
    /// </summary>
    [View(typeof(DragAndDropViewModel))]
    public partial class DragAndDropView : UserControl
    {
        public DragAndDropView()
        {
            this.InitializeComponent();
        }
    }
}
