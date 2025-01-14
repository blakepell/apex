﻿using System.Collections.ObjectModel;
using Apex.MVVM;

namespace Gallery.MVVM.ViewBrokerActivationSample
{
    /// <summary>
    /// The ViewBrokerSampleViewModel ViewModel class.
    /// </summary>
    [ViewModel]
    public class ViewBrokerActivationSampleViewModel : GalleryItemViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewBrokerActivationSampleViewModel"/> class.
        /// </summary>
        public ViewBrokerActivationSampleViewModel()
        {
            this.Title = "View Broker Activation Sample";

            //  Add the page view models.
            pageViewModels.Add(new Page1ViewModel() { IsSelected = true});
            pageViewModels.Add(new Page2ViewModel());
        }

        private ObservableCollection<ViewModel> pageViewModels = new ObservableCollection<ViewModel>();

        public ObservableCollection<ViewModel> PageViewModels => pageViewModels;

        private readonly  NotifyingProperty selectedPageViewModelProperty = new NotifyingProperty("SelectedPageViewModel", typeof(ViewModel), null);

        public ViewModel SelectedPageViewModel
        {
            get => (ViewModel)this.GetValue(selectedPageViewModelProperty);
            set => this.SetValue(selectedPageViewModelProperty, value);
        }
    }
}
