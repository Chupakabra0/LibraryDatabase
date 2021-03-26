using ConsoleDBTest.Models;

namespace ConsoleDBTest.ViewModels {
    public class StudentViewModel {
        public StudentViewModel(Student student) {
            this.Id         = student.Id;
            this.Name       = student.Name;
            this.Surname    = student.Surname;
            this.Patronymic = student.Patronymic;
            this.City       = student.City.Name;
            this.Group      = StudentViewModel.GetGroupName(student.Group);
            this.IsActive   = student.IsActive;
        }

        private static string GetGroupName(Group group) {
            return group is null ? "null" : new GroupViewModel(group).Name;
        }

        public int    Id         { get; set; }
        public string Name       { get; set; }
        public string Surname    { get; set; }
        public string Patronymic { get; set; }
        public string City       { get; set; }
        public string Group      { get; set; }
        public bool   IsActive   { get; set; }
    }
}
