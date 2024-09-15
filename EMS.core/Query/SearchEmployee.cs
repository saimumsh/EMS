using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.core.Query
{
    public class SearchEmployee
    {
        public string? SName { get; set; }
        public string? SEmail { get; set; }
        public DateOnly? SDOB { get; set; }
        public string? SMobile { get; set; }
    }
}
