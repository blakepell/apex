using System.Windows.Controls;
using Apex;
using Apex.MVVM;

namespace Gallery.Popups.SimplePopup
{
    /// <summary>
    /// Interaction logic for SimplePopupView.xaml
    /// </summary>
    [View(typeof(SimplePopupViewModel))]
    public partial class SimplePopupView : UserControl, IView
    {
        public SimplePopupView()
        {
            this.InitializeComponent();
        }

        public void OnActivated()
        {
            this.ViewModel.ShowPopupCommand.Executing += this.ShowPopupCommandOnExecuting;
        }

        public void OnDeactivated()
        {
            this.ViewModel.ShowPopupCommand.Executing -= this.ShowPopupCommandOnExecuting;
        }

        private void ShowPopupCommandOnExecuting(object sender, CancelCommandEventArgs args)
        {
            var shell = ApexBroker.GetShell();
            this.ViewModel.PopupResult =
                shell.ShowPopup(new SimplePopup());
        }

        public SimplePopupViewModel ViewModel => (SimplePopupViewModel)this.DataContext;
    }
}
