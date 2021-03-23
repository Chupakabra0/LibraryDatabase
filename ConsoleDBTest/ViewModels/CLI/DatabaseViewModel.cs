using System;
using System.Data.Entity;
using ConsoleDBTest.ModelController;
using ConsoleDBTest.Reader;

namespace ConsoleDBTest.ViewModels.CLI
{
    public class DatabaseViewModel {
        public DatabaseViewModel(DbContext databaseContext, ConsoleReader consoleReader) {
            this.DatabaseContext = databaseContext;
            this.ConsoleReader   = consoleReader;
        }

        public bool ExecuteShow(string tableName) => 
            this.GetController(tableName)?.Show(this.DatabaseContext) ?? false;

        public bool ExecuteAdd(string tableName) =>
            this.GetController(tableName)?.Add(this.DatabaseContext) ?? false;

        public bool ExecuteRemove(string tableName) =>
            this.GetController(tableName)?.Remove(this.DatabaseContext) ?? false;

        public bool ExecuteEdit(string tableName) => 
            this.GetController(tableName)?.Edit(this.DatabaseContext) ?? false;
        

        private ConsoleController GetController(string tableName) =>
            tableName switch {
                "Countries" => new CountryController(),
                "Genres"    => new GenreController(),
                "Authors"   => new AuthorController(),
                _           => null
            };
        

        public DbContext     DatabaseContext { get; set; }
        public ConsoleReader ConsoleReader   { get; set; }
    }
}
