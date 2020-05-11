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
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList;
using System.IO;

namespace BiTools.Controls
{
    public partial class Tasks : DevExpress.XtraEditors.XtraUserControl
    {
        public EventHandler Savetemplateform;
        public Tasks()
        {
            InitializeComponent();
            task_picture.MouseWheel += Task_picture_MouseWheel;
        }

        private void Task_picture_MouseWheel(object sender, MouseEventArgs e)
        {

            Size t = task_picture.Image.Size;
            t.Width += e.Delta;
            t.Height += e.Delta;
            if (t.Width < 0 || t.Height < 0)
                return;
            Bitmap tempbitmap = new Bitmap(currentemage, t.Width, t.Height);
            task_picture.Image = tempbitmap;
        }
        Image currentemage;
        private void setnodestatus(TreeListNode tn)
        {
            if (tr_content.FocusedNode == null)
            {
                return;
            }

            tr_content.SetFocusedNode(tn);

            templeteandtaskpicture.Visible = true;
            TypeNode nodetype = TypeNode.node;
            object typ =tn.GetValue("nodetype");
            object _id = tn.GetValue("_id");
            if (typ is TypeNode && typ != null)
            {
                nodetype = (TypeNode)typ;
            }
            btn_deleteNode.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            bar_addnode.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            bar_addtemplete.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            bar_addtask.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            if (tr_content.FocusedNode.ParentNode != null)
            {
                if (nodetype.Equals(TypeNode.node))
                {

                    bar_addtask.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    templeteandtaskpicture.Visible = false;
                }
                else if (nodetype.Equals(TypeNode.templete))
                {
                    templeteandtaskpicture.PanelVisibility = SplitPanelVisibility.Panel2;
                    bar_addnode.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    bar_addtemplete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    if(_id !=null)
                    {
                        spread_templete.LoadDocument(_connector.getfile(_id.ToString()));
                        span_startrow.EditValue = tn.GetValue("startrow");
                        span_startcolumn.EditValue = tn.GetValue("startcolumn");
                        span_endcolumn.EditValue = tn.GetValue("endcolumn");
                        span_endrow.EditValue= tn.GetValue("endrow");
                    }
                }
                else if (nodetype.Equals(TypeNode.task))
                {
                    templeteandtaskpicture.PanelVisibility = SplitPanelVisibility.Panel1;
                    bar_addnode.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    bar_addtemplete.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    bar_addtask.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    if (_id != null)
                    {
                        currentemage = new Bitmap(new MemoryStream(_connector.getfile(_id.ToString())));
                        task_picture.Image = new Bitmap(currentemage,task_picture.Width,task_picture.Height);
                    }
                }
            }
            else
            {
                btn_deleteNode.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                bar_addtask.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                templeteandtaskpicture.Visible = false;

            }
           
        }
        private void Tr_content_MouseClick(object sender, MouseEventArgs e)
        {
            TreeListHitInfo hitinfo = tr_content.CalcHitInfo(e.Location);
            if (hitinfo == null || hitinfo.Node == null)
            {
                return;
            }
            setnodestatus(hitinfo.Node);
            
            if (e.Button.Equals(MouseButtons.Right))
               { 
                    taskpopup.ShowPopup(MousePosition); 
                }
            
               
             
        }
        AbConnector _connector;
        List<UserNode> curentsets = new List<UserNode>();
        List<UserNode> addnodes = new List<UserNode>(); 
        public void Init(AbConnector connector)
        {
            
            templeteandtaskpicture.Visible = false;
            if(curentsets.Count==0)
            {
                _connector = connector;
                curentsets = _connector.GetNodesById(); 
                tr_content.BeginUpdate();
                tr_content.DataSource = curentsets;
                tc_nodecolumn.FieldName = "nodename";
                tr_content.KeyFieldName = "_id";
                tr_content.ParentFieldName = "parentid";
                tr_content.ImageIndexFieldName = "stateimageindex"; 
                tr_content.RefreshDataSource();
                tr_content.EndUpdate();
                tr_content.Nodes[0].Expand();
            }
        }
        private TreeListNode setNode(string name,string objectid,TypeNode nodetype,int immageindex)
        {
            TreeListNode parentnode = tr_content.FocusedNode;
            var tn=tr_content.AppendNode(name, parentnode);
            tn.SetValue("_id", objectid);
            tn.SetValue("nodename",name);
            tn.SetValue("parentid",parentnode.GetValue("_id"));
            tn.SetValue("stateimageindex",immageindex);
            tn.SetValue("nodetype",nodetype);
            if(nodetype.Equals(TypeNode.task))
            tn.SetValue("taskstatus",1);
            //tr_content.SetFocusedNode(tn);
           _connector.AddUserNode( tr_content.GetDataRecordByNode(tn) as UserNode);
            expandallParentNode(tn);
            return tn;
        }
        private void expandallParentNode(TreeListNode node)
        {
            node.Expand();
            if(node.ParentNode !=null)
            {
                expandallParentNode(node.ParentNode);
            }
        }
        private void Bar_addnode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        { 
            setNode("新节点",Guid.NewGuid().ToString(),TypeNode.node,10); 
        }

