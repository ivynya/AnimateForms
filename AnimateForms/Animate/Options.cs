using static AnimateForms.Animate.Animate;
using static AnimateForms.Animate.Easings;

namespace AnimateForms.Animate
{
    public class Options
    {
        public Options(Function easing, int duration, int delay = 0, int interval = 0)
        {
            Easings = new Function[] { easing };
            Duration = duration;
            Delay = delay;
            Interval = interval;
        }

        public Options(Function[] easings, int duration, int delay = 0, int interval = 0)
        {
            Easings = easings;
            Duration = duration;
            Delay = delay;
            Interval = interval;
        }

        public Function[] Easings { get; set; } = { Linear };
        public int Duration { get; set; } = 1000;
        public int Delay { get; set; } = 0;
        public int Interval { get; set; } = 0;
    }
}
