using System.ComponentModel.DataAnnotations;

namespace ConsoleDBTest.Models {
    public class Book {
        [Key]
        public int Id { get; set; }

        public string Name     { get; set; }
        public bool   IsActive { get; set; }

        public int AuthorId    { get; set; }
        public int PublisherId { get; set; }
        public int GenreId     { get; set; }
        public int LibraryId   { get; set; }
    }
}
