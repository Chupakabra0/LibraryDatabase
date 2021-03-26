using ConsoleDBTest.Models;

namespace ConsoleDBTest.ViewModels {
    public class TeacherViewModel {
        public TeacherViewModel(Teacher teacher) {
            this.Id         = teacher.Id;
            this.Name       = teacher.Name;
            this.Surname    = teacher.Surname;
            this.Patronymic = teacher.Patronymic;
            this.City       = teacher.City.Name;
            this.Cathedra   = teacher.Cathedra.ShortName;
            this.IsActive   = teacher.IsActive;
        }

        public int    Id         { get; set; }
        public string Name       { get; set; }
        public string Surname    { get; set; }
        public string Patronymic { get; set; }
        public string City       { get; set; }
        public string Cathedra   { get; set; }
        public bool   IsActive   { get; set; }
    }
}