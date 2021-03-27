using System.Linq;
using ConsoleDBTest.DB;
using ConsoleDBTest.Models;

namespace ConsoleDBTest.ViewModels {
    public class GroupViewModel {
        public GroupViewModel(Group group, UniversityLibrary db = null) {
            this.Id       = group.Id;
            this.Name = GroupViewModel.GetGroupName
                (group.FacultyAndSpecialtyAndCathedraId, group.DegreeId, group.Year, group.Serial, db);
            this.IsActive = group.IsActive;
        }

        private static string GetGroupName(int facultyAndSpecialtyAndCathedraId, int degreeId, int year, int serial, UniversityLibrary db) {
            var facultyAndSpecialtyAndCathedra = db
                                                 ?.Database
                                                 ?.SqlQuery<FacultyAndSpecialtyAndCathedra
                                                 >($"select * from {nameof(db.FacultyAndSpecialtyAndCathedras)} where Id={facultyAndSpecialtyAndCathedraId}")
                                                 ?.ToList()
                                                 ?.First();

            if (facultyAndSpecialtyAndCathedra is null) {
                return "null";
            }

            var facultyAndSpecialty = db.Database
                                        ?.SqlQuery<FacultyAndSpecialty
                                        >($"select * from {nameof(db.FacultyAndSpecialties)} where Id={facultyAndSpecialtyAndCathedra.FacultyAndSpecialtyId}")
                                        ?.ToList()
                                        ?.First();

            if (facultyAndSpecialty is null) {
                return "null";
            }

            var faculty = db.Database
                            ?.SqlQuery<Faculty
                            >($"select * from {nameof(db.Faculties)} where Id={facultyAndSpecialty.FacultyId}")
                            ?.ToList()
                            ?.First();

            if (faculty is null) {
                return "null";
            }

            var specialty = db.Database
                              ?.SqlQuery<Specialty
                              >($"select * from {nameof(db.Specialties)} where Id={facultyAndSpecialty.SpecialtyId}")
                              ?.ToList()
                              ?.First();

            if (specialty is null) {
                return "null";
            }

            var degree = db.Database
                           ?.SqlQuery<Degree>($"select * from {nameof(db.Degrees)} where Id={degreeId}")
                           ?.ToList()
                           ?.First();

            return degree is null ? "null" : $"{faculty.ShortLetter}{specialty.ShortLetter}-{year.ToString()[..^1].Last()}{year.ToString().Last()}-{serial}{degree.ShortLetter}";
        }

        public int    Id       { get; set; }
        public string Name     { get; set; }
        public bool   IsActive { get; set; }
    }
}
