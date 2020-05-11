using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolLIbrary.Model
{
    public class User
    {
        public string _id { get; set; }
        public string username { get; set; }
        public string displayname { get; set; }
        public string pwd { get; set; }
        public string belongrole { get; set; }
        public string remark { get; set; }
        public override string ToString()
        {
            if (displayname == null)
                return "";
            else
                return displayname;
        }

    }
    public class Role
    {
        public string _id { get; set; }
        public string rolename { get; set; }
        public string displayname { get; set; }
        public string remark { get; set; }
        public override string ToString()
        {
            if (displayname == null)
                return "";
            else
                return displayname;
        }

    }
    public enum TypeNode
    {
        node = 1,
        templete = 2,
        task = 3
    }
    public class UserNode
    {
        public string _id { get; set; }
        public string parentid { get; set; }
        public string nodename { get; set; }
        public int stateimageindex { get; set; }
        TypeNode _nodetype = TypeNode.node;
        public int startrow { get; set; }
        public int startcolumn { get; set; }
        public int endcolumn { get; set; }
        public string jiaoyanren { get; set; }
        public string keycolumns { get; set; }
        public int _endrow = 5;
        public int endrow
        {
            get
            {
                return _endrow;
            }
            set
            {
                _endrow = value;
            }

        }
        int _status = 1;
        public string firstuserid { get; set; }
        public string seconduserid { get; set; }
        public int taskstatus
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }

        public TypeNode nodetype
        {
            get
            {
                return _nodetype;
            }
            set
            {
                _nodetype = value;
            }
        }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(nodename))
            {
                return nodename;
            }
            return "";
        }

    }
    public class UserTaskMap
    {
        public string _id { get; set; }
        public List<Dictionary<string, string>> _taskids;
        /// <summary>
        /// 任务映射，key为taskid
        /// </summary>
        public List<Dictionary<string, string>> taskids
        {
            get
            {
                if (_taskids == null)
                {
                    _taskids = new List<Dictionary<string, string>>();

                }
                return _taskids;
            }
        }
    }
}
