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
using System.IO;
using System.Threading;

namespace BiTools
{
    public partial class AddTask : DevExpress.XtraEditors.XtraForm
    {
        AbConnector _connector;
        string _parentid;
        public AddTask(AbConnector connector,string parentid)
        {
            InitializeComponent();
            pict_display.MouseWheel += PictureEdit1_MouseWheel;
            _parentid = parentid;
            _connector = connector;
            
        }
        Dictionary<string, string> _CurrentAdd=new Dictionary<string, string>();
        public Dictionary<string,string> CurrentAdd
        {
            get
            {
                return _CurrentAdd;
            }
        }
        private void PictureEdit1_MouseWheel(object sender, MouseEventArgs e)
        {
            Size t = pict_display.Image.Size;
            t.Width += e.Delta;
            t.Height += e.Delta;
            if (t.Width < 0 || t.Height < 0)
                return;
            Bitmap tempbitmap = new Bitmap(pict_display.Image, t.Width, t.Height);
            pict_display.Image = tempbitmap;
        }

        private void Bar_sel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
             
        }
        Dictionary<string, string> eerorlist = null;
        private void Bar_confirm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (bw.IsBusy && addbw.IsBusy && savebw.IsBusy)
            {
                XtraMessageBox.Show("正在加载数据，请稍后!");
                return;
            }
            eerorlist = new Dictionary<string, string>();
            savebw = new BackgroundWorker();
            savebw.WorkerReportsProgress = true;
            savebw.DoWork += Savebw_DoWork;
            savebw.RunWorkerCompleted += Savebw_RunWorkerCompleted;
            savebw.RunWorkerAsync(current);
             
        }

        private void Savebw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
             if(eerorlist.Count>0)
            {
                if(XtraMessageBox.Show("存在上传失败的任务，您是否要重新上传失败文件?",
                    "提示",MessageBoxButtons.YesNo,MessageBoxIcon.Error,MessageBoxDefaultButton.Button2).Equals(DialogResult.OK)
                    )
                {
                    Dictionary<string, byte[]> savename = new Dictionary<string, byte[]>();
                    foreach(string name in eerorlist.Keys)
                    {
                        savename.Add(name,current[name]);
                    }
                    eerorlist = new Dictionary<string, string>();
                    savebw = new BackgroundWorker();
                    savebw.WorkerReportsProgress = true;
                    savebw.DoWork += Savebw_DoWork;
                    savebw.RunWorkerCompleted += Savebw_RunWorkerCompleted;
                    savebw.RunWorkerAsync(savename);
                }
            }
            XtraMessageBox.Show("上传成功!");
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Savebw_DoWork(object sender, DoWorkEventArgs e)
        {
            Dictionary<string,byte[]> savename = e.Argument as Dictionary<string, byte[]>;
            int i = 0;
            setmemotext medit = new setmemotext(setmemo);
            setmemotext list = new setmemotext(setlist);
            foreach (string filename in savename.Keys)
            {
                
                try
                {
                    _CurrentAdd.Add(filename,_connector.uploadfile(filename,savename[filename]));
                  this.Invoke(medit, string.Format("{0}上传成功！", filename));
                    i++;
                    UpdateProgress((int)((float)i / (float)savename.Count * 100));
                    Thread.Sleep(0);

                }
                catch (Exception ex)
                {
                    this.Invoke(medit, string.Format("{0}上传失败:{1}", filename, ex.Message));
                    eerorlist.Add(filename,filename);
                    i++;
                    UpdateProgress((int)((float)i / (float)savename.Count * 100));
                    Thread.Sleep(0);
                }
            }
        }

        Dictionary<string, byte[]> orignal = new Dictionary<string, byte[]>(), current = new Dictionary<string, byte[]>(); 
        private void Bar_addshuj_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "图片文件|*.jpg;*.jpeg;*.tif;*.png;*.gif";
            ofd.Multiselect = true;
            if(bw.IsBusy&&addbw.IsBusy&&savebw.IsBusy)
            {
                XtraMessageBox.Show("正在加载数据，请稍后!");
                return;
            }
            if (ofd.ShowDialog().Equals(DialogResult.OK))
            {
                addbw = new BackgroundWorker();
                addbw.DoWork += Addbw_DoWork;
                addbw.RunWorkerCompleted += Addbw_RunWorkerCompleted;
                addbw.ProgressChanged += Addbw_ProgressChanged;
                addbw.WorkerReportsProgress = true;
                addbw.RunWorkerAsync(ofd.FileNames);
            }
        }

        private void Addbw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
        }
        public delegate void UpdateProgressInvoker(int pos); 
        void UpdateProgress(int pos)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new UpdateProgressInvoker(UpdateProgress), new object[] { pos });
                return;
            } 
            bar_progress.EditValue = pos;
        }
        private void Addbw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            setmemo("加载完成！");
        }

        private void Addbw_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] filenames = e.Argument as string[];
            int i = 0;
            setmemotext medit = new setmemotext(setmemo);
            setmemotext list = new setmemotext(setlist);
            foreach (string path in filenames)
            {
                string filename = Path.GetFileNameWithoutExtension(path);
                try
                {
                    if(!orignal.ContainsKey(filename)&&!current.ContainsKey(filename))
                    {
                        string name = null;
                        current.Add(filename, StaticHelper.ConvertTiff2Jpeg(path,ref name));
                        if(string.IsNullOrEmpty(name))
                        { 
                        this.Invoke(list,filename);
                        this.Invoke(medit, string.Format("{0}加载成功！", filename));
                        }
                        else
                        {
                            this.Invoke(medit, string.Format("{0}加载失败！", filename));
                        }
                    }
                    i++;
                    UpdateProgress((int)((float)i / (float)filenames.Length * 100));
                    Thread.Sleep(0);
                   
                }
                catch (Exception ex)
                {
                    this.Invoke(medit, string.Format("{0}加载失败:{1}",filename,ex.Message));
                }
            }
        }

        BackgroundWorker bw = new BackgroundWorker();
        BackgroundWorker addbw = new BackgroundWorker();
        BackgroundWorker savebw = new BackgroundWorker();
        private void AddTask_Load(object sender, EventArgs e)
        {
            try
            { 
            List<UserNode> users = _connector.GetNodesById(new List<string>() { string.Format("'{0}'",_parentid) }, TypeUserQuery.parentid);
                bw.DoWork += Bw_DoWork;
                bw.ProgressChanged += Bw_ProgressChanged;
                bw.RunWorkerCompleted += Bw_RunWorkerCompleted;
                bw.WorkerReportsProgress = true;
                bw.RunWorkerAsync(users);
            }
            catch(Exception ex)
            {
                message_edit.Text += ex.Message;
            }
        }
        delegate void setmemotext(string text);
        void setmemo(string text)
        {
            if(string.IsNullOrEmpty(message_edit.Text))
            {
                message_edit.Text = string.Format("{0}\r\n",text);
            }
            else
            {
                message_edit.Text = string.Format("{0}{1}\r\n",message_edit.Text, text);
            }
        }
        void setlist(string text)
        {
            task_list.Items.Add(text);
        }
        private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            setmemo("加载完成！");
        }

        private void Bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            

        }

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            List<UserNode> users = e.Argument as List<UserNode>;
            int i = 0;
            setmemotext medit = new setmemotext(setmemo);
            setmemotext list = new setmemotext(setlist);
            foreach (UserNode un in users)
            {
                try
                {

                    orignal.Add(un.nodename, _connector.getfile(un._id));
                    this.Invoke(list, un.nodename);
                    this.Invoke(medit, string.Format("{0}加载成功！",un.nodename));
                    i++;
                    
                    UpdateProgress((int)((int)((float)i / (float)users.Count * 100)));
                }
                catch (Exception ex)
                {
                    this.Invoke(medit, ex.Message);
                }
            }
        }

        private void Task_list_SelectedValueChanged(object sender, EventArgs e)
        {
            if (task_list.SelectedItem != null)
            { 
                string name = task_list.SelectedItem.ToString();
                byte[] data = null;
            if(orignal.ContainsKey(name))
            {
                    data = orignal[name];
            }
            else if(current.ContainsKey(name))
                {
                    data = current[name];
                }
            if(data !=null)
                {
                    MemoryStream ms = new System.IO.MemoryStream(data);
                    pict_display.Image = Bitmap.FromStream(ms);
                }
            }
        }

        private void Bar_cancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}