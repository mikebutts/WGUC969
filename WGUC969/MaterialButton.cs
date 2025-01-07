using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WGUC969
{
    internal class MaterialButton :  Button
    {
        // Constructor
        public MaterialButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackColor = Color.FromArgb(98, 0, 248); 
            this.ForeColor = Color.White;
            this.Font = new Font("Roboto", 10, FontStyle.Bold);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Smooth edges for drawing
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Create a rounded rectangle
            Rectangle rect = new Rectangle(1, 1, this.Width - 2, this.Height - 2);
            using (GraphicsPath path = CreateRoundedRectanglePath(rect, 8)) // px corner radius
            {
                // Set the region for clipping (ensures proper rounding)
                this.Region = new Region(path);

                // Fill the button background
                using (SolidBrush brush = new SolidBrush(this.BackColor))
                {
                    e.Graphics.FillPath(brush, path);
                }

                // Draw the border
                using (Pen pen = new Pen(Color.Black, 1)) // Change color for testing
                {
                    e.Graphics.DrawPath(pen, path);
                }

                // Draw the text
                TextRenderer.DrawText(e.Graphics, this.Text, this.Font, rect, this.ForeColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

        private GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int cornerRadius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = cornerRadius * 2;

            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            return path;
        }



    }
}
