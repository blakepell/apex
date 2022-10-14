using System.Windows.Controls;
using Apex.MVVM;

namespace Gallery.Home
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    [View(typeof(HomeViewModel))]
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            this.InitializeComponent();
        }
    }
}
