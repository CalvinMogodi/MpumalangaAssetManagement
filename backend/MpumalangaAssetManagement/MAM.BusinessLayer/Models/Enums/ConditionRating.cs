using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MAM.BusinessLayer.Models.Enums
{
    public enum ConditionRating
    {
        [Description("C1 (Excellent)")]
        C1 = 1,
        [Description("C2 (Good)")]
        C2 = 2,
        [Description("C3 (Fair)")]
        C3 = 3,
        [Description("C4 (Poor)")]
        C4 = 4,
        [Description("C5 (Very Poor)")]
        C5 = 5
    }
}
