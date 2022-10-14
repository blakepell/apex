using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Apex.Controls
{
    /// <summary>
    /// Provides a circular progress bar
    /// </summary>
    public partial class CircularProgressBar : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CircularProgressBar"/> class.
        /// </summary>
        public CircularProgressBar()
        {
            this.InitializeComponent();

            animationTimer = new DispatcherTimer(
                DispatcherPriority.ContextIdle, this.Dispatcher)
            {
                Interval = new TimeSpan(0, 0, 0, 0, 75)
            };
        }

        private readonly DispatcherTimer animationTimer;

        private void Start()
        {
            animationTimer.Tick += this.HandleAnimationTick;
            animationTimer.Start();
        }

        private void Stop()
        {
            animationTimer.Stop();
            animationTimer.Tick -= this.HandleAnimationTick;
        }

        private void HandleAnimationTick(object sender, EventArgs e)
        {
            SpinnerRotate.Angle = (SpinnerRotate.Angle + 36)%360;
        }

        private void HandleLoaded(object sender, RoutedEventArgs e)
        {
            const double offset = Math.PI;
            const double step = Math.PI*2/10.0;

            this.SetPosition(C0, offset, 0.0, step);
            this.SetPosition(C1, offset, 1.0, step);
            this.SetPosition(C2, offset, 2.0, step);
            this.SetPosition(C3, offset, 3.0, step);
            this.SetPosition(C4, offset, 4.0, step);
            this.SetPosition(C5, offset, 5.0, step);
            this.SetPosition(C6, offset, 6.0, step);
            this.SetPosition(C7, offset, 7.0, step);
            this.SetPosition(C8, offset, 8.0, step);
        }

        private void SetPosition(Ellipse ellipse, double offset,
                                 double posOffSet, double step)
        {
            ellipse.SetValue(Canvas.LeftProperty, 50.0
                                                  + Math.Sin(offset + posOffSet*step)*50.0);

            ellipse.SetValue(Canvas.TopProperty, 50
                                                 + Math.Cos(offset + posOffSet*step)*50.0);
        }

        private void HandleUnloaded(object sender, RoutedEventArgs e)
        {
            this.Stop();
        }

        private void HandleVisibleChanged(object sender,
                                          DependencyPropertyChangedEventArgs e)
        {
            bool isVisible = (bool) e.NewValue;

            if (isVisible)
            {
                this.Start();
            }
            else
            {
                this.Stop();
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
        }

        /// <summary>
        /// The progress text property.
        /// </summary>
        public static DependencyProperty ProgressTextProperty = DependencyProperty.Register("ProgressText", typeof (string), typeof (CircularProgressBar));

        /// <summary>
        /// Gets or sets the progress text.
        /// </summary>
        /// <value>
        /// The progress text.
        /// </value>
        public string ProgressText
        {
            get => (string)this.GetValue(ProgressTextProperty);
            set => this.SetValue(ProgressTextProperty, value);
        }
    }
}