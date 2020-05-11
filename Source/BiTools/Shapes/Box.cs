using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BiTools.Shapes
{
    public class Box : Shape
    {
        private Graphics _g;
        public override void DrawShape(Graphics g)
        {
            g.FillRectangle(Brushes.Transparent, this.Rectangle);
            g.DrawRectangle(Pens.Red, this.Rectangle);
            _g = g;
        }
        public Image Img
        {
            set
            {
                _g.DrawImage(value, new Point(0, 0));
            }
        }
        
        public override bool In(int x, int y)
        {
            return this.Rectangle.Contains(x, y);
        }
    }
}
