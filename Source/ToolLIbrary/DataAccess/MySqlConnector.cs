using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolLIbrary.Model
{
   public class MySqlConnector:AbConnector
    {
        MySqlConnection mysqlcon;
        public MySqlConnector(ConnectExpression ce):base(ce)
        {
            try
            { 
            mysqlcon = new MySqlConnection(string.Format("server={0};user={1};database={2};password={3};port=3306",ce.DataSource
                                                         ,ce.UserName,ce.DataBaseName,ce.Password));
            }
            catch(Exception ex)
            {
                string error = ex.Message;
            }
        }
        public override bool TestConnection(ref string message)
        {
            try
            {
                mysqlcon.Open();
                mysqlcon.Close();
                return true;
            }
            catch(Exception ex)
            {
                message = ex.Message;
                return false;
            }
            
        }
        public override List<string> getDbList()
        {
            List<string> dblist = new List<string>();
           
                MySqlDataAdapter mda = new MySqlDataAdapter();
            MySqlCommand mycmd = new MySqlCommand("select SCHEMA_NAME from information_schema.SCHEMATA ", mysqlcon);
            mda.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            mda.SelectCommand = mycmd;
                DataTable dt = new DataTable();
                mda.Fill(dt);
            
                foreach (DataRow row in dt.Rows)
                {
                    dblist.Add(row[0].ToString());
                }
             

            return dblist;
        }
    }
}
