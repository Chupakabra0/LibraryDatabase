using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ConsoleDBTest.Models;

namespace ConsoleDBTest.Dealer {
    public class PublisherDealer {
        public List<Publisher> Select(DbContext db) =>
            db.Database
              .SqlQuery<Publisher>($@"select * from {PublisherDealer.tableName}")
              .ToList();

        public List<Publisher> Select(DbContext db, int id) =>
            db.Database
              .SqlQuery<Publisher>($@"select * from {PublisherDealer.tableName} where Id = '{id}'")
              .ToList();

        public int Delete(DbContext db) =>
            db.Database
              .ExecuteSqlCommand($@"delete from {PublisherDealer.tableName}");

        public int Delete(DbContext db, int id) =>
            db.Database
              .ExecuteSqlCommand($@"delete from {PublisherDealer.tableName} where Id = '{id}'");

        public int UpdatePublisher(DbContext db, int id, string name, int cityId, bool isActive) =>
            db.Database
              .ExecuteSqlCommand($@"update {PublisherDealer.tableName} set Name=N'{name}', CityId={cityId}, IsActive='{isActive}' where Id = '{id}'");

        public int UpdatePublisher(DbContext db, string name, int cityId, bool isActive) =>
            db.Database
              .ExecuteSqlCommand($@"update {PublisherDealer.tableName} set Name=N'{name}', CityId={cityId}, IsActive='{isActive}'");

        public int AddPublisher(DbContext db, string name, int cityId, bool isActive) =>
            db.Database
              .ExecuteSqlCommand($@"insert into {PublisherDealer.tableName} (Name, CityId, IsActive) values (N'{name}', {cityId}, '{isActive}')");

        private static string tableName = "Publishers";
    }
}
