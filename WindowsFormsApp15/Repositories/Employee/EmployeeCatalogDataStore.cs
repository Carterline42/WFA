using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using WindowsFormsApp15.Data;
using WindowsFormsApp15.Models;

namespace WindowsFormsApp15.Repositories
{
    class EmployeeCatalogDataStore : IDataStore<EmployeeCatalog>
    {

        private DataContext _dc;
        private Table<EmployeeCatalog> _catalog;

        public EmployeeCatalogDataStore()
        {
            _dc = new DataContext(Connect.ConnectionString);
            _catalog = _dc.GetTable<EmployeeCatalog>();
        }
        public bool AddItem(EmployeeCatalog item)
        {
            if (item == null)
                return false;

            _catalog.InsertOnSubmit(item);
            _dc.SubmitChanges();

            return true;

        }

        public EmployeeCatalog GetItem(int id)
        {
            return _catalog.Single(x => x.Id == id);
        }

        public IEnumerable<EmployeeCatalog> GetItems()
        {
            return _catalog.ToList();
        }

        public bool RemoveItem(int id)
        {
            var item = GetItem(id);
            if (item == null)
                return false;

            _catalog.DeleteOnSubmit(item);
            _dc.SubmitChanges();

            return true;
        }

        public bool UpdateItem(EmployeeCatalog item)
        {
            throw new NotImplementedException();
        }
    }
}
