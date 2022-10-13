using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Tables
{
    public class FaultNote
    {
        public int Id { get; set; }
        public int FaultId { get; set; }
        public string Comment { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedById { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
