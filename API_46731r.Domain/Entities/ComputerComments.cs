using API_46731r.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_46731r.Domain.Entities
{
    public class ComputerComments :BaseEntity
    {
        public int UserId { get; set; }
        public int ComputerId { get; set; }

        public string Content { get; set; }
        public DateTime PostedOn { get; set; }
  

        public virtual ApplicationUser User { get; set; }
        public virtual Computer Computer { get; set; }

    }
}
