using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimateForms.Animate
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
                await Task.Delay(2);
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
    }
}
