using System;
using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp15.Data;

namespace WindowsFormsApp15.Models
{
    class Tree
    {
        private DataContext dc = new DataContext(Connect.ConnectionString);
        public void Init(TreeView tree)
        {
            CreateNodes(tree.Nodes[0]);
        }
        public void CreateNodes(TreeNode node)
        {
            var nodes = dc.GetTable<Node>().Where(x => x.ParentId == Convert.ToInt32(node.Tag)).ToList();

            foreach (var item in nodes)
            {
                TreeNode treeNode = new TreeNode { Text = item.Title, Tag = item.Id };
                node.Nodes.Add(treeNode);
                CreateNodes(treeNode);
            }

        }
    }
}
