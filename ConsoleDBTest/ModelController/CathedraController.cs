using System;
using System.Linq;
using ConsoleDBTest.DB;
using ConsoleDBTest.Dealer;
using ConsoleDBTest.ViewModels;
using ConsoleTables;

namespace ConsoleDBTest.ModelController
{
    public class CathedraController : ConsoleController
    {
        public override bool Add(UniversityLibrary db) {
            try {
                var defaultStrValue = string.Empty;
                var defaultBoolValue = true;

                var name     = this.AskString($"Enter string Name ({defaultStrValue}): ", defaultStrValue);
                var shortName = this.AskString($"Enter string ShortName ({defaultStrValue}): ", defaultStrValue);
                var isActive = this.AskBoolean($"Is it active ? [true/false]({defaultBoolValue}) : ", defaultBoolValue);

                this.CathedraDealer.AddCathedra(db, name, shortName, isActive);
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public override bool Show(UniversityLibrary db) {
            try {
                this.GetConsoleTable(this.CathedraDealer.Select(db)
                                         .Select(cathedra => new CathedraViewModel(cathedra))
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
                    this.CathedraDealer.Delete(db, id);
                }
                else {
                    this.CathedraDealer.Delete(db);
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
                if (this.CathedraDealer.Select(db, id)?.Count == 0) {
                    // TODO: ERROR ID IS NO VALID
                    return false;
                }

                var name = this.AskString($"Enter string Name ({defaultStrValue}): ", defaultStrValue);
                var shortName = this.AskString($"Enter string ShortName ({defaultStrValue}): ", defaultStrValue);
                var isActive = this.AskBoolean($"Is it active ? [True/False]({defaultBoolValue}) : ", defaultBoolValue);

                if (id > 0) {
                    this.CathedraDealer.UpdateCathedra(db, id, name, shortName, isActive);
                }
                else {
                    this.CathedraDealer.UpdateCathedra(db, name, shortName, isActive);
                }
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public CathedraDealer CathedraDealer { get; set; } = new();
    }
}
