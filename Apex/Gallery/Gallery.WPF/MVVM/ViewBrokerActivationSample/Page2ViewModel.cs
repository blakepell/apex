using Apex.Controls;
using Apex.MVVM;

namespace Gallery.MVVM.ViewBrokerActivationSample
{
    [ViewModel]
    public class Page2ViewModel : ViewModel, ISelectableItem 
    {
        public string Title => "Page 2";

        private readonly NotifyingProperty isSelectedProperty = new NotifyingProperty("IsSelected", typeof(bool), default(bool));

        public bool IsSelected
        {
            get => (bool)this.GetValue(isSelectedProperty);
            set => this.SetValue(isSelectedProperty, value);
        }
    }
}
