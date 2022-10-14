using System.Windows.Controls;
using Apex.MVVM;

namespace Gallery.Popups
{
    /// <summary>
    /// Interaction logic for PopupsView.xaml
    /// </summary>
    [View(typeof(PopupsViewModel))]
    public partial class PopupsView : UserControl
    {
        public PopupsView()
        {
            this.InitializeComponent();
        }
    }
}
