using System.Linq;
using ConsoleDBTest.Models;

namespace ConsoleDBTest.ViewModels {
    public class GroupViewModel {
        public GroupViewModel(Group group) {
            this.Id       = group.Id;
            this.Name = GroupViewModel.GetGroupName
                (group.FacultyAndSpecialtyAndCathedra, group.Degree, group.Year, group.Serial);
            //this.Year     = group.Year;
            //this.Serial   = group.Serial;
            this.IsActive = group.IsActive;
        }

        private static string GetGroupName(FacultyAndSpecialtyAndCathedra facultyAndSpecialtyAndCathedra, Degree degree, int year, int serial) {
            return facultyAndSpecialtyAndCathedra is null || degree is null ? 
                "null" : $"{facultyAndSpecialtyAndCathedra.FacultyAndSpecialty.Faculty.ShortLetter}{facultyAndSpecialtyAndCathedra.FacultyAndSpecialty.Specialty.ShortLetter}-{year.ToString()[..^1].Last()}{year.ToString().Last()}-{serial}{degree.ShortLetter}";
        }

        public int    Id     { get; set; }
        //public int    Year   { get; set; }
        //public int    Serial { get; set; }
        public string Name   { get; set; }
        //public string FacultyAndSpecialtyAndCathedra { get; set; }
        //public string Degree                         { get; set; }
        public bool   IsActive                       { get; set; }
    }
}
