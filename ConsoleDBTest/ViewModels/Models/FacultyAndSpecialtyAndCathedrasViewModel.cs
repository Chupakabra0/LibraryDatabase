using ConsoleDBTest.Models;

namespace ConsoleDBTest.ViewModels {
    public class FacultyAndSpecialtyAndCathedraViewModel {
        public FacultyAndSpecialtyAndCathedraViewModel(FacultyAndSpecialtyAndCathedra facultyAndSpecialtyAndCathedra) {
            this.Id                  = facultyAndSpecialtyAndCathedra.Id;
            this.FacultyAndSpecialty = FacultyAndSpecialtyAndCathedraViewModel.GetFacultyAndSpecialtyName
                                        (facultyAndSpecialtyAndCathedra.FacultyAndSpecialty);
            this.Cathedra            = facultyAndSpecialtyAndCathedra.Cathedra.ShortName;
            this.IsActive            = facultyAndSpecialtyAndCathedra.IsActive;
        }

        private static string GetFacultyAndSpecialtyName(FacultyAndSpecialty facultyAndSpecialty) =>
            facultyAndSpecialty is null ? "null" : $"{facultyAndSpecialty.Faculty}/{facultyAndSpecialty.Specialty}";

        public int    Id                  { get; set; }
        public string FacultyAndSpecialty { get; set; }
        public string Cathedra            { get; set; }
        public bool   IsActive            { get; set; }
    }
}
