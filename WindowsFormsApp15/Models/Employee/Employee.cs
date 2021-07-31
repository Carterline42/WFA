using System;
using System.Data.Linq.Mapping;

namespace WindowsFormsApp15.Models
{
    [Table(Name = "Employees")]
    public class Employee
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        public int Id { get; set; }

        [Column]
        public string Surname { get; set; }

        [Column]
        public string Name { get; set; }

        [Column]
        public string Patronomyc { get; set; }

        [Column]
        public DateTime DateOfAdoption { get; set; }

        [Column]
        public int NodeId { get; set; }
    }
}
