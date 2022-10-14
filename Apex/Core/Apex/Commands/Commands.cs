using System.Windows;
using System.Windows.Input;


namespace Apex.Commands
{
    /// <summary>
    /// Common Extended Commands.
    /// </summary>
    public static class ExtendedCommands
    {
        //  Context menu operation are NOT available for silverlight.
#if !SILVERLIGHT

        /// <summary>
        /// The ContextMenuDataContext dependency property.
        /// </summary>
        public static readonly DependencyProperty ContextMenuDataContextProperty =
            DependencyProperty.RegisterAttached("ContextMenuDataContext",
                typeof(object), typeof(ExtendedCommands),
                new PropertyMetadata(OnContextMenuDataContextChanged));

        /// <summary>
        /// Gets the context menu data context.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns></returns>
        public static object GetContextMenuDataContext(FrameworkElement obj)
        {
            return obj.GetValue(ContextMenuDataContextProperty);
        }

        /// <summary>
        /// Sets the context menu data context.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <param name="value">The value.</param>
        public static void SetContextMenuDataContext(FrameworkElement obj, object value)
        {
            obj.SetValue(ContextMenuDataContextProperty, value);
        }

        /// <summary>
        /// Called when the context menu data context changed.
        /// </summary>
        /// <param name="d">The dependency object.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnContextMenuDataContextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //  Cast the data.
            if (!(d is FrameworkElement frameworkElement))
            {
                return;
            }

            //  Set the data context of the context menu.
            if (frameworkElement.ContextMenu != null)
            {
                frameworkElement.ContextMenu.DataContext = GetContextMenuDataContext(frameworkElement);
            }
        }

#endif

