using AnimateForms.Core;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace NuGetDemo
{
    public partial class Demo : Form
    {
        private readonly Animate a = new Animate();

        public Demo()
        {
            InitializeComponent();
        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://sdbagel.github.io/AnimateForms/");
        }

        private void LinkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://sdbagel.github.io/AnimateForms/Quickstart");
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            await a.Resize(panel1, Easings.Linear, 1000, new Size(300, 30));
        }

        private async void Button2_Click(object sender, EventArgs e)
        {
            await a.Resize(panel1, Easings.Linear, 1000, new Size(30, 30));
        }

        private async void Button4_Click(object sender, EventArgs e)
        {
            await a.Move(panel2, Easings.Linear, 1000, new Point(20, panel2.Location.Y));
        }

        private async void Button3_Click(object sender, EventArgs e)
        {
            await a.Move(panel2, Easings.Linear, 1000, new Point(290, panel2.Location.Y));
        }

        private async void Button6_Click(object sender, EventArgs e)
        {
            await a.Recolor(panel3, Easings.Linear, 1000, Color.White);
        }

        private async void Button5_ClickAsync(object sender, EventArgs e)
        {
            await a.Recolor(panel3, Easings.Linear, 1000, Color.FromArgb(255, 128, 0));
        }

        private async void Button8_Click(object sender, EventArgs e)
        {
            await a.MoveRelative(panel4, Easings.Linear, 5000, new Point(-200, 0));
        }

        private async void Button7_Click(object sender, EventArgs e)
        {
            await a.MoveRelative(panel4, Easings.Linear, 5000, new Point(200, 0));
        }
    }
}
