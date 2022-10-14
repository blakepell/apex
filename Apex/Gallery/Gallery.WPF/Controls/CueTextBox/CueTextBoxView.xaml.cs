using System.Windows.Controls;
using Apex.MVVM;

namespace Gallery.CueTextBox
{
    /// <summary>
    /// Interaction logic for CueTextBoxView.xaml
    /// </summary>
    [View(typeof(CueTextBoxViewModel))]
    public partial class CueTextBoxView : UserControl
    {
        public CueTextBoxView()
        {
            this.InitializeComponent();
        }
    }
}
