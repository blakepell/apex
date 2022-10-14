using System.Windows.Controls;
using Apex.MVVM;

namespace Gallery.Controls.ImageButton
{
    /// <summary>
    /// Interaction logic for ImageButtonView.xaml
    /// </summary>
    [View(typeof(ImageButtonViewModel))]
    public partial class ImageButtonView : UserControl
    {
        public ImageButtonView()
        {
            this.InitializeComponent();
        }
    }
}
