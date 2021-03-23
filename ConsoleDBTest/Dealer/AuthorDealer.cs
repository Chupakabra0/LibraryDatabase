﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ConsoleDBTest.Models;

namespace ConsoleDBTest.Dealer {
    public class AuthorDealer {
        public List<Author> Select(DbContext db) =>
            db.Database
              .SqlQuery<Author>($@"select * from {AuthorDealer.tableName}").ToList();

        public List<Author> Select(DbContext db, int id) =>
            db.Database
              .SqlQuery<Author>($@"select * from {AuthorDealer.tableName} where Id = '{id}'").ToList();

        public int Delete(DbContext db) => 
            db.Database
              .ExecuteSqlCommand($@"delete from {AuthorDealer.tableName}");

        public int Delete(DbContext db, int id) =>
            db.Database
              .ExecuteSqlCommand($@"delete from {AuthorDealer.tableName} where Id = '{id}'");
        
        public int UpdateAuthor(DbContext db, int id, string name, string surname, string patronymic, bool isActive) =>
            db.Database
              .ExecuteSqlCommand($@"update {AuthorDealer.tableName} set Name=N'{name}', Surname=N'{surname}', Patronymic=N'{patronymic}', IsActive='{isActive}' where Id = '{id}'");

        public int UpdateAuthor(DbContext db, string name, string surname, string patronymic, bool isActive) => 
            db.Database.
               ExecuteSqlCommand($@"update{AuthorDealer.tableName} set Name = N'{name}', Surname = N'{surname}', Patronymic = N'{patronymic}', IsActive = '{isActive}'");
        
        public int AddAuthor(DbContext db, string name, string surname, string patronymic, bool isActive) =>
            db.Database.
               ExecuteSqlCommand($@"insert into {AuthorDealer.tableName} (Name, Surname, Patronymic, IsActive) values (N'{name}', N'{surname}',N'{patronymic}', '{isActive}')");

        private static string tableName = "Authors";
    }
}