using System.Windows.Forms;
using static AnimateForms.Animate.Animate;
using static AnimateForms.Animate.Easings;

namespace AnimateForms.Animate
{
    public class Options
    {
        public Options() { }

        public Options(Control control, Function easing, int duration, int delay = 0, int interval = 0)
        {
            Controls = new Control[] { control };
            Easings = new Function[] { easing };
            Duration = duration;
            Delay = delay;
            Interval = interval;
        }

        public Options(Control[] controls, Function easing, int duration, int delay = 0, int interval = 0)
        {
            Controls = controls;
            Easings = new Function[] { easing };
            Duration = duration;
            Delay = delay;
            Interval = interval;
        }

        public Options(Control[] controls, Function[] easings, int duration, int delay = 0, int interval = 0)
        {
            Controls = controls;
            Easings = easings;
            Duration = duration;
            Delay = delay;
            Interval = interval;
        }

        public Control[] Controls { get; set; }
        public Function[] Easings { get; set; } = { Linear };
        public string Alignment { get; set; } = "default";
        public int Duration { get; set; } = 1000;
        public int Delay { get; set; } = 0;
        public int EndDelay { get; set; } = 0;
        public int Interval { get; set; } = 0;
    }
}
