using System;
using XYFramework.Common.Encrypt;
using XYFramework.HttpRequest;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IEncryptBase encryptBase = EncryptFactory.GetInstance(EncryptType.Auth);
            //var str = "12123123123";
            var key = "DXFLYB!!!";
            //var output = encryptBase.Encrypt(str, key);
            //Console.WriteLine(output);
            ////output = encryptBase.Decrypt(output, key);
            ////Console.WriteLine(output);

            //var url = @"http://baidu.com";
            //var task = HttpProvider.Get(url);
            string str = "12345654321";
            string result = encryptBase.Encrypt(str, key);
            Console.WriteLine(result);
            Console.WriteLine("------------------");
            result = encryptBase.Decrypt(result, key);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
