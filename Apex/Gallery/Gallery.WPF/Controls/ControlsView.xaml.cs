using System.Windows.Controls;
using Apex.MVVM;

namespace Gallery.Controls
{
    /// <summary>
    /// Interaction logic for ControlsView.xaml
    /// </summary>
    [View(typeof(ControlsViewModel))]
    public partial class ControlsView : UserControl
    {
        public ControlsView()
        {
            this.InitializeComponent();
        }
    }
}
