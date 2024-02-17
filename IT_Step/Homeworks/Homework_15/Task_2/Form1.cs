using System;
using System.Drawing;
using System.Windows.Forms;

namespace Task_2
{
    public partial class Form1 : Form
    {
        private int startX;
        private int startY;
        private int number = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.startX = e.X;
                this.startY = e.Y;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var label = new Label
                {
                    BorderStyle = BorderStyle.FixedSingle
                };

                // Define the element's anchor point (upper left corner),
                // based on its start and final coordinates.
                if (e.X > startX && e.Y < startY)
                {
                    label.Location = new Point(startX, e.Y);
                }
                else if (e.X > startX && e.Y > startY)
                {
                    label.Location = new Point(startX, startY);
                }
                else if (e.X < startX && e.Y > startY)
                {
                    label.Location = new Point(e.X, startY);
                }
                else
                {
                    label.Location = new Point(e.X, e.Y);
                }

                // If the element meets the conditions, create it.
                if (Math.Abs(e.X - startX) > 10 && Math.Abs(e.Y - startY) > 10)
                {
                    label.Size = new Size(Math.Abs(e.X - startX), Math.Abs(e.Y - startY));
                    label.Text = $"{number}";
                    label.ForeColor = Color.Black;
                    label.BackColor = Color.DarkGray;

                    // Add the element to the form controls collection.
                    this.Controls.Add(label);

                    // Subscribe to click events on the element.
                    label.MouseClick += LabelMouseClickEvent;
                    label.MouseDoubleClick += LabelMouseDoubleClickEvent;

                    this.number++;
                }
                else
                {
                    MessageBox.Show("The element must be greater than 10х10", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LabelMouseClickEvent(object sender, MouseEventArgs e)
        {
            int labelNumber = 0;

            if (e.Button == MouseButtons.Right)
            {
                foreach (Label item in Controls)
                {
                    // Get the coordinates of the click.
                    Point location = item.PointToScreen(Point.Empty);

                    // Define the element(s) on which the click is made.
                    if (MousePosition.X > location.X &&
                        MousePosition.X < location.X + item.Width &&
                        MousePosition.Y > location.Y &&
                        MousePosition.Y < location.Y + item.Height)
                    {
                        // Select the element with the highest serial number.
                        if (labelNumber < Convert.ToInt32(item.Text))
                        {
                            labelNumber = Convert.ToInt32(item.Text);
                        }

                        this.Text = $"Элемент {item.Text}, " +
                                    $"S = {item.Width * item.Height}, " +
                                    $"Х = {item.Location.X}, " +
                                    $"Y = {item.Location.Y}";
                    }
                }
            }
        }

        private void LabelMouseDoubleClickEvent(object sender, MouseEventArgs e)
        {
            int labelNumber = this.number;

            if (e.Button == MouseButtons.Left)
            {
                foreach (Label item in Controls)
                {
                    // Get the coordinates of the click.
                    Point location = item.PointToScreen(Point.Empty);

                    // Define the element(s) on which the click is made.
                    if (MousePosition.X > location.X &&
                        MousePosition.X < location.X + item.Width &&
                        MousePosition.Y > location.Y &&
                        MousePosition.Y < location.Y + item.Height)
                    {
                        // Select the element with the highest serial number.
                        if (labelNumber > Convert.ToInt32(item.Text))
                        {
                            labelNumber = Convert.ToInt32(item.Text);
                        }
                    }
                }

                foreach (Label item in Controls)
                {
                    // Find the element in a form controls collection
                    if (labelNumber == Convert.ToInt32(item.Text))
                    {
                        // and delete it.
                        Controls.Remove(item);
                        item.MouseClick -= LabelMouseClickEvent;
                        item.MouseDoubleClick -= LabelMouseDoubleClickEvent;
                    }
                }
            }
        }
    }
}
