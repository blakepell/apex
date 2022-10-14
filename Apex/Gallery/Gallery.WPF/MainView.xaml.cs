using System.Windows;
using System.Windows.Controls;

namespace Gallery
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        public MainView()
        {
            this.InitializeComponent();
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            ((GalleryViewModel)this.DataContext).SelectedGalleryItem = e.NewValue as GalleryItemViewModel;
        }
    }
}
