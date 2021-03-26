using System;
using System.Data.Entity;
using System.Linq;
using ConsoleDBTest.Dealer;
using ConsoleDBTest.ViewModels;
using ConsoleTables;

namespace ConsoleDBTest.ModelController {
    public class LibraryTransactionController : ConsoleController {
        public override bool Add(DbContext db) {
            try {
                var defaultIntValue  = 0;
                var defaultBoolValue = true;
                var defaultDateValue = "NULL";

                var takeDate = this.AskDate($"Enter DateTime TakeDate ({defaultDateValue}): ");
                var returnDate = this.AskDate($"Enter DateTime ReturnDate ({defaultDateValue}): ");
                var clientCardId = this.AskInt($"Enter int ClientCardId ({defaultIntValue}): ", defaultIntValue);
                var workerId = this.AskInt($"Enter int WorkerId ({defaultIntValue}): ", defaultIntValue);
                var bookId = this.AskInt($"Enter int BookId ({defaultIntValue}): ", defaultIntValue);
                var isReturnInTime = this.AskBoolean($"Enter bool IsReturnInTime [true/false]({defaultBoolValue}): ", defaultBoolValue);
                var isActive = this.AskBoolean($"Is it active ? [true/false]({defaultBoolValue}) : ", defaultBoolValue);

                this.LibraryTransactionDealer.AddTransaction(db, takeDate, returnDate, clientCardId, workerId, bookId, isReturnInTime, isActive);
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public override bool Show(DbContext db) {
            try {
                this.GetConsoleTable(this.LibraryTransactionDealer.Select(db)
                                         .Select(transaction => new LibraryTransactionViewModel(transaction))
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
                    this.LibraryTransactionDealer.Delete(db, id);
                }
                else {
                    this.LibraryTransactionDealer.Delete(db);
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
                var defaultBoolValue = true;
                var defaultDateValue = "NULL";

                var id = this.AskInt("Enter int Id (): ", defaultIntValue);
                if (this.LibraryTransactionDealer.Select(db, id)?.Count == 0) {
                    // TODO: ERROR ID IS NO VALID
                    return false;
                }

                var takeDate     = this.AskDate($"Enter DateTime TakeDate ({defaultDateValue}): ");
                var returnDate   = this.AskDate($"Enter DateTime ReturnDate ({defaultDateValue}): ");
                var clientCardId = this.AskInt($"Enter int ClientCardId ({defaultIntValue}): ", defaultIntValue);
                var workerId     = this.AskInt($"Enter int WorkerId ({defaultIntValue}): ",     defaultIntValue);
                var bookId       = this.AskInt($"Enter int BookId ({defaultIntValue}): ",       defaultIntValue);
                var isReturnInTime = this.AskBoolean($"Enter bool IsReturnInTime [true/false]({defaultBoolValue}): ", defaultBoolValue);
                var isActive = this.AskBoolean($"Is it active ? [true/false]({defaultBoolValue}) : ", defaultBoolValue);

                if (id > 0) {
                    this.LibraryTransactionDealer.UpdateTransaction(db, id, takeDate, returnDate, clientCardId, workerId, bookId, isReturnInTime, isActive);
                }
                else {
                    this.LibraryTransactionDealer.UpdateTransaction(db, takeDate, returnDate, clientCardId,
                                                                    workerId, bookId, isReturnInTime, isActive);
                }
            }
            catch (Exception) {
                return false;
            }

            return true;
        }

        public LibraryTransactionDealer LibraryTransactionDealer { get; set; } = new();
    }
}
