using System;
using System.Linq;
using ConsoleDBTest.DB;
using ConsoleDBTest.Dealer;
using ConsoleDBTest.ViewModels;
using ConsoleTables;

namespace ConsoleDBTest.ModelController {
    public class WorkerController : ConsoleController {
        public override bool Add(UniversityLibrary db) {
            try {
                var defaultStrValue = string.Empty;
                var defaultBoolValue = true;

                var name = this.AskString($"Enter string Name ({defaultStrValue}): ", defaultStrValue);
                var surname = this.AskString($"Enter string Surname ({defaultStrValue}): ", defaultStrValue);
                var patronymic = this.AskString($"Enter string Patronymic ({defaultStrValue}): ", defaultStrValue);
                var isActive = this.AskBoolean($"Is it active? [true/false]({defaultBoolValue}): ", defaultBoolValue);

                this.WorkerDealer.AddWorker(db, name, surname, patronymic, isActive);
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public override bool Show(UniversityLibrary db) {
            try {
                this.GetConsoleTable(this.WorkerDealer.Select(db)
                                         .Select(worker => new WorkerViewModel(worker))
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
                    this.WorkerDealer.Delete(db, id);
                }
                else {
                    this.WorkerDealer.Delete(db);
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
                if (this.WorkerDealer.Select(db, id)?.Count == 0) {
                    // TODO: ERROR ID IS NO VALID
                    return false;
                }

                var name = this.AskString($"Enter string Name ({defaultStrValue}): ", defaultStrValue);
                var surname = this.AskString($"Enter string Surname ({defaultStrValue}): ", defaultStrValue);
                var patronymic = this.AskString($"Enter string Patronymic ({defaultStrValue}): ", defaultStrValue);
                var isActive = this.AskBoolean($"Is it active? [true/false]({defaultBoolValue}): ", defaultBoolValue);

                if (id > 0) {
                    this.WorkerDealer.UpdateWorker(db, id, name, surname, patronymic, isActive);
                }
                else {
                    this.WorkerDealer.UpdateWorker(db, name, surname, patronymic, isActive);
                }
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public WorkerDealer WorkerDealer { get; set; } = new();
    }
}
