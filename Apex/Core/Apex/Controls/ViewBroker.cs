using System;
using System.Windows.Controls;
using System.Windows;
using Apex.MVVM;

namespace Apex.Controls
{
    /// <summary>
    /// A ViewBroker takes a ViewModel and shows the appropriate View.
    /// </summary>
    public class ViewBroker : ContentControl
    {
        /// <summary>
        /// When overridden in a derived class, is invoked whenever application code or internal processes 
        /// call <see cref="M:System.Windows.FrameworkElement.ApplyTemplate"/>.
        /// </summary>
        public override void OnApplyTemplate()
        {
            //  Call the base.
            base.OnApplyTemplate();

            //  If we have no view model selected, we're done.
            if(this.ViewModel == null)
            {
                return;
            }

            //  Get a view for the view model.
            var view = this.GetViewForViewModel(this.ViewModel);

            //  Activate it.
            this.ActivateView(view);
        }

        /// <summary>
        /// The DependencyProperty for the BrokerHint property.
        /// </summary>
        private static readonly DependencyProperty BrokerHintProperty =
          DependencyProperty.Register("BrokerHint", typeof(string), typeof(ViewBroker),
          new PropertyMetadata(null));

        /// <summary>
        /// Gets or sets BrokerHint.
        /// </summary>
        /// <value>The value of BrokerHint.</value>
        public string BrokerHint
        {
            get => (string)this.GetValue(BrokerHintProperty);
            set => this.SetValue(BrokerHintProperty, value);
        }

        
        /// <summary>
        /// The DependencyProperty for the AllowUnknownViewModels property.
        /// </summary>
        public static readonly DependencyProperty AllowUnknownViewModelsProperty =
          DependencyProperty.Register("AllowUnknownViewModels", typeof(bool), typeof(ViewBroker),
          new PropertyMetadata(default(bool)));

        /// <summary>
        /// Gets or sets AllowUnknownViewModels.
        /// </summary>
        /// <value>The value of AllowUnknownViewModels.</value>
        public bool AllowUnknownViewModels
        {
            get => (bool)this.GetValue(AllowUnknownViewModelsProperty);
            set => this.SetValue(AllowUnknownViewModelsProperty, value);
        }

        /// <summary>   
        /// The DependencyProperty for the ViewModel property.
        /// </summary>
        private static readonly DependencyProperty ViewModelProperty =
          DependencyProperty.Register("ViewModel", typeof(object), typeof(ViewBroker),
          new PropertyMetadata(null, OnViewModelChanged));

        /// <summary>
        /// Gets or sets ViewModel.
        /// </summary>
        /// <value>The value of ViewModel.</value>
        public object ViewModel
        {
            get => this.GetValue(ViewModelProperty);
            set => this.SetValue(ViewModelProperty, value);
        }

        /// <summary>
        /// Called when ViewBroker changes.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="args">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnViewModelChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            var me = o as ViewBroker;
            
            //  If the viewmodel is null, show the default content.
            if (me.ViewModel == null)
            {
                me.ActivateView(null);
                return;
            }

            //  Get the appropriate view and activate it.
            var view = me.GetViewForViewModel(me.ViewModel);
            me.ActivateView(view);
        }

        /// <summary>
        /// Activates the view.
        /// </summary>
        /// <param name="view">The view.</param>
        private void ActivateView(object view)
        {
            //  Before we set the view as the content, if the current content is a view,
            //  we can deactivate it.
            if(this.Content is IView view1)
            {
                ((IView)this.Content).OnDeactivated();
            }

            //  Set the view as the content.
            this.Content = view;

            //  If the view instance implements IView, we can activate it.
            if (view is IView view2)
            {
                view2.OnActivated();
            }
        }

        /// <summary>
        /// Gets a view instance for a view model.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <returns>An instance of the associated view.</returns>
        private object GetViewForViewModel(object viewModel)
        {
            //  Get the type of the view, given the broker hint.
            var viewType = ApexBroker.GetViewForViewModel(viewModel.GetType(), this.BrokerHint);

            //  If we don't have a type, we must throw an exception, unless we allow this.
            if (viewType == null && this.AllowUnknownViewModels)
            {
                return null;
            }
            else if(viewType == null)
            {
                throw new InvalidOperationException("Cannot broker a view for the view model type " + viewModel.GetType().Name);
            }

            //  We have the view type, now we must create an instance of it.
            //  TODO: This is where we must take the re-use options into account.
            object viewInstance = Activator.CreateInstance(viewType);

            //  It must be a dependency object and framework element.
            if (viewInstance is FrameworkElement == false)
            {
                throw new InvalidOperationException("A View must be a FrameworkElement");
            }

            //  Set the data context.
            ((FrameworkElement) viewInstance).DataContext = viewModel;

            //  Return the view instance.
            return viewInstance;
        }
    }
}
