using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.BusinessLayer.Models.Templetes
{
    public class TempleteOne
    {
        public int Id { get; set; }
        public OptimalSupportingAccommodation OptimalSupportingAccommodation { get; set; }
        public List<Programme> Programmes { get; set; }
    }
}
