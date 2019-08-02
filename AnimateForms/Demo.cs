using System;
using System.Drawing;
using System.Windows.Forms;
using AnimateForms.Animate;

namespace AnimateForms
{
    public partial class Demo : Form
    {
        private readonly int d = 1000;
        private Size eS = new Size(300, 20);
        private Size dS = new Size(20, 20);

        private readonly Animate.Animate a = new Animate.Animate();

        public Demo()
        {
            InitializeComponent();
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            await a.Resize(
                new Options {
                    Controls = Helpers.SortCollectionByName(parent.Controls),
                    Easings = Easings.AllEasings,
                    Duration = d,
                    Alignment = "h-center"
                }, eS);
        }

        private async void Button2_Click(object sender, EventArgs e)
        {
            await a.Resize(
                new Options{
                    Controls = Helpers.SortCollectionByName(parent.Controls),
                    Easings = Easings.AllEasings,
                    Duration = d,
                    Alignment = "h-center"
                }, dS);
        }

        private async void Button3_Click(object sender, EventArgs e)
        {
            Color[] rainbow = new Color[]
            {
                Color.Red, Color.Orange, Color.Yellow, Color.Lime,
                Color.Cyan, Color.Blue, Color.Magenta
            };

            Control[] controls = Helpers.SortCollectionByName(parent.Controls);

            Options recolorOptions = new Options(
                controls: controls,
                easings: Easings.AllEasings,
                duration: d / 2);

            Options moveOptions = new Options(
                controls: controls,
                easing: Easings.CubicInOut,
                duration: d / 2,
                interval: 200);

            Options resizeOptions = new Options
            {
                Controls = controls,
                Easings = Easings.AllEasings,
                Duration = d,
                Alignment = "h-center"
            };

            while(true)
            {
                await a.Resize(new Options(controls, Easings.AllEasings, d), eS);

                await a.Move(moveOptions, new Point(3, 159), new Point(0, -26));

                Array.Reverse(rainbow);
                await a.Recolor(recolorOptions, rainbow);

                await a.Resize(resizeOptions, dS);

                await a.Move(moveOptions, new Point(3, 3), new Point(0, 26));

                Array.Reverse(rainbow);
                await a.Recolor(recolorOptions, rainbow);
            }
        }

        private void Panel1_LocationChanged(object sender, EventArgs e)
        {
            label8.Text = panel1.Location.ToString();
        }
    }
}
