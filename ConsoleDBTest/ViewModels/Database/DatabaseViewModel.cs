using System.Data.Entity;
using ConsoleDBTest.DB;
using ConsoleDBTest.ModelController;

namespace ConsoleDBTest.ViewModels.CLI {
    public class DatabaseViewModel {
        public DatabaseViewModel(UniversityLibrary universityLibrary) {
            this.UniversityLibrary = universityLibrary;
        }

        public bool ExecuteShow(string tableName) => 
            this.GetController(tableName)?.Show(this.UniversityLibrary) ?? false;

        public bool ExecuteAdd(string tableName) =>
            this.GetController(tableName)?.Add(this.UniversityLibrary) ?? false;

        public bool ExecuteRemove(string tableName) =>
            this.GetController(tableName)?.Remove(this.UniversityLibrary) ?? false;

        public bool ExecuteEdit(string tableName) => 
            this.GetController(tableName)?.Edit(this.UniversityLibrary) ?? false;
        
        private ConsoleController GetController(string tableName) =>
            tableName.ToLower() switch {
                "countries"                       => new CountryController(),
                "genres"                          => new GenreController(),
                "authors"                         => new AuthorController(),
                "specialties"                     => new SpecialtyController(),
                "cathedras"                       => new CathedraController(),
                "faculties"                       => new FacultyController(),
                "degrees"                         => new DegreeController(),
                "workers"                         => new WorkerController(),
                "cities"                          => new CityController(),
                "facultyandspecialties"           => new FacultyAndSpecialtyController(),
                "facultyandspecialtyandcathedras" => new FacultyAndSpecialtyAndCathedraController(),
                "teachers"                        => new TeacherController(),
                "groups"                          => new GroupController(),
                "students"                        => new StudentController(),
                "clientcards"                     => new ClientCardController(),
                "publishers"                      => new PublisherController(),
                "books"                           => new BookController(),
                "librarytransactions"             => new LibraryTransactionController(),
                _                                 => null
            };
        
        public UniversityLibrary UniversityLibrary { get; set; }
    }
}
