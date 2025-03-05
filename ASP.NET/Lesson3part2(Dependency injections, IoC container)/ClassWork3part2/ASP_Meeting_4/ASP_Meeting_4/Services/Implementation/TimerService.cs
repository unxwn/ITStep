using ASP_Meeting_4.Services.Abstract;

namespace ASP_Meeting_4.Services.Implementation
{
    public class TimerService
    {
        public TimerService(IMyTimer timer)
        {
            Timer = timer;
        }

        public IMyTimer Timer { get; }
    }
}
