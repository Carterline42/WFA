using System;
using System.Windows.Forms;
using WindowsFormsApp15.Models;
using WindowsFormsApp15.Repositories;
using WindowsFormsApp15.Views;

namespace WindowsFormsApp15
{
    public partial class Form1 : Form
    {

        private Tree tree = new Tree();
        private NodeDataStore _nodeStore;
        private EmployeeDataStore _employeeStore;
        private NodeTypeDataStore _typeStore;
        public Form1()
        {
            InitializeComponent();

            Init();
            tree.Init(treeView2);

            treeView2.SelectedNode = treeView2.Nodes[0];
            SetControlVisible(lblOpenAddForm, true);
            SetPanelVisible(employeePanel, false);
            SetPanelVisible(nodePanel, false);
        }
        private void Init()
        {
            _nodeStore = new NodeDataStore();
            _employeeStore = new EmployeeDataStore();
            _typeStore = new NodeTypeDataStore();
        }
        private void lblOpenAddForm_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView2.SelectedNode == null)
                    throw new ArgumentException();
                AddNodeForm form = new AddNodeForm(treeView2.SelectedNode);
                form.Show();
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Выделите необходимый узел дерева.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Неизестная ошибка {ex.HResult}", $"{ex.Message}");
            }
        }
        private void lblRemoveNode_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView2.SelectedNode == null)
                    throw new ArgumentNullException();


                var result = MessageBox.Show("Вы действительно хотите удалить этот узел?");

                if (result == DialogResult.OK)
                {

                    var selectedNode = treeView2.SelectedNode;
                    treeView2.Nodes.Remove(selectedNode);

                    _nodeStore.RemoveItem(Convert.ToInt32(selectedNode.Tag));

                }
                else if (result == DialogResult.Cancel)
                    return;
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Выделите необходимый узел дерева.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Неизестная ошибка {ex.HResult}", $"{ex.Message}");
            }
        }

        private void lblOpenUpdateForm_Click(object sender, EventArgs e)
        {
            try
            {
                if (treeView2.SelectedNode == null)
                    throw new ArgumentException();

                var selectedNode = treeView2.SelectedNode;
                UpdateNodeForm form = new UpdateNodeForm(selectedNode);
                form.Show();
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Выделите необходимый узел дерева.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Неизестная ошибка {ex.HResult}", $"{ex.Message}");
            }
        }

        private void SetDefaultValues(DateTime date, string surname = "", string name = "", string patronomyc = "")
        {
            txtSurname.Text = surname;
            txtName.Text = surname;
            txtPatronomyc.Text = surname;
            pickerAdoptionDate.Value = DateTime.Now;
        }


        /// <summary>
        /// Скрывает элементы управления в зависимости от выбранного узла (проверяется по типу узла)
        /// Если тип узла является "Подразделение", то доступно добавиление, удаление, редактирование узла
        /// Если тип узла является "Должность", то будет доступно только удаление и редактирование
        /// </summary>
        private void treeView2_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                var currentTreeNode = e.Node;
                if (currentTreeNode.Name == "readonlyCoreNode")
                {

                    SetControlVisible(lblOpenAddForm, true);
                    SetPanelVisible(nodePanel, false);
                    SetPanelVisible(employeePanel, false);
                    return;
                }

                var node = _nodeStore.GetItem(Convert.ToInt32(currentTreeNode.Tag));

                if (node != null)
                {
                    SetDefaultValues(DateTime.Now);

                    if (node.Type == _typeStore.GetItem("Должность").Id)
                    {
                        SetControlVisible(lblOpenAddForm, false);
                        SetPanelVisible(nodePanel, true);
                        SetPanelVisible(employeePanel, true);

                        var employee = _employeeStore.GetItem(currentTreeNode);
                        if (employee != null)
                            SetDefaultValues(employee.DateOfAdoption, employee.Surname, employee.Name, employee.Patronomyc);

                        return;
                    }
                    else if (node.Type == _typeStore.GetItem("Подразделение").Id)
                    {
                        SetControlVisible(lblOpenAddForm, true);
                        SetPanelVisible(nodePanel, true);
                        SetPanelVisible(employeePanel, false);
                        return;
                    }
                }
            }
            catch { }
        }

        /// <summary>
        /// При добавлении сначала идет проверка на существования объекта Employee в БД,
        /// если такой работник уже существует, то его поля в базе данных будут обновлены. 
        /// Если же объект отсутствует в базе данных, то он будет добавлен.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtSurname.Text) || string.IsNullOrWhiteSpace(txtName.Text))
                    throw new Exception();


                var currNode = treeView2.SelectedNode;

                Employee employee = new Employee
                {
                    Surname = txtSurname.Text,
                    Name = txtName.Text,
                    Patronomyc = txtPatronomyc.Text,
                    DateOfAdoption = pickerAdoptionDate.Value,
                    NodeId = Convert.ToInt32(currNode.Tag)
                };

                if (_employeeStore.GetItem(currNode) != null)
                {
                    var item = _employeeStore.GetItem(currNode);
                    employee.Id = item.Id;
                    _employeeStore.UpdateItem(employee);
                    return;
                }

                _employeeStore.AddItem(employee);
            }
            catch
            {
                MessageBox.Show("Введенные вами данные некорренты.");
            }

        }

        //Очистка узла с типом "Должность" (удаляет работника из таблицы Employees)
        private void button2_Click(object sender, EventArgs e)
        {
            var currNode = treeView2.SelectedNode;

            var dbItem = _employeeStore.GetItem(currNode);

            if (dbItem != null)
            {
                _employeeStore.RemoveItem(dbItem.Id);
                SetDefaultValues(DateTime.Now);
            }
        }
        #region Методы реализующие скрытие/открытие элементов управления

        private void SetPanelVisible(Panel panel, bool visible)
        {
            foreach (Control control in panel.Controls)
            {
                SetControlVisible(control, visible);
            }
        }
        private void SetControlVisible(Control control, bool visible)
        {
            control.Visible = visible;
        }
        #endregion

    }
}
