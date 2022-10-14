using System;

namespace Apex.MVVM
{
    /// <summary>
    /// The Model Attribute marks a class as a model.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ModelAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelAttribute"/> class.
        /// </summary>
        public ModelAttribute()
        {
            //  Use the standard execution context.
            this.Context = ExecutionContext.Standard;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelAttribute"/> class.
        /// </summary>
        /// <param name="context">The execution context for the model.</param>
        public ModelAttribute(ExecutionContext context)
        {
            //  Store the execution context.
            this.Context = context;
        }

        /// <summary>
        /// Gets the execution context for the model.
        /// </summary>
        public ExecutionContext Context
        {
            get;
            private set;
        }
    }
}
