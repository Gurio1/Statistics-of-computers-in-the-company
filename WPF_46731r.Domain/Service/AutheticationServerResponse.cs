using Newtonsoft.Json;
using WPF_46731r.Domain.Models;

namespace WPF_46731r.Domain.Service
{
    public class AutheticationServerResponse
    {
        [JsonProperty("errors")]
        public Errors Errors { get; set; }

        public ApplicationUser User { get; set; }

        public int StatusCode { get; set; }

        public bool IsSuccessStatusCode { get; set; }
    }
}
