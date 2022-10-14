using System.Windows.Controls;
using Apex.MVVM;

namespace Gallery.Controls.MultiBorder
{
    /// <summary>
    /// Interaction logic for MultiBorderView.xaml
    /// </summary>
    [View(typeof(MultiBorderViewModel))]
    public partial class MultiBorderView : UserControl
    {
        public MultiBorderView()
        {
            this.InitializeComponent();
        }
    }
}
