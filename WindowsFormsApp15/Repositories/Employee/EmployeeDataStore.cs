using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp15.Data;
using WindowsFormsApp15.Models;

namespace WindowsFormsApp15.Repositories
{
    class EmployeeDataStore : IDataStore<Employee>
    {
        private DataContext _dc;
        private Table<Employee> _employees;
        public EmployeeDataStore()
        {
            _dc = new DataContext(Connect.ConnectionString);
            _employees = _dc.GetTable<Employee>();

        }
        public bool AddItem(Employee item)
        {
            if (item == null)
                return false;
            
            _employees.InsertOnSubmit(item);
            _dc.SubmitChanges();
            return true;
        }
        public Employee GetItem(int id)
        {
            return _employees.Single(x => x.Id == id);
        }
        public Employee GetItem(TreeNode node)
        {
            return _employees.SingleOrDefault(x => x.NodeId == Convert.ToInt32(node.Tag));
        }
        public Employee GetItem(Employee employee)
        {
            return _employees.SingleOrDefault(x => x.Surname == employee.Surname && 
                                          x.Name == employee.Name &&
                                          x.Patronomyc == employee.Patronomyc &&
                                          x.DateOfAdoption == employee.DateOfAdoption &&
                                          x.NodeId == employee.NodeId);
        }
        public IEnumerable<Employee> GetItems()
        {
            return _employees.ToList();
        }
        
        public bool RemoveItem(int id)
        {
            var item = GetItem(id);
            if (item == null)
                return false;
            
            _employees.DeleteOnSubmit(item);
            _dc.SubmitChanges();
            return true;
        }

        public bool UpdateItem(Employee item)
        {
            var newItem = GetItem(item.Id);
            if (newItem == null)
                return false;
            
            newItem.Surname = item.Surname;
            newItem.Name = item.Name;
            newItem.Patronomyc = item.Patronomyc;
            newItem.DateOfAdoption = item.DateOfAdoption;
            newItem.NodeId = item.NodeId;
            _dc.SubmitChanges();
            return true;
        }
    }
}
