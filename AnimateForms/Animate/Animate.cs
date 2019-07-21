using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimateForms.Animate
{
    public class Animate
    {
        public delegate int Function(float t, float b, float c, float d);

        public async Task<bool> Delay(int duration)
        {
            await Task.Delay(duration);
            return true;
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

        public async Task<bool> Resize(Control[] controls, Size sizeTo, int duration, Function easing)
        {
            for (int i = 0; i < controls.Length - 1; i++)
                _ = Resize(controls[i], sizeTo, duration, easing);

            return await Resize(controls.Last(), sizeTo, duration, easing);
        }

        public async Task<bool> Resize(Control[] controls, Size sizeTo, int duration, Function[] easings)
        {
            for (int i = 0; i < controls.Length - 1; i++)
                _ = Resize(controls[i], sizeTo, duration, easings[i % easings.Length]);

            return await Resize(controls.Last(), sizeTo, duration, 
                easings[controls.Length - 1 % easings.Length]);
        }

        public async Task<bool> Resize(Control[] controls, Size sizeTo, Options o)
        {
            await Delay(o.Delay);
            for (int i = 0; i < controls.Length - 1; i++)
            {
                _ = Resize(controls[i], sizeTo, o.Duration, o.Easings[i % o.Easings.Length]);
                await Delay(o.Interval);
            }

            return await Resize(controls.Last(), sizeTo, o.Duration, 
                o.Easings[controls.Length - 1 % o.Easings.Length]);
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

        public async Task<bool> Move(Control[] controls, Point moveTo, Point offset, int duration, Function easing)
        {
            Point destination = moveTo;
            for (int i = 0; i < controls.Length - 1; i++)
            {
                _ = Move(controls[i], destination, duration, easing);
                destination = new Point(moveTo.X + (offset.X * (i + 1)),
                                        moveTo.Y + (offset.Y * (i + 1)));
            }

            return await Move(controls.Last(), destination, duration, easing);
        }

        public async Task<bool> Move(Control[] controls, Point moveTo, Point offset, Options o)
        {
            await Delay(o.Delay);
            Point destination = moveTo;
            for (int i = 0; i < controls.Length - 1; i++)
            {
                _ = Move(controls[i], destination, o.Duration, o.Easings[i % o.Easings.Length]);
                destination = new Point(moveTo.X + (offset.X * (i + 1)),
                                        moveTo.Y + (offset.Y * (i + 1)));
                await Delay(o.Interval);
            }

            return await Move(controls.Last(), destination, o.Duration,
                o.Easings[(controls.Length - 1) % o.Easings.Length]);
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

        public async Task<bool> Recolor(Control[] controls, Color colorTo, int duration, Function easing)
        {
            foreach (Control control in controls)
                if (control != controls.Last())
                    _ = Recolor(control, colorTo, duration, easing);

            return await Recolor(controls.Last(), colorTo, duration, easing);
        }

        public async Task<bool> Recolor(Control[] controls, Color[] colors, int duration, Function easing)
        {
            for (int i = 0; i < controls.Length - 1; i++)
                _ = Recolor(controls[i], colors[i % colors.Length], duration, easing);

            return await Recolor(controls.Last(), colors[(controls.Length - 1) % colors.Length], duration, easing);
        }

        public async Task<bool> Recolor(Control[] controls, Color[] colors, int duration, Function[] easings)
        {
            for (int i = 0; i < controls.Length - 1; i++)
                _ = Recolor(controls[i], colors[i % colors.Length], duration, easings[i % colors.Length]);

            return await Recolor(controls.Last(), colors[(controls.Length - 1) % colors.Length], 
                duration, easings[controls.Length % easings.Length]);
        }

        public async Task<bool> Recolor(Control[] controls, Color[] colors, Options o)
        {
            await Delay(o.Delay);
            for (int i = 0; i < controls.Length - 1; i++)
            {
                _ = Recolor(controls[i], colors[i % colors.Length], o.Duration, o.Easings[i % colors.Length]);
                await Delay(o.Interval);
            }

            return await Recolor(controls.Last(), colors[(controls.Length - 1) % colors.Length],
                o.Duration, o.Easings[controls.Length % o.Easings.Length]);
        }
    }
}
