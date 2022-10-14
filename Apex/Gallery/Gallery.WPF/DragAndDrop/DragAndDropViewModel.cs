using Apex.MVVM;
using Gallery.DragAndDrop.CanvasSample;
using Gallery.DragAndDrop.ItemsControlSample;

namespace Gallery.DragAndDrop
{
    [ViewModel]
    public class DragAndDropViewModel : GalleryItemViewModel
    {
        public DragAndDropViewModel()
        {
            this.Title = "Drag & Drop";

            this.GalleryItems.Add(new CanvasSampleViewModel());
            this.GalleryItems.Add(new ItemsControlSampleViewModel());
        }
    }
}
