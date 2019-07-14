using System;
using System.Collections.Generic;
using System.Text;

namespace XYFramework.Common.Encrypt
{
    public enum EncryptType
    {
        Auth,
        DES,
        MD5
    }
    public class EncryptFactory
    {
        private EncryptFactory() { }

        private static IEncryptBase encryptBase = null;
        public static IEncryptBase GetInstance(EncryptType type)
        {
            switch (type)
            {
                case EncryptType.Auth: encryptBase = new AuthEncrypt(); break;
                case EncryptType.DES: encryptBase = new DESEncrypt(); break;
                case EncryptType.MD5: encryptBase = new MD5Encrypt(); break;
                default:return null;
            }
            return encryptBase;
        }
    }
}
