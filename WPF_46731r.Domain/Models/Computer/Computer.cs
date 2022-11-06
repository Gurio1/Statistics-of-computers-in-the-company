using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_46731r.Domain.Models.Computer
{
    public class Computer
    {
        public int inventoryNumber { get; set; }
        public string hostName { get; set; }
        public string mac { get; set; }
        public string state { get; set; }
        public Characteristics characteristics { get; set; }
        public CheckedOn LastChecked { get; set; }
        public ModifiedOn LastModified { get; set; }
        public List<string> computerComments { get; set; }
    }


}
