using System;
using System.Windows;
using System.Windows.Input;

namespace Apex.Commands
{
    /// <summary> 
    /// Allows a command to bound via a static resource.
    /// The inspiration from this class came from:
    /// http://joshsmithonwpf.wordpress.com/
    /// </summary> 
    public class CommandReference : Freezable, ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandReference"/> class.
        /// </summary>
        public CommandReference()
        {
        }

        /// <summary>
        /// The Command dependency property.
        /// </summary>
        public static readonly DependencyProperty CommandProperty =
          DependencyProperty.Register("Command",
          typeof(ICommand), typeof(CommandReference),
          new PropertyMetadata(OnCommandChanged));

        /// <summary>
        /// Gets or sets the command.
        /// </summary>
        /// <value>
        /// The command.
        /// </value>
        public ICommand Command
        {
            get => (ICommand)this.GetValue(CommandProperty);
            set => this.SetValue(CommandProperty, value);
        }

        #region ICommand Members

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns>
        /// true if this command can be executed; otherwise, false.
        /// </returns>
        public bool CanExecute(object parameter)
        {
            if (this.Command != null)
            {
                return this.Command.CanExecute(parameter);
            }

            return false;
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        public void Execute(object parameter)
        {
            this.Command.Execute(parameter);
        }

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Called when the command is changed..
        /// </summary>
        /// <param name="d">The dependency object.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //  Get the reference to the CommandReference.
            var me = d as CommandReference;

            //  Cast the data.
            var newCommandValue = e.NewValue as ICommand;

            if (e.OldValue is ICommand oldCommandValue)
            {
                oldCommandValue.CanExecuteChanged -= me.CanExecuteChanged;
            }

            if (newCommandValue != null)
            {
                newCommandValue.CanExecuteChanged += me.CanExecuteChanged;
            }
        }

        #endregion

#if !SILVERLIGHT

        #region Freezable

        /// <summary>
        /// When implemented in a derived class, creates a new instance of the <see cref="T:System.Windows.Freezable"/> derived class.
        /// </summary>
        /// <returns>
        /// The new instance.
        /// </returns>
        protected override Freezable CreateInstanceCore()
        {
            throw new NotImplementedException();
        }

        #endregion

#endif

    }
}