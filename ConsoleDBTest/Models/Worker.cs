using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ConsoleDBTest.ViewModels;

namespace ConsoleDBTest.Models {
    public class Worker {
        [Key]
        public int Id { get; set; }

        public string Name       { get; set; }
        public string Surname    { get; set; }
        public string Patronymic { get; set; }
        public bool   IsActive   { get; set; }

        public virtual ICollection<LibraryTransaction> Libraries { get; set; }

        public WorkerViewModel ToViewModel() => new(this);
    }
}
