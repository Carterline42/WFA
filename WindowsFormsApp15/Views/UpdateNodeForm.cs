using System;
using System.Windows.Forms;
using WindowsFormsApp15.Repositories;

namespace WindowsFormsApp15.Views
{
    public partial class UpdateNodeForm : Form
    {
        private TreeNode _node;
        private NodeDataStore _store = new NodeDataStore();
        public UpdateNodeForm(TreeNode node)
        {
            InitializeComponent();
            _node = node;
            Init();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                var item = _store.GetItem(Convert.ToInt32(_node.Tag));
                if (item == null || string.IsNullOrWhiteSpace(txtNewTitle.Text))
                    throw new ArgumentNullException();

                item.Title = txtNewTitle.Text;
                _store.UpdateItem(item);
                UpdateNodeTitle();
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Заполните все поля");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Неизестная ошибка {ex.HResult}", $"{ex.Message}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Init()
        {
            txtOldTitle.Text = _node.Text;
        }
        private void UpdateNodeTitle()
        {
            _node.Text = txtNewTitle.Text;
        }
    }
}
