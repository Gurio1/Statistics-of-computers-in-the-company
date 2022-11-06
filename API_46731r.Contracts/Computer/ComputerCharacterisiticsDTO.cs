using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_46731r.Contracts.Computer
{
    public class ComputerCharacterisiticsDTO
    {
        public string? Processor { get; set; }
        public int? RAM { get; set; }
        public string? MotherBoard { get; set; }
        public int? Storage { get; set; }
    }
}
