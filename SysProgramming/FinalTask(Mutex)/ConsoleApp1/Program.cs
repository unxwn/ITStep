using System;
using System.Security.Principal;
using System.Threading;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main()
        {
            bool mutexIsOccupied = false;
            Mutex mutex = null;
            try
            {
                mutex = Mutex.OpenExisting("MyMutexName");
                Console.WriteLine("Another instance of app is already running ");
                
            }
            catch (WaitHandleCannotBeOpenedException)
            {
                mutex = new Mutex(true, "MyMutexName");
                mutexIsOccupied = true;

                Console.WriteLine("It`s first instance of app");
                Console.WriteLine("Mutex is captured by current thread");
                Console.ReadKey(true);
            }
            catch (Exception ex) { Console.WriteLine(ex.ToString()); }
            finally
            {
                if (mutexIsOccupied == true)
                {
                    mutex.ReleaseMutex();
                    mutex.Dispose();
                }
            }

        }
    }
}
