using System;
using System.Globalization;
using ConsoleDBTest.ViewModels.CLI;


namespace ConsoleDBTest.View {
    public class ConsoleView {
        public ConsoleView(DatabaseViewModel databaseViewModel) {
            this.DatabaseViewModel = databaseViewModel;
        }

        public void Show() {
            var tableName = string.Empty;

            while (tableName.ToLower() != "exit") {
                if (tableName == string.Empty) {
                    Console.WriteLine("Connected to DB... Write name of a table to work with.");
                    Console.Write("> ");
                    tableName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(this.DatabaseViewModel.ConsoleReader
                                                                                    .ReadString()
                                                                                    .ToLower());
                }
                else {
                    Console.WriteLine($"Working with {tableName}. Enter your command...");
                    Console.Write("> ");

                    var command = this.DatabaseViewModel.ConsoleReader.ReadString().Split(" ");
                    switch (command[0]) {
                        case"exit": {
                            tableName = "exit";
                            break;
                        }
                        case"cls": {
                            Console.Clear();
                            break;
                        }
                        case"back": {
                            Console.WriteLine("Back to the table choose menu...");
                            tableName = string.Empty;
                            break;
                        }
                        case"show": {
                            this.DatabaseViewModel.ExecuteShow(tableName);
                            break;
                        }
                        case"add": {
                            this.DatabaseViewModel.ExecuteAdd(tableName);
                            break;
                        }
                        case"remove": {
                            this.DatabaseViewModel.ExecuteRemove(tableName);
                            break;
                        }
                        case"edit": {
                            this.DatabaseViewModel.ExecuteEdit(tableName);
                            break;
                        }
                    }
                }
            }

            Console.WriteLine("EXIT!");
        }

        public DatabaseViewModel DatabaseViewModel { get; set; }
    }
}
