using System;
using System.Collections.Generic;
using ConsoleDBTest.DB;
using ConsoleDBTest.Reader;
using ConsoleTables;

namespace ConsoleDBTest.ModelController {
    public interface IUniversityModelController {
        public bool Add(UniversityLibrary    db);
        public bool Show(UniversityLibrary   db);
        public bool Remove(UniversityLibrary db);
        public bool Edit(UniversityLibrary   db);
    }

    public abstract class ConsoleController : IUniversityModelController {
        public abstract bool Add(UniversityLibrary    db);
        public abstract bool Show(UniversityLibrary   db);
        public abstract bool Remove(UniversityLibrary db);
        public abstract bool Edit(UniversityLibrary   db);

        protected ConsoleController() {
            this.ConsoleReader = new ConsoleReader();
        }

        protected bool AskBoolean(string message, bool emptyResult = true) {
            try {
                Console.Write(message);
                var result = this.ConsoleReader.ReadString().ToLower();

                return result.Length == 0
                    ? emptyResult
                    : result == "t" || result == "true" || result == "y" || result == "yes";
            }
            catch (Exception) {
                return emptyResult;
            }
        }

        protected string AskString(string message, string emptyResult = "") {
            try {
                Console.Write(message);
                var result = this.ConsoleReader.ReadString();

                return result.Length == 0 ? emptyResult : result;
            }
            catch (Exception) {
                return emptyResult;
            }
        }

        protected char AskSymbol(string message, char emptyResult = ' ') {
            try {
                Console.Write(message);
                var result = this.ConsoleReader.ReadSymbol();

                return result != '\0' ? result : emptyResult;
            }
            catch (Exception) {
                return emptyResult;
            }
        }

        protected int AskInt(string message, int emptyResult = 0) {
            try {
                Console.Write(message);
                var result = this.ConsoleReader.ReadString();

                return result.Length == 0 ? emptyResult : int.Parse(result);
            }
            catch (Exception) {
                return emptyResult;
            }
        }

        protected int? AskNullableInt(string message) {
            try {
                Console.Write(message);
                var result = this.ConsoleReader.ReadString();

                return result.Length == 0 ? null : int.Parse(result);
            }
            catch (Exception) {
                return null;
            }
        }

        protected DateTime? AskDate(string message) {
            try {
                Console.Write(message);
                return this.ConsoleReader.ReadNullableDate();
            }
            catch (Exception) {
                return null;
            }
        }

        protected ConsoleTable GetConsoleTable<T>(IEnumerable<T> source) {
            var table = ConsoleTable.From(source);
            table.Options.EnableCount = false;

            return table;
        }

        public ConsoleReader ConsoleReader { get; set; }
    }
}
