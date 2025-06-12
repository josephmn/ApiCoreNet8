using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiCoreNet8.Models
{
    public class Person
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("document")]
        public string Document { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("last_name")]
        public string LastName { get; set; }
        [Column("age")]
        public int Age { get; set; }
        [Column("date_birthday")]
        public DateTime DateBirthday { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("status")]
        public int Status { get; set; }
    }
}
