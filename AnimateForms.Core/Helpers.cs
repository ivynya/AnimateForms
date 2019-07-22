using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AnimateForms.Core
{
    /// <summary>
    /// Class with methods to assist with using the API
    /// </summary>
    public static class Helpers
    {
        /// <summary>
        /// Converts a ControlCollection to a Control array.
        /// </summary>
        /// <param name="controlCollection">Input collection</param>
        /// <returns>Control array</returns>
        public static Control[] CollectionToArray(Control.ControlCollection controlCollection)
        {
            IEnumerable<Control> controls = controlCollection.OfType<Control>();
            return controls.ToArray();
        }

        /// <summary>
        /// Converts a ControlCollection into a Control array sorted by the name.
        /// </summary>
        /// <param name="controlCollection">Input collection</param>
        /// <returns>Control array sorted alphabetically by Name property</returns>
        public static Control[] SortCollectionByName(Control.ControlCollection controlCollection)
        {
            IEnumerable<Control> controls = controlCollection.OfType<Control>();
            Control[] controlsArray = controls.ToArray();
            Array.Sort(controlsArray, delegate (Control a, Control b) {
                return a.Name.CompareTo(b.Name);
            });
            return controlsArray;
        }
    }
}
