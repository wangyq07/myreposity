using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ToolLIbrary.Model;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.Columns;

namespace BiTools
{
    public partial class TaskDispatch : DevExpress.XtraEditors.XtraForm
    {
        AbConnector _connector;
        public TaskDispatch(AbConnector connector)
        {
            InitializeComponent();
            _connector=connector;
        }
        List<UserNode> uns; List<User> users;
        private void TaskDispatch_Load(object sender, EventArgs e)
        {
            combo_status.Items.AddRange(new object[] { TypeStatus.全部, TypeStatus.一录, TypeStatus.二录, TypeStatus.校验 });
            uns = _connector.GetNodesById();
             users= _connector.getUsersByUserName();
            seconduser.Items.Add(new User() { _id=""});
            seconduser.Items.AddRange(users);
            firstuser.Items.Add(new User() { _id=""}); firstuser.Items.AddRange(users);
            rep_jiaoyanren.Items.Add(new User() { _id = "" }); rep_jiaoyanren.Items.AddRange(users);
            firstuser.CloseUp += Firstuser_CloseUp;
            seconduser.CloseUp += Firstuser_CloseUp;
            firstuser.Popup += Firstuser_Popup;
            rep_jiaoyanren.CloseUp += Firstuser_CloseUp;
            rep_jiaoyanren.Popup += Firstuser_Popup;
            treeList1.CellValueChanged += TreeList1_CellValueChanged;
            treeList1.DataSource = uns;
            treeList1.KeyFieldName = "_id";
            treeList1.ParentFieldName = "parentid";
            treeList1.ExpandAll();
          
            
        }

        private void Firstuser_Popup(object sender, EventArgs e)
        {
            Object user = null;
            if (treeList1.FocusedColumn.Equals(firstinput))
                user = treeList1.GetFocusedRowCellValue(firstinput);
            else
                user = treeList1.GetFocusedRowCellValue(secondinput);
            if (user != null)
            {
                var editor = sender as ComboBoxEdit;
                for (int i = 0; i < editor.Properties.Items.Count; i++)
                {
                    if (editor.Properties.Items[i] != null && editor.Properties.Items[i] is User
                        && (editor.Properties.Items[i] as User)!=null
                        && (editor.Properties.Items[i] as User).username !=null
                        && (editor.Properties.Items[i] as User).username.Equals(user.ToString())
                        )
                    {
                        editor.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void Firstuser_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
           
            //var edits = sender as ComboBoxEdit;
            //var selitem = e.Value as User;
            //if(selitem !=null)
            //treeList1.SetFocusedValue(selitem._id);
            //else
            //    treeList1.SetFocusedValue("");
        }

        private void Firstuser_QueryCloseUp(object sender, CancelEventArgs e)
        {
          
        }

        private void TreeList1_CellValueChanged(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
           recursenodeset(e.Node,e.Value,e.Column);
        }
        Dictionary<string, List<string>> dispatchtask = new Dictionary<string, List<string>>();
        private void recursenodeset(TreeListNode node,object value,TreeListColumn tc)
        {
             if(node !=null)
            {
                node.SetValue(tc,value);
                object _id = node.GetValue("_id");
                object nodetype = node.GetValue("nodetype");
                if(nodetype !=null&&nodetype.ToString().Equals("task") && _id !=null)
                 
                {
                    if (!dispatchtask.ContainsKey(_id.ToString()))
                        {
                        dispatchtask.Add(_id.ToString(),new List<string>());
                        }
                    object firstuser= node.GetValue("firstuserid"),secondeuser= node.GetValue("seconduserid"),
                        jiaoyanren=node.GetValue("jiaoyanren");
                    dispatchtask[_id.ToString()].Clear();
                    dispatchtask[_id.ToString()].Add(string.Format("{0}",firstuser==null?"":firstuser));
                    dispatchtask[_id.ToString()].Add(string.Format("{0}", secondeuser == null ? "": secondeuser));
                    dispatchtask[_id.ToString()].Add(string.Format("{0}", jiaoyanren == null ? "":jiaoyanren));
                }
                if(node.HasChildren)
                {
                    for(int i=0;i<node.Nodes.Count;i++)
                    {
                        recursenodeset(node.Nodes[i],value,tc);
                    }
                }
            }
        }
        private void Firstuser_EditValueChanged(object sender, EventArgs e)
        {
           
        }

        private void Bar_save_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            treeList1.CloseEditor();
            _connector.EditUserMap(dispatchtask);
            XtraMessageBox.Show("保存成功!");
            dispatchtask.Clear();
        }

        private void TreeList1_CellValueChanging(object sender, DevExpress.XtraTreeList.CellValueChangedEventArgs e)
        {
             
        }

        private void TreeList1_Validating(object sender, CancelEventArgs e)
        {

        }

        private void TreeList1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if(e.Value is User)
            {
                e.Value = (e.Value as User).username;
                e.Valid = true;
            }
        }

        private void Bar_cancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
            this.Close();
        }

        private void Bar_status_EditValueChanged(object sender, EventArgs e)
        {
           if(uns !=null)
            {
                TypeStatus selectedstatus =(TypeStatus) bar_status.EditValue   ;
                treeList1.DataSource = null;
                switch(selectedstatus)
                {
                    case TypeStatus.一录:
                        var first = uns.FindAll(c=>(c.nodetype==TypeNode.node||c.nodetype==TypeNode.templete
                                                   ||(c.nodetype==TypeNode.task&&c.taskstatus==1)));
                        treeList1.DataSource = first;
                        break;
                    case TypeStatus.二录:
                        var second = uns.FindAll(c => (c.nodetype == TypeNode.node || c.nodetype == TypeNode.templete
                                                   || (c.nodetype == TypeNode.task && c.taskstatus == 2)));
                        treeList1.DataSource = second;
                        break;
                    case TypeStatus.校验:
                        var jiao = uns.FindAll(c => (c.nodetype == TypeNode.node || c.nodetype == TypeNode.templete
                                                   || (c.nodetype == TypeNode.task && c.taskstatus == 3)));
                        treeList1.DataSource = jiao;
                        break;
                    default:
                        treeList1.DataSource = uns;
                        break;
                }
                treeList1.ExpandAll();
            }
        }

        private void TaskDispatch_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
    public enum TypeStatus
    {
        全部=0,
        一录=1,
            二录=2,
            校验=3,
            成果=4
    }
}