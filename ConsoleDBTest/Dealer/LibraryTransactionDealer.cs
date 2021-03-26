﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ConsoleDBTest.Models;

namespace ConsoleDBTest.Dealer {
    public class LibraryTransactionDealer {
        public List<LibraryTransaction> Select(DbContext db) =>
            db.Database
              .SqlQuery<LibraryTransaction>($@"select * from {LibraryTransactionDealer.tableName}")
              .ToList();

        public List<LibraryTransaction> Select(DbContext db, int id) =>
            db.Database
              .SqlQuery<LibraryTransaction>($@"select * from {LibraryTransactionDealer.tableName} where Id = '{id}'")
              .ToList();

        public int Delete(DbContext db) =>
            db.Database
              .ExecuteSqlCommand($@"delete from {LibraryTransactionDealer.tableName}");

        public int Delete(DbContext db, int id) =>
            db.Database
              .ExecuteSqlCommand($@"delete from {LibraryTransactionDealer.tableName} where Id = '{id}'");

        public int UpdateTransaction(DbContext db, int id, DateTime? takeDate, DateTime? returnDate, int clientCardId, int workerId, int bookId, bool isReturnInTime, bool isActive) =>
            db.Database
              .ExecuteSqlCommand($@"update {LibraryTransactionDealer.tableName} set TakeDate={(takeDate == null ? "NULL" : $"'{takeDate}'")}, ReturnDate={(returnDate == null ? "NULL" : $"'{returnDate}'")}, ClientCardId={clientCardId}, WorkerId={workerId}, BookId={bookId}, IsReturnIntTime='{isReturnInTime}', IsActive='{isActive}' where Id = '{id}'");

        public int UpdateTransaction(DbContext db, DateTime? takeDate, DateTime? returnDate, int clientCardId, int workerId, int bookId, bool isReturnInTime, bool isActive) =>
            db.Database
              .ExecuteSqlCommand($@"update {LibraryTransactionDealer.tableName} set TakeDate={(takeDate == null ? "NULL" : $"'{takeDate}'")}, ReturnDate={(returnDate == null ? "NULL" : $"'{returnDate}'")}, ClientCardId={clientCardId}, WorkerId={workerId}, BookId={bookId}, IsReturnIntTime='{isReturnInTime}', IsActive='{isActive}'");

        public int AddTransaction(DbContext db, DateTime? takeDate, DateTime? returnDate, int clientCardId, int workerId, int bookId, bool isReturnInTime, bool isActive) =>
            db.Database
              .ExecuteSqlCommand($@"insert into {LibraryTransactionDealer.tableName} (TakeDate, ReturnDate, ClientCardId, WorkerId, BookId, IsReturnInTime, IsActive) values ({(takeDate == null ? "NULL" : $"'{takeDate}'")}, {(returnDate == null ? "NULL" : $"'{returnDate}'")}, {clientCardId}, {workerId}, {bookId}, '{isReturnInTime}', '{isActive}')");

        private static string tableName = "LibraryTransactions";
    }
}
