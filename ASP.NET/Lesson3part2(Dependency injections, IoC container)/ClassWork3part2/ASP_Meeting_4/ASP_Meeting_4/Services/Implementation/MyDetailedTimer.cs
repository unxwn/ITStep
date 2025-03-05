using ASP_Meeting_4.Services.Abstract;

namespace ASP_Meeting_4.Services.Implementation
{
    public class MyDetailedTimer : IMyTimer
    {
        public string CurrentTime { get ; init ; }

        public MyDetailedTimer()
        {
            CurrentTime = string.Format("{0:MMMM dddd, yyyy H:mm:ss FFFFF}", DateTime.Now);
        }
    }
}
