using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media.Animation;
using System.Collections.ObjectModel;
using Apex.MVVM;

namespace Apex.Controls
{
    /// <summary>
    /// Interaction logic for PivotControl.xaml
    /// </summary>
    [TemplatePart(Name = "PART_ItemsControl", Type = typeof(ItemsControl))]
    [TemplatePart(Name = "PART_PivotScrollViewer", Type = typeof(AnimatedScrollViewer))]
    [ContentProperty("PivotItems")]
    public partial class PivotControl : ContentControl
    {
#if !SILVERLIGHT
        /// <summary>
        /// Initializes the <see cref="PivotControl"/> class.
        /// </summary>
        static PivotControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PivotControl),
                new FrameworkPropertyMetadata(typeof(PivotControl)));
        }
#else
    /// <summary>
    /// Initializes the <see cref="PivotControl"/> class.
    /// </summary>
        public PivotControl()
        {
            this.DefaultStyleKey = typeof(DragAndDropHost);
        }
#endif

        /// <summary>
        /// When overridden in a derived class, is invoked whenever application code or internal processes call <see cref="M:System.Windows.FrameworkElement.ApplyTemplate"/>.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            try
            {
                itemsControl = (ItemsControl)this.GetTemplateChild("PART_ItemsControl");
                pivotScrollViewer = (AnimatedScrollViewer)this.GetTemplateChild("PART_PivotScrollViewer");
            }
            catch
            {
                throw new Exception("Unable to access the internal elements of the Pivot control.");
            }

            selectPivotItemCommand = new Command(this.SelectPivotItem, true);

            this.SizeChanged += this.PivotControl_SizeChanged;

            this.Loaded += this.PivotControl_Loaded;
        }

        private void PivotControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.SelectedPivotItem == null && this.PivotItems.Count > 0)
            {
                foreach (var pivotItem in this.PivotItems)
                {
                    if (pivotItem.IsInitialPage)
                    {
                        this.SelectedPivotItem = pivotItem;
                        break;
                    }
                }

                if (this.SelectedPivotItem == null)
                {
                    this.SelectedPivotItem = this.PivotItems[0];
                }
            }
        }

        private ItemsControl itemsControl;
        private AnimatedScrollViewer pivotScrollViewer;

        private void PivotControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            //  Go through each pivot item and set the size.
            foreach (var pivotItem in this.PivotItems)
            {
                if (pivotItem.Content is FrameworkElement frameworkElement)
                {
                    frameworkElement.Width = pivotScrollViewer.ActualWidth;
                    frameworkElement.Height = pivotScrollViewer.ActualHeight;
                }
            }

            this.UpdatePositioning(true);
        }

        /// <summary>
        /// Selects the pivot item.
        /// </summary>
        /// <param name="pivotItem">The pivot item.</param>
        public void SelectPivotItem(object pivotItem)
        {
            //  Deselect all items.
            foreach (var pitem in this.PivotItems)
            {
                pitem.IsSelected = false;
            }

            var item = pivotItem as PivotItem;
            if (item != null)
            {
                item.IsSelected = true;
            }

            this.SelectedPivotItem = item;
        }

        /// <summary>
        /// PivotItems dependency property.
        /// </summary>
        public static readonly DependencyProperty PivotItemsProperty = DependencyProperty.Register("PivotItems",
            typeof(ObservableCollection<PivotItem>), typeof(PivotControl),
            new PropertyMetadata(new ObservableCollection<PivotItem>()));

        /// <summary>
        /// SelectedPivotItem dependency property.
        /// </summary>
        public static readonly DependencyProperty SelectedPivotItemProperty = DependencyProperty.Register(
            "SelectedPivotItem",
            typeof(PivotItem), typeof(PivotControl), new PropertyMetadata(null, OnSelectedPivotItemChanged));

        private Command selectPivotItemCommand = null;


        /// <summary>
        /// Gets or sets the pivot items.
        /// </summary>
        /// <value>
        /// The pivot items.
        /// </value>
        public ObservableCollection<PivotItem> PivotItems
        {
            get => this.GetValue(PivotItemsProperty) as ObservableCollection<PivotItem>;
            set => this.SetValue(PivotItemsProperty, value);
        }


        /// <summary>
        /// Gets or sets the selected pivot item.
        /// </summary>
        /// <value>
        /// The selected pivot item.
        /// </value>
        public PivotItem SelectedPivotItem
        {
            get => this.GetValue(SelectedPivotItemProperty) as PivotItem;
            set => this.SetValue(SelectedPivotItemProperty, value);
        }

        /// <summary>
        /// Gets the select pivot item command.
        /// </summary>
        public ICommand SelectPivotItemCommand => selectPivotItemCommand;

        /// <summary>
        /// Called when [selected pivot item changed].
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        public static void OnSelectedPivotItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //  Get the pivot control and pivot item.

            //  Continue only if we have non-null objects.
            if (!(d is PivotControl me) || !(e.NewValue is PivotItem item))
            {
                return;
            }

            me.PivotControl_SizeChanged(me, null);
            me.UpdatePositioning(e.OldValue == null ? true : false);
        }

        private void UpdatePositioning(bool immediate)
        {
            if (this.SelectedPivotItem == null || this.SelectedPivotItem.Content is FrameworkElement == false)
            {
                return;
            }

            //  Get the pivot content.
            var pivotContent = ((FrameworkElement)this.SelectedPivotItem.Content);

            itemsControl.UpdateLayout();
            var relativePoint = pivotContent.TransformToAncestor(this).Transform(new Point(0, 0));

            //  We'll actually move the item to the centre of the screen.
            relativePoint.X += (pivotContent.ActualWidth / 2) - (this.ActualWidth / 2);

            var horzAnim = new DoubleAnimation
            {
                From = pivotScrollViewer.HorizontalOffset,
                To = pivotScrollViewer.HorizontalOffset + relativePoint.X,
                DecelerationRatio = .8,
                Duration = new Duration(TimeSpan.FromMilliseconds(immediate ? 0 : 300))
            };

            var sb = new Storyboard();
            sb.Children.Add(horzAnim);

            Storyboard.SetTarget(horzAnim, pivotScrollViewer);
            Storyboard.SetTargetProperty(horzAnim,
                new PropertyPath(AnimatedScrollViewer.CurrentHorizontalOffsetProperty));

            sb.Begin();
        }


        private static readonly DependencyProperty ShowPivotHeadingsProperty =
            DependencyProperty.Register("ShowPivotHeadings", typeof(bool), typeof(PivotControl),
                new PropertyMetadata(true));

        /// <summary>
        /// Gets or sets a value indicating whether [show pivot headings].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show pivot headings]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowPivotHeadings
        {
            get => (bool)this.GetValue(ShowPivotHeadingsProperty);
            set => this.SetValue(ShowPivotHeadingsProperty, value);
        }
    }
}