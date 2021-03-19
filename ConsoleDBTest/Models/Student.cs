using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsoleDBTest.Models {
    public class Student {
        [Key]
        public int Id { get; set; }

        public string Name       { get; set; }
        public string Surname    { get; set; }
        public string Patronymic { get; set; }
        public bool   IsActive   { get; set; }

        public int CityId  { get; set; }
        public int GroupId { get; set; }

        public virtual ICollection<ClientCard> ClientCards { get; set; }
    }
}