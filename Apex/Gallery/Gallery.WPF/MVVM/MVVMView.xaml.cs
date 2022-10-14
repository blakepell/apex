using System.Windows.Controls;
using Apex.MVVM;

namespace Gallery.MVVM
{
    /// <summary>
    /// Interaction logic for MVVMView.xaml
    /// </summary>
    [View(typeof(MVVMViewModel))]
    public partial class MVVMView : UserControl
    {
        public MVVMView()
        {
            this.InitializeComponent();
        }
    }
}
