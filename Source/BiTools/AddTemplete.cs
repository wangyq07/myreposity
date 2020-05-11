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
using DevExpress.Spreadsheet;
using System.IO;
using DevExpress.XtraSpreadsheet;

namespace BiTools
{
    public partial class AddTempleteForm : DevExpress.XtraEditors.XtraForm
    {
        Dictionary<string, byte[]> filestream=new Dictionary<string, byte[]>();
        string filename;
        string fileextend = "xls";
        public string FileExtend
        {
            get
            {
                return fileextend;
            }
        }
        public Dictionary<string,byte[]> FileStreames
        {
            get
            {
                return filestream;
            }
        }
        public AddTempleteForm(string templetepath,string filnamewithoutpath)
        {
            InitializeComponent();
            spread_templete.LoadDocument(templetepath);
            filename = filnamewithoutpath;
            if(System.Text.RegularExpressions.Regex.IsMatch(templetepath,".xlsx"))
            {
                fileextend = "xlsx";
            }
            savetobytes(filnamewithoutpath,spread_templete);
        }
        private void savetobytes(string filename, SpreadsheetControl sp)
        {
            filestream.Add(filename, sp.SaveDocument(fileextend.Equals("xls")?DocumentFormat.Xls:DocumentFormat.OpenXml));
        }
        private void Btn_confirm_Click(object sender, EventArgs e)
        {
            
        }
        private void SaveWorksheet(int index)
        {
            SpreadsheetControl sp = new SpreadsheetControl();
            if(sp.LoadDocument(filestream[filename]))
            {
                IWorkbook wb = sp.Document;
              //Worksheet ws=   wb.Worksheets[index];
               for(int i=wb.Worksheets.Count-1;i>=0; i--)
                {
                    if (i == index)
                        continue;
                    wb.Worksheets.RemoveAt(i);
                }
                savetobytes(wb.Worksheets[0].Name, sp);
            }
        }
        private void Btn_cancel_Click(object sender, EventArgs e)
        {
           
        }

        private void Bar_confirm_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IWorkbook wb = spread_templete.Document;
            if (wb.Worksheets.Count > 1)
            {
                for (int i = 0; i < wb.Worksheets.Count; i++)
                {
                    if (wb.Worksheets[i].Name.ToLower().Contains("sheet"))
                    {
                        continue;
                    }
                    SaveWorksheet(i);
                }
            }
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Bar_cancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}