using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure_Meeting_7.Models
{
    public class Book
    {
        public string Title { get; set; } = default!;

        public int Pages { get; set; }

        public int YearOfPublish { get; set; } = default!;

    }
}
