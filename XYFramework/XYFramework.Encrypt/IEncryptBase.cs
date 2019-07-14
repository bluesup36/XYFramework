using System;
using System.Collections.Generic;
using System.Text;

namespace XYFramework.Common.Encrypt
{
    public interface IEncryptBase
    {
        string Encrypt(string pToEncrypt, string sKey);

        string Decrypt(string pToDecrypt, string sKey);
    }
}
