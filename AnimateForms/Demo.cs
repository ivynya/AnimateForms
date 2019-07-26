using System;
using System.Drawing;
using System.Windows.Forms;
using AnimateForms.Animate;

namespace AnimateForms
{
    public partial class Demo : Form
    {
        private readonly int d = 3000;
        private Size eS = new Size(300, 20);
        private Size dS = new Size(20, 20);

        private readonly Animate.Animate a = new Animate.Animate();

        public Demo()
        {
            InitializeComponent();
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            await a.Resize(Helpers.SortCollectionByName(parent.Controls),
                    eS, d, Easings.AllEasings);
        }

        private async void Button2_Click(object sender, EventArgs e)
        {
            await a.Resize(Helpers.SortCollectionByName(parent.Controls),
                    dS, d, Easings.AllEasings);
        }

        private async void Button3_Click(object sender, EventArgs e)
        {
            Color[] rainbow = new Color[]
            {
                Color.Red, Color.Orange, Color.Yellow, Color.Lime,
                Color.Cyan, Color.Blue, Color.Magenta
            };

            Control[] controls = Helpers.SortCollectionByName(parent.Controls);

            while(true)
            {
                await a.Resize(controls, eS, new Options(Easings.AllEasings, d / 2));

                await a.Move(controls, new Point(3, 159), new Point(0, -26), 
                    new Options(Easings.SinInOut, d / 2, 0, 200));

                Array.Reverse(rainbow);
                await a.Recolor(controls, rainbow, d, Easings.CubicInOut);

                await a.Resize(controls, dS, d, Easings.AllEasings);

                await a.Move(controls, new Point(3, 3), new Point(0, 26),
                    new Options(Easings.QuintInOut, d / 2, 0, 200));

                Array.Reverse(rainbow);
                await a.Recolor(controls, rainbow, d, Easings.CubicInOut);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
