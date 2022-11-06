using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_46731r.Contracts.Computer
{
    public class ComputerCommentsDTO
    {
        public string Content { get; set; }
        public DateTime PostedOn { get; set; }
        public string UserName { get; set; }
    }
}
