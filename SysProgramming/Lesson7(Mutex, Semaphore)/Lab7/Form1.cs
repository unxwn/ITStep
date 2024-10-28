using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace Lab7
{
    public partial class Form1 : Form
    {
        private int threadCounter = 1;
        private Semaphore semaphore;
        private List<ThreadInfo> createdThreads = new List<ThreadInfo>();
        private Dictionary<int, ThreadInfo> workingThreads = new Dictionary<int, ThreadInfo>();
        private System.Windows.Forms.Timer updateTimer;
        private bool isRunning = false;

        public Form1()
        {
            InitializeComponent();
            semaphore = new Semaphore((int)numericUpDown1.Value, (int)numericUpDown1.Value);

            listView1.View = View.Details;
            listView1.Columns.Add("threads", 100);

            listView2.View = View.Details;
            listView2.Columns.Add("threads", 100);
            listView2.FullRowSelect = true;

            listView3.View = View.Details;
            listView3.Columns.Add("threads", 100);
            listView3.Columns.Add("duration", 100);
            listView3.FullRowSelect = true;

            updateTimer = new System.Windows.Forms.Timer();
            updateTimer.Interval = 1000;
            updateTimer.Tick += UpdateListView3;
            updateTimer.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThreadInfo threadInfo = new ThreadInfo(threadCounter++);
            createdThreads.Add(threadInfo);
            UpdateListView(listView1, createdThreads, includeCounter: false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (isRunning)
            {
                ResetApplication();
            }
            else
            {
                isRunning = true;
                button1.Enabled = true;
                numericUpDown1.Enabled = false;
                button2.Text = "Stop";
                semaphore = new Semaphore((int)numericUpDown1.Value, (int)numericUpDown1.Value);
                updateTimer.Start();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            int newValue = (int)numericUpDown1.Value;
            semaphore = new Semaphore(newValue, newValue);
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int index = listView1.SelectedItems[0].Index;
                if (index >= 0 && index < createdThreads.Count)
                {
                    ThreadInfo selectedThread = createdThreads[index];
                    createdThreads.Remove(selectedThread);
                    AddToWaitingQueue(selectedThread);
                    UpdateListView(listView1, createdThreads, includeCounter: false);
                }
            }
        }

        private async void listView3_DoubleClick(object sender, EventArgs e)
        {
            if (listView3.SelectedItems.Count > 0)
            {
                int threadId = int.Parse(listView3.SelectedItems[0].Text.Split(' ')[1]);
                if (workingThreads.ContainsKey(threadId))
                {
                    ThreadInfo threadToRemove = workingThreads[threadId];
                    if (threadToRemove.isOccupied)
                    {
                        await threadToRemove.StopAsync();
                        workingThreads.Remove(threadId);
                        semaphore.Release();
                        UpdateListView(listView3, workingThreads.Values, includeCounter: true);
                    }
                }
            }
        }

        private void AddToWaitingQueue(ThreadInfo threadInfo)
        {
            listView2.Items.Add(new ListViewItem("Thread " + threadInfo.Id));
            
            ThreadPool.QueueUserWorkItem(state =>
            {
                semaphore.WaitOne();
                threadInfo.isOccupied = true;
                Invoke((Action)(() =>
                {
                    RemoveFromListViewById(listView2, threadInfo.Id);
                    workingThreads[threadInfo.Id] = threadInfo;
                    threadInfo.Start();
                    UpdateListView(listView3, workingThreads.Values, includeCounter: true);
                }));
            });
        }

        private void UpdateListView(ListView listView, IEnumerable<ThreadInfo> threads, bool includeCounter)
        {
            listView.Items.Clear();
            foreach (var thread in threads)
            {
                var item = new ListViewItem($"Thread {thread.Id}");
                if (includeCounter)
                {
                    item.SubItems.Add($"{thread.Counter} sec");
                }
                listView.Items.Add(item);
            }
        }

        private void RemoveFromListViewById(ListView listView, int id)
        {
            foreach (ListViewItem item in listView.Items)
            {
                if (item.Text.Contains($"Thread {id}"))
                {
                    listView.Items.Remove(item);
                    break;
                }
            }
        }

        private void UpdateListView3(object sender, EventArgs e)
        {
            UpdateListView(listView3, workingThreads.Values, includeCounter: true);
        }

        private void ResetApplication()
        {
            foreach (var thread in workingThreads.Values)
            {
                thread.Stop();
            }
            createdThreads.Clear();
            workingThreads.Clear();
            listView1.Items.Clear();
            listView2.Items.Clear();
            listView3.Items.Clear();
            threadCounter = 1;

            button1.Enabled = false;
            numericUpDown1.Enabled = true;
            button2.Text = "Start";
            updateTimer.Stop();
            isRunning = false;
        }
    }
}
