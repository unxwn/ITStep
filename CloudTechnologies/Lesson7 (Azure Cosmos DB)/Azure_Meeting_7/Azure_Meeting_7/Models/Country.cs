using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Azure_Meeting_7.Models
{
    public class Country
    {
        public string Name { get; set; } = default!;

        public string PhoneCode { get; set; } = default!;

        public override string ToString()
        {
            return $"{Name}, Phone Code: {PhoneCode}";
        }
    }
}
