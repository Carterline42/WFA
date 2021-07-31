using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp15.Data;

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
