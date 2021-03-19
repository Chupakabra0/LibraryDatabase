using System;
using System.ComponentModel.DataAnnotations;

namespace ConsoleDBTest.Models {
    public class ClientCard {
        [Key]
        public int Id { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? DateGiven { get; set; }
        public bool      IsActive  { get; set; }

        public int? StudentId;
        public int? TeacherId;
        public int  LibraryId;
    }
}
