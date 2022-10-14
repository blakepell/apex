using System;
using System.Windows.Controls;
using System.Windows;

namespace Apex.Controls
{
    /// <summary>
    /// The CueDisplayMode enumeration allows the behaviour of a CueTextBox's cue's
    /// visibilty to be controlled.
    /// </summary>
    public enum CueDisplayMode
    {
        /// <summary>
        /// Hide the cue when the CueTextBox has text.
        /// </summary>
        HideWhenHasText,

        /// <summary>
        /// Hide the cue when the CueTextBox has text or is focussed.
        /// </summary>
        HideWhenHasTextOrFocus
    }

    /// <summary>
    /// The CueTextBox is a standard TextBox control that can show a 'cue' or 'hint'. The cue is a faint
    /// label in the text box area that instructs the user on what they should enter in the text box.
    /// The cue can be set via the CueText property.
    /// </summary>
    [TemplatePart(Name = "PART_CueLabel", Type = typeof(TextBlock))]
    public class CueTextBox : TextBox
    {
        /// <summary>
        /// Initializes the <see cref="CueTextBox"/> class.
        /// </summary>
        static CueTextBox()
        {
            //  Override the default style. 
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CueTextBox),
                new FrameworkPropertyMetadata(typeof(CueTextBox)));
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.UIElement.LostFocus"/> event (using the provided arguments).
        /// </summary>
        /// <param name="e">Provides data about the event.</param>
        protected override void OnLostFocus(RoutedEventArgs e)
        {
            //  Call the base.
            base.OnLostFocus(e);

            //  Update the cue visibilty.
            this.UpdateCueVisiblity();
        }

        /// <summary>
        /// Invoked whenever an unhandled <see cref="E:System.Windows.UIElement.GotFocus"/> event reaches this element in its route.
        /// </summary>
        /// <param name="e">The <see cref="T:System.Windows.RoutedEventArgs"/> that contains the event data.</param>
        protected override void OnGotFocus(RoutedEventArgs e)
        {
            //  Call the base.
            base.OnGotFocus(e);

            //  Update the cue visibilty.
            this.UpdateCueVisiblity();
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
                //  Get the cue labe.
                cueLabel = (TextBlock)this.GetTemplateChild("PART_CueLabel");
            }
            catch
            {
                throw new Exception("Unable to access the internal elements of the CueTextBox.");
            }

            //  Initial visibility.
            this.UpdateCueVisiblity();
        }

        /// <summary>
        /// Is called when content in this editing control changes.
        /// </summary>
        /// <param name="e">The arguments that are associated with the <see cref="E:System.Windows.Controls.Primitives.TextBoxBase.TextChanged"/> event.</param>
        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);

            //  Update the cue visibilty.
            this.UpdateCueVisiblity();
        }

        /// <summary>
        /// Updates the cue visiblity.
        /// </summary>
        private void UpdateCueVisiblity()
        {
            //  If we don't have the cue label we can skip.
            if (cueLabel == null)
            {
                return;
            }

            //  We set the cue visibilty based on the cue display mode.
            switch (this.CueDisplayMode)
            {
                case CueDisplayMode.HideWhenHasTextOrFocus:
                    cueLabel.Visibility = (this.IsFocused || !string.IsNullOrEmpty(this.Text))
                        ? Visibility.Collapsed
                        : Visibility.Visible;
                    break;
                case CueDisplayMode.HideWhenHasText:
                    cueLabel.Visibility = string.IsNullOrEmpty(this.Text) ? Visibility.Visible : Visibility.Collapsed;
                    break;
            }
        }

        /// <summary>
        /// The cue label.
        /// </summary>
        private TextBlock cueLabel;

        /// <summary>
        /// The DependencyProperty for the CueText property.
        /// </summary>
        public static readonly DependencyProperty CueTextProperty =
            DependencyProperty.Register("CueText", typeof(string), typeof(CueTextBox),
                new PropertyMetadata(default(string)));

        /// <summary>
        /// Gets or sets CueText.
        /// </summary>
        /// <value>The value of CueText.</value>
        public string CueText
        {
            get => (string)this.GetValue(CueTextProperty);
            set => this.SetValue(CueTextProperty, value);
        }

        /// <summary>
        /// The DependencyProperty for the CueDisplayMode property.
        /// </summary>
        public static readonly DependencyProperty CueDisplayModeProperty =
            DependencyProperty.Register("CueDisplayMode", typeof(CueDisplayMode), typeof(CueTextBox),
                new PropertyMetadata(CueDisplayMode.HideWhenHasTextOrFocus, OnCueDisplayModeChanged));

        /// <summary>
        /// Gets or sets CueDisplayMode.
        /// </summary>
        /// <value>The value of CueDisplayMode.</value>
        public CueDisplayMode CueDisplayMode
        {
            get => (CueDisplayMode)this.GetValue(CueDisplayModeProperty);
            set => this.SetValue(CueDisplayModeProperty, value);
        }

        /// <summary>
        /// Called when cue display mode changed.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="args">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnCueDisplayModeChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            var cueTextBox = (CueTextBox)o;
            cueTextBox.UpdateCueVisiblity();
        }
    }
}