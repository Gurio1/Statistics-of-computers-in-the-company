using WPF_46731r.ViewModels;

namespace WPF_46731r.Services
{
    public interface INavigationService<TViewModel> where TViewModel : ViewModelBase
    {
        void Navigate();
    }
}
