using Apex.Extensions;
using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Apex.Behaviours
{
    /// <summary>
    /// The Slide Fade In behaviour does an MS Zune style slide and fade in.
    /// </summary>
    public class SlideFadeInBehaviour : Behavior<UIElement>
    {
        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();

            //  TODO: In the designer this makes the element invisible, another way?
            this.AssociatedObject.Opacity = 0;
        }

        /// <summary>
        /// Performs the slide fade in of all elements contained in 'container'
        /// that have the SlideFadeInBehaviour.
        /// </summary>
        /// <param name="container">The container.</param>
        public static void DoSlideFadeIn(FrameworkElement container)
        {
            //  We're going to fill a list with slide fade in behaviours.
            var slideFadeInBehaviours = new List<SlideFadeInBehaviour>();

            //  Get all children.
            var children = container.GetLogicalChildren<UIElement>();

            //  Go through each child, add all slide fade in behaviours.
            foreach (var child in children)
            {
                //  Do we have an slide fade in behaviours?
                slideFadeInBehaviours.AddRange(
                    from b in Interaction.GetBehaviors(child)
                    where b is SlideFadeInBehaviour
                    select b as SlideFadeInBehaviour);
            }

            //  Create the animation for each fade in.
            var animations = slideFadeInBehaviours.SelectMany(s => s.CreateAnimations());

            //  Create a storyboard, add the animations.
            var storyboard = new Storyboard();
            foreach (var animation in animations)
            {
                storyboard.Children.Add(animation);
            }

            //  Start the storyboard.
#if !SILVERLIGHT
            storyboard.Begin(container);
#else
            storyboard.Begin();
#endif
        }

        /// <summary>
        /// Creates the animations required to slide fade in this element.
        /// </summary>
        /// <returns>Required animations.</returns>
        private IEnumerable<Timeline> CreateAnimations()
        {
            //  Create and set the translation.
            var translation = new TranslateTransform() { X = -SlideDistance, Y = 0 };
            this.AssociatedObject.RenderTransform = translation;

            //  Create an animation for the opacity.
            var opacityAnimation = new DoubleAnimation() { From = 0, To = 1, Duration = this.Duration, BeginTime = this.BeginTime };

            //  Create an animation for the slide in.
            var slideInAnimation = new DoubleAnimation
            {
                To = 0,
                Duration = this.Duration,
                BeginTime = this.BeginTime,
                EasingFunction = new CubicEase() { EasingMode = EasingMode.EaseOut }
            };

            //  Set the targets for the animations.
            Storyboard.SetTarget(opacityAnimation, this.AssociatedObject);
            Storyboard.SetTarget(slideInAnimation, this.AssociatedObject);
            Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath(UIElement.OpacityProperty));
            Storyboard.SetTargetProperty(slideInAnimation, new PropertyPath("(UIElement.RenderTransform).(TranslateTransform.X)"));

            //  Return the animations.
            return new List<Timeline> { opacityAnimation, slideInAnimation };
        }

        private const double SlideDistance = 40.0;

        /// <summary>
        /// The Duration Dependency property.
        /// </summary>
        public static readonly DependencyProperty DurationProperty =
            DependencyProperty.Register("Duration", typeof(Duration), typeof(SlideFadeInBehaviour),
            new PropertyMetadata(new Duration(TimeSpan.FromMilliseconds(750))));

        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        /// <value>
        /// The duration.
        /// </value>
        public Duration Duration
        {
            get => (Duration)this.GetValue(DurationProperty);
            set => this.SetValue(DurationProperty, value);
        }

        /// <summary>
        /// The DependencyProperty for the BeginTime property.
        /// </summary>
        private static readonly DependencyProperty BeginTimeProperty =
          DependencyProperty.Register("BeginTime", typeof(TimeSpan), typeof(SlideFadeInBehaviour),
          new PropertyMetadata(TimeSpan.FromMilliseconds(0)));

        /// <summary>
        /// Gets or sets BeginTime.
        /// </summary>
        /// <value>The value of BeginTime.</value>
        public TimeSpan BeginTime
        {
            get => (TimeSpan)this.GetValue(BeginTimeProperty);
            set => this.SetValue(BeginTimeProperty, value);
        }
    }
}
