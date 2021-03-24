using System;
using System.Data.Entity;
using ConsoleDBTest.Dealer;
using ConsoleTables;

namespace ConsoleDBTest.ModelController {
    public class FacultyAndSpecialtyAndCathedraController : ConsoleController {
        public override bool Add(DbContext db) {
            try {
                var defaultIntValue  = 0;
                var defaultBoolValue = true;

                var facultyAndSpecialtyId = this.AskInt($"Enter int FacultyAndSpecialtyId ({defaultIntValue}): ", defaultIntValue);
                var cathedraId = this.AskInt($"Enter int CathedraId ({defaultIntValue}): ", defaultIntValue);
                var isActive = this.AskBoolean($"Is it active ? [true/false]({defaultBoolValue}) : ", defaultBoolValue);

                this.FacultyAndSpecialtyAndCathedraDealer.AddFacultyAndSpecialtyAndCathedra
                    (db, facultyAndSpecialtyId, cathedraId, isActive);
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public override bool Show(DbContext db) {
            try {
                var table = ConsoleTable.From(this.FacultyAndSpecialtyAndCathedraDealer.Select(db));

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
                    this.FacultyAndSpecialtyAndCathedraDealer.Delete(db, id);
                }
                else {
                    this.FacultyAndSpecialtyAndCathedraDealer.Delete(db);
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
                var defaultBoolValue = true;

                var id = this.AskInt("Enter int Id (): ", defaultIntValue);
                if (this.FacultyAndSpecialtyAndCathedraDealer.Select(db, id)?.Count == 0) {
                    // TODO: ERROR ID IS NO VALID
                    return false;
                }

                var facultyAndSpecialtyId = this.AskInt($"Enter int FacultyAndSpecialtyId ({defaultIntValue}): ", defaultIntValue);
                var cathedraId = this.AskInt($"Enter int CathedraId ({defaultIntValue}): ", defaultIntValue);
                var isActive = this.AskBoolean($"Is it active ? [true/false]({defaultBoolValue}) : ", defaultBoolValue);

                if (id > 0) {
                    this.FacultyAndSpecialtyAndCathedraDealer.UpdateFacultyAndSpecialtyAndCathedra(db, id,
                     facultyAndSpecialtyId, cathedraId, isActive);
                }
                else {
                    this.FacultyAndSpecialtyAndCathedraDealer.UpdateFacultyAndSpecialtyAndCathedra(db,
                     facultyAndSpecialtyId, cathedraId, isActive);
                }
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public FacultyAndSpecialtyAndCathedraDealer FacultyAndSpecialtyAndCathedraDealer { get; set; } = new();
    }
}
