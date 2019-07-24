using System;
using System.Drawing;
using System.Windows.Forms;
using AnimateForms.Core;

namespace NuGetDemo
{
    public partial class Demo : Form
    {
        private Animate a = new Animate();

        public Demo()
        {
            InitializeComponent();
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            await a.Resize(panel1, new Size(300, 30), 1000, Easings.Linear);
        }
    }
}
