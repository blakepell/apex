﻿using System;

namespace Apex.MVVM
{
    /// <summary>
    /// The ViewModel attribute marks a class as a ViewModel. This is used
    /// to allow the Apex SDK to help build Views and ViewModels.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ViewModelAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelAttribute"/> class.
        /// </summary>
        public ViewModelAttribute()
        {
            //  By default, a viewmodel is in the standard context.
            this.Context = ExecutionContext.Standard;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelAttribute"/> class.
        /// </summary>
        /// <param name="context">The execution context for the view model.</param>
        public ViewModelAttribute(ExecutionContext context)
        {
            //  Store the context.
            this.Context = context;
        }

        /// <summary>
        /// Gets the execution context for the model.
        /// </summary>
        public ExecutionContext Context { get; private set; }
    }
}