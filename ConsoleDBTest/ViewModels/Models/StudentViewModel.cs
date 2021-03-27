using System.Linq;
using ConsoleDBTest.DB;
using ConsoleDBTest.Models;

namespace ConsoleDBTest.ViewModels {
    public class StudentViewModel {
        public StudentViewModel(Student student, UniversityLibrary db = null) {
            this.Id         = student.Id;
            this.Name       = student.Name;
            this.Surname    = student.Surname;
            this.Patronymic = student.Patronymic;
            this.City       = StudentViewModel.GetCityName(student.CityId, db);
            this.Group      = StudentViewModel.GetGroupName(student.GroupId, db);
            this.IsActive   = student.IsActive;
        }

        private static string GetCityName(int cityId, UniversityLibrary db) =>
            db?.Database
              ?.SqlQuery<City>($"select * from {nameof(db.Cities)} where Id={cityId}")
              ?.ToList()
              ?.First()
              .Name ?? "null";

        private static string GetGroupName(int groupId, UniversityLibrary db) {
            if (db is null) {
                return "null";
            }

            var group = db?.Database?.SqlQuery<Group>($"select * from {nameof(db.Groups)} where Id={groupId}")
                          ?.ToList()
                          ?.First();

            return group is null ? "null" : new GroupViewModel(group, db).Name;
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
