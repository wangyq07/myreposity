using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolLIbrary.Model
{
   public class MongodbConnection:AbConnector
    {
       MongoClient mclient;
        IMongoDatabase db;
        ConnectExpression _ce;
        
        public MongodbConnection(ConnectExpression ce) : base(ce)
        {
            try
            {
                _ce = ce;
                mclient =  new MongoDB.Driver.MongoClient(string.Format("mongodb://{0}:{1}@{2}:27017/{3}", ce.UserName, ce.Password, ce.DataSource, ce.DataBaseName));
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
        GridFSBucket gb;
        public override bool TestConnection(ref string message)
        {
            try
            {
                //mclient = new MongoDB.Driver.MongoClient(string.Format("mongodb://{0}:{1}@{2}:27017/{3}", _ce.UserName, _ce.getDesPassword(), _ce.DataSource, _ce.DataBaseName));
                db = mclient.GetDatabase(_ce.DataBaseName);
                 gb = new GridFSBucket(db);
                return true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }

        }
        public override List<User> getUsersByUserName(List<string> usernames = null)
        {
            var usercollection = db.GetCollection<User>("user");
            //usercollection.Find(BsonDocument.Parse("{}"));
            return usercollection.Find("{}").ToList<User>();
        }
        public override List<User> getUsersByPost(List<string> posts = null)
        {
            return null;
        }
        public override List<Role> getRoles(List<string> rolenames = null)
        {
            var usercollection = db.GetCollection<Role>("role");
            //usercollection.Find(BsonDocument.Parse("{}"));
            return usercollection.Find( "{}" ).ToList<Role>();
            
        }
        public override bool CheckLogin(string username, string password,ref User u)
        {
            if(db !=null)
            {
                var usercollection = db.GetCollection<User>("user");
                var users = usercollection.Find(BsonDocument.Parse(string.Format(@"{{username:""{0}"",pwd:""{1}""}}",username,password)));
                if(users !=null&&users.CountDocuments()>0)
                {
                    u = users.First();
                    return true;
                }
            }
            return false;
        }
        public override List<string> getDbList()
        {
            return mclient.ListDatabaseNames().ToList();
        }
        public override bool AddUserNode(UserNode topnode)
        { 
          var usernodes=  db.GetCollection<UserNode>("usernode");
            usernodes.InsertOne(topnode);
            return false;
        }
        public override bool updatecolectiondata(Dictionary<string, Dictionary<string, Dictionary<int, Dictionary<string, object>>>> data)
        {

            List<string> orstring = new List<string>(),andstring=new List<string>();
            foreach (string collectionname in data.Keys)
            {
                try
                { 
                var collection = db.GetCollection<BsonDocument>(collectionname);
                List<BsonDocument> bsons = new List<BsonDocument>();
                    orstring.Clear();
                foreach(string taskid in data[collectionname].Keys)
                    {
                        andstring.Clear();
                      
                        foreach (int rowindex in data[collectionname][taskid].Keys)
                        {
                            BsonDocument bd = new BsonDocument();
                            andstring.Add(string.Format("{{taskid:'{0}'}}", taskid));
                            andstring.Add(string.Format("{{rowindex:{0}}}", rowindex));
                            andstring.Add(string.Format("{{taskstaus:{0}}}", data[collectionname][taskid][rowindex]["taskstatus"]));
                            bd.AddRange(data[collectionname][taskid][rowindex]); 
                            bsons.Add(bd);
                        }
                        orstring.Add(string.Format("{{$and:[{0}]}}", string.Join(",", andstring.ToArray())));
                    }
                if(orstring.Count>0)
                collection.DeleteMany(string.Format(@"{{$or:[{0}]}}", string.Join(",", orstring.ToArray())));
                   if(bsons.Count>0)
                    collection.InsertMany(bsons);
                }
                catch(Exception ex)
                {

                }
            }
            return false;
        }
        public override  Dictionary<string, int>  getmaxstatus(Dictionary<string, Dictionary<string, int>> currentids)
        {
            var retcurrents = new Dictionary<string, int>();
            foreach(string collectionname in currentids.Keys)
            {
                //var dcol = db.GetCollection<BsonDocument>(collectionname);

                //var agreed = dcol.Aggregate<BsonDocument>("");
                List<string> taskids = new List<string>();
                foreach(string taskid in currentids[collectionname].Keys)
                {
                    taskids.Add(string.Format("'{0}'",taskid));
                }
                //获取统计后的最大taskstatus数据
                var result = db.RunCommand<BsonDocument>(string.Format(@"{{
                                                                     aggregate: '{0}',
                                                                     pipeline: [
                                                                      {{ $match: {1}}},
                                                                      {{ $group: {{_id:'$taskid',taskstatus:{{$max:'$taskstatus'}} }}  }}
                                                                        ],
                                                                         cursor:{{}}
                                                                          }}", collectionname,
                                                                          string.Format("{{taskid:{{$in:[{0}]}}}}"
                                                                          , string.Join(",", taskids.ToArray())))
                                                                          );
                //取出统计后的数据
               var resultdata= result.GetValue("cursor").AsBsonDocument.GetValue("firstBatch").AsBsonArray.ToList();
                if(resultdata.Count>0)
                {
                    foreach (BsonDocument bson in resultdata)
                    {
                        string key = bson.GetElement("_id").Value.AsString;
                        int v = bson.GetElement("taskstatus").Value.AsInt32;
                        retcurrents.Add(key, v);
                    }
                }
                //agreed.Match(string.Format("{{taskid:{{$in:[{0}]}}}}",string.Join(",",taskids.ToArray())));
                //agreed.Group<BsonDocument>("{{_id:'$taskid',taskstatus:{{$max:'$taskstatus'}}}}");
                // agreed.AppendStage<BsonDocument>(string.Format("{{taskid:{{$in:[{0}]}}}}", string.Join(",", taskids.ToArray())));
                // agreed.AppendStage<BsonDocument>("{_id:'$taskid',taskstatus:{$max:'$taskstatus'}}");
                //var list = agreed.ToList();
                // if (list.Count > 0)
                // {
                //     foreach (BsonDocument bson in list)
                //     {
                //         string key = bson.GetElement("_id").Value.AsString;
                //         int v = bson.GetElement("taskstatus").Value.AsInt32;
                //         retcurrents.Add(key, v);
                //     }
                // }
            }
            return retcurrents;
        }
        //private void deletecurrenttaskdata(IMongoCollection<BsonDocument> collection,List<BsonDocument> taskidrowindex)
        //{
        //    collection.DeleteMany();
        //}
        public override   Dictionary<int, Dictionary<string, object>>  getcolectiondata(string taskid, string collectionname, int taskstatus = 1)
        {
          Dictionary<int, Dictionary<string, object>>  retdata =new  Dictionary<int, Dictionary<string, object>>();
            var datacolleciont = db.GetCollection<BsonDocument>(collectionname);
          
           var bsons= datacolleciont.Find<BsonDocument>(string.Format("{{taskid:'{0}',taskstatus:{1}}}",taskid,taskstatus));
             if(bsons.CountDocuments()>0)
            {
                List<BsonDocument> bdocs = bsons.ToList();
                foreach(BsonDocument bdoc in bdocs)
                {
                    int curentsn = bdoc.GetValue("rowindex").ToInt32();
                    string currenttaskid = bdoc.GetValue("taskid").ToString();
                    if(!retdata.ContainsKey(curentsn))
                    retdata.Add( curentsn,bdoc.ToDictionary());
                    //foreach(BsonElement be in bdoc.Elements)
                    //{
                    //    retdata [curentsn].Add(be.Name, be.Value);
                    //}
                }
            }
            return retdata;
        }
        public override bool DeleteUserNode(List<string> nodeids = null)
        {
            var usernodes = db.GetCollection<UserNode>("usernode");
            usernodes.DeleteMany(string.Format(@"{{_id:{{$in:[{0}]}}}}",string.Join(",",nodeids.ToArray())));
            return false;
        }
        public override List<UserNode> getTaskByUser(string userid,int taskstatus)
        {
            List<UserNode> refusernodes = new List<UserNode>();
            var usernodes = db.GetCollection<UserNode>("usernode");
            if(taskstatus==1)
            {
               var nodes= usernodes.Find( string.Format(@"{{$or:[{{$and:[{{nodetype:3}},{{taskstatus: {{$gte:{0}}}}},{{firstuserid:'{1}'}}]}}
                                                        ,{{ nodetype: {{$in:[1,2]}}}}]}}", taskstatus, userid));
                if(nodes.CountDocuments()>0)
                {
                    return nodes.ToList();
                }
            }
            else if(taskstatus==2)
            {
                var nodes = usernodes.Find(string.Format(@"{{$or:[{{$and:[{{nodetype:3}},{{taskstatus:{{$gte:{0}}}}},{{seconduserid:'{1}'}}]}}
                                                        ,{{ nodetype: {{$in:[1,2]}}}}]}}", taskstatus, userid));
                if (nodes.CountDocuments() > 0)
                {
                    return nodes.ToList();
                }
            }
            else if (taskstatus == 3)
            {
                var nodes = usernodes.Find(string.Format(@"{{$or:[{{$and:[{{nodetype:3}},{{taskstatus:{{$gte:{0}}}}},{{jiaoyanren:'{1}'}}]}}
                                                        ,{{ nodetype: {{$in:[1,2]}}}}]}}", taskstatus, userid));
                if (nodes.CountDocuments() > 0)
                {
                    return nodes.ToList();
                }
            }
            else if (taskstatus == 4)
            {
                var nodes = usernodes.Find(string.Format(@"{{$or:[{{$and:[{{nodetype:3}},{{taskstatus:{{$gte:{0}}}}}]}}
                                                        ,{{ nodetype: {{$in:[1,2]}}}}]}}", taskstatus, userid));
                if (nodes.CountDocuments() > 0)
                {
                    return nodes.ToList();
                }
            }
            return refusernodes;
        }
        public override List<UserNode> GetNodesById(List<string> ids = null, TypeUserQuery querytype = TypeUserQuery.id,int status=1)
        {
            List<UserNode> refusernodes = new List<UserNode>();
            var usernodes = db.GetCollection<UserNode>("usernode");
            if (ids == null )
            {
                switch (querytype)
                {
                    case TypeUserQuery.id:
                var nodes = usernodes.Find<UserNode>("{}");
                if (nodes.CountDocuments() > 0)
                {
                    return nodes.ToList();
                }
                        return refusernodes;
                    case TypeUserQuery.nodetemplete:
                        var nodest = usernodes.Find<UserNode>( "{{ nodetype: {{$in:[1,2]}}}}");
                        if (nodest.CountDocuments() > 0)
                        {
                            return nodest.ToList();
                        }
                        return refusernodes;
                    case TypeUserQuery.task:
                        var nodesp = usernodes.Find<UserNode>(string.Format(@"{{$and:[{{nodetype:3}},{{taskstatus:{0}}}]}}",status));
                        if (nodesp.CountDocuments() > 0)
                        {
                            return nodesp.ToList();
                        }
                        return refusernodes;
                    default:
                        break;
               }
            }
             
            else if(ids !=null)
            {
                switch(querytype)
                {
                    case TypeUserQuery.id:
                        var nodes = usernodes.Find<UserNode>(string.Format(@"{{_id:{{$in:[{0}]}}}}", string.Join(",", ids.ToArray())));
                        if (nodes.CountDocuments() > 0)
                        {
                            return nodes.ToList();
                        }
                        return refusernodes;
                    case TypeUserQuery.parentid:
                        var nodesp = usernodes.Find<UserNode>(string.Format(@"{{parentid:{{$in:[{0}]}}}}", string.Join(",", ids.ToArray())));
                        if (nodesp.CountDocuments() > 0)
                        {
                            return nodesp.ToList();
                        }
                        return refusernodes;
                    default:
                        return refusernodes;
                }

            }
            

            return refusernodes;
        }
        public override string uploadfile(string filename, byte[] data)
        {
            
            ObjectId oid= gb.UploadFromBytes(filename, data); 
           
            return oid.ToString();
        }
        public override byte[] getfile(string objectid)
        {
            return gb.DownloadAsBytes(new ObjectId(objectid));
        }
        public override bool deleteuserdata(string collectionname, List<string> objectid)
        {
            var usercollection = db.GetCollection<BsonDocument>(collectionname);
            string condition = string.Join("','", objectid.ToArray());
            condition = string.Format("{{taskid:{{$in:['{0}']}}}}", condition);
            usercollection.DeleteOne(condition);
            return false;
             
        }
        public override bool deletefile(string objectid)
        {
            gb.Delete(new ObjectId(objectid));
            return false;
        }
        public override bool renameusernode(string objectid, string newname)
        {
            var usercollection = db.GetCollection<BsonDocument>("usernode");
            usercollection.UpdateOne(BsonDocument.Parse(string.Format("{{_id:'{0}'}}",objectid))
                                    ,BsonDocument.Parse(string.Format("{{'$set':{{nodename:'{0}'}}}}",newname)));
            return false;
        }
        public override bool updateusernodedatatemplete(string objectid, string startrow, string startcolumn, string endcolumn, string endrow)
        {
            var usercollection = db.GetCollection<BsonDocument>("usernode");
            usercollection.UpdateOne(BsonDocument.Parse(string.Format("{{_id:'{0}'}}", objectid))
                                    , BsonDocument.Parse(string.Format(@"{{'$set':{{startrow:{0},startcolumn:{1},endcolumn:{2},endrow:{3}}}}}"
                                                                   , startrow,startcolumn,endcolumn,endrow)));
            return false;
        }
        public override bool updateendrow(string objectid, string endrow)
        {
            var usercollection = db.GetCollection<BsonDocument>("usernode");
            usercollection.UpdateOne(BsonDocument.Parse(string.Format("{{_id:'{0}'}}", objectid))
                                    , BsonDocument.Parse(string.Format("{{'$set':{{endrow: {0} }}}}", endrow)));
            return false;
        }
        public override bool updatetaskstatus(string objectid, string status)
        {
            var usercollection = db.GetCollection<BsonDocument>("usernode");
            usercollection.UpdateOne(BsonDocument.Parse(string.Format("{{_id:'{0}'}}", objectid))
                                    , BsonDocument.Parse(string.Format("{{'$set':{{taskstatus:{0}}}}}", status)));
            return false;
        }
        public override bool EditUserMap(Dictionary<string, List<string>> dispatchtask)
        {
            var usercollection = db.GetCollection<BsonDocument>("usernode");
            foreach(string key in dispatchtask.Keys)
            {
                usercollection.UpdateOne(BsonDocument.Parse(string.Format("{{_id:'{0}'}}", key))
                                   ,BsonDocument.Parse(string.Format("{{'$set':{{firstuserid:'{0}',seconduserid:'{1}',jiaoyanren:'{2}'}}}}"
                                   ,dispatchtask[key][0], dispatchtask[key][1], dispatchtask[key][2])));
            }
            return false;
        }
        public override bool createUserDataCollectionIndex(string collectionname,  string  keycolumns)
        {
            var usercollection = db.GetCollection<BsonDocument>(collectionname);
            List<CreateIndexModel<BsonDocument>> indexcolumns = new List<CreateIndexModel<BsonDocument>>() { new CreateIndexModel<BsonDocument>("{taskid:1}"),
            new CreateIndexModel<BsonDocument>("{rowindex:1}"),new CreateIndexModel<BsonDocument>("{taskstaus:1}") };
            usercollection.Indexes.CreateMany(indexcolumns);
            return false;
        }
        public override bool deleteUser(List<User> deletuser)
        {
            var usercollection = db.GetCollection<User>("user");
            var userids = deletuser.Select(c => c._id);
            string condition = string.Join("','", userids.ToArray());
            condition = string.Format("{{_id:{{$in:['{0}']}}}}", condition);
            usercollection.DeleteMany(condition);
            return false;
        }
        public override bool updateuser(List<User> user)
        {
            var usercollection = db.GetCollection<BsonDocument>("user");
            //var userids = user.Select(c => c._id);
            foreach(User u in user)
            usercollection.UpdateOne(string.Format("{{_id:'{0}'}}",u._id),string.Format("{{ '$set':{{ username:'{0}',displayname:'{1}',belongrole:'{2}'}}}}", u.username,u.displayname,u.belongrole));
                return false;
        }
        public override bool changeuserpassword(string _id, string password)
        {
            var usercollection = db.GetCollection<BsonDocument>("user");
            //var userids = user.Select(c => c._id);
            
                usercollection.UpdateOne(string.Format("{{_id:'{0}'}}", _id), string.Format("{{ '$set':{{ pwd:'{0}'}}}}", password));
            return false;
        }
        public override bool adduser(List<User> user)
        {
            var usercollection = db.GetCollection<User>("user");
            usercollection.InsertMany(user);
            return false;
        }
        public override bool deleterole(List<Role> deletuser)
        {
            var usercollection = db.GetCollection<Role>("role");
            var userids = deletuser.Select(c => c._id);
            string condition = string.Join("','", userids.ToArray());
            condition = string.Format("{{_id:{{$in:['{0}']}}}}", condition);
            usercollection.DeleteMany(condition);
            return false;
             
        }
        public override bool updaterole(List<Role> user)
        {
            var usercollection = db.GetCollection<BsonDocument>("role");
            //var userids = user.Select(c => c._id);
            foreach (Role u in user)
                usercollection.UpdateOne(string.Format("{{_id:'{0}'}}", u._id), string.Format("{{ '$set':{{ username:'{0}',displayname:'{1}'}}}}", u.rolename, u.displayname));
            return false;
        }
        public override bool addrole(List<Role> user)
        {
            var usercollection = db.GetCollection<Role>("role");
            usercollection.InsertMany(user);
            return false;
        }
    }
    public enum TypeQuery
    {
        User=1,
        Data=2,
        Role=3,
    }
}
