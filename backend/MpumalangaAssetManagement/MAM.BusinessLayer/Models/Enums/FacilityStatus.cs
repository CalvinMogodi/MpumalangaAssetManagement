using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MAM.BusinessLayer.Models.Enums
{
    public enum FacilityStatus
    {
        [Description("New")]
        New = 1,
        [Description("Awaiting Verification")]
        AwaitingVerification = 2,
        [Description("Awaiting Authorization")]
        AwaitingAuthorization = 3,
        [Description("Authorised")]
        Authorised = 4,
        [Description("Saved")]
        Saved = 5,
        [Description("Completed")]
        Completed = 6
    }
}
