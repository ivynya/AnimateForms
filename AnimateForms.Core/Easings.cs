using System;

namespace AnimateForms.Core
{
    /// <summary>
    /// Includes a list of all basic easings
    /// </summary>
    /// <remarks>Easing equations pulled from http://gizma.com/easing/ </remarks>
    public static class Easings
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public static Animate.Function[] AllEasings = new Animate.Function[]
        {
            Linear, QuadIn, QuadOut, QuadInOut, CubicIn, CubicOut, CubicInOut,
            QuartIn, QuartOut, QuartInOut, QuintIn, QuintOut, QuintInOut, SinIn,
            SinOut, SinInOut, ExpIn, ExpOut, ExpInOut, CircIn, CircOut, CircInOut
        };

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

        public static int QuartIn(float t, float b, float c, float d)
        {
            t /= d;
            return (int)Math.Round(c * t * t * t * t + b);
        }

        public static int QuartOut(float t, float b, float c, float d)
        {
            t /= d;
            t--;
            return (int)Math.Round(-c * (t * t * t * t - 1) + b);
        }

        public static int QuartInOut(float t, float b, float c, float d)
        {
            t /= d / 2;
            if (t < 1) return (int)Math.Round(c / 2 * t * t * t * t + b);
            t -= 2;
            return (int)Math.Round(-c / 2 * (t * t * t * t - 2) + b);
        }

        public static int QuintIn(float t, float b, float c, float d)
        {
            t /= d;
            return (int)Math.Round(c * t * t * t * t * t + b);
        }

        public static int QuintOut(float t, float b, float c, float d)
        {
            t /= d;
            t--;
            return (int)Math.Round(c * (t * t * t * t * t + 1) + b);
        }

        public static int QuintInOut(float t, float b, float c, float d)
        {
            t /= d / 2;
            if (t < 1) return (int)Math.Round(c / 2 * t * t * t * t * t + b);
            t -= 2;
            return (int)Math.Round(c / 2 * (t * t * t * t * t + 2) + b);
        }

        public static int SinIn(float t, float b, float c, float d)
        {
            return (int)Math.Round(-c * Math.Cos(t / d * (Math.PI / 2)) + c + b);
        }

        public static int SinOut(float t, float b, float c, float d)
        {
            return (int)Math.Round(c * Math.Sin(t / d * (Math.PI / 2)) + b);
        }

        public static int SinInOut(float t, float b, float c, float d)
        {
            return (int)Math.Round(-c / 2 * (Math.Cos(Math.PI * t / d) - 1) + b);
        }

        public static int ExpIn(float t, float b, float c, float d)
        {
            return (int)Math.Round(c * Math.Pow(2, 10 * (t / d - 1)) + b);
        }

        public static int ExpOut(float t, float b, float c, float d)
        {
            return (int)Math.Round(c * (-Math.Pow(2, -10 * t / d) + 1) + b);
        }

        public static int ExpInOut(float t, float b, float c, float d)
        {
            t /= d / 2;
            if (t < 1) return (int)Math.Round(c / 2 * Math.Pow(2, 10 * (t - 1)) + b);
            t--;
            return (int)Math.Round(c / 2 * (-Math.Pow(2, -10 * t) + 2) + b);
        }

        public static int CircIn(float t, float b, float c, float d)
        {
            t /= d;
            return (int)Math.Round(-c * (Math.Sqrt(1 - t * t) - 1) + b);
        }

        public static int CircOut(float t, float b, float c, float d)
        {
            t /= d;
            t--;
            return (int)Math.Round(c * Math.Sqrt(1 - t * t) + b);
        }

        public static int CircInOut(float t, float b, float c, float d)
        {
            t /= d / 2;
            if (t < 1) return (int)Math.Round(-c / 2 * (Math.Sqrt(1 - t * t) - 1) + b);
            t -= 2;
            return (int)Math.Round(c / 2 * (Math.Sqrt(1 - t * t) + 1) + b);
        }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}
