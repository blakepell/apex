using System.Windows.Controls;
using Apex.MVVM;

namespace Gallery.PathTextBox
{
    /// <summary>
    /// Interaction logic for PathTextBoxView.xaml
    /// </summary>
    [View(typeof(PathTextBoxViewModel))]
    public partial class PathTextBoxView : UserControl
    {
        public PathTextBoxView()
        {
            this.InitializeComponent();
        }
    }
}
