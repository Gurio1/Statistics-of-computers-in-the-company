using API_46731r.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_46731r.Domain.Entities.ComputerState
{
    public abstract class TimeStateCheckedByStaff : BaseEntity
    {
        public int UserId { get; set; }
        public int ComputerId { get; set; }

        public DateTime CheckedOn { get; set; }
        public ApplicationUser CheckedBy { get; set; }
    }
}
