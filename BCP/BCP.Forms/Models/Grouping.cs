//  // --------------------------------------------------------------------------------------------------------------------
//  // <copyright file="Grouping.cs" company="Grosvenor">
//  //   Grosvenor
//  // </copyright>
//  // <summary>
//  //   Grouping.cs
//  // </summary>
//  // --------------------------------------------------------------------------------------------------------------------

namespace BCP.Forms.Models
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Grouping.
    /// </summary>
    public class Grouping<K, T> : ObservableCollection<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BCP.Forms.Models.Grouping`2"/> class.
        /// </summary>
        /// <param name="key">the Key.</param>
        /// <param name="items">the Items.</param>
        public Grouping(K key, IEnumerable<T> items)
        {
            Key = key;
            foreach (var item in items)
            {
                this.Items.Add(item);
            }
        }

        /// <summary>
        /// Gets the key.
        /// </summary>
        /// <value>The key.</value>
        public K Key { get; private set; }
    }
}
