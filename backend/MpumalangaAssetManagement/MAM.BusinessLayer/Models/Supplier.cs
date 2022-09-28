using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.BusinessLayer.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CumpanyNumber { get; set; }
        public string ContactName { get; set; }
        public string ContactNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
