using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AnimateForms.Animate
{
    public static class Helpers
    {
        public struct HSV
        {
            public float Hue;
            public float Saturation;
            public float Value;
        }

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

        public static HSV RGBtoHSV(Color rgb)
        {
            int max = Math.Max(rgb.R, Math.Max(rgb.G, rgb.B));
            int min = Math.Min(rgb.R, Math.Min(rgb.G, rgb.B));

            HSV hsv = new HSV
            {
                Hue = rgb.GetHue(),
                Saturation = (max == 0) ? 0 : 1 - (1 * min / max),
                Value = max / 255
            };

            return hsv;
        }

        public static Color HSVtoRGB(HSV hsv)
        {
            int chroma = (int)(hsv.Value * hsv.Saturation);
            int degree = (int)Math.Floor(hsv.Hue / 60) % 6;
            int x = chroma * (1 - Math.Abs(degree % 2 - 1));
            int m = (int)(hsv.Value - chroma);

            switch (degree)
            {
                case 0: return Color.FromArgb(chroma + m, x + m, m);
                case 1: return Color.FromArgb(x + m, chroma + m, m);
                case 2: return Color.FromArgb(m, chroma + m, x + m);
                case 3: return Color.FromArgb(m, x + m, chroma + m);
                case 4: return Color.FromArgb(x + m, m, chroma + m);
                default: return Color.FromArgb(chroma + m, m, x + m);
            }
        }
    }
}
