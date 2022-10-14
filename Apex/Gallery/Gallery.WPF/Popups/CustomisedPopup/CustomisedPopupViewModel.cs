using Apex.MVVM;

namespace Gallery.Popups.CustomisedPopup
{
    public class CustomisedPopupViewModel : GalleryItemViewModel
    {
        public CustomisedPopupViewModel()
        {
            this.Title = "Customised Popup";

            //  Create the commands.
            this.ShowBouncePopupCommand = new Command(this.DoShowBouncePopupCommand);
            this.ShowFadePopupCommand = new Command(this.DoShowFadePopupCommand);
        }
        
        /// <summary>
        /// Performs the ShowBouncePopup command.
        /// </summary>
        /// <param name="parameter">The ShowBouncePopup command parameter.</param>
        private void DoShowBouncePopupCommand(object parameter)
        {
        }

        /// <summary>
        /// Gets the ShowBouncePopup command.
        /// </summary>
        /// <value>The value of .</value>
        public Command ShowBouncePopupCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// Performs the ShowFadePopup command.
        /// </summary>
        /// <param name="parameter">The ShowFadePopup command parameter.</param>
        private void DoShowFadePopupCommand(object parameter)
        {
        }

        /// <summary>
        /// Gets the ShowFadePopup command.
        /// </summary>
        /// <value>The value of .</value>
        public Command ShowFadePopupCommand
        {
            get;
            private set;
        }
    }
}
