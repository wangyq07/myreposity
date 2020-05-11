using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolLIbrary.Model
{
   public class BuildConnector
    {
        //static IConnector connector;
        public static AbConnector buildConnector(DbaseType connecttype,ConnectExpression ce)
        {
            switch(connecttype)
            {
                case DbaseType.mysql:
                    if(string.IsNullOrWhiteSpace(ce.DataBaseName))
                    {
                        ce.DataBaseName = "mysql";
                    }
                    return new MySqlConnector(ce);
                case DbaseType.mongo:
                    if (string.IsNullOrWhiteSpace(ce.DataBaseName))
                    {
                        ce.DataBaseName = "admin";
                    }
                    return new MongodbConnection(ce);
                default:
                    if (string.IsNullOrWhiteSpace(ce.DataBaseName))
                    {
                        ce.DataBaseName = "admin";
                    }
                    return new MongodbConnection(ce);
            }
        }
    }
    public enum DbaseType
    {
        mysql=1,
        sqlserver=2,
        mongo=3,
    }
}
