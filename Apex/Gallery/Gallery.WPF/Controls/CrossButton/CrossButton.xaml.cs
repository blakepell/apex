using System.Windows.Controls;
using Apex.MVVM;
using Gallery.Controls.CrossButton;

namespace ControlsSample.Samples
{
    /// <summary>
    /// Interaction logic for CrossButton.xaml
    /// </summary>
    [View(typeof(CrossButtonViewModel))]
    public partial class CrossButton : UserControl
    {
        public CrossButton()
        {
            this.InitializeComponent();
        }
    }
}
