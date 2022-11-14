// <copyright file="RelayCommand.cs" company="RSSCargo">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RSS_Cargo.Presentation.Core
{
    using System;
    using System.Windows.Input;

    /// <summary>
    /// Relay command.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action<object> execute;
        private readonly Func<object, bool>? canExecute;

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/> class.
        /// </summary>
        /// <param name="execute">Exacutor.</param>
        /// <param name="canExecute">Can exacute.</param>
        public RelayCommand(Action<object> execute, Func<object, bool>? canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        /// <summary>
        /// Execute event handler.
        /// </summary>
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Can execute.
        /// </summary>
        /// <param name="parameter">Parameter.</param>
        /// <returns>Can ecaute.</returns>
        public bool CanExecute(object? parameter)
        {
            return this.canExecute == null || this.canExecute(parameter!);
        }

        /// <summary>
        /// execute.
        /// </summary>
        /// <param name="parameter">Parameter.</param>
        public void Execute(object? parameter)
        {
            this.execute(parameter!);
        }
    }
}
