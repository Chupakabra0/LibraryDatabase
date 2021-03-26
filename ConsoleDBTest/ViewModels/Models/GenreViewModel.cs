﻿using ConsoleDBTest.Models;

namespace ConsoleDBTest.ViewModels {
    public class GenreViewModel {
        public GenreViewModel(Genre genre) {
            this.Id       = genre.Id;
            this.Name     = genre.Name;
            this.IsActive = genre.IsActive;
        }

        public int    Id       { get; set; }
        public string Name     { get; set; }
        public bool   IsActive { get; set; }
    }
}
