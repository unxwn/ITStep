using ASP_Meeting_4.Services.Abstract;
namespace ASP_Meeting_4.Services.Implementation
{
    public class MyTimer : IMyTimer
    {
        public string CurrentTime { get ; init ; }

        public MyTimer() {
            CurrentTime = string.Format("{0:MM/dd/yy H:mm:ss FFFFF}", DateTime.Now);
            //CurrentTime = string.Format("{0:FFFFF}", DateTime.Now);
        }
    }
}
