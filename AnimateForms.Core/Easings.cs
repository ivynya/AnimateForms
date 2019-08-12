using System;

namespace AnimateForms.Core
{
    public static class Easings
    {
        public static Animate.Function[] AllEasings = new Animate.Function[]
        {
            Linear, QuadIn, QuadOut, QuadInOut, CubicIn, CubicOut, CubicInOut,
            QuartIn, QuartOut, QuartInOut, QuintIn, QuintOut, QuintInOut, SinIn,
            SinOut, SinInOut, ExpIn, ExpOut, ExpInOut, CircIn, CircOut, CircInOut
        };

        // Easing equations pulled from http://gizma.com/easing/

        public static float Linear(float t, float b, float c, float d)
        {
            return (float)(c * t / d + b);
        }

        public static float QuadIn(float t, float b, float c, float d)
        {
            t /= d;
            return (float)(c * t * t + b);
        }

        public static float QuadOut(float t, float b, float c, float d)
        {
            t /= d;
            return (float)(-c * t * (t - 2) + b);
        }

        public static float QuadInOut(float t, float b, float c, float d)
        {
            t /= d / 2;
            if (t < 1) return (float)(c / 2 * t * t + b);
            t--;
            return (float)(-c / 2 * (t * (t - 2) - 1) + b);
        }

        public static float CubicIn(float t, float b, float c, float d)
        {
            t /= d;
            return (float)(c * t * t * t + b);
        }

        public static float CubicOut(float t, float b, float c, float d)
        {
            t /= d;
            t--;
            return (float)(c * (t * t * t + 1) + b);
        }

        public static float CubicInOut(float t, float b, float c, float d)
        {
            t /= d / 2;
            if (t < 1) return (float)(c / 2 * t * t * t + b);
            t -= 2;
            return (float)(c / 2 * (t * t * t + 2) + b);
        }

        public static float QuartIn(float t, float b, float c, float d)
        {
            t /= d;
            return (float)(c * t * t * t * t + b);
        }

        public static float QuartOut(float t, float b, float c, float d)
        {
            t /= d;
            t--;
            return (float)(-c * (t * t * t * t - 1) + b);
        }

        public static float QuartInOut(float t, float b, float c, float d)
        {
            t /= d / 2;
            if (t < 1) return (float)(c / 2 * t * t * t * t + b);
            t -= 2;
            return (float)(-c / 2 * (t * t * t * t - 2) + b);
        }

        public static float QuintIn(float t, float b, float c, float d)
        {
            t /= d;
            return (float)(c * t * t * t * t * t + b);
        }

        public static float QuintOut(float t, float b, float c, float d)
        {
            t /= d;
            t--;
            return (float)(c * (t * t * t * t * t + 1) + b);
        }

        public static float QuintInOut(float t, float b, float c, float d)
        {
            t /= d / 2;
            if (t < 1) return (float)(c / 2 * t * t * t * t * t + b);
            t -= 2;
            return (float)(c / 2 * (t * t * t * t * t + 2) + b);
        }

        public static float SinIn(float t, float b, float c, float d)
        {
            return (float)(-c * Math.Cos(t / d * (Math.PI / 2)) + c + b);
        }

        public static float SinOut(float t, float b, float c, float d)
        {
            return (float)(c * Math.Sin(t / d * (Math.PI / 2)) + b);
        }

        public static float SinInOut(float t, float b, float c, float d)
        {
            return (float)(-c / 2 * (Math.Cos(Math.PI * t / d) - 1) + b);
        }

        public static float ExpIn(float t, float b, float c, float d)
        {
            return (float)(c * Math.Pow(2, 10 * (t / d - 1)) + b);
        }

        public static float ExpOut(float t, float b, float c, float d)
        {
            return (float)(c * (-Math.Pow(2, -10 * t / d) + 1) + b);
        }

        public static float ExpInOut(float t, float b, float c, float d)
        {
            t /= d / 2;
            if (t < 1) return (float)(c / 2 * Math.Pow(2, 10 * (t - 1)) + b);
            t--;
            return (float)(c / 2 * (-Math.Pow(2, -10 * t) + 2) + b);
        }

        public static float CircIn(float t, float b, float c, float d)
        {
            t /= d;
            return (float)(-c * (Math.Sqrt(1 - t * t) - 1) + b);
        }

        public static float CircOut(float t, float b, float c, float d)
        {
            t /= d;
            t--;
            return (float)(c * Math.Sqrt(1 - t * t) + b);
        }

        public static float CircInOut(float t, float b, float c, float d)
        {
            t /= d / 2;
            if (t < 1) return (float)(-c / 2 * (Math.Sqrt(1 - t * t) - 1) + b);
            t -= 2;
            return (float)(c / 2 * (Math.Sqrt(1 - t * t) + 1) + b);
        }
    }
}
