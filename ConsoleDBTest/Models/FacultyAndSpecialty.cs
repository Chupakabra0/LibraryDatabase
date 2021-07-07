﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ConsoleDBTest.DB;
using ConsoleDBTest.ViewModels;

namespace ConsoleDBTest.Models {
    public class FacultyAndSpecialty {
        [Key]
        public int Id { get; set; }

        public int  FacultyId   { get; set; }
        public int  SpecialtyId { get; set; }
        public bool IsActive    { get; set; }

        public virtual ICollection<FacultyAndSpecialtyAndCathedra> FacultiesAndSpecialtiesAndCathedras { get; set; }

        public virtual Faculty   Faculty   { get; set; }
        public virtual Specialty Specialty { get; set; }

        public FacultyAndSpecialtyViewModel ToViewModel(UniversityLibrary db = null) => new(this, db);
    }
}
