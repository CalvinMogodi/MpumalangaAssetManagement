using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MAM.BusinessLayer.Models.Enums
{
    public enum ResultType
    {
        [Description("Percentage")]
        Percentage = 1,
        [Description("Money")]
        Money = 2,
    }
}
