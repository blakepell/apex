using System.Windows.Controls;
using Apex;
using Apex.Helpers.Popups;
using Apex.MVVM;

namespace Gallery.Popups.CustomisedPopup
{
    /// <summary>
    /// Interaction logic for SimplePopupView.xaml
    /// </summary>
    [View(typeof(CustomisedPopupViewModel))]
    public partial class CustomisedPopupView : UserControl, IView
    {
        public CustomisedPopupView()
        {
            this.InitializeComponent();
        }

        public void OnActivated()
        {
            this.ViewModel.ShowBouncePopupCommand.Executing += this.ShowBouncePopupCommandOnExecuting;
            this.ViewModel.ShowFadePopupCommand.Executing += this.ShowFadePopupCommandOnExecuting;
        }

        public void OnDeactivated()
        {
            this.ViewModel.ShowBouncePopupCommand.Executing -= this.ShowBouncePopupCommandOnExecuting;
            this.ViewModel.ShowFadePopupCommand.Executing -= this.ShowFadePopupCommandOnExecuting;
        }

        private void ShowBouncePopupCommandOnExecuting(object sender, CancelCommandEventArgs args)
        {
            var shell = ApexBroker.GetShell();
            shell.PopupAnimationHelper = new BounceInOutPopupAnimationHelper();
            shell.ShowPopup(new CustomisedPopup());
        }
        
        private void ShowFadePopupCommandOnExecuting(object sender, CancelCommandEventArgs args)
        {
            var shell = ApexBroker.GetShell();
            shell.PopupAnimationHelper = new FadeInOutPopupAnimationHelper();
            shell.ShowPopup(new CustomisedPopup());
        }

        public CustomisedPopupViewModel ViewModel => (CustomisedPopupViewModel)this.DataContext;
    }
}
