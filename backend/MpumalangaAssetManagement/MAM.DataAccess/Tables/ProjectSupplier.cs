using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Tables
{
    public class ProjectSupplier
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int SupplierId { get; set; }
    }
}
