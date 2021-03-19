﻿using System.Data.Entity;
using ConsoleDBTest.Models;

namespace ConsoleDBTest.DB {
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : this(nameof(DatabaseContext)) {

        }

        public DatabaseContext(string nameOrConnectionString)
            : base(nameOrConnectionString) {

        }

        public DbSet<Author>                         Authors                             { get; set; }
        public DbSet<Book>                           Books                               { get; set; }
        public DbSet<Cathedra>                       Cathedras                           { get; set; }
        public DbSet<Country>                        Countries                           { get; set; }
        public DbSet<Degree>                         Degrees                             { get; set; }
        public DbSet<Faculty>                        Faculties                           { get; set; }
        public DbSet<FacultyAndSpecialty>            FacultiesAndSpecialties             { get; set; }
        public DbSet<FacultyAndSpecialtyAndCathedra> FacultiesAndSpecialtiesAndCathedras { get; set; }
        public DbSet<Genre>                          Genres                              { get; set; }
        public DbSet<Group>                          Groups                              { get; set; }
        public DbSet<Library>                        Library                             { get; set; }
        public DbSet<Publisher>                      Publishers                          { get; set; }
        public DbSet<Specialty>                      Specialties                         { get; set; }
        public DbSet<Student>                        Students                            { get; set; }
        public DbSet<Teacher>                        Teachers                            { get; set; }
        public DbSet<Worker>                         Workers                             { get; set; }
    }
}
