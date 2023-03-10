using System.Text.Json.Serialization;

namespace WPF_46731r.Domain.Service
{
   public class Errors
   {
       [JsonPropertyName("Password")]
       public List<string>? Password { get; set; }
   
       [JsonPropertyName("Email")]
       public List<string>? Email { get; set; }
   
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