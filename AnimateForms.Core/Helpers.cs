using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AnimateForms.Core
{
    public static class Helpers
    {
        public static Control[] CollectionToArray(Control.ControlCollection controlCollection)
        {
            IEnumerable<Control> controls = controlCollection.OfType<Control>();
            return controls.ToArray();
        }

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
