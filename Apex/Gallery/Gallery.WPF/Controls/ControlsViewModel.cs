using Apex.MVVM;
using Gallery.Controls.ApexGrid;
using Gallery.Controls.CrossButton;
using Gallery.Controls.EnumComboBox;
using Gallery.Controls.FolderTextBox;
using Gallery.Controls.ImageButton;
using Gallery.Controls.ImageCheckBox;
using Gallery.Controls.MultiBorder;
using Gallery.Controls.PaddedGrid;
using Gallery.Controls.SelectableItemsControl;
using Gallery.Controls.TabbedDocumentInterface;
using Gallery.CueTextBox;
using Gallery.PathTextBox;
using Gallery.PivotControl;
using Gallery.SearchTextBox;

namespace Gallery.Controls
{
    [ViewModel]
    public class ControlsViewModel : GalleryItemViewModel
    {
        public ControlsViewModel()
        {
            this.Title = "Controls";

            this.GalleryItems.Add(new ApexGridViewModel());
            this.GalleryItems.Add(new CrossButtonViewModel());
            this.GalleryItems.Add(new CueTextBoxViewModel());
            this.GalleryItems.Add(new EnumComboBoxViewModel());
            this.GalleryItems.Add(new FolderTextBoxViewModel());
            this.GalleryItems.Add(new ImageButtonViewModel());
            this.GalleryItems.Add(new ImageCheckBoxViewModel());
            this.GalleryItems.Add(new MultiBorderViewModel());
            this.GalleryItems.Add(new PaddedGridViewModel());
            this.GalleryItems.Add(new PathTextBoxViewModel());
            this.GalleryItems.Add(new PivotControlViewModel());
            this.GalleryItems.Add(new SearchTextBoxViewModel());
            this.GalleryItems.Add(new SelectableItemsControlViewModel());
            this.GalleryItems.Add(new TabbedDocumentInterfaceViewModel());
        }
    }
}
