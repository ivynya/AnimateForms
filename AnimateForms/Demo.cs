using System;
using System.Drawing;
using System.Windows.Forms;
using AnimateForms.Animate;

namespace AnimateForms
{
    public partial class Demo : Form
    {
        private readonly int d = 2000;
        private Size eS = new Size(300, 20);
        private Size dS = new Size(20, 20);

        private readonly Animate.Animate a = new Animate.Animate();

        public Demo()
        {
            InitializeComponent();
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            _ = a.Resize(panel1, eS, d, Easings.Linear);
            _ = a.Resize(panel2, eS, d, Easings.QuadIn);
            _ = a.Resize(panel3, eS, d, Easings.QuadOut);
            _ = a.Resize(panel4, eS, d, Easings.QuadInOut);
            _ = a.Resize(panel5, eS, d, Easings.CubicIn);
            _ = a.Resize(panel6, eS, d, Easings.CubicOut);
            await a.Resize(panel7, eS, d, Easings.CubicInOut);
        }

        private async void Button2_Click(object sender, EventArgs e)
        {
            _ = a.Resize(panel1, dS, d, Easings.Linear);
            _ = a.Resize(panel2, dS, d, Easings.QuadIn);
            _ = a.Resize(panel3, dS, d, Easings.QuadOut);
            _ = a.Resize(panel4, dS, d, Easings.QuadInOut);
            _ = a.Resize(panel5, dS, d, Easings.CubicIn);
            _ = a.Resize(panel6, dS, d, Easings.CubicOut);
            await a.Resize(panel7, dS, d, Easings.CubicInOut);
        }

        private async void Button3_Click(object sender, EventArgs e)
        {
            while(true)
            {
                await a.Resize(parent.Controls, eS, d, Easings.CubicInOut);
                
                _ = a.Move(panel1, new Point(3, 159), d, Easings.CubicInOut);
                _ = a.Move(panel2, new Point(3, 133), d, Easings.CubicInOut);
                _ = a.Move(panel3, new Point(3, 107), d, Easings.CubicInOut);
                _ = a.Move(panel5, new Point(3, 55), d, Easings.CubicInOut);
                _ = a.Move(panel6, new Point(3, 29), d, Easings.CubicInOut);
                _ = a.Move(panel7, new Point(3, 3), d, Easings.CubicInOut);
                await a.Delay(d / 2);

                _ = a.Recolor(panel1, Color.Pink, d / 2, Easings.CubicInOut);
                _ = a.Recolor(panel2, Color.Blue, d / 2, Easings.CubicInOut);
                _ = a.Recolor(panel3, Color.Cyan, d / 2, Easings.CubicInOut);
                _ = a.Recolor(panel5, Color.Yellow, d / 2, Easings.CubicInOut);
                _ = a.Recolor(panel6, Color.Orange, d / 2, Easings.CubicInOut);
                _ = a.Recolor(panel7, Color.Red, d / 2, Easings.CubicInOut);

                await a.Resize(parent.Controls, dS, d, Easings.CubicInOut);

                _ = a.Move(panel7, new Point(3, 159), d, Easings.CubicInOut);
                _ = a.Move(panel6, new Point(3, 133), d, Easings.CubicInOut);
                _ = a.Move(panel5, new Point(3, 107), d, Easings.CubicInOut);
                _ = a.Move(panel3, new Point(3, 55), d, Easings.CubicInOut);
                _ = a.Move(panel2, new Point(3, 29), d, Easings.CubicInOut);
                _ = a.Move(panel1, new Point(3, 3), d, Easings.CubicInOut);
                await a.Delay(d / 2);

                _ = a.Recolor(panel1, Color.Red, d / 2, Easings.CubicInOut);
                _ = a.Recolor(panel2, Color.Orange, d / 2, Easings.CubicInOut);
                _ = a.Recolor(panel3, Color.Yellow, d / 2, Easings.CubicInOut);
                _ = a.Recolor(panel5, Color.Cyan, d / 2, Easings.CubicInOut);
                _ = a.Recolor(panel6, Color.Blue, d / 2, Easings.CubicInOut);
                _ = a.Recolor(panel7, Color.Pink, d / 2, Easings.CubicInOut);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
