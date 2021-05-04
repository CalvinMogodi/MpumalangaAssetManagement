using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAM.BusinessLayer.Models
{
    public class Utilisation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Post { get; set; }
        public string AllocatedSpace { get; set; }
        public string RequiredSpace { get; set; }
        public string PercentageUtilised { get; set; }

        public DataAccess.Tables.Utilisation ConvertToUtilisationTable(Utilisation utilisation)
        {
            return new DataAccess.Tables.Utilisation()
            {
                Id = utilisation.Id,
                UserId = 1033,
                Post = utilisation.Post,
                RequiredSpace = utilisation.RequiredSpace,
                PercentageUtilised = utilisation.PercentageUtilised
            };
        }

        public List<Utilisation> ConvertToUtilisations(List<DataAccess.Tables.Utilisation> utilisations)
        {
            return utilisations.Select(u => new Utilisation()
            {
                Id = u.Id,
                UserId = u.UserId,
                Post = u.Post,
                RequiredSpace = u.RequiredSpace,
                PercentageUtilised = u.PercentageUtilised
            }).ToList();
        }
    }
}
