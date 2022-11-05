using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_46731r.Domain.Entities.Identity
{
    public class ApplicationRole : BaseEntity
    {
        public string Name { get; set; }

        public int Force { get; set; }

        public virtual ICollection<ApplicationUser>? ApplicationUsers { get; set; }
    }
}
