using System;
using System.Data.Entity;
using ConsoleDBTest.Dealer;
using ConsoleTables;

namespace ConsoleDBTest.ModelController
{
    public class CityController : ConsoleController
    {
        public override bool Add(DbContext db) {
            try {
                var defaultStrValue  = string.Empty;
                var defaultIntValue  = 0;
                var defaultBoolValue = true;

                var name     = this.AskString($"Enter string Name ({defaultStrValue}): ", defaultStrValue);
                var countryId = this.AskInt($"Enter int CountryId ({defaultIntValue}): ", defaultIntValue);
                var isActive = this.AskBoolean($"Is it active ? [true/false]({defaultBoolValue}) : ", defaultBoolValue);

                this.CityDealer.AddCity(db, name, countryId, isActive);
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public override bool Show(DbContext db) {
            try {
                var table = ConsoleTable.From(this.CityDealer.Select(db));

                table.Columns.RemoveAt(table.Columns.Count - 1);
                table.Columns.RemoveAt(table.Columns.Count - 1);
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
                    this.CityDealer.Delete(db, id);
                }
                else {
                    this.CityDealer.Delete(db);
                }
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public override bool Edit(DbContext db) {
            try {
                var defaultStrValue  = string.Empty;
                var defaultIntValue  = 0;
                var defaultBoolValue = true;

                var id = this.AskInt("Enter int Id (): ", defaultIntValue);
                if (this.CityDealer.Select(db, id)?.Count == 0) {
                    // TODO: ERROR ID IS NO VALID
                    return false;
                }

                var name = this.AskString($"Enter string Name ({defaultStrValue}): ", defaultStrValue);
                var countryId = this.AskInt($"Enter int CountryId ({defaultIntValue}): ", defaultIntValue);
                var isActive = this.AskBoolean($"Is it active ? [True/False]({defaultBoolValue}) : ", defaultBoolValue);

                if (id > 0) {
                    this.CityDealer.UpdateCity(db, id, name, countryId, isActive);
                }
                else {
                    this.CityDealer.UpdateCity(db, name, countryId, isActive);
                }
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public CityDealer CityDealer { get; set; } = new();
    }
}
