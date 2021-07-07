﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ConsoleDBTest.ViewModels;

namespace ConsoleDBTest.Models {
    public class Degree {
        [Key]
        public int Id { get; set; }

        public string Name        { get; set; }
        public string ShortLetter { get; set; }
        public bool   IsActive    { get; set; }

        public virtual ICollection<Group> Groups { get; set; }

        public DegreeViewModel ToViewModel() => new(this);
    }
}
