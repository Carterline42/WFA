using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Threading.Tasks;
using WindowsFormsApp15.Data;
using WindowsFormsApp15.Models;

namespace WindowsFormsApp15.Repositories
{
    class NodeDataStore : IDataStore<Node>
    {
        private DataContext _dc;
        private Table<Node> _nodes;
        public NodeDataStore()
        {
            _dc = new DataContext(Connect.ConnectionString);
            _nodes = _dc.GetTable<Node>();

        }
        public bool AddItem(Node item)
        {
            if (item == null)
                return false;

            _nodes.InsertOnSubmit(item);
            _dc.SubmitChanges();

            return true;
        }

        public Node GetItem(int id)
        {
            return _nodes.Single(x => x.Id == id);
        }
        public IEnumerable<Node> GetItems()
        {
            return _nodes.ToList();
        }

        public bool RemoveItem(int id)
        {
            var item = GetItem(id);
            if (item == null)
                return false;

            _nodes.DeleteOnSubmit(item);
            _dc.SubmitChanges();
            RemoveEmptyReference(id);
            return true;
        }

        public bool UpdateItem(Node item)
        {
            var node = GetItem(item.Id);

            if (node == null)
                return false;


            node.Title = item.Title;
            node.Type = item.Type;
            node.ParentId = item.ParentId;
            _dc.SubmitChanges();

            return true;
        }


        /// <summary>
        /// Вызывается при удалении узла. Проверяет таблицу Nodes на наличие узлов, 
        /// которые ни на что не ссылаются, а затем удаляются.
        /// </summary>
        /// <param name="id"></param>

        private void RemoveEmptyReference(int id)
        {
            DataContext dc = new DataContext(Connect.ConnectionString);
            var table = dc.GetTable<Node>();

            foreach (var item in GetItems().Where(x => x.ParentId == id))
            {
                RemoveItem(item.Id);
                RemoveEmptyReference(item.Id);
            }
        }
    }
}
