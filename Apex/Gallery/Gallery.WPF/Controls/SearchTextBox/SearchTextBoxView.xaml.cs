using System.Windows.Controls;
using Apex.MVVM;

namespace Gallery.SearchTextBox
{
    /// <summary>
    /// Interaction logic for SearchTextBoxView.xaml
    /// </summary>
    [View(typeof(SearchTextBoxViewModel))]
    public partial class SearchTextBoxView : UserControl
    {
        public SearchTextBoxView()
        {
            this.InitializeComponent();
        }
    }
}
