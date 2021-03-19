using ConsoleDBTest.DB;
using ConsoleDBTest.Models;

namespace ConsoleDBTest {
    internal static class Program {

        internal static void Main(string[] args) {
            using var dbContext = new DatabaseContext();

            //var country = new Country() {
            //    LongName = "Российская Федерация",
            //    ShortName = "Россия",
            //    ISOCode = "RU",
            //    IsActive = true
            //};

            //dbContext.Countries.Add(country);
            dbContext.Database
                     .ExecuteSqlCommand("insert into Countries values (N'Канада', N'Канада', 'CA', '1')");
            dbContext.SaveChanges();
        }

    }
}
