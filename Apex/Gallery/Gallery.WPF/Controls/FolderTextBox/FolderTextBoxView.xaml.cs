using System.Windows.Controls;
using Apex.MVVM;

namespace Gallery.Controls.FolderTextBox
{
    /// <summary>
    /// Interaction logic for FolderTextBoxView.xaml
    /// </summary>
    [View(typeof(FolderTextBoxViewModel))]
    public partial class FolderTextBoxView : UserControl
    {
        public FolderTextBoxView()
        {
            this.InitializeComponent();
        }
    }
}
