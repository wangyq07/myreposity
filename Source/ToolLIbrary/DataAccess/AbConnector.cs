using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ToolLIbrary.Model
{
    public abstract class AbConnector
    {
        public AbConnector(ConnectExpression ce)
        {

        }
        public virtual Dictionary<int, Dictionary<string, object>> getcolectiondata(string taskid,string collectionname,int taskstatus=1)
        {
            return null;
        }
        public virtual bool updatecolectiondata(Dictionary<string, Dictionary<string, Dictionary<int, Dictionary<string, object>>>> data)
        {

            return false;
        }
        public virtual List<string> getDbList()
        {
            return null;
        }
        public virtual bool TestConnection(ref string message)
        {
            return false;
        }
        public virtual void BatchExcute<T>(T Data)
        {

        }
       public virtual void ExcuteSql<T>(T Command)
        {

        }
        public virtual List<User> getUsersByUserName(List<string> usernames=null)
        {
            return null;
        }
        public virtual List<User> getUsersByPost(List<string> posts=null)
        {
            return null;
        }
        public virtual List<Role> getRoles(List<string> rolenames=null)
        {
            return null;
        }
       public virtual bool CheckLogin(string username,string password, ref User u)
        {
            return false;
        }
        
        public virtual bool AddUserNode(UserNode topnode)
        {
            return false;
        }
        public virtual List<UserNode> GetNodesById( List<string>   ids=null, TypeUserQuery querytype=TypeUserQuery.id, int status = 1)
        {
            return null;
        }
        public virtual bool DeleteUserNode(List<string> nodeids=null)
        {
            return false;
        }
        public virtual string uploadfile(string filename,byte[] data)
        {
            return string.Empty;
        }
        public virtual bool renameusernode(string objectid,string newname)
        {
            return false;
        }
        public virtual byte[] getfile(string objectid)
        {
            return null;
        }
        public virtual bool deletefile(string objectid)
        {
            return false;
        }
        public virtual  Dictionary<string,int>  getmaxstatus(Dictionary<string,Dictionary<string,int>> currentids)
        {
            return null;
        }
        public virtual bool updateusernodedatatemplete(string objectid,string startrow,string startcolumn,string endcolumn,string endrow)
        {
            return false;
        }
        public virtual bool updateendrow(string objectid,string endrow)
        {
            return false;
        }
        public virtual bool updatetaskstatus(string objectid,string status)
        {
            return false;
        }
        public virtual bool EditUserMap(Dictionary<string, List<string>> dispatchtask)
        {
            return false;
        }
        public virtual bool createUserDataCollectionIndex(string collectionname, string  keycolumns)
        {
            return false;
        }
        public virtual bool deleteUser(List<User> deletuser)
        {
            return false;
        }
        public virtual bool updateuser(List<User>  user)
        {
            return false;
        }
        public virtual bool adduser(List<User> user)
        {
            return false;
        }
        public virtual bool deleterole(List<Role> deletuser)
        {
            return false;
        }
        public virtual bool updaterole(List<Role> user)
        {
            return false;
        }
        public virtual bool deleteuserdata(string collectionname,List<string> objectid)
        {

            return false;
        }
        public virtual bool addrole(List<Role> user)
        {
            return false;
        }
        public virtual bool changeuserpassword(string _id,string password)
        {
            return false;
        }
        public virtual List<UserNode> getTaskByUser(string userid, int taskstatus)
        {
            return null;
        }
    }
    public enum TypeUserQuery
    {
        parentid=0,
        id=1,
        task=2,
        nodetemplete=3
    }

}
