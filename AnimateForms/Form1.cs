using System;
using System.Drawing;
using System.Windows.Forms;

namespace AnimateForms
{
    public partial class Form1 : Form
    {
        private int d = 1000;
        private Size eS = new Size(300, 20);
        private Size dS = new Size(20, 20);

        private Animate.Animate a = new Animate.Animate();

        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            a.AnimateElement(panel1, eS, d, "Linear");
            a.AnimateElement(panel2, eS, d, "QuadIn");
            a.AnimateElement(panel3, eS, d, "QuadOut");
            a.AnimateElement(panel4, eS, d, "QuadInOut");
            a.AnimateElement(panel5, eS, d, "CubicIn");
            a.AnimateElement(panel6, eS, d, "CubicOut");
            a.AnimateElement(panel7, eS, d, "CubicInOut");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            a.AnimateElement(panel1, dS, d, "Linear");
            a.AnimateElement(panel2, dS, d, "QuadIn");
            a.AnimateElement(panel3, dS, d, "QuadOut");
            a.AnimateElement(panel4, dS, d, "QuadInOut");
            a.AnimateElement(panel5, dS, d, "CubicIn");
            a.AnimateElement(panel6, dS, d, "CubicOut");
            a.AnimateElement(panel7, dS, d, "CubicInOut");
        }

        private async void Button3_Click(object sender, EventArgs e)
        {
            while(true)
            {
                a.AnimateElement(panel1, eS, d, "Linear");
                a.AnimateElement(panel2, eS, d, "QuadIn");
                a.AnimateElement(panel3, eS, d, "QuadOut");
                a.AnimateElement(panel4, eS, d, "QuadInOut");
                a.AnimateElement(panel5, eS, d, "CubicIn");
                a.AnimateElement(panel6, eS, d, "CubicOut");
                a.AnimateElement(panel7, eS, d, "CubicInOut");

                a.AnimateElement(panel1, dS, d, "Linear");
                a.AnimateElement(panel2, dS, d, "QuadIn");
                a.AnimateElement(panel3, dS, d, "QuadOut");
                a.AnimateElement(panel4, dS, d, "QuadInOut");
                a.AnimateElement(panel5, dS, d, "CubicIn");
                a.AnimateElement(panel6, dS, d, "CubicOut");
                a.AnimateElement(panel7, dS, d, "CubicInOut");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Button1_Click(sender, e);
        }
    }
}
