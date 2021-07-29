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
        private NodeDataStore _nodeStore = new NodeDataStore();
        private EmployeeDataStore _employeeStore = new EmployeeDataStore();
        public Form1()
        {
            InitializeComponent();

            tree.Init(treeView2);

            foreach(Control control in panel3.Controls)
            {
                control.Visible = false;
            }
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

                if (MessageBox.Show("Вы действительно хотите удалить этот узел?") == DialogResult.OK)
                {

                    var selectedNode = treeView2.SelectedNode;
                    treeView2.Nodes.Remove(selectedNode);

                    _nodeStore.RemoveItem(Convert.ToInt32(selectedNode.Tag));

                }
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

        private void treeView2_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {

                TreeNode treeNode = e.Node;
                if (SetConstantValues(treeNode) == true)
                    return;

                Node node = _nodeStore.GetItem(Convert.ToInt32(treeNode.Tag));
                SetConstantValues(node);
                Init(treeNode);
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
                    NodeId = Convert.ToInt32(currNode.Tag),
                    Surname = txtSurname.Text,
                    Name = txtName.Text,
                    Patronomyc = txtPatronomyc.Text,
                    DateOfAdoption = pickerAdoptionDate.Value
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
        private void Init(TreeNode node)
        {
            try
            {

                var item = _employeeStore.GetItem(node);
                if (item == null)
                {
                    txtSurname.Text = string.Empty;
                    txtName.Text = string.Empty;
                    txtPatronomyc.Text = string.Empty;
                    pickerAdoptionDate.Value = DateTime.Now;
                }
                else
                {

                    txtSurname.Text = item.Surname;
                    txtName.Text = item.Name;
                    txtPatronomyc.Text = item.Patronomyc;
                    pickerAdoptionDate.Value = item.DateOfAdoption;
                }
            }
            catch
            {

            }
        }

        #region Методы инициализации скрытия/открытия
        private bool SetConstantValues(TreeNode treeNode)
        {
            if (Convert.ToInt32(treeNode.Tag) == 0)
            {
                SetPanelVisible(panel4, false);
                return true;
            }
            SetPanelVisible(panel4, true);
            return false;
        }
        private void SetConstantValues(Node node)
        {
            if (node.Type == "Подразделение")
            {
                SetControlVisible(lblOpenAddForm, true);
                SetPanelVisible(panel3, false);
                return;
            }
            if (node.Type == "Должность")
            {
                SetControlVisible(lblOpenAddForm, false);
                SetPanelVisible(panel3, true);
            }
        }

        #endregion

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
