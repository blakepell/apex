using System.Collections.ObjectModel;
using Apex.MVVM;

namespace Gallery.MVVM.CommandingSample
{
    /// <summary>
    /// The CommandingSampleViewModel ViewModel class.
    /// </summary>
    [ViewModel]
    public class CommandingSampleViewModel : GalleryItemViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandingSampleViewModel"/> class.
        /// </summary>
        public CommandingSampleViewModel()
        {
            this.Title = "Commanding Sample";

            //  Create the simple command - calls DoSimpleCommand.
            this.SimpleCommand = new Command(this.DoSimpleCommand);

            //  Create the lambda command, no extra function necessary.
            this.LambdaCommand = new Command(
              () =>
              {
                  this.Messages.Add("Calling the Lamba Command - no explicit function necessary.");
              });

            //  Create the parameterized command.
            this.ParameterisedCommand = new Command(this.DoParameterisedCommand, true);

            //  Create the enable/disable command, initially disabled.
            this.EnableDisableCommand = new Command(
                () =>
                {
                    this.Messages.Add("Enable/Disable command called.");
                }, false);

            //  Create the events command.
            this.EventsCommand = new Command(
                () =>
                {
                    this.Messages.Add("Calling the Events Command.");
                });

            //  Create the async command.
            this.AsyncCommand1 = new AsynchronousCommand(
                () =>
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        //  Report progress.
                        this.AsyncCommand1.ReportProgress(() => { this.Messages.Add(i.ToString()); });

                        System.Threading.Thread.Sleep(200);
                    }
                });

            //  Create the async command.
            this.AsyncCommand2 = new AsynchronousCommand(
                () =>
                {
                    for (char c = 'A'; c <= 'Z'; c++)
                    {
                        //  Report progress.
                        this.AsyncCommand2.ReportProgress(() => { this.Messages.Add(c.ToString()); });

                        System.Threading.Thread.Sleep(100);
                    }
                });

            //  Create the cancellable async command.
            this.CancellableAsyncCommand = new AsynchronousCommand(
              () =>
              {
                  for (int i = 1; i <= 100; i++)
                  {
                      //  Do we need to cancel?
                      if (this.CancellableAsyncCommand.CancelIfRequested())
                      {
                          return;
                      }

                      //  Report progress.
                      this.CancellableAsyncCommand.ReportProgress(() => { this.Messages.Add(i.ToString()); });

                      System.Threading.Thread.Sleep(100);
                  }
              });

            //  Create the disable during execution command.
            this.DisabledDuringExecutionAsyncCommand = new AsynchronousCommand(
                () =>
                {
                    for (int i = 1; i <= 10; i++)
                    {
                        //  Report progress.
                        this.DisabledDuringExecutionAsyncCommand.ReportProgress(() => { this.Messages.Add(i.ToString()); });

                        System.Threading.Thread.Sleep(200);
                    }
                })
            {
                DisableDuringExecution = true
            };

            //  Create the event binding command.
            this.EventBindingCommand = new Command(this.DoEventBindingCommand);

            //  Create the typed commands.
            this.IntTypedCommand = new Command<int>(this.DoIntTypedCommand);
            this.StringTypedCommand = new Command<string>(this.DoStringTypedCommand);
        }

        private void DoSimpleCommand()
        {
            //  Add a message.
            this.Messages.Add("Calling 'DoSimpleCommand'.");
        }

        private void DoParameterisedCommand(object parameter)
        {
            this.Messages.Add("Calling a Parameterised Command - the Parameter is '" + parameter.ToString() + "'.");
        }

        private void DoEventBindingCommand()
        {
            this.Messages.Add("Called a command via an event.");
        }

        /// <summary>
        /// Does the int typed command.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        private void DoIntTypedCommand(int parameter)
        {
            this.Messages.Add("Received an int parameter: " + parameter);
        }

        /// <summary>
        /// Does the string typed command.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        private void DoStringTypedCommand(string parameter)
        {
            this.Messages.Add("Received a string parameter: " + parameter);
        }
        
        public Command SimpleCommand
        {
            get;
            private set;
        }

        public Command LambdaCommand
        {
            get;
            private set;
        }

        public Command ParameterisedCommand
        {
            get;
            private set;
        }

        public Command EnableDisableCommand
        {
            get;
            private set;
        }

        public Command EventsCommand
        {
            get;
            private set;
        }

        public AsynchronousCommand AsyncCommand1
        {
            get;
            private set;
        }

        public AsynchronousCommand AsyncCommand2
        {
            get;
            private set;
        }

        public AsynchronousCommand CancellableAsyncCommand
        {
            get;
            private set;
        }

        public AsynchronousCommand DisabledDuringExecutionAsyncCommand { get; private set; }

        public Command EventBindingCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the int typed command.
        /// </summary>
        public Command<int> IntTypedCommand { get; private set; }

        /// <summary>
        /// Gets the string typed command.
        /// </summary>
        public Command<string> StringTypedCommand { get; private set; }

        /// <summary>
        /// The messages observable collection.
        /// </summary>
        private readonly ObservableCollection<string> messages = new ObservableCollection<string>();

        /// <summary>
        /// Gets the messages.
        /// </summary>
        public ObservableCollection<string> Messages => messages;
    }
}
