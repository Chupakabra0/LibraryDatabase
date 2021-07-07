using System.Linq;
using ConsoleDBTest.DB;
using ConsoleDBTest.Models;

namespace ConsoleDBTest.ViewModels {
    public class PublisherViewModel {
        public PublisherViewModel(Publisher publisher, UniversityLibrary db = null) {
            this.Id       = publisher.Id;
            this.Name     = publisher.Name;
            this.City     = PublisherViewModel.GetCityName(publisher.CityId, db);
            this.IsActive = publisher.IsActive;
        }

        private static string GetCityName(int cityId, UniversityLibrary db) =>
            db?.Database
              ?.SqlQuery<City>($"select * from {nameof(db.Cities)} where Id={cityId}")
              ?.ToList()
              ?.First().Name ?? "null";

        public int    Id       { get; set; }
        public string Name     { get; set; }
        public string City     { get; set; }
        public bool   IsActive { get; set; }
    }
}
