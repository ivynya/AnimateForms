using System;
using System.Drawing;
using System.Windows.Forms;

namespace AnimateForms
{
    public partial class Demo : Form
    {
        private readonly int d = 5000;
        private Size eS = new Size(300, 20);
        private Size dS = new Size(20, 20);

        private readonly Animate.Animate a = new Animate.Animate();

        public Demo()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            a.AnimateResize(panel1, eS, d, "Linear");
            a.AnimateResize(panel2, eS, d, "QuadIn");
            a.AnimateResize(panel3, eS, d, "QuadOut");
            a.AnimateResize(panel4, eS, d, "QuadInOut");
            a.AnimateResize(panel5, eS, d, "CubicIn");
            a.AnimateResize(panel6, eS, d, "CubicOut");
            a.AnimateResize(panel7, eS, d, "CubicInOut");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            a.AnimateResize(panel1, dS, d, "Linear");
            a.AnimateResize(panel2, dS, d, "QuadIn");
            a.AnimateResize(panel3, dS, d, "QuadOut");
            a.AnimateResize(panel4, dS, d, "QuadInOut");
            a.AnimateResize(panel5, dS, d, "CubicIn");
            a.AnimateResize(panel6, dS, d, "CubicOut");
            a.AnimateResize(panel7, dS, d, "CubicInOut");
        }

        private async void Button3_Click(object sender, EventArgs e)
        {
            while(true)
            {
                a.AnimateResize(panel1, eS, d, "Linear");
                a.AnimateResize(panel2, eS, d, "QuadIn");
                a.AnimateResize(panel3, eS, d, "QuadOut");
                a.AnimateResize(panel4, eS, d, "QuadInOut");
                a.AnimateResize(panel5, eS, d, "CubicIn");
                a.AnimateResize(panel6, eS, d, "CubicOut");
                await a.AnimateResize(panel7, eS, d, "CubicInOut");

                a.AnimateResize(panel1, dS, d, "Linear");
                a.AnimateResize(panel2, dS, d, "QuadIn");
                a.AnimateResize(panel3, dS, d, "QuadOut");
                a.AnimateResize(panel4, dS, d, "QuadInOut");
                a.AnimateResize(panel5, dS, d, "CubicIn");
                a.AnimateResize(panel6, dS, d, "CubicOut");
                await a.AnimateResize(panel7, dS, d, "CubicInOut");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            a.AnimateResize(panel1, eS, d, "Linear");
        }
    }
}
