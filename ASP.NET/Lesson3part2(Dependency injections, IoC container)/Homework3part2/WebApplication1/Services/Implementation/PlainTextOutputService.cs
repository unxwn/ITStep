using System.Text;
using WebApplication1.Services.Abstraction;

namespace WebApplication1.Services.Implementation
{
    public class PlainTextOutputService : IOutputService
    {
        public string OutputMode => "plain";
        private StringBuilder _sb = new StringBuilder();
        public void AppendLine(string text) => _sb.AppendLine(text);
        public string GetOutput() => _sb.ToString();
    }
}
