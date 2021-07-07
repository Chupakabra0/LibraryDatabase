using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ConsoleDBTest.ViewModels;

namespace ConsoleDBTest.Models {
    public class Cathedra {
        [Key]
        public int Id { get; set; }

        public string Name      { get; set; }
        public string ShortName { get; set; }
        public bool   IsActive  { get; set; }

        public virtual ICollection<FacultyAndSpecialtyAndCathedra> FacultiesAndSpecialtiesAndCathedras { get; set; }
        public virtual ICollection<Teacher>                        Teachers                            { get; set; }

        public CathedraViewModel ToViewModel() => new(this);
    }
}
