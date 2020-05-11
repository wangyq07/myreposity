using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using BiTools.Marks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Drawing.Drawing2D;

namespace BiTools.Shapes
{
    public class Canvas
    {
        public Canvas()
        {
            shapes = new ShapeCollection(this);
        }

        ShapeCollection shapes;
        Control _ctl;
        public ShapeCollection Shapes
        {
            get { return shapes; }
        }
        public Control cont
        {
            get
            {
                return _ctl;
            }
        }


        public void Draw(Control ctrl)
        {
            Graphics g = ctrl.CreateGraphics();
            
            Draw(ctrl,g);
           
            g.Dispose();
        }

        public void Draw(Control ctrl,Graphics g)
        {
            g.TextRenderingHint = TextRenderingHint.AntiAlias;
            g.SmoothingMode = SmoothingMode.HighQuality;
            
            //g.Clear(Color.White);
            foreach (Shape s in shapes)
                s.Draw(g);

            foreach (Shape s in shapes)
                if (s.Selected)
                    s.DrawMark(g);
            _ctl = ctrl;
        }

        public Shape GetShape(int x, int y)
        {
            for (int i = shapes.Count - 1; i >= 0; --i)
                if (shapes[i].In(x, y))
                    return shapes[i];
            return null;
        }

        public void ClearSelection()
        {
            foreach (Shape s in shapes)
                s.Selected = false;
        }

        public Marks.Mark GetMark(int x, int y)
        {
            foreach (Shape s in shapes)
                if (s.Selected)
                    for (int i = s.Marks.Count - 1; i >= 0; i--)
                    {
                        Mark m = s.Marks[i];
                        if (m.In(x, y))
                            return m;
                    }
            return null;
        }

    }
}
