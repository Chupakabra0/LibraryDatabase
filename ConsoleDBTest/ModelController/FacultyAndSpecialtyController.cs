using System;
using System.Data.Entity;
using ConsoleDBTest.Dealer;
using ConsoleTables;

namespace ConsoleDBTest.ModelController {
    public class FacultyAndSpecialtyController : ConsoleController {
        public override bool Add(DbContext db) {
            try {
                var defaultIntValue  = 0;
                var defaultBoolValue = true;

                var facultyId = this.AskInt($"Enter int FacultyId ({defaultIntValue}): ", defaultIntValue);
                var specialtyId = this.AskInt($"Enter int SpecialtyId ({defaultIntValue}): ", defaultIntValue);
                var isActive = this.AskBoolean($"Is it active ? [true/false]({defaultBoolValue}) : ", defaultBoolValue);

                this.FacultyAndSpecialtyDealer.AddFacultyAndSpecialty(db, facultyId, specialtyId, isActive);
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public override bool Show(DbContext db) {
            try {
                var table = ConsoleTable.From(this.FacultyAndSpecialtyDealer.Select(db));

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
                    this.FacultyAndSpecialtyDealer.Delete(db, id);
                }
                else {
                    this.FacultyAndSpecialtyDealer.Delete(db);
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
                if (this.FacultyAndSpecialtyDealer.Select(db, id)?.Count == 0) {
                    // TODO: ERROR ID IS NO VALID
                    return false;
                }

                var facultyId = this.AskInt($"Enter int FacultyId ({defaultIntValue}): ", defaultIntValue);
                var specialtyId = this.AskInt($"Enter int SpecialtyId ({defaultIntValue}): ", defaultIntValue);
                var isActive = this.AskBoolean($"Is it active ? [true/false]({defaultBoolValue}) : ", defaultBoolValue);

                if (id > 0) {
                    this.FacultyAndSpecialtyDealer.UpdateFacultyAndSpecialty(db, id, facultyId, specialtyId, isActive);
                }
                else {
                    this.FacultyAndSpecialtyDealer.UpdateFacultyAndSpecialty(db, facultyId, specialtyId, isActive);
                }
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public FacultyAndSpecialtyDealer FacultyAndSpecialtyDealer { get; set; } = new();
    }
}
