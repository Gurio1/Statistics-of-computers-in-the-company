using System.Security;
using System.Windows;
using System.Windows.Controls;
namespace WPF_46731r.Controls
{
    /// <summary>
    /// Interaction logic for BindablePasswordBox.xaml
    /// </summary>
    /// 
    public partial class BindablePasswordBox : UserControl
    {
        private static readonly DependencyProperty PasswordProprety = 
            DependencyProperty.Register("Password",typeof(string),typeof(BindablePasswordBox));

        public string Password
        {
            get { return (string)GetValue(PasswordProprety); }
            set { SetValue(PasswordProprety, value); }
        }
        public BindablePasswordBox()
        {
            InitializeComponent();
            txtPassword.PasswordChanged += OnPasswordChanged;
        }

        private void OnPasswordChanged(object sender,RoutedEventArgs e)
        {
            Password = txtPassword.Password;
        }
    }
}
