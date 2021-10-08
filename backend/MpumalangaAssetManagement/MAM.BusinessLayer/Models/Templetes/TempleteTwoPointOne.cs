using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.BusinessLayer.Models.Templetes
{
    public class TempleteTwoPointOne
    {
        public int Id { get; set; }
        public List<Property> Properties { get; set; }

        public TempleteTwoPointOne ConvertToTempleteTwoPointOne(List<DataAccess.Tables.Property> properties)
        {
            TempleteTwoPointOne templeteTwoPointOne = new TempleteTwoPointOne();
            Property property = new Property();
            templeteTwoPointOne.Properties = property.ConvertToProperties(properties);
            return templeteTwoPointOne;
        }
    }
}
