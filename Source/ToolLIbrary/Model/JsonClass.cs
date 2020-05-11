using log4net;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ToolLIbrary.Model
{
    /// <summary>
    /// Json系列化接口数据时调用
    /// </summary>
    public class JsonInterfaceConverter<T> : JsonConverter
    {
        #region Constructor

        #endregion

        #region Member

        #endregion

        #region Event

        #endregion

        #region Private Progerty

        #endregion

        #region Public Progerty

        #endregion

        #region Public Methods

        public override bool CanConvert(Type objectType)
        {
            return true;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize<T>(reader);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }

        #endregion

        #region Private Methods

        #endregion


    }
    
    /// <summary>
    /// Json系列化接口数据时调用
    /// </summary>
    /// <summary>
    /// Use KnownType Attribute to match a divierd class based on the class given to the serilaizer
    /// Selected class will be the first class to match all properties in the json object.
    /// </summary>
    public class KnownTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return System.Attribute.GetCustomAttributes(objectType).Any(v => v is KnownTypeAttribute);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            
            JObject jObject = JObject.Load(reader);

           
            System.Attribute[] attrs = System.Attribute.GetCustomAttributes(objectType);  // Reflection. 
  
            string currentkey = string.Empty;
            string currenttype = string.Empty;
            foreach (System.Attribute attr in attrs)
            {
                if (attr is KnownTypeAttribute)
                {
                    KnownTypeAttribute k = (KnownTypeAttribute)attr;
                    var props = k.Type.GetProperties();
                    bool found = true;
                    foreach (var f in jObject)
                    {
                        if (props.Any(z => z.Name == f.Key))
                        {
                            found = true;
                            break;
                        }
                        currentkey = f.Key;

                    }
                    currenttype = (attr as KnownTypeAttribute).Type.FullName;
                    if (found)
                    {
                        Assembly asm = System.Reflection.Assembly.Load(currenttype);

                        var target = asm.CreateInstance(currenttype);

                        serializer.Populate(jObject[currentkey].CreateReader(), target);
                        return target;
                    }
                }
            }
            return null; 

        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {

        }
    }
     
    public abstract class JsonCreationConverter<T> : JsonConverter
    {
        protected abstract T Create(Type objectType, JObject jObject);

        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            // Load JObject from stream
            JObject jObject = JObject.Load(reader);

            // Create target object based on JObject
            T target = Create(objectType, jObject);

            // Populate the object properties
            StringWriter writer = new StringWriter();
            serializer.Serialize(writer, jObject);
            using (JsonTextReader newReader = new JsonTextReader(new StringReader(writer.ToString())))
            {
                 
                serializer.Populate(newReader, target);
            }

            return target;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
    public class LimitPropsContractResolver : DefaultContractResolver
    {

        string[] props = null;

        public LimitPropsContractResolver(string[] props)
        {

            //指定要序列化属性的清单

            this.props = props;


        }
        
        IList<JsonProperty> curentPrpoperty;
        protected override IList<JsonProperty> CreateProperties(Type type,

        MemberSerialization memberSerialization)
        {

            IList<JsonProperty> list =

            base.CreateProperties(type, memberSerialization);

            //只保留清单有列出的属性

            curentPrpoperty = list.Where(p => props.Contains(p.PropertyName)).ToList();
            return curentPrpoperty;

        }
        
    }
    /// <summary>
    /// 序列化和反序列化对象
    /// </summary>
    public class JsonClass
    {

        /// <summary>
        /// 获取序列化对象的字符串
        /// </summary>
        /// <param name="obj">传入的Object 对象</param>
        /// <returns>返回序列化的对象</returns>
        public static string GetJsonString<T>(T obj)
        {

            return JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);
        }
        /// <summary>
        /// 获取序列化对象的字符串,p
        /// </summary>
        /// <param name="obj">传入的Object 对象</param>
        /// <returns>返回序列化的对象</returns>
        public static string GetJsonString<T>(T obj, string[] prop)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ContractResolver = new LimitPropsContractResolver(prop);
            return JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented, settings);
        }
        /// <summary>
        /// 反序列化对象
        /// </summary>
        /// <typeparam name="T">泛型对象参数</typeparam>
        /// <param name="jsonstring">对象内容字符串</param>
        /// <returns>返回对象内容</returns>
        public static T DeserialJson<T>(string jsonstring)
        {
            return JsonConvert.DeserializeObject<T>(jsonstring);
        }
        /// <summary>
        /// 序列化对象到文件
        /// </summary>
        /// <typeparam name="T">泛型对象名称</typeparam>
        /// <param name="FileName">文件名称</param>
        /// <param name="obj">要序列化的对象</param>
        /// <param name="IsFilePath">是否全路径，若不是全路径默认存入系统Tmp文件路径中</param>
        public static void SaveToXml<T>(string FileName, T obj, string[] prop, bool IsFilePath = true)
        {
            XmlDocument xmldoc = new XmlDocument();
            XmlNode nd = xmldoc.CreateNode(XmlNodeType.Element, "Root", string.Empty);
            nd.InnerText = GetJsonString(obj, prop);
            xmldoc.AppendChild(nd);
            //XmlDocumentType xmt = new XmlDocumentType();
            //XmlAttribute xa = xmldoc.CreateAttribute();
            //xmldoc.DocumentType=xmt;
            xmldoc.Save(string.Format(@"{0}", !IsFilePath ? string.Format(@"{0}/{1}", Constants.SYS_TEMP_PATH, FileName) : FileName));
        }
        /// <summary>
        /// 序列化对象到文件
        /// </summary>
        /// <typeparam name="T">泛型对象名称</typeparam>
        /// <param name="FileName">文件名称</param>
        /// <param name="obj">要序列化的对象</param>
        /// <param name="IsFilePath">是否全路径，若不是全路径默认存入系统Tmp文件路径中</param>
        public static void SaveToXml<T>(string FileName, T obj, bool IsFilePath = true)
        {
            XmlDocument xmldoc = new XmlDocument();
            XmlNode nd = xmldoc.CreateNode(XmlNodeType.Element, "Root", string.Empty);
            nd.InnerText = GetJsonString(obj);
            xmldoc.AppendChild(nd);
            //XmlDocumentType xmt = new XmlDocumentType();
            //XmlAttribute xa = xmldoc.CreateAttribute();
            //xmldoc.DocumentType=xmt;
            xmldoc.Save(string.Format(@"{0}", !IsFilePath ? string.Format(@"{0}/{1}", Constants.SYS_TEMP_PATH, FileName) : FileName));
        }
        /// <summary>
        /// 取得反序列化对象从Xml文件中获取
        /// </summary>
        /// <typeparam name="T">泛型对象</typeparam>
        /// <param name="FileName">文件名</param>
        /// <param name="IsFilePath">是否全路径</param>
        /// <returns>返回序列化对象</returns>
        public static T GetDeserialObjectFromXml<T>(string FileName, string[] prop, bool IsFilePath = true)
        {
            string xmlfile = string.Format(@"{0}", !IsFilePath ? string.Format(@"{0}/{1}", Constants.SYS_TEMP_PATH, FileName) : FileName);
            if (File.Exists(xmlfile))
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(xmlfile);
                XmlNode nd = xmldoc.SelectSingleNode("Root");

                return JsonConvert.DeserializeObject<T>(nd.InnerText);
            }
            return default(T);
        }
        /// <summary>
        /// 取得反序列化对象从Xml文件中获取
        /// </summary>
        /// <typeparam name="T">泛型对象</typeparam>
        /// <param name="FileName">文件名</param>
        /// <param name="IsFilePath">是否全路径</param>
        /// <returns>返回序列化对象</returns>
        public static T GetDeserialObjectFromXml<T>(string FileName, bool IsFilePath = true)
        {
            string xmlfile = string.Format(@"{0}", !IsFilePath ? string.Format(@"{0}/{1}", Constants.SYS_TEMP_PATH, FileName) : FileName);
            if (File.Exists(xmlfile))
            {
                try
                {
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.Load(xmlfile);
                    XmlNode nd = xmldoc.SelectSingleNode("Root");

                    return JsonConvert.DeserializeObject<T>(nd.InnerText);
                }
                catch
                {

                }
            }
            return default(T);
        }
    }
     
    public class JTypeDescriptor : ICustomTypeDescriptor
    {
        public JTypeDescriptor(JObject jobject)
        {
            if (jobject == null)
                throw new ArgumentNullException("jobject");

            JObject = jobject;
        }

        // NOTE: the property grid needs at least one r/w property otherwise it will not show properly in collection editors...
        public JObject JObject { get; set; }

        public override string ToString()
        {
            // we display this object's serialized json as the display name, for example
            return JObject.ToString(Newtonsoft.Json.Formatting.None);
        }

        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties(Attribute[] attributes)
        {
            // browse the JObject and build a list of pseudo-properties
            List<PropertyDescriptor> props = new List<PropertyDescriptor>();
            foreach (var kv in JObject)
            {
                props.Add(new Prop(kv.Key, kv.Value, null));
            }
            return new PropertyDescriptorCollection(props.ToArray());
        }

        AttributeCollection ICustomTypeDescriptor.GetAttributes()
        {
            return null;
        }

        string ICustomTypeDescriptor.GetClassName()
        {
            return null;
        }

        string ICustomTypeDescriptor.GetComponentName()
        {
            return null;
        }

        TypeConverter ICustomTypeDescriptor.GetConverter()
        {
            return null;
        }

        EventDescriptor ICustomTypeDescriptor.GetDefaultEvent()
        {
            throw new NotImplementedException();
        }

        PropertyDescriptor ICustomTypeDescriptor.GetDefaultProperty()
        {
            return null;
        }

        object ICustomTypeDescriptor.GetEditor(Type editorBaseType)
        {
            return null;
        }

        EventDescriptorCollection ICustomTypeDescriptor.GetEvents(Attribute[] attributes)
        {
            throw new NotImplementedException();
        }

        EventDescriptorCollection ICustomTypeDescriptor.GetEvents()
        {
            throw new NotImplementedException();
        }

        PropertyDescriptorCollection ICustomTypeDescriptor.GetProperties()
        {
            return ((ICustomTypeDescriptor)this).GetProperties(null);
        }

        object ICustomTypeDescriptor.GetPropertyOwner(PropertyDescriptor pd)
        {
            return this;
        }

        // represents one dynamic pseudo-property
        private class Prop : PropertyDescriptor
        {
            private Type _type;
            private object _value;

            public Prop(string name, object value, Attribute[] attrs)
                : base(name, attrs)
            {
                _value = ComputeValue(value);
                _type = _value == null ? typeof(object) : _value.GetType();
            }

            private static object ComputeValue(object value)
            {
                if (value == null)
                    return null;

                JArray array = value as JArray;
                if (array != null)
                {
                    // we use the arraylist because that's all the property grid needs...
                    ArrayList list = new ArrayList();
                    for (int i = 0; i < array.Count; i++)
                    {
                        JObject subo = array[i] as JObject;
                        if (subo != null)
                        {
                            JTypeDescriptor td = new JTypeDescriptor(subo);
                            list.Add(td);
                        }
                        else
                        {
                            JValue jv = array[i] as JValue;
                            if (jv != null)
                            {
                                list.Add(jv.Value);
                            }
                            else
                            {
                                // etc.
                            }
                        }
                    }
                    // we don't support adding things
                    return ArrayList.ReadOnly(list);
                }
                else
                {
                    // etc.
                }
                return value;
            }

            public override bool CanResetValue(object component)
            {
                return false;
            }

            public override Type ComponentType
            {
                get { return typeof(object); }
            }

            public override object GetValue(object component)
            {
                return _value;
            }

            public override bool IsReadOnly
            {
                get { return false; }
            }

            public override Type PropertyType
            {
                get { return _type; }
            }

            public override void ResetValue(object component)
            {
            }

            public override void SetValue(object component, object value)
            {
                _value = value;
            }

            public override bool ShouldSerializeValue(object component)
            {
                return false;
            }
        }
    }
    /// <summary>
    /// 数据相关操作
    /// </summary>
    public class DataOperate
    {
        /// <summary>
        /// 获取有更新的字段
        /// </summary>
        /// <param name="cols">列名集合</param>
        /// <param name="uptable">要更新的数据表</param>
        /// <returns>返回要更新的字段</returns>
        public static List<string> GetUpdateFields(List<string> cols, DataTable uptable)
        {
            List<string> updfield = new List<string>();
            foreach (DataRow dr in uptable.Rows)
            {
                foreach (string cle in cols)
                {
                    if (!dr[cle, DataRowVersion.Current].Equals(dr[cle, DataRowVersion.Original]))
                    {
                        if (!updfield.Contains(cle))
                            updfield.Add(cle);
                    }
                }
            }
            return updfield;
        }
    }
    /// <summary>
    /// 统一日志输出的类
    /// </summary>
    public class Output
    {
        private static bool _isErrorMsg = false;
        /// <summary>
        /// 是否存在错误信息
        /// </summary>
        public static bool IsErrorMsg
        {
            get { return _isErrorMsg; }
            set { _isErrorMsg = value; }
        }
        //public static readonly ILog Logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// 取得日志存放路径
        /// </summary>
        /// <param name="logconfig">日志表</param>

        public static void ReplaceFileTag(string logconfig)
        {
            try
            {
                System.IO.FileStream fs = new System.IO.FileStream(logconfig, System.IO.FileMode.Open, System.IO.FileAccess.ReadWrite);
                StreamReader sr = new StreamReader(fs, System.Text.Encoding.UTF8);
                string str = sr.ReadToEnd();
                sr.Close();
                fs.Close();

                if (str.IndexOf("#LOG_PATH#") > -1)
                {
                    str = str.Replace(@"#LOG_PATH#", Constants.SYS_TEMP_PATH);
                    System.IO.FileStream fs1 = new System.IO.FileStream(logconfig, System.IO.FileMode.Open, System.IO.FileAccess.Write);
                    StreamWriter swWriter = new StreamWriter(fs1, System.Text.Encoding.UTF8);
                    swWriter.Flush();
                    swWriter.Write(str);
                    swWriter.Close();
                    fs1.Close();
                }
            }
            catch (System.Exception ex)
            {

            }
        }
        /// <summary>
        /// 初始化日志器
        /// </summary>
        /// <param name="name">日志名称</param>
        public static void InitLogger(string name)
        {

            string logconfig = @"log4net.config";
            ReplaceFileTag(logconfig);

            Stopwatch st = new Stopwatch();//实例化类
            st.Start();//开始计时
            log4net.GlobalContext.Properties["dynamicName"] = name;
            Logger = LogManager.GetLogger(name);
            st.Stop();//终止计时
            if (st.ElapsedMilliseconds > 2000)
            {
                Logger.Info("log4net.config file ERROR!!!");
                System.IO.FileStream fs = new System.IO.FileStream(logconfig, System.IO.FileMode.Open, System.IO.FileAccess.ReadWrite);
                StreamReader sr = new StreamReader(fs, System.Text.Encoding.UTF8);
                string str = sr.ReadToEnd();
                str = str.Replace(@"ref=""SQLAppender""", @"ref=""SQLAppenderError""");
                sr.Close();
                fs.Close();
                System.IO.FileStream fs1 = new System.IO.FileStream(logconfig, System.IO.FileMode.Open, System.IO.FileAccess.Write);
                StreamWriter swWriter = new StreamWriter(fs1, System.Text.Encoding.UTF8);
                swWriter.Flush();
                swWriter.Write(str);
                swWriter.Close();
                fs1.Close();
            }
        }
        //public static ILog Logger =
        //    LogManager.Exists(Constants.PORCESS_NAME.IndexOf('.') > -1 ? Constants.PORCESS_NAME.Substring(0, Constants.PORCESS_NAME.IndexOf('.')) : Constants.PORCESS_NAME) != null ?
        //    LogManager.Exists(Constants.PORCESS_NAME.IndexOf('.') > -1 ? Constants.PORCESS_NAME.Substring(0, Constants.PORCESS_NAME.IndexOf('.')) : Constants.PORCESS_NAME) :
        //    LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static ILog Logger = null;    // LogManager.GetLogger(System.Diagnostics.Process.GetCurrentProcess().ProcessName);
                                             /// <summary>
                                             /// 事件传送信息打印
                                             /// </summary>
                                             /// <param name="sender"></param>
                                             /// <param name="e"></param>
                                             /// <param name="SourceFile"></param>
                                             /// <param name="SourceLine"></param>
        public static void EventsMsg(object sender, object e, System.Diagnostics.StackFrame SourceFile)
        {
            string msg = string.Format("[FILE:{0} ],LINE:{1},{2}] sender:{3},e:{4}", SourceFile.GetFileName(), SourceFile.GetFileLineNumber(), SourceFile.GetMethod(), sender.GetType(), e.GetType());
            //Trace.WriteLine(msg);
            if (Logger != null)
            {
                Logger.Info(msg);
            }
        }
        public static void Info(string message)
        {
            if (Logger != null)
            {
                Logger.Info(message);
            }
        }
        public static void Error(string message, Exception ex)
        {
            if (Logger != null)
            {
                Logger.Error(message, ex);
            }
        }
        /// <summary>
        /// 获取文件消息
        /// </summary>
        /// <param name="SourceFile"></param>
        /// <returns></returns>
        private static string getFileMsg(System.Diagnostics.StackFrame SourceFile)
        {
            return string.Format("FILE: [{0}] LINE:[{1}] Method:[{2}]", SourceFile.GetFileName(), SourceFile.GetFileLineNumber(), SourceFile.GetMethod());
        }
        public static void Error(System.Diagnostics.StackFrame SourceFile, Exception ex)
        {
            if (ex == null)
                return;
            if (Logger != null)
            {
                Logger.Info(getFileMsg(SourceFile));
                Logger.Error(ex.Message);
                if (ex.InnerException != null)
                    Logger.Fatal(ex.InnerException);
            }
            //if(IsErrorMsg)
            //    System.Windows.Forms.XtraMessageBox.Show(ex.Message);
        }
        private static void Info(System.Diagnostics.StackFrame SourceFile, string infomsg)
        {
            if (infomsg == null)
                return;
            if (Logger != null)
            {
                Logger.Info(getFileMsg(SourceFile));
                Logger.Info(infomsg);
            }
            //if(IsErrorMsg)
            //    System.Windows.Forms.XtraMessageBox.Show(ex.Message);
        }
    }
    /// <summary>
    /// 系统需要使用到的常量
    /// </summary>
    public class Constants
    {
        public Constants()
        {
            if (!System.IO.Directory.Exists(TEMP_PATH))
                Directory.CreateDirectory(TEMP_PATH);
            if (!System.IO.Directory.Exists(LOG_PATH))
                Directory.CreateDirectory(LOG_PATH);
        }
        /// <summary>
        /// 拷贝目录内容
        /// </summary>
        /// <param name="source">源目录</param>
        /// <param name="destination">目的目录</param>
        /// <param name="copySubDirs">是否拷贝子目录</param>
        public static void CopyDirectory(DirectoryInfo source, DirectoryInfo destination, bool copySubDirs)
        {
            if (!destination.Exists)
            {
                destination.Create(); //目标目录若不存在就创建
            }
            FileInfo[] files = source.GetFiles();
            foreach (FileInfo file in files)
            {
                file.CopyTo(Path.Combine(destination.FullName, file.Name), true); //复制目录中所有文件
            }
            if (copySubDirs)
            {
                DirectoryInfo[] dirs = source.GetDirectories();
                foreach (DirectoryInfo dir in dirs)
                {
                    string destinationDir = Path.Combine(destination.FullName, dir.Name);
                    CopyDirectory(dir, new DirectoryInfo(destinationDir), copySubDirs); //复制子目录
                }
            }
        }
        public const double Pi = 3.14159;
        public const int SpeedOfLight = 300000; // km per sec.
                                                //public const string TEMP_PATH = System.Environment.GetEnvironmentVariable("TEMP");
                                                /// <summary>
                                                /// 
                                                /// </summary>
        //public const string XML_FILE_FILTER = Language.GetString("Xml_files");
        ///// <summary>
        ///// Excel文件对话框过滤
        ///// </summary>
        //public const string EXCLE_FILE_FILTER = Language.GetString("Excel_files");
        ///// <summary>
        ///// Excel文件对话框过滤
        ///// </summary>
        //public const string FLAT_FILE_FILTER = Language.GetString("Text_File");
        ///// <summary>
        ///// Access数据库的文件对话框过滤
        ///// </summary>
        //public const string ACCESS_FILE_FILTER = Language.GetString("Access_files");
        /// <summary>
        /// 目的表和源表的 映射关系表 表名称
        /// </summary>
        public const string TABLE_MAPS_NAME = "SYS_TAB_MAPS";
        /// <summary>
        /// 目的列和源列的 映射关系表 表名称
        /// </summary>
        public const string COLUMN_MAPS_NAME = "SYS_COLUMN_MAPS";
        /// <summary>
        /// 基本数据表信息，包括数据库的版本，等一些常用固定的信息，
        /// 在系统初始化的时候写入
        /// </summary>
        public const string SYS_DATA_INFO = "SYS_DATA_INFO";
        public static string PORCESS_NAME = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
        /// <summary>
        /// 
        /// </summary>
        //public static string EXE_PATH = Assembly.GetEntryAssembly().Location;
        /// <summary>
        /// 
        /// </summary>
        public static string BIN_PATH = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        /// <summary>
        /// 
        /// </summary>
        public static string ROOT_PATH = BIN_PATH + @"\..\";
        /// <summary>
        /// 系统临时文件路径
        /// </summary>
        public static string SYS_TEMP_PATH = /*System.Environment.GetEnvironmentVariable("TEMP")*/AppDomain.CurrentDomain.BaseDirectory + @"\";
        /// <summary>
        /// 系统临时文件路径
        /// </summary>
        /// 
        public static string SYS_TMP_PATH = AppDomain.CurrentDomain.BaseDirectory + @"\";
        /// <summary>
        /// 配置文件路径,此路径只读 ，系统按装后的配置文件路径
        /// </summary>
        public static string SYS_CONFIG_PATH = ROOT_PATH + @"\Config\";
        /// <summary>
        /// 
        /// </summary>
        public static string SYS_GLOBAL_PATH = SYS_CONFIG_PATH + @"\Global\";

        /// <summary>
        /// 临时文件路径
        /// </summary>
        public static string TEMP_PATH = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\opt\Temp\";
        /// <summary>
        /// 配置文件路径,此路径可写
        /// </summary>
        public static string CONFIG_PATH = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\opt\Config\";
        /// <summary>
        /// 
        /// </summary>
        public static string CONFIG_PATH1 = AppDomain.CurrentDomain.BaseDirectory;
        /// <summary>
        /// 日志路径
        /// </summary>
        public static string LOG_PATH = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + @"\opt\Log\";
        /// <summary>
        /// 
        /// </summary>
        public static string CONFIG_SCHEMA = Constants.SYS_CONFIG_PATH + @"\Global\db\ImportConfigSchema.xml";

        /// <summary>
        /// WELL_LOG表名
        /// </summary>
        public const string WELL_LOG_TABLE_NAME = "T_WELL_LOG";//目标表
    }
    public class Regedit
    {
        public static void Access_Registry(RegistryKey keyR, String strHome, string key, ref List<string> value)
        {
            string[] subkeyNames;
            string[] subvalueNames;
            try
            {
                RegistryKey aimdir = keyR.OpenSubKey(strHome, true);
                if (aimdir != null)
                {
                    subvalueNames = aimdir.GetValueNames();
                    foreach (string valueName in subvalueNames)
                    {
                        if (valueName.Equals("ORACLE_HOME"))
                        {
                            Object val = aimdir.GetValue(key);
                            value.Add(val.ToString());
                            break;
                        }
                    }
                    subkeyNames = aimdir.GetSubKeyNames();
                    foreach (string keyName in subkeyNames)
                    {
                        Access_Registry(aimdir, keyName, key, ref value);
                    }
                }
            }
            catch (System.Exception ex)
            {
                Output.Logger.Error(ex.Message);
            }
            //Console.ReadLine();
        }
    }
    /// <summary>
    /// Json文件处理类
    /// </summary>
    public static class JsonFile
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string Read(string fileName, System.Text.Encoding en = null)
        {
            string json = string.Empty;
            string strLine = string.Empty;

            try
            {
                if (en == null)
                    en = Encoding.UTF8;

                using (FileStream fsSource = new FileStream(fileName,
                   System.IO.FileMode.Open, System.IO.FileAccess.Read, FileShare.ReadWrite))
                {

                    //StreamReader sr = new StreamReader(fsSource);
                    //strLine = sr.ReadLine();
                    //while (strLine != null)
                    //{
                    //    Console.WriteLine(strLine);
                    //    strLine = sr.ReadLine();
                    //}


                    // Read the source file into a byte array.
                    byte[] bytes = new byte[fsSource.Length];
                    int numBytesToRead = (int)fsSource.Length;
                    int numBytesRead = 0;
                    while (numBytesToRead > 0)
                    {
                        // Read may return anything from 0 to numBytesToRead.
                        int n = fsSource.Read(bytes, numBytesRead, numBytesToRead);
                        // Break when the end of the file is reached.
                        if (n == 0)
                            break;
                        numBytesRead += n;
                        numBytesToRead -= n;
                    }
                    numBytesToRead = bytes.Length;
                    json = en.GetString(bytes);
                }
            }
            catch (FileNotFoundException ex)
            {
                Output.Logger.Error(ex.Message);
            }
            catch (System.Exception ex)
            {
                Output.Logger.Error(ex.Message);
            }
            finally
            {
            }
            return json;
        }
        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="fileName">文件路径</param>
        /// <param name="json">json字符串</param>
        public static void Write(string fileName, string json, System.Text.Encoding en = null)
        {
            try
            {
                if (en == null)
                    en = Encoding.UTF8;

                FileInfo file = new FileInfo(fileName);
                if (!Directory.Exists(file.DirectoryName))
                {
                    Directory.CreateDirectory(file.DirectoryName);
                }

                using (FileStream fs = new FileStream(fileName,
                  FileMode.Create, FileAccess.Write, FileShare.ReadWrite
                 ))
                {
                    try
                    {
                        byte[] byteArray = en.GetBytes(json);
                        fs.Position = 0;
                        //将待写入内容追加到文件末尾  
                        fs.Write(byteArray, 0, byteArray.Length);
                    }
                    catch (System.Exception ex)
                    {
                        Output.Logger.Error(ex.Message);
                    }
                    finally
                    {
                        fs.Close();
                    }
                }
            }
            catch (System.Exception ex)
            {
                Output.Logger.Error(ex.Message);
            }

        }


        /// <summary>
        /// 取得一个文本文件的编码方式。如果无法在文件头部找到有效的前导符，Encoding.UTF8将被返回。
        /// </summary>
        /// <param name="fileName">文件名。</param>
        /// <returns></returns>
        public static Encoding GetEncoding(string fileName)
        {
            return GetEncoding(fileName, Encoding.UTF8);
        }
        /// <summary>
        /// 取得一个文本文件流的编码方式。
        /// </summary>
        /// <param name="stream">文本文件流。</param>
        /// <returns></returns>
        public static Encoding GetEncoding(FileStream stream)
        {
            return GetEncoding(stream, Encoding.UTF8);
        }
        /// <summary>
        /// 取得一个文本文件的编码方式。
        /// </summary>
        /// <param name="fileName">文件名。</param>
        /// <param name="defaultEncoding">默认编码方式。当该方法无法从文件的头部取得有效的前导符时，将返回该编码方式。</param>
        /// <returns></returns>
        public static Encoding GetEncoding(string fileName, Encoding defaultEncoding)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open);
            Encoding targetEncoding = GetEncoding(fs, defaultEncoding);
            fs.Close();
            return targetEncoding;
        }
        /// <summary>
        /// 取得一个文本文件流的编码方式。
        /// </summary>
        /// <param name="stream">文本文件流。</param>
        /// <param name="defaultEncoding">默认编码方式。当该方法无法从文件的头部取得有效的前导符时，将返回该编码方式。</param>
        /// <returns></returns>
        public static Encoding GetEncoding(FileStream stream, Encoding defaultEncoding)
        {
            Encoding targetEncoding = defaultEncoding;
            if (stream != null && stream.Length >= 2)
            {
                //保存文件流的前4个字节
                byte byte1 = 0;
                byte byte2 = 0;
                byte byte3 = 0;
                byte byte4 = 0;
                //保存当前Seek位置
                long origPos = stream.Seek(0, SeekOrigin.Begin);
                stream.Seek(0, SeekOrigin.Begin);

                int nByte = stream.ReadByte();
                byte1 = Convert.ToByte(nByte);
                byte2 = Convert.ToByte(stream.ReadByte());
                if (stream.Length >= 3)
                {
                    byte3 = Convert.ToByte(stream.ReadByte());
                }
                if (stream.Length >= 4)
                {
                    byte4 = Convert.ToByte(stream.ReadByte());
                }
                //根据文件流的前4个字节判断Encoding
                //Unicode {0xFF, 0xFE};
                //BE-Unicode {0xFE, 0xFF};
                //UTF8 = {0xEF, 0xBB, 0xBF};
                if (byte1 == 0xFE && byte2 == 0xFF)//UnicodeBe
                {
                    targetEncoding = Encoding.BigEndianUnicode;
                }
                if (byte1 == 0xFF && byte2 == 0xFE && byte3 != 0xFF)//Unicode
                {
                    targetEncoding = Encoding.Unicode;
                }
                if (byte1 == 0xEF && byte2 == 0xBB && byte3 == 0xBF)//UTF8
                {
                    targetEncoding = Encoding.UTF8;
                }
                //恢复Seek位置      
                stream.Seek(origPos, SeekOrigin.Begin);
            }
            return targetEncoding;
        }

    }
    public struct DetailDataStruct
    {
        /// <summary>
        /// 前一级别类型
        /// </summary>
        public string PriviorType { get; set; }
        /// <summary>
        ///详细类型
        /// </summary>
        public string DetailType { get; set; }
        /// <summary>
        /// 属性名称
        /// </summary>
        public string AttributeName { get; set; }
        /// <summary>
        /// 前一级别的ID字段名称
        /// </summary>
        public string PriviorFieldName { get; set; }
        /// <summary>
        /// 当前级别的ID字段名称
        /// </summary>
        public string CurrentIDFieldName { get; set; }
        /// <summary>
        /// 当前一级别ID值
        /// </summary>
        public string TmpCurrentID { get; set; }
        /// <summary>
        /// 前一级别ID值
        /// </summary>
        public string TmpCurrentPriviorID { get; set; }
        /// <summary>
        /// 详细数据表
        /// </summary>
        public DataTable DetailTable { get; set; }
    }
}
