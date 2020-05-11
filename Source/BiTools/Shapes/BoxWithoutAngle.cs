using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;
using System.Drawing;
using BiTools.Marks;

namespace BiTools.Shapes
{
    public class BoxWithoutOneAngle : Shape
    {
        double angleSize = 0.3;
        ShapeMark angleMark;

        public BoxWithoutOneAngle()
        {
            angleMark = new ShapeMark(this) { X = 0.3, Y = 0 };
            this.Marks.Add(angleMark);

            this.RectangleChanged
                += BoxWithoutOneAngle_RectangleChanged;

            MoveMarks();
        }

        public override void OnMarkMoving(Mark mark, ref double newX, ref double newY)
        {
            if (mark == angleMark)
            {
                newY = 0;
                double xDistance = newX * this.Rectangle.Width;
                double refWidth = Math.Min(this.Rectangle.Width, this.Rectangle.Height);
                if (xDistance < 0)
                {
                    newX = 0;
                    this.angleSize = 0;
                }
                else if (xDistance > refWidth)
                {
                    newX = refWidth / this.Rectangle.Width;
                    this.angleSize = 1;
                }
                else
                {
                    this.angleSize = xDistance / refWidth;
                }
                return;
            }

            base.OnMarkMoving(mark, ref newX, ref newY);
        }

        private void MoveMarks()
        {
            if (this.Rectangle.Height >= this.Rectangle.Width)
                this.angleMark.X = this.angleSize;
            else
                this.angleMark.X = this.angleSize * this.Rectangle.Height / this.Rectangle.Width;
        }

        void BoxWithoutOneAngle_RectangleChanged(object sender, EventArgs e)
        {
            MoveMarks();
        }


        public double AngleSize
        {
            get { return angleSize; }
            set { angleSize = value; }
        }



        public override void DrawShape(System.Drawing.Graphics g)
        {
            int x1 = Rectangle.Left;
            int x2 = Rectangle.Right;
            int y1 = Rectangle.Top;
            int y2 = Rectangle.Bottom;

            int aSize =
                (int)(angleSize * Math.Min(Rectangle.Width, Rectangle.Height) + 0.5);

            Point[] points = new Point[5]{
                new Point(x1 , y1 + aSize),
                new Point(x1 + aSize, y1),
                new Point(x2, y1),
                new Point(x2, y2),
                new Point(x1, y2)};

            g.FillPolygon(Brushes.Yellow, points);
            g.DrawPolygon(Pens.Black, points);
        }

        protected override Region GetUserDataRegion()
        {
            int x1 = Rectangle.Left;
            int x2 = Rectangle.Right;
            int y1 = Rectangle.Top;
            int y2 = Rectangle.Bottom;

            int aSize =
                (int)(angleSize * Math.Min(Rectangle.Width, Rectangle.Height) + 0.5);

            Point[] points = new Point[5]{
                new Point(x1 , y1 + aSize),
                new Point(x1 + aSize, y1),
                new Point(x2, y1),
                new Point(x2, y2),
                new Point(x1, y2)};

            GraphicsPath path = new GraphicsPath(points,
                new Byte[5] { 1, 1, 1, 1, 1 });
            return new Region(path);
        }

        public override bool In(int x, int y)
        {
            Rectangle rect = this.Rectangle;
            if (!rect.Contains(x, y)) return false;
            if (x + y - rect.Left - rect.Top < angleSize)
                return false;

            return true;
        }
    }
}
