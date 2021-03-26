using ConsoleDBTest.Models;

namespace ConsoleDBTest.ViewModels {
    public class CityViewModel {
        public CityViewModel(City city) {
            this.Id       = city.Id;
            this.Name     = city.Name;
            this.Country  = city.Country.ShortName;
            this.IsActive = city.IsActive;
        }

        public int    Id       { get; set; }
        public string Name     { get; set; }
        public string Country  { get; set; }
        public bool   IsActive { get; set; }
    }
}
