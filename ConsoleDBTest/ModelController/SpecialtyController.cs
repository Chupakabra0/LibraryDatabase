using System;
using System.Data.Entity;
using ConsoleDBTest.Dealer;
using ConsoleTables;

namespace ConsoleDBTest.ModelController {
    public class SpecialtyController : ConsoleController {
        public override bool Add(DbContext db) {
            try {
                var defaultStrValue = string.Empty;
                var defaultBoolValue = true;

                var name = this.AskString($"Enter string Name ({defaultStrValue}): ", defaultStrValue);
                var shortLetter = this.AskString($"Enter string ShortLetter ({defaultStrValue}): ", defaultStrValue);
                var isActive = this.AskBoolean($"Is it active ? [true/false]({defaultBoolValue}) : ", defaultBoolValue);

                this.SpecialtyDealer.AddSpecialty(db, name, shortLetter, isActive);
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public override bool Show(DbContext db) {
            try {
                var table = ConsoleTable.From(this.SpecialtyDealer.Select(db));

                table.Columns.RemoveAt(table.Columns.Count - 1);
                table.Options.EnableCount = false;
                table.Write(Format.MarkDown);
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
                    this.SpecialtyDealer.Delete(db, id);
                }
                else {
                    this.SpecialtyDealer.Delete(db);
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
                if (this.SpecialtyDealer.Select(db, id)?.Count == 0) {
                    // TODO: ERROR ID IS NO VALID
                    return false;
                }

                var name = this.AskString($"Enter string Name ({defaultStrValue}): ", defaultStrValue);
                var shortLetter = this.AskString($"Enter string ShortLetter ({defaultStrValue}): ", defaultStrValue);
                var isActive = this.AskBoolean($"Is it active ? [True/False]({defaultBoolValue}) : ", defaultBoolValue);

                if (id > 0) {
                    this.SpecialtyDealer.UpdateSpecialty(db, id, name, shortLetter, isActive);
                }
                else {
                    this.SpecialtyDealer.UpdateSpecialty(db, name, shortLetter, isActive);
                }
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public SpecialtyDealer SpecialtyDealer { get; set; } = new();
    }
}
