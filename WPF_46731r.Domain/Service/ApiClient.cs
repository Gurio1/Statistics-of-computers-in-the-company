using System.Net.Http.Json;
using System.Net.Http.Headers;
using WPF_46731r.Domain.Models;
using System.Collections.ObjectModel;
using System.Text.Json;
using WPF_46731r.Domain.Models.Computer;
using WPF_46731r.Domain.Service.Abstractions;

namespace WPF_46731r.Domain.Service
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _client;

        public ApiClient(HttpClient client)
        {
            _client = client;
        }
    
            public async Task<AuthenticationServerResponse> LogIn(string email,string password)
            {
                _client.DefaultRequestHeaders.Accept.Clear();
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var user = new UserVm() { Email = email, Password = password };
                var response = await _client.PostAsJsonAsync("https://localhost:7211/api/Authentication", user);

                if (!response.IsSuccessStatusCode)
                {
                    var serverResponse =  await response.Content.ReadFromJsonAsync<AuthenticationServerResponse>();
                    if (serverResponse is null)
                    {
                        throw new Exception("Can not handle server response");
                    }

                    serverResponse.IsSuccessStatusCode = response.IsSuccessStatusCode;
                    serverResponse.StatusCode = (int)response.StatusCode;
                    return serverResponse;
                }

                var userFromServer = await response.Content.ReadFromJsonAsync<ApplicationUser>();
                return new AuthenticationServerResponse() { User = userFromServer, IsSuccessStatusCode = true };
            }

            public async Task<ObservableCollection<Building>> GetAllBuildings(ApplicationUser user)
        {
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",$"{user.JWT}" );


                var response = await _client.GetAsync("https://localhost:7211/Building/GetAll");

                if (!response.IsSuccessStatusCode) throw new Exception("Cant get all buildings");
                
                var entities = await response.Content.ReadFromJsonAsync<List<Building>>();
                if (entities != null) return new ObservableCollection<Building>(entities);
                
                throw new Exception("Can't serialize entities from server response");
        }

            public async Task<BaseEntity> CreateAsync<T>(T entity) where T : BaseEntity
            {
                _client.DefaultRequestHeaders.Accept.Clear();
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (entity is Computer computer)
                {
                    var json =  JsonSerializer.Serialize(computer);
                    
                    var response = await _client.PostAsJsonAsync($"https://localhost:7211/Room/AddComputer",entity);
                    var compFromServer = await response.Content.ReadFromJsonAsync<Computer>();
                    if (compFromServer is null)
                    {
                        return null;
                    }

                    return compFromServer;
                }
                else if (entity is Room)
                {

                    var response = await _client.PostAsJsonAsync($"https://localhost:7211/Building/AddRoom",entity);
                    var roomFromServer = await response.Content.ReadFromJsonAsync<Room>();
                    if (roomFromServer is null)
                    {
                        return null;
                    }

                    return roomFromServer;
                }
                else if (entity is Building building)
                {
                    var json =  JsonSerializer.Serialize(building);
                    var response = await _client.PostAsJsonAsync($"https://localhost:7211/Building/CreateEntity",entity);
                    var buildingFromServer = await response.Content.ReadFromJsonAsync<Building>();
                    if (buildingFromServer is null)
                    {
                        return null;
                    }

                    return buildingFromServer;
                }

                return null;
            }

            public async Task<bool> UpdateAsync<T>(T entity) where T : BaseEntity
            {
                _client.DefaultRequestHeaders.Accept.Clear();
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                if (entity is Computer computer)
                {
                    var response = await _client.PutAsJsonAsync($"https://localhost:7211/Computer/UpdateComputer",computer); //https://localhost:7211/Computer/UpdateComputer
                    return response.IsSuccessStatusCode;
                }
                else
                {
                    var json = JsonSerializer.Serialize(entity);
                    var response = await _client.PutAsJsonAsync($"https://localhost:7211/{entity.GetType().Name}/UpdateEntity",entity);
                    return response.IsSuccessStatusCode;
                }
            }

            public async Task<bool> DeleteAsync<T>(T entity) where T : BaseEntity
            {
                _client.DefaultRequestHeaders.Accept.Clear();
                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await _client.DeleteAsync($"https://localhost:7211/{entity.GetType().Name}/DeleteEntity/{entity.Id}");

                return response.IsSuccessStatusCode;
            }
    }
    }
