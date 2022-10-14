using System.Collections.ObjectModel;
using Apex.MVVM;
using Gallery.Behaviours;
using Gallery.Controls;
using Gallery.Converters;
using Gallery.DragAndDrop;
using Gallery.MVVM;
using Gallery.Popups;

namespace Gallery
{
    public class GalleryViewModel : ViewModel
    {
        public GalleryViewModel()
        {
            var home = new Home.HomeViewModel();
            this.GalleryItems.Add(home);

            var controlItems = new ControlsViewModel();
            this.GalleryItems.Add(controlItems);

            var converters = new ConvertersViewModel();
            this.GalleryItems.Add(converters);

            var popupItems = new PopupsViewModel();
            this.GalleryItems.Add(popupItems);

            var behaviourItems = new BehavioursViewModel();
            this.GalleryItems.Add(behaviourItems);

            var dragAndDropItems = new DragAndDropViewModel();
            this.GalleryItems.Add(dragAndDropItems);

            var mvvmItems = new MVVMViewModel();
            this.GalleryItems.Add(mvvmItems);

            this.SelectedGalleryItem = home;
        }

        /// <summary>
        /// The GalleryItems observable collection.
        /// </summary>
        private ObservableCollection<GalleryItemViewModel> GalleryItemsProperty =
            new ObservableCollection<GalleryItemViewModel>();

        /// <summary>
        /// Gets the GalleryItems observable collection.
        /// </summary>
        /// <value>The GalleryItems observable collection.</value>
        public ObservableCollection<GalleryItemViewModel> GalleryItems => GalleryItemsProperty;


        /// <summary>
        /// The NotifyingProperty for the SelectedGalleryItem property.
        /// </summary>
        private readonly NotifyingProperty SelectedGalleryItemProperty =
          new NotifyingProperty("SelectedGalleryItem", typeof(GalleryItemViewModel), default(GalleryItemViewModel));

        /// <summary>
        /// Gets or sets SelectedGalleryItem.
        /// </summary>
        /// <value>The value of SelectedGalleryItem.</value>
        public GalleryItemViewModel SelectedGalleryItem
        {
            get => (GalleryItemViewModel)this.GetValue(SelectedGalleryItemProperty);
            set => this.SetValue(SelectedGalleryItemProperty, value);
        }
    }

}
