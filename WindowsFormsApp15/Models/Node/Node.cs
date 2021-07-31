using System;
using System.ComponentModel;
using System.Data.Linq.Mapping;

namespace WindowsFormsApp15.Models
{
    [Table(Name = "Nodes")]
    class Node
    {
        [Column(IsDbGenerated = true, IsPrimaryKey = true)]
        public int Id { get; set; }

        [Column]
        public string Title { get; set; }

        [Column]
        public int Type { get; set; }

        [Column]
        public int? ParentId { get; set; }

    }
}
