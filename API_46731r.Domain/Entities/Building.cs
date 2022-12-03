using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_46731r.Domain.Entities
{
    public class Building : BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Room> ?Rooms { get; set; }
    }
}
