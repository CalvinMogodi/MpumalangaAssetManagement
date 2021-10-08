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

        public TempleteOne ConvertToTempleteOne(List<DataAccess.Tables.Programme> programmes, DataAccess.Tables.OptimalSupportingAccommodation osa)
        {
            TempleteOne templeteOne = new TempleteOne();
            Programme programme = new Programme();
            OptimalSupportingAccommodation optimalSupportingAccommodation = new OptimalSupportingAccommodation();
            templeteOne.Programmes = programme.ConvertToProgrammes(programmes);
            templeteOne.OptimalSupportingAccommodation = optimalSupportingAccommodation.ConvertToOptimalSupportingAccommodation(osa);
            return templeteOne;
        }
    }
}
