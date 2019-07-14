using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace XYFramework.Common.Encrypt
{
    public class DESEncrypt : IEncryptBase
    {
        /// <summary>
        /// Encrypt with DES
        /// </summary>
        /// <param name="pToEncrypt">content to encrypt</param>
        /// <param name="sKey">encrypt key</param>
        /// <returns>base64 string</returns>
        public string Encrypt(string pToEncrypt, string sKey)
        {
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                byte[] inputByteArray = Encoding.UTF8.GetBytes(pToEncrypt);
                var bytes = MD5.Create().ComputeHash(ASCIIEncoding.ASCII.GetBytes(sKey)).Take(8).ToArray();
                des.Key = bytes;
                des.IV = bytes;
                MemoryStream ms = new MemoryStream();
                using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    cs.Close();
                }
                string str = Convert.ToBase64String(ms.ToArray());
                ms.Close();
                return str;
            }
        }

        /// <summary>
        /// Decrypt with DES
        /// </summary>
        /// <param name="pToDecrypt">content to decrypt</param>
        /// <param name="sKey">decrypt key</param>
        /// <returns>raw content</returns>
        public string Decrypt(string pToDecrypt, string sKey)
        {
            byte[] inputByteArray = Convert.FromBase64String(pToDecrypt);
            using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
            {
                var bytes = MD5.Create().ComputeHash(ASCIIEncoding.ASCII.GetBytes(sKey)).Take(8).ToArray();
                des.Key = bytes;
                des.IV = bytes;
                MemoryStream ms = new MemoryStream();
                using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                    cs.Close();
                }
                string str = Encoding.UTF8.GetString(ms.ToArray());
                ms.Close();
                return str;
            }
        }
    }
}
