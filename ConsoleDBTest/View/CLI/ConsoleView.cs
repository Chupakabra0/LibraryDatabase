using System.Collections.Generic;
using System.Linq;
using ConsoleDBTest.DB;
using ConsoleDBTest.Reader;
using ConsoleDBTest.Utils.StringUtils;
using ConsoleDBTest.ViewModels.CLI;
using ConsoleDBTest.Writer;

namespace ConsoleDBTest.View {
    public class ConsoleView {
        public ConsoleView(DatabaseViewModel databaseViewModel) =>
            this.DatabaseViewModel = databaseViewModel;

        public DatabaseViewModel DatabaseViewModel { get; set; }

        public void ShowMainMenu() {
            this.ConsoleWriter.WriteSuccess(@"Connected to DB...");
            var isWorking = true;
            var tableName = string.Empty;

            while (isWorking) {
                this.ConsoleWriter.Write(@">");
                this.ConsoleWriter.WriteBlank();

                var arguments = this.ConsoleReader.ReadString().Split(" ")
                                    .Select(word => word.ToFirstLetterUpperCase())
                                    .ToList();
                var command = arguments?.ElementAtOrDefault(0);

                switch (command) {
                    case nameof(ConsoleNoContextCommands.Back): case "B": {
                        if (tableName != string.Empty) {
                            this.ConsoleWriter.WriteInfo($@"Exited from {tableName}...");
                            tableName = string.Empty;
                        }
                        continue;
                    }
                    case nameof(ConsoleNoContextCommands.Quit): case "Q": {
                        this.ConsoleWriter.WriteInfo(@"Work has completed...");
                        isWorking = false;
                        continue;
                    }
                    case nameof(ConsoleNoContextCommands.Cls): case "C": {
                        this.ConsoleWriter.Cls();
                        continue;
                    }
                    case nameof(ConsoleNoContextCommands.Help): case "H": {
                        this.ShowHelp();
                        continue;
                    }
                    case nameof(ConsoleNoContextCommands.Online): case "O": {
                        this.ShowContextTable(tableName);
                        continue;
                    }
                    case nameof(ConsoleNoContextCommands.Tables): case "T": {
                        this.ShowTableList();
                        continue;
                    }
                    case nameof(ConsoleNoContextCommands.Go): case "G": {
                        tableName = this.GetGoTableName(arguments?.ElementAtOrDefault(1)?.ToFirstLetterUpperCase() ?? string.Empty, tableName);
                        continue;
                    }
                }

                if (tableName == string.Empty) {
                    this.ConsoleWriter.WriteError($@"Command {command} doesn't exist at this context!");
                }
                else {
                    switch (command) {
                        case nameof(ConsoleContextCommands.Show): case "S": {
                            this.DatabaseViewModel.ExecuteShow(tableName);
                            break;
                        }
                        case nameof(ConsoleContextCommands.Add): case "A": {
                            if (this.DatabaseViewModel.ExecuteAdd(tableName)) {
                                this.ConsoleWriter.WriteSuccess($@"Item successfully added to {tableName}.");
                            }
                            else {
                                this.ConsoleWriter.WriteError($@"Adding to {tableName} was failed.");
                            }

                            break;
                        }
                        case nameof(ConsoleContextCommands.Edit): case "E": {
                            if (this.DatabaseViewModel.ExecuteEdit(tableName)) {
                                this.ConsoleWriter.WriteSuccess($@"Item successfully edited at {tableName}.");
                            }
                            else {
                                this.ConsoleWriter.WriteError($@"Editing at {tableName} was failed.");
                            }

                            break;
                        }
                        case nameof(ConsoleContextCommands.Remove): case "R": {
                            if (this.DatabaseViewModel.ExecuteRemove(tableName)) {
                                this.ConsoleWriter.WriteSuccess($@"Item successfully removed from {tableName}.");
                            }
                            else {
                                this.ConsoleWriter.WriteError($@"Removing from {tableName} was failed.");
                            }

                            break;
                        }
                        //case nameof(ConsoleContextCommands.Duplicate): case "D": {
                        //    this.DatabaseViewModel.ExecuteCopy(tableName);
                        //    break;
                        //}
                        default: {
                            this.ConsoleWriter.WriteError($@"Command {command} doesn't exist!");
                            break;
                        }
                    }
                }
            }
        }

