using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.BusinessLayer.Models.Templetes
{
    public class TempleteTwoPointTwo
    {
        public int Id { get; set; }
        public List<Property> Properties { get; set; }

        public TempleteTwoPointTwo ConvertToTempleteTwoPointTwo(List<DataAccess.Tables.Property> properties)
        {
            TempleteTwoPointTwo templeteTwoPointTwo = new TempleteTwoPointTwo();
            Property property = new Property();
            templeteTwoPointTwo.Properties = property.ConvertToProperties(properties);
            return templeteTwoPointTwo;
        }
    }
}
