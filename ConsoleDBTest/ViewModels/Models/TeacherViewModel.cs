using System.Linq;
using ConsoleDBTest.DB;
using ConsoleDBTest.Models;

namespace ConsoleDBTest.ViewModels {
    public class TeacherViewModel {
        public TeacherViewModel(Teacher teacher, UniversityLibrary db = null) {
            this.Id         = teacher.Id;
            this.Name       = teacher.Name;
            this.Surname    = teacher.Surname;
            this.Patronymic = teacher.Patronymic;
            this.City       = TeacherViewModel.GetCityName(teacher.CityId, db);
            this.Cathedra   = TeacherViewModel.GetCathedraName(teacher.CathedraId, db);
            this.IsActive   = teacher.IsActive;
        }

        private static string GetCityName(int cityId, UniversityLibrary db) =>
            db?.Database
              ?.SqlQuery<City>($"select * from {nameof(db.Cities)} where Id={cityId}")
              ?.ToList()
              ?.First()
              .Name ?? "null";

        private static string GetCathedraName(int cathedraId, UniversityLibrary db) =>
            db?.Database?.SqlQuery<Cathedra>($"select * from {nameof(db.Cathedras)} where Id={cathedraId}")
              ?.ToList()
              ?.First()
              ?.ShortName ?? "null";

        public int    Id         { get; set; }
        public string Name       { get; set; }
        public string Surname    { get; set; }
        public string Patronymic { get; set; }
        public string City       { get; set; }
        public string Cathedra   { get; set; }
        public bool   IsActive   { get; set; }
    }
}