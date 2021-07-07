using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using ConsoleDBTest.DB;
using ConsoleDBTest.ModelController;
using ConsoleDBTest.Utils.StringUtils;

namespace ConsoleDBTest.ViewModels.CLI
{
    public class DatabaseViewModel
    {
        public DatabaseViewModel(UniversityLibrary universityLibrary) =>
            this.UniversityLibrary = universityLibrary;

        public bool ExecuteShow(string tableName) =>
            this.GetController(tableName)?.Show(this.UniversityLibrary) ?? false;

        public bool ExecuteAdd(string tableName) =>
            this.GetController(tableName)?.Add(this.UniversityLibrary) ?? false;

        public bool ExecuteRemove(string tableName) =>
            this.GetController(tableName)?.Remove(this.UniversityLibrary) ?? false;

        public bool ExecuteEdit(string tableName) =>
            this.GetController(tableName)?.Edit(this.UniversityLibrary) ?? false;

        public ConsoleController GetController(string tableName) {
            this.Controllers.TryGetValue(tableName, out var controller);
            return controller;
        }

        public UniversityLibrary UniversityLibrary { get; set; }

        public Dictionary<string, ConsoleController> Controllers { get; } = new() {
            { nameof(DatabaseViewModel.UniversityLibrary.Countries).ToFirstLetterUpperCase(), new CountryController() },
            { nameof(DatabaseViewModel.UniversityLibrary.Genres).ToFirstLetterUpperCase(), new GenreController() },
            { nameof(DatabaseViewModel.UniversityLibrary.Authors).ToFirstLetterUpperCase(), new AuthorController() },
            { nameof(DatabaseViewModel.UniversityLibrary.Specialties).ToFirstLetterUpperCase(), new SpecialtyController() },
            { nameof(DatabaseViewModel.UniversityLibrary.Cathedras).ToFirstLetterUpperCase(), new CathedraController() },
            { nameof(DatabaseViewModel.UniversityLibrary.Faculties).ToFirstLetterUpperCase(), new FacultyController() },
            { nameof(DatabaseViewModel.UniversityLibrary.Degrees).ToFirstLetterUpperCase(), new DegreeController() },
            { nameof(DatabaseViewModel.UniversityLibrary.Workers).ToFirstLetterUpperCase(), new WorkerController() },
            { nameof(DatabaseViewModel.UniversityLibrary.Cities).ToFirstLetterUpperCase(), new CityController() },
            { nameof(DatabaseViewModel.UniversityLibrary.FacultyAndSpecialties).ToFirstLetterUpperCase(), new FacultyAndSpecialtyController() },
            { nameof(DatabaseViewModel.UniversityLibrary.FacultyAndSpecialtyAndCathedras).ToFirstLetterUpperCase(), new FacultyAndSpecialtyAndCathedraController() },
            { nameof(DatabaseViewModel.UniversityLibrary.Teachers).ToFirstLetterUpperCase(), new TeacherController() },
            { nameof(DatabaseViewModel.UniversityLibrary.Groups).ToFirstLetterUpperCase(), new GroupController() },
            { nameof(DatabaseViewModel.UniversityLibrary.Students).ToFirstLetterUpperCase(), new StudentController() },
            { nameof(DatabaseViewModel.UniversityLibrary.ClientCards).ToFirstLetterUpperCase(), new ClientCardController() },
            { nameof(DatabaseViewModel.UniversityLibrary.Publishers).ToFirstLetterUpperCase(), new PublisherController() },
            { nameof(DatabaseViewModel.UniversityLibrary.Books).ToFirstLetterUpperCase(), new BookController() },
            { nameof(DatabaseViewModel.UniversityLibrary.LibraryTransactions).ToFirstLetterUpperCase(), new LibraryTransactionController() }
        };
    }
}
