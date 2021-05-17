using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MAM.DataAccess.Tables
{
    public class Facility
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string FileReference { get; set; }
        public string Type { get; set; }
        public string VestedType { get; set; }       
        public string Survey { get; set; }
        public string ClientCode { get; set; }
        [ForeignKey("Id")]
        public int CapturerId { get; set; }
        public string Status { get; set; }
        [ForeignKey("LandId")]
        public int? LandId { get; set; }
        [ForeignKey("FinanceId")]
        public int? FinanceId { get; set; }
        [ForeignKey("Id")]
        public DateTime CreatedDate { get; set; }
        [ForeignKey("Id")]
        public int? ApproverId { get; set; }       
        public DateTime? ApprovedDate { get; set; }
        [ForeignKey("Id")]
        public int? VerifierId { get; set; }        
        public DateTime? SingedOffDate { get; set; }
        [ForeignKey("Id")]
        public int? ModifierId { get; set; }
        public DateTime? ModifiedDate { get; set; }      
        public virtual Land Land { get; set; }
        public virtual Finance Finance { get; set; }
        public virtual List<Improvement> Improvements { get; set; }       
    }
}
