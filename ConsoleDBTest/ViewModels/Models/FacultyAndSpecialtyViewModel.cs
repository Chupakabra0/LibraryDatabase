using ConsoleDBTest.Models;

namespace ConsoleDBTest.ViewModels {
    public class FacultyAndSpecialtyViewModel {
        public FacultyAndSpecialtyViewModel(FacultyAndSpecialty facultyAndSpecialty) {
            this.Id        = facultyAndSpecialty.Id;
            this.Faculty   = facultyAndSpecialty.Faculty.ShortName;
            this.Specialty = facultyAndSpecialty.Specialty.Name;
            this.IsActive  = facultyAndSpecialty.IsActive;
        }

        public int    Id        { get; set; }
        public string Faculty   { get; set; }
        public string Specialty { get; set; }
        public bool   IsActive  { get; set; }
    }
}
