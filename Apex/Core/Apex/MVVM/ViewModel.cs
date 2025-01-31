﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Threading;
using System;
using System.Xml.Serialization;

namespace Apex.MVVM
{
    /// <summary>
    /// Standard viewmodel class base, simply allows property change notifications to be sent.
    /// </summary>
    public class ViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Raises the property changed event.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        public virtual void NotifyPropertyChanged(string propertyName)
        {
            //  Store the event handler - in case it changes between
            //  the line to check it and the line to fire it.
            var propertyChanged = this.PropertyChanged;

            //  If the event has been subscribed to, fire it.
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Gets all the the notifying properties for the view model.
        /// </summary>
        /// <param name="declaredOnly">if set to <c>true</c> gets the notifying properties for the view model only,
        ///  not properties from superclasses..</param>
        /// <returns>All notifying properties for the view model.</returns>
        public IEnumerable<NotifyingProperty> GetNotifyingProperties(bool declaredOnly = false)
        {
            //  Get my type.
            var myType = this.GetType();

            //  Go through all properties, yield notifying properties.
            var flags = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance;
            if (declaredOnly)
            {
                flags |= BindingFlags.DeclaredOnly;
            }

            //  Return the properties that are notifying properties.
            return from field in myType.GetFields(flags)
                   where
                       field.FieldType == typeof(NotifyingProperty)
                   select field.GetValue(this) as NotifyingProperty;
        }

        /// <summary>
        /// Saves the initial state.
        /// This stores all of the values of the notifying properties.
        /// </summary>
        public void SaveInitialState()
        {
            //  Go through each notifying property.
            foreach (var notifyingProperty in this.GetNotifyingProperties())
            {
                //  Save it's initial state.
                notifyingProperty.SaveInitialState();
            }

            //  At this stage, we can clear the HasChanges flag.
            this.HasChanges = false;
        }

        /// <summary>
        /// Restores the initial state.
        /// This restores all of the values of the notifying properties.
        /// </summary>
        public void RestoreInitialState()
        {
            //  Go through each notifying property.
            foreach (var notifyingProperty in this.GetNotifyingProperties())
            {
                //  Restore it's initial state.
                notifyingProperty.RestoreInitialState();
            }

            //  At this stage, we can clear the HasChanges flag.
            this.HasChanges = false;
        }

        /// <summary>
        /// Resets the has changes flag.
        /// </summary>
        public void ResetHasChangesFlag()
        {
            this.HasChanges = false;
        }

        /// <summary>
        /// Gets the value of a notifying property.
        /// </summary>
        /// <param name="notifyingProperty">The notifying property.</param>
        /// <returns>The value of the notifying property.</returns>
        protected object GetValue(NotifyingProperty notifyingProperty)
        {
            return notifyingProperty.Value;
        }

        /// <summary>
        /// Sets the value of the notifying property.
        /// </summary>
        /// <param name="notifyingProperty">The notifying property.</param>
        /// <param name="value">The value to set.</param>
        protected void SetValue(NotifyingProperty notifyingProperty, object value)
        {
            //  Call SetValue without forcing an update.
            this.SetValue(notifyingProperty, value, false);
        }

        /// <summary>
        /// Sets the value of the notifying property.
        /// </summary>
        /// <param name="notifyingProperty">The notifying property.</param>
        /// <param name="value">The value to set.</param>
        /// <param name="forceUpdate">if set to <c>true</c> NotifyPropertyChanged will be called
        /// regardless of whether the new value is different to the old one.</param>
        protected void SetValue(NotifyingProperty notifyingProperty, object value, bool forceUpdate)
        {
            //  We'll only set the value and notify that it has changed if the
            //  value is different - or if we are forcing an update.
            if (notifyingProperty.Value != value || forceUpdate)
            {
                //  Set the value.
                notifyingProperty.SetValue(value);

                //  Notify that the property has changed.
                this.NotifyPropertyChanged(notifyingProperty.Name);

                //  We have changes.
                this.HasChanges = true;
            }
        }

        /// <summary>
        /// Performs an action on the UI thread.
        /// </summary>
        /// <param name="action">The action.</param>
        protected void OnUI(Action action)
        {
            var dispatcher = Dispatcher.CurrentDispatcher;

            //  Use the dispatcher to invoke the action.
            if (dispatcher.CheckAccess())
            {
                action();
            }
            else
            {
                dispatcher.BeginInvoke(action);
            }
        }

        /// <summary>
        /// A flag used to sow whether a view model has changes.
        /// </summary>
        private bool hasChanges;

        /// <summary>
        /// The property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets or sets a value indicating whether this instance has changes.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance has changes; otherwise, <c>false</c>.
        /// </value>
        [XmlIgnore]
        public bool HasChanges
        {
            get => hasChanges;
            protected set
            {
                if (hasChanges != value)
                {
                    hasChanges = value;
                    this.NotifyPropertyChanged("HasChanges");
                }
            }
        }
    }
}