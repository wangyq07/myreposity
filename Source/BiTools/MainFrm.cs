using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using BiTools.Controls;
using ToolLIbrary.Model;
 
using DevExpress.Utils;

namespace BiTools
{
    public partial class MainFrm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        private void BackstageViewClientControl1_Load(object sender, EventArgs e)
        {

        }

        private void Btn_exit_ItemClick(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            this.Close();
        }

        private void MainFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(XtraMessageBox.Show("是否有内容要保存，确定关闭吗？","关闭",MessageBoxButtons.YesNo, MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2).Equals(DialogResult.No))
            {
                e.Cancel = true;
            }
        }
        Input secondinputctl = null;
        Input firstinputctl = null;
        Input resultdatactl = null;
        Tasks tasksctl = null ;
        jiaoyanctl jiao = null;
        private void Homebutton_SelectedPageChanged(object sender, EventArgs e)
        {
            MainControlContent.Controls.Clear();
            if (Homebutton.SelectedPage == null)
                return;
            Homebutton.ShowDisplayOptionsMenuButton = DefaultBoolean.True;
           switch (Homebutton.SelectedPage.Name)
            {
                case "taskcreate":
                    if(tasksctl ==null)
                    {
                        tasksctl = new Tasks();
                        tasksctl.Savetemplateform += new EventHandler(tasksavetempleteform);
                    }
                    this.MainControlContent.Controls.Add(tasksctl);
                    tasksctl.Dock = DockStyle.Fill;
                    tasksctl.Init(connector);
                    Homebutton.ShowDisplayOptionsMenuButton = DefaultBoolean.False;
                    break;
                case "firstinput":
                    if(firstinputctl==null)
                    firstinputctl = new Input(currentUser.username,1,connector);
                    this.MainControlContent.Controls.Add(firstinputctl);
                    firstinputctl.Dock = DockStyle.Fill;
                    firstinputctl.Init();
                    break;
                case "secondinput":
                    if(secondinputctl==null)
                    secondinputctl = new Input(currentUser.username, 2, connector);
                    this.MainControlContent.Controls.Add(secondinputctl);
                    secondinputctl.Dock = DockStyle.Fill;
                    secondinputctl.Init();
                    break;
                case "jiaoyan":
                    if (jiao == null)
                        jiao = new jiaoyanctl(connector, currentUser.username);
                    this.MainControlContent.Controls.Add(jiao);
                    jiao.Dock = DockStyle.Fill;
                    jiao.Init();
                    break;
                case "presult":
                    if (resultdatactl == null)
                        resultdatactl = new Input(currentUser.username,4,connector);
                    this.MainControlContent.Controls.Add(resultdatactl);
                    resultdatactl.Dock = DockStyle.Fill;
                    resultdatactl.Init();
                    break;
                case "Aggregation":
                    break;
                default:
                    break;

            }
        }

        private void tasksavetempleteform(object sender, EventArgs e)
        {
            if (firstinputctl != null)
                firstinputctl.RefreshData();
            if (secondinputctl != null)
                secondinputctl.RefreshData();
            if (jiao != null)
                jiao.RefreshData();
            if(resultdatactl !=null)
            {
                resultdatactl.RefreshData();
            }
        }

        private void Password_EditValueChanged(object sender, EventArgs e)
        {
            ce.Password = edit_password.Text;
            statusset();
        }
        AbConnector connector; ConnectExpression ce = new ConnectExpression();
        private void Btn_test_Click(object sender, EventArgs e)
        {
           
           
            connector = BuildConnector.buildConnector(DbaseType.mongo, ce);
            string erromessage = "";
            if (connector.TestConnection(ref erromessage))
            {
                XtraMessageBox.Show("测试成功!", "测试连接", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                btn_cancel.Enabled = true;
                btn_confirm.Enabled = true;
            }
            else
            {
                XtraMessageBox.Show(string.Format("测试失败:{0}",erromessage), "测试连接", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                btn_confirm.Enabled = false;
                btn_cancel.Enabled = false;
            }
        }

        private void Edit_server_EditValueChanged(object sender, EventArgs e)
        {
            ce.DataSource = edit_server.Text;
            if(ce !=null)
            statusset();
        }
        private void statusset()
        {
            if(string.IsNullOrWhiteSpace(edit_password.Text)
                || string.IsNullOrWhiteSpace(edit_server.Text)
                || string.IsNullOrWhiteSpace(edit_user.Text)
                || string.IsNullOrWhiteSpace(combo_dblist.Text)
                )
            {
                btn_cancel.Enabled = false;
                btn_confirm.Enabled = false;
                btn_test.Enabled = false;
            }
            else
            {
                btn_cancel.Enabled = false;
                btn_confirm.Enabled = false;
                btn_test.Enabled = true;
            }
        }

        private void DataBaseLayout_Click(object sender, EventArgs e)
        {
            statusset();
        }

        private void Combo_dblist_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Combo_dblist_TextChanged(object sender, EventArgs e)
        {
            ce.DataBaseName = combo_dblist.Text;
            statusset();
        }

        private void Combo_dblist_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(edit_password.Text)
                || string.IsNullOrWhiteSpace(edit_server.Text)
                || string.IsNullOrWhiteSpace(edit_user.Text)
               // || string.IsNullOrWhiteSpace(combo_dblist.Text)
                )
            {
                return;
            }
            combo_dblist.Properties.Items.Clear();
            string databasename = ce.DataBaseName;
            ce.DataBaseName = "";
            //ce.DataSource = edit_server.Text;
            //ce.Password = ConnectExpression.Encrypt( edit_password.Text);
            //ce.UserName = edit_user.Text;
            connector = BuildConnector.buildConnector(DbaseType.mongo, ce);
            try
            {
               combo_dblist.Properties.Items.AddRange( connector.getDbList());
                if(!string.IsNullOrWhiteSpace(databasename))
                { 
                  ce.DataBaseName = databasename;
                    combo_dblist.SelectedText = databasename;
                }
            }
            catch(Exception ex)
            {
                XtraMessageBox.Show(string.Format("错误:{0}",ex.Message),"错误",MessageBoxButtons.OK,MessageBoxIcon.Error,MessageBoxDefaultButton.Button1);
            }

        }

        private void Btn_confirm_Click(object sender, EventArgs e)
        {
            if(ce !=null)
            {
                ce.Password = ConnectExpression.Encrypt(ce.Password);
               JsonClass.SaveToXml<ConnectExpression>(string.Format(@"{0}\connect.xml", Constants.BIN_PATH),ce);
                btn_userlogin.Enabled = true;

            }
        }

        private void Edit_user_EditValueChanged(object sender, EventArgs e)
        {
            ce.UserName = edit_user.Text;
            statusset();
        }
        User currentUser=null;
        private void Btn_login_Click(object sender, EventArgs e)
        {
            if (connector != null && !string.IsNullOrEmpty(edit_loguser.Text) && !string.IsNullOrEmpty(edit_logpass.Text)
               && connector.CheckLogin(edit_loguser.Text, ConnectExpression.Encrypt(edit_logpass.Text), ref currentUser)
               )
            {
                XtraMessageBox.Show("登录成功");
                //currentUser.pwd = ConnectExpression.Encrypt(edit_password.Text);
                JsonClass.SaveToXml<User>(string.Format(@"{0}\user.xml", Constants.BIN_PATH), currentUser);
                
                setvisible(true);
            }
            else
            {
                XtraMessageBox.Show("登录失败！");
                setvisible(false);
            }
        }
        List<User> users = null;List<Role> roles = null;
        private void setvisible(bool currentd)
        {
            if (currentd)
            {
                taskcreate.Visible = true;
                firstinput.Visible = true; 
                secondinput.Visible = true;
                jiaoyan.Visible = true;
                presult.Visible = true;
                if (currentUser != null && currentUser.belongrole.Equals("admin"))
                {
                    btn_usermanager.Enabled = true;
                    Aggregation.Visible = true;
                    gc_user.DataSource = null;
                    if (users == null)
                    {
                        users = connector.getUsersByUserName();
                    }
                    if(roles==null)
                    {
                        roles = connector.getRoles();
                    }
                    gc_user.DataSource = JsonClass.DeserialJson<List<User>>(JsonClass.GetJsonString<List<User>>(users));

                    userdatanav.DataSource = null;
                    userdatanav.DataSource = gc_user.DataSource;
                    rolecombo.Items.Add(new Role());
                    rolecombo.Items.AddRange(roles);
                    rolecombo.CloseUp += Rolecombo_CloseUp;
                    rolecombo.Popup += Rolecombo_Popup;
                    gc_role.DataSource = null;
                    gc_role.DataSource= JsonClass.DeserialJson<List<Role>>(JsonClass.GetJsonString<List<Role>>(roles));
                }
                else
                {
                    btn_usermanager.Visible = false;
                    Aggregation.Visible = false;
                }
            }
            else
            {

                btn_usermanager.Enabled = false;
                Aggregation.Visible = false;
                firstinput.Visible = false;
                taskcreate.Visible = false;
                secondinput.Visible = false;
                jiaoyan.Visible = false;
                presult.Visible = false;
            }
}

        private void Rolecombo_Popup(object sender, EventArgs e)
        {
            Object role = null;
            if (gv_user.FocusedColumn.Name.Equals("belongrole"))
                role = gv_user.GetFocusedRowCellValue("belongrole");

            if (role != null)
            {
                var editor = sender as ComboBoxEdit;
                for (int i = 0; i < editor.Properties.Items.Count; i++)
                {
                    if (editor.Properties.Items[i] != null && editor.Properties.Items[i] is Role
                        && (editor.Properties.Items[i] as Role)._id !=null
                        && (editor.Properties.Items[i] as Role)._id.Equals(role.ToString())
                        )
                    {
                        editor.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void Rolecombo_CloseUp(object sender, DevExpress.XtraEditors.Controls.CloseUpEventArgs e)
        {
            
        }

        private void MainFrm_Load(object sender, EventArgs e)
        {
            //taskcreate.Ribbon.Visible = false;
             
            ce = JsonClass.GetDeserialObjectFromXml<ConnectExpression>(string.Format(@"{0}\connect.xml", Constants.BIN_PATH));
            if(ce !=null)
            {
                edit_server.Text
                    = ce.DataSource;
                edit_password.Text = ConnectExpression.Decrypt(ce.Password);
                edit_user.Text = ce.UserName;
                combo_dblist.Text = ce.DataBaseName;
                connector = BuildConnector.buildConnector(DbaseType.mongo, ce);
                if(connector !=null)
                {
                    statusset();
                    btn_userlogin.Enabled = true;
                    string eer = null;
                    connector.TestConnection(ref eer);
                }
            }
            currentUser = JsonClass.GetDeserialObjectFromXml<User>(string.Format(@"{0}\user.xml", Constants.BIN_PATH));
            if(currentUser !=null)
            {
                edit_loguser.Text = currentUser.username;
                edit_logpass.Text = ConnectExpression.Decrypt(currentUser.pwd);
                if (connector != null && !string.IsNullOrEmpty(edit_loguser.Text) && !string.IsNullOrEmpty(edit_logpass.Text)
               && connector.CheckLogin(edit_loguser.Text, ConnectExpression.Encrypt(edit_logpass.Text), ref currentUser)
               )
                {
                    setvisible(true);
                }
                else
                {
                    setvisible(false);
                }
                }
            if (ce == null)
                ce = new ConnectExpression();

        }

        private void Hidedisplay_ItemClick(object sender, ItemClickEventArgs e)
        {
           
            if (firstinputctl != null)
            {
                if (hidedisplay.ImageIndex ==5)
                { 
                firstinputctl.sethidetree(true);
                    
                }
                else if(hidedisplay.ImageIndex == 6)
                {
                    firstinputctl.sethidetree(false);
                  
                }
            }
            if (secondinputctl != null)
            {
                if (hidedisplay.ImageIndex == 5)
                {
                    secondinputctl.sethidetree(true);
                  
                }
                else if (hidedisplay.ImageIndex == 6)
                {
                    secondinputctl.sethidetree(false);
                  
                }
            }
            if (jiao != null)
            {
                if (hidedisplay.ImageIndex == 5)
                {
                    jiao.sethidetree(true);

                }
                else if (hidedisplay.ImageIndex == 6)
                {
                    jiao.sethidetree(false);

                }
            }
            if (hidedisplay.ImageIndex == 5)
            {
               hidedisplay.ImageIndex = 6;

            }
            else if (hidedisplay.ImageIndex == 6)
            {
                hidedisplay.ImageIndex = 5;

            }
        }

        private void Btn_dispatch_ItemClick(object sender, ItemClickEventArgs e)
        {
            TaskDispatch tf = new TaskDispatch(connector);
            if(tf.ShowDialog().Equals(DialogResult.OK))
            {
                if(firstinputctl !=null && secondinputctl !=null &&jiao!=null)
                {
                    firstinputctl.RefreshData();
                    secondinputctl.RefreshData();
                    jiao.RefreshData();
                }
            }
        }

        private void Bar_verital_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (firstinputctl != null)
            {
                firstinputctl.setveri();
            }
            if (secondinputctl != null)
            {
                secondinputctl.setveri();
            }
        }

        private void Bar_horin_ItemClick(object sender, ItemClickEventArgs e)
        {
            if(firstinputctl !=null)
            {
                firstinputctl.sethori();
            }
            if(secondinputctl !=null)
            {
                secondinputctl.sethori();
            }
        }

        private void Btn_save_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (firstinputctl != null)
            { 
                firstinputctl.save();
                if(secondinputctl !=null)
                {
                    secondinputctl.RefreshData();
                }
            }
        }

        private void Btn_saveall_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (firstinputctl != null)
                firstinputctl.saveall();
            //if (secondinputctl != null)
            //{
            //    secondinputctl.RefreshData();
            //}
        }

        private void Second_save_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (secondinputctl != null)
                secondinputctl.save();
            //if (jiao != null)
            //{
            //    jiao.RefreshData();
            //}
        }

        private void Second_saveall_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (secondinputctl != null)
                secondinputctl.saveall();
            //if (jiao != null)
            //{
            //    jiao.RefreshData();
            //}
        }

        private void Jiaoyan_save_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (jiao != null)
                jiao.save();
        }

        private void Jiaoyan_saveall_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (jiao != null)
                jiao.saveall();
        }

        private void Gc_user_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            switch(e.Button.ButtonType)
            {
                case NavigatorButtonType.Append:
                    break;
                case NavigatorButtonType.EndEdit:
                    break;
                case NavigatorButtonType.Remove:
                    break;
            }
        }

        private void Userdatanav_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            switch (e.Button.Tag)
            {
                case "add":
                    List<User> tusers=gv_user.DataSource as List<User>;
                    tusers.Add(new User() { username=string.Format("newuser{0}",tusers.Count),_id=Guid.NewGuid().ToString()});
                    gv_user.RefreshData();
                    break;
                case "save":
                    List<User> currentusers= gv_user.DataSource as List<User>;
                    List<User> deleteusers = users.FindAll(c=>!currentusers.Exists(d=>d._id.Equals(c._id)));
                    List<User> insertusers = currentusers.FindAll(c => !users.Exists(d => d._id.Equals(c._id)));
                    List<User> updateusers = users.FindAll(c=>currentusers.Exists(d=>d._id.Equals(c._id)
                                                                                  &&(d.username !=c.username
                                                                                    ||d.displayname !=c.displayname
                                                                                    ||d.belongrole !=d.belongrole
                                                                                  )));
                    insertusers.ForEach((User u) => { u.pwd = ConnectExpression.Encrypt(u.username); });
                    if(deleteusers.Count>0)
                    connector.deleteUser(deleteusers);
                    if(insertusers.Count>0)
                    connector.adduser(insertusers);
                    if(updateusers.Count>0)
                    connector.updateuser(updateusers);
                    users = JsonClass.DeserialJson<List<User>>(JsonClass.GetJsonString(currentusers));
                    break;
                case "del":
                   var _id= gv_user.GetRowCellValue(gv_user.FocusedRowHandle,"username");
                    if(gv_user.FocusedRowHandle>=0
                       && (_id==null||!_id.Equals("admin"))
                        )
                    gv_user.DeleteRow(gv_user.FocusedRowHandle);
                    break;
            }
        }

        private void Userdatanav_Click(object sender, EventArgs e)
        {

        }

        private void Gv_user_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
           
        }

        private void Gv_user_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //if (e.Value is Role)
            //{
            //    gv_user.SetRowCellValue(e.RowHandle,e.Column, (e.Value as Role)._id);
               
            //}
        }

        private void Gv_user_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            if (e.Value is Role)
            {
                e.Value= (e.Value as Role).rolename;
                e.Valid = true;

            }
            if(gv_user.FocusedColumn.FieldName.Equals("username"))
            {
                if(e.Value==null||e.Value.ToString().Equals(string.Empty))
                {
                    e.ErrorText = "用户名不能为空";
                    e.Valid = false;
                }
                var currentusers = gv_user.DataSource as List<User>;
                if(currentusers.Exists(c=>c.username !=null&&c.username.Equals(e.Value)))
                {
                    e.ErrorText = string.Format("{0} 已经存在",e.Value);
                    e.Valid = false;
                }
            }
           
           
        }

        private void DataNavigator1_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            switch (e.Button.Tag)
            {
                case "add":
                    List<Role> tusers = gv_role.DataSource as List<Role>;
                    tusers.Add(new Role() { rolename = string.Format("newrole{0}", tusers.Count), _id = Guid.NewGuid().ToString() });
                    gv_role.RefreshData();
                    break;
                case "save":
                    List<Role> currentusers = gv_role.DataSource as List<Role>;
                    List<Role> deleteusers = roles.FindAll(c => !currentusers.Exists(d => d._id.Equals(c._id)));
                    List<Role> insertusers = currentusers.FindAll(c => !roles.Exists(d => d._id.Equals(c._id)));
                    List<Role> updateusers = roles.FindAll(c => currentusers.Exists(d => d._id.Equals(c._id)
                                                                                    && (d.rolename != c.rolename
                                                                                      || d.displayname != c.displayname
                                                                                      
                                                                                    )));
                    //insertusers.ForEach((User u) => { u.pwd = ConnectExpression.Encrypt(u.username); });
                    if (deleteusers.Count > 0)
                        connector.deleterole(deleteusers);
                    if (insertusers.Count > 0)
                        connector.addrole(insertusers);
                    if (updateusers.Count > 0)
                        connector.updaterole(updateusers);
                    roles = JsonClass.DeserialJson<List<Role>>(JsonClass.GetJsonString(currentusers));
                    rolecombo.Items.Clear();
                    rolecombo.Items.Add(new Role());
                    rolecombo.Items.AddRange(roles.ToArray());
                    break;
                case "del":
                    var _id = gv_user.GetRowCellValue(gv_user.FocusedRowHandle, "rolename");
                    if (gv_role.FocusedRowHandle >= 0
                       && (_id == null || !_id.Equals("admin"))
                        )
                        gv_role.DeleteRow(gv_user.FocusedRowHandle);
                    break;
            }
        }

        private void Updatepassword_Click(object sender, EventArgs e)
        {
            if(!layoutControl1.Visible)
            {
                layoutControl1.Visible = true;
            }
        }

        private void Edit_oldpas_Validated(object sender, EventArgs e)
        {

        }

        private void Edit_oldpas_Validating(object sender, CancelEventArgs e)
        {
           
        }

        private void DxValidationProvider1_ValidationFailed(object sender, DevExpress.XtraEditors.DXErrorProvider.ValidationFailedEventArgs e)
        {

        }

        private void Btn_modifyconfirm_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(edit_oldpas.Text)
                ||string.IsNullOrEmpty(edit_newpas.Text)
                ||string.IsNullOrEmpty(edit_confirmpas.Text)
                )
            {
                XtraMessageBox.Show("输入不能为空！");
                return;
            }
            var oldpassword = ConnectExpression.Encrypt( edit_oldpas.Text);
            var newpassword = edit_newpas.Text;
            var confirmpassword = edit_confirmpas.Text;
            if (!oldpassword.Equals(currentUser.pwd))
            {
                XtraMessageBox.Show("输入的旧密码不正确！");
                return;
            }
                if (!confirmpassword.Equals(newpassword))
            {
                XtraMessageBox.Show("两次输入密码不一致！");
                return;
            }
            connector.changeuserpassword(currentUser._id, ConnectExpression.Encrypt(newpassword));
            currentUser.pwd = ConnectExpression.Encrypt(newpassword);

            layoutControl1.Visible = false;
        }

        private void Btn_modify_cancel_Click(object sender, EventArgs e)
        {
            layoutControl1.Visible = false;
        }

        private void Btn_submit_ItemClick(object sender, ItemClickEventArgs e)
        {
            if(firstinputctl !=null)
            {
                firstinputctl.submit();
                firstinputctl.RefreshData();
            }
            if(secondinputctl !=null)
            {
                secondinputctl.RefreshData();
            }
        }

        private void Btn_sumbmitjiaoyan_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (secondinputctl != null)
            {
                secondinputctl.submit();
                secondinputctl.RefreshData();
            }
            if (jiao != null)
            {
                jiao.RefreshData();
            }
        }

        private void Btn_submitresult_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (jiao != null)
            {
                jiao.submit();
                jiao.RefreshData();
            }
            if (resultdatactl != null)
            {
                resultdatactl.RefreshData();
            }
        }
    }
}