using System.Windows;
using System.Windows.Controls;
using Apex.MVVM;

namespace Apex.Controls
{

  /// <summary>
  /// The Flip Panel Control. A control that hosts content on the front and back of the panel,
  /// and allows the panel to be flipped - revealing the other side.
  /// </summary>
  public class FlipPanel : Control
  {
    /// <summary>
    /// Initializes the <see cref="FlipPanel"/> class.
    /// </summary>
    static FlipPanel()
    {
      DefaultStyleKeyProperty.OverrideMetadata(typeof(FlipPanel), new FrameworkPropertyMetadata(typeof(FlipPanel)));
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="FlipPanel"/> class.
    /// </summary>
    public FlipPanel()
    {
      //  Keep track of size changed events.
      this.SizeChanged += this.FlipPanel_SizeChanged;

        //  Create the Flip command.
      flipCommand = new Command(this.Flip, true);
    }
      
    /// <summary>
    /// Handles the SizeChanged event of the FlipPanel control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Windows.SizeChangedEventArgs"/> instance containing the event data.</param>
    void FlipPanel_SizeChanged(object sender, SizeChangedEventArgs e)
    {
      //  To make sure that the 3D model is not distorted when we resize, update the aspect ratio.
      this.AspectRatio = this.ActualHeight / this.ActualWidth;
    }

    /// <summary>
    /// Flips this instance.
    /// </summary>
    private void Flip()
    {
        if (this.IsFlipped)
        {
            var args = new RoutedEventArgs(FlippedBackToFrontEvent);
            this.RaiseEvent(args);
            this.IsFlipped = false;
        }
        else
        {
            var args = new RoutedEventArgs(FlippedFrontToBackEvent);
            this.RaiseEvent(args);
            this.IsFlipped = true;
        }
    }

    /// <summary>
    /// The ContentFront dependency property.
    /// </summary>
    public static readonly DependencyProperty ContentFrontProperty = DependencyProperty.Register("ContentFront", typeof(object), typeof(FlipPanel));

    /// <summary>
    /// The ContentBack dependency property.
    /// </summary>
    public static readonly DependencyProperty ContentBackProperty = DependencyProperty.Register("ContentBack", typeof(object), typeof(FlipPanel));

    /// <summary>
    /// The AspectRatio dependency property.
    /// </summary>
    public static readonly DependencyProperty AspectRatioProperty = DependencyProperty.Register("AspectRatio", typeof(double), typeof(FlipPanel), new PropertyMetadata(0.5));

    /// <summary>
    /// The IsFlipped property, true if the panel is flipped.
    /// </summary>
    public static readonly DependencyProperty IsFlippedProperty = DependencyProperty.Register("IsFlipped", typeof(bool), typeof(FlipPanel), new PropertyMetadata(false));
      
    /// <summary>
    /// Occurs when flipped front to back.
    /// </summary>
    public static readonly RoutedEvent FlippedFrontToBackEvent = EventManager.RegisterRoutedEvent("FlippedFrontToBack", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(FlipPanel));

    /// <summary>
    /// Occurs when flipped back to front.
    /// </summary>
      public static readonly RoutedEvent FlippedBackToFrontEvent = EventManager.RegisterRoutedEvent("FlippedBackToFront", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(FlipPanel));

    /// <summary>
    /// The Flip Command.
    /// </summary>
    public Command flipCommand;

    /// <summary>
    /// Gets or sets the front content.
    /// </summary>
    /// <value>The front content.</value>
    public object ContentFront
    {
      get => this.GetValue(ContentFrontProperty);
      set => this.SetValue(ContentFrontProperty, value);
    }

    /// <summary>
    /// Gets or sets the back content.
    /// </summary>
    /// <value>The back content.</value>
    public object ContentBack
    {
      get => this.GetValue(ContentBackProperty);
      set => this.SetValue(ContentBackProperty, value);
    }

    /// <summary>
    /// Gets or sets the aspect ratio.
    /// </summary>
    /// <value>The aspect ratio.</value>
    public double AspectRatio
    {
      get => (float)this.GetValue(AspectRatioProperty);
      set => this.SetValue(AspectRatioProperty, value);
    }

    /// <summary>
    /// Gets or sets a value indicating whether this instance is flipped.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is flipped; otherwise, <c>false</c>.
    /// </value>
    public bool IsFlipped
    {
        get => (bool)this.GetValue(IsFlippedProperty);
        set => this.SetValue(IsFlippedProperty, value);
    }

    /// <summary>
    /// Gets the flip command.
    /// </summary>
    /// <value>The flip command.</value>
    public Command FlipCommand => flipCommand;

    /// <summary>
    /// Occurs when flipped front to back.
    /// </summary>
    public event RoutedEventHandler FlippedFrontToBack
    {
        add => this.AddHandler(FlippedFrontToBackEvent, value);
        remove => this.RemoveHandler(FlippedFrontToBackEvent, value);
    }

    /// <summary>
    /// Occurs when flipped back to fron.
    /// </summary>
    public event RoutedEventHandler FlippedBackToFront
    {
        add => this.AddHandler(FlippedBackToFrontEvent, value);
        remove => this.RemoveHandler(FlippedBackToFrontEvent, value);
    }
  }
}
