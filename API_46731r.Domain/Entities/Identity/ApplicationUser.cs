using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_46731r.Domain.Entities.Identity
{
    public class ApplicationUser : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string HashedPassword{ get; set; }


        public int RoleId { get; set; }
        public virtual ApplicationRole Role { get; set; }


    }
}
