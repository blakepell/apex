using System.Windows.Controls;
using Apex.MVVM;

namespace Gallery.Converters
{
    /// <summary>
    /// Interaction logic for ConvertersView.xaml
    /// </summary>
    [View(typeof(ConvertersViewModel))]
    public partial class ConvertersView : UserControl
    {
        public ConvertersView()
        {
            this.InitializeComponent();
        }
    }
}
