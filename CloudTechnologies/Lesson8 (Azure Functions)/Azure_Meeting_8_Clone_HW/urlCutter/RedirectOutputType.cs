using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;

namespace urlCutter
{
    public class RedirectOutputType
    {
        [HttpResult]
        public IActionResult Result { get; set; } = default!;

        [QueueOutput("counts")]
        public string? Message { get; set; }
    }
}
