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
            a.Resize(panel1, eS, d, Easings.Linear);
            a.Resize(panel2, eS, d, Easings.QuadIn);
            a.Resize(panel3, eS, d, Easings.QuadOut);
            a.Resize(panel4, eS, d, Easings.QuadInOut);
            a.Resize(panel5, eS, d, Easings.CubicIn);
            a.Resize(panel6, eS, d, Easings.CubicOut);
            await a.Resize(panel7, eS, d, Easings.CubicInOut);
        }

        private async void Button2_Click(object sender, EventArgs e)
        {
            a.Resize(panel1, dS, d, Easings.Linear);
            a.Resize(panel2, dS, d, Easings.QuadIn);
            a.Resize(panel3, dS, d, Easings.QuadOut);
            a.Resize(panel4, dS, d, Easings.QuadInOut);
            a.Resize(panel5, dS, d, Easings.CubicIn);
            a.Resize(panel6, dS, d, Easings.CubicOut);
            await a.Resize(panel7, dS, d, Easings.CubicInOut);
        }

        private async void Button3_Click(object sender, EventArgs e)
        {
            while(true)
            {
                a.Resize(panel1, eS, d, Easings.Linear);
                a.Resize(panel2, eS, d, Easings.QuadIn);
                a.Resize(panel3, eS, d, Easings.QuadOut);
                a.Resize(panel4, eS, d, Easings.QuadInOut);
                a.Resize(panel5, eS, d, Easings.CubicIn);
                a.Resize(panel6, eS, d, Easings.CubicOut);
                await a.Resize(panel7, eS, d, Easings.CubicInOut);

                a.Move(panel1, new Point(70, 340), d, Easings.CubicInOut);
                a.Move(panel2, new Point(70, 300), d, Easings.CubicInOut);
                a.Move(panel3, new Point(70, 260), d, Easings.CubicInOut);
                a.Move(panel5, new Point(70, 180), d, Easings.CubicInOut);
                a.Move(panel6, new Point(70, 140), d, Easings.CubicInOut);
                await a.Move(panel7, new Point(70, 100), d, Easings.CubicInOut);

                a.Resize(panel1, dS, d, Easings.Linear);
                a.Resize(panel2, dS, d, Easings.QuadIn);
                a.Resize(panel3, dS, d, Easings.QuadOut);
                a.Resize(panel4, dS, d, Easings.QuadInOut);
                a.Resize(panel5, dS, d, Easings.CubicIn);
                a.Resize(panel6, dS, d, Easings.CubicOut);
                await a.Resize(panel7, dS, d, Easings.CubicInOut);

                a.Move(panel7, new Point(70, 340), d, Easings.CubicInOut);
                a.Move(panel6, new Point(70, 300), d, Easings.CubicInOut);
                a.Move(panel5, new Point(70, 260), d, Easings.CubicInOut);
                a.Move(panel3, new Point(70, 180), d, Easings.CubicInOut);
                a.Move(panel2, new Point(70, 140), d, Easings.CubicInOut);
                await a.Move(panel1, new Point(70, 100), d, Easings.CubicInOut);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //a.Resize(panel1, eS, d, "Linear");
        }
    }
}
