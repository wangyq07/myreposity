using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BiTools.Shapes;
using System.Windows.Forms;

namespace BiTools.Marks
{
    public class MarkCollection : List<Mark>
    {
        Shape shape;
        public MarkCollection(Shape parentShape)
        {
            shape = parentShape;
        }

        public void AddRange(params SizeMark[] marks)
        {
            base.AddRange(marks);
        }
    }
}
