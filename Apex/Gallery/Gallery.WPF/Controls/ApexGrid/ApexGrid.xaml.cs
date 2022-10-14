using System.Windows.Controls;
using Apex.MVVM;
using Gallery.Controls.ApexGrid;

namespace ControlsSample.Samples
{
    /// <summary>
    /// Interaction logic for ApexGrid.xaml
    /// </summary>
    [View(typeof(ApexGridViewModel))]
    public partial class ApexGrid : UserControl
    {
        public ApexGrid()
        {
            this.InitializeComponent();
        }
    }
}
