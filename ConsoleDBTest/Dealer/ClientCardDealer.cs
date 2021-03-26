using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ConsoleDBTest.Models;

namespace ConsoleDBTest.Dealer {
    public class ClientCardDealer {
        public List<ClientCard> Select(DbContext db) =>
            db.Database
              .SqlQuery<ClientCard>($@"select * from {ClientCardDealer.tableName}")
              .ToList();

        public List<ClientCard> Select(DbContext db, int id) =>
            db.Database
              .SqlQuery<ClientCard>($@"select * from {ClientCardDealer.tableName} where Id = '{id}'")
              .ToList();

        public int Delete(DbContext db) =>
            db.Database
              .ExecuteSqlCommand($@"delete from {ClientCardDealer.tableName}");

        public int Delete(DbContext db, int id) =>
            db.Database
              .ExecuteSqlCommand($@"delete from {ClientCardDealer.tableName} where Id = '{id}'");

        public int UpdateCard(DbContext db, int id, DateTime? dateGiven, int? studentId, int? teacherId, bool isActive) =>
            db.Database
              .ExecuteSqlCommand($@"update {ClientCardDealer.tableName} set DateGiven={(dateGiven == null ? "NULL" : $"'{dateGiven}'")}, StudentId={(studentId == null ? "NULL" : studentId)}, TeacherId={(teacherId == null ? "NULL" : teacherId)}, IsActive='{isActive}' where Id = '{id}'");

        public int UpdateCard(DbContext db, DateTime? dateGiven, int? studentId, int? teacherId, bool isActive) =>
            db.Database
              .ExecuteSqlCommand($@"update {ClientCardDealer.tableName} set DateGiven={(dateGiven == null ? "NULL" : $"'{dateGiven}'")}, StudentId={(studentId == null ? "NULL" : studentId)}, TeacherId={(teacherId == null ? "NULL" : teacherId)}, IsActive='{isActive}'");

        public int AddCard(DbContext db, DateTime? dateGiven, int? studentId, int? teacherId, bool isActive) =>
            db.Database.
               ExecuteSqlCommand($@"insert into {ClientCardDealer.tableName} (DateGiven, StudentId, TeacherId, IsActive) values ({(dateGiven == null ? "NULL" : $"'{dateGiven}'")}, {(studentId == null ? "NULL" : studentId)}, {(teacherId == null ? "NULL" : teacherId)}, '{isActive}')");
        
        private static string tableName = "ClientCards";
    }
}
