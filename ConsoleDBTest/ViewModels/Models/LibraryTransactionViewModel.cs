using System;
using System.Linq;
using ConsoleDBTest.Models;

namespace ConsoleDBTest.ViewModels {
    public class LibraryTransactionViewModel {
        public LibraryTransactionViewModel(LibraryTransaction libraryTransaction) {
            this.Id             = libraryTransaction.Id;
            this.TakeDate       = LibraryTransactionViewModel.GetDate(libraryTransaction.TakeDate);
            this.ReturnDate     = LibraryTransactionViewModel.GetDate(libraryTransaction.ReturnDate);
            this.ClientCard     = LibraryTransactionViewModel.GetCard(libraryTransaction.ClientCard);
            this.Worker         = LibraryTransactionViewModel.GetWorkerName(libraryTransaction.Worker);
            this.Book           = libraryTransaction.Book.Name;
            this.IsReturnInTime = libraryTransaction.IsReturnInTime;
            this.IsActive       = libraryTransaction.IsActive;
        }

        private static string GetDate(DateTime? dateTime) =>
            dateTime?.ToShortDateString() ?? "null";

        private static string GetCard(ClientCard clientCard) =>
            clientCard is null ? "null" : $"№{clientCard.Id}";

        private static string GetWorkerName(Worker worker) =>
            worker is null ? "null" : $"{worker.Name.First()}. {worker.Patronymic.First()}. {worker.Surname}";

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
