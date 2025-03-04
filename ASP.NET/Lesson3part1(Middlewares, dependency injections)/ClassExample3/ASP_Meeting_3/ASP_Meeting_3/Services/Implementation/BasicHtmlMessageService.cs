using ASP_Meeting_3.Services.Abstract;
using System.Text;

namespace ASP_Meeting_3.Services.Implementation
{
    public class BasicHtmlMessageService : IMessageService
    {

        public string GetMessage(string message)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<h2 style='color: red'>");
            sb.Append(message);
            sb.Append("</h2>");
            return sb.ToString();
        }
    }
}
