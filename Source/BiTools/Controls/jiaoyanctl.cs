using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ToolLIbrary.Model;
using BiTools.Marks;
using BiTools.Shapes;
using DevExpress.XtraTreeList;
using DevExpress.Spreadsheet;

namespace BiTools.Controls
{
    public partial class jiaoyanctl : DevExpress.XtraEditors.XtraUserControl
    {
        AbConnector _connector; string _userid;
        public jiaoyanctl(AbConnector connector, string userid)
        {
            InitializeComponent();
            _connector = connector;
            _userid = userid;
            taskpicture.MouseWheel += Taskpicture_MouseWheel;
            taskpicture.Width = IputControl.Panel1.Width;
            taskpicture.Height = IputControl.Panel1.Height;
        }

        private void Taskpicture_MouseWheel(object sender, MouseEventArgs e)
        {
            Input.setmousewheel(taskpicture, canvas, currentemage, e);
        }

        Mark markOnMouseDown = null;
        BiTools.Shapes.Shape shapeOnMouseDown = null;
        Point pointOnMouseDown;
        Point pointInShapeOnMouseDown;
        Canvas canvas = new Canvas();
        List<UserNode> curentsets = new List<UserNode>();
        List<UserNode> addnodes = new List<UserNode>();
        public void Init()
        {
            if (curentsets.Count == 0)
            {

                curentsets = _connector.getTaskByUser(_userid, 3);
                tr_content.BeginUpdate();
                tr_content.DataSource = curentsets;
                tc_nodecolumn.FieldName = "nodename";
                tr_content.KeyFieldName = "_id";
                tr_content.ParentFieldName = "parentid";
                tr_content.ImageIndexFieldName = "stateimageindex";
                tr_content.RefreshDataSource();
                tr_content.EndUpdate();
                tr_content.ExpandAll();
                canvas.Shapes.Clear();
                canvas.Shapes.Add(new Box()
                {
                    Rectangle = new Rectangle(100, 100, 100, 100),
                    UserData = null,

                });
            }
        }

        private void Taskpicture_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (markOnMouseDown != null)
                {
                    markOnMouseDown.MoveTo(e.Location);
                    this.Refresh();
                    return;
                }
                else if (shapeOnMouseDown != null)
                {
                    shapeOnMouseDown.MoveTo(
                        new Point(e.X - pointInShapeOnMouseDown.X,
                            e.Y - pointInShapeOnMouseDown.Y));
                    this.Refresh();
                    this.Cursor = Cursors.SizeAll;
                    return;
                }
            }

