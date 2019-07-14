using System.Drawing;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace AnimateForms.Animate
{
    public class Animate
    {
        private delegate int Function(float t, float b, float c, float d);
        private static System.Timers.Timer timer;

        public Animate()
        {
            timer = new System.Timers.Timer(10);
            timer.Elapsed += Update;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        public async Task<bool> AnimateElement(Control control, Size sizeTo, int duration, string easing)
        {
            int height = control.Height;
            int width = control.Width;

            int heightDif = sizeTo.Height - control.Height;
            int widthDif = sizeTo.Width - control.Width;

            Function f;
            switch (easing)
            {
                case "Linear": f = Easings.Linear; break;
                case "QuadIn": f = Easings.QuadIn; break;
                case "QuadOut": f = Easings.QuadOut; break;
                case "QuadInOut": f = Easings.QuadInOut; break;
                case "CubicIn": f = Easings.CubicIn; break;
                case "CubicOut": f = Easings.CubicOut; break;
                case "CubicInOut": f = Easings.CubicInOut; break;
                default: f = Easings.Linear; break;
            }

            for (int i = 0; i <= duration; i++)
            {
                control.Size = new Size(f(i, width, widthDif, duration),
                                        f(i, height, heightDif, duration));
                await Task.Delay(1);
            }

            return true;
        } 

        private void Update(object source, ElapsedEventArgs e)
        {
        }
    }
}
