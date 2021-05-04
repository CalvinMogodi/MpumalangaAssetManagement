using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Tables
{
    public class Utilisation
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Post { get; set; }
        public string RequiredSpace { get; set; }
        public string PercentageUtilised { get; set; }
    }
}
