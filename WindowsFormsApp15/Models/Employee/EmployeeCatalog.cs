using System.Data.Linq.Mapping;

namespace WindowsFormsApp15.Models
{
    [Table]
    class EmployeeCatalog
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        public int Id { get; set; }

        [Column]
        public int EmployeeId { get; set; }
    }
}
