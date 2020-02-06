using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnimateForms.Animate
{
    public class Animate
    {
        public delegate float Function(float t, float b, float c, float d);
        private readonly List<(string, string)> _animating = new List<(string, string)>();

        public static event EventHandler OnAnimationComplete;

        private static readonly string _moveName = "Move";
        public async Task Move(Control control, Function easing, int duration, Point moveTo)
        {
            if (_animating.Contains((control.Name, _moveName)))
                return;
            else
                _animating.Add((control.Name, _moveName));

            Point location = control.Location;
            int yDif = moveTo.Y - location.Y;
            int xDif = moveTo.X - location.X;
            if (yDif == 0 && xDif == 0)
            {
                _animating.Remove((control.Name, _moveName));
                return;
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (stopwatch.ElapsedMilliseconds < duration)
            {
                await Task.Delay(1);
                int time = (int)stopwatch.ElapsedMilliseconds;
                if (time > duration) time = duration;

                control.Location = new Point((int)easing(time, location.X, xDif, duration),
                                             (int)easing(time, location.Y, yDif, duration));
            }

            _animating.Remove((control.Name, _moveName));
            OnAnimationComplete?.Invoke(control, new EventArgs());
        }

        public async Task Move(Options o, Point moveTo)
        {
            await Task.Delay(o.Delay);
            Point destination = moveTo;

            for (int i = 0; i < o.Controls.Length; i++)
            {
                _ = Move(o.Controls[i], o.Easings[i % o.Easings.Length], o.Duration, destination);
                destination = new Point(moveTo.X, moveTo.Y);
                await Task.Delay(o.Interval);
            }

            await Task.Delay(o.Duration + o.EndDelay);
            OnAnimationComplete?.Invoke(o.Controls, new EventArgs());
        }

        public async Task Move(Options o, Point moveTo, Point offset)
        {
            await Task.Delay(o.Delay);
            Point destination = moveTo;

            for (int i = 0; i < o.Controls.Length; i++)
            {
                _ = Move(o.Controls[i], o.Easings[i % o.Easings.Length], o.Duration, destination);
                destination = new Point(moveTo.X + (offset.X * (i + 1)),
                                        moveTo.Y + (offset.Y * (i + 1)));
                await Task.Delay(o.Interval);
            }

            await Task.Delay(o.Duration + o.EndDelay);
            OnAnimationComplete?.Invoke(o.Controls, new EventArgs());
        }

        public async Task MoveRelative(Control control, Function easing, int duration, Point offset)
        {
            if (offset.X == 0 && offset.Y == 0) return;
            Point prevPoint = new Point(0, 0);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (stopwatch.ElapsedMilliseconds < duration)
            {
                await Task.Delay(1);
                int time = (int)stopwatch.ElapsedMilliseconds;
                if (time > duration) time = duration;

                Point newPoint = new Point((int)easing(time, 0, offset.X, duration),
                                           (int)easing(time, 0, offset.Y, duration));

                control.Location = new Point(control.Location.X + (newPoint.X - prevPoint.X),
                                             control.Location.Y + (newPoint.Y - prevPoint.Y));

                prevPoint = newPoint;
            }

            OnAnimationComplete?.Invoke(control, new EventArgs());
        }

        public async Task MoveRelative(Options o, Point offset)
        {
            await Task.Delay(o.Delay);

            for (int i = 0; i < o.Controls.Length; i++)
            {
                _ = MoveRelative(o.Controls[i], o.Easings[i % o.Easings.Length], o.Duration, offset);
                await Task.Delay(o.Interval);
            }

            await Task.Delay(o.Duration + o.EndDelay);
            OnAnimationComplete?.Invoke(o.Controls, new EventArgs());
        }

        private static readonly string _recolorName = "Recolor";
        public async Task Recolor(Control control, Function easing, int duration, Color colorTo, bool backColor = true)
        {
            if (_animating.Contains((control.Name, _recolorName))) return;
            else _animating.Add((control.Name, _recolorName));

            Color color;
            if (backColor) color = control.BackColor;
            else color = control.ForeColor;
            if (color == colorTo)
            {
                _animating.Remove((control.Name, _recolorName));
                return;
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
                newColor = Color.FromArgb((int)easing(time, color.A, aDif, duration),
                                          (int)easing(time, color.R, rDif, duration),
                                          (int)easing(time, color.G, gDif, duration),
                                          (int)easing(time, color.B, bDif, duration));
                if (backColor)
                    control.BackColor = newColor;
                else
                    control.ForeColor = newColor;
            }

            _animating.Remove((control.Name, _recolorName));
            OnAnimationComplete?.Invoke(control, new EventArgs());
        }

        public async Task Recolor(Control control, Function easing, int duration, Helpers.HSV colorTo, bool backColor = true)
        {
            if (_animating.Contains((control.Name, _recolorName))) return;
            else _animating.Add((control.Name, _recolorName));

            Helpers.HSV color;
            if (backColor) color = Helpers.ToHSV(control.BackColor);
            else color = Helpers.ToHSV(control.ForeColor);
            if (color.Hue == colorTo.Hue && 
                color.Hue == colorTo.Saturation && 
                color.Value == colorTo.Value)
            {
                _animating.Remove((control.Name, _recolorName));
                return;
            }

            int hDif = (int)(colorTo.Hue - color.Hue);
            float sDif = colorTo.Saturation - color.Saturation;
            float vDif = colorTo.Value - color.Value;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (stopwatch.ElapsedMilliseconds < duration)
            {
                await Task.Delay(1);
                int time = (int)stopwatch.ElapsedMilliseconds;
                if (time > duration) time = duration;

                Helpers.HSV newHSV = new Helpers.HSV
                {
                    Hue = easing(time, color.Hue, hDif, duration),
                    Saturation = easing(time, color.Saturation, sDif, duration),
                    Value = easing(time, color.Value, vDif, duration)
                };
                Color newColor = Helpers.ToRGB(newHSV);

                if (backColor)
                    control.BackColor = newColor;
                else
                    control.ForeColor = newColor;
            }

            _animating.Remove((control.Name, _recolorName));
            OnAnimationComplete?.Invoke(control, new EventArgs());
        }

        public async Task Recolor(Options o, Color color, bool backColor = true)
        {
            await Task.Delay(o.Delay);

            for (int i = 0; i < o.Controls.Length; i++)
            {
                _ = Recolor(o.Controls[i], o.Easings[i % o.Easings.Length], o.Duration,
                            color, backColor);
                await Task.Delay(o.Interval);
            }

            await Task.Delay(o.Duration + o.EndDelay);
            OnAnimationComplete?.Invoke(o.Controls, new EventArgs());
        }

        public async Task Recolor(Options o, Color[] colors, bool backColor = true)
        {
            await Task.Delay(o.Delay);

            for (int i = 0; i < o.Controls.Length; i++)
            {
                _ = Recolor(o.Controls[i], o.Easings[i % o.Easings.Length],
                            o.Duration, colors[i % colors.Length], backColor);
                await Task.Delay(o.Interval);
            }

            await Task.Delay(o.Duration + o.EndDelay);
            OnAnimationComplete?.Invoke(o.Controls, new EventArgs());
        }

        public async Task Recolor(Options o, Helpers.HSV color, bool backColor = true)
        {
            await Task.Delay(o.Delay);

            for (int i = 0; i < o.Controls.Length; i++)
            {
                _ = Recolor(o.Controls[i], o.Easings[i % o.Easings.Length],
                            o.Duration, color, backColor);
                await Task.Delay(o.Interval);
            }

            await Task.Delay(o.Duration + o.EndDelay);
            OnAnimationComplete?.Invoke(o.Controls, new EventArgs());
        }

        public async Task Recolor(Options o, Helpers.HSV[] colors, bool backColor = true)
        {
            await Task.Delay(o.Delay);

            for (int i = 0; i < o.Controls.Length; i++)
            {
                _ = Recolor(o.Controls[i], o.Easings[i % o.Easings.Length],
                            o.Duration, colors[i % colors.Length], backColor);
                await Task.Delay(o.Interval);
            }

            await Task.Delay(o.Duration + o.EndDelay);
            OnAnimationComplete?.Invoke(o.Controls, new EventArgs());
        }

        private static readonly string _resizeName = "Resize";
        public async Task Resize(Control control, Function easing, int duration, Size sizeTo)
        {
            if (_animating.Contains((control.Name, _resizeName))) return;
            else _animating.Add((control.Name, _resizeName));

            Size size = control.Size;
            int heightDif = sizeTo.Height - size.Height;
            int widthDif = sizeTo.Width - size.Width;
            if (widthDif == 0 && heightDif == 0)
            {
                _animating.Remove((control.Name, _resizeName));
                return;
            }

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            while (stopwatch.ElapsedMilliseconds < duration)
            {
                await Task.Delay(1);
                int time = (int)stopwatch.ElapsedMilliseconds;
                if (time > duration) time = duration;

                control.Size = new Size((int)easing(time, size.Width, widthDif, duration),
                                        (int)easing(time, size.Height, heightDif, duration));
            }

            _animating.Remove((control.Name, _resizeName));
            OnAnimationComplete?.Invoke(control, new EventArgs());
        }

        public async Task Resize(Options o, Size sizeTo)
        {
            double xMultiplier = 0;
            double yMultiplier = 0;
            switch (o.Alignment)
            {
                case "h-center": xMultiplier = 0.5; break;
                case "right": xMultiplier = 1.0; break;
                case "v-center": yMultiplier = 0.5; break;
                case "bottom": yMultiplier = 1.0; break;
                case "hv-center": xMultiplier = 0.5; yMultiplier = 0.5; break;
            }

            await Task.Delay(o.Delay);

            for (int i = 0; i < o.Controls.Length; i++)
            {
                _ = Resize(o.Controls[i], o.Easings[i % o.Easings.Length], o.Duration, sizeTo);
                if (o.Alignment != "default")
                    _ = MoveRelative(new Options(o.Controls[i], o.Easings[i % o.Easings.Length], o.Duration),
                                     new Point(-(int)Math.Round(xMultiplier * (sizeTo.Width - o.Controls[i].Width)),
                                               -(int)Math.Round(yMultiplier * (sizeTo.Height - o.Controls[i].Height))));

                await Task.Delay(o.Interval);
            }

            await Task.Delay(o.Duration + o.EndDelay);
            OnAnimationComplete?.Invoke(o.Controls, new EventArgs());
        }

        public async Task Resize(Options o, int? width = null, int? height = null)
        {
            double xMultiplier = 0;
            double yMultiplier = 0;
            switch (o.Alignment)
            {
                case "h-center": xMultiplier = 0.5; break;
                case "right": xMultiplier = 1.0; break;
                case "v-center": yMultiplier = 0.5; break;
                case "bottom": yMultiplier = 1.0; break;
                case "hv-center": xMultiplier = 0.5; yMultiplier = 0.5; break;
            }

            await Task.Delay(o.Delay);

            Size sizeTo;
            for (int i = 0; i < o.Controls.Length; i++)
            {
                sizeTo = o.Controls[i].Size;
                if (width != null) sizeTo.Width = width.Value;
                if (height != null) sizeTo.Height = height.Value;

                _ = Resize(o.Controls[i], o.Easings[i % o.Easings.Length], o.Duration, sizeTo);
                if (o.Alignment != "default")
                    _ = MoveRelative(new Options(o.Controls[i], o.Easings[i % o.Easings.Length], o.Duration),
                                     new Point(-(int)Math.Round(xMultiplier * (sizeTo.Width - o.Controls[i].Width)),
                                               -(int)Math.Round(yMultiplier * (sizeTo.Height - o.Controls[i].Height))));

                await Task.Delay(o.Interval);
            }

            await Task.Delay(o.Duration + o.EndDelay);
            OnAnimationComplete?.Invoke(o.Controls, new EventArgs());
        }
    }
}
