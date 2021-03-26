using System;
using System.Data.Entity;
using System.Linq;
using ConsoleDBTest.Dealer;
using ConsoleDBTest.ViewModels;
using ConsoleTables;

namespace ConsoleDBTest.ModelController {
    public class DegreeController : ConsoleController {
        public override bool Add(DbContext db) {
            try {
                var defaultStrValue = string.Empty;
                var defaultBoolValue = true;

                var name = this.AskString($"Enter string Name ({defaultStrValue}): ", defaultStrValue);
                var shortLetter = this.AskString($"Enter string ShortLetter ({defaultStrValue}): ", defaultStrValue);
                var isActive = this.AskBoolean($"Is it active ? [true/false]({defaultBoolValue}) : ", defaultBoolValue);

                this.DegreeDealer.AddDegree(db, name, shortLetter, isActive);
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public override bool Show(DbContext db) {
            try {
                this.GetConsoleTable(this.DegreeDealer.Select(db)
                                         .Select(degree => new DegreeViewModel(degree))
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
                    this.DegreeDealer.Delete(db, id);
                }
                else {
                    this.DegreeDealer.Delete(db);
                }
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public override bool Edit(DbContext db) {
            try {
                var defaultIntValue = 0;
                var defaultStrValue = string.Empty;
                var defaultBoolValue = true;

                var id = this.AskInt("Enter int Id (): ", defaultIntValue);
                if (this.DegreeDealer.Select(db, id)?.Count == 0) {
                    // TODO: ERROR ID IS NO VALID
                    return false;
                }

                var name = this.AskString($"Enter string Name ({defaultStrValue}): ", defaultStrValue);
                var shortLetter = this.AskString($"Enter string ShortLetter ({defaultStrValue}): ", defaultStrValue);
                var isActive = this.AskBoolean($"Is it active ? [True/False]({defaultBoolValue}) : ", defaultBoolValue);

                if (id > 0) {
                    this.DegreeDealer.UpdateDegree(db, id, name, shortLetter, isActive);
                }
                else {
                    this.DegreeDealer.UpdateDegree(db, name, shortLetter, isActive);
                }
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public DegreeDealer DegreeDealer { get; set; } = new();
    }
}
