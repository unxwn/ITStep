using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lab7
{
    internal class ThreadInfo
    {
        public int Id { get; private set; }
        public int Counter { get; private set; }
        public DateTime StartTime { get; set; } 
        public bool isOccupied;
        private Thread thread;
        private bool isRunning;

        public ThreadInfo(int id)
        {
            Id = id;
            Counter = 0;
            isOccupied = false;
            isRunning = false;
        }

        public void Start()
        {
            isRunning = true;
            thread = new Thread(() =>
            {
                while (isRunning)
                {
                    Counter++;
                    Thread.Sleep(1000);
                }
            });
            thread.Start();
        }

        public async Task StopAsync()
        {
            isRunning = false;
            if (thread != null && thread.IsAlive)
            {
                await Task.Run(() => thread.Join());
            }
        }

        public void Stop()
        {
            isRunning = false;
            thread?.Join();
        }
    }
}
