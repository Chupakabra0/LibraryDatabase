using System;
using System.Data.Entity;
using System.Linq;
using ConsoleDBTest.Dealer;
using ConsoleDBTest.ViewModels;
using ConsoleTables;

namespace ConsoleDBTest.ModelController {
    public class GenreController : ConsoleController {
        public override bool Add(DbContext db) {
            try {
                var defaultStrValue = string.Empty;
                var defaultBoolValue = true;

                var name  = this.AskString($"Enter string Name ({defaultStrValue}): ", defaultStrValue);
                var isActive = this.AskBoolean($"Is it active ? [true/false]({defaultBoolValue}) : ", defaultBoolValue);

                this.GenreDealer.AddGenre(db, name, isActive);
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public override bool Show(DbContext db) {
            try {
                this.GetConsoleTable(this.GenreDealer.Select(db)
                                         .Select(genre => new GenreViewModel(genre))
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
                    this.GenreDealer.Delete(db, id);
                }
                else {
                    this.GenreDealer.Delete(db);
                }
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public override bool Edit(DbContext db) {
            try {
                var defaultIntValue  = 0;
                var defaultStrValue  = string.Empty;
                var defaultBoolValue = true;

                var id     = this.AskInt("Enter int Id (): ", defaultIntValue);
                if (this.GenreDealer.Select(db, id)?.Count == 0) {
                    // TODO: ERROR ID IS NO VALID
                    return false;
                }

                var name = this.AskString($"Enter string Name ({defaultStrValue}): ", defaultStrValue);
                var isActive = this.AskBoolean($"Is it active ? [True/False]({defaultBoolValue}) : ", defaultBoolValue);

                if (id > 0) {
                    this.GenreDealer.UpdateGenre(db, id, name, isActive);
                }
                else {
                    this.GenreDealer.UpdateGenre(db, name, isActive);
                }
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public GenreDealer GenreDealer { get; set; } = new();
    }
}
