using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_46731r.Services.Authentication
{
    public class AutheticationResult<ApplicationUser>
    {
        public bool IsSucceded { get; set; } = true;
        public string Error { get; set; } = String.Empty;
        public ApplicationUser User { get; set; }
    }
}
