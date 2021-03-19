using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsoleDBTest.Models {
    public class FacultyAndSpecialtyAndCathedra {
        [Key]
        public int Id { get; set; }

        public int FacultyAndSpecialtyId { get; set; }
        public int CathedraId            { get; set; }

        public virtual ICollection<Group> Groups { get; set; }
    }
}