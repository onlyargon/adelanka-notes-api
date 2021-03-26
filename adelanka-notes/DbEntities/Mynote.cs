using System;
using System.Collections.Generic;

#nullable disable

namespace adelanka_notes.DbEntities
{
    public partial class Mynote
    {
        public int NoteId { get; set; }
        public int? UserId { get; set; }
        public string NoteTitle { get; set; }
        public string NoteContent { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
