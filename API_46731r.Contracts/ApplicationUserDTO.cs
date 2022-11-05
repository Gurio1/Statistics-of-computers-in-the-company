using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_46731r.Contracts
{
    public class ApplicationUserDTO
    {
        public string Name { get; set; }

        public string SecondName { get; set; }

        public string Email { get; set; }

        public string JWT { get; set; }
    }
}