            Mark m = canvas.GetMark(e.X, e.Y);
            if (m != null)
                this.Cursor = m.Cursor;
            else
                this.Cursor = Cursors.Default;
        }

        private void Taskpicture_MouseDown(object sender, MouseEventArgs e)
        {
            pointOnMouseDown = e.Location;

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
                markOnMouseDown = canvas.GetMark(e.X, e.Y);
            if (markOnMouseDown != null)
                return;

            shapeOnMouseDown = canvas.GetShape(e.X, e.Y);
            if (shapeOnMouseDown != null)
            {
                pointInShapeOnMouseDown = new Point(
                    e.Location.X -
                    shapeOnMouseDown.Rectangle.Location.X,
                    e.Location.Y -
                    shapeOnMouseDown.Rectangle.Location.Y);
                shapeOnMouseDown.Selected = true;
            }
            else
                canvas.ClearSelection();

            this.Refresh();
        }

        private void Taskpicture_MouseUp(object sender, MouseEventArgs e)
        {
            if (taskpicture.Image != null)
                Input.setimg(currentemage, canvas, taskpicture,taskpicture.Image.Width,taskpicture.Image.Height);
        }

        private void Taskpicture_DoubleClick(object sender, EventArgs e)
        {
            
            if (taskpicture.Image != null)
                Input.setimg(currentemage, canvas, taskpicture, taskpicture.Image.Width, taskpicture.Image.Height);
        }

        private void Taskpicture_Paint(object sender, PaintEventArgs e)
        {
            canvas.Draw(taskpicture, e.Graphics);
        }
        Image currentemage;
        Dictionary<string, Dictionary<string, Dictionary<int, Dictionary<string, object>>>> datas = new Dictionary<string, Dictionary<string, Dictionary<int, Dictionary<string, object>>>>();
        Dictionary<string, Dictionary<string, Dictionary<int, Dictionary<string, object>>>> currentdata = new Dictionary<string, Dictionary<string, Dictionary<int, Dictionary<string, object>>>>();
        Dictionary<string, Dictionary<string, Dictionary<int, Dictionary<string, object>>>> firstdatas = new Dictionary<string, Dictionary<string, Dictionary<int, Dictionary<string, object>>>>();
        Dictionary<string, Dictionary<string, Dictionary<int, Dictionary<string, object>>>> seconddatas = new Dictionary<string, Dictionary<string, Dictionary<int, Dictionary<string, object>>>>();
        private void Taskpicture_SizeChanged(object sender, EventArgs e)
        {
            if(taskpicture.Image !=null)
            Input.setimg(currentemage, canvas, taskpicture, taskpicture.Image.Width, taskpicture.Image.Height);
        }
        string currentconnectionname, currenttaskid;
        private void Tr_content_MouseClick(object sender, MouseEventArgs e)
        {
            TreeListHitInfo hitinfo = tr_content.CalcHitInfo(e.Location);
            if (hitinfo == null || hitinfo.Node == null)
            {
                return;
            }
            var files = Input.setnodestatus(tr_content, hitinfo.Node, ref currentconnectionname, ref currentemage, IputControl, ref currenttaskid, _connector, taskpicture, bar_endrow, span_startrow, span_startcolumn, span_endcolumn, jiaoyanspread, 3, datas,canvas);
            if (files != null)
            {
                firstinputSpread.LoadDocument(files);
                secondinputspread.LoadDocument(files);
                Input.setcurrentbasedata(firstdatas, currentconnectionname, currenttaskid, _connector, 1);
                Input.setcurrentbasedata(seconddatas, currentconnectionname, currenttaskid, _connector, 2);
                Input.setinspread(firstinputSpread, currentconnectionname, currenttaskid, firstdatas);
                Input.setinspread(secondinputspread, currentconnectionname, currenttaskid, seconddatas);
                var taskstatus = hitinfo.Node.GetValue("taskstatus");
                if (
               (bar_endrow.EditValue != null && span_startrow.EditValue != null && span_startcolumn.EditValue != null && span_endcolumn.EditValue != null)
                 && int.TryParse(bar_endrow.EditValue.ToString(), out endrow)
                  && int.TryParse(span_startrow.EditValue.ToString(), out startrow)
                 && int.TryParse(span_startcolumn.EditValue.ToString(), out startcolumn)
                  && int.TryParse(span_endcolumn.EditValue.ToString(), out endcolumn)
                   )
                {


                    if (taskstatus != null && taskstatus.Equals(3))
                    {
                        
                        jiaoyanspread.BeginUpdate();
                        try
                        {
                            var firstdata = firstdatas[currentconnectionname][currenttaskid];
                            var seconddata = seconddatas[currentconnectionname][currenttaskid];
                            if (!datas.ContainsKey(currentconnectionname) ||!datas[currentconnectionname].ContainsKey(currenttaskid))
                                Input.setinspread(jiaoyanspread, currentconnectionname, currenttaskid, seconddatas);
                            else
                                seconddata= datas[currentconnectionname][currenttaskid];
                            for (int i = startrow - 1; i <= endrow - 1; i++)
                            {

                                for (int j = startcolumn - 1; j <= endcolumn - 1; j++)
                                {

                                    var key = string.Format("c{0}", j);
                                    if (firstdata.ContainsKey(i) && firstdata[i].ContainsKey(key)
                                       && seconddata.ContainsKey(i) && seconddata[i].ContainsKey(key)
                                       
                                       )
                                    {
                                        object f = firstdata[i][key];
                                        object s = seconddata[i][key];
                                        if((f==null&&s!=null)||(f!=null&&s==null)
                                            || (f != null && s != null && !f.ToString().Equals(s.ToString()))
                                            )
                                        jiaoyanspread.ActiveWorksheet.Cells[i, j].FillColor = Color.Red;
                                         
                                    }

                                }
                            }
                        }
                        catch
                        {

                        }
                        jiaoyanspread.EndUpdate();
                    }
                }
            }
        }
        public void save()
        {
            Input.save(tr_content.FocusedNode, currenttaskid, currentconnectionname, currentdata, jiaoyanspread, _connector, 3);
            XtraMessageBox.Show("保存完成");
        }
        int endrow = 0,
           startcolumn = 0,
           startrow = 0,
           endcolumn = 0;

        private void Jiaoyanspread_SelectionChanged(object sender, EventArgs e)
        {
            IList<Range> ee = jiaoyanspread.GetSelectedRanges();
            List<Range> firstranage = new List<Range>(),secondrange=new List<Range>();
            foreach (Range r in ee)
            {
                firstranage.Add(firstinputSpread.ActiveWorksheet.Range[r.GetReferenceA1()]);
                secondrange.Add(secondinputspread.ActiveWorksheet.Range[r.GetReferenceA1()]);
            }
            firstinputSpread.SetSelectedRanges(firstranage);
            secondinputspread.SetSelectedRanges(secondrange);
        }
        public void RefreshData()
        {
            if (_connector != null)
            {
                curentsets = _connector.getTaskByUser(_userid, 3);
                tr_content.DataSource = null;
                tr_content.DataSource = curentsets;
            }
        }

        private void IputControl_Panel1_SizeChanged(object sender, EventArgs e)
        {
            Input.setpanelsizechange(currentemage, taskpicture, IputControl.Panel1);
        }

        private void Jiaoyanspread_CellBeginEdit(object sender, DevExpress.XtraSpreadsheet.SpreadsheetCellCancelEventArgs e)
        {
            
        }

        private void Jiaoyanspread_LocationChanged(object sender, EventArgs e)
        {
            
        }

        private void Jiaoyanspread_Click(object sender, EventArgs e)
        {
            Input.setcanvas(jiaoyanspread.ActiveCell.RowIndex, jiaoyanspread.ActiveCell.ColumnIndex, canvas, canvas.Shapes[0].Rectangle.Width, canvas.Shapes[0].Rectangle.Height,
                        jiaoyanspread, taskpicture);
            this.Refresh();
            Input.setimg(currentemage, canvas, taskpicture, taskpicture.Image.Width, taskpicture.Image.Height);
        }

        private void Jiaoyanspread_ScrollPositionChanged(object sender, ScrollPositionChangedEventArgs e)
        {
            //XtraMessageBox.Show(string.Format(@"{0},{1}",e.ColumnIndex,e.RowIndex));
        }

        public void sethidetree(bool t)
        {
            if (t)
            {
                this.tr_content.Visible = false;
            }
            else
                this.tr_content.Visible = true;
        }
        private void Jiaoyanspread_CellValueChanged(object sender, DevExpress.XtraSpreadsheet.SpreadsheetCellEventArgs e)
        {
            if (
                (bar_endrow.EditValue == null || span_startrow.EditValue == null || span_startcolumn.EditValue == null || span_endcolumn.EditValue == null)
                || !int.TryParse(bar_endrow.EditValue.ToString(), out endrow)
               || !int.TryParse(span_startrow.EditValue.ToString(), out startrow)
               || !int.TryParse(span_startcolumn.EditValue.ToString(), out startcolumn)
               || !int.TryParse(span_endcolumn.EditValue.ToString(), out endcolumn)
                )
                return;

            Input.changespreaddata(datas, currentdata, startrow, endrow, startcolumn, endcolumn, currenttaskid, currentconnectionname, jiaoyanspread, 3, e );
        }
      
        public void saveall()
        {
            Input.saveall(currentdata, _connector, 3, jiaoyanspread);
            XtraMessageBox.Show("保存完成");
        }
        public void submit()
        {
            Input.submit(currentdata, _connector, 3, jiaoyanspread,   tr_content);
            XtraMessageBox.Show("提交完成");
        }
    }
}
