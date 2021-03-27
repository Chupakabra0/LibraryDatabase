using System;
using System.Linq;
using ConsoleDBTest.DB;
using ConsoleDBTest.Dealer;
using ConsoleDBTest.ViewModels;
using ConsoleTables;

namespace ConsoleDBTest.ModelController {
    public class ClientCardController : ConsoleController {
        public override bool Add(UniversityLibrary db) {
            try {
                var defaultIntValue  = 0;
                var defaultBoolValue = true;
                var defaultNullableValue = "null";

                var dateGiven     = this.AskDate($"Enter DateTime DateGiven ({defaultNullableValue}): ");
                var studentId     = this.AskNullableInt($"Enter int StudentId ({defaultNullableValue}): ");
                var teacherId   = this.AskNullableInt($"Enter int TeacherId ({defaultNullableValue}): ");
                var isActive = this.AskBoolean($"Is it active? [true/false]({defaultBoolValue}): ", defaultBoolValue);

                this.ClientCardDealer.AddCard(db, dateGiven, studentId, teacherId, isActive);
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public override bool Show(UniversityLibrary db) {
            try {
                this.GetConsoleTable(this.ClientCardDealer.Select(db)
                                         .Select(card => new ClientCardViewModel(card, db))
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
                    this.ClientCardDealer.Delete(db, id);
                }
                else {
                    this.ClientCardDealer.Delete(db);
                }
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public override bool Edit(UniversityLibrary db) {
            try {
                var defaultIntValue  = 0;
                var defaultBoolValue = true;

                var id = this.AskInt("Enter int Id (): ", defaultIntValue);
                if (this.ClientCardDealer.Select(db, id)?.Count == 0) {
                    // TODO: ERROR ID IS NO VALID
                    return false;
                }

                var date      = this.AskDate("Enter DateTime DateGiven: ");
                var studentId = this.AskNullableInt($"Enter int StudentId ({defaultIntValue}): ");
                var teacherId = this.AskNullableInt($"Enter int TeacherId ({defaultIntValue}): ");
                var isActive  = this.AskBoolean($"Is it active? [true/false]({defaultBoolValue}): ", defaultBoolValue);

                if (id > 0) {
                    this.ClientCardDealer.UpdateCard(db, id, date, studentId, teacherId, isActive);
                }
                else {
                    this.ClientCardDealer.UpdateCard(db, date, studentId, teacherId, isActive);
                }
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public ClientCardDealer ClientCardDealer { get; set; } = new();
    }
}
