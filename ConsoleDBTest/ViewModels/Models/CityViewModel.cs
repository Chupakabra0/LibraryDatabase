using System.Linq;
using ConsoleDBTest.DB;
using ConsoleDBTest.Models;

namespace ConsoleDBTest.ViewModels {
    public class CityViewModel {
        public CityViewModel(City city, UniversityLibrary db = null) {
            this.Id       = city.Id;
            this.Name     = city.Name;
            this.Country  = CityViewModel.GetCountry(city.CountryId, db);
            this.IsActive = city.IsActive;
        }

        private static string GetCountry(int cityId, UniversityLibrary db) =>
            db?.Database?.SqlQuery<Country>($"select * from {nameof(db.Countries)} where Id={cityId}")
              ?.ToList()
              ?.First()
              ?.ShortName ?? "null";
        
        public int    Id       { get; set; }
        public string Name     { get; set; }
        public string Country  { get; set; }
        public bool   IsActive { get; set; }
    }
}
