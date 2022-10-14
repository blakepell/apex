using Apex.MVVM;
using Gallery.MVVM.CommandingSample;
using Gallery.MVVM.SimpleSample;
using Gallery.MVVM.ViewBrokerActivationSample;
using Gallery.MVVM.ViewBrokerSample;

namespace Gallery.MVVM
{
    [ViewModel]
    public class MVVMViewModel : GalleryItemViewModel
    {
        public MVVMViewModel()
        {
            this.Title = "MVVM";

            this.GalleryItems.Add(new SimpleExampleViewModel());
            this.GalleryItems.Add(new CommandingSampleViewModel());
            this.GalleryItems.Add(new ViewBrokerSampleViewModel());
            this.GalleryItems.Add(new ViewBrokerActivationSampleViewModel());
        }
    }
}
