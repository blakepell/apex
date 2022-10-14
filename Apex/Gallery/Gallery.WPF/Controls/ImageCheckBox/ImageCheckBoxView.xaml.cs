using System.Windows.Controls;
using Apex.MVVM;

namespace Gallery.Controls.ImageCheckBox
{
    /// <summary>
    /// Interaction logic for ImageCheckBoxView.xaml
    /// </summary>
    [View(typeof(ImageCheckBoxViewModel))]
    public partial class ImageCheckBoxView : UserControl
    {
        public ImageCheckBoxView()
        {
            this.InitializeComponent();
        }
    }
}
