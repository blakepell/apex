﻿using System.Linq;
using System.Windows.Controls;
using System.Windows;
using Apex.MVVM;

namespace Apex.Controls
{
    /// <summary>
    /// An ISelectableItem will automatically have its OnSelected/OnDeselected
    /// functions called and its IsSelected property set if the items are used
    /// in a SelectableItemsControl.
    /// </summary>
    public interface ISelectableItem
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is selected.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is selected; otherwise, <c>false</c>.
        /// </value>
        bool IsSelected { get; set; }
    }

    public class SelectableItemsControlItem : ContentControl
    {
        /// <summary>
        /// The DependencyProperty for the IsSelected property.
        /// </summary>
        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register("IsSelected", typeof(bool), typeof(SelectableItemsControlItem),
                new PropertyMetadata(default(bool), OnIsSelectedChanged));

        /// <summary>
        /// Gets or sets IsSelected.
        /// </summary>
        /// <value>The value of IsSelected.</value>
        public bool IsSelected
        {
            get => (bool)this.GetValue(IsSelectedProperty);
            set => this.SetValue(IsSelectedProperty, value);
        }

        /// <summary>
        /// Called when IsSelected is changed.
        /// </summary>
        /// <param name="o">The dependency object.</param>
        /// <param name="args">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnIsSelectedChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            //var me = o as SelectableItemsControlItem;
        }
    }

    /// <summary>
    /// A SelectableItemsControl is a standard ItemsControl that
    /// can flag an item as selected.
    /// TODO: Should this be limited to ISelectableItem items? 
    /// With ISelectable.IsSelected, ISelectable.Activate, ISelectable.Deactivate?
    /// </summary>
    public class SelectableItemsControl : Consistency.ItemsControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SelectableItemsControl"/> class.
        /// </summary>
        public SelectableItemsControl()
        {
            //  Wire up commands.
            this.SelectItemCommand = new Command(this.DoSelectItemCommand);
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return (item is SelectableItemsControlItem);
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new SelectableItemsControlItem();
        }

        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            base.PrepareContainerForItemOverride(element, item);
            ((SelectableItemsControlItem)element).ContentTemplate = this.ItemTemplate;
            ((SelectableItemsControlItem)element).Content = item;

            if (this.ClickToSelectItem && item is ISelectableItem)
            {
                ((SelectableItemsControlItem)element).MouseLeftButtonDown +=
                    (sender, args) => this.DoSelectItemCommand(item);
            }
        }

        /// <summary>
        /// When overridden in a derived class, is invoked whenever application code or internal processes call <see cref="M:System.Windows.FrameworkElement.ApplyTemplate"/>.
        /// </summary>
        public override void OnApplyTemplate()
        {
            //  Call the base.
            base.OnApplyTemplate();

            //  Set the Selected state of the items.
            this.SetItemsSelectedState();

            //  The template has now been applied.
            isTemplateApplied = true;
        }

        /// <summary>
        /// Sets the selected state of the items correctly.
        /// </summary>
        private void SetItemsSelectedState()
        {
            //  If we have no items, we cannot set their state.
            if (this.ItemsSource == null)
            {
                return;
            }

            //  Go through every item.
            foreach (var item in this.ItemsSource)
            {
                //  If the item is selectable, we can set it's selectable state.
                var selectableItem = item as ISelectableItem;
                if (selectableItem != null)
                {
                    selectableItem.IsSelected = selectableItem == this.SelectedItem;
                }

                //  If the item has a selectable items control item container, we can set the selectable state.
                if (this.ItemContainerGenerator.ContainerFromItem(item) is SelectableItemsControlItem itemContainer)
                {
                    itemContainer.IsSelected = selectableItem == this.SelectedItem;
                }
            }
        }

        /// <summary>
        /// The DependencyProperty for the SelectedItem property.
        /// </summary>
        private static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(object), typeof(SelectableItemsControl),
                new FrameworkPropertyMetadata(default(object),
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, SelectedItemChanged));

        /// <summary>
        /// Called when the selected item is changed.
        /// </summary>
        /// <param name="d">The dependency object.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void SelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //  Get the control, call the OnChanged function.
            var selectableItemsControl = (SelectableItemsControl)d;
            selectableItemsControl.OnSelectedItemChanged(e.OldValue, e.NewValue);
        }

        /// <summary>
        /// Called when the selected item is changed.
        /// </summary>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        protected virtual void OnSelectedItemChanged(object oldValue, object newValue)
        {
            //  We don't need to set state if we have no template.
            if (!isTemplateApplied)
            {
                return;
            }

            //  Set the Selected state of the items.
            this.SetItemsSelectedState();
        }

        /// <summary>
        /// Gets or sets SelectedItem.
        /// </summary>
        /// <value>The value of SelectedItem.</value>
        public object SelectedItem
        {
            get => this.GetValue(SelectedItemProperty);
            set => this.SetValue(SelectedItemProperty, value);
        }

        /// <summary>
        /// Performs the SelectItem command.
        /// </summary>
        /// <param name="itemToSelect">The item to select.</param>
        private void DoSelectItemCommand(object itemToSelect)
        {
            this.SelectedItem = itemToSelect;
        }

        private SelectableItemsControlItem GetItemContainerFromItem(object item)
        {
            return this.Items.OfType<SelectableItemsControlItem>().FirstOrDefault(sici => sici.Content == item);
        }

        /// <summary>
        /// A flag that is set if the template has been applied.
        /// </summary>
        private bool isTemplateApplied;

        /// <summary>
        /// Gets the SelectItem command.
        /// </summary>
        /// <value>The SelectItem command.</value>
        public Command SelectItemCommand { get; private set; }

        /// <summary>
        /// The DependencyProperty for the ClickToSelectItem property.
        /// </summary>
        public static readonly DependencyProperty ClickToSelectItemProperty =
            DependencyProperty.Register("ClickToSelectItem", typeof(bool), typeof(SelectableItemsControl),
                new PropertyMetadata(default(bool)));

        /// <summary>
        /// Gets or sets ClickToSelectItem.
        /// </summary>
        /// <value>The value of ClickToSelectItem.</value>
        public bool ClickToSelectItem
        {
            get => (bool)this.GetValue(ClickToSelectItemProperty);
            set => this.SetValue(ClickToSelectItemProperty, value);
        }
    }
}