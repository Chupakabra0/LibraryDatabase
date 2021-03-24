using System;
using System.Data.Entity;
using ConsoleDBTest.Dealer;
using ConsoleTables;

namespace ConsoleDBTest.ModelController {
    public class TeacherController : ConsoleController {
        public override bool Add(DbContext db) {
            try {
                var defaultIntValue  = 0;
                var defaultStrValue  = string.Empty;
                var defaultBoolValue = true;

                var name = this.AskString($"Enter string Name ({defaultStrValue}): ", defaultStrValue);
                var surname = this.AskString($"Enter string Surname ({defaultStrValue}): ", defaultStrValue);
                var patronymic = this.AskString($"Enter string Patronymic ({defaultStrValue}): ", defaultStrValue);
                var cityId = this.AskInt($"Enter int CityId ({defaultIntValue}): ", defaultIntValue);
                var cathedraId = this.AskInt($"Enter int CathedraId ({defaultIntValue}): ", defaultIntValue);
                var isActive = this.AskBoolean($"Is it active ? [true/false]({defaultBoolValue}) : ", defaultBoolValue);

                this.TeacherDealer.AddTeacher(db, name, surname, patronymic, cityId, cathedraId, isActive);
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public override bool Show(DbContext db) {
            try {
                var table = ConsoleTable.From(this.TeacherDealer.Select(db));

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
                    this.TeacherDealer.Delete(db, id);
                }
                else {
                    this.TeacherDealer.Delete(db);
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
                if (this.TeacherDealer.Select(db, id)?.Count == 0) {
                    // TODO: ERROR ID IS NO VALID
                    return false;
                }

                var name = this.AskString($"Enter string Name ({defaultStrValue}): ", defaultStrValue);
                var surname = this.AskString($"Enter string Surname ({defaultStrValue}): ", defaultStrValue);
                var patronymic = this.AskString($"Enter string Patronymic ({defaultStrValue}): ", defaultStrValue);
                var cityId = this.AskInt($"Enter int CityId ({defaultIntValue}): ", defaultIntValue);
                var cathedraId = this.AskInt($"Enter int CathedraId ({defaultIntValue}): ", defaultIntValue);
                var isActive = this.AskBoolean($"Is it active ? [true/false]({defaultBoolValue}) : ", defaultBoolValue);

                if (id > 0) {
                    this.TeacherDealer.UpdateTeacher(db, id, name, surname, patronymic, cityId, cathedraId, isActive);
                }
                else {
                    this.TeacherDealer.UpdateTeacher(db, name, surname, patronymic, cityId, cathedraId, isActive);
                }
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public TeacherDealer TeacherDealer { get; set; } = new();
    }
}
