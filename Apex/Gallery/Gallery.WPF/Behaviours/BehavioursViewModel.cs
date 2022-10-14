using Apex.MVVM;
using Gallery.Behaviours.ListViewItemContextMenuBehaviour;

namespace Gallery.Behaviours
{
    [ViewModel]
    public class BehavioursViewModel : GalleryItemViewModel
    {
        public BehavioursViewModel()
        {
            this.Title = "Behaviours";

            this.GalleryItems.Add(new ListViewItemContextMenuBehaviourViewModel());
        }
    }
}
