using System;
using System.Globalization;
using ConsoleDBTest.DB;
using ConsoleDBTest.Reader;
using ConsoleDBTest.View;
using ConsoleDBTest.ViewModels.CLI;

namespace ConsoleDBTest {
    internal static class Program {
        internal static void Main(string[] args) {
            new ConsoleView(new DatabaseViewModel(new DatabaseContext(), new ConsoleReader())).Show();
        }
    }
}
