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
            await a.Resize(panel1, new Size(300, 30), 1000, Easings.Linear);
        }

        private async void Button2_Click(object sender, EventArgs e)
        {
            await a.Resize(panel1, new Size(30, 30), 1000, Easings.Linear);
        }
    }
}
