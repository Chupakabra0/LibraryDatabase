﻿using System;
using System.ComponentModel.DataAnnotations;
using ConsoleDBTest.DB;
using ConsoleDBTest.ViewModels;

namespace ConsoleDBTest.Models {
    public class ClientCard {
        [Key]
        public int Id { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? DateGiven { get; set; }
        public int?  StudentId     { get; set; }
        public int?  TeacherId     { get; set; }
        public bool  IsActive      { get; set; }

        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }

        public ClientCardViewModel ToViewModel(UniversityLibrary db = null) => new(this, db);
    }
}
