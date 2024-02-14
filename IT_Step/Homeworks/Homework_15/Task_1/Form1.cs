using System;
using System.Threading;
using System.Windows.Forms;

namespace Task_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Left) && Control.ModifierKeys == Keys.Control)
            {
                Environment.Exit(0);
            }

            if (e.Button == MouseButtons.Right)
            {
                this.Text = $"Window width = {this.Width}, Window height = {this.Height}";
                Thread.Sleep(500);
            }

            if (e.Button == MouseButtons.Left)
            {

                if (e.X < 10 ||
                    e.X > this.ClientSize.Width - 10 ||
                    e.Y < 10 ||
                    e.Y > this.ClientSize.Height - 10)
                {
                    MessageBox.Show("This point is outside the rectangle.",
                                    "Selected position", MessageBoxButtons.OK);
                }
                else if ((e.X == 10 || e.X == this.ClientSize.Width - 10) ||
                        (e.Y == 10 || e.Y == this.ClientSize.Height - 10))
                {
                    MessageBox.Show("This point is on the border of the rectangle.",
                                    "Selected position", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("This point is inside the rectangle.",
                                    "Selected position", MessageBoxButtons.OK);
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            this.Text = $"X = {e.X}, Y = {e.Y}";
        }
    }
}
