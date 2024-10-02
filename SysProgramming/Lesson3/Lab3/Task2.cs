using System;
using System.IO;
using System.Threading;

public class Bank
{
    private readonly string FILE_PATH = "bank_log.txt";

    public int Money { get; private set; }
    public string Name { get; private set; }
    public int Percent { get; private set; }

    public void UpdateMoney(int value)
    {
        Money = value;
        LogChanges();
    }

    public void UpdateName(string value)
    {
        Name = value;
        LogChanges();
    }

    public void UpdatePercent(int value)
    {
        Percent = value;
        LogChanges();
    }

    private void LogChanges()
    {
        ThreadStart TS = new ThreadStart(() =>
        {
            string logEntry = $"Time: {DateTime.Now}, Name: {Name}, Money: {Money}, Percent: {Percent}";

            try
            {
                File.AppendAllText(FILE_PATH, logEntry + "\n");
                Console.WriteLine("Changes saved to the file");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred when saving the data to file: {ex.Message}");
            }
        });
        Thread logThread = new Thread(TS);
        logThread.Start();
        logThread.Join();
    }
}