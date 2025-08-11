using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure_Meeting_8
{
    public class RedirectOutputType
    {
        [HttpResult]
        public IActionResult Result { get; set; } = default!;
        [QueueOutput("counts")]
        public string? Message { get; set; }
    }
}
