using System;
using XYFramework.Encrypt;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = "12123123123";
            var key = "DXFLYB!!!";
            var output = DESEncrypt.EncryptDES(str, key);
            Console.WriteLine(output);
            output = DESEncrypt.DecryptDES(output, key);
            Console.WriteLine(output);
            Console.ReadKey();
        }
    }
}
