﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Apex.Controls
{
    /// <summary>
    /// The image button is a button that shows an image which is changed for mouseover.
    /// </summary>
    public class ImageButton : Button
    {
        /// <summary>
        /// Initializes the <see cref="ImageButton"/> class.
        /// </summary>
        static ImageButton()
        {
            //  Override the default style. 
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageButton),
                new FrameworkPropertyMetadata(typeof(ImageButton)));
        }

        /// <summary>
        /// When overridden in a derived class, is invoked whenever application code or internal processes call <see cref="M:System.Windows.FrameworkElement.ApplyTemplate" />.
        /// </summary>
        public override void OnApplyTemplate()
        {
            //  Call the base.
            base.OnApplyTemplate();

            //  If we're missing any images, use the normal one.
            if (this.MouseOverImageSource == null)
            {
                this.MouseOverImageSource = this.NormalImageSource;
            }

            if (this.PressedImageSource == null)
            {
                this.PressedImageSource = this.NormalImageSource;
            }

            if (this.DisabledImageSource == null)
            {
                this.DisabledImageSource = this.NormalImageSource;
            }
        }

        /// <summary>
        /// The DependencyProperty for the NormalImageSource property.
        /// </summary>
        public static readonly DependencyProperty NormalImageSourceProperty =
            DependencyProperty.Register("NormalImageSource", typeof(ImageSource), typeof(ImageButton),
                new PropertyMetadata(default(ImageSource)));

        /// <summary>
        /// Gets or sets NormalImageSource.
        /// </summary>
        /// <value>The value of NormalImageSource.</value>
        public ImageSource NormalImageSource
        {
            get => (ImageSource)this.GetValue(NormalImageSourceProperty);
            set => this.SetValue(NormalImageSourceProperty, value);
        }


        /// <summary>
        /// The DependencyProperty for the MouseOverImageSource property.
        /// </summary>
        public static readonly DependencyProperty MouseOverImageSourceProperty =
            DependencyProperty.Register("MouseOverImageSource", typeof(ImageSource), typeof(ImageButton),
                new PropertyMetadata(default(ImageSource)));

        /// <summary>
        /// Gets or sets MouseOverImageSource.
        /// </summary>
        /// <value>The value of MouseOverImageSource.</value>
        public ImageSource MouseOverImageSource
        {
            get => (ImageSource)this.GetValue(MouseOverImageSourceProperty);
            set => this.SetValue(MouseOverImageSourceProperty, value);
        }

        /// <summary>
        /// The DependencyProperty for the PressedImageSource property.
        /// </summary>
        public static readonly DependencyProperty PressedImageSourceProperty =
            DependencyProperty.Register("PressedImageSource", typeof(ImageSource), typeof(ImageButton),
                new PropertyMetadata(default(ImageSource)));

        /// <summary>
        /// Gets or sets PressedImageSource.
        /// </summary>
        /// <value>The value of PressedImageSource.</value>
        public ImageSource PressedImageSource
        {
            get => (ImageSource)this.GetValue(PressedImageSourceProperty);
            set => this.SetValue(PressedImageSourceProperty, value);
        }

        /// <summary>
        /// The DependencyProperty for the DisabledImageSource property.
        /// </summary>
        public static readonly DependencyProperty DisabledImageSourceProperty =
            DependencyProperty.Register("DisabledImageSource", typeof(ImageSource), typeof(ImageButton),
                new PropertyMetadata(default(ImageSource)));

        /// <summary>
        /// Gets or sets DisabledImageSource.
        /// </summary>
        /// <value>The value of DisabledImageSource.</value>
        public ImageSource DisabledImageSource
        {
            get => (ImageSource)this.GetValue(DisabledImageSourceProperty);
            set => this.SetValue(DisabledImageSourceProperty, value);
        }
    }
}