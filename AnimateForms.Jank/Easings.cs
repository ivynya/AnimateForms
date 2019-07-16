using System;

namespace AnimateForms.Core
{
    public static class Easings
    {
        public static int Linear(float t, float b, float c, float d)
        {
            return (int)Math.Round(c * t / d + b);
        }

        public static int QuadIn(float t, float b, float c, float d)
        {
            t /= d;
            return (int)Math.Round(c * t * t + b);
        }

        public static int QuadOut(float t, float b, float c, float d)
        {
            t /= d;
            return (int)Math.Round(-c * t * (t - 2) + b);
        }

        public static int QuadInOut(float t, float b, float c, float d)
        {
            t /= d / 2;
            if (t < 1) return (int)Math.Round(c / 2 * t * t + b);
            t--;
            return (int)Math.Round(-c / 2 * (t * (t - 2) - 1) + b);
        }

        public static int CubicIn(float t, float b, float c, float d)
        {
            t /= d;
            return (int)Math.Round(c * t * t * t + b);
        }

        public static int CubicOut(float t, float b, float c, float d)
        {
            t /= d;
            t--;
            return (int)Math.Round(c * (t * t * t + 1) + b);
        }

        public static int CubicInOut(float t, float b, float c, float d)
        {
            t /= d / 2;
            if (t < 1) return (int)Math.Round(c / 2 * t * t * t + b);
            t -= 2;
            return (int)Math.Round(c / 2 * (t * t * t + 2) + b);
        }
    }
}
