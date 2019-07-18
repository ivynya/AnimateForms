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
            await a.Resize(a.Helpers.SortCollectionByName(parent.Controls),
                    eS, d, Easings.AllEasings);
        }

        private async void Button2_Click(object sender, EventArgs e)
        {
            await a.Resize(a.Helpers.SortCollectionByName(parent.Controls),
                    dS, d, Easings.AllEasings);
        }

        private async void Button3_Click(object sender, EventArgs e)
        {
            while(true)
            {
                await a.Resize(a.Helpers.SortCollectionByName(parent.Controls),
                    eS, d, Easings.AllEasings);
                
                await a.Move(a.Helpers.SortCollectionByName(parent.Controls), 
                    new Point(3, 159), new Point(0, -26), d, Easings.CubicInOut);

                _ = a.Recolor(panel1, Color.Pink, d / 2, Easings.CubicInOut);
                _ = a.Recolor(panel2, Color.Blue, d / 2, Easings.CubicInOut);
                _ = a.Recolor(panel3, Color.Cyan, d / 2, Easings.CubicInOut);
                _ = a.Recolor(panel5, Color.Yellow, d / 2, Easings.CubicInOut);
                _ = a.Recolor(panel6, Color.Orange, d / 2, Easings.CubicInOut);
                await a.Recolor(panel7, Color.Red, d / 2, Easings.CubicInOut);

                await a.Resize(a.Helpers.SortCollectionByName(parent.Controls),
                    dS, d, Easings.AllEasings);

                await a.Move(a.Helpers.SortCollectionByName(parent.Controls),
                    new Point(3, 3), new Point(0, 26), d, Easings.CubicInOut);

                _ = a.Recolor(panel1, Color.Red, d / 2, Easings.CubicInOut);
                _ = a.Recolor(panel2, Color.Orange, d / 2, Easings.CubicInOut);
                _ = a.Recolor(panel3, Color.Yellow, d / 2, Easings.CubicInOut);
                _ = a.Recolor(panel5, Color.Cyan, d / 2, Easings.CubicInOut);
                _ = a.Recolor(panel6, Color.Blue, d / 2, Easings.CubicInOut);
                await a.Recolor(panel7, Color.Pink, d / 2, Easings.CubicInOut);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
