using Apex.MVVM;

namespace Gallery.MVVM.SimpleSample
{
    /// <summary>
    /// The SimpleExampleViewModel ViewModel class.
    /// </summary>
    [ViewModel]
    public class SimpleExampleViewModel : GalleryItemViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleExampleViewModel"/> class.
        /// </summary>
        public SimpleExampleViewModel()
        {
            this.Title = "Simple MVVM Example";

            //  Create the build name command.
            this.BuildNameCommand = new Command(this.DoBuildNameCommand, false);
        }

        /// <summary>
        /// Performs the build name command.
        /// </summary>
        private void DoBuildNameCommand()
        {
            //  Set the full name.
            this.FullName = this.FirstName + " " + this.SecondName;
        }

        /// <summary>
        /// The first name property.
        /// </summary>
        private NotifyingProperty firstNameProperty = 
            new NotifyingProperty("FirstName", typeof(string), string.Empty);

        /// <summary>
        /// The second name property.
        /// </summary>
        private NotifyingProperty secondNameProperty =
            new NotifyingProperty("SecondName", typeof(string), string.Empty);

        /// <summary>
        /// The full name property.
        /// </summary>
        private NotifyingProperty fullNameProperty =
            new NotifyingProperty("FullName", typeof(string), string.Empty);

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>The first name.</value>
        public string FirstName
        {
            get => (string)this.GetValue(firstNameProperty);
            set 
            {
                this.SetValue(firstNameProperty, value);
                this.BuildNameCommand.CanExecute = string.IsNullOrEmpty(this.FirstName) == false && string.IsNullOrEmpty(this.SecondName) == false;
            }
        }

        /// <summary>
        /// Gets or sets the second name.
        /// </summary>
        /// <value>The second name.</value>
        public string SecondName
        {
            get => (string)this.GetValue(secondNameProperty);
            set
            {
                this.SetValue(secondNameProperty, value);
                this.BuildNameCommand.CanExecute = string.IsNullOrEmpty(this.FirstName) == false && string.IsNullOrEmpty(this.SecondName) == false;
            }
        }

        /// <summary>
        /// Gets or sets the full name.
        /// </summary>
        /// <value>The full name.</value>
        public string FullName
        {
            get => (string)this.GetValue(fullNameProperty);
            set => this.SetValue(fullNameProperty, value);
        }
        
        /// <summary>
        /// Gets the build name command.
        /// </summary>
        /// <value>The build name command.</value>
        public Command BuildNameCommand
        {
            get;
            private set;
        }
    }
}
