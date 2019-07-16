using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimateForms.Core
{
    public class Animate
    {
        public delegate int Function(float t, float b, float c, float d);

        private Function GetFunction(string function)
        {
            switch (function)
            {
                case "Linear": return Easings.Linear;
                case "QuadIn": return Easings.QuadIn;
                case "QuadOut": return Easings.QuadOut;
                case "QuadInOut": return Easings.QuadInOut;
                case "CubicIn": return Easings.CubicIn;
                case "CubicOut": return Easings.CubicOut;
                case "CubicInOut": return Easings.CubicInOut;
                default: return Easings.Linear;
            }
        }

        public async Task<bool> Resize(Control control, Size sizeTo, int duration, Function easing)
        {
            Size size = control.Size;
            int heightDif = sizeTo.Height - size.Height;
            int widthDif = sizeTo.Width - size.Width;
            if (widthDif == 0 && heightDif == 0) return false;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (stopwatch.ElapsedMilliseconds < duration)
            {
                await Task.Delay(1);
                int time = (int)stopwatch.ElapsedMilliseconds;
                if (time > duration) time = duration;

                control.Size = new Size(easing(time, size.Width, widthDif, duration),
                                        easing(time, size.Height, heightDif, duration));
            }

            return true;
        }

        public async Task<bool> Resize(Control control, Size sizeTo, int duration, string easing)
        {
            return await Resize(control, sizeTo, duration, GetFunction(easing));
        }

        public async Task<bool> Move(Control control, Point moveTo, int duration, Function easing)
        {
            Point location = control.Location;
            int yDif = moveTo.Y - location.Y;
            int xDif = moveTo.X - location.X;
            if (yDif == 0 && xDif == 0) return false;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (stopwatch.ElapsedMilliseconds < duration)
            {
                await Task.Delay(1);
                int time = (int)stopwatch.ElapsedMilliseconds;
                if (time > duration) time = duration;

                control.Location = new Point(easing(time, location.X, xDif, duration),
                                             easing(time, location.Y, yDif, duration));
            }

            return true;
        }

        public async Task<bool> Move(Control control, Point moveTo, int duration, string easing)
        {
            return await Move(control, moveTo, duration, GetFunction(easing));
        }

        public async Task<bool> Recolor(Control control, Color colorTo, int duration, Function easing, bool backColor = true)
        {
            Color color;
            if (backColor) color = control.BackColor;
            else color = control.ForeColor;
            if (color == colorTo) return false;

            int aDif = colorTo.A - color.A;
            int rDif = colorTo.R - color.R;
            int gDif = colorTo.G - color.G;
            int bDif = colorTo.B - color.B;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (stopwatch.ElapsedMilliseconds < duration)
            {
                await Task.Delay(1);
                int time = (int)stopwatch.ElapsedMilliseconds;
                if (time > duration) time = duration;

                Color newColor;
                newColor = Color.FromArgb(easing(time, color.A, aDif, duration),
                                          easing(time, color.R, rDif, duration),
                                          easing(time, color.G, gDif, duration),
                                          easing(time, color.B, bDif, duration));
                if (backColor)
                    control.BackColor = newColor;
                else
                    control.ForeColor = newColor;
            }

            return true;
        }

        public async Task<bool> Recolor(Control control, Color colorTo, int duration, string easing, bool backColor = true)
        {
            return await Recolor(control, colorTo, duration, GetFunction(easing), backColor);
        }
    }
}