        /// <summary>
        /// Handles the LeftClickMouseDown event of the Control object.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Input.MouseButtonEventArgs"/> instance containing the event data.</param>
        private static void Control_LeftClickMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount != 1 || e.LeftButton != MouseButtonState.Pressed || !(sender is FrameworkElement element))
            {
                return;
            }

            var command = GetLeftClickCommand(element);
            object param = GetLeftClickCommandParameter(element);
            if (command != null && command.CanExecute(param))
            {
                command.Execute(param);
                e.Handled = true;
            }
        }

        /// <summary>
        /// Handles the RightClickMouseDown event of the Control object.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Input.MouseButtonEventArgs"/> instance containing the event data.</param>
        private static void Control_RightClickMouseDown(object sender, MouseButtonEventArgs e)
        {
            //  Silverlight doesn't give us quite as much help here as WPF does.
#if SILVERLIGHT
            if (MouseClickDetector.IsDoubleClick(sender, e) || element == null /* TODO Ensure it's right button */)
                return;
#else
            if (e.ClickCount != 1 || e.RightButton != MouseButtonState.Pressed || !(sender is FrameworkElement element))
            {
                return;
            }
#endif
            var command = GetRightClickCommand(element);
            object param = GetRightClickCommandParameter(element);
            if (command != null && command.CanExecute(param))
            {
                command.Execute(param);
                e.Handled = true;
            }
        }

        /// <summary>
        /// Handles the LeftDoubleClickMouseDown event of the Control object.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Input.MouseButtonEventArgs"/> instance containing the event data.</param>
        private static void Control_LeftDoubleClickMouseDown(object sender, MouseButtonEventArgs e)
        {
            //  Silverlight doesn't give us quite as much help here as WPF does.
#if SILVERLIGHT
            if (MouseClickDetector.IsDoubleClick(sender, e) == false || element == null /* TODO Ensure it's right button */)
                return;
#else
            if (e.ClickCount != 2 || e.LeftButton != MouseButtonState.Pressed || !(sender is FrameworkElement element))
            {
                return;
            }
#endif

            var command = GetLeftDoubleClickCommand(element);
            object param = GetLeftDoubleClickCommandParameter(element);
            if (command != null && command.CanExecute(param))
            {
                command.Execute(param);
                e.Handled = true;
            }
        }

        /// <summary>
        /// Handles the RightDoubleClickMouseDown event of the Control object.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Input.MouseButtonEventArgs"/> instance containing the event data.</param>
        private static void Control_RightDoubleClickMouseDown(object sender, MouseButtonEventArgs e)
        {
            //  Silverlight doesn't give us quite as much help here as WPF does.
#if SILVERLIGHT
            if (MouseClickDetector.IsDoubleClick(sender, e) == false || element == null /* TODO Ensure it's right button */)
                return;
#else
            if (e.ClickCount != 2 || e.RightButton != MouseButtonState.Pressed || !(sender is FrameworkElement element))
            {
                return;
            }
#endif

            var command = GetRightDoubleClickCommand(element);
            object param = GetRightDoubleClickCommandParameter(element);
            if (command != null && command.CanExecute(param))
            {
                command.Execute(param);
                e.Handled = true;
            }
        }


        /// <summary>
        /// The LeftClickCommand dependency property.
        /// </summary>
        public static readonly DependencyProperty LeftClickCommandProperty =
            DependencyProperty.RegisterAttached("LeftClickCommand", typeof(ICommand),
                typeof(ExtendedCommands), new PropertyMetadata(default(ICommand),
                    OnLeftClickCommandChanged));

        /// <summary>
        /// Gets the left click command.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        public static ICommand GetLeftClickCommand(FrameworkElement element)
        {
            return (ICommand)element.GetValue(LeftClickCommandProperty);
        }

        /// <summary>
        /// Sets the left click command.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="value">The value.</param>
        public static void SetLeftClickCommand(FrameworkElement element, ICommand value)
        {
            element.SetValue(LeftClickCommandProperty, value);
        }

        /// <summary>
        /// Called when the left click command changes.
        /// </summary>
        /// <param name="d">The dependency object.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnLeftClickCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UIElement element)
            {
                if (e.OldValue == null && e.NewValue != null)
                {
                    element.MouseDown += Control_LeftClickMouseDown;
                }
                else if (e.OldValue != null && e.NewValue == null)
                {
                    element.MouseDown -= Control_LeftClickMouseDown;
                }
            }
        }

        /// <summary>
        /// The LeftClickCommandParameter dependency property.
        /// </summary>
        public static readonly DependencyProperty LeftClickCommandParameterProperty =
            DependencyProperty.RegisterAttached("LeftClickCommandParameter", typeof(object),
                typeof(ExtendedCommands), new PropertyMetadata(default(object)));

        /// <summary>
        /// Gets the left click command parameter.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        public static object GetLeftClickCommandParameter(FrameworkElement element)
        {
            return element.GetValue(LeftClickCommandParameterProperty);
        }

        /// <summary>
        /// Sets the left click command parameter.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="value">The value.</param>
        public static void SetLeftClickCommandParameter(FrameworkElement element, object value)
        {
            element.SetValue(LeftClickCommandParameterProperty, value);
        }

        /// <summary>
        /// The LeftDoubleClickCommand dependency property.
        /// </summary>
        public static readonly DependencyProperty LeftDoubleClickCommandProperty =
            DependencyProperty.RegisterAttached("LeftDoubleClickCommand", typeof(ICommand),
                typeof(ExtendedCommands), new PropertyMetadata(default(ICommand)));

        /// <summary>
        /// Gets the left double click command.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        public static ICommand GetLeftDoubleClickCommand(FrameworkElement element)
        {
            return (ICommand)element.GetValue(LeftDoubleClickCommandProperty);
        }

        /// <summary>
        /// Sets the left double click command.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="value">The value.</param>
        public static void SetLeftDoubleClickCommand(FrameworkElement element, ICommand value)
        {
            element.SetValue(LeftDoubleClickCommandProperty, value);
        }

        /// <summary>
        /// Called when the left double click command changes.
        /// </summary>
        /// <param name="d">The dependency object.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnLeftDoubleClickCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UIElement element)
            {
                if (e.OldValue == null && e.NewValue != null)
                {
                    element.MouseDown += Control_LeftDoubleClickMouseDown;
                }
                else if (e.OldValue != null && e.NewValue == null)
                {
                    element.MouseDown -= Control_LeftDoubleClickMouseDown;
                }
            }
        }


        /// <summary>
        /// The LeftDoubleClickCommandParameter property.
        /// </summary>
        public static readonly DependencyProperty LeftDoubleClickCommandParameterProperty =
            DependencyProperty.RegisterAttached("LeftDoubleClickCommandParameter", typeof(object),
                typeof(ExtendedCommands), new PropertyMetadata(default(object))
            );

        /// <summary>
        /// Gets the left double click command parameter.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        public static object GetLeftDoubleClickCommandParameter(FrameworkElement element)
        {
            return element.GetValue(LeftDoubleClickCommandParameterProperty);
        }

        /// <summary>
        /// Sets the left double click command parameter.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="value">The value.</param>
        public static void SetLeftDoubleClickCommandParameter(FrameworkElement element, object value)
        {
            element.SetValue(LeftDoubleClickCommandParameterProperty, value);
        }

        /// <summary>
        /// Called when the left double click command parameter changes.
        /// </summary>
        /// <param name="d">The dependency object.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnLeftDoubleClickCommandParameterChanged(DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            var me = d as FrameworkElement;
        }

        /// <summary>
        /// The RightClickCommand dependency property.
        /// </summary>
        public static readonly DependencyProperty RightClickCommandProperty =
            DependencyProperty.RegisterAttached("RightClickCommand", typeof(ICommand),
                typeof(ExtendedCommands), new PropertyMetadata(default(ICommand),
                    OnRightClickCommandChanged));

        /// <summary>
        /// Gets the right click command.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        public static ICommand GetRightClickCommand(FrameworkElement element)
        {
            return (ICommand)element.GetValue(RightClickCommandProperty);
        }

        /// <summary>
        /// Sets the right click command.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="value">The value.</param>
        public static void SetRightClickCommand(FrameworkElement element, ICommand value)
        {
            element.SetValue(RightClickCommandProperty, value);
        }

        /// <summary>
        /// Called when the right click command changes.
        /// </summary>
        /// <param name="d">The dependency object.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnRightClickCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UIElement element)
            {
                if (e.OldValue == null && e.NewValue != null)
                {
                    element.MouseDown += Control_RightClickMouseDown;
                }
                else if (e.OldValue != null && e.NewValue == null)
                {
                    element.MouseDown -= Control_RightClickMouseDown;
                }
            }
        }

        /// <summary>
        /// The RightClickCommandParameter dependency property.
        /// </summary>
        public static readonly DependencyProperty RightClickCommandParameterProperty =
            DependencyProperty.RegisterAttached("RightClickCommandParameter", typeof(object),
                typeof(ExtendedCommands), new PropertyMetadata(default(object)));

        /// <summary>
        /// Gets the right click command parameter.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        public static object GetRightClickCommandParameter(FrameworkElement element)
        {
            return element.GetValue(RightClickCommandParameterProperty);
        }

        /// <summary>
        /// Sets the right click command parameter.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="value">The value.</param>
        public static void SetRightClickCommandParameter(FrameworkElement element, object value)
        {
            element.SetValue(RightClickCommandParameterProperty, value);
        }

        /// <summary>
        /// The RightDoubleClickCommand dependency property.
        /// </summary>
        public static readonly DependencyProperty RightDoubleClickCommandProperty =
            DependencyProperty.RegisterAttached("RightDoubleClickCommand", typeof(ICommand),
                typeof(ExtendedCommands), new PropertyMetadata(default(ICommand),
                    OnRightDoubleClickCommandChanged));

        /// <summary>
        /// Gets the right double click command.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        public static ICommand GetRightDoubleClickCommand(FrameworkElement element)
        {
            return (ICommand)element.GetValue(RightDoubleClickCommandProperty);
        }

        /// <summary>
        /// Sets the right double click command.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="value">The value.</param>
        public static void SetRightDoubleClickCommand(FrameworkElement element, ICommand value)
        {
            element.SetValue(RightDoubleClickCommandProperty, value);
        }

        /// <summary>
        /// Called when the right double click command changes.
        /// </summary>
        /// <param name="d">The dependency object.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnRightDoubleClickCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UIElement element)
            {
                if (e.OldValue == null && e.NewValue != null)
                {
                    element.MouseDown += Control_RightDoubleClickMouseDown;
                }
                else if (e.OldValue != null && e.NewValue == null)
                {
                    element.MouseDown -= Control_RightDoubleClickMouseDown;
                }
            }
        }


        /// <summary>
        /// The RightDoubleClickCommandParameter dependency property.
        /// </summary>
        public static readonly DependencyProperty RightDoubleClickCommandParameterProperty =
            DependencyProperty.RegisterAttached("RightDoubleClickCommandParameter", typeof(object),
                typeof(ExtendedCommands), new PropertyMetadata(default(object)));

        /// <summary>
        /// Gets the right double click command parameter.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        public static object GetRightDoubleClickCommandParameter(FrameworkElement element)
        {
            return element.GetValue(RightDoubleClickCommandParameterProperty);
        }

        /// <summary>
        /// Sets the right double click command parameter.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="value">The value.</param>
        public static void SetRightDoubleClickCommandParameter(FrameworkElement element, object value)
        {
            element.SetValue(RightDoubleClickCommandParameterProperty, value);
        }
    }
}