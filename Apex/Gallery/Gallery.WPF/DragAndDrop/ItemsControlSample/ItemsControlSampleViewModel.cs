using System.Collections.ObjectModel;

namespace Gallery.DragAndDrop.ItemsControlSample
{
    /// <summary>
    /// The ItemsControlSampleViewModel ViewModel class.
    /// </summary>
    public class ItemsControlSampleViewModel : GalleryItemViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemsControlSampleViewModel"/> class.
        /// </summary>
        public ItemsControlSampleViewModel()
        {
            this.Title = "Items Control Sample";

            this.Group1.Add("Homer Simpson");
            this.Group1.Add("Marge Simpson");
            this.Group1.Add("Bart Simpson");
            this.Group1.Add("Lisa Simpson");
            this.Group1.Add("Maggie Simpson");

            this.Group2.Add("Mr Burns");
            this.Group2.Add("Mr Smithers");

            this.Group3.Add("Krusty");
            this.Group3.Add("Bubblebee Man");

            group4.Add("Itchy");
            group4.Add("Scratchy");
        }

        private ObservableCollection<string> group1 = new ObservableCollection<string>();
        private ObservableCollection<string> group2 = new ObservableCollection<string>();
        private ObservableCollection<string> group3 = new ObservableCollection<string>();
        private ObservableCollection<string> group4 = new ObservableCollection<string>();

        public ObservableCollection<string> Group1 => group1;
        public ObservableCollection<string> Group2 => group2;
        public ObservableCollection<string> Group3 => group3;
        public ObservableCollection<string> Group4 => group4;
    }
}
