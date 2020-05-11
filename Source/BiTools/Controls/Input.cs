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
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System.IO;
using System.Drawing.Imaging;
using BiTools.Marks;
using BiTools.Shapes;
using DevExpress.XtraSpreadsheet;
using DevExpress.XtraBars;

namespace BiTools.Controls
{
    public partial class Input : DevExpress.XtraEditors.XtraUserControl
    {
        AbConnector _connector; int _inputstatus; string _userid;
        public Input(string userid, int inputstatus, AbConnector connector)
        {
            InitializeComponent();
            _connector = connector;
            _inputstatus = inputstatus;
            _userid = userid;
            taskpicture.MouseWheel += Taskpicture_MouseWheel;
            taskpicture.Width = IputControl.Panel1.Width;
            taskpicture.Height = IputControl.Panel1.Height; 
        }
        public static void setmousewheel(PictureBox taskpicture,Canvas canvas,Image currentemage,MouseEventArgs e)
        {
            if (taskpicture.Image == null)
                return;
            Size t = taskpicture.Image.Size;
            t.Width += e.Delta;
            t.Height += e.Delta;

            if( (t.Width <=100 || t.Height <=100)
                || t.Width>=1920||t.Height>=1080
                )
                return;
            //canvas.Shapes[0].Rectangle = new Rectangle(canvas.Shapes[0].Rectangle.X, canvas.Shapes[0].Rectangle.Y, t.Width / 12, t.Height / 2);
            if (taskpicture.Image != null)
                setimg(currentemage, canvas, taskpicture, t.Width, t.Height);
            taskpicture.Width = t.Width;
            taskpicture.Height = t.Height;
        }
        private void Taskpicture_MouseWheel(object sender, MouseEventArgs e)
        {
            setmousewheel(taskpicture, canvas, currentemage, e);


        }
         
