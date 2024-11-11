using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab8
{
    public partial class Form1 : Form
    {
        private readonly RegistryKey[] _registryKeys = new RegistryKey[] { Registry.ClassesRoot, Registry.CurrentUser, Registry.Users, Registry.LocalMachine, Registry.CurrentConfig };

        public Form1()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.Form1_Load);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadRegistryTree();
        }

        private void LoadRegistryTree()
        {
            foreach (var key in _registryKeys)
            {
                AddRegistryKeyToTreeView(key, treeView1.Nodes);
            }

            // Expand the first node to show the initial registry keys
            if (treeView1.Nodes.Count > 0)
            {
                treeView1.SelectedNode = treeView1.Nodes[0];
                treeView1.Nodes[0].Expand();
                DisplayRegistryKeyValues((RegistryKey)treeView1.SelectedNode.Tag);
            }
        }

        private void AddRegistryKeyToTreeView(RegistryKey key, TreeNodeCollection nodes)
        {
            if (key != null)
            {
                TreeNode node = nodes.Add(key.Name);
                node.Tag = key;

                try
                {
                    string[] subKeyNames = key.GetSubKeyNames();
                    foreach (string subKeyName in subKeyNames)
                    {
                        using (RegistryKey subKey = key.OpenSubKey(subKeyName))
                        {
                            AddRegistryKeyToTreeView(subKey, node.Nodes);
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode selectedNode = treeView1.SelectedNode;
            if (selectedNode != null)
            {
                RegistryKey selectedKey = (RegistryKey)selectedNode.Tag;
                listView1.Items.Clear();

                if (selectedKey != null)
                {
                    string[] valueNames = selectedKey.GetValueNames();
                    foreach (string valueName in valueNames)
                    {
                        object value = selectedKey.GetValue(valueName);
                        string type = selectedKey.GetValueKind(valueName).ToString();

                        ListViewItem item = new ListViewItem(new[] { valueName, type, value.ToString() });
                        listView1.Items.Add(item);
                    }
                }
            }
        }

        private void DisplayRegistryKeyValues(RegistryKey key)
        {
            
        }
    }
}