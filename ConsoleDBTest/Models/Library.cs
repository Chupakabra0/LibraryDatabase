using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsoleDBTest.Models {
    public class Library {
        [Key]
        public int Id { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime?  TakeDate   { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? ReturnDate { get; set; }
        public bool      IsActive   { get; set; }

        public virtual ICollection<ClientCard> ClientCards { get; set; }
        public virtual ICollection<Book>       Books       { get; set; }
        public virtual ICollection<Worker>     Workers     { get; set; }
    }
}