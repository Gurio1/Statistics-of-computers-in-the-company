using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_46731r.Domain.Models.Computer
{
    public class Characteristics
    {
        public string processor { get; set; }
        public int ram { get; set; }
        public string motherBoard { get; set; }
        public int storage { get; set; }
    }

    public class CheckedOn
    {
        public DateTime checkedOn { get; set; }
        public string checkedBy { get; set; }
    }

    public class ModifiedOn
    {
        public DateTime checkedOn { get; set; }
        public string checkedBy { get; set; }
        public string log { get; set; }
    }

    public class Computer
    {
        public int inventoryNumber { get; set; }
        public string hostName { get; set; }
        public string mac { get; set; }
        public string state { get; set; }
        public Characteristics characteristics { get; set; }
        public List<CheckedOn> checkedOn { get; set; }
        public List<ModifiedOn> modifiedOn { get; set; }
        public List<string> computerComments { get; set; }
    }


}
