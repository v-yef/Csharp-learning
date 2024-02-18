using System.Windows.Forms;

namespace Task_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            // Check whether the cursor is inside the rectangular area around the element.
            if ((e.X > label1.Location.X - 50) &&
                (e.X < label1.Location.X + label1.Width + 50) &&
                (e.Y > label1.Location.Y - 50) &&
                (e.Y < label1.Location.Y + label1.Height + 50))
            {
                // Define the side of cursor's approach and move the element to the opposite.
                // Cursor is on the left.
                if ((e.X > label1.Location.X - 10) &&
                    (e.X < label1.Location.X))
                {
                    label1.Left += 10;
                }
                // Cursor is on the right.
                else if ((e.X < label1.Location.X + label1.Width + 10) &&
                        (e.X > label1.Location.X + label1.Width))
                {
                    label1.Left -= 10;
                }
                // Cursor is on the top.
                else if ((e.Y > label1.Location.Y - 10) &&
                        (e.Y < label1.Location.Y))
                {
                    label1.Top += 10;
                }
                // Cursor is on the bottom.
                else if ((e.Y < label1.Location.Y + label1.Height + 10) &&
                        (e.Y > label1.Location.Y + label1.Height))
                {
                    label1.Top -= 10;
                }

                // Returns the element to the center if it reaches the window border.
                if ((label1.Location.X < 0) ||
                    (label1.Location.X > ClientSize.Width - label1.Width) ||
                    (label1.Location.Y < 0) ||
                    (label1.Location.Y > ClientSize.Height - label1.Height))
                {
                    label1.Left = (ClientSize.Width - label1.Size.Width) / 2;
                    label1.Top = (ClientSize.Height - label1.Size.Height) / 2;
                }
            }
        }
    }
}
