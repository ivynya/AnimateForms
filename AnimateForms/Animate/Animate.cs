using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimateForms.Animate
{
    public class Animate
    {
        private delegate int Function(float t, float b, float c, float d);

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

        public async Task<bool> AnimateResize(Control control, Size sizeTo, int duration, string easing)
        {
            int height = control.Height;
            int width = control.Width;

            int heightDif = sizeTo.Height - height;
            int widthDif = sizeTo.Width - width;

            Function f = GetFunction(easing);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            while (stopwatch.ElapsedMilliseconds < duration)
            {
                await Task.Delay(1);
                int time = (int)stopwatch.ElapsedMilliseconds;
                if (time > duration) time = duration;
                control.Size = new Size(f(time, width, widthDif, duration),
                                        f(time, height, heightDif, duration));
            }

            return true;
        }
    }
}
