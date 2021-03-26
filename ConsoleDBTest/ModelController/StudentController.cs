using System;
using System.Data.Entity;
using System.Linq;
using ConsoleDBTest.Dealer;
using ConsoleDBTest.ViewModels;
using ConsoleTables;

namespace ConsoleDBTest.ModelController {
    public class StudentController : ConsoleController {
        public override bool Add(DbContext db) {
            try {
                var defaultIntValue  = 0;
                var defaultStrValue  = string.Empty;
                var defaultBoolValue = true;

                var name = this.AskString($"Enter string Name ({defaultStrValue}): ", defaultStrValue);
                var surname = this.AskString($"Enter string Surname ({defaultStrValue}): ", defaultStrValue);
                var patronymic = this.AskString($"Enter string Patronymic ({defaultStrValue}): ", defaultStrValue);
                var cityId = this.AskInt($"Enter int CityId ({defaultIntValue}): ", defaultIntValue);
                var groupId = this.AskInt($"Enter int GroupId ({defaultIntValue}): ", defaultIntValue);
                var isActive = this.AskBoolean($"Is it active ? [true/false]({defaultBoolValue}) : ", defaultBoolValue);

                this.StudentDealer.AddStudent(db, name, surname, patronymic, cityId, groupId, isActive);
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public override bool Show(DbContext db) {
            try {
                this.GetConsoleTable(this.StudentDealer.Select(db)
                                         .Select(student => new StudentViewModel(student))
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
                    this.StudentDealer.Delete(db, id);
                }
                else {
                    this.StudentDealer.Delete(db);
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
                if (this.StudentDealer.Select(db, id)?.Count == 0) {
                    // TODO: ERROR ID IS NO VALID
                    return false;
                }

                var name = this.AskString($"Enter string Name ({defaultStrValue}): ", defaultStrValue);
                var surname = this.AskString($"Enter string Surname ({defaultStrValue}): ", defaultStrValue);
                var patronymic = this.AskString($"Enter string Patronymic ({defaultStrValue}): ", defaultStrValue);
                var cityId = this.AskInt($"Enter int CityId ({defaultIntValue}): ", defaultIntValue);
                var groupId = this.AskInt($"Enter int GroupId ({defaultIntValue}): ", defaultIntValue);
                var isActive = this.AskBoolean($"Is it active ? [true/false]({defaultBoolValue}) : ", defaultBoolValue);

                if (id > 0) {
                    this.StudentDealer.UpdateStudent(db, id, name, surname, patronymic, cityId, groupId, isActive);
                }
                else {
                    this.StudentDealer.UpdateStudent(db, name, surname, patronymic, cityId, groupId, isActive);
                }
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public StudentDealer StudentDealer { get; set; } = new();
    }
}
