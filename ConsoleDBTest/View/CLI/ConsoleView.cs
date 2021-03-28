using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleDBTest.DB;
using ConsoleDBTest.Reader;
using ConsoleDBTest.Utils.StringUtils;
using ConsoleDBTest.ViewModels.CLI;

namespace ConsoleDBTest.View {
    public class ConsoleView {
        public ConsoleView(DatabaseViewModel databaseViewModel) {
            this.DatabaseViewModel = databaseViewModel;
        }

        public DatabaseViewModel DatabaseViewModel { get; set; }
        public ConsoleReader     ConsoleReader     { get; set; } = new();

        public void ShowMainMenu() {
            Console.WriteLine(@"Connected to DB...");
            var isWorking = true;
            var tableName = string.Empty;

            while (isWorking) {
                Console.Write(@"> ");

                var arguments = this.ConsoleReader.ReadString().Split(" ")
                                    .Select(word => word.ToFirstLetterUpperCase())
                                    .ToList();
                var command = arguments?.ElementAtOrDefault(0);

                switch (command) {
                    case nameof(ConsoleNoContextCommands.Back): case "B": {
                        if (tableName != string.Empty) {
                            Console.WriteLine($@"Exited from {tableName}...");
                            tableName = string.Empty;
                        }
                        else {
                            // TODO smth
                        }
                        continue;
                    }
                    case nameof(ConsoleNoContextCommands.Quit): case "Q": {
                        Console.WriteLine(@"Work has completed...");
                        isWorking = false;
                        continue;
                    }
                    case nameof(ConsoleNoContextCommands.Cls): case "C": {
                        Console.Clear();
                        continue;
                    }
                    case nameof(ConsoleNoContextCommands.Help): case "H": {
                        this.ShowHelp();
                        continue;
                    }
                    case nameof(ConsoleNoContextCommands.Online): case "O": {
                        // TODO show context table
                        continue;
                    }
                    case nameof(ConsoleNoContextCommands.Tables): case "T": {
                        this.ShowTableList();
                        continue;
                    }
                    case nameof(ConsoleNoContextCommands.Sql): case "S": {
                        // TODO sql mode
                        continue;
                    }
                    case nameof(ConsoleNoContextCommands.Go): case "G": {
                        tableName = this.GetGoTableName(arguments?.ElementAtOrDefault(1)?.ToFirstLetterUpperCase() ?? string.Empty, tableName);
                        continue;
                    }
                }

                if (tableName == string.Empty) {
                    Console.WriteLine($@"Command {command} doesn't exist!");
                }
                else {
                    switch (command) {
                        case nameof(ConsoleContextCommands.Show): case "S": {
                            this.DatabaseViewModel.ExecuteShow(tableName);
                            break;
                        }
                        case nameof(ConsoleContextCommands.Add): case "A": {
                            this.DatabaseViewModel.ExecuteAdd(tableName);
                            break;
                        }
                        case nameof(ConsoleContextCommands.Edit): case "E": {
                            this.DatabaseViewModel.ExecuteEdit(tableName);
                            break;
                        }
                        case nameof(ConsoleContextCommands.Remove): case "R": {
                            this.DatabaseViewModel.ExecuteRemove(tableName);
                            break;
                        }
                        //case nameof(ConsoleContextCommands.Duplicate): case "D": {
                        //    this.DatabaseViewModel.ExecuteCopy(tableName);
                        //    break;
                        //}
                        default: {
                            Console.WriteLine($@"Command {command} doesn't exist!");
                            break;
                        }
                    }
                }
            }
        }

        private void ShowHelp() {
            var link = @"#";
            Console.WriteLine("University Library Database application...");
            Console.WriteLine("Copyright (C) 2021 by Chupakabra, All Rights Reserved");
            Console.WriteLine();

            Console.WriteLine($"GitHub link: {link}");
            Console.WriteLine();

            Console.WriteLine("Usage:");
            Console.WriteLine($"{string.Empty, 2}<command>");
            Console.WriteLine();

            Console.WriteLine("Where:");
            Console.WriteLine($"{string.Empty, 2}<command>");

            Console.WriteLine($"{string.Empty, 4}Not contexted command:");
            Console.WriteLine($"{string.Empty, 6}help{string.Empty, 26}Display help");
            Console.WriteLine($"{string.Empty, 6}quit{string.Empty, 26}Exit from the application");
            Console.WriteLine($"{string.Empty, 6}cls{string.Empty, 27}Clean screen");
            Console.WriteLine($"{string.Empty, 6}tables [NOT-IMPLEMENTED]{string.Empty, 6}Display list of the tables in database");
            Console.WriteLine($"{string.Empty, 6}online [NOT-IMPLEMENTED]{string.Empty, 6}Display context table name");
            Console.WriteLine($"{string.Empty, 6}go <table-name>{string.Empty, 15}Make the table <table-name> the current command context");
            Console.WriteLine($"{string.Empty, 6}back{string.Empty, 26}Exit from context table");
            Console.WriteLine($"{string.Empty, 6}sql [NOT-IMPLEMENTED]{string.Empty, 9}Enable/disable sql mode where you can type MS SQL commands");
            Console.WriteLine();

            Console.WriteLine($"{string.Empty, 4}Contexted command:");
            Console.WriteLine($"{string.Empty, 6}show{string.Empty, 26}Display current context table");
            Console.WriteLine($"{string.Empty, 6}add{string.Empty, 27}Insert new item into the context table");
            Console.WriteLine($"{string.Empty, 6}edit{string.Empty, 26}Edit existing item in the context table by id");
            Console.WriteLine($"{string.Empty, 6}remove{string.Empty, 24}Remove existing item in the context table by id");
            Console.WriteLine($"{string.Empty, 6}duplicate [NOT-IMPLEMENTED]{string.Empty, 3}Copy existing item to the context table by id");
            Console.WriteLine();
        }

        private string GetGoTableName(string tableName, string defaultValue) {
            if (this.GetTableList().Contains(tableName)) {
                Console.WriteLine($@"Connected to {tableName}...");
                return tableName;
            }
            if (!string.IsNullOrEmpty(tableName)) {
                Console.WriteLine($@"Table {tableName} doesn't exist!");
            }

            return defaultValue;
        }

        private void ShowTableList() {
            Console.WriteLine(@"Table list:");
            this.GetTableList().ForEach(tableName => Console.Write($@"{tableName} "));
            Console.WriteLine();
        }

        private List<string> GetTableList() {
            //var list = this.DatabaseViewModel.UniversityLibrary.Database
            //               .SqlQuery<string>("select name from sys.tables")?.ToList();
            var list = typeof(UniversityLibrary).GetProperties()?.Select(info => info.Name.ToFirstLetterUpperCase()).ToList();
            list.Sort();

            return list;
        }
    }
}
