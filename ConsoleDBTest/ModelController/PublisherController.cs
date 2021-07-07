using System;
using System.Linq;
using ConsoleDBTest.DB;
using ConsoleDBTest.Dealer;
using ConsoleDBTest.ViewModels;
using ConsoleTables;

namespace ConsoleDBTest.ModelController {
    public class PublisherController : ConsoleController {
        public override bool Add(UniversityLibrary db) {
            try {
                var defaultStrValue  = string.Empty;
                var defaultIntValue  = 0;
                var defaultBoolValue = true;

                var name     = this.AskString($"Enter string Name ({defaultStrValue}): ", defaultStrValue);
                var cityId = this.AskInt($"Enter int CityId ({defaultIntValue}): ", defaultIntValue);
                var isActive = this.AskBoolean($"Is it active? [true/false]({defaultBoolValue}) : ", defaultBoolValue);

                this.PublisherDealer.AddPublisher(db, name, cityId, isActive);
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public override bool Show(UniversityLibrary db) {
            try {
                this.GetConsoleTable(this.PublisherDealer.Select(db)
                                         .Select(publisher => new PublisherViewModel(publisher, db))
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
                    this.PublisherDealer.Delete(db, id);
                }
                else {
                    this.PublisherDealer.Delete(db);
                }
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public override bool Edit(UniversityLibrary db) {
            try {
                var defaultStrValue  = string.Empty;
                var defaultIntValue  = 0;
                var defaultBoolValue = true;

                var id = this.AskInt("Enter int Id (): ", defaultIntValue);
                if (this.PublisherDealer.Select(db, id)?.Count == 0) {
                    // TODO: ERROR ID IS NO VALID
                    return false;
                }

                var name = this.AskString($"Enter string Name ({defaultStrValue}): ", defaultStrValue);
                var cityId = this.AskInt($"Enter int CityId ({defaultIntValue}): ", defaultIntValue);
                var isActive = this.AskBoolean($"Is it active? [True/False]({defaultBoolValue}) : ", defaultBoolValue);

                if (id > 0) {
                    this.PublisherDealer.UpdatePublisher(db, id, name, cityId, isActive);
                }
                else {
                    this.PublisherDealer.UpdatePublisher(db, name, cityId, isActive);
                }
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public PublisherDealer PublisherDealer { get; set; } = new();
    }
}
