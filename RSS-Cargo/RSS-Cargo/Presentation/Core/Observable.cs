// <copyright file="Observable.cs" company="RSSCargo">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RSS_Cargo.Presentation.Core
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Observer.
    /// </summary>
    public class Observable : INotifyPropertyChanged
    {
        /// <summary>
        /// Gets or sets changes.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Handle changes.
        /// </summary>
        /// <param name="name">Name.</param>
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
