using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp15.Repositories
{
    interface IDataStore<T>
    {
        bool AddItem(T item);
        bool RemoveItem(int id);
        bool UpdateItem(T item);
        T GetItem(int id);
        IEnumerable<T> GetItems();
    }
}
