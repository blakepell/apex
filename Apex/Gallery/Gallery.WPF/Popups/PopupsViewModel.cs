using Apex.MVVM;
using Gallery.Popups.CustomisedPopup;
using Gallery.Popups.SimplePopup;

namespace Gallery.Popups
{
    [ViewModel]
    public class PopupsViewModel : GalleryItemViewModel
    {
        public PopupsViewModel()
        {
            this.Title = "Popups";

            this.GalleryItems.Add(new SimplePopupViewModel());
            this.GalleryItems.Add(new CustomisedPopupViewModel());
        }
    }
}
