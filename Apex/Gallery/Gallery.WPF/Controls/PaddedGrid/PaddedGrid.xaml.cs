using System.Windows.Controls;
using Apex.MVVM;
using Gallery.Controls.PaddedGrid;

namespace ControlsSample.Samples
{
    /// <summary>
    /// Interaction logic for PaddedGrid.xaml
    /// </summary>
    [View(typeof(PaddedGridViewModel))]
    public partial class PaddedGrid : UserControl
    {
        public PaddedGrid()
        {
            this.InitializeComponent();
        }
    }
}
