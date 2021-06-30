using MAM.DataAccess.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Interfaces
{
    public interface IPropertyRepository
    {
        int AddProperty(Property property);
        void UpdateProperty(Property property);
        void DeleteProperty(Property property);
        List<Property> GetProperties(int uampId);
    }
}