        private void ShowHelp() {
            var link = @"https://github.com/Chupakabra0/LibraryDatabase";
            this.ConsoleWriter.WriteInfo("University Library Database application...");
            this.ConsoleWriter.WriteInfo("Copyright (C) 2021 by Chupakabra, All Rights Reserved");
            this.ConsoleWriter.WriteNewLine();

            this.ConsoleWriter.WriteInfo($"GitHub link: {link}");
            this.ConsoleWriter.WriteNewLine();

            this.ConsoleWriter.WriteInfo("Usage:");
            this.ConsoleWriter.WriteInfo($"{string.Empty, 2}<command>");
            this.ConsoleWriter.WriteNewLine();

            this.ConsoleWriter.WriteInfo("Where:");
            this.ConsoleWriter.WriteInfo($"{string.Empty, 2}<command>");

            this.ConsoleWriter.WriteInfo($"{string.Empty, 4}Not contexted command:");
            this.ConsoleWriter.WriteInfo($"{string.Empty, 6}help{string.Empty, 26}Display help");
            this.ConsoleWriter.WriteInfo($"{string.Empty, 6}quit{string.Empty, 26}Exit from the application");
            this.ConsoleWriter.WriteInfo($"{string.Empty, 6}cls{string.Empty, 27}Clean screen");
            this.ConsoleWriter.WriteInfo($"{string.Empty, 6}tables{string.Empty, 24}Display list of the tables in database");
            this.ConsoleWriter.WriteInfo($"{string.Empty, 6}online{string.Empty, 24}Display context table name");
            this.ConsoleWriter.WriteInfo($"{string.Empty, 6}go <table-name>{string.Empty, 15}Make the table <table-name> the current command context");
            this.ConsoleWriter.WriteInfo($"{string.Empty, 6}back{string.Empty, 26}Exit from context table");
            this.ConsoleWriter.WriteNewLine();

            this.ConsoleWriter.WriteInfo($"{string.Empty, 4}Contexted command:");
            this.ConsoleWriter.WriteInfo($"{string.Empty, 6}show{string.Empty, 26}Display current context table");
            this.ConsoleWriter.WriteInfo($"{string.Empty, 6}add{string.Empty, 27}Insert new item into the context table");
            this.ConsoleWriter.WriteInfo($"{string.Empty, 6}edit{string.Empty, 26}Edit existing item in the context table by id");
            this.ConsoleWriter.WriteInfo($"{string.Empty, 6}remove{string.Empty, 24}Remove existing item in the context table by id");
            this.ConsoleWriter.WriteInfo($"{string.Empty, 6}duplicate [NOT-IMPLEMENTED]{string.Empty, 3}Copy existing item to the context table by id");
            this.ConsoleWriter.WriteNewLine();
        }

        private string GetGoTableName(string tableName, string defaultValue) {
            if (this.GetTableList().Contains(tableName)) {
                this.ConsoleWriter.WriteSuccess($@"Connected to {tableName}...");
                return tableName;
            }
            if (!string.IsNullOrEmpty(tableName)) {
                this.ConsoleWriter.WriteError($@"Table {tableName} doesn't exist!");
            }

            return defaultValue;
        }

        private void ShowTableList() {
            this.ConsoleWriter.WriteInfo(@"Table list:");
            this.GetTableList().ForEach(tableName => this.ConsoleWriter.WriteInfo(tableName));
            this.ConsoleWriter.WriteNewLine();
        }

        private void ShowContextTable(string tableName) {
            if (string.IsNullOrEmpty(tableName)) {
                this.ConsoleWriter.WriteError($@"There's no context table yet!");
            }
            else {
                this.ConsoleWriter.WriteInfo($@"Context table is {tableName}.");
            }
        }

        private List<string> GetTableList() {
            var list = typeof(UniversityLibrary).GetProperties()?.Select(info => info.Name.ToFirstLetterUpperCase()).ToList();
            list.Sort();

            return list;
        }

        private ConsoleReader ConsoleReader { get; } = new();
        private ConsoleWriter ConsoleWriter { get; } = new();
    }
}
