using ConsoleDBTest.Models;

namespace ConsoleDBTest.ViewModels {
    public class PublisherViewModel {
        public PublisherViewModel(Publisher publisher) {
            this.Id       = publisher.Id;
            this.Name     = publisher.Name;
            this.City     = publisher.City.Name;
            this.IsActive = publisher.IsActive;
        }

        public int    Id       { get; set; }
        public string Name     { get; set; }
        public string City     { get; set; }
        public bool   IsActive { get; set; }
    }
}
