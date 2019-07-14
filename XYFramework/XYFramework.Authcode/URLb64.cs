using System;
using System.Collections.Generic;
using System.Text;

namespace XYFramework.Authcode
{
    public class URLb64
    {
        public static string Url_b64encode(string str,string key)
        {
            str = Authcode.DiscuzAuthcodeEncode(str, key);
            str = Convert.ToBase64String(Encoding.Default.GetBytes(str));
            str=str.Replace("+", "-");
            str=str.Replace("/", "_");
            str=str.Replace("=", "");
            return str;
        }

        public static string Url_b64decode(string str,string key)
        {
            str=str.Replace("-", "+");
            str=str.Replace("_", "/");
            int mod4 = str.Length % 4;
            if(mod4>0)
            {
                str += "====".Substring(mod4);
            }
            str = Encoding.Default.GetString(Convert.FromBase64String(str));
            str = Authcode.DiscuzAuthcodeDecode(str, key);
            return str;
        }
    }
}
