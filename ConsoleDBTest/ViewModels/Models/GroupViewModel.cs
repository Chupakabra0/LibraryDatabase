﻿using System.Linq;
using ConsoleDBTest.DB;
using ConsoleDBTest.Models;

namespace ConsoleDBTest.ViewModels {
    public class GroupViewModel {
        public GroupViewModel(Group group, UniversityLibrary db = null) {
            this.Id        = group.Id;
            this.Name      = GetGroupName(group.FacultyAndSpecialtyAndCathedraId, group.DegreeId, group.Year, group.Serial, db);
            this.Faculty   = GetFacultyName(GetFacultyAndSpecialty(GetFacultyAndSpecialtyAndCathedra(group.FacultyAndSpecialtyAndCathedraId, db).FacultyAndSpecialtyId, db).FacultyId, db);
            this.Specialty = GetSpecialtyName(GetFacultyAndSpecialty(GetFacultyAndSpecialtyAndCathedra(group.FacultyAndSpecialtyAndCathedraId, db).FacultyAndSpecialtyId, db).SpecialtyId, db);
            this.Cathedra  = GetCathedraName(GetFacultyAndSpecialtyAndCathedra(group.FacultyAndSpecialtyAndCathedraId, db).CathedraId, db);
            this.IsActive  = group.IsActive;
        }

        private static FacultyAndSpecialtyAndCathedra GetFacultyAndSpecialtyAndCathedra(int facultyAndSpecialtyAndCathedraId, UniversityLibrary db) =>
             db?.Database?.SqlQuery<FacultyAndSpecialtyAndCathedra>
                   ($"select * from {nameof(db.FacultyAndSpecialtyAndCathedras)} where Id={facultyAndSpecialtyAndCathedraId}")
               ?.ToList()
               ?.First();

        private static FacultyAndSpecialty GetFacultyAndSpecialty(int facultyAndSpecialtyId, UniversityLibrary db) =>
            db?.Database
              ?.SqlQuery<FacultyAndSpecialty>($"select * from {nameof(db.FacultyAndSpecialties)} where Id={facultyAndSpecialtyId}")
              ?.ToList()
              ?.First();

        private static Faculty GetFaculty(int facultyId, UniversityLibrary db) =>
            db.Database
              ?.SqlQuery<Faculty>($"select * from {nameof(db.Faculties)} where Id={facultyId}")
              ?.ToList()
              ?.First();

        private static Specialty GetSpecialty(int specialtyId, UniversityLibrary db) =>
            db.Database
              ?.SqlQuery<Specialty>($"select * from {nameof(db.Specialties)} where Id={specialtyId}")
              ?.ToList()
              ?.First();

        private static Degree GetDegree(int degreeId, UniversityLibrary db) =>
            db.Database
              ?.SqlQuery<Degree>($"select * from {nameof(db.Degrees)} where Id={degreeId}")
              ?.ToList()
              ?.First();

        private static string GetGroupName(int facultyAndSpecialtyAndCathedraId, int degreeId, int year, int serial, UniversityLibrary db) {
            var facultyAndSpecialtyAndCathedra =
                GroupViewModel.GetFacultyAndSpecialtyAndCathedra(facultyAndSpecialtyAndCathedraId, db);

            if (facultyAndSpecialtyAndCathedra is null) {
                return "null";
            }

            var facultyAndSpecialty = GroupViewModel.GetFacultyAndSpecialty(facultyAndSpecialtyAndCathedra.FacultyAndSpecialtyId, db);

            if (facultyAndSpecialty is null) {
                return "null";
            }

            var faculty = GroupViewModel.GetFaculty(facultyAndSpecialty.FacultyId, db);

            if (faculty is null) {
                return "null";
            }

            var specialty = GroupViewModel.GetSpecialty(facultyAndSpecialty.SpecialtyId, db);

            if (specialty is null) {
                return "null";
            }

            var degree = GroupViewModel.GetDegree(degreeId, db);

            return degree is null ? "null" : $"{faculty.ShortLetter}{specialty.ShortLetter}-{year.ToString()[..^1].Last()}{year.ToString().Last()}-{serial}{degree.ShortLetter}";
        }

        private static string GetFacultyName(int facultyId, UniversityLibrary db) =>
            db?.Database?.SqlQuery<Faculty>($@"select * from {nameof(db.Faculties)} where id = {facultyId}")
              ?.ToList()?.First()?.ShortName ?? "null";

        private static string GetSpecialtyName(int specialtyId, UniversityLibrary db) =>
            db?.Database?.SqlQuery<Specialty>($@"select * from {nameof(db.Specialties)} where id = {specialtyId}")
              ?.ToList()?.First()?.Name ?? "null";

        private static string GetCathedraName(int cathedraId, UniversityLibrary db) =>
            db?.Database?.SqlQuery<Cathedra>($@"select * from {nameof(db.Cathedras)} where id = {cathedraId}")
              ?.ToList()?.First()?.ShortName ?? "null";

        public int    Id        { get; set; }
        public string Name      { get; set; }
        public string Faculty { get; set; }
        public string Specialty { get; set; }
        public string Cathedra { get; set; }
        public bool   IsActive  { get; set; }
    }
}
