using System;
using System.Collections.Generic;
using System.Text;

namespace MAM.DataAccess.Tables
{
    public class Camp
    {
		public int Id { get; set; }
		public string Status { get; set; }
		public string FileReference { get; set; }
		public int? OptimalSupportingAccommodationId { get; set; }
		public int UserId { get; set; }
		public DateTime CreatedDate { get; set; }
		public int ModifiedBy { get; set; }
		public DateTime ModifiedDate { get; set; }
		public string Department { get; set; }
		public User User { get; set; }
	}
}
