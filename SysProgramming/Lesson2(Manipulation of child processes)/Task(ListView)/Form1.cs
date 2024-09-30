using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Task_ListView_
{
    public partial class Form1 : Form
    {
        private Timer updateTimer;

        public Form1()
        {
            InitializeComponent();

            listView1.View = View.Details;
            listView1.Columns.Add("process_id", 75);
            listView1.Columns.Add("process_name", 225);
            listView1.Columns.Add("cpu_time", 100);
            listView1.Columns.Add("thread_count", 100);
            listView1.Columns.Add("instance_count", 100);
            listView1.FullRowSelect = true;

            listView2.View = View.Details;
            listView2.Columns.Add("thread_id", 75);
            listView2.Columns.Add("thread_priorityLvl", 100);
            listView2.Columns.Add("thread_startTime", 125);
            listView2.FullRowSelect = true;

            listView3.View = View.Details;
            listView3.Columns.Add("module_name", 300);
            listView3.FullRowSelect = true;

            updateTimer = new System.Windows.Forms.Timer();
            updateTimer.Tick += UpdateProcessList;
            updateTimer.Interval = 1000;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int id = int.Parse(listView1.SelectedItems[0].Text);
                Process process = Process.GetProcessById(id);
                try
                {
                    process.Kill();
                    MessageBox.Show($"Process {process.ProcessName} (ID: {process.Id}) has been terminated.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to terminate process: {ex.Message}");
                }
            }
        }

        private void UpdateProcessList(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            Process[] processes = Process.GetProcesses();
            var processGroups = processes.GroupBy(p => p.ProcessName);

            foreach (var processGroup in processGroups)
            {
                foreach (Process process in processGroup)
                {
                    try
                    {
                        ListViewItem listViewItem = new ListViewItem(process.Id.ToString());
                        listViewItem.SubItems.Add(process.ProcessName);
                        listViewItem.SubItems.Add(process.TotalProcessorTime.TotalSeconds.ToString("F2") + " s");
                        listViewItem.SubItems.Add(process.Threads.Count.ToString());
                        listViewItem.SubItems.Add(processGroup.Count().ToString());
                        listView1.Items.Add(listViewItem);
                    }
                    catch (Win32Exception ex)
                    {
                        ListViewItem listViewItem = new ListViewItem(process.Id.ToString());
                        listViewItem.SubItems.Add(process.ProcessName);
                        listViewItem.SubItems.Add("Access Denied");
                        listViewItem.SubItems.Add("Access Denied");
                        listViewItem.SubItems.Add(processGroup.Count().ToString());
                        listView1.Items.Add(listViewItem);
                    }
                    catch (Exception ex)
                    {
                        ListViewItem listViewItem = new ListViewItem(process.Id.ToString());
                        listViewItem.SubItems.Add(process.ProcessName);
                        listViewItem.SubItems.Add("Error");
                        listViewItem.SubItems.Add("Error");
                        listViewItem.SubItems.Add(processGroup.Count().ToString());
                        listView1.Items.Add(listViewItem);
                    }
                }
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

                try
                {
                    var threads = process.Threads;

                    foreach (ProcessThread thread in threads)
                    {
                        ListViewItem listViewItem = new ListViewItem(thread.Id.ToString());
                        listViewItem.SubItems.Add(thread.PriorityLevel.ToString());
                        listViewItem.SubItems.Add(thread.StartTime.ToString());
                        listView2.Items.Add(listViewItem);
                    }
                }
                catch (Exception ex)
                {
                    label1.ForeColor = Color.Red;
                    label1.Text = ex.Message;
                }

                try
                {
                    var modules = process.Modules;

                    foreach (ProcessModule module in modules)
                    {
                        ListViewItem listViewItem = new ListViewItem(module.ModuleName);
                        listView3.Items.Add(listViewItem);
                    }
                }
                catch
                {
                    label2.ForeColor = Color.Red;
                    label2.Text = $"Modules in {process.ProcessName} is inaccessible";
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int interval) && interval > 0)
            {
                updateTimer.Interval = interval * 1000;
                updateTimer.Start();
            }
            else
            {
                updateTimer.Stop();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            updateTimer.Start();
        }
    }
}