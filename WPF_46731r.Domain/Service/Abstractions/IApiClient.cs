using System.Collections.ObjectModel;
using WPF_46731r.Domain.Models;
using WPF_46731r.Domain.Models.Abstractions;

namespace WPF_46731r.Domain.Service.Abstractions;

public interface IApiClient
{
    Task<AuthenticationServerResponse> LogIn(string email, string password);

    Task<ObservableCollection<Building>> GetAllBuildings(ApplicationUser user);
    
    Task<BaseEntity> CreateAsync<T>(T entity) where T : BaseEntity; 
    Task<bool> UpdateAsync<T>(T entity) where T : BaseEntity;
    Task<bool> DeleteAsync<T>(T entity) where T : BaseEntity;
}