        private void Bar_addtemplete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "excel2003文件|*.xls|excel2016文件|*.xlsx|excel文件|*.xls;*.xlsx";
            if (ofd.ShowDialog().Equals(DialogResult.OK))
            {
                AddTempleteForm adf = new AddTempleteForm(ofd.FileName, System.IO.Path.GetFileNameWithoutExtension(ofd.FileName));
                if (adf.ShowDialog().Equals(DialogResult.OK))
                {

                  

                    int i = 0;
                     foreach(string name in adf.FileStreames.Keys)
                    {
                        if (adf.FileStreames.Count > 1 && i == 0)
                        {
                            i = i + 1;
                            tr_content.FocusedNode.SetValue("nodename",name);
                            _connector.renameusernode(tr_content.FocusedNode.GetValue("_id").ToString(), name);
                            continue;
                        }
                        setNode(name, _connector.uploadfile(string.Format(@"{0}|*.{1}",name,adf.FileExtend), adf.FileStreames[name]), TypeNode.templete, 12);
                    }

                    }

            }
             
        }

        private void Bar_addtask_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
          
                AddTask adf = new AddTask(_connector,tr_content.FocusedNode.GetValue("_id").ToString());
                if (adf.ShowDialog().Equals(DialogResult.OK))
                { 
                  foreach(string filename in adf.CurrentAdd.Keys)
                {
                    setNode(filename, adf.CurrentAdd[filename], TypeNode.task, 11);
                }
                }

           

        }
        private Dictionary<string,List<string>> getcollectionnames(List<string> ids)
        {
            var diction = new Dictionary<string, List<string>>();
            foreach (string id in ids)
            {
                var tn = tr_content.FindNodeByFieldValue("_id", id);
                if(tn !=null)
                { 
                var nodetype = tn.GetValue("nodetype");
                if (nodetype != null && nodetype.Equals(TypeNode.task))
                {
                    List<string> parentnames = new List<string>();
                    recursernames(tn.ParentNode, parentnames);
                    string collectionname = string.Join("_", parentnames.ToArray());
                    if(!diction.ContainsKey(collectionname))
                    {
                        diction.Add(collectionname,new List<string>());
                    }
                    diction[collectionname].Add(id);
                }
                }
            }
            return diction;
        }
        private void deletenode(TreeListNode tn)
        {
           
            List<string> ids = new List<string>(),filenodes=new List<string>();

            recurserchildids(tn, ids,filenodes);
            var diction = getcollectionnames(ids);
            tn.Remove();
               foreach(string collectionname in diction.Keys)
                {
                    _connector.deleteuserdata(collectionname, diction[collectionname]);
                }
            _connector.DeleteUserNode(ids);
            //_connector.deleteuserdata()
            foreach(string id in filenodes)
            {
                _connector.deletefile(id);
                
            }
            if(Savetemplateform !=null)
            {
                Savetemplateform(null, null);
            }
        }
        private void Btn_deleteNode_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            deletenode(tr_content.FocusedNode);
        }
        private void recurserchildids(TreeListNode parentid, List<string> parentids,List<string> filenodes)
        {
            object id = parentid.GetValue("_id");
            object doctype = parentid.GetValue("nodetype");
            if (id !=null&&!parentids.Contains(id))
            {
                parentids.Add(string.Format("'{0}'",id));
                if(doctype !=null&&!doctype.ToString().Equals("node"))
                {
                    filenodes.Add(id.ToString());
                }
            }
            if(parentid.HasChildren)
            {
                foreach (TreeListNode tn in parentid.Nodes)
                    recurserchildids(tn,parentids, filenodes);
            }
           
             
        }

        private void Tr_content_ShowingEditor(object sender, CancelEventArgs e)
        {
            if (tr_content.FocusedNode != null && tr_content.FocusedNode.ParentNode == null)
                e.Cancel = true;
            else
                setnodestatus(tr_content.FocusedNode);
        }

        private void Tr_content_DataSourceChanged(object sender, EventArgs e)
        {
           
        }

        private void Tr_content_TextChanged(object sender, EventArgs e)
        {

        }

        private void Tr_content_NodeChanged(object sender, NodeChangedEventArgs e)
        {
            
        }

        private void Tr_content_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {

            object id = e.Node.GetValue("_id"),
             nodename = e.Node.GetValue("nodename");
            if(id !=null&&nodename !=null)
            _connector.renameusernode(id.ToString(), nodename.ToString());
        }

        private void BarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var tn = tr_content.FocusedNode;
            if(tn !=null)
            {
                string _id =  tn.GetValue("_id").ToString();
                string startrow = span_startrow.EditValue.ToString();
                string startcolumn =span_startcolumn.EditValue.ToString();
                string endcolumn = span_endcolumn.EditValue.ToString();
                string endrow = span_endrow.EditValue.ToString();
                //string keycolumns = edit_keycolumns.EditValue.ToString();
                tn.SetValue("startrow",startrow);tn.SetValue("startcolumn",startcolumn);tn.SetValue("endcolumn",endcolumn);
                tn.SetValue("endrow",endrow);
                //tn.SetValue("keycolumns",keycolumns);
                _connector.updateusernodedatatemplete(_id,startrow,startcolumn,endcolumn,endrow);
                List<string> parentnames = new List<string>();
                recursernames(tn,parentnames);
                _connector.createUserDataCollectionIndex(string.Join("_", parentnames.ToArray()), null);
                if(Savetemplateform !=null)
                {
                    Savetemplateform(sender, e);
                }
            }
        }
        private void recursernames(TreeListNode tn, List<string> parentnames)
        {
            parentnames.Add(tn.GetValue("nodename").ToString());
            if(tn.ParentNode !=null&&tn.ParentNode.ParentNode!=null)
            {
                recursernames(tn.ParentNode,parentnames);
            }


        }
    }
    public static class NodeOperator
    {
        
    }
}
