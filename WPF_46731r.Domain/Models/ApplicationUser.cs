using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_46731r.Domain.Models
{
    public class ApplicationUser
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("secondName")]
        public string SecondName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("jwt")]
        public string JWT { get; set; }

        public override string ToString()
        {
            return Name + " " + SecondName;
        }
    }
}
