using System;
using System.Data.Entity;
using System.Linq;
using ConsoleDBTest.Dealer;
using ConsoleDBTest.ViewModels;
using ConsoleTables;

namespace ConsoleDBTest.ModelController {
    public class BookController : ConsoleController {
        public override bool Add(DbContext db) {
            try {
                var defaultStrValue  = string.Empty;
                var defaultIntValue  = 0;
                var defaultBoolValue = true;

                var name     = this.AskString($"Enter string Name ({defaultStrValue}): ", defaultStrValue);
                var authorId = this.AskInt($"Enter int AuthorId ({defaultIntValue}): ", defaultIntValue);
                var publisherId = this.AskInt($"Enter int PublisherId ({defaultIntValue}): ", defaultIntValue);
                var genreId = this.AskInt($"Enter int GenreId ({defaultIntValue}): ", defaultIntValue);
                var isActive = this.AskBoolean($"Is it active ? [true/false]({defaultBoolValue}) : ", defaultBoolValue);

                this.BookDealer.AddBook(db, name, authorId, publisherId, genreId, isActive);
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public override bool Show(DbContext db) {
            try {
                this.GetConsoleTable(this.BookDealer.Select(db)
                                         .Select(book => new BookViewModel(book))
                                         .ToList())
                    .Write(Format.MarkDown);
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public override bool Remove(DbContext db) {
            try {
                var defaultIntValue = 0;

                var id = this.AskInt("Enter int Id (): ", defaultIntValue);

                if (id > 0) {
                    this.BookDealer.Delete(db, id);
                }
                else {
                    this.BookDealer.Delete(db);
                }
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public override bool Edit(DbContext db) {
            try {
                var defaultStrValue  = string.Empty;
                var defaultIntValue  = 0;
                var defaultBoolValue = true;

                var id = this.AskInt("Enter int Id (): ", defaultIntValue);
                if (this.BookDealer.Select(db, id)?.Count == 0) {
                    // TODO: ERROR ID IS NO VALID
                    return false;
                }

                var name = this.AskString($"Enter string Name ({defaultStrValue}): ", defaultStrValue);
                var authorId = this.AskInt($"Enter int AuthorId ({defaultIntValue}): ", defaultIntValue);
                var publisherId = this.AskInt($"Enter int PublisherId ({defaultIntValue}): ", defaultIntValue);
                var genreId = this.AskInt($"Enter int GenreId ({defaultIntValue}): ", defaultIntValue);
                var isActive = this.AskBoolean($"Is it active ? [true/false]({defaultBoolValue}) : ", defaultBoolValue);

                if (id > 0) {
                    this.BookDealer.UpdateBook(db, id, name, authorId, publisherId, genreId, isActive);
                }
                else {
                    this.BookDealer.UpdateBook(db, name, authorId, publisherId, genreId, isActive);
                }
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public BookDealer BookDealer { get; set; } = new();
    }
}
