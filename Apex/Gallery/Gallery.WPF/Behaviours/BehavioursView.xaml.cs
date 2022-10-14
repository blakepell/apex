using System.Windows.Controls;
using Apex.MVVM;

namespace Gallery.Behaviours
{
    /// <summary>
    /// Interaction logic for BehavioursView.xaml
    /// </summary>
    [View(typeof(BehavioursViewModel))]
    public partial class BehavioursView : UserControl
    {
        public BehavioursView()
        {
            this.InitializeComponent();
        }
    }
}
