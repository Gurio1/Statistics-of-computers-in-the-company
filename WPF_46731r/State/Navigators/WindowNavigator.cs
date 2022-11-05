using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_46731r.ViewModels;

namespace WPF_46731r.State.Navigators
{
    public class WindowNavigator
    {
        private Window _currentView;
        public event Action CurrentViewChanged;
        public Window CurrentView
        {
            get
            {
                return _currentView;
            }
            set
            {
                _currentView?.Close();

                _currentView = value;
                _currentView.Show();
                OnCurrentViewChanged();
            }
        }

        private void OnCurrentViewChanged()
        {
            CurrentViewChanged?.Invoke();
        }
    }
}
