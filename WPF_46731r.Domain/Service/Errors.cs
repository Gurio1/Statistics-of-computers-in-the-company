using Newtonsoft.Json;

namespace WPF_46731r.Domain.Service
{
    public class Errors
    {
        [JsonProperty("Password")]
        public List<string> Password { get; set; }

        [JsonProperty("Email")]
        public List<string> Email { get; set; }

        public string PasswordErrorsToString()
        {
          return Password is null? string.Empty : string.Join(Environment.NewLine, Password);
        }

        public string EmailErrorsToString()
        {
            return Email is null ? string.Empty :  string.Join(Environment.NewLine, Email);
        }
    }
}