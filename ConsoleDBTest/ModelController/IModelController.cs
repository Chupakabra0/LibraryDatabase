using System;
using System.Data.Entity;
using ConsoleDBTest.Reader;

namespace ConsoleDBTest.ModelController {
    public interface IModelController {
        public bool Add(DbContext db);
        public bool Show(DbContext db);
        public bool Remove(DbContext db);
        public bool Edit(DbContext db);
    }

    public abstract class ConsoleController : IModelController {
        public abstract bool Add(DbContext    db);
        public abstract bool Show(DbContext   db);
        public abstract bool Remove(DbContext db);
        public abstract bool Edit(DbContext   db);

        protected ConsoleController() {
            this.ConsoleReader = new ConsoleReader();
        }

        protected bool AskBoolean(string message, bool emptyResult = true) {
            try {
                Console.Write(message);
                var result = this.ConsoleReader.ReadString().ToLower();

                return result.Length == 0 ? emptyResult : result == "t" || result == "true";
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

        protected DateTime AskDate(string message) {
            try {
                Console.Write(message);
                return this.ConsoleReader.ReadDate();
            }
            catch (Exception) {
                return DateTime.MinValue;
            }
        }

        public ConsoleReader ConsoleReader { get; set; }
    }
}
