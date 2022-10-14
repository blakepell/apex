using Apex.Controls;
using Apex.MVVM;

namespace Gallery.Controls.SelectableItemsControl
{
    public class SelectableItemViewModel : ViewModel, ISelectableItem 
    {
        public SelectableItemViewModel()
        {
            
        }
        
        /// <summary>
        /// The NotifyingProperty for the Title property.
        /// </summary>
        private readonly NotifyingProperty TitleProperty =
          new NotifyingProperty("Title", typeof(string), default(string));

        /// <summary>
        /// Gets or sets Title.
        /// </summary>
        /// <value>The value of Title.</value>
        public string Title
        {
            get => (string)this.GetValue(TitleProperty);
            set => this.SetValue(TitleProperty, value);
        }

        
        /// <summary>
        /// The NotifyingProperty for the Details property.
        /// </summary>
        private readonly NotifyingProperty DetailsProperty =
          new NotifyingProperty("Details", typeof(string), default(string));

        /// <summary>
        /// Gets or sets Details.
        /// </summary>
        /// <value>The value of Details.</value>
        public string Details
        {
            get => (string)this.GetValue(DetailsProperty);
            set => this.SetValue(DetailsProperty, value);
        }

        /// <summary>
        /// The NotifyingProperty for the IsSelected property.
        /// </summary>
        private readonly NotifyingProperty IsSelectedProperty =
          new NotifyingProperty("IsSelected", typeof(bool), default(bool));

        /// <summary>
        /// Gets or sets IsSelected.
        /// </summary>
        /// <value>The value of IsSelected.</value>
        public bool IsSelected
        {
            get => (bool)this.GetValue(IsSelectedProperty);
            set => this.SetValue(IsSelectedProperty, value);
        }
    }
}
