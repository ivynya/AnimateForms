using static AnimateForms.Core.Animate;

namespace AnimateForms.Core
{
    /// <summary>
    /// Options for altering animation properties
    /// </summary>
    public class Options
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
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
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

        /// <summary>
        /// List of easings to be used
        /// </summary>
        public Function[] Easings { get; set; } = { Core.Easings.Linear };
        /// <summary>
        /// Duration of animation, in milliseconds
        /// </summary>
        public int Duration { get; set; } = 1000;
        /// <summary>
        /// Delay before animation initializes, in milliseconds
        /// </summary>
        public int Delay { get; set; } = 0;
        /// <summary>
        /// Delay between animations using multiple targets, in milliseconds
        /// </summary>
        public int Interval { get; set; } = 0;
    }
}
