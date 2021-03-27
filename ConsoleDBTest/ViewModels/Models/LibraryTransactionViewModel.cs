using System;
using System.Linq;
using ConsoleDBTest.DB;
using ConsoleDBTest.Models;

namespace ConsoleDBTest.ViewModels {
    public class LibraryTransactionViewModel {
        public LibraryTransactionViewModel(LibraryTransaction libraryTransaction, UniversityLibrary db = null) {
            this.Id             = libraryTransaction.Id;
            this.TakeDate       = LibraryTransactionViewModel.GetDate(libraryTransaction.TakeDate);
            this.ReturnDate     = LibraryTransactionViewModel.GetDate(libraryTransaction.ReturnDate);
            this.ClientCard     = LibraryTransactionViewModel.GetCard(libraryTransaction.ClientCardId);
            this.Worker         = LibraryTransactionViewModel.GetWorkerName(libraryTransaction.WorkerId, db);
            this.Book           = LibraryTransactionViewModel.GetBookName(libraryTransaction.BookId, db);
            this.IsReturnInTime = libraryTransaction.IsReturnInTime;
            this.IsActive       = libraryTransaction.IsActive;
        }

        private static string GetDate(DateTime? dateTime) =>
            dateTime?.ToShortDateString() ?? "null";

        private static string GetCard(int clientCardId) =>
            $"№{clientCardId}";

        private static string GetWorkerName(int workerId, UniversityLibrary db) {
            var worker = db?.Database?.SqlQuery<Worker>($"select * from {nameof(db.Workers)} where Id={workerId}")
                           ?.ToList()
                           ?.First();

            return worker == null ? "null" : $"{worker.Name.First()}. {worker.Patronymic.First()}. {worker.Surname}";
        }

        private static string GetBookName(int bookId, UniversityLibrary db) =>
            db?.Database?.SqlQuery<Book>($"select * from {nameof(db.Books)} where Id={bookId}")
              ?.ToList()
              ?.First()
              ?.Name ?? "null";

        public int    Id             { get; set; }
        public string TakeDate       { get; set; }
        public string ReturnDate     { get; set; }
        public string ClientCard     { get; set; }
        public string Worker         { get; set; }
        public string Book           { get; set; }
        public bool   IsReturnInTime { get; set; }
        public bool   IsActive       { get; set; }
    }
}
