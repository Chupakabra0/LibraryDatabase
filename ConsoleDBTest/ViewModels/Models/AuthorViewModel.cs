using ConsoleDBTest.Models;

namespace ConsoleDBTest.ViewModels {
    public class AuthorViewModel {
        public AuthorViewModel(Author author) {
            this.Id         = author.Id;
            this.Name       = author.Name;
            this.Surname    = author.Surname;
            this.Patronymic = author.Patronymic;
            this.IsActive   = author.IsActive;
        }

        public int    Id         { get; set; }
        public string Name       { get; set; }
        public string Surname    { get; set; }
        public string Patronymic { get; set; }
        public bool   IsActive   { get; set; }
    }
}
