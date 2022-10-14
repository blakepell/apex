using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;

namespace Apex.Controls
{
    //  TODO IList for the documents.

    [TemplatePart(Name = "PART_DocumentsTabControl", Type = typeof(TabControl))]
    [TemplatePart(Name = "PART_ContentControl", Type = typeof(ContentControl))]
    public class TabbedDocumentInterface : ContentControl
    {
        /// <summary>
        /// Initializes the <see cref="CueTextBox"/> class.
        /// </summary>
        static TabbedDocumentInterface()
        {
            //  Override the default style. 
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TabbedDocumentInterface),
                new FrameworkPropertyMetadata(typeof(TabbedDocumentInterface)));
        }

        /// <summary>
        /// Is called when a control template is applied.
        /// </summary>
        public override void OnApplyTemplate()
        {
            //  Call the base.
            base.OnApplyTemplate();

            try
            {
                documentsTabControl = (TabControl)this.GetTemplateChild("PART_DocumentsTabControl");
                contentControl = (ContentControl)this.GetTemplateChild("PART_ContentControl");
            }
            catch
            {
                throw new Exception("Unable to access the internal elements of the TabbedDocumentInterface.");
            }

            //  If we already have documents, wire up the handler.
            this.WireUpCollectionChangedEventHandler(null, this.Documents);

            //  If we have any documents, add them.
            if (this.Documents != null && this.Documents.Count > 0)
            {
                foreach (var document in this.Documents)
                {
                    this.AddDocumentTab(document);
                }
            }

            //  Update the visiblity of the tabs.
            this.UpdateTabsVisibility();
        }

        private void UpdateTabsVisibility()
        {
            //  The tabs are visbile only if we have documents.
            bool showTabs = this.Documents != null && this.Documents.Count > 0;
            documentsTabControl.Visibility = showTabs ? Visibility.Visible : Visibility.Collapsed;
            contentControl.Visibility = showTabs ? Visibility.Collapsed : Visibility.Visible;
        }

        private void WireUpCollectionChangedEventHandler(object oldValue, object newValue)
        {
            if (oldValue is INotifyCollectionChanged changed)
            {
                changed.CollectionChanged -= this.TabbedDocumentInterface_DocumentsCollectionChanged;
            }

            if (newValue is INotifyCollectionChanged collectionChanged)
            {
                collectionChanged.CollectionChanged -= this.TabbedDocumentInterface_DocumentsCollectionChanged;
                collectionChanged.CollectionChanged += this.TabbedDocumentInterface_DocumentsCollectionChanged;
            }
        }

        private static void OnDocumentsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((TabbedDocumentInterface)d).WireUpCollectionChangedEventHandler(e.OldValue, e.NewValue);
        }

        private void AddDocumentTab(object document)
        {
            //  Create a tab item.
            documentsTabControl.Items.Add(document);
        }

        void TabbedDocumentInterface_DocumentsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var newDocument in e.NewItems)
                    {
                        this.AddDocumentTab(newDocument);
                    }

                    break;
                case NotifyCollectionChangedAction.Remove:
                    break;
                case NotifyCollectionChangedAction.Replace:
                    break;
                case NotifyCollectionChangedAction.Move:
                    break;
                case NotifyCollectionChangedAction.Reset:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            //  Make sure the tabs visbility is correct.
            this.UpdateTabsVisibility();
        }

        public static IList GetDocuments(DependencyObject obj)
        {
            return (IList)obj.GetValue(DocumentsProperty);
        }

        public static void SetDocuments(DependencyObject obj, ObservableCollection<DateTime> value)
        {
            obj.SetValue(DocumentsProperty, value);
        }

        public IList Documents
        {
            get => (IList)this.GetValue(DocumentsProperty);
            set => this.SetValue(DocumentsProperty, value);
        }

        public static readonly DependencyProperty DocumentsProperty =
            DependencyProperty.RegisterAttached("Documents", typeof(IList),
                typeof(TabbedDocumentInterface), new UIPropertyMetadata(null, OnDocumentsChanged));

        private TabControl documentsTabControl;
        private ContentControl contentControl;


        /// <summary>
        /// The DependencyProperty for the TabHeaderTemplate property.
        /// </summary>
        public static readonly DependencyProperty TabHeaderTemplateProperty =
            DependencyProperty.Register("TabHeaderTemplate", typeof(DataTemplate), typeof(TabbedDocumentInterface),
                new PropertyMetadata(default(DataTemplate), OnTabHeaderTemplateChanged));

        /// <summary>
        /// Gets or sets TabHeaderTemplate.
        /// </summary>
        /// <value>The value of TabHeaderTemplate.</value>
        public DataTemplate TabHeaderTemplate
        {
            get => (DataTemplate)this.GetValue(TabHeaderTemplateProperty);
            set => this.SetValue(TabHeaderTemplateProperty, value);
        }

        /// <summary>
        /// Called when TabHeaderTemplate is changed.
        /// </summary>
        /// <param name="o">The dependency object.</param>
        /// <param name="args">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnTabHeaderTemplateChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            var me = o as TabbedDocumentInterface;
        }


        /// <summary>
        /// The DependencyProperty for the TabContentTemplate property.
        /// </summary>
        public static readonly DependencyProperty TabContentTemplateProperty =
            DependencyProperty.Register("TabContentTemplate", typeof(DataTemplate), typeof(TabbedDocumentInterface),
                new PropertyMetadata(default(DataTemplate), OnTabContentTemplateChanged));

        /// <summary>
        /// Gets or sets TabContentTemplate.
        /// </summary>
        /// <value>The value of TabContentTemplate.</value>
        public DataTemplate TabContentTemplate
        {
            get => (DataTemplate)this.GetValue(TabContentTemplateProperty);
            set => this.SetValue(TabContentTemplateProperty, value);
        }

        /// <summary>
        /// Called when TabContentTemplate is changed.
        /// </summary>
        /// <param name="o">The dependency object.</param>
        /// <param name="args">The <see cref="DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnTabContentTemplateChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            var me = o as TabbedDocumentInterface;
        }
    }
}