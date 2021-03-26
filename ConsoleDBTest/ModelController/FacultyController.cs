using System;
using System.Data.Entity;
using System.Linq;
using ConsoleDBTest.Dealer;
using ConsoleDBTest.ViewModels;
using ConsoleTables;

namespace ConsoleDBTest.ModelController
{
    public class FacultyController : ConsoleController
    {
        public override bool Add(DbContext db) {
            try {
                var defaultStrValue  = string.Empty;
                var defaultBoolValue = true;

                var name     = this.AskString($"Enter string Name ({defaultStrValue}): ", defaultStrValue);
                var shortName = this.AskString($"Enter string ShortName ({defaultStrValue}): ", defaultStrValue);
                var shortLetter = this.AskString($"Enter char ShortLetter ({defaultStrValue}): ", defaultStrValue);
                var isActive = this.AskBoolean($"Is it active ? [true/false]({defaultBoolValue}) : ", defaultBoolValue);

                this.FacultyDealer.AddFaculty(db, name, shortName, shortLetter, isActive);
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public override bool Show(DbContext db) {
            try {
                this.GetConsoleTable(this.FacultyDealer.Select(db)
                                         .Select(faculty => new FacultyViewModel(faculty))
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
                    this.FacultyDealer.Delete(db, id);
                }
                else {
                    this.FacultyDealer.Delete(db);
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

                var id = this.AskInt("Enter int Id (): ", defaultIntValue);
                if (this.FacultyDealer.Select(db, id)?.Count == 0) {
                    // TODO: ERROR ID IS NO VALID
                    return false;
                }

                var name = this.AskString($"Enter string Name ({defaultStrValue}): ", defaultStrValue);
                var shortName = this.AskString($"Enter string ShortName ({defaultStrValue}): ", defaultStrValue);
                var shortLetter = this.AskString($"Enter string ShortLetter ({defaultStrValue}): ", defaultStrValue);
                var isActive = this.AskBoolean($"Is it active ? [True/False]({defaultBoolValue}) : ", defaultBoolValue);

                if (id > 0) {
                    this.FacultyDealer.UpdateFaculty(db, id, name, shortName, shortLetter, isActive);
                }
                else {
                    this.FacultyDealer.UpdateFaculty(db, name, shortName, shortLetter, isActive);
                }
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public FacultyDealer FacultyDealer { get; set; } = new();
    }
}
