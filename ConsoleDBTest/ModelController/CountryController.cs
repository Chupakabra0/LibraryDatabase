using System;
using System.Data.Entity;
using System.Linq;
using ConsoleDBTest.Dealer;
using ConsoleDBTest.ViewModels;
using ConsoleTables;

namespace ConsoleDBTest.ModelController {
    public class CountryController : ConsoleController {
        public override bool Add(DbContext db) {
            try {
                var defaultStrValue = string.Empty;
                var defaultBoolValue = true;

                var longName  = this.AskString($"Enter string LongName ({defaultStrValue}): ",  defaultStrValue);
                var shortName = this.AskString($"Enter string ShortName ({defaultStrValue}): ", defaultStrValue);
                var isoCode   = this.AskString($"Enter string ISOCode ({defaultStrValue}): ",   defaultStrValue);
                var isActive  = this.AskBoolean($"Is it active ? [true/false]({defaultBoolValue}) : ", defaultBoolValue);

                this.CountryDealer.AddCountry(db, longName, shortName, isoCode, isActive);
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public override bool Show(DbContext db) {
            try {
                this.GetConsoleTable(this.CountryDealer.Select(db).
                                          Select(country => new CountryViewModel(country)).
                                          ToList())
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
                var id              = this.AskInt("Enter int Id (): ", defaultIntValue);

                if (id > 0) {
                    this.CountryDealer.Delete(db, id);
                }
                else {
                    this.CountryDealer.Delete(db);
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

                var id        = this.AskInt("Enter int Id (): ", defaultIntValue);
                if (this.CountryDealer.Select(db, id)?.Count == 0) {
                    // TODO: ERROR ID IS NO VALID
                    return false;
                }

                var longName  = this.AskString($"Enter string LongName ({defaultStrValue}): ",  defaultStrValue);
                var shortName = this.AskString($"Enter string ShortName ({defaultStrValue}): ", defaultStrValue);
                var isoCode   = this.AskString($"Enter string ISOCode ({defaultStrValue}): ",   defaultStrValue);
                var isActive = this.AskBoolean($"Is it active ? [True/False]({defaultBoolValue}) : ", defaultBoolValue);

                if (id > 0) {
                    this.CountryDealer.UpdateCountry(db, id, longName, shortName, isoCode, isActive);
                }
                else {
                    this.CountryDealer.UpdateCountry(db, longName, shortName, isoCode, isActive);
                }
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public CountryDealer CountryDealer { get; set; } = new();
    }
}
