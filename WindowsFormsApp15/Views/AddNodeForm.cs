using System;
using System.Collections.Generic;
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
        private Tree _tree;
        #endregion
        public AddNodeForm(TreeNode node)
        {
            InitializeComponent();
            _node = node;
          
            Init();
        }
        private void Init()
        {
            comboBox1.Items.Add("Подразделение");
            comboBox1.Items.Add("Должность");

            _store = new NodeDataStore();
            _tree = new Tree();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedItem == null || string.IsNullOrWhiteSpace(textBox1.Text))
                    throw new ArgumentNullException();

                Node node = new Node
                {
                    Title = textBox1.Text,
                    Type = comboBox1.SelectedItem.ToString(),
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
