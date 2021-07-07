﻿using System.Linq;
using ConsoleDBTest.DB;
using ConsoleDBTest.Models;
using ConsoleDBTest.Utils.StringUtils;

namespace ConsoleDBTest.ViewModels {
    public class BookViewModel {
        public BookViewModel(Book book, UniversityLibrary db = null) {
            this.Id        = book.Id;
            this.Name      = book.Name;
            this.Author    = BookViewModel.GetAuthorName(book.AuthorId, db);
            this.Publisher = BookViewModel.GetPublisherName(book.PublisherId, db);
            this.Genre     = BookViewModel.GetGenreName(book.GenreId, db);
            this.IsActive  = book.IsActive;
        }

        private static string GetAuthorName(int authorId, UniversityLibrary db) {
            var author = db?.Database?.SqlQuery<Author>($"select * from {nameof(db.Authors)} where Id={authorId}")
                           ?.ToList()
                           ?.First();

            return author == null ? "null" : 
                string.IsNullOrEmpty(author.Pseudonym) ?
                    StringUtils.GetPersonName(author.Name, author.Surname, author.Patronymic) : author.Pseudonym;
        }

        private static string GetPublisherName(int publisherId, UniversityLibrary db) =>
            db?.Database?.SqlQuery<Publisher>($"select * from {nameof(db.Publishers)} where Id={publisherId}")
              ?.ToList()
              ?.First()
              ?.Name ?? "null";

        private static string GetGenreName(int genreId, UniversityLibrary db) =>
            db?.Database?.SqlQuery<Genre>($"select * from {nameof(db.Genres)} where Id={genreId}")
              ?.ToList()
              ?.First()
              ?.Name ?? "null";

        public int    Id        { get; set; }
        public string Name      { get; set; }
        public string Author    { get; set; }
        public string Publisher { get; set; }
        public string Genre     { get; set; }
        public bool   IsActive  { get; set; }
    }
}
