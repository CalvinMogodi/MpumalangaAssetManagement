using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MAM.BusinessLayer.Models
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

        public List<FaultNote> ConvertToFaults(List<DataAccess.Tables.FaultNote> notes)
        {
            if (notes == null) {
                return new List<FaultNote>();
            }
            return notes.Select(note => new FaultNote()
            {
                Id = note.Id,
                FaultId = note.FaultId,
                Comment = note.Comment,
                CreatedDate = note.CreatedDate,
                ModifiedDate = note.ModifiedDate,
                CreatedById = note.CreatedById,
                ModifiedById = note.ModifiedById,
            }).ToList();
        }

        public FaultNote ConvertToFault(DataAccess.Tables.FaultNote note)
        {
            return new FaultNote()
            {
                Id = note.Id,
                FaultId = note.FaultId,
                Comment = note.Comment,
                CreatedDate = note.CreatedDate,
                ModifiedDate = note.ModifiedDate,
                CreatedById = note.CreatedById,
                ModifiedById = note.ModifiedById,
            };
        }

        public DataAccess.Tables.FaultNote ConvertToFaultNoteTable(FaultNote note)
        {
            return new DataAccess.Tables.FaultNote()
            {
                Id = note.Id,
                FaultId = note.FaultId,
                Comment = note.Comment,
                CreatedDate = note.CreatedDate,
                ModifiedDate = note.ModifiedDate,   
                CreatedById = note.CreatedById,
                ModifiedById = note.ModifiedById,
            };
        }
    }
}

