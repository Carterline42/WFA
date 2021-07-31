using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp15.Data;
using WindowsFormsApp15.Models;

namespace WindowsFormsApp15.Repositories
{
    class NodeTypeDataStore : IDataStore<NodeType>
    {
        private DataContext _dc;
        private Table<NodeType> _nodes;
        public NodeTypeDataStore()
        {
            _dc = new DataContext(Connect.ConnectionString);
            _nodes = _dc.GetTable<NodeType>();

        }
        public bool AddItem(NodeType item)
        {
            if (item == null)
                return false;

            _nodes.InsertOnSubmit(item);
            _dc.SubmitChanges();

            return true;
        }

        public NodeType GetItem(int id)
        {
            return _nodes.Single(x => x.Id == id);
        }
        public NodeType GetItem(string type)
        {
            return _nodes.Single(x => x.Type == type);
        }
        public IEnumerable<NodeType> GetItems()
        {
            var dc = new DataContext(Connect.ConnectionString);
            var table = dc.GetTable<NodeType>();

            return table.ToList();
        }

        public bool RemoveItem(int id)
        {
            var item = GetItem(id);
            if (item == null)
                return false;

            _nodes.DeleteOnSubmit(item);
            _dc.SubmitChanges();

            return true;
        }

        public bool UpdateItem(NodeType item)
        {
            var node = GetItem(item.Id);

            if (node == null)
                return false;

            node.Type = item.Type;
            _dc.SubmitChanges();

            return true;
        }
    }
}
