using System;
using System.Data.Entity;
using ConsoleDBTest.Dealer;
using ConsoleTables;

namespace ConsoleDBTest.ModelController {
    public class GroupController : ConsoleController {
        public override bool Add(DbContext db) {
            try {
                var defaultIntValue  = 0;
                var defaultBoolValue = true;

                var year = this.AskInt($"Enter int Year ({defaultIntValue}): ", defaultIntValue);
                var serial = this.AskInt($"Enter int Serial ({defaultIntValue}): ", defaultIntValue);
                var isActive = this.AskBoolean($"Is it active ? [true/false]({defaultBoolValue}) : ", defaultBoolValue);
                var facultyAndSpecialtyAndCathedraId =
                    this.AskInt($"Enter int FacultyAndSpecialtyAndCathedraId ({defaultIntValue}): ", defaultIntValue);
                var degreeId = this.AskInt($"Enter int DegreeId ({defaultIntValue}): ", defaultIntValue);

                this.GroupDealer.AddGroup(db, facultyAndSpecialtyAndCathedraId, degreeId, year, serial, isActive);
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public override bool Show(DbContext db) {
            try {
                var table = ConsoleTable.From(this.GroupDealer.Select(db));

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
                    this.GroupDealer.Delete(db, id);
                }
                else {
                    this.GroupDealer.Delete(db);
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
                if (this.GroupDealer.Select(db, id)?.Count == 0) {
                    // TODO: ERROR ID IS NO VALID
                    return false;
                }

                var year     = this.AskInt($"Enter int Year ({defaultIntValue}): ",     defaultIntValue);
                var serial   = this.AskInt($"Enter int Serial ({defaultIntValue}): ",   defaultIntValue);
                var isActive = this.AskBoolean($"Is it active ? [true/false]({defaultBoolValue}) : ", defaultBoolValue);
                var facultyAndSpecialtyAndCathedraId =
                    this.AskInt($"Enter int FacultyAndSpecialtyAndCathedraId ({defaultIntValue}): ", defaultIntValue);
                var degreeId = this.AskInt($"Enter int DegreeId ({defaultIntValue}): ", defaultIntValue);

                if (id > 0) {
                    this.GroupDealer.UpdateGroup(db, id, facultyAndSpecialtyAndCathedraId, degreeId, year, serial, isActive);
                }
                else {
                    this.GroupDealer.UpdateGroup(db, facultyAndSpecialtyAndCathedraId, degreeId, year, serial, isActive);
                }
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public GroupDealer GroupDealer { get; set; } = new();
    }
}
