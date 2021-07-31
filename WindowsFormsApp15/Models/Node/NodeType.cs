using System.Data.Linq.Mapping;

namespace WindowsFormsApp15.Models
{
    [Table]
    class NodeType
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        public int Id { get; set; }

        [Column]
        public string Type { get; set; }

        public override string ToString()
        {
            return Type;
        }
    }
}
