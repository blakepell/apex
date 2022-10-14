using System.Windows.Controls;
using System.Windows;

namespace Apex.Controls
{
    /// <summary>
    /// Scrollviewer with basic animation capabilities.
    /// </summary>
    public class AnimatedScrollViewer : ScrollViewer
    {
        /// <summary>
        /// Current Vertical Offset dependency property.
        /// </summary>
        public static DependencyProperty CurrentVerticalOffsetProperty =
            DependencyProperty.Register("CurrentVerticalOffset", typeof(double), typeof(AnimatedScrollViewer),
                new PropertyMetadata(OnVerticalChanged));

        /// <summary>
        /// Current horizontal offset dependency property.
        /// </summary>
        public static DependencyProperty CurrentHorizontalOffsetProperty =
            DependencyProperty.Register("CurrentHorizontalOffsetOffset", typeof(double), typeof(AnimatedScrollViewer),
                new PropertyMetadata(OnHorizontalChanged));

        /// <summary>
        /// Called when vertical changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnVerticalChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var viewer = (AnimatedScrollViewer)d;
            viewer.ScrollToVerticalOffset((double)e.NewValue);
        }

        /// <summary>
        /// Called when horizontal changed.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnHorizontalChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var viewer = (AnimatedScrollViewer)d;
            viewer.ScrollToHorizontalOffset((double)e.NewValue);
        }

        /// <summary>
        /// Gets or sets the current horizontal offset.
        /// </summary>
        /// <value>
        /// The current horizontal offset.
        /// </value>
        public double CurrentHorizontalOffset
        {
            get => (double)this.GetValue(CurrentHorizontalOffsetProperty);
            set => this.SetValue(CurrentHorizontalOffsetProperty, value);
        }

        /// <summary>
        /// Gets or sets the current vertical offset.
        /// </summary>
        /// <value>
        /// The current vertical offset.
        /// </value>
        public double CurrentVerticalOffset
        {
            get => (double)this.GetValue(CurrentVerticalOffsetProperty);
            set => this.SetValue(CurrentVerticalOffsetProperty, value);
        }
    }
}