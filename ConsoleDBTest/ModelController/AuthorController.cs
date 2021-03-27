using System;
using System.Linq;
using ConsoleDBTest.DB;
using ConsoleDBTest.Dealer;
using ConsoleDBTest.ViewModels;
using ConsoleTables;

namespace ConsoleDBTest.ModelController {
    public class AuthorController : ConsoleController {
        public override bool Add(UniversityLibrary db) {
            try {
                var defaultStrValue = string.Empty;
                var defaultBoolValue = true;

                var name = this.AskString($"Enter string Name ({defaultStrValue}): ", defaultStrValue);
                var surname = this.AskString($"Enter string Surname ({defaultStrValue}): ", defaultStrValue);
                var patronymic = this.AskString($"Enter string Patronymic ({defaultStrValue}): ", defaultStrValue);
                var isActive = this.AskBoolean($"Is it active ? [true/false]({defaultBoolValue}) : ", defaultBoolValue);

                this.AuthorDealer.AddAuthor(db, name, surname, patronymic, isActive);
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public override bool Show(UniversityLibrary db) {
            try {
                this.GetConsoleTable(this.AuthorDealer.Select(db).
                                          Select(author => new AuthorViewModel(author))
                                          .ToList())
                    .Write(Format.MarkDown);
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public override bool Remove(UniversityLibrary db) {
            try {
                var defaultIntValue = 0;

                var id = this.AskInt("Enter int Id (): ", defaultIntValue);

                if (id > 0) {
                    this.AuthorDealer.Delete(db, id);
                }
                else {
                    this.AuthorDealer.Delete(db);
                }
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public override bool Edit(UniversityLibrary db) {
            try {
                var defaultIntValue = 0;
                var defaultStrValue = string.Empty;
                var defaultBoolValue = true;

                var id = this.AskInt("Enter int Id (): ", defaultIntValue);
                if (this.AuthorDealer.Select(db, id)?.Count == 0) {
                    // TODO: ERROR ID IS NO VALID
                    return false;
                }

                var name = this.AskString($"Enter string Name ({defaultStrValue}): ", defaultStrValue);
                var surname = this.AskString($"Enter string Surname ({defaultStrValue}): ", defaultStrValue);
                var patronymic = this.AskString($"Enter string Patronymic ({defaultStrValue}): ", defaultStrValue);
                var isActive = this.AskBoolean($"Is it active ? [true/false]({defaultBoolValue}) : ", defaultBoolValue);

                if (id > 0) {
                    this.AuthorDealer.UpdateAuthor(db, id, name, surname, patronymic, isActive);
                }
                else {
                    this.AuthorDealer.UpdateAuthor(db, name, surname, patronymic, isActive);
                }
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public AuthorDealer AuthorDealer { get; set; } = new();
    }
}
