using MAM.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.BusinessLayer.Interfaces
{
    public interface IHiringRegisterRepository
    {
        List<HiredProperty> GetHiredProperties();
        bool UpdateHiredProperty(HiredProperty hiredProperty);
        bool DeleteHiredProperty(HiredProperty hiredProperty);
        int AddHiredProperty(HiredProperty hiredProperty);
    }
}
