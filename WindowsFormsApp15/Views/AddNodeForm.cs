using System;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp15.Models;
using WindowsFormsApp15.Repositories;

namespace WindowsFormsApp15.Views
{
    public partial class AddNodeForm : Form
    {
        #region fields
        private TreeNode _node;
        private NodeDataStore _store;
        private NodeTypeDataStore _typeStore;

        #endregion
        public AddNodeForm(TreeNode node)
        {
            InitializeComponent();
            _node = node;
            Init();
        }
        private void Init()
        {
            _store = new NodeDataStore();
            _typeStore = new NodeTypeDataStore();
            comboBox1.DataSource = _typeStore.GetItems();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedItem == null || string.IsNullOrWhiteSpace(textBox1.Text))
                    throw new ArgumentNullException();


                string selectedType = comboBox1.SelectedItem.ToString();
                NodeType nodeType = _typeStore.GetItem(selectedType);

                Node node = new Node
                {
                    Title = textBox1.Text,
                    Type = nodeType.Id,
                    ParentId = Convert.ToInt32(_node.Tag)
                };
                _store.AddItem(node);

                Node nodeWithId = _store.GetItems().Last();
                AddNode(nodeWithId);
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Заполните все поля.");
            }
            catch { }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddNode(Node node)
        {
            TreeNode childNode = new TreeNode { Text = node.Title, Tag = Convert.ToInt32(node.Id), };
            _node.Nodes.Add(childNode);
        }

    }
}
