using MAM.DataAccess.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Interfaces
{
    public interface PropertyDescriptionInterface
    {
        int AddPropertyDescription(PropertyDescription propertyDescription);
        void UpdatePropertyDescription(PropertyDescription propertyDescription);
        List<PropertyDescription> GetPropertyDescriptions();
        PropertyDescription GetPropertyDescriptionById(int id);
    }
}
