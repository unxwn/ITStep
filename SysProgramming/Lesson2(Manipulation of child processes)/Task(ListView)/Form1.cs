using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_ListView_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            listView1.View = View.Details;
            listView1.Columns.Add("process_id", 75);
            listView1.Columns.Add("process_name", 225);
            listView1.FullRowSelect = true;

            listView2.View = View.Details;
            listView2.Columns.Add("thread_id", 75);
            listView2.Columns.Add("thread_priorityLvl", 100);
            listView2.Columns.Add("thread_startTime", 125);
            listView2.FullRowSelect = true;

            listView3.View = View.Details;
            listView3.Columns.Add("module_name", 300);;
            listView3.FullRowSelect = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            Process[] processes = Process.GetProcesses();

            foreach (Process process in processes)
            {
                ListViewItem listViewItem = new ListViewItem(process.Id.ToString());
                listViewItem.SubItems.Add(process.ProcessName);
                listView1.Items.Add(listViewItem);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listView2.Items.Clear();
            listView3.Items.Clear();

            if (listView1.SelectedItems.Count > 0)
            {
                int id = int.Parse(listView1.SelectedItems[0].Text);
                Process process = Process.GetProcessById(id);

                label1.ForeColor = Color.Black;
                label1.Text = $"Info about threads of {process.ProcessName}";
                label2.ForeColor = Color.Black;
                label2.Text = $"Info about modules of {process.ProcessName}";

                //MessageBox.Show($"This process has {process.Threads.Count} threads");

                try {
                    var threads = process.Threads;
                    
                    foreach (ProcessThread thread in threads) {
                        ListViewItem listViewItem = new ListViewItem(thread.Id.ToString());
                        listViewItem.SubItems.Add(thread.PriorityLevel.ToString());
                        listViewItem.SubItems.Add(thread.StartTime.ToString());
                        listView2.Items.Add(listViewItem);
                    }
                }
                catch (Exception ex) {
                    label1.ForeColor = Color.Red;
                    label1.Text = ex.Message;
                }

                try
                {
                    var modules = process.Modules;

                    foreach (var module in modules)
                    {
                        try
                        {
                            ListViewItem listViewItem = new ListViewItem(module.ToString());
                            listView3.Items.Add(listViewItem);
                        }
                        catch { continue; }
                    }
                }
                catch {
                    label2.ForeColor = Color.Red;
                    label2.Text = $"Modules in {process.ProcessName} is inaccessible";
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
