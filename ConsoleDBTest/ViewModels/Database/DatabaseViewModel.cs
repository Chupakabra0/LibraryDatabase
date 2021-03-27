using System.Globalization;
using ConsoleDBTest.DB;
using ConsoleDBTest.ModelController;

namespace ConsoleDBTest.ViewModels.CLI {
    public class DatabaseViewModel {
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

        public ConsoleController GetController(string tableName) =>
            CultureInfo.CurrentCulture.TextInfo.ToTitleCase(tableName) switch {
                nameof(this.UniversityLibrary.Countries)                       => new CountryController(),
                nameof(this.UniversityLibrary.Genres)                          => new GenreController(),
                nameof(this.UniversityLibrary.Authors)                         => new AuthorController(),
                nameof(this.UniversityLibrary.Specialties)                     => new SpecialtyController(),
                nameof(this.UniversityLibrary.Cathedras)                       => new CathedraController(),
                nameof(this.UniversityLibrary.Faculties)                       => new FacultyController(),
                nameof(this.UniversityLibrary.Degrees)                         => new DegreeController(),
                nameof(this.UniversityLibrary.Workers)                         => new WorkerController(),
                nameof(this.UniversityLibrary.Cities)                          => new CityController(),
                nameof(this.UniversityLibrary.FacultyAndSpecialties)           => new FacultyAndSpecialtyController(),
                nameof(this.UniversityLibrary.FacultyAndSpecialtyAndCathedras) => new FacultyAndSpecialtyAndCathedraController(),
                nameof(this.UniversityLibrary.Teachers)                        => new TeacherController(),
                nameof(this.UniversityLibrary.Groups)                          => new GroupController(),
                nameof(this.UniversityLibrary.Students)                        => new StudentController(),
                nameof(this.UniversityLibrary.ClientCards)                     => new ClientCardController(),
                nameof(this.UniversityLibrary.Publishers)                      => new PublisherController(),
                nameof(this.UniversityLibrary.Books)                           => new BookController(),
                nameof(this.UniversityLibrary.LibraryTransactions)             => new LibraryTransactionController(),
                _                                                              => null
            };

        public UniversityLibrary UniversityLibrary { get; set; }
    }
}
