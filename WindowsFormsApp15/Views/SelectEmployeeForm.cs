using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp15.Models;
using WindowsFormsApp15.Repositories;

namespace WindowsFormsApp15.Views
{
    public partial class SelectEmployeeForm : Form
    {
        private EmployeeDataStore _employeeStore;
        private NodeDataStore _nodeStore;
        private TreeNode _node;
        private Employee _employee;
        public SelectEmployeeForm(TreeNode node, Employee employee)
        {
            InitializeComponent();
            _node = node;
            _employee = employee;
            Init();
        }

        private void Init()
        {
            _employeeStore = new EmployeeDataStore();
            _nodeStore = new NodeDataStore();

            dataGridView1.DataSource = _employeeStore.GetItems().Select(x => new
            {
                Id = x.Id,
                Surname = x.Surname,
                Name = x.Name,
                Patronomyc = x.Patronomyc
            }).ToList();


            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Фамилия";
            dataGridView1.Columns[2].HeaderText = "Имя";
            dataGridView1.Columns[3].HeaderText = "Отчество";
        }
        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtSurname.Text) && string.IsNullOrWhiteSpace(txtName.Text) && string.IsNullOrWhiteSpace(txtPatronomyc.Text))
            {
                dataGridView1.DataSource = _employeeStore.GetItems().Select(x => new
                {
                    Surname = x.Surname,
                    Name = x.Name,
                    Patronomyc = x.Patronomyc
                }).ToList();
                return;
            }


            dataGridView1.DataSource = _employeeStore.GetItems().Where(x => x.Surname == txtSurname.Text ||
                                                                       x.Name == txtName.Text ||
                                                                       x.Patronomyc == txtPatronomyc.Text)
                                                                .Select(x => new
                                                                {
                                                                    Surname = x.Surname,
                                                                    Name = x.Name,
                                                                    Patronomyc = x.Patronomyc
                                                                }).ToList(); ;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Employee employee = new Employee();
            try
            {
                int selectedEmployeeId = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["Id"].Value);
                employee = _employeeStore.GetItem(selectedEmployeeId);
                if (_employee != null)
                {
                    _employee.NodeId = -1;
                    _employeeStore.UpdateItem(_employee);
                }

                employee.NodeId = Convert.ToInt32(_node.Tag);
                _employeeStore.UpdateItem(employee);
            }
            catch (Exception ex)
            {
                employee.NodeId = -1;
                _employeeStore.UpdateItem(employee);

                Debug.WriteLine(ex.Message);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
