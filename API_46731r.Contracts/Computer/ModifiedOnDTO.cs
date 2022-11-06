using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_46731r.Contracts.Computer
{
    public class ModifiedOnDTO
    {
        public DateTime CheckedOn { get; set; }
        public string CheckedBy { get; set; }
        public string? Log { get; set; }
    }
}
