using System;
using System.Linq;
using ConsoleDBTest.DB;
using ConsoleDBTest.Dealer;
using ConsoleDBTest.ViewModels;
using ConsoleTables;

namespace ConsoleDBTest.ModelController {
    public class TeacherController : ConsoleController {
        public override bool Add(UniversityLibrary db) {
            try {
                var defaultIntValue  = 0;
                var defaultStrValue  = string.Empty;
                var defaultBoolValue = true;

                var name = this.AskString($"Enter string Name ({defaultStrValue}): ", defaultStrValue);
                var surname = this.AskString($"Enter string Surname ({defaultStrValue}): ", defaultStrValue);
                var patronymic = this.AskString($"Enter string Patronymic ({defaultStrValue}): ", defaultStrValue);
                var cityId = this.AskInt($"Enter int CityId ({defaultIntValue}): ", defaultIntValue);
                var cathedraId = this.AskInt($"Enter int CathedraId ({defaultIntValue}): ", defaultIntValue);
                var isActive = this.AskBoolean($"Is it active? [true/false]({defaultBoolValue}): ", defaultBoolValue);

                this.TeacherDealer.AddTeacher(db, name, surname, patronymic, cityId, cathedraId, isActive);
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public override bool Show(UniversityLibrary db) {
            try {
                this.GetConsoleTable(this.TeacherDealer.Select(db)
                                         .Select(teacher => new TeacherViewModel(teacher, db))
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

        public override bool Edit(UniversityLibrary db) {
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
                var isActive = this.AskBoolean($"Is it active? [true/false]({defaultBoolValue}): ", defaultBoolValue);

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
