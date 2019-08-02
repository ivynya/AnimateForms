using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimateForms.Core
{
    public class Animate
    {
        public delegate int Function(float t, float b, float c, float d);
        private readonly List<(string, string)> _animating = new List<(string, string)>();

        public async Task<bool> Move(Control control, Point moveTo, int duration, Function easing)
        {
            if (_animating.Contains((control.Name, "move")))
                return false;
            else
                _animating.Add((control.Name, "move"));

            Point location = control.Location;
            int yDif = moveTo.Y - location.Y;
            int xDif = moveTo.X - location.X;
            if (yDif == 0 && xDif == 0)
            {
                _animating.Remove((control.Name, "move"));
                return false;
            }

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

            _animating.Remove((control.Name, "move"));
            return true;
        }

        public async Task<bool> Move(Options o, Point moveTo)
        {
            await Task.Delay(o.Delay);
            Point destination = moveTo;
            for (int i = 0; i < o.Controls.Length - 1; i++)
            {
                _ = Move(o.Controls[i], destination, o.Duration, o.Easings[i % o.Easings.Length]);
                destination = new Point(moveTo.X, moveTo.Y);
                await Task.Delay(o.Interval);
            }

            bool success = await Move(o.Controls.Last(), destination, o.Duration,
                                      o.Easings[(o.Controls.Length - 1) % o.Easings.Length]);
            await Task.Delay(o.EndDelay);
            return success;
        }

        public async Task<bool> Move(Options o, Point moveTo, Point offset)
        {
            await Task.Delay(o.Delay);
            Point destination = moveTo;
            for (int i = 0; i < o.Controls.Length - 1; i++)
            {
                _ = Move(o.Controls[i], destination, o.Duration, o.Easings[i % o.Easings.Length]);
                destination = new Point(moveTo.X + (offset.X * (i + 1)),
                                        moveTo.Y + (offset.Y * (i + 1)));
                await Task.Delay(o.Interval);
            }

            bool success = await Move(o.Controls.Last(), destination, o.Duration,
                                      o.Easings[(o.Controls.Length - 1) % o.Easings.Length]);
            await Task.Delay(o.EndDelay);
            return success;
        }

        public async Task<bool> MoveRelative(Control control, Point offset, int duration, Function easing)
        {
            Point prevPoint = new Point(0, 0);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (stopwatch.ElapsedMilliseconds < duration)
            {
                await Task.Delay(1);
                int time = (int)stopwatch.ElapsedMilliseconds;
                if (time > duration) time = duration;

                Point newPoint = new Point(easing(time, 0, offset.X, duration),
                                           easing(time, 0, offset.Y, duration));

                control.Location = new Point(control.Location.X + (newPoint.X - prevPoint.X),
                                             control.Location.Y + (newPoint.Y - prevPoint.Y));

                prevPoint = newPoint;
            }

            return true;
        }

        public async Task<bool> MoveRelative(Options o, Point offset)
        {
            await Task.Delay(o.Delay);
            for (int i = 0; i < o.Controls.Length - 1; i++)
            {
                _ = MoveRelative(o.Controls[i], offset, o.Duration, o.Easings[i % o.Easings.Length]);
                await Task.Delay(o.Interval);
            }

            bool success = await MoveRelative(o.Controls.Last(), offset, o.Duration,
                                              o.Easings[(o.Controls.Length - 1) % o.Easings.Length]);
            await Task.Delay(o.EndDelay);
            return success;
        }

        public async Task<bool> Recolor(Control control, Color colorTo, int duration, Function easing, bool backColor = true)
        {
            if (_animating.Contains((control.Name, "recolor")))
                return false;
            else
                _animating.Add((control.Name, "recolor"));

            Color color;
            if (backColor) color = control.BackColor;
            else color = control.ForeColor;
            if (color == colorTo)
            {
                _animating.Remove((control.Name, "recolor"));
                return false;
            }

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

            _animating.Remove((control.Name, "recolor"));
            return true;
        }

        public async Task<bool> Recolor(Options o, Color color, bool backColor = true)
        {
            await Task.Delay(o.Delay);
            for (int i = 0; i < o.Controls.Length - 1; i++)
            {
                _ = Recolor(o.Controls[i], color, o.Duration,
                    o.Easings[i % o.Easings.Length], backColor);
                await Task.Delay(o.Interval);
            }

            bool success = await Recolor(o.Controls.Last(), color, o.Duration,
                           o.Easings[(o.Controls.Length - 1) % o.Easings.Length]);
            await Task.Delay(o.EndDelay);
            return success;
        }

        public async Task<bool> Recolor(Options o, Color[] colors, bool backColor = true)
        {
            await Task.Delay(o.Delay);
            for (int i = 0; i < o.Controls.Length - 1; i++)
            {
                _ = Recolor(o.Controls[i], colors[i % colors.Length], o.Duration,
                    o.Easings[i % o.Easings.Length], backColor);
                await Task.Delay(o.Interval);
            }

            bool success = await Recolor(o.Controls.Last(), colors[(o.Controls.Length - 1) % colors.Length],
                                         o.Duration, o.Easings[(o.Controls.Length - 1) % o.Easings.Length]);
            await Task.Delay(o.EndDelay);
            return success;
        }

        public async Task<bool> Resize(Control control, Size sizeTo, int duration, Function easing)
        {
            if (_animating.Contains((control.Name, "resize")))
                return false;
            else
                _animating.Add((control.Name, "resize"));

            Size size = control.Size;
            int heightDif = sizeTo.Height - size.Height;
            int widthDif = sizeTo.Width - size.Width;
            if (widthDif == 0 && heightDif == 0)
            {
                _animating.Remove((control.Name, "resize"));
                return false;
            }

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

            _animating.Remove((control.Name, "resize"));
            return true;
        }

        public async Task<bool> Resize(Options o, Size sizeTo)
        {
            await Task.Delay(o.Delay);
            for (int i = 0; i < o.Controls.Length - 1; i++)
            {
                _ = Resize(o.Controls[i], sizeTo, o.Duration, o.Easings[i % o.Easings.Length]);
                await Task.Delay(o.Interval);
            }

            bool success = await Resize(o.Controls.Last(), sizeTo, o.Duration,
                                        o.Easings[(o.Controls.Length - 1) % o.Easings.Length]);
            await Task.Delay(o.EndDelay);
            return success;
        }
    }
}
