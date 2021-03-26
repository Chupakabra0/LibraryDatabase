using System.Linq;
using ConsoleDBTest.Models;

namespace ConsoleDBTest.ViewModels {
    public class BookViewModel {
        public BookViewModel(Book book) {
            this.Id        = book.Id;
            this.Name      = book.Name;
            this.Author    = BookViewModel.GetAuthorName(book.Author);
            this.Publisher = book.Publisher.Name;
            this.Genre     = book.Genre.Name;
        }

        private static string GetAuthorName(Author author) =>
            author is null ? "null" : $"{author.Name.First()}. {author.Patronymic.First()}. {author.Surname}";

        public int    Id        { get; set; }
        public string Name      { get; set; }
        public string Author    { get; set; }
        public string Publisher { get; set; }
        public string Genre     { get; set; }
        public bool   IsActive  { get; set; }
    }
}
