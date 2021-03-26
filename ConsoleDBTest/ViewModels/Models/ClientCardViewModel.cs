using System;
using System.Linq;
using ConsoleDBTest.Models;

namespace ConsoleDBTest.ViewModels {
    public class ClientCardViewModel {
        public ClientCardViewModel(ClientCard clientCard) {
            this.Id        = clientCard.Id;
            this.DateGiven = ClientCardViewModel.GetDate(clientCard.DateGiven);
            this.Student   = ClientCardViewModel.GetStudentName(clientCard.Student);
            this.Teacher   = ClientCardViewModel.GetTeacherName(clientCard.Teacher);
            this.IsActive  = clientCard.IsActive;
        }

        private static string GetDate(DateTime? dateTime) =>
            dateTime?.ToShortDateString() ?? "null";

        private static string GetStudentName(Student student) =>
            student is null ? "null" : $"{student.Name.First()}. {student.Patronymic.First()}. {student.Surname}";
        
        private static string GetTeacherName(Teacher teacher) =>
            teacher is null ? "null" : $"{teacher.Name.First()}. {teacher.Patronymic.First()}. {teacher.Surname}";
        
        public int    Id        { get; set; }
        public string DateGiven { get; set; }
        public string Student   { get; set; }
        public string Teacher   { get; set; }
        public bool   IsActive  { get; set; }
    }
}
