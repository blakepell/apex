using System.Windows.Controls;
using Apex.MVVM;

namespace Gallery.Behaviours.ListViewItemContextMenuBehaviour
{
    /// <summary>
    /// Interaction logic for ListViewItemContextMenuBehaviourView.xaml
    /// </summary>
    [View(typeof(ListViewItemContextMenuBehaviourViewModel))]
    public partial class ListViewItemContextMenuBehaviourView : UserControl
    {
        public ListViewItemContextMenuBehaviourView()
        {
            this.InitializeComponent();
        }
    }
}
