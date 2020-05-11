using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ToolLIbrary.Model
{
   public class ConnectExpression
    {
        const string key = "Laobiya!";
        const string ivkey = "shengqqud";
        public string UserName { get; set; }
        string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
            }
        }
        public string DataBaseName { get; set; }
        public string DataSource { get; set; }
        //public string getDesPassword()
        //{
        //    return Decrypt(_password);
        //}
        
        public static string Encrypt(string sourceString)
        {
            try
            {
                byte[] btKey = Encoding.UTF8.GetBytes(key);

                byte[] btIV = Encoding.UTF8.GetBytes(ivkey);

                DESCryptoServiceProvider des = new DESCryptoServiceProvider();

                using (MemoryStream ms = new MemoryStream())
                {
                    byte[] inData = Encoding.UTF8.GetBytes(sourceString);
                    try
                    {
                        using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(btKey, btIV), CryptoStreamMode.Write))
                        {
                            cs.Write(inData, 0, inData.Length);

                            cs.FlushFinalBlock();
                        }

                        return Convert.ToBase64String(ms.ToArray());
                    }
                    catch(Exception ex)
                    {
                        string error = ex.Message;
                        return sourceString;
                    }
                }
            }
            catch { }

            return sourceString;
        }
        public static string Decrypt(string encryptedString )
        {
            byte[] btKey = Encoding.UTF8.GetBytes(key);

            byte[] btIV = Encoding.UTF8.GetBytes(ivkey);

            DESCryptoServiceProvider des = new DESCryptoServiceProvider();

            using (MemoryStream ms = new MemoryStream())
            {
                byte[] inData = Convert.FromBase64String(encryptedString);
                try
                {
                    using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(btKey, btIV), CryptoStreamMode.Write))
                    {
                        cs.Write(inData, 0, inData.Length);

                        cs.FlushFinalBlock();
                    }

                    return Encoding.UTF8.GetString(ms.ToArray());
                }
                catch
                {
                    return encryptedString;
                }
            }
        }
    }
}