        Mark markOnMouseDown = null;
        Shape shapeOnMouseDown = null;
        Point pointOnMouseDown;
        Point pointInShapeOnMouseDown;
        Canvas canvas = new Canvas();
        List<UserNode> curentsets = new List<UserNode>();
        List<UserNode> addnodes = new List<UserNode>();
        public void Init()
        {
            if (curentsets.Count == 0)
            {
                curentsets = _connector.getTaskByUser(_userid, _inputstatus);
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
                    Rectangle = new Rectangle(100, 100,100,100),
                    UserData = null,

                });
            }
        }
        public void RefreshData()
        {
            if(_connector !=null)
            { 
              curentsets = _connector.getTaskByUser(_userid, _inputstatus);
                tr_content.DataSource = null;
                tr_content.DataSource = curentsets;
                datas = new Dictionary<string, Dictionary<string, Dictionary<int, Dictionary<string, object>>>>();
                currentdata = new Dictionary<string, Dictionary<string, Dictionary<int, Dictionary<string, object>>>>();
            }
        }
        
        public static void setinspread(SpreadsheetControl inputSpread,string currentconnectionname,
            string currenttaskid, Dictionary<string, Dictionary<string, Dictionary<int, Dictionary<string, object>>>> datas
            )
        {
            inputSpread.BeginUpdate();
            try
            {
                if (datas.ContainsKey(currentconnectionname) && datas[currentconnectionname].ContainsKey(currenttaskid))
                {
                    foreach (int i in datas[currentconnectionname][currenttaskid].Keys)
                    {
                        for (int j = 0; j < datas[currentconnectionname][currenttaskid][i].Count; j++)
                        {
                            var keyname = string.Format("c{0}", j);
                            if (datas[currentconnectionname][currenttaskid][i].ContainsKey(keyname))
                                inputSpread.ActiveWorksheet.Cells[i, j].SetValue(datas[currentconnectionname][currenttaskid][i][keyname]);
                        }
                    }
                }
            }
            catch
            {

            }
            inputSpread.EndUpdate();
        }
        private void PictureEdit1_MouseDown(object sender, MouseEventArgs e)
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

        private void BarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (tr_content.FocusedNode != null && tr_content.FocusedNode.GetValue("_id") != null)
            {
                _connector.updateendrow(tr_content.FocusedNode.GetValue("_id").ToString(),bar_endrow.EditValue.ToString());
            }
        }
        
        //Dictionary<string, string> currentsubmit = new Dictionary<string, string>();
        public static void submit(Dictionary<string, Dictionary<string, Dictionary<int, Dictionary<string, object>>>> currentdata
            ,AbConnector _connector, int _inputstatus, SpreadsheetControl inputSpread, TreeList trcontent)
        {
            saveall(currentdata,_connector,_inputstatus,inputSpread);
            
           var nodes= trcontent.FindNodes(c => c.GetValue("nodetype").ToString().Equals("task"));
            Dictionary<string, TreeListNode> tns = new Dictionary<string, TreeListNode>();
            Dictionary<string, Dictionary<string, int>> input = new Dictionary<string, Dictionary<string, int>>();
            foreach(TreeListNode tn in nodes)
            {
                List<string> names = new List<string>();
                recursernames(tn.ParentNode,names);
                string collectionname = string.Join("_",names.ToArray());
                var id = tn.GetValue("_id") ;
                if(id !=null)
                {
                    tns.Add(id.ToString(), tn);
                    if(!input.ContainsKey(collectionname))
                    {
                        input.Add(collectionname,new Dictionary<string, int>());
                    }
                    input[collectionname].Add(id.ToString(), 0);
                }
            }
            Dictionary<string, int> outputtask= _connector.getmaxstatus(input);
            foreach(string key in outputtask.Keys)
            {
                if (tns.ContainsKey(key))
                {
                    var ttn = tns[key];
                    if (ttn != null)
                    { 
                    int tasktatus;
                    var taskstatusdata = ttn.GetValue("taskstatus");
                        if(taskstatusdata !=null &&int.TryParse(taskstatusdata.ToString(),out tasktatus))
                        { 
                            if(tasktatus <= outputtask[key])
                            {
                             tasktatus = tasktatus + 1;
                             _connector.updatetaskstatus(key, tasktatus.ToString());
                            ttn.SetValue("taskstatus", tasktatus);
                            }
                        }
                    }
                }

            }
            inputSpread.ReadOnly = true;

        }
        public static void save(TreeListNode tn, string currenttaskid,string currentconnectionname,
            Dictionary<string, Dictionary<string, Dictionary<int, Dictionary<string, object>>>> currentdata
            ,SpreadsheetControl inputSpread,AbConnector _connector,int _inputstatus
            )
        {
            if (!string.IsNullOrEmpty(currenttaskid)
                && !string.IsNullOrEmpty(currentconnectionname)
                && currentdata.ContainsKey(currentconnectionname)
                && currentdata[currentconnectionname].ContainsKey(currenttaskid)
                )
            {
                inputSpread.CloseCellEditor(DevExpress.XtraSpreadsheet.CellEditorEnterValueMode.SelectedCells);
                var tempdata = new Dictionary<string, Dictionary<string, Dictionary<int, Dictionary<string, object>>>>();
                tempdata.Add(currentconnectionname, new Dictionary<string, Dictionary<int, Dictionary<string, object>>>());
                tempdata[currentconnectionname].Add(currenttaskid, currentdata[currentconnectionname][currenttaskid]);
                _connector.updatecolectiondata(tempdata); 
                currentdata[currentconnectionname].Remove(currenttaskid); 
            }
           
        }
         
        public static void saveall(Dictionary<string, Dictionary<string, Dictionary<int, Dictionary<string, object>>>> currentdata,AbConnector _connector,int _inputstatus,SpreadsheetControl inputSpread)
        {
            if (currentdata.Count > 0)
            {
                inputSpread.CloseCellEditor(DevExpress.XtraSpreadsheet.CellEditorEnterValueMode.SelectedCells);
                _connector.updatecolectiondata(currentdata);
                currentdata.Clear(); 

            }
            
        }
        public void submit()
        {
            submit(currentdata, _connector, _inputstatus, inputSpread,  tr_content);
            XtraMessageBox.Show("提交完成");
        }
        public void save()
        {
            save(tr_content.FocusedNode,currenttaskid, currentconnectionname, currentdata, inputSpread, _connector, _inputstatus);
            XtraMessageBox.Show("保存成功!");
        }
        public void saveall()
        {
            saveall(currentdata, _connector,_inputstatus, inputSpread);
            XtraMessageBox.Show("保存成功!");

        }
        Image currentemage;
        public static void setcurrentbasedata(Dictionary<string, Dictionary<string, Dictionary<int, Dictionary<string, object>>>> datas,string currentconnectionname,string currenttaskid,AbConnector _connector,int _inputstatus)
        {
            if (!datas.ContainsKey(currentconnectionname) || !datas[currentconnectionname].ContainsKey(currenttaskid))
            {
                var tempdata = _connector.getcolectiondata(currenttaskid, currentconnectionname, _inputstatus>3?3:_inputstatus);
                if (tempdata.Count > 0)
                {
                    if (!datas.ContainsKey(currentconnectionname))
                    {
                        datas.Add(currentconnectionname, new Dictionary<string, Dictionary<int, Dictionary<string, object>>>());
                        
                    }
                    if (datas[currentconnectionname].ContainsKey(currenttaskid))
                    {
                        datas[currentconnectionname].Remove(currenttaskid);
                    }
                    datas[currentconnectionname].Add(currenttaskid, tempdata);
                }
            }
        }
       public  static int startrowindex = 0, startcolumnindex = 0,startoriginalx=0,startoriginaly=0,orignalheight=0,endrowindex=0;
        public static byte[] setnodestatus(TreeList tr_content, TreeListNode tn,ref string currentconnectionname,ref Image currentemage,SplitContainerControl IputControl,ref string currenttaskid,AbConnector _connector,PictureBox taskpicture,
            BarEditItem bar_endrow,BarEditItem span_startrow,BarEditItem span_startcolumn,BarEditItem span_endcolumn
            ,SpreadsheetControl inputSpread,int _inputstatus, Dictionary<string, Dictionary<string, Dictionary<int, Dictionary<string, object>>>> datas,Canvas canvas 
            )
        {
            byte[] files = null;
            if (tr_content.FocusedNode == null)
            {
                return files;
            }
            tr_content.SetFocusedNode(tn);
            TypeNode nodetype = TypeNode.node;
            object typ = tn.GetValue("nodetype");
            object _id = tn.GetValue("_id");
            if (typ is TypeNode && typ != null)
            {
                nodetype = (TypeNode)typ;
            }
            IputControl.Visible = false;
            if (nodetype.Equals(TypeNode.task))
            {
                List<string> parentnames = new List<string>();
                recursernames(tn.ParentNode, parentnames);
                currentconnectionname = string.Join("_", parentnames.ToArray());
                IputControl.Visible = true;
                if (_id != null)
                {
                    currentemage = new Bitmap(new MemoryStream(_connector.getfile(_id.ToString())));
                    currenttaskid = _id.ToString();
                    if (taskpicture.Width == 0)
                        taskpicture.Width = IputControl.Panel1.Width;
                    if(taskpicture.Height==0)
                        taskpicture.Height = IputControl.Panel1.Height;
                    Bitmap bbm = new Bitmap(currentemage, taskpicture.Width, taskpicture.Height);
                    taskpicture.Image = bbm;
                    //setimg(currentemage, canvas, taskpicture, currentemage.Width, currentemage.Height);
                    setcurrentbasedata(datas,currentconnectionname,currenttaskid,_connector,_inputstatus);

                }
                inputSpread.CloseCellEditor(DevExpress.XtraSpreadsheet.CellEditorEnterValueMode.SelectedCells);
                object parentid = tn.GetValue("parentid");
                if(parentid !=null)
                {
                    files = _connector.getfile(parentid.ToString());
                    inputSpread.LoadDocument(files);
                    span_startcolumn.EditValue = tn.ParentNode.GetValue("startcolumn");
                    span_endcolumn.EditValue = tn.ParentNode.GetValue("endcolumn");
                    span_startrow.EditValue = tn.ParentNode.GetValue("startrow");
                    bar_endrow.EditValue = tn.ParentNode.GetValue("endrow");
                    var visiblerange = inputSpread.VisibleRange;
                    int startrow,endrow;
                    if(span_startrow.EditValue !=null&&int.TryParse(span_startrow.EditValue.ToString(),out startrow)
                        &&bar_endrow.EditValue !=null&&int.TryParse(bar_endrow.EditValue.ToString(),out endrow)
                        )
                    { 
                        inputSpread.ActiveWorksheet.FreezePanes(startrow-1, 1,visiblerange);
                        startrowindex = startrow - 1;
                        inputSpread.SetSelectedRanges(new List<DevExpress.Spreadsheet.Range>() { inputSpread.ActiveWorksheet.Cells[startrow - 1, 0] });
                        startoriginalx = taskpicture.Location.X +100;
                        startoriginaly = taskpicture.Location.Y+100;
                        endrowindex =endrow-1;
                        orignalheight = taskpicture.Height / 2;
                        setcanvas(startrowindex, startcolumnindex, canvas, taskpicture.Width/15, taskpicture.Height/2,
                        inputSpread,taskpicture);
                    }
                }
                inputSpread.ReadOnly = false;
                setinspread(inputSpread,currentconnectionname,currenttaskid,datas);
                object taskstatus = tn.GetValue("taskstatus");
                if(taskstatus !=null&&(!taskstatus.Equals(_inputstatus)||taskstatus.Equals(4)))
                {
                    inputSpread.ReadOnly = true;
                }
            }
            return files;
        }
        public static void setcanvas(int currentrowindex,int currentcolindex,Canvas canvas,int with,int height,SpreadsheetControl spreadsheet,PictureBox taskpicture)
        {
            int startr = startoriginalx,
                startc = startoriginaly;
               height = taskpicture.Height-150;
             for(int i=startcolumnindex+1;i<=currentcolindex;i++)
            {
                startr += with+(int)spreadsheet.ActiveWorksheet.Columns[i].ColumnWidth/15;
            }
            for(int j=startrowindex+1;j<=currentrowindex;j++)
            {
                startc +=(int) spreadsheet.ActiveWorksheet.Rows[j].RowHeight/ 15;
            }
            for(int k= startrowindex ; k<= currentrowindex; k++)
            {
                height -= (int)spreadsheet.ActiveWorksheet.Rows[k].RowHeight/ 15;
            }
            int maxpositionx= taskpicture.Location.X + taskpicture.Image.Width;
            int maxpositiony = taskpicture.Location.Y + taskpicture.Image.Height;
             if((startr+with)<maxpositionx&&(startc + height)<maxpositiony)
            {
                canvas.Shapes[0].Rectangle = new Rectangle(startr,startc, with, height);
            }
           
        }
        private void Tr_content_MouseClick(object sender, MouseEventArgs e)
        {
            TreeListHitInfo hitinfo = tr_content.CalcHitInfo(e.Location);
            if (hitinfo == null || hitinfo.Node == null)
            {
                return;
            }
            setnodestatus(tr_content,hitinfo.Node,ref currentconnectionname,ref currentemage,IputControl,ref currenttaskid,_connector,taskpicture,bar_endrow,span_startrow,span_startcolumn,span_endcolumn,inputSpread,_inputstatus,datas,canvas);
        }
        /// <summary>
        /// 图像明暗调整
        /// </summary>
        /// <param name="b">原始图</param>
        /// <param name="degree">亮度[-255, 255]</param>
        /// <returns></returns>
        public static Bitmap KiLighten(Bitmap b, int degree, Rectangle rect)
        {
            if (b == null)
            {
                return null;
            }

            if (degree < -255) degree = -255;
            if (degree > 255) degree = 255;

            try
            {

                int width = rect.Width;
                int height = rect.Height;

                int pix = 0;

                BitmapData data = b.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                unsafe
                {
                    byte* p = (byte*)data.Scan0;
                    int offset = data.Stride - width * 3;
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            // 处理指定位置像素的亮度
                            for (int i = 0; i < 3; i++)
                            {
                                pix = p[i] + degree;

                                if (degree < 0) p[i] = (byte)Math.Max(0, pix);
                                if (degree > 0) p[i] = (byte)Math.Min(255, pix);

                            }
                            p += 3;
                        }
                        p += offset;
                    }
                }

                b.UnlockBits(data);

                return new Bitmap(b);
            }
            catch(Exception ex)
            {
                return b;
            }

        }
        public static void setimg(Image currentemage,Canvas canvas,PictureBox taskpicture,int width,int height)
        {
            try
            {
                
                if (canvas.Shapes.Count > 0)
                {
                    int x = canvas.Shapes[0].Rectangle.X,
                      y = canvas.Shapes[0].Rectangle.Y;
                    int setrwidth = canvas.Shapes[0].Rectangle.Width;
                    int setheight = canvas.Shapes[0].Rectangle.Height;
                    if (setrwidth < 0)
                        setrwidth = 10;
                    if (canvas.Shapes[0].Rectangle.Height < 0)
                        setheight = 10;

                    if (x > (taskpicture.Image.Width + taskpicture.Location.X- setrwidth))
                    {
                        x = taskpicture.Image.Width + taskpicture.Location.X - setrwidth - 10;
                    }
                    else if (x < 0)
                    {
                        x = 30;
                    }
                    if (y > (taskpicture.Image.Height + taskpicture.Location.Y- setheight))
                    {
                        y = taskpicture.Image.Height + taskpicture.Location.Y - setheight - 10;
                    }
                    else if (y < 0)
                    {
                        y = 30;
                    }
                   
                        canvas.Shapes[0].Rectangle = new Rectangle(x,y, setrwidth, setheight);
                    var bbm = new Bitmap(currentemage,  width, height);
                    bbm = KiLighten(bbm, -50, new Rectangle(0, 0, bbm.Width, bbm.Height));
                    bbm = KiLighten(bbm, 50, new Rectangle(canvas.Shapes[0].Rectangle.X, canvas.Shapes[0].Rectangle.Y,
                                                  setrwidth, setheight));
                    taskpicture.Image = bbm;
                }
            }
            catch(Exception ex)
            {

            }

        }
        private void Taskpicture_SizeChanged(object sender, EventArgs e)
        {
            if(taskpicture.Image !=null)
            setimg(currentemage,canvas,taskpicture,taskpicture.Image.Width,taskpicture.Image.Height);
        }

        private void Taskpicture_Enter(object sender, EventArgs e)
        {
           
        }

        private void Taskpicture_MouseUp(object sender, MouseEventArgs e)
        {
            if (taskpicture.Image != null)
            {
                
                setimg(currentemage, canvas, taskpicture, taskpicture.Image.Width, taskpicture.Image.Height);
            }
            
        }

        private void Taskpicture_Paint(object sender, PaintEventArgs e)
        {
            canvas.Draw(taskpicture, e.Graphics);
            
        }

        private void Taskpicture_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                //if (e.Location.X > (taskpicture.Image.Width + taskpicture.Location.X)
                //    || e.Location.Y > (taskpicture.Image.Height + taskpicture.Location.Y
                //    ))
                //    return;
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
        public void sethori()
        {
            IputControl.Horizontal = false;
        }
        public void setveri()
        {
            IputControl.Horizontal = true;
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

        private void Taskpicture_DoubleClick(object sender, EventArgs e)
        {
            if (taskpicture.Image != null)
            {
                setimg(currentemage, canvas, taskpicture, taskpicture.Image.Width, taskpicture.Image.Height);
           
            }
        }

        private void Bar_endrow_EditValueChanged(object sender, EventArgs e)
        {
            if (tr_content.FocusedNode != null && tr_content.FocusedNode.GetValue("_id") != null)
            {
                _connector.updateendrow(tr_content.FocusedNode.GetValue("_id").ToString(), bar_endrow.EditValue.ToString());
                tr_content.FocusedNode.SetValue("endrow",bar_endrow.EditValue);
            }
        }
       
        Dictionary<string, Dictionary<string, Dictionary<int, Dictionary<string, object>>>> datas = new Dictionary<string, Dictionary<string, Dictionary<int, Dictionary<string, object>>>>();
        Dictionary<string, Dictionary<string, Dictionary<int, Dictionary<string, object>>>> currentdata = new Dictionary<string, Dictionary<string, Dictionary<int, Dictionary<string, object>>>>();
        public static void adddictionary(Dictionary<string, Dictionary<string, Dictionary<int, Dictionary<string, object>>>> ddatas
                                   ,int startrow,int endrow,int startcolumn,int endcolumn,string currenttaskid,string currentconnectionname,SpreadsheetControl inputSpread,int _inputstatus)
        { 
            if(!ddatas.ContainsKey(currentconnectionname))
            ddatas.Add(currentconnectionname, new Dictionary<string, Dictionary<int, Dictionary<string, object>>>()); 
            ddatas[currentconnectionname].Add(currenttaskid, new Dictionary<int, Dictionary<string, object>>()); 
            for (int i = startrow - 1; i <= endrow - 1; i++)
            {
                ddatas[currentconnectionname][currenttaskid].Add(i, new Dictionary<string, object>()); 
                ddatas[currentconnectionname][currenttaskid][i].Add("taskid", currenttaskid);
                ddatas[currentconnectionname][currenttaskid][i].Add("taskstatus", _inputstatus);
                ddatas[currentconnectionname][currenttaskid][i].Add("rowindex",i);
                for (int j = startcolumn - 1; j <= endcolumn - 1; j++)
                {
                    var v = inputSpread.ActiveWorksheet.Cells[i, j].Value;
                  
                    ddatas[currentconnectionname][currenttaskid][i].Add(string.Format("c{0}", j), v !=null?v.ToObject():null);
                   
                }
            }
        }
        public static void changespreaddata(Dictionary<string, Dictionary<string, Dictionary<int, Dictionary<string, object>>>> datas
            ,Dictionary<string, Dictionary<string, Dictionary<int, Dictionary<string, object>>>> currentdata
             , int startrow, int endrow, int startcolumn, int endcolumn, string currenttaskid, string currentconnectionname, SpreadsheetControl inputSpread, int _inputstatus
            ,DevExpress.XtraSpreadsheet.SpreadsheetCellEventArgs e 
            )
        {

            if (e.RowIndex <= endrow - 1
                && e.RowIndex >= startrow - 1
                && e.ColumnIndex <= endcolumn - 1
                && e.ColumnIndex >= startcolumn - 1
                )
            {
                if (datas.ContainsKey(currentconnectionname) && datas[currentconnectionname].Count == 0)
                {
                    datas.Remove(currentconnectionname);
                }
                if (currentdata.ContainsKey(currentconnectionname) && currentdata[currentconnectionname].Count == 0)
                {
                    currentdata.Remove(currentconnectionname);
                  
                }
                if (datas.ContainsKey(currentconnectionname) && datas[currentconnectionname].ContainsKey(currenttaskid)
                    && datas[currentconnectionname][currenttaskid].Count == 0
                    )
                {
                    datas[currentconnectionname].Remove(currenttaskid);
                }
                if (currentdata.ContainsKey(currentconnectionname) && currentdata[currentconnectionname].ContainsKey(currenttaskid)
                   && currentdata[currentconnectionname][currenttaskid].Count == 0
                   )
                {
                    currentdata[currentconnectionname].Remove(currenttaskid);
                    
                }
                if (!datas.ContainsKey(currentconnectionname) || !datas[currentconnectionname].ContainsKey(currenttaskid)
                    )
                {
                    adddictionary(datas, startrow, endrow, startcolumn, endcolumn, currenttaskid, currentconnectionname, inputSpread, _inputstatus);
                    adddictionary(currentdata, startrow, endrow, startcolumn, endcolumn, currenttaskid, currentconnectionname, inputSpread, _inputstatus);
                    
                }
                else if (datas.ContainsKey(currentconnectionname) && datas[currentconnectionname].ContainsKey(currenttaskid)
                     && (!currentdata.ContainsKey(currentconnectionname) || !currentdata[currentconnectionname].ContainsKey(currenttaskid)))
                {

                    object v = e.Value != null ? e.Value.ToObject() : null;
                    object f = datas[currentconnectionname][currenttaskid][e.RowIndex][string.Format("c{0}", e.ColumnIndex)];
                    if (v == null && f != null)
                    {
                        adddictionary(currentdata, startrow, endrow, startcolumn, endcolumn, currenttaskid, currentconnectionname, inputSpread, _inputstatus);
                        datas[currentconnectionname][currenttaskid][e.RowIndex][string.Format("c{0}", e.ColumnIndex)] = v;
                    }
                    else if (!v.Equals(f))
                    {
                        adddictionary(currentdata, startrow, endrow, startcolumn, endcolumn, currenttaskid, currentconnectionname, inputSpread, _inputstatus);
                      
                        datas[currentconnectionname][currenttaskid][e.RowIndex][string.Format("c{0}", e.ColumnIndex)] = v;
                    }
                }
                else if (datas.ContainsKey(currentconnectionname) && datas[currentconnectionname].ContainsKey(currenttaskid)
                     && (currentdata.ContainsKey(currentconnectionname) && currentdata[currentconnectionname].ContainsKey(currenttaskid)))
                {
                    object v = e.Value != null ? e.Value.ToObject() : null;
                    object f = datas[currentconnectionname][currenttaskid][e.RowIndex][string.Format("c{0}", e.ColumnIndex)];
                    if (v == null && f != null)
                    {
                        currentdata[currentconnectionname][currenttaskid][e.RowIndex][string.Format("c{0}", e.ColumnIndex)] = v;
                        datas[currentconnectionname][currenttaskid][e.RowIndex][string.Format("c{0}", e.ColumnIndex)] = v;
                    }
                    else if (!v.Equals(f))
                    {
                        currentdata[currentconnectionname][currenttaskid][e.RowIndex][string.Format("c{0}", e.ColumnIndex)] = v;
                        datas[currentconnectionname][currenttaskid][e.RowIndex][string.Format("c{0}", e.ColumnIndex)] = v;
                    }
                }
            }
        }
        int endrow = 0,
            startcolumn = 0,
            startrow = 0,
            endcolumn = 0;
        private void InputSpread_CellValueChanged(object sender, DevExpress.XtraSpreadsheet.SpreadsheetCellEventArgs e)
        {
           
            if (
                (bar_endrow.EditValue==null|| span_startrow.EditValue==null||span_startcolumn.EditValue==null||span_endcolumn.EditValue==null)
                ||!int.TryParse(bar_endrow.EditValue.ToString(),out endrow)
               ||!int.TryParse(span_startrow.EditValue.ToString(), out startrow)
               || !int.TryParse(span_startcolumn.EditValue.ToString(), out startcolumn)
               || !int.TryParse(span_endcolumn.EditValue.ToString(), out endcolumn)
                )
                return;

                changespreaddata(datas,currentdata,startrow,endrow,startcolumn,endcolumn,currenttaskid,currentconnectionname,inputSpread,_inputstatus,e);

            
        }
        public static void setpanelsizechange(Image currentemage,PictureBox taskpicture,SplitGroupPanel panel)
        {
            if (panel.Width == 0 || panel.Height == 0)
                return;
            if (currentemage != null && taskpicture.Image != null && taskpicture.Image.Width <= taskpicture.Width
               && taskpicture.Image.Height <= taskpicture.Height
               )
            {
                taskpicture.Width = panel.Width;
                taskpicture.Height = panel.Height;
                if (taskpicture.Width == 0 || taskpicture.Height == 0)
                    return;
                var bbm = new Bitmap(currentemage, taskpicture.Width, taskpicture.Height);
                taskpicture.Image = bbm;
            }
        }
        private void IputControl_Panel1_SizeChanged(object sender, EventArgs e)
        {

            setpanelsizechange(currentemage, taskpicture, IputControl.Panel1);


        }

        private void Taskpicture_RegionChanged(object sender, EventArgs e)
        {

        }

        private void InputSpread_Click(object sender, EventArgs e)
        {
            setcanvas(inputSpread.ActiveCell.RowIndex, inputSpread.ActiveCell.ColumnIndex,canvas, canvas.Shapes[0].Rectangle.Width, canvas.Shapes[0].Rectangle.Height,
                        inputSpread, taskpicture);
            this.Refresh();
            setimg(currentemage,canvas,taskpicture,taskpicture.Image.Width,taskpicture.Image.Height);
        }

        string currentconnectionname;
        string currenttaskid;
        private static void recursernames(TreeListNode tn, List<string> parentnames)
        {
            parentnames.Add(tn.GetValue("nodename").ToString());
            if (tn.ParentNode != null && tn.ParentNode.ParentNode != null)
            {
                recursernames(tn.ParentNode, parentnames);
            }


        }
    }
}
