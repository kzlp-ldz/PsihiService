using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Core;
using WPF.Pages;
using WPF.Pages.ClientPages;
using WPF.Pages.EmployeePages;

namespace WPF
{
    /// <summary>
    /// Логика взаимодействия для AutoPage.xaml
    /// </summary>
    public partial class AutoPage : Page
    {
        
        User user = new User();
        Employee employee = new Employee();
        Client client = new Client();
        public AutoPage()
        {
            InitializeComponent();
        }
        private void btnConnect(object sender, RoutedEventArgs e)
        {
            var users = DataManag.GetUsers().Where(a => a.login == login.Text && a.password == password.Text).FirstOrDefault();
            user = DataManag.GetUser(users.id_user);
            if (login.Text == user.login && password.Text == user.password)
            {
                if (user.id_user == client.id_user)
                    NavigationService.Navigate(new EmployeeListPage());
                else
                    NavigationService.Navigate(new ClientsListPage());
            }
            else
                MessageBox.Show("Неверный пароль или логин");
        }
        private void btnRegist(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegistPage());
        }
    }
}
