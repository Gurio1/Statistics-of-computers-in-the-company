using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using WPF_46731r.Domain.Models;
using WPF_46731r.Domain.Models.Computer;
using System.Collections.ObjectModel;

namespace WPF_46731r.Domain.Service
{
    public class HttpService
    {
        public static async Task<AutheticationServerResponse> LogIn(string email,string password)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "Your Oauth token");

                var user = new UserVm() { Email = email, Password = password };
                var response = await client.PostAsJsonAsync("https://localhost:7211/api/Authentication", user);

                if (response.IsSuccessStatusCode)
                {
                    return new AutheticationServerResponse() {User = await response.Content.ReadFromJsonAsync<ApplicationUser>(),  IsSuccessStatusCode = response.IsSuccessStatusCode };
                }

                var result =  await response.Content.ReadFromJsonAsync<AutheticationServerResponse>();
                result.IsSuccessStatusCode = false;
                result.StatusCode = (int)response.StatusCode;

                return result;
            }
        }

        public static async Task<ObservableCollection<Building>> GetAllBuildings(ApplicationUser user)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",$"{user.JWT}" );


                var response = await client.GetAsync("https://localhost:7211/Building/GetAllComputers");

                if (response.IsSuccessStatusCode)
                {
                    var test = await response.Content.ReadFromJsonAsync<List<Building>>();
                    return new ObservableCollection<Building>(test);
                }
                return null;
            }
        }
    }
}
