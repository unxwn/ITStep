using ASP_Meeting_3.Services.Abstract;
using System.Text;

namespace ASP_Meeting_3.Services.Implementation
{
    public class ModalMessageService : IMessageService
    {
        public string GetMessage(string message)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<div style='min-height:100vh;position:relative; " +
                "background-color: #aaa'>");
            sb.Append($"<div style='position: absolute; top:20px; left: 20px;" +
                $"right: 20px; bottom: 20px; background-color: #ddd'>{message}</div>");
            sb.Append("</div>");
            return sb.ToString();  

        }
    }
}
