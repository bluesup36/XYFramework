using System;
using System.Collections.Generic;
using System.Text;

namespace XYFramework.Validator
{
    interface IValidateBase
    {
        string Name { get; set; }
        string Rule { get; set; }
        string Message { get; set; }
        string Check();
    }
}
