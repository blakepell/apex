﻿using System.Collections.ObjectModel;
using Apex.MVVM;

namespace Gallery.MVVM.ViewBrokerSample
{
    /// <summary>
    /// The DeviceViewModel ViewModel class.
    /// </summary>
    [ViewModel]
    public class FolderViewModel : ViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FolderViewModel"/> class.
        /// </summary>
        public FolderViewModel()
        {
        }

        
        private NotifyingProperty NameProperty =
          new NotifyingProperty("Name", typeof(string), default(string));

        public string Name
        {
            get => (string)this.GetValue(NameProperty);
            set => this.SetValue(NameProperty, value);
        }

        
        private NotifyingProperty DescriptionProperty =
          new NotifyingProperty("Description", typeof(string), default(string));

        public string Description
        {
            get => (string)this.GetValue(DescriptionProperty);
            set => this.SetValue(DescriptionProperty, value);
        }                     

        /// <summary>
        /// The components.
        /// </summary>
        private ObservableCollection<FileViewModel> files = 
            new ObservableCollection<FileViewModel>();

        /// <summary>
        /// Gets or sets the components.
        /// </summary>
        /// <value>
        /// The components.
        /// </value>
        public ObservableCollection<FileViewModel> Files
        {
            get;
            set;
        }
    }
}
